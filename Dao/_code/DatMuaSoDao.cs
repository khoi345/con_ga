using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Dto;
namespace Dao
{
	public class DatMuaSoDao : _Dao
	{
		public DatMuaSo GetOnlyByID(string DatMuaSoID)
		{
			using (var conn = new SqlConnection(Conection.connStringBuilder.ToString()))
			{
				using (SqlCommand cmd = conn.CreateCommand())
				{
					cmd.CommandText = "SELECT * FROM DatMuaSo  WITH (NOLOCK)  where DatMuaSoID in ('" + DatMuaSoID + "');";
					conn.Open();
					using (SqlDataReader reader = cmd.ExecuteReader())
					{
						while (reader.Read())
						{
							return ReadRow(reader);
						}
					}
				}
			}
			return null;
		}
		public List<DatMuaSo> Get(DatMuaSo p)
		{
			List<DatMuaSo> l = new List<DatMuaSo>();
			using (var conn = new SqlConnection(Conection.connStringBuilder.ToString()))
			{
				using (SqlCommand cmd = conn.CreateCommand())
				{
					cmd.CommandText = "SELECT * FROM DatMuaSo  WITH (NOLOCK) where DatMuaSoID  in('" + p.ID + "');";
					conn.Open();
					using (SqlDataReader reader = cmd.ExecuteReader())
					{
						while (reader.Read())
						{
							l.Add(ReadRow(reader));
						}
					}
				}
			}
			return l;
		}
		public List<DatMuaSo> GetAll(DatMuaSo tmp, BoLoc boLoc = null)
		{
			string bl = this.SQLLoc(boLoc);
			List<DatMuaSo> l = new List<DatMuaSo>();
			using (var conn = new SqlConnection(Conection.connStringBuilder.ToString()))
			{
				using (SqlCommand cmd = conn.CreateCommand())
				{
					cmd.CommandText = "SELECT * FROM DatMuaSo t1  WITH (NOLOCK)  WHERE 1 = 1 " + bl;
					conn.Open();
					using (SqlDataReader reader = cmd.ExecuteReader())
					{
						while (reader.Read())
						{
							l.Add(ReadRow(reader));
						}
					}
				}
			}
			return l;
		}
		public DatMuaSo ReadRow(SqlDataReader reader)
		{
			DatMuaSo tmp = new DatMuaSo();
			CustomeStruct lUtils = new CustomeStruct();
			if (!lUtils.IsNull(reader["DatMuaSoID"]) && lUtils.IsNumeric(reader["DatMuaSoID"])) tmp.ID = lUtils.ToDouble(reader["DatMuaSoID"]);
			if (!lUtils.IsNull(reader["ThoiGianDat"]) && lUtils.IsDate(reader["ThoiGianDat"])) tmp.ThoiGianDat = lUtils.GetDate(reader["ThoiGianDat"]);
			if (!lUtils.IsNull(reader["SlotMoSoID"]) && lUtils.IsNumeric(reader["SlotMoSoID"])) tmp.SlotMoSoID = lUtils.ToDouble(reader["SlotMoSoID"]);
			if (!lUtils.IsNull(reader["SoDuocDat"]) && lUtils.IsNumeric(reader["SoDuocDat"])) tmp.SoDuocDat = lUtils.ToDouble(reader["SoDuocDat"]);
			if (!lUtils.IsNull(reader["UserID"]) && lUtils.IsNumeric(reader["UserID"])) tmp.UserID = lUtils.ToInt64(reader["UserID"]);
			tmp.CreateUser = lUtils.ToStr(reader["CreateUser"]);
			if (!lUtils.IsNull(reader["CreateDate"]) && lUtils.IsDate(reader["CreateDate"])) tmp.CreateDate = lUtils.GetDate(reader["CreateDate"]);
			tmp.EditUser = lUtils.ToStr(reader["EditUser"]);
			if (!lUtils.IsNull(reader["EditDate"]) && lUtils.IsDate(reader["EditDate"])) tmp.EditDate = lUtils.GetDate(reader["EditDate"]);
			return tmp;
		}
		public List<DatMuaSo> GetBySlotMoSoID(DatMuaSo p)
		{
			List<DatMuaSo> l = new List<DatMuaSo>();
			using (var conn = new SqlConnection(Conection.connStringBuilder.ToString()))
			{
				using (SqlCommand cmd = conn.CreateCommand())
				{
					cmd.CommandText = "SELECT * FROM DatMuaSo  WITH (NOLOCK) where SlotMoSoID  in('" + p.SlotMoSoID + "');";
					conn.Open();
					using (SqlDataReader reader = cmd.ExecuteReader())
					{
						while (reader.Read())
						{
							l.Add(ReadRow(reader));
						}
					}
				}
			}
			return l;
		}
		public List<DatMuaSo> GetByUserID(DatMuaSo p)
		{
			List<DatMuaSo> l = new List<DatMuaSo>();
			using (var conn = new SqlConnection(Conection.connStringBuilder.ToString()))
			{
				using (SqlCommand cmd = conn.CreateCommand())
				{
					cmd.CommandText = "SELECT * FROM DatMuaSo  WITH (NOLOCK) where UserID  in('" + p.UserID + "');";
					conn.Open();
					using (SqlDataReader reader = cmd.ExecuteReader())
					{
						while (reader.Read())
						{
							l.Add(ReadRow(reader));
						}
					}
				}
			}
			return l;
		}
		public List<DatMuaSo> GetByUserIDBThoiGianDat(DatMuaSo p)
		{
			List<DatMuaSo> l = new List<DatMuaSo>();
			using (var conn = new SqlConnection(Conection.connStringBuilder.ToString()))
			{
				using (SqlCommand cmd = conn.CreateCommand())
				{
					cmd.CommandText = "SELECT * FROM DatMuaSo  WITH (NOLOCK) where UserID  in('" + p.UserID + "') AND ThoiGianDat between '"+ p.ThoiGianDat.ToString("yyyy-MM-dd HH:00:00:000") + "' AND '" + p.ThoiGianDat.ToString("yyyy-MM-dd HH:59:59:999") + "' ;";
					conn.Open();
					using (SqlDataReader reader = cmd.ExecuteReader())
					{
						while (reader.Read())
						{
							l.Add(ReadRow(reader));
						}
					}
				}
			}
			return l;
		}
		public List<DatMuaSo> GetByUserSlotID(DatMuaSo p)
		{
			List<DatMuaSo> l = new List<DatMuaSo>();
			using (var conn = new SqlConnection(Conection.connStringBuilder.ToString()))
			{
				using (SqlCommand cmd = conn.CreateCommand())
				{
					cmd.CommandText = "SELECT * FROM DatMuaSo  WITH (NOLOCK) where UserID  in('" + p.UserID + "') AND SlotMoSoID in ('" + p.SlotMoSoID.ToString() + "')  ;";
					conn.Open();
					using (SqlDataReader reader = cmd.ExecuteReader())
					{
						while (reader.Read())
						{
							l.Add(ReadRow(reader));
						}
					}
				}
			}
			return l;
		}
		public string Right(string value, int length)
		{
			return value.Substring(value.Length - length);
		}
		public List<DatMuaSo> New(DatMuaSo p)
		{
			//List<DatMuaSo> l = new List<DatMuaSo>();
			//CustomeStruct lUtils = new CustomeStruct();
			//using (var conn = new SqlConnection(Conection.connStringBuilder.ToString()))
			//{
			//	using (SqlCommand cmd = conn.CreateCommand())
			//	{
			//		DatMuaSo tmp = new DatMuaSo();
			//		conn.Open();
			//		cmd.CommandText = "SELECT TOP 1 DatMuaSoID FROM DatMuaSo  WITH (NOLOCK)  ORDER BY DatMuaSoID DESC; )";
			//		using (SqlDataReader reader = cmd.ExecuteReader())
			//		{
			//			string ma = "1000000000";
			//			DatMuaSo tmp = new DatMuaSo();
			//			while (reader.Read())
			//			{
			//				if (reader[0].ToString() != "")
			//				{
			//					ma = reader[0].ToString();
			//				}
			//			}
			//			string so = Right(ma, 10);
			//			Int64 i = lUtils.ToInt64(so);
			//			i++;
			//			so = i.ToString().PadLeft(10, '0');
			//			tmp.KeyID = so;
			//			l.Add(tmp);
			//			return l;
			//		}
			//	}
			//}
			return null;
		}
		public long Insert(DatMuaSo p)
		{
			using (var conn = new SqlConnection(Conection.connStringBuilder.ToString()))
			{
				using (SqlCommand cmd = conn.CreateCommand())
				{
					conn.Open();
					string str = SQLInsert(p).ToString(); ;
					str += "\n DECLARE @InsertedID BIGINT;";
					str += "\n SET @InsertedID = SCOPE_IDENTITY();";
					str += "\n SELECT @InsertedID AS InsertedID;";
					cmd.CommandText = str;

					long insertedID = (long)cmd.ExecuteScalar();

					// Đóng kết nối sau khi thực hiện xong
					conn.Close();

					return insertedID;
				}
			}
		}
		public int Insert2(DatMuaSo p)
		{
			using (var conn = new SqlConnection(Conection.connStringBuilder.ToString()))
			{
				using (SqlCommand cmd = conn.CreateCommand())
				{
					cmd.CommandText = "sp_Insert_DatMuaSo_DatMuaSo";
					cmd.CommandType = CommandType.StoredProcedure;
					cmd.Parameters.Add("@DatMuaSoID", SqlDbType.Int).Value = p.ID;
					cmd.Parameters.Add("@ThoiGianDat", SqlDbType.DateTime).Value = (p.ThoiGianDat != null && p.ThoiGianDat > DateTime.MinValue) ? p.ThoiGianDat.ToString("yyyy-MM-dd HH:mm:ss.fff") : null;
					cmd.Parameters.Add("@SlotMoSoID", SqlDbType.Int).Value = p.SlotMoSoID;
					cmd.Parameters.Add("@SoDuocDat", SqlDbType.Int).Value = p.SoDuocDat;
					cmd.Parameters.Add("@UserID", SqlDbType.BigInt).Value = p.UserID;
					cmd.Parameters.Add("@CreateUser", SqlDbType.VarChar).Value = p.CreateUser;
					cmd.Parameters.Add("@CreateDate", SqlDbType.DateTime).Value = (p.CreateDate != null && p.CreateDate > DateTime.MinValue) ? p.CreateDate.ToString("yyyy-MM-dd HH:mm:ss.fff") : null;
					cmd.Parameters.Add("@EditUser", SqlDbType.VarChar).Value = p.EditUser;
					cmd.Parameters.Add("@EditDate", SqlDbType.DateTime).Value = (p.EditDate != null && p.EditDate > DateTime.MinValue) ? p.EditDate.ToString("yyyy-MM-dd HH:mm:ss.fff") : null;
					conn.Open();
					return cmd.ExecuteNonQuery();
				}
			}
		}
		public StringBuilder SQLInsert(DatMuaSo info)
		{
			CustomeStruct lUtils = new CustomeStruct();
			if (info == null) return new StringBuilder();
			StringBuilder SQL = new StringBuilder();
			SQL.Append(" INSERT INTO DatMuaSo (ThoiGianDat,SlotMoSoID,SoDuocDat,UserID,CreateUser,CreateDate,EditUser,EditDate) ");
			SQL.Append(" VALUES(");
			SQL.Append(((Convert.IsDBNull(info.ThoiGianDat) || !(lUtils.IsDate(info.ThoiGianDat))) ? "Null" : "'" + info.ThoiGianDat.ToString("yyyy-MM-dd HH:mm:ss.fff") + "'") + ",");
			SQL.Append(((Convert.IsDBNull(info.SlotMoSoID) || !(lUtils.IsNumeric(info.SlotMoSoID))) ? "Null" : info.SlotMoSoID) + ",");
			SQL.Append(((Convert.IsDBNull(info.SoDuocDat) || !(lUtils.IsNumeric(info.SoDuocDat))) ? "Null" : info.SoDuocDat) + ",");
			SQL.Append(((Convert.IsDBNull(info.UserID) || !(lUtils.IsNumeric(info.UserID))) ? "Null" : info.UserID) + ",");
			SQL.Append("'" + lUtils.SmoothStr(info.CreateUser) + "',");
			SQL.Append("'" + System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + "',");
			SQL.Append("'" + lUtils.SmoothStr(info.EditUser) + "',");
			SQL.Append(((Convert.IsDBNull(info.EditDate) || !(lUtils.IsDate(info.EditDate))) ? "Null" : "'" + info.EditDate.ToString("yyyy-MM-dd HH:mm:ss.fff") + "'") + "");
			SQL.Append(");\n");
			return SQL;
		}
		public int Insert(List<DatMuaSo> p)
		{
			using (var conn = new SqlConnection(Conection.connStringBuilder.ToString()))
			{
				using (SqlCommand cmd = conn.CreateCommand())
				{
					cmd.CommandText = SQLInsert(p).ToString();
					conn.Open();
					return cmd.ExecuteNonQuery();
				}
			}
		}
		public StringBuilder SQLInsert(List<DatMuaSo> temp)
		{
			CustomeStruct lUtils = new CustomeStruct();
			if (temp == null || temp.Count == 0) return new StringBuilder();
			StringBuilder SQL = new StringBuilder();
			SQL.Append(" INSERT INTO DatMuaSo (ThoiGianDat,SlotMoSoID,SoDuocDat,UserID,CreateUser,CreateDate,EditUser,EditDate) ");
			SQL.Append("\n VALUES\n");
			string phay = ", ";
			for (int i = 0; i < temp.Count; i++)
			{
				if (i == temp.Count - 1)
					phay = "; ";
				DatMuaSo info = new DatMuaSo().Truncate(temp[i]);
				SQL.Append("(");
				SQL.Append(((Convert.IsDBNull(info.ThoiGianDat) || !(lUtils.IsDate(info.ThoiGianDat))) ? "Null" : "'" + info.ThoiGianDat.ToString("yyyy-MM-dd HH:mm:ss.fff") + "'") + ",");
				SQL.Append(((Convert.IsDBNull(info.SlotMoSoID) || !(lUtils.IsNumeric(info.SlotMoSoID))) ? "Null" : info.SlotMoSoID) + ",");
				SQL.Append(((Convert.IsDBNull(info.SoDuocDat) || !(lUtils.IsNumeric(info.SoDuocDat))) ? "Null" : info.SoDuocDat) + ",");
				SQL.Append(((Convert.IsDBNull(info.UserID) || !(lUtils.IsNumeric(info.UserID))) ? "Null" : info.UserID) + ",");
				SQL.Append("'" + lUtils.SmoothStr(info.CreateUser) + "',");
				SQL.Append("'" + System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + "',");
				SQL.Append("'" + lUtils.SmoothStr(info.EditUser) + "',");
				SQL.Append(((Convert.IsDBNull(info.EditDate) || !(lUtils.IsDate(info.EditDate))) ? "Null" : "'" + info.EditDate.ToString("yyyy-MM-dd HH:mm:ss.fff") + "'") + "");
				SQL.Append(")" + phay + "\n");
			}
			return SQL;
		}
		public int Delete(DatMuaSo p)
		{
			using (var conn = new SqlConnection(Conection.connStringBuilder.ToString()))
			{
				using (SqlCommand cmd = conn.CreateCommand())
				{
					conn.Open();
					cmd.CommandText = SQLDelete(p.ID.ToString());
					return cmd.ExecuteNonQuery();
				}
			}
		}
		public string SQLDelete(string DatMuaSoID)
		{
			return "DELETE FROM [DatMuaSo] WHERE [DatMuaSoID] in ('" + DatMuaSoID + "') ; ";
		}
		public string SQLDeleteByDatMuaSoID(string DatMuaSoID)
		{
			return "DELETE FROM [DatMuaSo] WHERE [DatMuaSoID] in ('" + DatMuaSoID + "') ; ";
		}
		public int DeleteBySlotMoSoID(DatMuaSo p)
		{
			using (var conn = new SqlConnection(Conection.connStringBuilder.ToString()))
			{
				using (SqlCommand cmd = conn.CreateCommand())
				{
					conn.Open();
					cmd.CommandText = SQLDeleteBySlotMoSoID(p.SlotMoSoID.ToString());
					return cmd.ExecuteNonQuery();
				}
			}
		}
		public string SQLDeleteBySlotMoSoID(string SlotMoSoID)
		{
			return "DELETE FROM [DatMuaSo] WHERE [SlotMoSoID] in ('" + SlotMoSoID + "') ; ";
		}
		public int DeleteByUserID(DatMuaSo p)
		{
			using (var conn = new SqlConnection(Conection.connStringBuilder.ToString()))
			{
				using (SqlCommand cmd = conn.CreateCommand())
				{
					conn.Open();
					cmd.CommandText = SQLDeleteByUserID(p.UserID.ToString());
					return cmd.ExecuteNonQuery();
				}
			}
		}
		public string SQLDeleteByUserID(string UserID)
		{
			return "DELETE FROM [DatMuaSo] WHERE [UserID] in ('" + UserID + "') ; ";
		}
		public int Update(DatMuaSo p)
		{
			using (var conn = new SqlConnection(Conection.connStringBuilder.ToString()))
			{
				using (SqlCommand cmd = conn.CreateCommand())
				{
					conn.Open();
					cmd.CommandText = SQLUpdate(p);
					return cmd.ExecuteNonQuery();
				}
			}
		}
		public int Update(List<DatMuaSo> p)
		{
			using (var conn = new SqlConnection(Conection.connStringBuilder.ToString()))
			{
				using (SqlCommand cmd = conn.CreateCommand())
				{
					conn.Open();
					cmd.CommandText = SQLUpdate(p);
					return cmd.ExecuteNonQuery();
				}
			}
		}
		public string SQLUpdate(DatMuaSo info)
		{
			if (info == null) return "";
			CustomeStruct lUtils = new CustomeStruct();
			string SQL = " UPDATE DatMuaSo SET ";
			SQL += "[ThoiGianDat] = " + ((Convert.IsDBNull(info.ThoiGianDat) || !(lUtils.IsDate(info.ThoiGianDat))) ? "Null" : "'" + info.ThoiGianDat.ToString("yyyy-MM-dd HH:mm:ss.fff") + "'") + ",";
			SQL += "[SlotMoSoID] = " + ((Convert.IsDBNull(info.SlotMoSoID) || !(lUtils.IsNumeric(info.SlotMoSoID))) ? "Null" : info.SlotMoSoID) + ",";
			SQL += "[SoDuocDat] = " + ((Convert.IsDBNull(info.SoDuocDat) || !(lUtils.IsNumeric(info.SoDuocDat))) ? "Null" : info.SoDuocDat) + ",";
			SQL += "[UserID] = " + ((Convert.IsDBNull(info.UserID) || !(lUtils.IsNumeric(info.UserID))) ? "Null" : info.UserID) + ",";
			SQL += "[CreateUser] = '" + lUtils.SmoothStr(info.CreateUser) + "',";
			SQL += "[CreateDate] = " + ((Convert.IsDBNull(info.CreateDate) || !(lUtils.IsDate(info.CreateDate))) ? "Null" : "'" + info.CreateDate.ToString("yyyy-MM-dd HH:mm:ss.fff") + "'") + ",";
			SQL += "[EditUser] = '" + lUtils.SmoothStr(info.EditUser) + "',";
			SQL += "[EditDate] =  '" + System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + "'";
			SQL += " WHERE [DatMuaSoID] in ('" + info.ID + "');\n ";
			return SQL;
		}
		public string SQLUpdate(List<DatMuaSo> temp)
		{
			string str = "";
			for (int i = 0; i < temp.Count; i++)
			{
				str += SQLUpdate(temp[i]);
			}
			return str;
		}
		private string SQLKiemTraTonTai(DatMuaSo info)
		{
			CustomeStruct lUtils = new CustomeStruct();
			string SQL = "SELECT 1 FROM DatMuaSo  WITH (NOLOCK)  WHERE DatMuaSoID = N'" + lUtils.SmoothStr(info.ID.ToString()) + "';";
			return SQL;
		}
		public int KiemTraTonTai(DatMuaSo p)
		{
			using (var conn = new SqlConnection(Conection.connStringBuilder.ToString()))
			{
				conn.Open();
				using (SqlCommand cmd = conn.CreateCommand())
				{
					cmd.CommandText = SQLKiemTraTonTai(p);
					using (SqlDataReader reader = cmd.ExecuteReader())
					{
						while (reader.Read())
						{
							return 1;
						}
						return 0;
					}
				}
			}
		}
	}
}