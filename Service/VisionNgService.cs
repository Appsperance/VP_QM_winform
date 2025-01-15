using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using VP_QM_winform.ComManager;
using VP_QM_winform.DTO;
using VP_QM_winform.Helper;
using VP_QM_winform.VO;

namespace VP_QM_winform.Service
{
    public class VisionNgService
    {
        public async Task InsertVisionNg(VisionNgReqDTO visionNgReqDTO)
        {
            string apiUri = "http://13.125.114.64:5282/api/Vision/ng";
            try
            {
                HttpResponseMessage responseMessage = await HttpManager.PostAsync(apiUri, visionNgReqDTO);
                if (responseMessage.IsSuccessStatusCode)
                {
                    Console.WriteLine($"저장 성공 {responseMessage.Content}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
