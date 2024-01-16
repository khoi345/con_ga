using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Dto;
namespace Dao
{
	public class NguoiDungDao : _Dao
	{
		public NguoiDung GetOnlyByID(string UserID)
		{
			using (var conn = new SqlConnection(Conection.connStringBuilder.ToString()))
			{
				using (SqlCommand cmd = conn.CreateCommand())
				{
					cmd.CommandText = "SELECT * FROM NguoiDung  WITH (NOLOCK)  where UserID in ('" + UserID + "');";
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
		public List<NguoiDung> Get(NguoiDung p)
		{
			List<NguoiDung> l = new List<NguoiDung>();
			using (var conn = new SqlConnection(Conection.connStringBuilder.ToString()))
			{
				using (SqlCommand cmd = conn.CreateCommand())
				{
					cmd.CommandText = "SELECT * FROM NguoiDung  WITH (NOLOCK) where UserID  in('" + p.ID + "');";
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
		public List<NguoiDung> GetAll(NguoiDung tmp, BoLoc boLoc = null)
		{
			string bl = this.SQLLoc(boLoc);
			List<NguoiDung> l = new List<NguoiDung>();
			using (var conn = new SqlConnection(Conection.connStringBuilder.ToString()))
			{
				using (SqlCommand cmd = conn.CreateCommand())
				{
					cmd.CommandText = "SELECT * FROM NguoiDung t1  WITH (NOLOCK)  WHERE 1 = 1 " + bl;
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
		public NguoiDung ReadRow(SqlDataReader reader)
		{
			NguoiDung tmp = new NguoiDung();
			CustomeStruct lUtils = new CustomeStruct();
			if (!lUtils.IsNull(reader["UserID"]) && lUtils.IsNumeric(reader["UserID"])) tmp.ID = lUtils.ToInt64(reader["UserID"]);
			tmp.DienThoai = lUtils.ToStr(reader["DienThoai"]);
			if (!lUtils.IsNull(reader["NgaySinh"]) && lUtils.IsDate(reader["NgaySinh"])) tmp.NgaySinh = lUtils.GetDate(reader["NgaySinh"]);
			tmp.HoTen = lUtils.ToStr(reader["HoTen"]);
			tmp.CreateUser = lUtils.ToStr(reader["CreateUser"]);
			if (!lUtils.IsNull(reader["CreateDate"]) && lUtils.IsDate(reader["CreateDate"])) tmp.CreateDate = lUtils.GetDate(reader["CreateDate"]);
			tmp.EditUser = lUtils.ToStr(reader["EditUser"]);
			if (!lUtils.IsNull(reader["EditDate"]) && lUtils.IsDate(reader["EditDate"])) tmp.EditDate = lUtils.GetDate(reader["EditDate"]);
			return tmp;
		}
		public List<NguoiDung> GetByDienThoai(NguoiDung p)
		{
			List<NguoiDung> l = new List<NguoiDung>();
			using (var conn = new SqlConnection(Conection.connStringBuilder.ToString()))
			{
				using (SqlCommand cmd = conn.CreateCommand())
				{
					cmd.CommandText = "SELECT * FROM NguoiDung  WITH (NOLOCK) where DienThoai  in('" + p.DienThoai + "');";
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
		public List<NguoiDung> GetByInsert(NguoiDung p)
		{
			List<NguoiDung> l = new List<NguoiDung>();
			using (var conn = new SqlConnection(Conection.connStringBuilder.ToString()))
			{
				using (SqlCommand cmd = conn.CreateCommand())
				{
					cmd.CommandText = SQLRowInsert(p).ToString();
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
		public long GetByInsertID(NguoiDung p)
		{
			using (var conn = new SqlConnection(Conection.connStringBuilder.ToString()))
			{
				using (SqlCommand cmd = conn.CreateCommand())
				{
					cmd.CommandText = SQLIDInsert(p).ToString();
					conn.Open();
					using (SqlDataReader reader = cmd.ExecuteReader())
					{
						while (reader.Read())
						{
							if (!lUtils.IsNull(reader["UserID"]) && lUtils.IsNumeric(reader["UserID"])) return lUtils.ToInt64(reader["UserID"]);
						}
					}
				}
			}
			return -1;
		}
		public string Right(string value, int length)
		{
			return value.Substring(value.Length - length);
		}
		public List<NguoiDung> New(NguoiDung p)
		{
			//List<NguoiDung> l = new List<NguoiDung>();
			//CustomeStruct lUtils = new CustomeStruct();
			//using (var conn = new SqlConnection(Conection.connStringBuilder.ToString()))
			//{
			//	using (SqlCommand cmd = conn.CreateCommand())
			//	{
			//		NguoiDung tmp = new NguoiDung();
			//		conn.Open();
			//		cmd.CommandText = "SELECT TOP 1 UserID FROM NguoiDung  WITH (NOLOCK)  ORDER BY UserID DESC; )";
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
			return null;
		}
		public long Insert(NguoiDung p)
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

		public int Insert2(NguoiDung p)
		{
			using (var conn = new SqlConnection(Conection.connStringBuilder.ToString()))
			{
				using (SqlCommand cmd = conn.CreateCommand())
				{
					cmd.CommandText = "sp_Insert_NguoiDung_NguoiDung";
					cmd.CommandType = CommandType.StoredProcedure;
					cmd.Parameters.Add("@UserID", SqlDbType.BigInt).Value = p.ID;
					cmd.Parameters.Add("@DienThoai", SqlDbType.VarChar).Value = p.DienThoai;
					cmd.Parameters.Add("@NgaySinh", SqlDbType.DateTime).Value = (p.NgaySinh != null && p.NgaySinh > DateTime.MinValue) ? p.NgaySinh.ToString("yyyy-MM-dd HH:mm:ss.fff") : null;
					cmd.Parameters.Add("@HoTen", SqlDbType.NVarChar).Value = p.HoTen;
					cmd.Parameters.Add("@CreateUser", SqlDbType.VarChar).Value = p.CreateUser;
					cmd.Parameters.Add("@CreateDate", SqlDbType.DateTime).Value = (p.CreateDate != null && p.CreateDate > DateTime.MinValue) ? p.CreateDate.ToString("yyyy-MM-dd HH:mm:ss.fff") : null;
					cmd.Parameters.Add("@EditUser", SqlDbType.VarChar).Value = p.EditUser;
					cmd.Parameters.Add("@EditDate", SqlDbType.DateTime).Value = (p.EditDate != null && p.EditDate > DateTime.MinValue) ? p.EditDate.ToString("yyyy-MM-dd HH:mm:ss.fff") : null;
					conn.Open();
					return cmd.ExecuteNonQuery();
				}
			}
		}
		public StringBuilder SQLInsert(NguoiDung info)
		{
			CustomeStruct lUtils = new CustomeStruct();
			if (info == null) return new StringBuilder();
			StringBuilder SQL = new StringBuilder();
			SQL.Append(" INSERT INTO NguoiDung (DienThoai,NgaySinh,HoTen,CreateUser,CreateDate,EditUser,EditDate) ");
			SQL.Append(" VALUES(");
			SQL.Append("'" + lUtils.SmoothStr(info.DienThoai) + "',");
			SQL.Append(((Convert.IsDBNull(info.NgaySinh) || !(lUtils.IsDate(info.NgaySinh))) ? "Null" : "'" + info.NgaySinh.ToString("yyyy-MM-dd HH:mm:ss.fff") + "'") + ",");
			SQL.Append("N'" + lUtils.SmoothStr(info.HoTen) + "',");
			SQL.Append("'" + lUtils.SmoothStr(info.CreateUser) + "',");
			SQL.Append("'" + System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + "',");
			SQL.Append("'" + lUtils.SmoothStr(info.EditUser) + "',");
			SQL.Append(((Convert.IsDBNull(info.EditDate) || !(lUtils.IsDate(info.EditDate))) ? "Null" : "'" + info.EditDate.ToString("yyyy-MM-dd HH:mm:ss.fff") + "'") + "");
			SQL.Append(");\n");
			return SQL;
		}
		public int Insert(List<NguoiDung> p)
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
		public StringBuilder SQLInsert(List<NguoiDung> temp)
		{
			CustomeStruct lUtils = new CustomeStruct();
			if (temp == null || temp.Count == 0) return new StringBuilder();
			StringBuilder SQL = new StringBuilder();
			SQL.Append(" INSERT INTO NguoiDung (DienThoai,NgaySinh,HoTen,CreateUser,CreateDate,EditUser,EditDate) ");
			SQL.Append("\n VALUES\n");
			string phay = ", ";
			for (int i = 0; i < temp.Count; i++)
			{
				if (i == temp.Count - 1)
					phay = "; ";
				NguoiDung info = new NguoiDung().Truncate(temp[i]);
				SQL.Append("(");
				SQL.Append("'" + lUtils.SmoothStr(info.DienThoai) + "',");
				SQL.Append(((Convert.IsDBNull(info.NgaySinh) || !(lUtils.IsDate(info.NgaySinh))) ? "Null" : "'" + info.NgaySinh.ToString("yyyy-MM-dd HH:mm:ss.fff") + "'") + ",");
				SQL.Append("N'" + lUtils.SmoothStr(info.HoTen) + "',");
				SQL.Append("'" + lUtils.SmoothStr(info.CreateUser) + "',");
				SQL.Append("'" + System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + "',");
				SQL.Append("'" + lUtils.SmoothStr(info.EditUser) + "',");
				SQL.Append(((Convert.IsDBNull(info.EditDate) || !(lUtils.IsDate(info.EditDate))) ? "Null" : "'" + info.EditDate.ToString("yyyy-MM-dd HH:mm:ss.fff") + "'") + "");
				SQL.Append(")" + phay + "\n");
			}
			return SQL;
		}
		public StringBuilder SQLRowInsert(NguoiDung info)
		{
			CustomeStruct lUtils = new CustomeStruct();
			if (info == null) return new StringBuilder();
			StringBuilder SQL = new StringBuilder();
			SQL.Append(" INSERT INTO NguoiDung (DienThoai,NgaySinh,HoTen,CreateUser,CreateDate,EditUser,EditDate) ");
			SQL.Append("output inserted.* ");
			SQL.Append(" VALUES(");
			SQL.Append("'" + lUtils.SmoothStr(info.DienThoai) + "',");
			SQL.Append(((Convert.IsDBNull(info.NgaySinh) || !(lUtils.IsDate(info.NgaySinh))) ? "Null" : "'" + info.NgaySinh.ToString("yyyy-MM-dd HH:mm:ss.fff") + "'") + ",");
			SQL.Append("N'" + lUtils.SmoothStr(info.HoTen) + "',");
			SQL.Append("'" + lUtils.SmoothStr(info.CreateUser) + "',");
			SQL.Append("'" + System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + "',");
			SQL.Append("'" + lUtils.SmoothStr(info.EditUser) + "',");
			SQL.Append(((Convert.IsDBNull(info.EditDate) || !(lUtils.IsDate(info.EditDate))) ? "Null" : "'" + info.EditDate.ToString("yyyy-MM-dd HH:mm:ss.fff") + "'") + "");
			SQL.Append(");\n");
			return SQL;
		}
		public StringBuilder SQLIDInsert(NguoiDung info)
		{
			CustomeStruct lUtils = new CustomeStruct();
			if (info == null) return new StringBuilder();
			StringBuilder SQL = new StringBuilder();
			SQL.Append(" INSERT INTO NguoiDung (DienThoai,NgaySinh,HoTen,CreateUser,CreateDate,EditUser,EditDate) ");
			SQL.Append(" output inserted.UserID ");
			SQL.Append(" VALUES(");
			SQL.Append("'" + lUtils.SmoothStr(info.DienThoai) + "',");
			SQL.Append(((Convert.IsDBNull(info.NgaySinh) || !(lUtils.IsDate(info.NgaySinh))) ? "Null" : "'" + info.NgaySinh.ToString("yyyy-MM-dd HH:mm:ss.fff") + "'") + ",");
			SQL.Append("N'" + lUtils.SmoothStr(info.HoTen) + "',");
			SQL.Append("'" + lUtils.SmoothStr(info.CreateUser) + "',");
			SQL.Append("'" + System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + "',");
			SQL.Append("'" + lUtils.SmoothStr(info.EditUser) + "',");
			SQL.Append(((Convert.IsDBNull(info.EditDate) || !(lUtils.IsDate(info.EditDate))) ? "Null" : "'" + info.EditDate.ToString("yyyy-MM-dd HH:mm:ss.fff") + "'") + "");
			SQL.Append(");\n");
			return SQL;
		}
		public int Delete(NguoiDung p)
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
		public string SQLDelete(string UserID)
		{
			return "DELETE FROM [NguoiDung] WHERE [UserID] in ('" + UserID + "') ; ";
		}
		public string SQLDeleteByUserID(string UserID)
		{
			return "DELETE FROM [NguoiDung] WHERE [UserID] in ('" + UserID + "') ; ";
		}
		public int DeleteByDienThoai(NguoiDung p)
		{
			using (var conn = new SqlConnection(Conection.connStringBuilder.ToString()))
			{
				using (SqlCommand cmd = conn.CreateCommand())
				{
					conn.Open();
					cmd.CommandText = SQLDeleteByDienThoai(p.DienThoai);
					return cmd.ExecuteNonQuery();
				}
			}
		}
		public string SQLDeleteByDienThoai(string DienThoai)
		{
			return "DELETE FROM [NguoiDung] WHERE [DienThoai] in ('" + DienThoai + "') ; ";
		}
		public int Update(NguoiDung p)
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
		public int Update(List<NguoiDung> p)
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
		public string SQLUpdate(NguoiDung info)
		{
			if (info == null) return "";
			CustomeStruct lUtils = new CustomeStruct();
			string SQL = " UPDATE NguoiDung SET ";
			SQL += "[DienThoai] = '" + lUtils.SmoothStr(info.DienThoai) + "',";
			SQL += "[NgaySinh] = " + ((Convert.IsDBNull(info.NgaySinh) || !(lUtils.IsDate(info.NgaySinh))) ? "Null" : "'" + info.NgaySinh.ToString("yyyy-MM-dd HH:mm:ss.fff") + "'") + ",";
			SQL += "[HoTen] = N'" + lUtils.SmoothStr(info.HoTen) + "',";
			SQL += "[CreateUser] = '" + lUtils.SmoothStr(info.CreateUser) + "',";
			SQL += "[CreateDate] = " + ((Convert.IsDBNull(info.CreateDate) || !(lUtils.IsDate(info.CreateDate))) ? "Null" : "'" + info.CreateDate.ToString("yyyy-MM-dd HH:mm:ss.fff") + "'") + ",";
			SQL += "[EditUser] = '" + lUtils.SmoothStr(info.EditUser) + "',";
			SQL += "[EditDate] =  '" + System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + "'";
			SQL += " WHERE [UserID] in ('" + info.ID + "');\n ";
			return SQL;
		}
		public string SQLUpdate(List<NguoiDung> temp)
		{
			string str = "";
			for (int i = 0; i < temp.Count; i++)
			{
				str += SQLUpdate(temp[i]);
			}
			return str;
		}
		private string SQLKiemTraTonTai(NguoiDung info)
		{
			CustomeStruct lUtils = new CustomeStruct();
			string SQL = "SELECT 1 FROM NguoiDung  WITH (NOLOCK)  WHERE UserID = N'" + lUtils.SmoothStr(info.ID.ToString()) + "';";
			return SQL;
		}
		public int KiemTraTonTai(NguoiDung p)
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
		private string SQLKiemTraTenTonTai(NguoiDung info)
		{
			string SQL = "SELECT 1 FROM NguoiDung  WITH (NOLOCK)  WHERE DienThoai in( N'" + lUtils.SmoothStr(info.DienThoai.ToString()) + "')  AND UserID <> '" + info.ID + "';";
			return SQL;
		}
		public int KiemTraTenTonTai(NguoiDung p)
		{
			using (var conn = new SqlConnection(Conection.connStringBuilder.ToString()))
			{
				conn.Open();
				using (SqlCommand cmd = conn.CreateCommand())
				{
					cmd.CommandText = SQLKiemTraTenTonTai(p);
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
		private string SQLKiemTraTenTonTaiSoDienThoai(NguoiDung info)
		{
			string SQL = "SELECT 1 FROM NguoiDung  WITH (NOLOCK)  WHERE DienThoai in( N'" + lUtils.SmoothStr(info.DienThoai.ToString()) + "')  AND UserID <> '" + info.ID + "';";
			return SQL;
		}
		public int KiemTraTenTonTaiSoDienThoai(NguoiDung p)
		{
			using (var conn = new SqlConnection(Conection.connStringBuilder.ToString()))
			{
				conn.Open();
				using (SqlCommand cmd = conn.CreateCommand())
				{
					cmd.CommandText = SQLKiemTraTenTonTaiSoDienThoai(p);
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