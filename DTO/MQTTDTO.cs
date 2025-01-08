using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VP_QM_winform.DTO
{
    public class MQTTDTO
    {
        public string LineId {  get; set; }
        public string LotId { get; set; }
        public string Shift { get; set; }
        public int EmployeeNumber {  get; set; }
        public byte[] NGImg { get; set; }
        public string StageVal { get; set; }

    }
}
