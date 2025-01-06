using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VP_QM_winform.DAO;
using VP_QM_winform.Helper;
using VP_QM_winform.VO;

namespace VP_QM_winform.Service
{
    public class LoginService
    {
        private UserDAO userDAO;

        public UserVO Login(string loginId, string loginPw)
        {
            string storedHash = userDAO.GetHashedPwdByLoginId(loginId);
            string storedSalt = userDAO.GetSaltByLoginId(loginId);

            var result = PasswordHasher.VerifyHash(loginPw, storedSalt, storedHash);
            Console.WriteLine(result);

            if (result)
            {
                return userDAO.Login(loginId);
            }

            return null;
        }

    }
}
