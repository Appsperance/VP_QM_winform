using Dapper;
using System;
using System.Linq;
using System.Reflection;


namespace VP_QM_winform.Helper
{
    public static class DapperExtensions
    {
        public static void RegisterSnakeCaseMappers(Assembly assembly, string namespaceFilter = null)
        {
            // 지정된 어셈블리에서 모든 클래스 타입을 찾음
            var types = assembly.GetTypes()
                .Where(t => t.IsClass && t.IsPublic && (namespaceFilter == null || t.Namespace == namespaceFilter))
                .ToList();

            foreach (var type in types)
            {
                SqlMapper.SetTypeMap(type, new SnakeCaseMapper(type));
                Console.WriteLine($"Dapper Snake Case Mapper 등록: {type.Name}");
            }
        }
    }
}
