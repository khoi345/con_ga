 
using System;
using System.Collections.Generic;
using System.Web.Script.Serialization;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Data;
using Dto;
namespace Client
{
	public class DatMuaSoClient : DatMuaSo
	{
		public DatMuaSoClient()
		{
			
		}
	 
		public DatMuaSo GetOnlyByID(DatMuaSo p)
		{
			Dictionary<string, string> dic = new Dictionary<string, string>();
			dic["objName"] = objName;
			dic["obj"] = p.ToJSON(p);
			dic["thaoTac"] = "GBID";
			var jsonSerialiser = new JavaScriptSerializer();
			jsonSerialiser.RegisterConverters(new JavaScriptConverter[] { new DateTimeConverter() });
			DatMuaSo l = jsonSerialiser.Deserialize<DatMuaSo>(DataTransport.GetPostStrObj(dic, false));
			if (l != null)
			{
				return l;
			}
			return null;
		}
		public DatMuaSo DatMuaSoConGa(DatMuaSo p)
		{
			Dictionary<string, string> dic = new Dictionary<string, string>();
			dic["objName"] = objName;
			dic["obj"] = p.ToJSON(p);
			dic["thaoTac"] = "DMSCG";
			var jsonSerialiser = new JavaScriptSerializer();
			jsonSerialiser.RegisterConverters(new JavaScriptConverter[] { new DateTimeConverter() });
			string str = DataTransport.GetPostStrObj(dic, false);
			List<DatMuaSo> l = jsonSerialiser.Deserialize<List<DatMuaSo>>(str);
			if (l != null && l.Count > 0)
			{
				return l[0];
			}
			return null;
		}

		public List<DatMuaSo> GetAllListByUserID(DatMuaSo p)
		{
			{
				Dictionary<string, string> dic = new Dictionary<string, string>();
				dic["objName"] = objName;
				dic["obj"] = p.ToJSON(p);
				dic["thaoTac"] = "LBUID";
				var jsonSerialiser = new JavaScriptSerializer();
				jsonSerialiser.RegisterConverters(new JavaScriptConverter[] { new DateTimeConverter() });
				List<DatMuaSo> l = jsonSerialiser.Deserialize<List<DatMuaSo>>(DataTransport.GetPostStrObj(dic, false));
				if (l != null && l.Count > 0)
				{
					return l;
				}
				else return new List<DatMuaSo>();
			}
		}
		 
		//public bool KiemTraDaSuDung(DatMuaSo p)
		//{
		//	Dictionary<string, string> dic = new Dictionary<string, string>();
		//	dic["objName"] = objName;
		//	dic["obj"] = p.ToJSON(p);
		//	dic["thaoTac"] = "KTDSD";
		//	return DataTransport.Action(dic, false);
		//}
		//public bool KiemTraTonTai(DatMuaSo p)
		//{
		//	Dictionary<string, string> dic = new Dictionary<string, string>();
		//	dic["objName"] = objName;
		//	dic["obj"] = p.ToJSON(p);
		//	dic["thaoTac"] = "KTTT";
		//	return DataTransport.Action(dic, false);
		//}
		 
	}
}