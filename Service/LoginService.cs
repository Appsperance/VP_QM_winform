using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using VP_QM_winform.ComManager;
using VP_QM_winform.DTO;
using VP_QM_winform.Helper;
using System.Text.Json;
using System.Text;

namespace VP_QM_winform.Service
{
    public class LoginService
    {
        private LoginResDTO _loginResDTO;
        // 현재 로그인된 사용자 정보를 보관할 static 필드
        public async Task Login(LoginReqDTO loginReqDTO)
        {
            //로컬 서버 주소
            //string apiUri = "https://localhost:7144/api/login";
            //개발 서버 주소
            string apiUri = "http://13.125.114.64:5282/api/login";
            _loginResDTO = new LoginResDTO();

            try
            {
                HttpResponseMessage responseMessage = await HttpManager.PostAsync(apiUri, loginReqDTO);
                if (!responseMessage.IsSuccessStatusCode)
                {
                    throw new Exception("로그인 요청이 실패했습니다.");
                }

                string responseContent = await responseMessage.Content.ReadAsStringAsync();
                LoginResDTO _loginResDTO = JsonConvert.DeserializeObject<LoginResDTO>(responseContent);

                string jwtToken = _loginResDTO.JwtToken; // 응답에서 JWT 토큰 가져오기
                string result = GetRoleFromJwt(jwtToken);
                Console.WriteLine(result);

                Global.s_LoginDTO = new LoginInfoDTO()
                {
                    LoginId = _loginResDTO.LoginId,
                    EmployeeNumber = _loginResDTO.EmployeeNumber,
                    Name = _loginResDTO.Name,
                    Shift = _loginResDTO.Shift,
                    Photo = _loginResDTO.Photo,
                    Role = result,
                    JwtToken = jwtToken
                };
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[Error] {ex.Message}");
                throw;
            }
        }

        static string GetRoleFromJwt(string jwt)
        {
            try
            {
                // JWT의 두 번째 부분 (Payload)을 '.'로 나눈 뒤 추출
                string payloadEncoded = jwt.Split('.')[1];

                // Base64Url 디코딩 (패딩 문제 처리 포함)
                string paddedPayload = payloadEncoded.PadRight(payloadEncoded.Length + (4 - payloadEncoded.Length % 4) % 4, '=');
                byte[] payloadBytes = Convert.FromBase64String(paddedPayload);
                string payloadJson = Encoding.UTF8.GetString(payloadBytes);

                // JSON 파싱
                var payload = JsonDocument.Parse(payloadJson);

                // "role" 키의 값 추출
                string roleKey = "http://schemas.microsoft.com/ws/2008/06/identity/claims/role";
                if (payload.RootElement.TryGetProperty(roleKey, out var roleElement))
                {
                    return roleElement.GetString();
                }
                else
                {
                    throw new Exception("Role not found in JWT payload.");
                }
            }
            catch (Exception ex)
            {
                return $"Error: {ex.Message}";
            }
        }
    }
}
