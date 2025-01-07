using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VP_QM_winform.Service;
using VP_QM_winform.ComManager;
using System.Drawing.Drawing2D;
using VP_QM_winform.Controller;

namespace VP_QM_winform
{
    public partial class Form1 : Form
    {
        ProcessService process = new ProcessService();
        private FormController formController;
        private ChartController processChartController;
        private ChartController ngChartController;
        public Form1()
        {
            InitializeComponent();
            
            //멀티쓰레드 상태관리 
            ProcessState.Initialize();
            formController = new FormController(picture_state);
            formController.UpdatePictureBoxImage(ProcessState.GetState("CurrentStage").ToString());
            // 상태 변경 이벤트 등록
            ProcessState.StateChanged += OnStateChanged;

            //차트 생성
            processChartController = new ChartController(process_panel);
            ngChartController = new ChartController(ng_panel);

            // 임시 데이터 설정
            int totalInspections = 100;   // 총 검사 수량
            int currentInspections = 50;  // 현재 검사 수량
            int defectiveCount = 10;      // 불량 수량

            // 프로세스 차트 데이터 설정
            processChartController.UpdateChart(totalInspections, currentInspections, defectiveCount, "Progress"); // 불량 데이터는 0으로 설정

            // 불량률 차트 데이터 설정
            ngChartController.UpdateChart(totalInspections, currentInspections, defectiveCount, "Defect");
        }

        // 상태 변경 이벤트 핸들러
        private void OnStateChanged(string key, object value)
        {
            if (key == "CurrentStage") // 특정 키만 처리
            {
                string newStage = value.ToString();
                Console.WriteLine($"CurrentStage 변경: {newStage}");
                // UI 스레드에서 작업 수행
                if (InvokeRequired)
                {
                    Invoke(new Action(() => formController.UpdatePictureBoxImage(newStage)));
                }
                else
                {
                    formController.UpdatePictureBoxImage(newStage);
                }
            }
        }

        private void tableLayoutPanel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private async void btn_start_Click(object sender, EventArgs e)
        {
            try
            {
                // 백그라운드 작업 시작
                await Task.Run(() => process.RunAsync());
            }
            catch (Exception ex)
            {
                // 예외 처리 (필요에 따라 메시지 박스 또는 로그 추가)
                MessageBox.Show($"오류 발생: {ex.Message}");
            }
        }

        private void btn_popup_login_Click(object sender, EventArgs e)
        {
            // Login 폼 인스턴스 생성
            Login loginForm = new Login();
            // LoginSuccess 이벤트 구독
            loginForm.LoginSuccess += UpdateUserName;

            // 부모 폼(Form1)의 중심 좌표 계산
            int centerX = this.Location.X + (this.Width - loginForm.Width) / 2;
            int centerY = this.Location.Y + (this.Height - loginForm.Height) / 2;

            // Login 폼 위치 설정
            loginForm.StartPosition = FormStartPosition.Manual;
            loginForm.Location = new System.Drawing.Point(centerX, centerY);

            // Login 폼 열기
            loginForm.ShowDialog();
        }

        // LoginSuccess 이벤트 발생 시 호출될 메서드
        private void UpdateUserName(string userName)
        {
            // lb_userName에 로그인된 사용자 이름 설정
            Console.WriteLine($"updateUserName 호출: { userName}");
            lb_userName.Text = $"{userName}";
        }

        private void lb_userName_Click(object sender, EventArgs e)
        {

        }
    }
}
