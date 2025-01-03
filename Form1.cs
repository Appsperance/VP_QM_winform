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

namespace VP_QM_winform
{
    public partial class Form1 : Form
    {
        ProcessService process = new ProcessService();
        MQTTManager mqttManager = new MQTTManager();
        public Form1()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            await process.RunAsync();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            process.StopAsync();
        }

        private async void button3_Click(object sender, EventArgs e)
        {
            string brokerAddress = "43.203.159.137";
            string username = "admin";
            string password = "vapor";
            await mqttManager.ConnectAsync(brokerAddress,1883 ,username, password);
        }
    }
}
