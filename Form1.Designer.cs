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
            this.tableLayoutPanel10 = new System.Windows.Forms.TableLayoutPanel();
            this.btn_popup_login = new System.Windows.Forms.Button();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.lb_endTime = new System.Windows.Forms.Label();
            this.lb_startTime = new System.Windows.Forms.Label();
            this.lb_lot = new System.Windows.Forms.Label();
            this.lb_partId = new System.Windows.Forms.Label();
            this.lb_workerId = new System.Windows.Forms.Label();
            this.lb_end = new System.Windows.Forms.Label();
            this.lb_start = new System.Windows.Forms.Label();
            this.lb_lotId = new System.Windows.Forms.Label();
            this.lb_productId = new System.Windows.Forms.Label();
            this.lb_machineId = new System.Windows.Forms.Label();
            this.lb_currentTime = new System.Windows.Forms.Label();
            this.lb_lineId = new System.Windows.Forms.Label();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.btn_start = new System.Windows.Forms.Button();
            this.cb_lot = new System.Windows.Forms.ComboBox();
            this.btn_choiceLot = new System.Windows.Forms.Button();
            this.btn_getLot = new System.Windows.Forms.Button();
            this.btn_finish = new System.Windows.Forms.Button();
            this.tableLayoutPanel6 = new System.Windows.Forms.TableLayoutPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.ng_panel = new System.Windows.Forms.Panel();
            this.process_panel = new System.Windows.Forms.Panel();
            this.tableLayoutPanel7 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel8 = new System.Windows.Forms.TableLayoutPanel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.picture_state = new System.Windows.Forms.PictureBox();
            this.dg_history = new System.Windows.Forms.DataGridView();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel10.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.tableLayoutPanel5.SuspendLayout();
            this.tableLayoutPanel6.SuspendLayout();
            this.tableLayoutPanel7.SuspendLayout();
            this.tableLayoutPanel8.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picture_state)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dg_history)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.DimGray;
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
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 73F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(997, 599);
            this.tableLayoutPanel1.TabIndex = 3;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(44)))), ((int)(((byte)(90)))));
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.CorpName, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel10, 1, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 71F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(997, 71);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // CorpName
            // 
            this.CorpName.AutoSize = true;
            this.CorpName.Dock = System.Windows.Forms.DockStyle.Left;
            this.CorpName.Font = new System.Drawing.Font("나눔고딕", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.CorpName.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.CorpName.Location = new System.Drawing.Point(3, 0);
            this.CorpName.Name = "CorpName";
            this.CorpName.Size = new System.Drawing.Size(219, 71);
            this.CorpName.TabIndex = 0;
            this.CorpName.Text = "HYUNDAIINJ";
            this.CorpName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel10
            // 
            this.tableLayoutPanel10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(44)))), ((int)(((byte)(90)))));
            this.tableLayoutPanel10.ColumnCount = 1;
            this.tableLayoutPanel10.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel10.Controls.Add(this.btn_popup_login, 0, 0);
            this.tableLayoutPanel10.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel10.Location = new System.Drawing.Point(501, 3);
            this.tableLayoutPanel10.Name = "tableLayoutPanel10";
            this.tableLayoutPanel10.RowCount = 1;
            this.tableLayoutPanel10.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel10.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 65F));
            this.tableLayoutPanel10.Size = new System.Drawing.Size(493, 65);
            this.tableLayoutPanel10.TabIndex = 1;
            // 
            // btn_popup_login
            // 
            this.btn_popup_login.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(44)))), ((int)(((byte)(90)))));
            this.btn_popup_login.Dock = System.Windows.Forms.DockStyle.Right;
            this.btn_popup_login.FlatAppearance.BorderSize = 0;
            this.btn_popup_login.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_popup_login.Font = new System.Drawing.Font("나눔고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btn_popup_login.ForeColor = System.Drawing.SystemColors.Control;
            this.btn_popup_login.Location = new System.Drawing.Point(349, 0);
            this.btn_popup_login.Margin = new System.Windows.Forms.Padding(0);
            this.btn_popup_login.Name = "btn_popup_login";
            this.btn_popup_login.Size = new System.Drawing.Size(144, 65);
            this.btn_popup_login.TabIndex = 0;
            this.btn_popup_login.Text = "로그인";
            this.btn_popup_login.UseVisualStyleBackColor = false;
            this.btn_popup_login.Click += new System.EventHandler(this.btn_popup_login_Click);
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(90)))), ((int)(((byte)(113)))));
            this.tableLayoutPanel3.ColumnCount = 6;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPanel3.Controls.Add(this.lb_endTime, 4, 1);
            this.tableLayoutPanel3.Controls.Add(this.lb_startTime, 3, 1);
            this.tableLayoutPanel3.Controls.Add(this.lb_lot, 2, 1);
            this.tableLayoutPanel3.Controls.Add(this.lb_partId, 1, 1);
            this.tableLayoutPanel3.Controls.Add(this.lb_workerId, 5, 0);
            this.tableLayoutPanel3.Controls.Add(this.lb_end, 4, 0);
            this.tableLayoutPanel3.Controls.Add(this.lb_start, 3, 0);
            this.tableLayoutPanel3.Controls.Add(this.lb_lotId, 2, 0);
            this.tableLayoutPanel3.Controls.Add(this.lb_productId, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.lb_machineId, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.lb_currentTime, 5, 1);
            this.tableLayoutPanel3.Controls.Add(this.lb_lineId, 0, 1);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(0, 71);
            this.tableLayoutPanel3.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 2;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(997, 89);
            this.tableLayoutPanel3.TabIndex = 1;
            // 
            // lb_endTime
            // 
            this.lb_endTime.AutoSize = true;
            this.lb_endTime.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(90)))), ((int)(((byte)(113)))));
            this.lb_endTime.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lb_endTime.ForeColor = System.Drawing.SystemColors.Control;
            this.lb_endTime.Location = new System.Drawing.Point(649, 44);
            this.lb_endTime.Name = "lb_endTime";
            this.lb_endTime.Size = new System.Drawing.Size(193, 45);
            this.lb_endTime.TabIndex = 12;
            this.lb_endTime.Text = "label8";
            this.lb_endTime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lb_startTime
            // 
            this.lb_startTime.AutoSize = true;
            this.lb_startTime.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(90)))), ((int)(((byte)(113)))));
            this.lb_startTime.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lb_startTime.ForeColor = System.Drawing.SystemColors.Control;
            this.lb_startTime.Location = new System.Drawing.Point(450, 44);
            this.lb_startTime.Name = "lb_startTime";
            this.lb_startTime.Size = new System.Drawing.Size(193, 45);
            this.lb_startTime.TabIndex = 11;
            this.lb_startTime.Text = "label7";
            this.lb_startTime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lb_lot
            // 
            this.lb_lot.AutoSize = true;
            this.lb_lot.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(90)))), ((int)(((byte)(113)))));
            this.lb_lot.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lb_lot.ForeColor = System.Drawing.SystemColors.Control;
            this.lb_lot.Location = new System.Drawing.Point(301, 44);
            this.lb_lot.Name = "lb_lot";
            this.lb_lot.Size = new System.Drawing.Size(143, 45);
            this.lb_lot.TabIndex = 10;
            this.lb_lot.Text = "label6";
            this.lb_lot.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lb_partId
            // 
            this.lb_partId.AutoSize = true;
            this.lb_partId.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(90)))), ((int)(((byte)(113)))));
            this.lb_partId.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lb_partId.ForeColor = System.Drawing.SystemColors.Control;
            this.lb_partId.Location = new System.Drawing.Point(152, 44);
            this.lb_partId.Name = "lb_partId";
            this.lb_partId.Size = new System.Drawing.Size(143, 45);
            this.lb_partId.TabIndex = 9;
            this.lb_partId.Text = "label5";
            this.lb_partId.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lb_workerId
            // 
            this.lb_workerId.AutoSize = true;
            this.lb_workerId.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(90)))), ((int)(((byte)(113)))));
            this.lb_workerId.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lb_workerId.Font = new System.Drawing.Font("나눔고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lb_workerId.ForeColor = System.Drawing.Color.White;
            this.lb_workerId.Location = new System.Drawing.Point(848, 0);
            this.lb_workerId.Name = "lb_workerId";
            this.lb_workerId.Size = new System.Drawing.Size(146, 44);
            this.lb_workerId.TabIndex = 6;
            this.lb_workerId.Text = "현재시간";
            this.lb_workerId.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lb_end
            // 
            this.lb_end.AutoSize = true;
            this.lb_end.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(90)))), ((int)(((byte)(113)))));
            this.lb_end.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lb_end.Font = new System.Drawing.Font("나눔고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lb_end.ForeColor = System.Drawing.Color.White;
            this.lb_end.Location = new System.Drawing.Point(649, 0);
            this.lb_end.Name = "lb_end";
            this.lb_end.Size = new System.Drawing.Size(193, 44);
            this.lb_end.TabIndex = 5;
            this.lb_end.Text = "종료시간";
            this.lb_end.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lb_start
            // 
            this.lb_start.AutoSize = true;
            this.lb_start.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(90)))), ((int)(((byte)(113)))));
            this.lb_start.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lb_start.Font = new System.Drawing.Font("나눔고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lb_start.ForeColor = System.Drawing.Color.White;
            this.lb_start.Location = new System.Drawing.Point(450, 0);
            this.lb_start.Name = "lb_start";
            this.lb_start.Size = new System.Drawing.Size(193, 44);
            this.lb_start.TabIndex = 4;
            this.lb_start.Text = "시작시간";
            this.lb_start.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lb_lotId
            // 
            this.lb_lotId.AutoSize = true;
            this.lb_lotId.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(90)))), ((int)(((byte)(113)))));
            this.lb_lotId.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lb_lotId.Font = new System.Drawing.Font("나눔고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lb_lotId.ForeColor = System.Drawing.Color.White;
            this.lb_lotId.Location = new System.Drawing.Point(301, 0);
            this.lb_lotId.Name = "lb_lotId";
            this.lb_lotId.Size = new System.Drawing.Size(143, 44);
            this.lb_lotId.TabIndex = 3;
            this.lb_lotId.Text = "로트명";
            this.lb_lotId.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lb_productId
            // 
            this.lb_productId.AutoSize = true;
            this.lb_productId.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(90)))), ((int)(((byte)(113)))));
            this.lb_productId.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lb_productId.Font = new System.Drawing.Font("나눔고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lb_productId.ForeColor = System.Drawing.Color.White;
            this.lb_productId.Location = new System.Drawing.Point(152, 0);
            this.lb_productId.Name = "lb_productId";
            this.lb_productId.Size = new System.Drawing.Size(143, 44);
            this.lb_productId.TabIndex = 2;
            this.lb_productId.Text = "제품명";
            this.lb_productId.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lb_machineId
            // 
            this.lb_machineId.AutoSize = true;
            this.lb_machineId.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(90)))), ((int)(((byte)(113)))));
            this.lb_machineId.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lb_machineId.Font = new System.Drawing.Font("나눔고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lb_machineId.ForeColor = System.Drawing.Color.White;
            this.lb_machineId.Location = new System.Drawing.Point(3, 0);
            this.lb_machineId.Name = "lb_machineId";
            this.lb_machineId.Size = new System.Drawing.Size(143, 44);
            this.lb_machineId.TabIndex = 1;
            this.lb_machineId.Text = "설비명";
            this.lb_machineId.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lb_currentTime
            // 
            this.lb_currentTime.AutoSize = true;
            this.lb_currentTime.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(90)))), ((int)(((byte)(113)))));
            this.lb_currentTime.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lb_currentTime.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lb_currentTime.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lb_currentTime.Location = new System.Drawing.Point(848, 44);
            this.lb_currentTime.Name = "lb_currentTime";
            this.lb_currentTime.Size = new System.Drawing.Size(146, 45);
            this.lb_currentTime.TabIndex = 7;
            this.lb_currentTime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lb_lineId
            // 
            this.lb_lineId.AutoSize = true;
            this.lb_lineId.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(90)))), ((int)(((byte)(113)))));
            this.lb_lineId.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lb_lineId.ForeColor = System.Drawing.SystemColors.Control;
            this.lb_lineId.Location = new System.Drawing.Point(3, 44);
            this.lb_lineId.Name = "lb_lineId";
            this.lb_lineId.Size = new System.Drawing.Size(143, 45);
            this.lb_lineId.TabIndex = 8;
            this.lb_lineId.Text = "label4";
            this.lb_lineId.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.BackColor = System.Drawing.Color.Black;
            this.tableLayoutPanel4.ColumnCount = 3;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel4.Controls.Add(this.tableLayoutPanel5, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.tableLayoutPanel6, 2, 0);
            this.tableLayoutPanel4.Controls.Add(this.tableLayoutPanel7, 1, 0);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(3, 163);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 1;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(991, 433);
            this.tableLayoutPanel4.TabIndex = 2;
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(90)))), ((int)(((byte)(113)))));
            this.tableLayoutPanel5.ColumnCount = 1;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel5.Controls.Add(this.btn_start, 0, 4);
            this.tableLayoutPanel5.Controls.Add(this.cb_lot, 0, 1);
            this.tableLayoutPanel5.Controls.Add(this.btn_choiceLot, 0, 2);
            this.tableLayoutPanel5.Controls.Add(this.btn_getLot, 0, 0);
            this.tableLayoutPanel5.Controls.Add(this.btn_finish, 0, 5);
            this.tableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel5.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 6;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel5.Size = new System.Drawing.Size(192, 427);
            this.tableLayoutPanel5.TabIndex = 0;
            // 
            // btn_start
            // 
            this.btn_start.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(44)))), ((int)(((byte)(90)))));
            this.btn_start.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_start.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btn_start.FlatAppearance.BorderSize = 2;
            this.btn_start.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_start.Font = new System.Drawing.Font("나눔고딕", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btn_start.ForeColor = System.Drawing.Color.White;
            this.btn_start.Location = new System.Drawing.Point(3, 172);
            this.btn_start.Margin = new System.Windows.Forms.Padding(3, 3, 3, 20);
            this.btn_start.Name = "btn_start";
            this.btn_start.Size = new System.Drawing.Size(186, 105);
            this.btn_start.TabIndex = 3;
            this.btn_start.Text = "시작";
            this.btn_start.UseVisualStyleBackColor = false;
            this.btn_start.Click += new System.EventHandler(this.btn_start_Click);
            // 
            // cb_lot
            // 
            this.cb_lot.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cb_lot.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_lot.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cb_lot.Font = new System.Drawing.Font("나눔고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.cb_lot.FormattingEnabled = true;
            this.cb_lot.Location = new System.Drawing.Point(3, 67);
            this.cb_lot.Name = "cb_lot";
            this.cb_lot.Size = new System.Drawing.Size(186, 27);
            this.cb_lot.TabIndex = 6;
            // 
            // btn_choiceLot
            // 
            this.btn_choiceLot.BackColor = System.Drawing.Color.Gray;
            this.btn_choiceLot.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_choiceLot.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btn_choiceLot.FlatAppearance.BorderSize = 2;
            this.btn_choiceLot.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_choiceLot.Font = new System.Drawing.Font("나눔고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btn_choiceLot.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btn_choiceLot.Location = new System.Drawing.Point(3, 109);
            this.btn_choiceLot.Name = "btn_choiceLot";
            this.btn_choiceLot.Size = new System.Drawing.Size(186, 36);
            this.btn_choiceLot.TabIndex = 7;
            this.btn_choiceLot.Text = "작업 선택";
            this.btn_choiceLot.UseVisualStyleBackColor = false;
            this.btn_choiceLot.Click += new System.EventHandler(this.btn_choiceLot_Click);
            // 
            // btn_getLot
            // 
            this.btn_getLot.BackColor = System.Drawing.Color.Gray;
            this.btn_getLot.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_getLot.FlatAppearance.BorderColor = System.Drawing.Color.WhiteSmoke;
            this.btn_getLot.FlatAppearance.BorderSize = 2;
            this.btn_getLot.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_getLot.Font = new System.Drawing.Font("나눔고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btn_getLot.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btn_getLot.Location = new System.Drawing.Point(3, 3);
            this.btn_getLot.Name = "btn_getLot";
            this.btn_getLot.Size = new System.Drawing.Size(186, 58);
            this.btn_getLot.TabIndex = 8;
            this.btn_getLot.Text = "작업 조회";
            this.btn_getLot.UseVisualStyleBackColor = false;
            this.btn_getLot.Click += new System.EventHandler(this.btn_getLot_Click);
            // 
            // btn_finish
            // 
            this.btn_finish.BackColor = System.Drawing.Color.Gray;
            this.btn_finish.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_finish.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btn_finish.FlatAppearance.BorderSize = 2;
            this.btn_finish.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_finish.Font = new System.Drawing.Font("나눔고딕", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btn_finish.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btn_finish.Location = new System.Drawing.Point(3, 300);
            this.btn_finish.Margin = new System.Windows.Forms.Padding(3, 3, 3, 20);
            this.btn_finish.Name = "btn_finish";
            this.btn_finish.Size = new System.Drawing.Size(186, 107);
            this.btn_finish.TabIndex = 1;
            this.btn_finish.Text = "검사 완료";
            this.btn_finish.UseVisualStyleBackColor = false;
            this.btn_finish.Click += new System.EventHandler(this.btn_finish_Click);
            // 
            // tableLayoutPanel6
            // 
            this.tableLayoutPanel6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(90)))), ((int)(((byte)(113)))));
            this.tableLayoutPanel6.ColumnCount = 1;
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel6.Controls.Add(this.label2, 0, 2);
            this.tableLayoutPanel6.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel6.Controls.Add(this.ng_panel, 0, 3);
            this.tableLayoutPanel6.Controls.Add(this.process_panel, 0, 1);
            this.tableLayoutPanel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel6.Location = new System.Drawing.Point(795, 3);
            this.tableLayoutPanel6.Name = "tableLayoutPanel6";
            this.tableLayoutPanel6.RowCount = 4;
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel6.Size = new System.Drawing.Size(193, 427);
            this.tableLayoutPanel6.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(90)))), ((int)(((byte)(113)))));
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label2.Font = new System.Drawing.Font("나눔고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label2.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label2.Location = new System.Drawing.Point(3, 212);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(187, 42);
            this.label2.TabIndex = 5;
            this.label2.Text = "불량률";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(90)))), ((int)(((byte)(113)))));
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label1.Font = new System.Drawing.Font("나눔고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(187, 42);
            this.label1.TabIndex = 4;
            this.label1.Text = "진행률";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ng_panel
            // 
            this.ng_panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ng_panel.Location = new System.Drawing.Point(13, 257);
            this.ng_panel.Margin = new System.Windows.Forms.Padding(13, 3, 13, 3);
            this.ng_panel.Name = "ng_panel";
            this.ng_panel.Size = new System.Drawing.Size(167, 167);
            this.ng_panel.TabIndex = 3;
            // 
            // process_panel
            // 
            this.process_panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.process_panel.Location = new System.Drawing.Point(13, 45);
            this.process_panel.Margin = new System.Windows.Forms.Padding(13, 3, 13, 3);
            this.process_panel.Name = "process_panel";
            this.process_panel.Size = new System.Drawing.Size(167, 164);
            this.process_panel.TabIndex = 2;
            // 
            // tableLayoutPanel7
            // 
            this.tableLayoutPanel7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(90)))), ((int)(((byte)(113)))));
            this.tableLayoutPanel7.ColumnCount = 1;
            this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel7.Controls.Add(this.tableLayoutPanel8, 0, 0);
            this.tableLayoutPanel7.Controls.Add(this.dg_history, 0, 1);
            this.tableLayoutPanel7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel7.Location = new System.Drawing.Point(198, 3);
            this.tableLayoutPanel7.Margin = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.tableLayoutPanel7.Name = "tableLayoutPanel7";
            this.tableLayoutPanel7.RowCount = 2;
            this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel7.Size = new System.Drawing.Size(594, 427);
            this.tableLayoutPanel7.TabIndex = 2;
            // 
            // tableLayoutPanel8
            // 
            this.tableLayoutPanel8.ColumnCount = 1;
            this.tableLayoutPanel8.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel8.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel8.Controls.Add(this.panel2, 0, 0);
            this.tableLayoutPanel8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel8.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel8.Name = "tableLayoutPanel8";
            this.tableLayoutPanel8.RowCount = 1;
            this.tableLayoutPanel8.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel8.Size = new System.Drawing.Size(588, 207);
            this.tableLayoutPanel8.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.picture_state);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(582, 201);
            this.panel2.TabIndex = 1;
            // 
            // picture_state
            // 
            this.picture_state.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(90)))), ((int)(((byte)(113)))));
            this.picture_state.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picture_state.Location = new System.Drawing.Point(0, 0);
            this.picture_state.Name = "picture_state";
            this.picture_state.Size = new System.Drawing.Size(580, 199);
            this.picture_state.TabIndex = 0;
            this.picture_state.TabStop = false;
            // 
            // dg_history
            // 
            this.dg_history.AllowUserToAddRows = false;
            this.dg_history.AllowUserToDeleteRows = false;
            this.dg_history.BackgroundColor = System.Drawing.SystemColors.ActiveBorder;
            this.dg_history.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dg_history.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dg_history.Location = new System.Drawing.Point(6, 216);
            this.dg_history.Margin = new System.Windows.Forms.Padding(6, 3, 6, 3);
            this.dg_history.Name = "dg_history";
            this.dg_history.ReadOnly = true;
            this.dg_history.RowTemplate.Height = 23;
            this.dg_history.Size = new System.Drawing.Size(582, 208);
            this.dg_history.TabIndex = 1;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(90)))), ((int)(((byte)(113)))));
            this.ClientSize = new System.Drawing.Size(997, 599);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "Form1";
            this.Text = "품질관리";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.tableLayoutPanel10.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel5.ResumeLayout(false);
            this.tableLayoutPanel6.ResumeLayout(false);
            this.tableLayoutPanel6.PerformLayout();
            this.tableLayoutPanel7.ResumeLayout(false);
            this.tableLayoutPanel8.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picture_state)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dg_history)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Label CorpName;
        private System.Windows.Forms.Label lb_workerId;
        private System.Windows.Forms.Label lb_end;
        private System.Windows.Forms.Label lb_start;
        private System.Windows.Forms.Label lb_lotId;
        private System.Windows.Forms.Label lb_productId;
        private System.Windows.Forms.Label lb_machineId;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
        private System.Windows.Forms.Button btn_start;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel6;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel7;
        private System.Windows.Forms.DataGridView dg_history;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel8;
        private System.Windows.Forms.Button btn_finish;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel ng_panel;
        private System.Windows.Forms.Panel process_panel;
        private System.Windows.Forms.PictureBox picture_state;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel10;
        private System.Windows.Forms.Button btn_popup_login;
        private System.Windows.Forms.Label lb_currentTime;
        private System.Windows.Forms.ComboBox cb_lot;
        private System.Windows.Forms.Button btn_choiceLot;
        private System.Windows.Forms.Button btn_getLot;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lb_endTime;
        private System.Windows.Forms.Label lb_startTime;
        private System.Windows.Forms.Label lb_lot;
        private System.Windows.Forms.Label lb_partId;
        private System.Windows.Forms.Label lb_lineId;
    }
}

