using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using VP_QM_winform.ComManager;
using VP_QM_winform.DAO;
using VP_QM_winform.VO;

namespace VP_QM_winform.Service
{
    public class SettingJobService
    {
        public async Task <List<string>> GetLotList()
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
                    List<LotVO> lotList = JsonConvert.DeserializeObject<List<LotVO>>(responseContent);
                    List<string> idList = lotList.Select(lot => lot.Id).ToList();
                    return idList;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return null;
        }   
    }
}
