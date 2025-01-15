using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VP_QM_winform.DTO
{
    public class VisionHistoryDTO
    {
        public int No { get; set; } // 고유 번호
        public DateTime VisionTime { get; set; } = DateTime.Now;
        public NgType Label { get; set; }
        public string EmployeeName { get; set; }

        // ToString 재정의
        public override string ToString()
        {
            return $" Label: {Label}, VisionTime: {VisionTime:yyyy-MM-dd HH:mm:ss}, EmployeeName: {EmployeeName}";
        }
    }

    

}
