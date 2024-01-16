using System;
using System.IO;
using System.IO.Compression;
using System.Text;
using System.Web.Script.Serialization;

namespace Dto
{
    public class _obj
    {
        public bool IsZip { get; set; }
        public bool IsCache { get; set; }
        public _obj()
        {
            this.IsZip = false;
            this.IsCache = true;
        }

        public static void CopyTo(Stream src, Stream dest)
        {
            byte[] bytes = new byte[4096];
            int cnt;
            while ((cnt = src.Read(bytes, 0, bytes.Length)) != 0)
            {
                dest.Write(bytes, 0, cnt);
            }
        }

        public static byte[] Zip(string str)
        {
            var bytes = Encoding.UTF8.GetBytes(str);
            using (var msi = new MemoryStream(bytes))
            using (var mso = new MemoryStream())
            {
                using (var gs = new GZipStream(mso, CompressionMode.Compress))
                {
                    CopyTo(msi, gs);
                }

                return mso.ToArray();
            }
        }

        public static string Unzip(byte[] bytes)
        {
            using (var msi = new MemoryStream(bytes))
            using (var mso = new MemoryStream())
            {
                using (var gs = new GZipStream(msi, CompressionMode.Decompress))
                {
                    CopyTo(gs, mso);
                }

                return Encoding.UTF8.GetString(mso.ToArray());
            }
        }
        public static bool IsDate(object expression)
        {
            try
            {
                if (expression == null)
                    return false;
                System.DateTime testDate;
                if ((DateTime)expression == Convert.ToDateTime("1/1/0001 12:00:00 AM"))
                {
                    return false;
                }
                return System.DateTime.TryParse(expression.ToString(), out testDate);
            }
            catch
            {
                return false;
            }
        }

        public static bool IsNull(object expression)
        {
            if (expression == null || expression == DBNull.Value || String.IsNullOrEmpty(expression.ToString()))
                return true;
            else
                return false;
        }
        public static bool IsBool(object expression)
        {
            bool testBool;
            if (expression != null && bool.TryParse(expression.ToString(), out testBool))
                return true;
            return false;
        }
        public static DateTime ConvertFromUnixTimestamp(double timestamp)
        {
            DateTime origin = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            return origin.AddSeconds(timestamp);
        }

        public static Int32 ConvertToUnixTimestamp(DateTime date)
        {
            DateTime origin = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            TimeSpan diff = date.ToUniversalTime() - origin;
            return (Int32)Math.Floor(diff.TotalSeconds);
        }
    }
    public static class StringExt
    {
        public static string Truncate(this string value, int maxLength)
        {
            if (string.IsNullOrEmpty(value)) return value;
            return value.Length <= maxLength ? value : value.Substring(0, maxLength);
        }

        public static string TruncateRight(this string value, int maxLength)
        {
            if (string.IsNullOrEmpty(value)) return value;
            return value.Length <= maxLength ? value : value.Substring(value.Length - maxLength, maxLength);
        }
        public static string Json(this _Dto p)
        {
            var serializer = new JavaScriptSerializer();
            serializer.RegisterConverters(new JavaScriptConverter[] {   });
            string json = serializer.Serialize(p);
            return json;
        }
        public static string Json(this KetQua p)
        {
            var serializer = new JavaScriptSerializer();
            serializer.RegisterConverters(new JavaScriptConverter[] {  });
            string json = serializer.Serialize(p);
            return json;
        }
    }
}