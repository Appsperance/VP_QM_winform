using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VP_QM_winform.VO
{
    public class LotVO
    {
        public string Id { get; set; } // varchar(50)
        public string PartId { get; set; } // varchar(10)
        public string LineId { get; set; } // varchar(10)
        public DateTime? IssuedTime { get; set; } // timestamptz (nullable DateTime)
        public int Qty { get; set; } // int4
        public int CompletedQty { get; set; } // int4
        public string VisionLineIds { get; set; } // text
        public DateTime? InjectionStart { get; set; } // timestamptz (nullable DateTime)
        public DateTime? InjectionEnd { get; set; } // timestamptz (nullable DateTime)
        public string InjectionWorker { get; set; } // text
        public DateTime? VisionStart { get; set; } // timestamptz (nullable DateTime)
        public DateTime? VisionEnd { get; set; } // timestamptz (nullable DateTime)
        public string VisionWorker { get; set; } // text
        public string Supplier { get; set; } // varchar(50)
        public string Note { get; set; } // text
    }
}
