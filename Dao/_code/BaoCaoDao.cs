using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dto;
namespace Dao
{
	public class BaoCaoDao
	{
		public List<BaoCaoKetQua> LoadKetQuaSoByUserID(BaoCao p)
		{
			List<BaoCaoKetQua> l = new List<BaoCaoKetQua>();
			StringBuilder sql = new StringBuilder();
			sql = sql.Append("\n ");
			sql = sql.Append("\n select  SlotMoSoID,ThoiGianDat,  SoDuocDat, KetQua ");
			sql = sql.Append("\n from [DatMuaSo] t1 left join QuaySo t2 on t1.SlotMoSoID = t2.QuaySoID ");
			sql = sql.Append("\n where t1.UserID in('" + p.UserID + "');");
			sql = sql.Append("\n ");

			using (var conn = new SqlConnection(Conection.connStringBuilder.ToString()))
			{
				using (SqlCommand cmd = conn.CreateCommand())
				{
					cmd.CommandText = sql.ToString();
					conn.Open();
					using (SqlDataReader reader = cmd.ExecuteReader())
					{
						while (reader.Read())
						{
							l.Add(ReadRowBaoCaoKetQua(reader));
						}
					}
				}
			}
			return l;
		}
		public BaoCaoKetQua ReadRowBaoCaoKetQua(SqlDataReader reader)
		{
			BaoCaoKetQua tmp = new BaoCaoKetQua();
			CustomeStruct lUtils = new CustomeStruct();
			tmp.SlotMoSoID = reader["SlotMoSoID"].ToString();
			if (!lUtils.IsNull(reader["ThoiGianDat"]) && lUtils.IsDate(reader["ThoiGianDat"])) tmp.ThoiGianDat = lUtils.GetDate(reader["ThoiGianDat"]);
			if (!lUtils.IsNull(reader["SoDuocDat"]) && lUtils.IsNumeric(reader["SoDuocDat"])) tmp.SoDuocDat = lUtils.ToInt32(reader["SoDuocDat"]);

			if (long.Parse(tmp.SlotMoSoID) <= long.Parse(DateTime.Now.ToString("yyyyMMddHH")))
			{
				if (!lUtils.IsNull(reader["KetQua"]) && lUtils.IsNumeric(reader["KetQua"]))
				{
					int kq = lUtils.ToInt32(reader["KetQua"]);
					if (kq == tmp.SoDuocDat)
						tmp.KetQua = "WIN";
					else
						tmp.KetQua = "LOSE";
				}
				else tmp.KetQua = "LOSE";
			}
			else
			{
				tmp.KetQua = "";
			}
			return tmp;
		}
	}
}
