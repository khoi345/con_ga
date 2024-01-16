using System;
using System.Security.Cryptography;
using System.Text;
using System.Web.Script.Serialization;

namespace Dto
{
    public class _Dto : _obj
    {
        public static int MaxValue = 1073741824 / 4;//2gb /4
        public string KetNoi { get; set; }
        public string ObjName { get; set; }
        public string ThaoTac { get; set; }

        public string Obj { get; set; }
        public string Ver { get; set; }
        public string _boLoc { get; set; }

        public _Dto()
        {
            KetNoi = "";
            ObjName = "";
            ThaoTac = "";
            Obj = "";

        }
        public override string ToString()
        {
            JavaScriptSerializer tmp = new JavaScriptSerializer();
            tmp.MaxJsonLength = _Dto.MaxValue;
            return tmp.Serialize(this);
        }
        public static string DanhSachDuocDinhDang(string str)
        {
            string[] ds = str.Split(',', ' ', ';', '\n');
            string dsb = "";
            for (int i = 0; i < ds.Length; i++)
            {
                if (ds[i].Trim() != "")
                {
                    dsb += "'" + ds[i] + "',";
                }
            }
            if (dsb.Length > 0)
            {
                dsb = dsb.Substring(0, dsb.Length - 1);
            }
            return dsb;
        }
        public string MD5(string str)
        {

            byte[] asciiBytes = ASCIIEncoding.UTF8.GetBytes(str);
            byte[] hashedBytes = MD5CryptoServiceProvider.Create().ComputeHash(asciiBytes);
            string hashedString = BitConverter.ToString(hashedBytes).Replace("-", "").ToLower();
            return hashedString;
        }
        public string ToBASE64(string str)
        {
            byte[] data = System.Text.ASCIIEncoding.ASCII.GetBytes(str);
            return System.Convert.ToBase64String(data);
        }
        public static string ToJSON(object p)
        {
            var serializer = new JavaScriptSerializer();
            serializer.RegisterConverters(new JavaScriptConverter[] {  });
            string json = serializer.Serialize(p);
            return json;

        }
    }

}