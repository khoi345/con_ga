using Dto;
using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.Text;
using System.Web;
using System.Reflection;
using System.Web.Script.Serialization;
using Newtonsoft.Json;
using Wcf;
using System.ServiceModel.Activation;
using System.Threading;
using System.Linq;
using System.Timers;

namespace Wcf
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "HaravanService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select HaravanService.svc or HaravanService.svc.cs at the Solution Explorer and start debugging.
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class FLTService : IFLTService
    {
        public FLTService()
        {
          //  var x = new HourlyService();
        }
        public string Hello()
        {
            return "Xin chào đây đây là dịch vụ của Con Gà";
        }

        public KetQua Post(_Dto json)
        {
            KetQua kq = new KetQua();
            try
            {
                if (json != null && json.ThaoTac != null && json.ThaoTac.Trim() != "" && json.ObjName != null && json.ObjName != "")
                {
                    string _class = json.ObjName;

                    var jsonSerialiser = new JavaScriptSerializer();
                    jsonSerialiser.RegisterConverters(new JavaScriptConverter[] { });
                //    KetNoi k = jsonSerialiser.Deserialize<KetNoi>(ThongTinBiMat.Decrypt(json.KetNoi));

                    switch (_class)
                    {
                        case "BaoCao":
                            {
                                BaoCaoBus tmp = new BaoCaoBus();
                                return tmp.XuLy(json);
                            }
                        case "DatMuaSo":
                            {
                                DatMuaSoBus tmp = new DatMuaSoBus();
                                return tmp.XuLy(json);
                            }
                        case "QuaySo":
                            {
                                QuaySoBus tmp = new QuaySoBus();
                                return tmp.XuLy(json);
                            }
                        case "NguoiDung":
                            {
                                NguoiDungBus tmp = new NguoiDungBus();
                                return tmp.XuLy(json);
                            }

                        default:

                            return kq;
                    }

                }
                else
                {
                    kq.error = true;
                    kq.error_msg = "Kiểu dối tượng không được định nghĩa Obj =" + json.ObjName + " ThaoTac= " + json.ThaoTac;
                    return kq;
                }
            }
            catch (Exception ex)
            {
                kq.error = true;
                kq.error_msg = ex.Message;
                return kq;
            }
            finally
            {
                if (json != null) json = null;
            }
        }
    }
}
