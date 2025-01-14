using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using VP_QM_winform.ComManager;
using VP_QM_winform.DAO;
using VP_QM_winform.Helper;
using VP_QM_winform.VO;

namespace VP_QM_winform.Service
{
    public class SettingJobService
    {
        public async void GetLotList()
        {
            //로컬 서버 주소
            //string apiUri = "https://localhost:7144/api/lots/completed";
            //개발 서버 주소
            string apiUri = "http://13.125.114.64:5282/api/lots/completed";

            try
            {
                HttpResponseMessage responseMessage = await HttpManager.GetAsync(apiUri);
                if (responseMessage.IsSuccessStatusCode)
                {
                    string responseContent = await responseMessage.Content.ReadAsStringAsync();
                    var lotList = JsonConvert.DeserializeObject<List<LotVO>>(responseContent);
                    // Id와 Qty만 추출하여 KeyValuePair 리스트에 할당
                    Global.s_LotQtyList = lotList
                        .Select(lot => new KeyValuePair<string, int>(lot.Id, lot.Qty))
                        .ToList();
                    // 결과 출력 (디버깅용)
                    foreach (var item in Global.s_LotQtyList)
                    {
                        Console.WriteLine($"LotId: {item.Key}, Qty: {item.Value}");
                    }

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }   
    }
}
