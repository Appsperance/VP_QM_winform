using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace VP_QM_winform.Controller
{
    public class FormController
    {
        private PictureBox pictureBox;
        private Dictionary<string, Image> imageStates;

        //생성시 이미지 초기화
        public FormController(PictureBox pictureBox)
        {
            this.pictureBox = pictureBox;
            InitializePictureBox();
            InitializeImages();
        }
        // PictureBox 초기 설정
        private void InitializePictureBox()
        {
            // PictureBox 크기에 맞게 이미지 표시 (비율 유지)
            pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        private void InitializeImages()
        {
            // Application.StartupPath는 실행 파일의 경로를 반환합니다.
            string imagePath = System.IO.Path.Combine(Application.StartupPath, "Imgs");
            imageStates = new Dictionary<string, Image>
            {
                { "Idle", Image.FromFile(System.IO.Path.Combine(imagePath, "vp_idle-removebg-preview.png")) },
                { "sensor1", Image.FromFile(System.IO.Path.Combine(imagePath, "vp_sensor1-removebg-preview.png")) },
                { "sensor2", Image.FromFile(System.IO.Path.Combine(imagePath, "vp_sensor2-removebg-preview.png")) },
                { "sensor3", Image.FromFile(System.IO.Path.Combine(imagePath, "vp_sensor3-removebg-preview.png")) },
                { "waiting", Image.FromFile(System.IO.Path.Combine(imagePath, "vp_stop-removebg-preview.png")) }
            };
        }

        // 상태에 따라 PictureBox 이미지 업데이트
        public void UpdatePictureBoxImage(string state)
        {
            if (imageStates.ContainsKey(state))
            {
                Console.WriteLine($"Updating PictureBox image for state: {state}");
                pictureBox.Image = imageStates[state];
                pictureBox.Refresh();
            }
            else
            {
                throw new ArgumentException($"이미지 상태 '{state}'가 존재하지 않습니다.");
            }
        }

    }
}
