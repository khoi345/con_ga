using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Dto;
namespace Dao
{
	public class QuaySoDao : _Dao
	{
		public QuaySo GetOnlyByID(string QuaySoID)
		{
			using (var conn = new SqlConnection(Conection.connStringBuilder.ToString()))
			{
				using (SqlCommand cmd = conn.CreateCommand())
				{
					cmd.CommandText = "SELECT * FROM QuaySo  WITH (NOLOCK)  where QuaySoID in ('" + QuaySoID + "');";
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
		public List<QuaySo> Get(QuaySo p)
		{
			List<QuaySo> l = new List<QuaySo>();
			using (var conn = new SqlConnection(Conection.connStringBuilder.ToString()))
			{
				using (SqlCommand cmd = conn.CreateCommand())
				{
					cmd.CommandText = "SELECT * FROM QuaySo  WITH (NOLOCK) where QuaySoID  in('" + p.ID + "');";
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
		public List<QuaySo> GetAll(QuaySo tmp, BoLoc boLoc = null)
		{
			string bl = this.SQLLoc(boLoc);
			List<QuaySo> l = new List<QuaySo>();
			using (var conn = new SqlConnection(Conection.connStringBuilder.ToString()))
			{
				using (SqlCommand cmd = conn.CreateCommand())
				{
					cmd.CommandText = "SELECT * FROM QuaySo t1  WITH (NOLOCK)  WHERE 1 = 1 " + bl;
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
		public QuaySo ReadRow(SqlDataReader reader)
		{
			QuaySo tmp = new QuaySo();
			CustomeStruct lUtils = new CustomeStruct();
			if (!lUtils.IsNull(reader["QuaySoID"]) && lUtils.IsNumeric(reader["QuaySoID"])) tmp.ID = lUtils.ToDouble(reader["QuaySoID"]);
			if (!lUtils.IsNull(reader["ThoiGianQuaySo"]) && lUtils.IsDate(reader["ThoiGianQuaySo"])) tmp.ThoiGianQuaySo = lUtils.GetDate(reader["ThoiGianQuaySo"]);
			if (!lUtils.IsNull(reader["KetQua"]) && lUtils.IsNumeric(reader["KetQua"])) tmp.KetQua = lUtils.ToDouble(reader["KetQua"]);
			tmp.CreateUser = lUtils.ToStr(reader["CreateUser"]);
			if (!lUtils.IsNull(reader["CreateDate"]) && lUtils.IsDate(reader["CreateDate"])) tmp.CreateDate = lUtils.GetDate(reader["CreateDate"]);
			tmp.EditUser = lUtils.ToStr(reader["EditUser"]);
			if (!lUtils.IsNull(reader["EditDate"]) && lUtils.IsDate(reader["EditDate"])) tmp.EditDate = lUtils.GetDate(reader["EditDate"]);
			return tmp;
		}
		public List<QuaySo> GetByCreateUser(QuaySo p)
		{
			List<QuaySo> l = new List<QuaySo>();
			using (var conn = new SqlConnection(Conection.connStringBuilder.ToString()))
			{
				using (SqlCommand cmd = conn.CreateCommand())
				{
					cmd.CommandText = "SELECT * FROM QuaySo  WITH (NOLOCK) where CreateUser  in('" + p.CreateUser + "');";
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
		public List<QuaySo> GetByEditUser(QuaySo p)
		{
			List<QuaySo> l = new List<QuaySo>();
			using (var conn = new SqlConnection(Conection.connStringBuilder.ToString()))
			{
				using (SqlCommand cmd = conn.CreateCommand())
				{
					cmd.CommandText = "SELECT * FROM QuaySo  WITH (NOLOCK) where EditUser  in('" + p.EditUser + "');";
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
		public List<QuaySo> New(QuaySo p)
		{
			return null;
			//List<QuaySo> l = new List<QuaySo>();
			//CustomeStruct lUtils = new CustomeStruct();
			//using (var conn = new SqlConnection(Conection.connStringBuilder.ToString()))
			//{
			//	using (SqlCommand cmd = conn.CreateCommand())
			//	{
			//		QuaySo tmp = new QuaySo();
			//		conn.Open();
			//		cmd.CommandText = "SELECT TOP 1 QuaySoID FROM QuaySo  WITH (NOLOCK)  ORDER BY QuaySoID DESC; )";
			//		using (SqlDataReader reader = cmd.ExecuteReader())
			//		{
			//			string ma = "1000000000";
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
		}

		public int Insert(QuaySo p)
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
		public int Insert2(QuaySo p)
		{
			using (var conn = new SqlConnection(Conection.connStringBuilder.ToString()))
			{
				using (SqlCommand cmd = conn.CreateCommand())
				{
					cmd.CommandText = "sp_Insert_QuaySo_QuaySo";
					cmd.CommandType = CommandType.StoredProcedure;
					cmd.Parameters.Add("@QuaySoID", SqlDbType.BigInt).Value = p.ID;
					cmd.Parameters.Add("@ThoiGianQuaySo", SqlDbType.DateTime).Value = (p.ThoiGianQuaySo != null && p.ThoiGianQuaySo > DateTime.MinValue) ? p.ThoiGianQuaySo.ToString("yyyy-MM-dd HH:mm:ss.fff") : null;
					cmd.Parameters.Add("@KetQua", SqlDbType.Int).Value = p.KetQua;
					cmd.Parameters.Add("@CreateUser", SqlDbType.VarChar).Value = p.CreateUser;
					cmd.Parameters.Add("@CreateDate", SqlDbType.DateTime).Value = (p.CreateDate != null && p.CreateDate > DateTime.MinValue) ? p.CreateDate.ToString("yyyy-MM-dd HH:mm:ss.fff") : null;
					cmd.Parameters.Add("@EditUser", SqlDbType.VarChar).Value = p.EditUser;
					cmd.Parameters.Add("@EditDate", SqlDbType.DateTime).Value = (p.EditDate != null && p.EditDate > DateTime.MinValue) ? p.EditDate.ToString("yyyy-MM-dd HH:mm:ss.fff") : null;
					conn.Open();
					return cmd.ExecuteNonQuery();
				}
			}
		}
		public StringBuilder SQLInsert(QuaySo info)
		{
			CustomeStruct lUtils = new CustomeStruct();
			if (info == null) return new StringBuilder();
			StringBuilder SQL = new StringBuilder();
			SQL.Append(" INSERT INTO QuaySo (QuaySoID,ThoiGianQuaySo,KetQua,CreateUser,CreateDate,EditUser,EditDate) ");
			SQL.Append(" VALUES(");
			SQL.Append(((Convert.IsDBNull(info.ID) || !(lUtils.IsNumeric(info.ID))) ? "Null" : info.ID) + ",");
			SQL.Append(((Convert.IsDBNull(info.ThoiGianQuaySo) || !(lUtils.IsDate(info.ThoiGianQuaySo))) ? "Null" : "'" + info.ThoiGianQuaySo.ToString("yyyy-MM-dd HH:mm:ss.fff") + "'") + ",");
			SQL.Append(((Convert.IsDBNull(info.KetQua) || !(lUtils.IsNumeric(info.KetQua))) ? "Null" : info.KetQua) + ",");
			SQL.Append("'" + lUtils.SmoothStr(info.CreateUser) + "',");
			SQL.Append("'" + System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + "',");
			SQL.Append("'" + lUtils.SmoothStr(info.EditUser) + "',");
			SQL.Append(((Convert.IsDBNull(info.EditDate) || !(lUtils.IsDate(info.EditDate))) ? "Null" : "'" + info.EditDate.ToString("yyyy-MM-dd HH:mm:ss.fff") + "'") + "");
			SQL.Append(");\n");
			return SQL;
		}
		public int Insert(List<QuaySo> p)
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
		public StringBuilder SQLInsert(List<QuaySo> temp)
		{
			CustomeStruct lUtils = new CustomeStruct();
			if (temp == null || temp.Count == 0) return new StringBuilder();
			StringBuilder SQL = new StringBuilder();
			SQL.Append(" INSERT INTO QuaySo (QuaySoID,ThoiGianQuaySo,KetQua,CreateUser,CreateDate,EditUser,EditDate) ");
			SQL.Append("\n VALUES\n");
			string phay = ", ";
			for (int i = 0; i < temp.Count; i++)
			{
				if (i == temp.Count - 1)
					phay = "; ";
				QuaySo info = new QuaySo().Truncate(temp[i]);
				SQL.Append("(");
				SQL.Append(((Convert.IsDBNull(info.ID) || !(lUtils.IsNumeric(info.ID))) ? "Null" : info.ID) + ",");
				SQL.Append(((Convert.IsDBNull(info.ThoiGianQuaySo) || !(lUtils.IsDate(info.ThoiGianQuaySo))) ? "Null" : "'" + info.ThoiGianQuaySo.ToString("yyyy-MM-dd HH:mm:ss.fff") + "'") + ",");
				SQL.Append(((Convert.IsDBNull(info.KetQua) || !(lUtils.IsNumeric(info.KetQua))) ? "Null" : info.KetQua) + ",");
				SQL.Append("'" + lUtils.SmoothStr(info.CreateUser) + "',");
				SQL.Append("'" + System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + "',");
				SQL.Append("'" + lUtils.SmoothStr(info.EditUser) + "',");
				SQL.Append(((Convert.IsDBNull(info.EditDate) || !(lUtils.IsDate(info.EditDate))) ? "Null" : "'" + info.EditDate.ToString("yyyy-MM-dd HH:mm:ss.fff") + "'") + "");
				SQL.Append(")" + phay + "\n");
			}
			return SQL;
		}
		public int Delete(QuaySo p)
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
		public string SQLDelete(string QuaySoID)
		{
			return "DELETE FROM [QuaySo] WHERE [QuaySoID] in ('" + QuaySoID + "') ; ";
		}
		public string SQLDeleteByQuaySoID(string QuaySoID)
		{
			return "DELETE FROM [QuaySo] WHERE [QuaySoID] in ('" + QuaySoID + "') ; ";
		}
		public int DeleteByCreateUser(QuaySo p)
		{
			using (var conn = new SqlConnection(Conection.connStringBuilder.ToString()))
			{
				using (SqlCommand cmd = conn.CreateCommand())
				{
					conn.Open();
					cmd.CommandText = SQLDeleteByCreateUser(p.CreateUser);
					return cmd.ExecuteNonQuery();
				}
			}
		}
		public string SQLDeleteByCreateUser(string CreateUser)
		{
			return "DELETE FROM [QuaySo] WHERE [CreateUser] in ('" + CreateUser + "') ; ";
		}
		public int DeleteByEditUser(QuaySo p)
		{
			using (var conn = new SqlConnection(Conection.connStringBuilder.ToString()))
			{
				using (SqlCommand cmd = conn.CreateCommand())
				{
					conn.Open();
					cmd.CommandText = SQLDeleteByEditUser(p.EditUser);
					return cmd.ExecuteNonQuery();
				}
			}
		}
		public string SQLDeleteByEditUser(string EditUser)
		{
			return "DELETE FROM [QuaySo] WHERE [EditUser] in ('" + EditUser + "') ; ";
		}
		public int Update(QuaySo p)
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
		public int Update(List<QuaySo> p)
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
		public string SQLUpdate(QuaySo info)
		{
			if (info == null) return "";
			CustomeStruct lUtils = new CustomeStruct();
			string SQL = " UPDATE QuaySo SET ";
			SQL += "[ThoiGianQuaySo] = " + ((Convert.IsDBNull(info.ThoiGianQuaySo) || !(lUtils.IsDate(info.ThoiGianQuaySo))) ? "Null" : "'" + info.ThoiGianQuaySo.ToString("yyyy-MM-dd HH:mm:ss.fff") + "'") + ",";
			SQL += "[KetQua] = " + ((Convert.IsDBNull(info.KetQua) || !(lUtils.IsNumeric(info.KetQua))) ? "Null" : info.KetQua) + ",";
			SQL += "[CreateUser] = '" + lUtils.SmoothStr(info.CreateUser) + "',";
			SQL += "[CreateDate] = " + ((Convert.IsDBNull(info.CreateDate) || !(lUtils.IsDate(info.CreateDate))) ? "Null" : "'" + info.CreateDate.ToString("yyyy-MM-dd HH:mm:ss.fff") + "'") + ",";
			SQL += "[EditUser] = '" + lUtils.SmoothStr(info.EditUser) + "',";
			SQL += "[EditDate] =  '" + System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + "'";
			SQL += " WHERE [QuaySoID] in ('" + info.ID + "');\n ";
			return SQL;
		}
		public string SQLUpdate(List<QuaySo> temp)
		{
			string str = "";
			for (int i = 0; i < temp.Count; i++)
			{
				str += SQLUpdate(temp[i]);
			}
			return str;
		}
		private string SQLKiemTraTonTai(QuaySo info)
		{
			CustomeStruct lUtils = new CustomeStruct();
			string SQL = "SELECT 1 FROM QuaySo  WITH (NOLOCK)  WHERE QuaySoID = N'" + lUtils.SmoothStr(info.ID.ToString()) + "';";
			return SQL;
		}
		public int KiemTraTonTai(QuaySo p)
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