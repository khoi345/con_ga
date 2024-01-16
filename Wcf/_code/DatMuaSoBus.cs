using System;
using System.Web.Script.Serialization;
using System.Reflection;
using Dto;
using Dao;
using System.Collections.Generic;

namespace Wcf
{
    public class DatMuaSoBus : BusCache
    {
        public KetQua XuLy(_Dto data)
        {
            try
            {
                string thaoTac = data.ThaoTac;
                KetQua kq = new KetQua();
                var jsonSerialiser = new JavaScriptSerializer();
                jsonSerialiser.RegisterConverters(new JavaScriptConverter[] { new DateTimeConverter() });

                BoLoc boLoc = null;
                if (data._boLoc != null)
                {
                    boLoc = jsonSerialiser.Deserialize<BoLoc>(data._boLoc);
                }
                TaoName(data);
                thaoTac = LayCache(kq, thaoTac);

                DatMuaSo obj = jsonSerialiser.Deserialize<DatMuaSo>(data.Obj);
                DatMuaSoDao dao = new DatMuaSoDao();
                switch (thaoTac)
                {
                    case "NDMS": kq.result = jsonSerialiser.Serialize(dao.New(obj));
                        TaoCacheByID(data);
                        break;
                    case "IDMS": kq.result = jsonSerialiser.Serialize(dao.Insert(obj).ToString());
                        TaoCacheByID(data);
                        break;
                    case "DMSCG": kq.result = jsonSerialiser.Serialize(this.DatMuaSoConGa(obj));
                        XoaListCache(data);
                        break;
                    case "DDMS": kq.result = jsonSerialiser.Serialize(dao.Delete(obj).ToString());
                        XoaListCache(data);
                        break;
                    case "UDMS": kq.result = jsonSerialiser.Serialize(dao.Update(obj).ToString());
                        XoaListCache(data);
                        break;
                    case "GBID": kq.result = jsonSerialiser.Serialize(dao.GetOnlyByID(obj.ID.ToString()));
                        TaoCacheByID(data);
                        break;
                    case "LBID": kq.result = jsonSerialiser.Serialize(dao.Get(obj));
                        TaoCacheByID(data);
                        break;
                    case "LBUID": kq.result = jsonSerialiser.Serialize(dao.GetByUserID(obj));
                        TaoCacheByID(data);
                        break;
                    //case "LBIDS": kq.result = jsonSerialiser.Serialize(dao.GetS(obj));break; 
                    //case "LBIDR": kq.result = jsonSerialiser.Serialize(dao.GetR(obj));break; 
                    case "LA":
                        jsonSerialiser.MaxJsonLength = Int32.MaxValue;
                        kq.result = jsonSerialiser.Serialize(dao.GetAll(obj, boLoc));
                        TaoCacheByID(data);
                        break;
                    case "KTTT": kq.result = jsonSerialiser.Serialize(dao.KiemTraTonTai(obj));
                        TaoCacheByID(data);
                        break;
                        // case "KTTTT": kq.result = jsonSerialiser.Serialize(dao.KiemTraTenTonTai(obj)); break;
                        //  case "KTDSD": kq.result = jsonSerialiser.Serialize(dao.KiemTraDaSuDung(obj)); break;
                    default: return kq;
                }
                SetCache(kq, 60 * 60 * 24);
                SysCache();
                return kq;
            }
            catch (Exception ex)
            {
                long loi = -1;
                GuiLogDao gl = new GuiLogDao();
                if (data != null)
                    loi = gl.GuiLogTraMaLoi(this.GetType().Name, data.ThaoTac, data.Obj, ex.Message, data.Ver);
                else
                    loi = gl.GuiLogTraMaLoi(this.GetType().Name, "", "", ex.Message, "");
                throw new System.ArgumentException("Mã lỗi: " + loi.ToString() + " " + ex.Message);

            }
        }
        public List<DatMuaSo> DatMuaSoConGa(DatMuaSo tmp)
        {
            tmp.ThoiGianDat = DateTime.Now;
            List<DatMuaSo> l = new List<DatMuaSo>();
            DatMuaSoDao dao = new DatMuaSoDao();
            tmp.SlotMoSoID = DateTime.Now.AddHours(1).ToString("yyyyMMddHH");
            var l2 = dao.GetByUserSlotID(tmp);
            if (l2 != null && l2.Count > 0)
                return l2;
            else
            {

                long kq = dao.Insert(tmp);
                //_Dto  dto= new _Dto();
                //tmp = new DatMuaSo();
                //tmp.DatMuaSoID = kq;
                //dto.ThaoTac = "LBID";
                //dto.ObjName = DatMuaSo.objName;
                //dto.Obj = tmp.ToJSON(tmp);
                l2 = dao.Get(new DatMuaSo() { ID = kq });
            }
            return l2;
        }
        
    }
}