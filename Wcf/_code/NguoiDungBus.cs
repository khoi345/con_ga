using System;
using System.Web.Script.Serialization;
using System.Reflection;
using Dto;
using Dao;
namespace Wcf
{
	public class NguoiDungBus : BusCache
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
				NguoiDung obj = jsonSerialiser.Deserialize<NguoiDung>(data.Obj);
				NguoiDungDao dao = new NguoiDungDao();

				switch (thaoTac)
				{
					case "LNDBDT":
						KeyName = Conection.connStringBuilder.InitialCatalog + "-" + data.ObjName + "-" + data.ThaoTac + "-" + new _Dto().MD5(obj.DienThoai != null ? obj.DienThoai : "");
						break;
					default:
						TaoName(data); break;

				}				
				thaoTac = LayCache(kq, thaoTac);
		
				switch (thaoTac)
				{
					case "NND": kq.result = jsonSerialiser.Serialize(dao.New(obj));
						XoaCacheByID(data);
						break;
					case "IND": kq.result = jsonSerialiser.Serialize(dao.Insert(obj).ToString());
						XoaCacheByID(data);
						break;
					case "DND": kq.result = jsonSerialiser.Serialize(dao.Delete(obj).ToString());
						XoaCacheByID(data);
						break;
					case "UND": kq.result = jsonSerialiser.Serialize(dao.Update(obj).ToString());
						XoaCacheByID(data);
						break;
					case "GBID": kq.result = jsonSerialiser.Serialize(dao.GetOnlyByID(obj.ID.ToString()));
						TaoCacheByID(data);
						break;
					case "LBID": kq.result = jsonSerialiser.Serialize(dao.Get(obj));
						TaoCacheByID(data);
						break;
					case "LNDBDT": kq.result = jsonSerialiser.Serialize(dao.GetByDienThoai(obj));
						IsCache = true;
						break;
					//case "LBIDS": kq.result = jsonSerialiser.Serialize(dao.GetS(obj));          break; 
					//case "LBIDR": kq.result = jsonSerialiser.Serialize(dao.GetR(obj));          break; 
					case "LA":
						jsonSerialiser.MaxJsonLength = Int32.MaxValue;
						kq.result = jsonSerialiser.Serialize(dao.GetAll(obj, boLoc));
						TaoCacheByID(data);
						break;
					case "KTTT": kq.result = jsonSerialiser.Serialize(dao.KiemTraTonTai(obj));        
						break;
					case "KTTTT": kq.result = jsonSerialiser.Serialize(dao.KiemTraTenTonTai(obj));
						TaoCacheByID(data);
						break;	
					case "KTTTSDT": kq.result = jsonSerialiser.Serialize(dao.KiemTraTenTonTaiSoDienThoai(obj));
						TaoCacheByID(data);
						break;
					//	case "KTDSD": kq.result = jsonSerialiser.Serialize(dao.KiemTraDaSuDung(obj));           break;
					default: return kq;
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
		 
	}
}