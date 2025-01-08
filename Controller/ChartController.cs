using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VP_QM_winform.Controller
{
    public class ChartController
    {
        private Panel chartPanel; // 도넛 그래프를 그릴 Panel
        private int totalInspections;  // 총 검사 수량
        private int currentInspections; // 현재 검사 수량
        private int defectiveCount;    // 불량 수량
        private string currentMode = "Progress"; // 표시 모드 ("Progress" 또는 "Defect")

        public ChartController(Panel panel)
        {
            chartPanel = panel ?? throw new ArgumentNullException(nameof(panel));
            chartPanel.Paint += new PaintEventHandler(DrawDonutChart);
        }

        // 데이터를 업데이트하고 차트를 다시 그리기
        public void UpdateChart(int total, int current, int defective, string mode = "Progress")
        {
            if (total <= 0) throw new ArgumentException("Total inspections must be greater than 0.");
            if (current < 0 || defective < 0) throw new ArgumentException("Current or defective values cannot be negative.");
            if (current > total) throw new ArgumentException("Current inspections cannot exceed total inspections.");
            if (defective > current) throw new ArgumentException("Defective count cannot exceed current inspections.");

            totalInspections = total;
            currentInspections = current;
            defectiveCount = defective;
            currentMode = mode; // 표시 모드 설정

            chartPanel.Invalidate(); // Panel 다시 그리기
        }

        // 도넛 그래프 그리기
        private void DrawDonutChart(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            // Panel 크기와 위치 설정
            int margin = 10; // 패널 경계로부터의 여백
            int thickness = 12; // 도넛의 두께
            Rectangle outerCircle = new Rectangle(margin, margin, chartPanel.Width - 2 * margin, chartPanel.Height - 2 * margin);
            Rectangle innerCircle = new Rectangle(margin + thickness, margin + thickness, chartPanel.Width - 2 * (margin + thickness), chartPanel.Height - 2 * (margin + thickness));

            // 데이터 계산
            float percentage = 0;
            Color fillColor = Color.LightGray;
            if (currentMode == "Progress") // 진행률
            {
                percentage = (float)currentInspections / totalInspections * 100;
                fillColor = Color.Lime;
            }
            else if (currentMode == "Defect") // 불량률
            {
                percentage = currentInspections > 0 ? (float)defectiveCount / currentInspections * 100 : 0;
                fillColor = Color.FromArgb(252, 7, 117);
            }
            float sweepAngle = percentage / 100 * 360;

            // 도넛 그래프 채우기
            using (Brush brush = new SolidBrush(fillColor))
            {
                g.FillPie(brush, outerCircle, -90, sweepAngle); // 퍼센티지 부분
            }

            using (Brush brush = new SolidBrush(Color.LightGray))
            {
                g.FillPie(brush, outerCircle, -90 + sweepAngle, 360 - sweepAngle); // 나머지
            }

            // 도넛 중앙 구멍 채우기
            using (Brush brush = new SolidBrush(chartPanel.BackColor))
            {
                g.FillEllipse(brush, innerCircle);
            }

            // 도넛 테두리 그리기
            using (Pen pen = new Pen(Color.FromArgb(153,153,153), 1)) // 테두리 두께 2px
            {
                g.DrawEllipse(pen, outerCircle); // 바깥쪽 테두리
                g.DrawEllipse(pen, innerCircle); // 안쪽 테두리
            }

            // 중앙에 퍼센티지 표시
            string percentageText = $"{percentage:F1}%";
            using (Font font = new Font("Arial", 14, FontStyle.Bold))
            using (Brush textBrush = new SolidBrush(Color.White))
            {
                SizeF textSize = g.MeasureString(percentageText, font);
                float textX = chartPanel.Width / 2 - textSize.Width / 2;
                float textY = chartPanel.Height / 2 - textSize.Height / 2;
                g.DrawString(percentageText, font, textBrush, textX, textY);
            }
        }
    }
    }
