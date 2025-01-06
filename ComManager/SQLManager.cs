using Npgsql;
using System;
using System.Data;

namespace VP_QM_winform.ComManager
{
    public class SQLManager
    {
        private readonly string _connectionString = "Host=localhost;Port=5432;Username=root;Password=vapor;Database=msd_db;";
        private IDbConnection _connection;

        /// <summary>
        /// DB 연결을 생성하거나 기존 연결을 반환합니다.
        /// </summary>
        /// <returns>IDbConnection 객체</returns>
        public IDbConnection GetConnection()
        {
            if (_connection == null || _connection.State == ConnectionState.Closed)
            {
                _connection = new NpgsqlConnection(_connectionString);
                _connection.Open();
                Console.WriteLine("DB 연결됨");
            }
            return _connection;
        }

        /// <summary>
        /// DB 연결을 닫습니다.
        /// </summary>
        public void CloseConnection()
        {
            if (_connection != null && _connection.State != ConnectionState.Closed)
            {
                _connection.Close();
                Console.WriteLine("DB 연결 닫힘");
            }
        }
    }
}
