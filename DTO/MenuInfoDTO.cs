using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VP_QM_winform.DTO
{
    public class MenuInfoDTO
    {
        public string LineId { get; set; } = "비전검사 1호";
        public string PartId { get; set; }
        public string LotId { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }

    }
}
