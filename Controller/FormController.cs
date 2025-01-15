using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using VP_QM_winform.Helper;
using VP_QM_winform.DTO;

namespace VP_QM_winform.Controller
{
    public class FormController
    {
        private PictureBox pictureBox;
        private Dictionary<string, Image> imageStates;
        private readonly DataGridView _dataGridView;
        private readonly BindingSource visionBindingSource;

        //생성시 이미지 초기화
        public FormController(PictureBox pictureBox, DataGridView dataGridView)
        {
            this.pictureBox = pictureBox;
            _dataGridView = dataGridView;
            visionBindingSource = new BindingSource();
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

        public void InitializeDataGridView()
        {
            // DataGridView와 BindingSource 연결
            visionBindingSource.DataSource = Global.s_VisionHistoryList;
            _dataGridView.DataSource = visionBindingSource;

            _dataGridView.AutoGenerateColumns = false;
            _dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // 컬럼 자동 생성
            _dataGridView.AutoGenerateColumns = true;

            // 기타 설정
            _dataGridView.AllowUserToAddRows = false; // 사용자 추가 행 비활성화
            _dataGridView.ReadOnly = true; // 읽기 전용

            // CellFormatting 이벤트 등록
            _dataGridView.CellFormatting += _dataGridView_CellFormatting;

        }
        // CellFormatting 이벤트 처리기
        private void _dataGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            // Label 컬럼의 인덱스를 가져옵니다 (여기서는 2번째 컬럼이라고 가정)
            int labelColumnIndex = 2;

            if (e.ColumnIndex == labelColumnIndex && e.Value is NgType label)
            {
                if (label == NgType.NotClassified)
                {
                    e.Value = "Good"; // "NotClassified"를 "Good"으로 대체
                    e.FormattingApplied = true; // 형식 적용 완료
                }
            }
        }

        public void RefreshDataGridView()
        {
            // DataGridView 갱신
            if (_dataGridView.InvokeRequired)
            {
                _dataGridView.Invoke(new MethodInvoker(() => RefreshDataGridView()));
            }
            else
            {
                visionBindingSource.ResetBindings(false);
            }
        }



    }
}
