using System;
using System.Linq;
using System.Reflection;
using Dapper;

namespace VP_QM_winform.Helper
{
    public class SnakeCaseMapper : SqlMapper.ITypeMap
    {
        private readonly Type _type;

        public SnakeCaseMapper(Type type)
        {
            _type = type;
        }

        public ConstructorInfo FindConstructor(string[] names, Type[] types)
        {
            // Dapper의 기본 생성자 매핑 사용
            return new DefaultTypeMap(_type).FindConstructor(names, types);
        }

        public SqlMapper.IMemberMap GetConstructorParameter(ConstructorInfo constructor, string columnName)
        {
            // Dapper의 기본 매핑 사용
            return new DefaultTypeMap(_type).GetConstructorParameter(constructor, columnName);
        }

        public SqlMapper.IMemberMap GetMember(string columnName)
        {
            // Snake Case -> Camel Case 매핑
            var property = _type
                .GetProperties(BindingFlags.Public | BindingFlags.Instance)
                .FirstOrDefault(p => ToSnakeCase(p.Name) == columnName);

            if (property != null)
            {
                return new CustomMemberMap(columnName, property);
            }

            // 필드 매핑 처리
            var field = _type
                .GetFields(BindingFlags.Public | BindingFlags.Instance)
                .FirstOrDefault(f => ToSnakeCase(f.Name) == columnName);

            return field != null ? new CustomMemberMap(columnName, field) : null;
        }

        public ConstructorInfo FindExplicitConstructor()
        {
            return new DefaultTypeMap(_type).FindExplicitConstructor();
        }

        private static string ToSnakeCase(string input)
        {
            if (string.IsNullOrEmpty(input))
                return input;

            // CamelCase -> snake_case 변환
            return string.Concat(input.Select((x, i) =>
                char.IsUpper(x) && i > 0 ? "_" + char.ToLower(x) : char.ToLower(x).ToString()));
        }
    }

    public class CustomMemberMap : SqlMapper.IMemberMap
    {
        private readonly string _columnName;
        private readonly MemberInfo _memberInfo;

        public CustomMemberMap(string columnName, MemberInfo memberInfo)
        {
            _columnName = columnName;
            _memberInfo = memberInfo;
        }

        public string ColumnName => _columnName;
        public FieldInfo Field => _memberInfo as FieldInfo;
        public PropertyInfo Property => _memberInfo as PropertyInfo;
        public Type MemberType => Field?.FieldType ?? Property?.PropertyType;
        public ParameterInfo Parameter => null;
    }
}
