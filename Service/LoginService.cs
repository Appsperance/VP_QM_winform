using Newtonsoft.Json;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Cryptography;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Tokens;

using VP_QM_winform.ComManager;
using VP_QM_winform.DTO;
using VP_QM_winform.Helper;


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
                if (responseMessage.IsSuccessStatusCode)
                {
                    string responseContent = await responseMessage.Content.ReadAsStringAsync();
                    _loginResDTO = JsonConvert.DeserializeObject<LoginResDTO>(responseContent);

                    /****************************
                     * JWT 토큰 유효성 검사 로직*
                     ***************************/
/*                    if (_loginResDTO != null && !string.IsNullOrEmpty(_loginResDTO.JwtToken))
                    {
                        string publicKey = _loginResDTO.JwtPublicKey; // 응답에서 공개 키 가져오기
                        string jwtToken = _loginResDTO.JwtToken; // 응답에서 JWT 토큰 가져오기

                        bool isTokenValid = ValidateToken(jwtToken, publicKey);
                        if (isTokenValid) 
                        {
                            //스태틱 로그인 변수에 추가
                            Global.s_LoginDTO = new LoginInfoDTO()
                            {
                                LoginId = _loginResDTO.LoginId,
                                EmployeeNumber = _loginResDTO.EmployeeNumber,
                                Name = _loginResDTO.Name,
                                Shift = _loginResDTO.Shift,
                                Photo = _loginResDTO.Photo
                            };
                        }
                        else
                        {
                            throw new Exception("JWT 토큰이 유효하지 않습니다.");
                        }
                    }
                    else
                    {
                        throw new Exception("JWT 토큰 또는 공개 키가 없습니다.");
                    }

   */                 
                }
            }
            catch (Exception e) 
            {
                Console.WriteLine($"로그인 실패: {e}");
            }

        }
/*
        //토큰 검증 메서드
        public bool ValidateToken(string jwtToken, string publicKey)
        {
            try
            {
                // 공개 키를 RSA 객체로 변환
                var rsa = TokenHepler.CreateRsaFromPublicKey(publicKey);

                // RSA 키를 기반으로 한 RsaSecurityKey 생성
                var securityKey = new RsaSecurityKey(rsa);

                // 토큰 검증 매개변수 설정
                var validationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidateLifetime = true,
                    IssuerSigningKey = securityKey
                };

                // JWT 토큰 핸들러
                var tokenHandler = new JwtSecurityTokenHandler();
                tokenHandler.ValidateToken(jwtToken, validationParameters, out _);

                Console.WriteLine("Token is valid.");
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Token validation failed: {ex.Message}");
                return false;
            }
        }
*/
    }
}
