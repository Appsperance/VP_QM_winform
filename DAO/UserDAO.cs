using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VP_QM_winform.ComManager;
using VP_QM_winform.VO;

namespace VP_QM_winform.DAO
{
    public class UserDAO : IUserDAO
    {
        private readonly SQLManager _sqlManager;

        public UserDAO(SQLManager sqlManager)
        {
            _sqlManager = sqlManager;
        }

        public UserVO Login(string loginId)
        {
            try
            {
                var connection = _sqlManager.GetConnection();
                var query = "SELECT * FROM users WHERE login_id = @loginId;";
                return connection.QueryFirstOrDefault<UserVO>(query, new { loginId });
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error during login: {ex.Message}");
                return null;
            }
        }

        public string GetHashedPwdByLoginId(string loginId)
        {
            try
            {
                var connection = _sqlManager.GetConnection();
                var query = "SELECT login_pw FROM users WHERE login_id = @loginId";
                return connection.QueryFirstOrDefault<string>(query, new { loginId });
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error during login: {ex.Message}");
                return null;
            }
        }

        public string GetSaltByLoginId(string loginId)
        {
            try
            {
                var connection = _sqlManager.GetConnection();
                var query = "SELECT salt FROM users WHERE login_id = @loginId";
                return connection.QueryFirstOrDefault<string>(query, new { loginId });
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error during login: {ex.Message}");
                return null;
            }
        }
    }
}
