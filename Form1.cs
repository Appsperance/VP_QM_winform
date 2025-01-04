﻿using System;
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

namespace VP_QM_winform
{
    public partial class Form1 : Form
    {
        ProcessService process = new ProcessService();
        
        public Form1()
        {
            InitializeComponent();
            //멀티쓰레드 상태관리 
            ProcessState.Initialize();
        }

        private async void button1_Click(object sender, EventArgs e)
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

        private void button2_Click(object sender, EventArgs e)
        {
            process.StopAsync();
        }

        private async void button3_Click(object sender, EventArgs e)
        {
            /*string brokerAddress = "43.203.159.137";
            string username = "admin";
            string password = "vapor";
            await mqttManager.ConnectAsync(brokerAddress,1883 ,username, password);*/
        }
    }
}
