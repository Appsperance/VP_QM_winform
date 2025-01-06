using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VP_QM_winform.VO
{
    public class EmployeeVO
    {
        public int Year { get; set; } // year 컬럼: int2
        public string Gender { get; set; } // gender 컬럼: bpchar(1)
        public int Sequence { get; set; } // sequence 컬럼: int2
        public string Name { get; set; } // name 컬럼: varchar(100)
        public string Department { get; set; } // department 컬럼: varchar(50)
        public string Shift { get; set; } // shift 컬럼: varchar(4)
        public string Title { get; set; } // title 컬럼: varchar(20)
        public DateTime JoinDate { get; set; } // join_date 컬럼: date
    }
}
