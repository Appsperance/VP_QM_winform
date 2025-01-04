namespace VP_QM_winform
{
    partial class Form1
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.CorpName = new System.Windows.Forms.Label();
            this.CurrentTime = new System.Windows.Forms.Label();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.lb_workerId = new System.Windows.Forms.Label();
            this.lb_end = new System.Windows.Forms.Label();
            this.lb_start = new System.Windows.Forms.Label();
            this.lb_lotId = new System.Windows.Forms.Label();
            this.lb_productId = new System.Windows.Forms.Label();
            this.lb_machineId = new System.Windows.Forms.Label();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.btn_emp = new System.Windows.Forms.Button();
            this.btn_lot = new System.Windows.Forms.Button();
            this.btn_start = new System.Windows.Forms.Button();
            this.btn_stop = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.tableLayoutPanel5.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel3, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel4, 0, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 18F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1047, 614);
            this.tableLayoutPanel1.TabIndex = 3;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.CorpName, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.CurrentTime, 1, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 48F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1041, 67);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // CorpName
            // 
            this.CorpName.AutoSize = true;
            this.CorpName.Dock = System.Windows.Forms.DockStyle.Left;
            this.CorpName.Font = new System.Drawing.Font("굴림", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.CorpName.Location = new System.Drawing.Point(3, 0);
            this.CorpName.Name = "CorpName";
            this.CorpName.Size = new System.Drawing.Size(249, 67);
            this.CorpName.TabIndex = 0;
            this.CorpName.Text = "HYUNDAI_INJ";
            this.CorpName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // CurrentTime
            // 
            this.CurrentTime.AutoSize = true;
            this.CurrentTime.Dock = System.Windows.Forms.DockStyle.Right;
            this.CurrentTime.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.CurrentTime.Location = new System.Drawing.Point(973, 0);
            this.CurrentTime.Margin = new System.Windows.Forms.Padding(3, 0, 20, 0);
            this.CurrentTime.Name = "CurrentTime";
            this.CurrentTime.Size = new System.Drawing.Size(48, 67);
            this.CurrentTime.TabIndex = 1;
            this.CurrentTime.Text = "label1";
            this.CurrentTime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.BackColor = System.Drawing.SystemColors.Control;
            this.tableLayoutPanel3.ColumnCount = 6;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPanel3.Controls.Add(this.lb_workerId, 5, 0);
            this.tableLayoutPanel3.Controls.Add(this.lb_end, 4, 0);
            this.tableLayoutPanel3.Controls.Add(this.lb_start, 3, 0);
            this.tableLayoutPanel3.Controls.Add(this.lb_lotId, 2, 0);
            this.tableLayoutPanel3.Controls.Add(this.lb_productId, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.lb_machineId, 0, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 76);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 2;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(1041, 104);
            this.tableLayoutPanel3.TabIndex = 1;
            // 
            // lb_workerId
            // 
            this.lb_workerId.AutoSize = true;
            this.lb_workerId.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lb_workerId.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lb_workerId.Location = new System.Drawing.Point(887, 0);
            this.lb_workerId.Name = "lb_workerId";
            this.lb_workerId.Size = new System.Drawing.Size(151, 52);
            this.lb_workerId.TabIndex = 6;
            this.lb_workerId.Text = "작업자명";
            this.lb_workerId.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lb_end
            // 
            this.lb_end.AutoSize = true;
            this.lb_end.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lb_end.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lb_end.Location = new System.Drawing.Point(679, 0);
            this.lb_end.Name = "lb_end";
            this.lb_end.Size = new System.Drawing.Size(202, 52);
            this.lb_end.TabIndex = 5;
            this.lb_end.Text = "종료시간";
            this.lb_end.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lb_start
            // 
            this.lb_start.AutoSize = true;
            this.lb_start.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lb_start.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lb_start.Location = new System.Drawing.Point(471, 0);
            this.lb_start.Name = "lb_start";
            this.lb_start.Size = new System.Drawing.Size(202, 52);
            this.lb_start.TabIndex = 4;
            this.lb_start.Text = "시작시간";
            this.lb_start.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lb_lotId
            // 
            this.lb_lotId.AutoSize = true;
            this.lb_lotId.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lb_lotId.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lb_lotId.Location = new System.Drawing.Point(315, 0);
            this.lb_lotId.Name = "lb_lotId";
            this.lb_lotId.Size = new System.Drawing.Size(150, 52);
            this.lb_lotId.TabIndex = 3;
            this.lb_lotId.Text = "로트명";
            this.lb_lotId.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lb_productId
            // 
            this.lb_productId.AutoSize = true;
            this.lb_productId.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lb_productId.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lb_productId.Location = new System.Drawing.Point(159, 0);
            this.lb_productId.Name = "lb_productId";
            this.lb_productId.Size = new System.Drawing.Size(150, 52);
            this.lb_productId.TabIndex = 2;
            this.lb_productId.Text = "제품명";
            this.lb_productId.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lb_machineId
            // 
            this.lb_machineId.AutoSize = true;
            this.lb_machineId.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lb_machineId.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lb_machineId.Location = new System.Drawing.Point(3, 0);
            this.lb_machineId.Name = "lb_machineId";
            this.lb_machineId.Size = new System.Drawing.Size(150, 52);
            this.lb_machineId.TabIndex = 1;
            this.lb_machineId.Text = "설비명";
            this.lb_machineId.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 3;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 65F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel4.Controls.Add(this.tableLayoutPanel5, 0, 0);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(3, 186);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 1;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(1041, 425);
            this.tableLayoutPanel4.TabIndex = 2;
            this.tableLayoutPanel4.Paint += new System.Windows.Forms.PaintEventHandler(this.tableLayoutPanel4_Paint);
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.ColumnCount = 1;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel5.Controls.Add(this.btn_stop, 0, 4);
            this.tableLayoutPanel5.Controls.Add(this.btn_start, 0, 3);
            this.tableLayoutPanel5.Controls.Add(this.btn_lot, 0, 1);
            this.tableLayoutPanel5.Controls.Add(this.btn_emp, 0, 0);
            this.tableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel5.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 5;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel5.Size = new System.Drawing.Size(150, 419);
            this.tableLayoutPanel5.TabIndex = 0;
            // 
            // btn_emp
            // 
            this.btn_emp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_emp.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btn_emp.Location = new System.Drawing.Point(3, 3);
            this.btn_emp.Name = "btn_emp";
            this.btn_emp.Size = new System.Drawing.Size(144, 56);
            this.btn_emp.TabIndex = 0;
            this.btn_emp.Text = "작업자 선택";
            this.btn_emp.UseVisualStyleBackColor = true;
            // 
            // btn_lot
            // 
            this.btn_lot.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_lot.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btn_lot.Location = new System.Drawing.Point(3, 65);
            this.btn_lot.Name = "btn_lot";
            this.btn_lot.Size = new System.Drawing.Size(144, 56);
            this.btn_lot.TabIndex = 1;
            this.btn_lot.Text = "작업조회";
            this.btn_lot.UseVisualStyleBackColor = true;
            // 
            // btn_start
            // 
            this.btn_start.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_start.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btn_start.Location = new System.Drawing.Point(3, 168);
            this.btn_start.Margin = new System.Windows.Forms.Padding(3, 3, 3, 30);
            this.btn_start.Name = "btn_start";
            this.btn_start.Size = new System.Drawing.Size(144, 92);
            this.btn_start.TabIndex = 3;
            this.btn_start.Text = "시작";
            this.btn_start.UseVisualStyleBackColor = true;
            // 
            // btn_stop
            // 
            this.btn_stop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_stop.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btn_stop.Location = new System.Drawing.Point(3, 293);
            this.btn_stop.Margin = new System.Windows.Forms.Padding(3, 3, 3, 30);
            this.btn_stop.Name = "btn_stop";
            this.btn_stop.Size = new System.Drawing.Size(144, 96);
            this.btn_stop.TabIndex = 4;
            this.btn_stop.Text = "중지";
            this.btn_stop.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1047, 614);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel5.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Label CorpName;
        private System.Windows.Forms.Label CurrentTime;
        private System.Windows.Forms.Label lb_workerId;
        private System.Windows.Forms.Label lb_end;
        private System.Windows.Forms.Label lb_start;
        private System.Windows.Forms.Label lb_lotId;
        private System.Windows.Forms.Label lb_productId;
        private System.Windows.Forms.Label lb_machineId;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
        private System.Windows.Forms.Button btn_stop;
        private System.Windows.Forms.Button btn_start;
        private System.Windows.Forms.Button btn_lot;
        private System.Windows.Forms.Button btn_emp;
    }
}

