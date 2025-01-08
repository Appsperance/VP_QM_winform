using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VP_QM_winform.VO;

namespace VP_QM_winform.DTO
{
    public  class LoginDTO
    {
        public  UserVO User { get; set; }
        public  EmployeeVO Employee { get; set; }
    }
}
