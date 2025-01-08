using System;
using VP_QM_winform.DAO;
using VP_QM_winform.Helper;
using VP_QM_winform.VO;

namespace VP_QM_winform.Service
{
    public class LoginService
    {
        private UserDAO userDAO;
        private EmployeeDAO employeeDAO;
        // 현재 로그인된 사용자 정보를 보관할 static 필드
        

        public void Login(string loginId, string loginPw)
        {
            userDAO = new UserDAO();
            employeeDAO = new EmployeeDAO();

            string storedHash = userDAO.GetHashedPwdByLoginId(loginId);
            string storedSalt = userDAO.GetSaltByLoginId(loginId);

            var result = PasswordHasher.VerifyHash(loginPw, storedSalt, storedHash);
            Console.WriteLine($"loginId: {loginId}"); 
            Console.WriteLine(result);

            if (result)
            {
                UserVO userVO = userDAO.Login(loginId);
                Console.WriteLine(userVO.ToString());
                Global.s_LoginDTO.User = userVO;


                int employeeNumber = userVO.EmployeeNumber;
                Console.WriteLine($"employee : { employeeNumber}");
                
                Global.s_LoginDTO.Employee = employeeDAO.getEmployee(employeeNumber);
                
            }
            else
            {
                Console.WriteLine("로그인 실패 : Service");

            }

        }

    }
}
