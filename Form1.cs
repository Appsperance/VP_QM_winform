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
        public Form1()
        {
            InitializeComponent();
            
            //멀티쓰레드 상태관리 
            ProcessState.Initialize();
            formController = new FormController(picture_state);
            formController.UpdatePictureBoxImage(ProcessState.GetState("CurrentStage").ToString());
            // 상태 변경 이벤트 등록
            ProcessState.StateChanged += OnStateChanged;
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
    }
}
