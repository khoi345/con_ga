using System;
using System.Collections.Generic;
using System.Web.Script.Serialization;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Data;
using Dto;
namespace Client
{
	public class NguoiDungClient : NguoiDung
	{
		 
		public NguoiDung GetByDienThoai(NguoiDung p)
		{
			Dictionary<string, string> dic = new Dictionary<string, string>();
			dic["objName"] = objName;
			dic["obj"] = p.ToJSON(p);
			dic["thaoTac"] = "LNDBDT";
			var jsonSerialiser = new JavaScriptSerializer();
			jsonSerialiser.RegisterConverters(new JavaScriptConverter[] { new DateTimeConverter() });
			List<NguoiDung> l = jsonSerialiser.Deserialize<List<NguoiDung>>(DataTransport.GetPostStrObj(dic, false));
			if (l != null && l.Count > 0)
			{
				return l[0];
			}
			return null;
		}
        public bool Insert(NguoiDung p)
        {
            Dictionary<string, string> dic = new Dictionary<string, string>();
            dic["objName"] = objName;
            dic["obj"] = p.ToJSON(p);
            dic["thaoTac"] = "IND";
            return DataTransport.Action(dic, false);
        } 
		public bool KiemTraTonTaiSoDienThoai(NguoiDung p)
        {
            Dictionary<string, string> dic = new Dictionary<string, string>();
            dic["objName"] = objName;
            dic["obj"] = p.ToJSON(p);
            dic["thaoTac"] = "KTTTSDT";
            return DataTransport.Action(dic, false);
        }

    }
}