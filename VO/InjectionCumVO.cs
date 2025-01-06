using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VP_QM_winform.VO
{
    public class InjectionCumVO
    {
        public string LineId { get; set; } // line_id 컬럼: varchar(10)
        public DateTime Time { get; set; } // time 컬럼: timestamptz
        public string LotId { get; set; } // lot_id 컬럼: varchar(20)
        public string Shift { get; set; } // shift 컬럼: varchar(4)
        public string EmployeeNumber { get; set; } // employee_number 컬럼: bpchar(10)
        public int Total { get; set; } // total 컬럼: int4
    }
}
