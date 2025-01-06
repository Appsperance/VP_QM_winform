using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VP_QM_winform.VO;


namespace VP_QM_winform.DAO
{
    internal interface IUserDAO
    {
        /// <summary>
        /// 로그인 ID로 사용자를 가져옵니다.
        /// </summary>
        /// <param name="loginId">사용자의 로그인 ID</param>
        /// <param name="loginPw">사용자의 로그인 ID</param>
        /// <returns>UserVO 객체</returns>
        UserVO Login(string loginId);
        string GetHashedPwdByLoginId(string loginId);
        string GetSaltByLoginId(string loginId);
    }
}
