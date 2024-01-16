using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace Dto
{
    public class DateTimeConverter : JavaScriptConverter
    {
        public DateTimeConverter()
        {

        }

        public override IEnumerable<Type> SupportedTypes
        {
            get { return new List<Type>() { typeof(DateTime), typeof(DateTime?) }; }
        }

        public override IDictionary<string, object> Serialize(object obj, JavaScriptSerializer serializer)
        {
            Dictionary<string, object> result = new Dictionary<string, object>();
            if (obj == null) return result;
            result["DateTime"] = ((DateTime)obj).ToString("yyyy-MM-dd HH:mm:ss");
            return result;
        }

        public override object Deserialize(IDictionary<string, object> dictionary, Type type, JavaScriptSerializer serializer)
        {
            //      CultureInfo provider = CultureInfo.InvariantCulture;

            if (dictionary.ContainsKey("DateTime"))
                return DateTime.ParseExact(dictionary["DateTime"].ToString(), "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture);
            //  return new DateTime(long.Parse(dictionary["DateTime"].ToString()), DateTimeKind.Unspecified);
            return null;
        }
        public override string ToString()
        {
            //  if (this != null)
            //      return base.ToString();
            //  else return DateTime.MinValue.ToString("yyyy-MM-dd HH:mm:ss");
            return "";
        }
        //public string DateTimes(string key)
        //{
        //    List<TuNgayDenNgay> l = new List<TuNgayDenNgay>();
        //    var jsonSerialiser = new JavaScriptSerializer();

        //    jsonSerialiser.RegisterConverters(new JavaScriptConverter[] { new DateTimeConverter() });

        //    switch (key)
        //    {
        //        case "default":
        //        case "":
        //            l.Add(new TuNgayDenNgay());
        //            return jsonSerialiser.Serialize(l);

        //        case "full":
        //        case "DS":
        //        case "ds":
        //        case "list":
        //            List<object> l2 = new List<object>();
        //            l2 = new TuNgayDenNgay().List();
        //            // if (l2 != null && l2.Count > 0)
        //            //    for (int i = 0; i < l2.Count; i++)
        //            //      l.Add((TuNgayDenNgay)l2[i]);
        //            return jsonSerialiser.Serialize(l2);

        //        default:
        //            l.Add(new TuNgayDenNgay().get(key));
        //            return jsonSerialiser.Serialize(l);

        //    }
        //}
    }

}
