using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VP_QM_winform.DTO;
using VP_QM_winform.VO;

namespace VP_QM_winform.Helper
{
    public static class Global
    {
        public static List<VisionCumVO> s_VisionCumList { get; set; } = new List<VisionCumVO>();
        public static LoginInfoDTO s_LoginDTO { get; set; }
        public static MenuInfoDTO s_MenuDTO { get; set; }
        public static MQTTDTO s_MQTTDTO { get; set; }
        public static List<KeyValuePair<string, int>> s_LotQtyList {  get; set; }
        public static int s_LotQty { get; set; }
        
    }
}
