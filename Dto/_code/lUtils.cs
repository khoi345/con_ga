using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Dto
{
    [System.Diagnostics.DebuggerNonUserCode()]
    public static class lUtils
    {
        //        lUtils instance = null;
        #region Methods
        public static string VietnameseConvert(string strVietNamese)
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
        public static string RemoveSqlInjection(string input)
        {
            // Loại bỏ các ký tự đặc biệt thường được sử dụng trong SQL injection
            string pattern = @"[-';""/*]+"; // Thêm các ký tự khác nếu cần
            string safeInput = Regex.Replace(input, pattern, string.Empty);
            //        string sanitizedInput = RemoveSqlInjection(userInput);
            return safeInput;
        }
        public static string SmoothStr(String strTemp)
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

        public static bool IsNumeric(object expression)
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
            catch (Exception ex)
            {
                return false; throw ex;
            }
        }

        public static bool IsNull(object expression)
        {
            if (expression == null || expression == DBNull.Value || String.IsNullOrEmpty(expression.ToString()))
                return true;
            else
                return false;
        }

        //----- Các hàm convert
        public static String ToStr(object e)
        {
            try
            {
                if (e == null) return "";
                return Convert.ToString(e);
            }
            catch
            {
                return "";
            }

        }

        public static Decimal ToDecimal(object e)
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

        public static Double ToDouble(object e)
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

        public static Byte ToByte(object e)
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

        public static SByte ToSByte(object e)
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

        public static Int16 ToInt16(object e)
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

        public static Int32 ToInt32(object e)
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

        public static Int64 ToInt64(object e)
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

        public static Boolean ToBoolean(object e)
        {
            try
            {
                if (e.Equals("True")) return true;
                if (e is Boolean)
                    return Convert.ToBoolean(e);
                else if (lUtils.IsNumeric(e))
                {
                    if (int.Parse(e.ToString()) != 0)
                    {
                        return true;
                    }
                    return false;
                }
                else return false;
            }
            catch
            {
                return false;
            }
        }
        //-------------------
        public static DateTime GetDate(object value, DateTime nullValue)
        {
            if (value == null || Convert.IsDBNull(value) || string.IsNullOrEmpty(GetString(value)))
            {
                return nullValue;
            }
            return Convert.ToDateTime(value);
        }

        public static DateTime GetDate(object value)
        {
            return GetDate(value, Convert.ToDateTime("1/1/1900"));
        }
        public static TimeSpan GetTime(object value)
        {
            string[] str = value.ToString().Split(':');
            return new TimeSpan(int.Parse(str[0]), int.Parse(str[1]), int.Parse(str[2]));
        }
        public static string GetString(object value, string nullValue)
        {
            if (value == null || Convert.IsDBNull(value))
            {
                return nullValue;
            }
            return Convert.ToString(value);
        }

        public static string GetString(object value)
        {
            return GetString(value, string.Empty);
        }

        public static decimal GetDecimal(object value, decimal nullValue)
        {
            if (value == null || Convert.IsDBNull(value))
            {
                return nullValue;
            }

            return Convert.ToDecimal(value);
        }

        public static decimal GetDecimal(object value)
        {
            return GetDecimal(value, decimal.Zero);
        }

        public static string RemoveLastLetter(string s)
        {
            return s.Substring(0, s.Length - 1);
        }

        public static string UpperCaseFirst(string s)
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
        public static DateTime StringToDate(string Ngay)
        {
            DateTime dte = new DateTime();
            DateTime.TryParseExact(Ngay, "dd/MM/yyyy", null, DateTimeStyles.None, out dte);
            return dte;
        }

        /// <summary>
        /// Convert giá trị của DateEdit sang string, dùng trong save
        /// </summary>
        public static string ValueToDate(object Value)
        {
            return ((DateTime)Value).ToString("yyyy-MM-dd hh:mm:ss");
        }
        public static decimal Round(decimal d, int decimals)
        {
            if (decimals >= 0) return decimal.Round(d, decimals);
            decimal n = (decimal)Math.Pow(10, -decimals);
            return decimal.Round(d / n, 0) * n;
        }
        public static object RoundVND(object var)
        {
            decimal d = 0.0M;
            if (var != DBNull.Value)
            {
                d = decimal.Parse(var.ToString());
                d = d / 1000;
                d = Round(d, 0);
                d = d * 1000;
            }
            return d;
        }
        #endregion
    }

}
