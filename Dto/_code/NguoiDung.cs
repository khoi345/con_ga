using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;

namespace Dto
{
	public class NguoiDung
	{

		public static string objName = "NguoiDung";

		public static int _sizeDienThoai = 36;
		public static int _sizeHoTen = 255;
		public static int _sizeCreateUser = 36;
		public static int _sizeEditUser = 36;
		public object ID { get; set; } = -1;
		public string DienThoai { get; set; }
		public DateTime NgaySinh { get; set; } = DateTime.Now;
		public string HoTen { get; set; }
		public string CreateUser { get; set; }
		public DateTime CreateDate { get; set; }
		public string EditUser { get; set; }
		public DateTime EditDate { get; set; }

		public NguoiDung()
		{
			NgaySinh = DateTime.Now;
		}

		public NguoiDung(object UserID, string DienThoai)
		{

			this.ID = UserID;
			this.DienThoai = DienThoai;
		}

		public NguoiDung(NguoiDung temp)
		{
			this.ID = temp.ID;
			this.DienThoai = temp.DienThoai;
			this.NgaySinh = temp.NgaySinh;
			this.HoTen = temp.HoTen;
			this.CreateUser = temp.CreateUser;
			this.CreateDate = temp.CreateDate;
			this.EditUser = temp.EditUser;
			this.EditDate = temp.EditDate;
		}

		public string ToJSON(NguoiDung p)
		{
			var serializer = new JavaScriptSerializer();
			serializer.RegisterConverters(new JavaScriptConverter[] { new DateTimeConverter() });
			string json = serializer.Serialize(p);
			return json;

		}
		public NguoiDung Truncate(NguoiDung info)
		{
			if (info == null) return null;
			NguoiDung t = new NguoiDung(info);
			t.DienThoai = info.DienThoai.Truncate(_sizeDienThoai);
			t.NgaySinh = (_Dto.IsDate(info.NgaySinh) && info.NgaySinh > DateTime.MinValue) ? info.NgaySinh : new DateTime(1970, 1, 1);
			t.HoTen = info.HoTen.Truncate(_sizeHoTen);
			t.CreateUser = info.CreateUser.Truncate(_sizeCreateUser);
			t.CreateDate = (_Dto.IsDate(info.CreateDate) && info.CreateDate > DateTime.MinValue) ? info.CreateDate : new DateTime(1970, 1, 1);
			t.EditUser = info.EditUser.Truncate(_sizeEditUser);
			t.EditDate = (_Dto.IsDate(info.EditDate) && info.EditDate > DateTime.MinValue) ? info.EditDate : new DateTime(1970, 1, 1);
			return t;
		}

	}
}