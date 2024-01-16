using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;

namespace Dto
{
	public class DatMuaSo
	{

		public static string objName = "DatMuaSo";

		public static int _sizeCreateUser = 36;
		public static int _sizeEditUser = 36;
		public object ID { get; set; }
		public DateTime ThoiGianDat { get; set; }
		public object SlotMoSoID { get; set; }
		public object SoDuocDat { get; set; }
		public object UserID { get; set; }
		public string CreateUser { get; set; }
		public DateTime CreateDate { get; set; }	
		public string EditUser { get; set; }
		public DateTime EditDate { get; set; }

		public DatMuaSo()
		{

		}

		public DatMuaSo(object DatMuaSoID, object SlotMoSoID, object UserID)
		{

			this.ID = DatMuaSoID;
			this.SlotMoSoID = SlotMoSoID;
			this.UserID = UserID;
		}

		public DatMuaSo(DatMuaSo temp)
		{
			this.ID = temp.ID;
			this.ThoiGianDat = temp.ThoiGianDat;
			this.SlotMoSoID = temp.SlotMoSoID;
			this.SoDuocDat = temp.SoDuocDat;
			this.UserID = temp.UserID;
			this.CreateUser = temp.CreateUser;
			this.CreateDate = temp.CreateDate;
			this.EditUser = temp.EditUser;
			this.EditDate = temp.EditDate;
		}

		public string ToJSON(DatMuaSo p)
		{
			var serializer = new JavaScriptSerializer();
			serializer.RegisterConverters(new JavaScriptConverter[] { new DateTimeConverter() });
			string json = serializer.Serialize(p);
			return json;

		}
		public DatMuaSo Truncate(DatMuaSo info)
		{
			if (info == null) return null;
			DatMuaSo t = new DatMuaSo(info);
			t.ThoiGianDat = (_Dto.IsDate(info.ThoiGianDat) && info.ThoiGianDat > DateTime.MinValue) ? info.ThoiGianDat : new DateTime(1970, 1, 1);
			t.SlotMoSoID = (info.SlotMoSoID != null && info.SlotMoSoID.ToString().Trim() != "") ? info.SlotMoSoID : 0;
			t.SoDuocDat = (info.SoDuocDat != null && info.SoDuocDat.ToString().Trim() != "") ? info.SoDuocDat : 0;
			t.UserID = (info.UserID != null && info.UserID.ToString().Trim() != "") ? info.UserID : 0;
			t.CreateUser = info.CreateUser.Truncate(_sizeCreateUser);
			t.CreateDate = (_Dto.IsDate(info.CreateDate) && info.CreateDate > DateTime.MinValue) ? info.CreateDate : new DateTime(1970, 1, 1);
			t.EditUser = info.EditUser.Truncate(_sizeEditUser);
			t.EditDate = (_Dto.IsDate(info.EditDate) && info.EditDate > DateTime.MinValue) ? info.EditDate : new DateTime(1970, 1, 1);
			return t;
		}

	}
}