using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VP_QM_winform.DTO
{
    public class LoginInfoDTO
    {
        public string LoginId { get; set; }
        public int EmployeeNumber { get; set; }
        public string Name { get; set; }
        public string Shift { get; set; }
        public string Photo { get; set; }
        public string Role { get; set; }
        public string JwtToken { get; set; }
    }
}
