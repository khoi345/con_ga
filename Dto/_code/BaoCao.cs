using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace Dto
{
    public class BaoCao
    {
        public static string objName = "BaoCao";
        public string UserID { get; set; } = "";
        public string LotID { get; set; } = "";

        public string ToJSON(BaoCao p)
        {
            var serializer = new JavaScriptSerializer();
            serializer.RegisterConverters(new JavaScriptConverter[] { new DateTimeConverter() });
            string json = serializer.Serialize(p);
            return json;

        }
    }
    public class BaoCaoKetQua
    {

        public string SlotMoSoID { get; set; } = "";

        public int SoDuocDat { get; set; } = -1;
        public DateTime ThoiGianDat { get; set; } 

        public string KetQua { get; set; } = "";
    }
}
