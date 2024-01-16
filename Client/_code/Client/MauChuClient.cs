using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Client
{
    public class MauChu
    {
        public List<string> listToMau;
        Color color;

        public MauChu()
        {
            color = Color.Blue;
        }

        public void doimauchu(RichTextBox result)
        {
            int pos = result.SelectionStart;
            string s = result.Text;
            for (int j = 0; j < listToMau.Count; j++)
            {
                for (int ix = 0; ;)
                {
                    int jx = s.IndexOf(listToMau[j], ix, StringComparison.CurrentCultureIgnoreCase);
                    if (jx < 0) break;
                    result.SelectionStart = jx;
                    result.SelectionLength = listToMau[j].Length;
                    result.SelectionColor = color;
                    ix = jx + 1;
                }
            }
            result.SelectionStart = pos;
            result.SelectionLength = 0;
        }

        public void setMau()
        {
            listToMau = new List<string>();
            listToMau.Add("select");
            listToMau.Add("from");
            listToMau.Add("delete");
            listToMau.Add("update");
            listToMau.Add("for");
            listToMau.Add("where");
            listToMau.Add("object");
            listToMau.Add("catch");
            listToMau.Add("try");
            listToMau.Add("public");
            listToMau.Add("static");
            listToMau.Add("string");
            listToMau.Add("if");
            listToMau.Add("else");
            listToMau.Add("this");
            listToMau.Add("throw");
            listToMau.Add("return");
            listToMau.Add("finally");
            listToMau.Add("null");
            listToMau.Add("get");
            listToMau.Add("set");
            listToMau.Add("private");
            listToMau.Add("ALTER");
            listToMau.Add("TABLE ");
            listToMau.Add("DataTable ");
            listToMau.Add(" Dictionary");
            listToMau.Add(" new ");
            listToMau.Add("DataTable ");
            listToMau.Add("ADD");
            listToMau.Add("MODIFY");
            listToMau.Add("DROP");
            listToMau.Add("COLUMN");
            listToMau.Add("INSERT");
            listToMau.Add("INTO");
            listToMau.Add(" As ");
            listToMau.Add("bool ");
            listToMau.Add("void ");
            listToMau.Add("class ");
            listToMau.Add("default");
            listToMau.Add("var ");
            listToMau.Add("namespace ");
            listToMau.Add("using ");
            listToMau.Add("switch ");
            listToMau.Add("case ");
        }
    }
}
