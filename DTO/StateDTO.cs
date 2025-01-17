using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VP_QM_winform.DTO
{
    public static class StateDTO
    {
        public static bool IsLogined { get; set; } = false;
        public static bool IsJobChecked { get; set; } = false;
        public static bool IsJobSelected { get; set; } = false;
        public static bool IsProcessing { get; set; } = false;
        public static bool IsStarted { get; set;} = false;
    }
}
