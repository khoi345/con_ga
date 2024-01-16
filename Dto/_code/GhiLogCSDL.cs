using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;

namespace Dto
{
    public class GhiLogCSDL
    {

        public static string objName = "GhiLogCSDL";

        public static int _sizeVer = 36;
        public static int _sizeUrl = 250;
        public static int _sizeThaoTac = 50;
        public static int _sizeObj = 1073741823;
        public static int _sizeThongTin = 1073741823;
        public static int _sizeCreateUser = 50;
        public object Id { get; set; }
        public string Ver { get; set; }
        public string Url { get; set; }
        public string ThaoTac { get; set; }
        public string Obj { get; set; }
        public string ThongTin { get; set; }
        public string CreateUser { get; set; }
        public DateTime CreateDate { get; set; }

        public GhiLogCSDL()
        {

        }

        public GhiLogCSDL(GhiLogCSDL temp)
        {
            this.Id = temp.Id;
            this.Ver = temp.Ver;
            this.Url = temp.Url;
            this.ThaoTac = temp.ThaoTac;
            this.Obj = temp.Obj;
            this.ThongTin = temp.ThongTin;
            this.CreateUser = temp.CreateUser;
            this.CreateDate = temp.CreateDate;
        }

        public string ToJSON(GhiLogCSDL p)
        {
            var serializer = new JavaScriptSerializer();
            serializer.RegisterConverters(new JavaScriptConverter[] { new DateTimeConverter() });
            string json = serializer.Serialize(p);
            return json;

        }
        public GhiLogCSDL Truncate(GhiLogCSDL info)
        {
            if (info == null) return null;
            GhiLogCSDL t = new GhiLogCSDL(info);
            t.Id = (info.Id != null && info.Id.ToString().Trim() != "") ? info.Id : 0;
            t.Ver = info.Ver.Truncate(_sizeVer);
            t.Url = info.Url.Truncate(_sizeUrl);
            t.ThaoTac = info.ThaoTac.Truncate(_sizeThaoTac);
            t.Obj = info.Obj.Truncate(_sizeObj);
            t.ThongTin = info.ThongTin.Truncate(_sizeThongTin);
            t.CreateUser = info.CreateUser.Truncate(_sizeCreateUser);
            t.CreateDate = (_Dto.IsDate(info.CreateDate) && info.CreateDate > DateTime.MinValue) ? info.CreateDate : new DateTime(1970, 1, 1);
            return t;
        }

    }
}