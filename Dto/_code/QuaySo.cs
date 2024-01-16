using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;

namespace Dto
{
	public class QuaySo
	{

		public static string objName = "QuaySo";

		public static int _sizeCreateUser = 36;
		public static int _sizeEditUser = 36;
		public object ID { get; set; }
		public DateTime ThoiGianQuaySo { get; set; }
		public object KetQua { get; set; }
		public string CreateUser { get; set; }
		public DateTime CreateDate { get; set; }
		public string EditUser { get; set; }
		public DateTime EditDate { get; set; }

		public QuaySo()
		{

		}

		public QuaySo(object QuaySoID, string CreateUser, string EditUser)
		{

			this.ID = QuaySoID;
			this.CreateUser = CreateUser;
			this.EditUser = EditUser;
		}

		public QuaySo(QuaySo temp)
		{
			this.ID = temp.ID;
			this.ThoiGianQuaySo = temp.ThoiGianQuaySo;
			this.KetQua = temp.KetQua;
			this.CreateUser = temp.CreateUser;
			this.CreateDate = temp.CreateDate;
			this.EditUser = temp.EditUser;
			this.EditDate = temp.EditDate;
		}

		public string ToJSON(QuaySo p)
		{
			var serializer = new JavaScriptSerializer();
			serializer.RegisterConverters(new JavaScriptConverter[] { new DateTimeConverter() });
			string json = serializer.Serialize(p);
			return json;

		}
		public QuaySo Truncate(QuaySo info)
		{
			if (info == null) return null;
			QuaySo t = new QuaySo(info);
			t.ThoiGianQuaySo = (_Dto.IsDate(info.ThoiGianQuaySo) && info.ThoiGianQuaySo > DateTime.MinValue) ? info.ThoiGianQuaySo : new DateTime(1970, 1, 1);
			t.KetQua = (info.KetQua != null && info.KetQua.ToString().Trim() != "") ? info.KetQua : 0;
			t.CreateUser = info.CreateUser.Truncate(_sizeCreateUser);
			t.CreateDate = (_Dto.IsDate(info.CreateDate) && info.CreateDate > DateTime.MinValue) ? info.CreateDate : new DateTime(1970, 1, 1);
			t.EditUser = info.EditUser.Truncate(_sizeEditUser);
			t.EditDate = (_Dto.IsDate(info.EditDate) && info.EditDate > DateTime.MinValue) ? info.EditDate : new DateTime(1970, 1, 1);
			return t;
		}

	}
}