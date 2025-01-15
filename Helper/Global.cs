using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VP_QM_winform.DTO;
using VP_QM_winform.VO;

namespace VP_QM_winform.Helper
{
    public static class Global
    {
        public static ObservableList<VisionHistoryDTO> s_VisionHistoryList { get; set; } = new ObservableList<VisionHistoryDTO>();
        public static LoginInfoDTO s_LoginDTO { get; set; }
        public static MenuInfoDTO s_MenuDTO { get; set; }
        public static MQTTDTO s_MQTTDTO { get; set; }
        public static List<KeyValuePair<string, int>> s_LotQtyList {  get; set; }
        public static int s_LotQty { get; set; }
        
    }

    public class ObservableList<T> : List<T>
    {
        public event Action ListChanged; // 리스트 변경 이벤트
        public new void Add(T item)
        {
            // No 값을 자동으로 설정 (T가 VisionHistoryDTO일 경우)
            if (item is VisionHistoryDTO visionHistoryDTO)
            {
                visionHistoryDTO.No = this.Count + 1; // No 값을 Count + 1로 설정
            }
            base.Add(item);
            // 이벤트 호출
            // UI 스레드에서 이벤트 호출
            if (ListChanged != null)
            {
                if (System.Windows.Forms.Application.OpenForms[0].InvokeRequired)
                {
                    System.Windows.Forms.Application.OpenForms[0].Invoke(new MethodInvoker(() => ListChanged?.Invoke()));
                }
                else
                {
                    ListChanged?.Invoke();
                }
            }
            Console.WriteLine("새로운 값 추가: " + item);
            Console.WriteLine("현재 리스트 상태:");
            foreach (var listItem in this)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(listItem.ToString());
                
            }
        }
    }
}
