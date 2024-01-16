namespace Client
{
    partial class ThongBao
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
            this.txLog = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // txLog
            // 
            this.txLog.BackColor = System.Drawing.SystemColors.Menu;
            this.txLog.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txLog.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txLog.Location = new System.Drawing.Point(0, 0);
            this.txLog.Margin = new System.Windows.Forms.Padding(6);
            this.txLog.Multiline = true;
            this.txLog.Name = "txLog";
            this.txLog.Size = new System.Drawing.Size(1131, 308);
            this.txLog.TabIndex = 1;
            this.txLog.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txThongBao_KeyDown);
            // 
            // ThongBao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1131, 308);
            this.Controls.Add(this.txLog);
            this.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.Margin = new System.Windows.Forms.Padding(6);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ThongBao";
            this.ShowIcon = false;
            this.Text = "Thông báo lỗi";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ThongBao_FormClosing);
            this.Load += new System.EventHandler(this.ThongBao_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ThongBao_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txLog;
    }
}