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
        private byte[] _ngImg;
        public byte[] NGImg
        {
            get => _ngImg;
            set
            {
                _ngImg = value;
                if (_ngImg != null)
                {
                    Console.WriteLine($"NGImg has been set. Length: {_ngImg.Length} bytes");
                }
            }
        }
        public string StageVal { get; set; }

    }
}
