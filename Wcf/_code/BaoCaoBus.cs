using System;
using System.Web.Script.Serialization;
using System.Reflection;
using Dto;
using Dao;
using RedisBus;
using RedisBoost;

namespace Wcf
{
	public class BaoCaoBus
	{
		public static bool IsCache = true;
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

				BaoCao obj = jsonSerialiser.Deserialize<BaoCao>(data.Obj);
				BaoCaoDao dao = new BaoCaoDao();
				/// cache
				BaoCaoRedis testClient;
				RedisConnectionStringBuilder _cs = new RedisConnectionStringBuilder(Conection._SERVER_REDIS);
				data.ThaoTac = thaoTac;
				string KeyName = Conection.connStringBuilder.InitialCatalog + "-"+new _Dto().MD5(obj.ToString());
				if (IsCache)
				{
					try
					{
						testClient = new BaoCaoRedis();

						testClient.Connect(_cs);
						kq.result = testClient.GetString(KeyName);
						if (kq.result != null && kq.result.Trim() != "" && kq.result.Length > 10)
						{
							thaoTac = "";
						}
						testClient.Dispose();

					}
					catch
					{
						IsCache = false;
					}
					
				}
				/// end cache
				switch (thaoTac)
				{
					case "LKQSBUI": kq.result = jsonSerialiser.Serialize(dao.LoadKetQuaSoByUserID(obj));
						break;
					case "LQSTT": kq.result = jsonSerialiser.Serialize( this.LuotQuaySoTiepTheo());
						break;
					 
					default: return kq;
				}
				if (IsCache)
				{
					using (testClient = new BaoCaoRedis())
					{
						testClient.Connect(_cs);
						testClient.Set(KeyName, kq.result,15);
					}
				}
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
		public string LuotQuaySoTiepTheo()
		{
			HourlyService v = new HourlyService();
			return v.DoHourlyTask();
		}


	}
}