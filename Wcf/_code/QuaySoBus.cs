using System;
using System.Web.Script.Serialization;
using System.Reflection;
using Dto;
using Dao;
namespace Wcf
{
	public class QuaySoBus :BusCache
	{
		public KetQua XuLy(_Dto data)
		{
			try
			{
				string thaoTac = data.ThaoTac;
				KetQua kq = new KetQua();
				var jsonSerialiser = new JavaScriptSerializer();
				jsonSerialiser.RegisterConverters(new JavaScriptConverter[] { new DateTimeConverter() });

				BoLoc boLoc = null;
				if (data._boLoc != null)
				{
					boLoc = jsonSerialiser.Deserialize<BoLoc>(data._boLoc);
				}
				TaoName(data);
				thaoTac = LayCache(kq, thaoTac);

				QuaySo obj = jsonSerialiser.Deserialize<QuaySo>(data.Obj);
				QuaySoDao dao = new QuaySoDao();
				switch (thaoTac)
				{
					case "NQS": kq.result = jsonSerialiser.Serialize(dao.New(obj));
						XoaListCache(data); 
						break;
					case "IQS": kq.result = jsonSerialiser.Serialize(dao.Insert(obj).ToString());      
						XoaListCache(data);     break;
					case "DQS": kq.result = jsonSerialiser.Serialize(dao.Delete(obj).ToString());     
						XoaListCache(data);     break;
					case "UQS": kq.result = jsonSerialiser.Serialize(dao.Update(obj).ToString());
						XoaListCache(data); break;
					case "GBID": kq.result = jsonSerialiser.Serialize(dao.GetOnlyByID(obj.ID.ToString()));
						TaoCacheByID(data); 
						break;
					case "LBID": kq.result = jsonSerialiser.Serialize(dao.Get(obj));
						TaoCacheByID(data); 
						break;
					//case "LBIDS": kq.result = jsonSerialiser.Serialize(dao.GetS(obj));          break; 
					//case "LBIDR": kq.result = jsonSerialiser.Serialize(dao.GetR(obj));          break; 
					case "LA":
						jsonSerialiser.MaxJsonLength = Int32.MaxValue;
						kq.result = jsonSerialiser.Serialize(dao.GetAll(obj, boLoc));
						TaoCacheByID(data); 
						break;
					case "KTTT": kq.result = jsonSerialiser.Serialize(dao.KiemTraTonTai(obj));
						TaoCacheByID(data); break;
					//	case "KTTTT": kq.result = jsonSerialiser.Serialize(dao.KiemTraTenTonTai(obj));           break;
					//	case "KTDSD": kq.result = jsonSerialiser.Serialize(dao.KiemTraDaSuDung(obj));           break;
					default:   
						return kq;
				}
				SetCache(kq, 60 * 60 * 24);
				SysCache();
				return kq;
			}
			catch (Exception ex)
			{
				long loi = -1;
				GuiLogDao gl = new GuiLogDao();
				if (data != null)
					loi = gl.GuiLogTraMaLoi(this.GetType().Name, data.ThaoTac, data.Obj, ex.Message, data.Ver);
				else
					loi = gl.GuiLogTraMaLoi(this.GetType().Name, "", "", ex.Message, "");
				throw new System.ArgumentException("Mã lỗi: " + loi.ToString() + " " + ex.Message);

			}
		}
		 
		public void QuaySoVaLuuKetQua()
		{
			int randomNumber = new Random().RandBetween(0, 9);

			QuaySo qs = new QuaySo();
//#if DEBUG
//			 Tính thời gian cần đến phút thứ 0 của giờ kế tiếp
//			qs.QuaySoID = DateTime.Now.ToString("yyyyMMddHHmm");

//#else
           	qs.ID = DateTime.Now.ToString("yyyyMMddHH");

//#endif

			qs.KetQua = randomNumber;
			qs.ThoiGianQuaySo = DateTime.Now;
			qs.CreateUser = "SYS";
			_Dto dto = new _Dto();
			dto.ThaoTac = "IQS";
			dto.ObjName = QuaySo.objName;
			dto.Obj = qs.ToJSON(qs);
			this.XuLy(dto);
		}
	}
	public static class MathExtensions
	{
		private static readonly Random random = new Random();

		public static int RandBetween(this Random rand, int minValue, int maxValue)
		{
			// Đảm bảo minValue không lớn hơn maxValue
			if (minValue > maxValue)
			{
				int temp = minValue;
				minValue = maxValue;
				maxValue = temp;
			}

			return random.Next(minValue, maxValue + 1);
		}
	}
}