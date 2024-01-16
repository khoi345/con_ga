using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Dto
{
    public class CustomeStruct
    {
        public CustomeStruct()
        {
        }
        public string VietnameseConvert(string strVietNamese)
        {
            string strFormD = strVietNamese.Normalize(NormalizationForm.FormD);
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < strFormD.Length; i++)
            {
                System.Globalization.UnicodeCategory uc = System.Globalization.CharUnicodeInfo.GetUnicodeCategory(strFormD[i]);
                if (uc != System.Globalization.UnicodeCategory.NonSpacingMark)
                {
                    sb.Append(strFormD[i]);
                }
            }
            sb = sb.Replace('Đ', 'D');
            sb = sb.Replace('đ', 'd');
            return (sb.ToString().Normalize(NormalizationForm.FormD));
        }
        public string EncryptPassword(string text)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            md5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(text));
            byte[] result = md5.Hash;
            StringBuilder strBuilder = new StringBuilder();
            for (int i = 0; i < result.Length; i++)
            {
                strBuilder.Append(result[i].ToString("x2"));
            }
            return strBuilder.ToString();
        }

        public string SmoothStr(String strTemp)
        {
            try
            {
                if (strTemp == null || string.IsNullOrEmpty(strTemp.Trim()))
                    return "";
                strTemp = strTemp.Replace("'", "''");
                strTemp = strTemp.Replace(";", "");
                strTemp = strTemp.Replace("--", "");
                strTemp = strTemp.Replace("delete ", "");
                strTemp = strTemp.Replace("del ", "");
                strTemp = strTemp.Replace("set ", "");
                strTemp = strTemp.Replace("drop ", "");
                strTemp = strTemp.Replace("update ", "");
                strTemp = strTemp.Replace("select ", "");
                strTemp = strTemp.Replace("exec ", "");
                strTemp = strTemp.Replace("execute ", "");
                strTemp = strTemp.Replace("delete%", "");
                strTemp = strTemp.Replace("del%", "");
                strTemp = strTemp.Replace("set%", "");
                strTemp = strTemp.Replace("drop%", "");
                strTemp = strTemp.Replace("update%", "");
                strTemp = strTemp.Replace("select%", "");
                strTemp = strTemp.Replace("exec%", "");
                strTemp = strTemp.Replace("execute%", "");
                return strTemp;
            }
            catch
            {
                return "";
            }

        }

        public bool IsNumeric(object expression)
        {
            if (expression == null)
                return false;

            double testDouble;
            if (double.TryParse(expression.ToString(), out testDouble))
                return true;

            //VB's 'IsNumeric' returns true for any boolean value:
            bool testBool;
            if (bool.TryParse(expression.ToString(), out testBool))
                return true;

            return false;
        }

        public bool IsBool(object expression)
        {
            bool testBool;
            if (bool.TryParse(expression.ToString(), out testBool))
                return true;
            return false;
        }

        public bool IsDate(object expression)
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
            catch (Exception ex)
            {
                return false;
                throw ex;
            }
        }

        public bool IsNull(object expression)
        {
            if (expression == null || expression == DBNull.Value || String.IsNullOrEmpty(expression.ToString()))
                return true;
            else
                return false;
        }

        //----- Các hàm convert
        public String ToStr(object e)
        {
            try
            {
                if (e == null || e == DBNull.Value) return "";
                return Convert.ToString(e);
            }
            catch
            {
                return "";
            }
        }

        public Decimal ToDecimal(object e)
        {
            try
            {
                if (e == null) return 0;
                decimal re = 0;
                decimal.TryParse(e.ToString(), out re);
                return re;
            }
            catch
            {
                return 0;
            }
        }

        public Double ToDouble(object e)
        {
            try
            {
                if (e == null) return 0;
                double re = 0;
                double.TryParse(e.ToString(), out re);
                return re;
            }
            catch
            {
                return 0;
            }
        }

        public Byte ToByte(object e)
        {
            try
            {
                if (e == null) return 0;
                if (e.GetType() == typeof(bool)) return Convert.ToByte(e);
                Byte re = 0;
                Byte.TryParse(e.ToString(), out re);
                return re;
            }
            catch
            {
                return 0;
            }

        }

        public SByte ToSByte(object e)
        {
            try
            {
                if (e == null) return 0;
                if (e.GetType() == typeof(bool)) return Convert.ToSByte(e);
                SByte re = 0;
                SByte.TryParse(e.ToString(), out re);
                return re;
            }
            catch
            {
                return 0;
            }

        }

        public Int16 ToInt16(object e)
        {
            try
            {
                if (e == null) return 0;
                if (e.GetType() == typeof(bool)) return Convert.ToInt16(e);
                Int16 re = 0;
                Int16.TryParse(e.ToString(), out re);
                return re;
            }
            catch
            {
                return 0;
            }

        }

        public Int32 ToInt32(object e)
        {
            try
            {
                if (e == null) return 0;
                if (e.GetType() == typeof(bool)) return Convert.ToInt32(e);
                Int32 re = 0;
                Int32.TryParse(e.ToString(), out re);
                return re;
            }
            catch
            {
                return 0;
            }

        }

        public Int64 ToInt64(object e)
        {
            try
            {
                if (e == null) return 0;
                if (e.GetType() == typeof(bool)) return Convert.ToInt64(e);
                Int64 re = 0;
                Int64.TryParse(e.ToString(), out re);
                return re;
            }
            catch
            {
                return 0;
            }

        }

        public Boolean ToBoolean(object e)
        {
            try
            {
                if (e.ToString().Equals("True"))
                {
                    return true;
                }
                else
               if (e is Boolean)
                {
                    return Convert.ToBoolean(e);

                }
                else if (lUtils.IsNumeric(e))
                {
                    if (int.Parse(e.ToString()) > 0)
                    {
                        return true;
                    }
                    return false;
                }

                else return false;
            }
            catch { return false; }
        }
        //-------------------
        public DateTime GetDate(object value, DateTime nullValue)
        {
            if (value == null || Convert.IsDBNull(value) || string.IsNullOrEmpty(GetString(value)))
            {
                return nullValue;
            }
            return Convert.ToDateTime(value);
        }

        public DateTime GetDate(object value)
        {
            return GetDate(value, Convert.ToDateTime("1/1/1900"));
        }
        public TimeSpan GetTime(object value)
        {
            string[] str = value.ToString().Split(':');
            return new TimeSpan(int.Parse(str[0]), int.Parse(str[1]), int.Parse(str[2]));
        }
        public string GetString(object value, string nullValue)
        {
            if (value == null || Convert.IsDBNull(value))
            {
                return nullValue;
            }
            return Convert.ToString(value);
        }

        public string GetString(object value)
        {
            return GetString(value, string.Empty);
        }

        public decimal GetDecimal(object value, decimal nullValue)
        {
            if (value == null || Convert.IsDBNull(value))
            {
                return nullValue;
            }

            return Convert.ToDecimal(value);
        }

        public decimal GetDecimal(object value)
        {
            return GetDecimal(value, decimal.Zero);
        }

        public string RemoveLastLetter(string s)
        {
            return s.Substring(0, s.Length - 1);
        }

        public string UpperCaseFirst(string s)
        {
            char[] array = s.ToCharArray();
            if (array.Length >= 1)
            {
                if (char.IsLower(array[0]))
                {
                    array[0] = char.ToUpper(array[0]);
                }
            }
            for (int i = 1; i < array.Length; i++)
            {
                if (array[i - 1] == ' ')
                {
                    if (char.IsLower(array[i]))
                    {
                        array[i] = char.ToUpper(array[i]);
                    }
                }
            }
            return new string(array);
        }

        /// <summary>
        /// Convert dd/MM/yyyy to datetime
        /// </summary>
        public DateTime StringToDate(string Ngay)
        {
            DateTime dte = new DateTime();
            DateTime.TryParseExact(Ngay, "dd/MM/yyyy", null, DateTimeStyles.None, out dte);
            return dte;
        }

        /// <summary>
        /// Convert giá trị của DateEdit sang string, dùng trong save
        /// </summary>
        public string ValueToDate(object Value)
        {
            return ((DateTime)Value).ToString("yyyy-MM-dd hh:mm:ss");
        }

    }

}
