using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VP_QM_winform.Controller;
using VP_QM_winform.DTO;
using VP_QM_winform.Helper;
using VP_QM_winform.Service;

namespace VP_QM_winform
{
    public partial class Login : Form
    {
        public delegate void LoginSuccessHandler(string userName); // 이벤트 핸들러 델리게이트
        public event LoginSuccessHandler LoginSuccess; // 로그인 성공 시 발생할 이벤트
        private LoginService loginService;
        public Login()
        {
            InitializeComponent();
        }

        private void text_Leave(object sender, EventArgs e)
        {
            VKeyController.HideKeyboard();
        }

        private void text_Enter(object sender, EventArgs e)
        {
            VKeyController.ShowKeyboard(this);
        }

        private void LoginForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            VKeyController.HideKeyboard(); // 키보드 종료
        }

        private async void btn_login_Click(object sender, EventArgs e)
        {
            loginService = new LoginService();
            LoginReqDTO loginReqDTO = new LoginReqDTO() 
            {
                loginId = tb_id.Text,
                loginPw = tb_pwd.Text
            };

            try
            {
                await loginService.Login(loginReqDTO);
                if (Global.s_LoginDTO != null)
                {
                    StateDTO.IsLogined = true;
                    // 로그인 성공 이벤트 호출
                    LoginSuccess?.Invoke(Global.s_LoginDTO.Name); // 사용자 이름 전달
                    this.Close(); // 로그인 창 닫기
                }

            }
            catch (Exception ex) 
            {
                MessageBox.Show($"로그인 실패 : {ex}");
            }

        }
    }
}
