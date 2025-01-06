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
        public string EmployeeNumber { get; set; }
        public string Roles { get; set; }
        public string ProfileImg { get; set; }
        public string ProfileText { get; set; }
    }
}
