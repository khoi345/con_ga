using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;
using System.Windows.Forms;
using System.Xml;

namespace Client
{
    [System.Diagnostics.DebuggerNonUserCode()]
    public static class lData
    {
        public static string Maincode(string sql)
        {
            XmlDocument doc = new XmlDocument();
            try
            {
                doc.Load(Application.StartupPath + "\\maincode.xml");

            }
            catch (Exception ex)
            {
                MessageBox.Show(MethodBase.GetCurrentMethod().Name + ": " + ex.Message, "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            XmlNodeList nodeLst = doc.GetElementsByTagName(sql);
            return nodeLst.Item(0).InnerText;

        }
        public static void GetLeafID(List<string> lNode, DataTable dt, string ParentID, string ParentFieldName, string KeyFieldName)
        {
            try
            {
                DataRow[] rows = dt.Select(ParentFieldName + " = '" + ParentID + "'");
                if (rows == null || rows.Length == 0)
                {
                    if (lNode.Contains(ParentID) == false) lNode.Add(ParentID);
                    return;
                }
                foreach (DataRow r in rows)
                {
                    string IDForder = "";
                    IDForder = r[KeyFieldName].ToString();
                    if (IDForder == "0")
                    {
                        if (lNode.Contains(ParentID) == false) lNode.Add(ParentID);
                        return;
                    }
                    if (lNode.Contains(ParentID) == false) lNode.Add(ParentID);
                    GetLeafID(lNode, dt, IDForder.ToString(), ParentFieldName, KeyFieldName);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(MethodBase.GetCurrentMethod().Name + ": " + ex.Message, "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        public static DateTime GetDateTime()
        {
            return DateTime.Now;
        }

    }
}
