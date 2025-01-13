using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using VP_QM_winform.Service;
using VP_QM_winform.Controller;
using VP_QM_winform.Helper;
using VP_QM_winform.VO;

namespace VP_QM_winform
{
    public partial class Form1 : Form
    {
        private ProcessService process;
        private SettingJobService settingJobService;
        private FormController formController;
        private ChartController processChartController;
        private ChartController ngChartController;
        public Form1()
        {
            InitializeComponent();
            process  = new ProcessService();
            settingJobService = new SettingJobService();
            
            formController = new FormController(picture_state,dg_inj);
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

            // Form 로드 시 현재 시간 표시
            UpdateCurrentTime();

            // Timer 설정: 매초마다 업데이트
            Timer timer = new Timer();
            timer.Interval = 1000; // 1초(1000ms)
            timer.Tick += (sender, e) => UpdateCurrentTime();
            timer.Start();
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

        private void UpdateCurrentTime()
        {
            // 현재 시간을 "년-월-일 시:분:초" 형식으로 포맷
            string currentTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

            // Label에 시간 표시
            lb_currentTime.Text = currentTime;
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
            string txt = btn_start.Text;
            if(txt == "시작")
            {
                try
                {
                    btn_start.Text = "중지";
                    btn_start.BackColor = System.Drawing.Color.Red;
                    btn_start.FlatAppearance.BorderColor = System.Drawing.Color.Magenta;
                    // 백그라운드 작업 시작
                    await Task.Run(() => process.RunAsync());
                }
                catch (Exception ex)
                {
                    // 예외 처리 (필요에 따라 메시지 박스 또는 로그 추가)
                    MessageBox.Show($"오류 발생: {ex.Message}");
                }
                
            }else if(txt == "중지")
            {
                //중지 메소드
                process.Stop();

                btn_start.Text = "시작";
                btn_start.BackColor = System.Drawing.Color.ForestGreen;
                btn_start.FlatAppearance.BorderColor = System.Drawing.Color.Lime;
            }
        }

        private void btn_popup_login_Click(object sender, EventArgs e)
        {
            string txt = btn_popup_login.Text;
            if (txt == "로그인")
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
            else
            {
                DialogResult result = MessageBox.Show(
                    "정말 로그아웃 하시겠습니까?",
                    "확인",
                    MessageBoxButtons.YesNo,
                     MessageBoxIcon.Question
                    );
                if(result == DialogResult.Yes)
                {
                    //로그아웃
                    Logout();
                }
                
            }
        }

        // LoginSuccess 이벤트 발생 시 호출될 메서드
        private void UpdateUserName(string userName)
        {
            // lb_userName에 로그인된 사용자 이름 설정
            Console.WriteLine($"updateUserName 호출: { userName}");
            btn_popup_login.Text = $"{userName}";
        }

        private async void btn_getLot_Click(object sender, EventArgs e)
        {
            // 비동기 작업의 결과를 기다림
            var result = await settingJobService.GetLotList();

            cb_lot.Items.Clear();
            cb_lot.Items.Add("작업을 선택하세요.");

            // 결과를 foreach로 순회
            foreach (var lot in result)
            {
                cb_lot.Items.Add(lot);
            }

            cb_lot.SelectedIndex = 0;
        }

        private void btn_choiceLot_Click(object sender, EventArgs e)
        {
            var lot = cb_lot.Text;
            Global.s_CurrentLot = lot;
            Console.WriteLine($"현재 Lot: { Global.s_CurrentLot}");
        }

        private void Logout()
        {
            if (ProcessState.GetState("CurrentStage") == "Idle")
            {
                Global.s_LoginDTO = null;
                btn_popup_login.Text = "로그인";
            }
            else
            {
                MessageBox.Show("장비가 정지된 후 로그아웃 해주세요.");
            }
        }
    }
}
