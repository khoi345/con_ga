namespace Client
{
    partial class frMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btDatCuoc = new System.Windows.Forms.Button();
            this.txDienThoai = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.dtNgaySinh = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.txHoTen = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txDatCuoc = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.txTuoi = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txNguoiChienThang = new System.Windows.Forms.Label();
            this.dgLichSu = new System.Windows.Forms.DataGridView();
            this.label6 = new System.Windows.Forms.Label();
            this.paMau = new System.Windows.Forms.Panel();
            this.txThongBao = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txLuotTiepTheio = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.txDatCuoc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgLichSu)).BeginInit();
            this.paMau.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btDatCuoc
            // 
            this.btDatCuoc.Location = new System.Drawing.Point(104, 58);
            this.btDatCuoc.Name = "btDatCuoc";
            this.btDatCuoc.Size = new System.Drawing.Size(75, 23);
            this.btDatCuoc.TabIndex = 1;
            this.btDatCuoc.Text = "Đặt cược";
            this.btDatCuoc.UseVisualStyleBackColor = true;
            this.btDatCuoc.Click += new System.EventHandler(this.btDatCuoc_Click);
            // 
            // txDienThoai
            // 
            this.txDienThoai.Location = new System.Drawing.Point(131, 13);
            this.txDienThoai.Name = "txDienThoai";
            this.txDienThoai.Size = new System.Drawing.Size(182, 20);
            this.txDienThoai.TabIndex = 0;
            this.txDienThoai.Text = "0866592512";
            this.txDienThoai.Validated += new System.EventHandler(this.txDienThoai_Validated);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(73, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Điện thoại:";
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // dtNgaySinh
            // 
            this.dtNgaySinh.CustomFormat = "dd/MM/yyyy";
            this.dtNgaySinh.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtNgaySinh.Location = new System.Drawing.Point(131, 65);
            this.dtNgaySinh.Name = "dtNgaySinh";
            this.dtNgaySinh.Size = new System.Drawing.Size(115, 20);
            this.dtNgaySinh.TabIndex = 2;
            this.dtNgaySinh.ValueChanged += new System.EventHandler(this.dtNgaySinh_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(110, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Ngày tháng năm sinh:";
            // 
            // txHoTen
            // 
            this.txHoTen.Location = new System.Drawing.Point(131, 39);
            this.txHoTen.Name = "txHoTen";
            this.txHoTen.Size = new System.Drawing.Size(182, 20);
            this.txHoTen.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(89, 42);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Họ tên:";
            // 
            // txDatCuoc
            // 
            this.txDatCuoc.Location = new System.Drawing.Point(59, 22);
            this.txDatCuoc.Name = "txDatCuoc";
            this.txDatCuoc.Size = new System.Drawing.Size(120, 20);
            this.txDatCuoc.TabIndex = 0;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 25);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(51, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Đặt cược";
            // 
            // txTuoi
            // 
            this.txTuoi.Location = new System.Drawing.Point(131, 91);
            this.txTuoi.Name = "txTuoi";
            this.txTuoi.Size = new System.Drawing.Size(182, 20);
            this.txTuoi.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(100, 94);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(31, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Tuổi:";
            // 
            // txNguoiChienThang
            // 
            this.txNguoiChienThang.AutoSize = true;
            this.txNguoiChienThang.Dock = System.Windows.Forms.DockStyle.Top;
            this.txNguoiChienThang.Location = new System.Drawing.Point(0, 0);
            this.txNguoiChienThang.Name = "txNguoiChienThang";
            this.txNguoiChienThang.Size = new System.Drawing.Size(0, 13);
            this.txNguoiChienThang.TabIndex = 6;
            // 
            // dgLichSu
            // 
            this.dgLichSu.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgLichSu.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dgLichSu.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgLichSu.DefaultCellStyle = dataGridViewCellStyle6;
            this.dgLichSu.Location = new System.Drawing.Point(555, 28);
            this.dgLichSu.Name = "dgLichSu";
            this.dgLichSu.Size = new System.Drawing.Size(463, 312);
            this.dgLichSu.TabIndex = 11;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(611, 9);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(87, 13);
            this.label6.TabIndex = 6;
            this.label6.Text = "Lịch sử đặt cược";
            // 
            // paMau
            // 
            this.paMau.Controls.Add(this.txThongBao);
            this.paMau.Location = new System.Drawing.Point(13, 298);
            this.paMau.Name = "paMau";
            this.paMau.Size = new System.Drawing.Size(536, 54);
            this.paMau.TabIndex = 12;
            // 
            // txThongBao
            // 
            this.txThongBao.AutoSize = true;
            this.txThongBao.Dock = System.Windows.Forms.DockStyle.Top;
            this.txThongBao.Location = new System.Drawing.Point(0, 0);
            this.txThongBao.Name = "txThongBao";
            this.txThongBao.Padding = new System.Windows.Forms.Padding(10);
            this.txThongBao.Size = new System.Drawing.Size(36, 33);
            this.txThongBao.TabIndex = 6;
            this.txThongBao.Text = "...";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txDienThoai);
            this.groupBox1.Controls.Add(this.txHoTen);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.dtNgaySinh);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txTuoi);
            this.groupBox1.Location = new System.Drawing.Point(13, 28);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(326, 129);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông tin cá nhân";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txDatCuoc);
            this.groupBox2.Controls.Add(this.btDatCuoc);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Location = new System.Drawing.Point(350, 28);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(199, 129);
            this.groupBox2.TabIndex = 14;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Đặt cược";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.panel1.Controls.Add(this.txLuotTiepTheio);
            this.panel1.Location = new System.Drawing.Point(16, 189);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(536, 54);
            this.panel1.TabIndex = 15;
            // 
            // txLuotTiepTheio
            // 
            this.txLuotTiepTheio.AutoSize = true;
            this.txLuotTiepTheio.Dock = System.Windows.Forms.DockStyle.Top;
            this.txLuotTiepTheio.Location = new System.Drawing.Point(0, 0);
            this.txLuotTiepTheio.Name = "txLuotTiepTheio";
            this.txLuotTiepTheio.Padding = new System.Windows.Forms.Padding(10);
            this.txLuotTiepTheio.Size = new System.Drawing.Size(36, 33);
            this.txLuotTiepTheio.TabIndex = 6;
            this.txLuotTiepTheio.Text = "...";
            // 
            // frMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1030, 352);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dgLichSu);
            this.Controls.Add(this.paMau);
            this.Controls.Add(this.txNguoiChienThang);
            this.Controls.Add(this.label6);
            this.Name = "frMain";
            this.Text = "Con gà con gà";
            this.Load += new System.EventHandler(this.frMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txDatCuoc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgLichSu)).EndInit();
            this.paMau.ResumeLayout(false);
            this.paMau.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label txNguoiChienThang;
        private System.Windows.Forms.DataGridView dgLichSu;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel paMau;
        private System.Windows.Forms.Label txThongBao;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        public System.Windows.Forms.Button btDatCuoc;
        public System.Windows.Forms.TextBox txDienThoai;
        public System.Windows.Forms.DateTimePicker dtNgaySinh;
        public System.Windows.Forms.TextBox txHoTen;
        public System.Windows.Forms.NumericUpDown txDatCuoc;
        public System.Windows.Forms.TextBox txTuoi;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label txLuotTiepTheio;
    }
}