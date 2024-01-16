using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Dto;
namespace Dao
{
    public class GhiLogCSDLDao : _Dao
    {
        public List<GhiLogCSDL> Get(GhiLogCSDL p)
        {
            List<GhiLogCSDL> l = new List<GhiLogCSDL>();
            using (var conn = new SqlConnection(Conection.connStringBuilder2.ToString()))
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "SELECT * FROM S777 where Id =  '" + p.Id + "';";
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
        public List<GhiLogCSDL> GetAll(GhiLogCSDL tmp, BoLoc boLoc = null)
        {
            string bl = this.SQLLoc(boLoc);
            List<GhiLogCSDL> l = new List<GhiLogCSDL>();
            using (var conn = new SqlConnection(Conection.connStringBuilder2.ToString()))
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "SELECT * FROM S777 t1 WHERE 1 = 1 " + bl;
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
        public GhiLogCSDL ReadRow(SqlDataReader reader)
        {
            GhiLogCSDL tmp = new GhiLogCSDL();
            CustomeStruct lUtils = new CustomeStruct();
            if (!lUtils.IsNull(reader["Id"]) && lUtils.IsNumeric(reader["Id"])) tmp.Id = lUtils.ToDouble(reader["Id"]);
            tmp.Ver = lUtils.ToStr(reader["Ver"]);
            tmp.Url = lUtils.ToStr(reader["Url"]);
            tmp.ThaoTac = lUtils.ToStr(reader["ThaoTac"]);
            tmp.Obj = lUtils.ToStr(reader["Obj"]);
            tmp.ThongTin = lUtils.ToStr(reader["ThongTin"]);
            tmp.CreateUser = lUtils.ToStr(reader["CreateUser"]);
            if (!lUtils.IsNull(reader["CreateDate"]) && lUtils.IsDate(reader["CreateDate"])) tmp.CreateDate = lUtils.GetDate(reader["CreateDate"]);
            return tmp;
        }
        public string Right(string value, int length)
        {
            return value.Substring(value.Length - length);
        }
        public long Insert(GhiLogCSDL p)
        {
            using (var conn = new SqlConnection(Conection.connStringBuilder2.ToString()))
            {
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    conn.Open();
                    string str = SQLInsert(p).ToString(); ;
                    str += "\n DECLARE @InsertedID BIGINT;";
                    str += "\n SET @InsertedID = SCOPE_IDENTITY();";
                    str += "\n SELECT @InsertedID AS InsertedID;";
                    cmd.CommandText = str;

                    // Thêm tham số và kiểu trả về cho Stored Procedure (nếu có)
                    // cmd.CommandType = CommandType.StoredProcedure;

                    // Thêm các tham số vào cmd.Parameters (nếu có)
                    // cmd.Parameters.AddWithValue("@ParamName", paramValue);

                    long insertedID = (long)cmd.ExecuteScalar();

                    // Đóng kết nối sau khi thực hiện xong
                    conn.Close();

                    return insertedID;
                }
            }
        }

        // có thay đổi


        public StringBuilder SQLInsert(GhiLogCSDL info)
        {
            CustomeStruct lUtils = new CustomeStruct();
            if (info == null) return new StringBuilder();
            StringBuilder SQL = new StringBuilder();
            SQL.Append(" INSERT INTO S777 (Ver,Url,ThaoTac,Obj,ThongTin,CreateUser,CreateDate) ");
            SQL.Append(" VALUES(");
            SQL.Append("'" + lUtils.SmoothStr(info.Ver) + "',");
            SQL.Append("N'" + lUtils.SmoothStr(info.Url) + "',");
            SQL.Append("N'" + lUtils.SmoothStr(info.ThaoTac) + "',");
            SQL.Append("N'" + lUtils.SmoothStr(info.Obj) + "',");
            SQL.Append("N'" + lUtils.SmoothStr(info.ThongTin) + "',");
            SQL.Append("'" + lUtils.SmoothStr(info.CreateUser) + "',");
            SQL.Append("'" + System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + "'");
            SQL.Append(");\n");
            return SQL;
        }

        public int Insert(List<GhiLogCSDL> p)
        {
            using (var conn = new SqlConnection(Conection.connStringBuilder2.ToString()))
            {
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    conn.Open();
                    cmd.CommandText = SQLInsert(p);
                    return cmd.ExecuteNonQuery();
                }
            }
        }
        public string SQLInsert(List<GhiLogCSDL> temp)
        {
            string str = "";
            for (int i = 0; i < temp.Count; i++)
            {
                str += SQLInsert(temp[i]);
            }
            return str;
        }
        public string SQLDelete(string Id)
        {
            return "DELETE FROM [S777] WHERE [Id] = '" + Id + "' ; ";
        }
        public int Delete(GhiLogCSDL p)
        {
            using (var conn = new SqlConnection(Conection.connStringBuilder2.ToString()))
            {
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    conn.Open();
                    cmd.CommandText = SQLDelete(p.Id.ToString());
                    return cmd.ExecuteNonQuery();
                }
            }
        }
        public int Update(GhiLogCSDL p)
        {
            using (var conn = new SqlConnection(Conection.connStringBuilder2.ToString()))
            {
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    conn.Open();
                    cmd.CommandText = SQLUpdate(p);
                    return cmd.ExecuteNonQuery();
                }
            }
        }
        public int Update(List<GhiLogCSDL> p)
        {
            using (var conn = new SqlConnection(Conection.connStringBuilder2.ToString()))
            {
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    conn.Open();
                    cmd.CommandText = SQLUpdate(p);
                    return cmd.ExecuteNonQuery();
                }
            }
        }

        public string SQLUpdate(GhiLogCSDL info)
        {
            if (info == null) return "";
            CustomeStruct lUtils = new CustomeStruct();
            string SQL = " UPDATE S777 SET ";
            SQL += "[Id] = " + ((Convert.IsDBNull(info.Id) || !(lUtils.IsNumeric(info.Id))) ? "Null" : info.Id) + ",";
            SQL += "[Ver] = '" + lUtils.SmoothStr(info.Ver) + "',";
            SQL += "[Url] = N'" + lUtils.SmoothStr(info.Url) + "',";
            SQL += "[ThaoTac] = N'" + lUtils.SmoothStr(info.ThaoTac) + "',";
            SQL += "[Obj] = N'" + lUtils.SmoothStr(info.Obj) + "',";
            SQL += "[ThongTin] = N'" + lUtils.SmoothStr(info.ThongTin) + "',";
            SQL += "[CreateUser] = '" + lUtils.SmoothStr(info.CreateUser) + "',";
            SQL += "[CreateDate] = " + ((Convert.IsDBNull(info.CreateDate) || !(lUtils.IsDate(info.CreateDate))) ? "Null" : "'" + info.CreateDate.ToString("yyyy-MM-dd HH:mm:ss.fff") + "'") + "";
            SQL += " WHERE [Id] = '" + info.Id.ToString() + "';\n ";
            return SQL;
        }
        public string SQLUpdate(List<GhiLogCSDL> temp)
        {
            string str = "";
            for (int i = 0; i < temp.Count; i++)
            {
                str += SQLUpdate(temp[i]);
            }
            return str;
        }
        private string SQLKiemTraTonTai(GhiLogCSDL info)
        {
            CustomeStruct lUtils = new CustomeStruct();
            string SQL = "SELECT 1 FROM S777 WHERE Id = N'" + lUtils.SmoothStr(info.Id.ToString()) + "';";
            return SQL;
        }
        public int KiemTraTonTai(GhiLogCSDL p)
        {
            using (var conn = new SqlConnection(Conection.connStringBuilder2.ToString()))
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
        public StringBuilder SQLRowInsert(GhiLogCSDL info)
        {
            CustomeStruct lUtils = new CustomeStruct();
            if (info == null) return new StringBuilder();
            StringBuilder SQL = new StringBuilder();
            SQL.Append(" INSERT INTO S777 (Ver,Url,ThaoTac,Obj,ThongTin,CreateUser,CreateDate) ");
            SQL.Append("output inserted.* ");
            SQL.Append(" VALUES(");
            SQL.Append("'" + lUtils.SmoothStr(info.Ver) + "',");
            SQL.Append("N'" + lUtils.SmoothStr(info.Url) + "',");
            SQL.Append("N'" + lUtils.SmoothStr(info.ThaoTac) + "',");
            SQL.Append("N'" + lUtils.SmoothStr(info.Obj) + "',");
            SQL.Append("N'" + lUtils.SmoothStr(info.ThongTin) + "',");
            SQL.Append("'" + lUtils.SmoothStr(info.CreateUser) + "',");
            SQL.Append("'" + System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + "'");
            SQL.Append(");\n");
            return SQL;
        }
        public StringBuilder SQLIDInsert(GhiLogCSDL info)
        {
            CustomeStruct lUtils = new CustomeStruct();
            if (info == null) return new StringBuilder();
            StringBuilder SQL = new StringBuilder();
            SQL.Append(" INSERT INTO S777 (Ver,Url,ThaoTac,Obj,ThongTin,CreateUser,CreateDate) ");
            SQL.Append(" output inserted.Id ");
            SQL.Append(" VALUES(");
            SQL.Append("'" + lUtils.SmoothStr(info.Ver) + "',");
            SQL.Append("N'" + lUtils.SmoothStr(info.Url) + "',");
            SQL.Append("N'" + lUtils.SmoothStr(info.ThaoTac) + "',");
            SQL.Append("N'" + lUtils.SmoothStr(info.Obj) + "',");
            SQL.Append("N'" + lUtils.SmoothStr(info.ThongTin) + "',");
            SQL.Append("'" + lUtils.SmoothStr(info.CreateUser) + "',");
            SQL.Append("'" + System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + "'");
            SQL.Append(");\n");
            return SQL;
        }
        public List<GhiLogCSDL> GetByInsert(GhiLogCSDL p)// có thay đổi
        {
            GhiLogCSDL p2 = new GhiLogCSDL().Truncate(p);
            List<GhiLogCSDL> l = new List<GhiLogCSDL>();
            using (var conn = new SqlConnection(Conection.connStringBuilder2.ToString()))
            {
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = SQLRowInsert(p2).ToString();
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
        public long GetByInsertID(GhiLogCSDL p) //có thay đối
        {
            GhiLogCSDL p2 = new GhiLogCSDL().Truncate(p);
            using (var conn = new SqlConnection(Conection.connStringBuilder2.ToString()))
            {
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = SQLIDInsert(p2).ToString();
                    conn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            if (!lUtils.IsNull(reader["Id"]) && lUtils.IsNumeric(reader["Id"])) return lUtils.ToInt64(reader["Id"]);
                        }
                    }
                }
            }
            return -1;
        }
    }
}