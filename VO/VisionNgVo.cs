using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VP_QM_winform.VO
{
    public class VisionNgVO
    {
        public int Id { get; set; } // id 컬럼: serial4
        public string LotId { get; set; } // lot_id 컬럼: varchar(20)
        public string PartId { get; set; } // part_id 컬럼: varchar(5)
        public string LineId { get; set; } // line_id 컬럼: varchar(10)
        public DateTime DateTime { get; set; } // date_time 컬럼: timestamptz
        public string NgLabel { get; set; } // ng_label 컬럼: varchar(50)
        public string NgImgPath { get; set; } // ng_img_path 컬럼: text
    }
}
