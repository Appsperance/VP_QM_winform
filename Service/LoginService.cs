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

        // 현재 로그인된 사용자 정보를 보관할 static 필드
        public static UserVO CurrentUser { get; private set; }

        public void Login(string loginId, string loginPw)
        {
            userDAO = new UserDAO();
            string storedHash = userDAO.GetHashedPwdByLoginId(loginId);
            string storedSalt = userDAO.GetSaltByLoginId(loginId);

            var result = PasswordHasher.VerifyHash(loginPw, storedSalt, storedHash);
            Console.WriteLine(result);

            if (result)
            {
                CurrentUser = userDAO.Login(loginId);
            }
            else
            {
                Console.WriteLine("로그인 실패 : Service");

            }

        }

    }
}
