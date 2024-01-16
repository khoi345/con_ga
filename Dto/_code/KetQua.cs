using System.Web.Script.Serialization;

namespace Dto
{

    public class KetQua : _obj
    {
        public bool error { get; set; }
        public string error_msg { get; set; }
        public bool thongBao { get; set; }
        public string thongBao_msg { get; set; }
        public string result { get; set; }
        public byte[] resultArray { get; set; }

        public KetQua()
        {
            error = false;
            error_msg = "";
            thongBao = false;
            thongBao_msg = "";
            result = "[]";
            IsZip = false;
        }
        public KetQua(KetQua tmp)
        {
            if (tmp != null)
            {
                this.error = tmp.error;
                this.error_msg = tmp.error_msg;
                this.thongBao = tmp.thongBao;
                this.thongBao_msg = tmp.thongBao_msg;
                this.result = tmp.result;
            }
            else new KetQua();
        }

        public override string ToString()
        {
            JavaScriptSerializer tmp = new JavaScriptSerializer();
            tmp.MaxJsonLength = _Dto.MaxValue;
            //   tmp.RecursionLimit = 100;
            return tmp.Serialize(this);
        }
    }
}