
using System;
using System.Collections.Generic;
using System.Web.Script.Serialization;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Data;
using Dto;
namespace Client
{
	public class BaoCaoClient : BaoCao
	{
		public BaoCaoClient()
		{

		}

		public List<BaoCaoKetQua> LoadKetQuaSoByUserID(BaoCao p)
		{
			Dictionary<string, string> dic = new Dictionary<string, string>();
			dic["objName"] = objName;
			dic["obj"] = p.ToJSON(p);
			dic["thaoTac"] = "LKQSBUI";
			var jsonSerialiser = new JavaScriptSerializer();
			jsonSerialiser.RegisterConverters(new JavaScriptConverter[] { new DateTimeConverter() });
			List<BaoCaoKetQua> l = jsonSerialiser.Deserialize<List<BaoCaoKetQua>>(DataTransport.GetPostStrObj(dic, false));
			if (l != null && l.Count>0)
			{
				return l;
			}
			return null;
		}
		public string LuotQuaySoTiepTheo(BaoCao p)
		{
			Dictionary<string, string> dic = new Dictionary<string, string>();
			dic["objName"] = objName;
			dic["obj"] = p.ToJSON(p);
			dic["thaoTac"] = "LQSTT";
			var jsonSerialiser = new JavaScriptSerializer();
			jsonSerialiser.RegisterConverters(new JavaScriptConverter[] { new DateTimeConverter() });
			string l = jsonSerialiser.Deserialize<string>(DataTransport.GetPostStrObj(dic, false));
			return l;
		}

	}
}