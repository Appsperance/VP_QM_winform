using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VP_QM_winform.VO
{
    public class UserVO
    {
        public int Id { get; set; }
        public string LoginId { get; set; }
        public string LoginPw { get; set; }
        public string Salt { get; set; }
        public string Name { get; set; }
        public int EmployeeNumber { get; set; }
        public string Roles { get; set; }

        public override string ToString()
        {
            return $"UserVO [Id={Id}, LoginId={LoginId}, LoginPw={LoginPw}, Salt={Salt}, Name={Name}, " +
                   $"EmployeeNumber={EmployeeNumber}, Roles={Roles}";
        }
    }
}
