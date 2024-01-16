using System;
using System.Web.Script.Serialization;
using Dto;
using Dao;
using System.Collections.Generic;
using System.Threading;
using System.Text;

namespace Dao
{
    public class GuiLogDao
    {

        public void GuiLog(string url = "", string thaoTac = "", string obj = "", string thongTin = "", string ver = "")
        {
#if DEBUG
            GhiLog(url, thaoTac, obj, thongTin, ver);
#else
            ThreadPool.QueueUserWorkItem(o => GhiLog(url, thaoTac, obj, thongTin, ver));
#endif
        }
        public long GuiLogTraMaLoi(string url = "", string thaoTac = "", string obj = "", string thongTin = "", string ver = "")
        {
            long loi = 0;
            try
            {
#if DEBUG
            loi = GhiLog(url, thaoTac, obj, thongTin, ver);
#else
                ThreadPool.QueueUserWorkItem(o =>
                {
                    try
                    {
                        loi = GhiLog(url, thaoTac, obj, thongTin, ver);
                    }
                    catch (Exception ex)
                    {
                        // Handle the exception in the asynchronous thread if needed
                        Console.WriteLine("Error in asynchronous thread: " + ex.Message);
                    }
                });
#endif
            }
            catch (Exception ex)
            {
                // Handle the exception if needed
                Console.WriteLine("Error in GuiLogTraMaLoi: " + ex.Message);
                // Set loi to an appropriate error code
                loi = -1;
            }
            return loi;
        }

        public static long GhiLog(string url, string ThaoTac, string obj, string thongTin, string ver = "")
        {
            GhiLogCSDLDao dao = new GhiLogCSDLDao();
            GhiLogCSDL p1 = new GhiLogCSDL();
            p1.Url = url;
            p1.ThaoTac = ThaoTac;
            p1.Obj = obj;
            p1.ThongTin = thongTin;
            p1.Ver = ver;
            p1.CreateUser = Conection.connStringBuilder.InitialCatalog;
            GhiLogCSDL p2 = new GhiLogCSDL(p1);
            p2 = p2.Truncate(p2);
            return dao.Insert(p2);
        }
    }
}
