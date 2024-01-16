using System;
using System.Windows.Forms;

namespace Client
{
    public partial class ThongBao : Form
    {
        public ThongBao()
        {
            InitializeComponent();
        }
        public static bool isShow = false;
        public static ThongBao fr;

        private void ThongBao_Load(object sender, EventArgs e)
        {
            txLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            // Allow the TAB key to be entered in the TextBox control.
            txLog.AcceptsReturn = true;
            // Allow the TAB key to be entered in the TextBox control.
            txLog.AcceptsTab = true;
            // Set WordWrap to true to allow text to wrap to the next line.
            txLog.WordWrap = true;
            // Set the default text of the control.
        }
        public static void ShowThongBao(string str)
        {
            MauChu mc = new MauChu();
            if (isShow == false)
            {
                isShow = true;
                fr = new ThongBao();
                fr.txLog.Text = str;
             //   mc.doimauchu(fr.txLog);
                fr.Show();
            }
            else
            {
                fr.txLog.Text += "\n" + str;
              //  mc.doimauchu(fr.txLog);
                fr.txLog.Refresh();
              //  fr.txLog.Refresh();
                //move the caret to the end of the text
                fr.txLog.SelectionStart = fr.txLog.TextLength;
                //scroll to the caret
                fr.txLog.ScrollToCaret();
                //Sets the cursor
                fr.txLog.Focus();
            }
            if (Application.OpenForms[fr.Name] == null)
            {
                fr.Show();
            }
            else
            {
                Application.OpenForms[fr.Name].Focus();
            }
        }

        private void ThongBao_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void txThongBao_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void ThongBao_FormClosing(object sender, FormClosingEventArgs e)
        {
            isShow = false;
        }
    }
}
