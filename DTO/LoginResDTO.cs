using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VP_QM_winform.VO;

namespace VP_QM_winform.DTO
{
    public  class LoginResDTO
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("loginId")]
        public string LoginId { get; set; }

        [JsonProperty("employeeNumber")]
        public int EmployeeNumber { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("photo")]
        public string Photo { get; set; }

        [JsonProperty("shift")]
        public string Shift { get; set; }

        [JsonProperty("jwtToken")]
        public string JwtToken { get; set; }

        [JsonProperty("jwtPublicKey")]
        public string JwtPublicKey { get; set; }

        public override string ToString()
        {
            return $"UserVO [Id={Id}, LoginId={LoginId}, EmployeeNumber={EmployeeNumber}, Name={Name}, Photo={Photo}, " +
                   $"Shift={Shift}, JwtToken={JwtToken} , JwtPublicKey={JwtPublicKey}";
        }
    }
}
