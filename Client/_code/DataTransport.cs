using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using System.Net;
using System.Reflection;
using System.IO;
using System.Runtime.Serialization.Json;
using Newtonsoft.Json;
using System.Text;
using System.Web.Script.Serialization;
#if DEBUG
using Wcf;
#endif
using Dto;

namespace Client
{
    public class DataTransport
    {

        public static string server = lData.Maincode("Release");
        public static string ftp = "";
        public static string url = server + "FLTService.svc/Post";
        public static string urlget = server + "FLTService.svc/Get";
     //   public static string urlgetobj = server + "FLTService.svc/vice.svc/GetObj";
     //   public static string serverGET = server + "FLTService.svc/";
     //   public static string url2 = serverGET + "Post2";
        public DataTransport()
        {

        }
        public DataTable ConvertToDataTable(Object[] array)
        {
            PropertyInfo[] properties = array.GetType().GetElementType().GetProperties();
            DataTable dt = CreateDataTable(properties);
            if (array.Length != 0)
            {
                foreach (object obj in array)
                    FillData(properties, dt, obj);
            }
            return dt;
        }
        private DataTable CreateDataTable(PropertyInfo[] properties)
        {
            DataTable dt = new DataTable();
            DataColumn dc = null;
            foreach (PropertyInfo pi in properties)
            {
                dc = new DataColumn();
                dc.ColumnName = pi.Name;
                dc.DataType = pi.PropertyType;
                dt.Columns.Add(dc);
            }
            return dt;
        }
        private void FillData(PropertyInfo[] properties, DataTable dt, Object o)
        {
            DataRow dr = dt.NewRow();
            foreach (PropertyInfo pi in properties)
            {
                dr[pi.Name] = pi.GetValue(o, null);
            }
            dt.Rows.Add(dr);
        }
        public static Stream GenerateStreamFromString(string s)
        {
            MemoryStream stream = new MemoryStream();
            StreamWriter writer = new StreamWriter(stream);
            writer.Write(s);
            writer.Flush();
            stream.Position = 0;
            return stream;
        }

         
        public void upfile(string myFile)
        {
            try
            {
                WebClient client = new WebClient();
                client.Credentials = CredentialCache.DefaultCredentials;
                client.UploadFile(@"http://localhost:8080/Service.svc//UploadFile?fileName=tap_tin.txt", "POST", myFile);
                client.Dispose();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }
        private static KetQua CreateConection(Dictionary<string, string> dic, string type = "POST")
        {
            Stream stream = null;
            MemoryStream ms = new MemoryStream();
            KetQua kq = null;
            byte[] t = ms.ToArray();
            byte[] result = null;
            WebClient proxy = new WebClient();
            proxy.Headers["Content-type"] = "application/json";
            _Dto data = new _Dto();


        //    data.KetNoi = ThongTinBiMat.Encrypt( dic["ketNoi"].ToString());
            data.ObjName = dic["objName"].ToString();
            data.ThaoTac = dic["thaoTac"].ToString();
            data.Obj = dic["obj"].ToString();
            data.IsZip = false;



            if (type.Equals("POST"))
            {
#if DEBUG
                FLTService sv = new FLTService();
                try
                {
                    kq = sv.Post(data);
                }
                catch (Exception ex)
                {
                    throw new System.ArgumentException(stream.ToString() + ex.Message);
                }
#else
                DataContractJsonSerializer serializerToUplaod = new DataContractJsonSerializer(typeof(_Dto));
                serializerToUplaod.WriteObject(ms, data);
                try
                {
                    result = proxy.UploadData(url, type, ms.ToArray());
                }
                catch (Exception ex)
                {
                    if (stream != null)
                        throw new System.ArgumentException(stream.ToString() + ex.Message);
                    else
                        throw new System.ArgumentException(ex.Message);
                }
                stream = new MemoryStream(result);
                DataContractJsonSerializer obj = new DataContractJsonSerializer(typeof(KetQua));
                kq = obj.ReadObject(stream) as KetQua;
#endif
            }
            else if (type.Equals("GET"))
            {
                string s = "";//= string.Concat("{", string.Join(",", kvs), "}");

                DataContractJsonSerializer serializerToUplaod = new DataContractJsonSerializer(typeof(string));
                serializerToUplaod.WriteObject(ms, s);
                try
                {
                    result = proxy.UploadData(urlget, type, ms.ToArray());
                }
                catch (Exception ex)
                {
                    throw new System.ArgumentException(stream.ToString() + ex.Message);
                }
                stream = new MemoryStream(result);
            }
            if (kq.IsZip)
            {
                kq.result = _obj.Unzip(kq.resultArray);
            }
            return kq;
        }
        /*
        public static bool Action(Dictionary<string, string> dic, bool thongBao = true)
        {
            var jsonSerialiser = new JavaScriptSerializer();
            jsonSerialiser.RegisterConverters(new JavaScriptConverter[] { new Dto.DateTimeConverter() });
            KetQua json = null;
            try
            {
                json = CreateConection(dic);
            }
            catch (Exception ex)
            {
                ThongBao.ShowThongBao(ex.Message.ToString());
                return false;
            }

            if (json != null && json.error)
            {
                ThongBao.ShowThongBao(json.error_msg);
                return false;
            }
            else
            {
                if (json != null && json.thongBao && thongBao)
                {
                    MessageBox.Show(json.thongBao_msg.ToString());
                }
            }
            try
            {
                if (json != null && (json.error || thongBao))
                    ThongBao.ShowThongBao(json.error_msg + "\n" + json.thongBao_msg);
                return (jsonSerialiser.Deserialize<int>(json.result.ToString()) > 0);
            }
            catch (Exception ex)
            {
                ThongBao.ShowThongBao(ex.Message.ToString());
                return false;
            }
        }
       
        public static bool Get(Dictionary<string, string> dic, bool thongBao = true)
        {
            try
            {
                KetQua stream = CreateConection(dic, "GET");
                var jsonSerialiser = new JavaScriptSerializer();
                jsonSerialiser.RegisterConverters(new JavaScriptConverter[] { new Dto.DateTimeConverter() });
                return jsonSerialiser.Deserialize<bool>(stream.result.ToString());
            }
            catch (Exception ex)
            {
                throw new System.ArgumentException(ex.Message.ToString());
            }
        }
        */
        public static DataTable ToDataTable<T>(List<T> items)
        {
            DataTable dataTable = new DataTable(typeof(T).Name);
            //Get all the properties
            if (items == null)
                return dataTable;
            else
            {
                PropertyInfo[] Props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
                foreach (PropertyInfo prop in Props)
                {
                    //Setting column names as Property names
                    //   Type ty = prop.GetType();
                    dataTable.Columns.Add(prop.Name);

                }
                foreach (T item in items)
                {
                    var values = new object[Props.Length];
                    for (int i = 0; i < Props.Length; i++)
                    {
                        //inserting property values to datatable rows
                        values[i] = Props[i].GetValue(item, null);
                    }
                    dataTable.Rows.Add(values);
                }
                //put a breakpoint here and check datatable
                return dataTable;
            }
        }

        public static object GetPropValue(object src, string propName)
        {
            return src.GetType().GetProperty(propName).GetValue(src, null);
        }
        public static bool Action(Dictionary<string, string> dic, bool thongBao = true)
        {
            var jsonSerialiser = new JavaScriptSerializer();
            jsonSerialiser.RegisterConverters(new JavaScriptConverter[] { new Dto.DateTimeConverter() });
            KetQua json = null;
            try
            {
                json = CreateConection(dic);
            }
            catch (Exception ex)
            {
                ThongBao.ShowThongBao(ex.Message.ToString());
                return false;
            }

            if (json != null && json.error)
            {
                ThongBao.ShowThongBao(json.error_msg);
                return false;
            }
            else
            {
                if (json != null && json.thongBao && thongBao)
                {
                    MessageBox.Show(json.thongBao_msg.ToString());
                }
            }
            try
            {
                if (json != null && (json.error || thongBao))
                    ThongBao.ShowThongBao(json.error_msg + "\n" + json.thongBao_msg);
                return (jsonSerialiser.Deserialize<int>(json.result.ToString()) > 0);
            }
            catch (Exception ex)
            {
                ThongBao.ShowThongBao(ex.Message.ToString());
                return false;
            }
        }
        public static string GetPostStrObj(Dictionary<string, string> dic = null, bool thongBao = true)
        {
            KetQua kq = new KetQua();
            try
            {
                kq = CreateConection(dic);
                if (thongBao)
                {
                    if (kq.thongBao || kq.error)
                    {
                        if (kq.thongBao)
                        {
                            MessageBox.Show(kq.thongBao_msg + "\n " + kq.error, "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            if (kq.thongBao_msg.Length > 0) ThongBao.ShowThongBao(kq.thongBao_msg + "\n " + kq.error_msg);
                            else ThongBao.ShowThongBao(kq.error_msg);
                        }

                    }
                    return kq.result;
                }
                else if (thongBao == false)
                {
                    if (kq.error)
                    {
                        if (kq.thongBao_msg.Length > 0)
                            throw new System.ArgumentException(kq.thongBao_msg + "\n " + kq.error_msg);
                        else
                            throw new System.ArgumentException(kq.error_msg);
                    }
                    return kq.result;
                }
                return kq.result;

            }
            catch (Exception ex)
            {
                if (kq != null && kq.thongBao_msg != null && kq.thongBao_msg.Length > 0)
                    throw new System.ArgumentException(kq.thongBao_msg + "\n " + kq.error_msg);
                else if (kq != null && kq.error_msg != null && kq.error_msg.Length > 0)
                    throw new System.ArgumentException(kq.error_msg);
                else throw new System.ArgumentException(ex.Message);
            }
        }
        /*
        public static string PostValue(Dictionary<string, string> dic = null, bool thongBao = true)
        {
            KetQua kq = null;
            try
            {
                kq = CreateConection(dic);
                if (kq.error)
                {
                    ThongBao.ShowThongBao(kq.error_msg);
                    if (kq.thongBao)
                    {
                        ThongBao.ShowThongBao(kq.thongBao_msg);
                    }
                    return null;
                }
                return kq.result;
            }
            catch (Exception)
            {

                ThongBao.ShowThongBao(kq.ToString());
                return "[]";
            }
        }
        public static DataTable GetDataTable(Dictionary<string, string> dic = null, bool thongBao = true)
        {
            string str = "";
            try
            {
                KetQua kq = CreateConection(dic, "POST");
                if (kq.error)
                {
                    ThongBao.ShowThongBao(kq.error.ToString());
                    if (kq.thongBao)
                    {
                        ThongBao.ShowThongBao(kq.thongBao_msg);
                    }
                    return null;

                }
                else
                {
                    return JsonConvert.DeserializeObject<DataTable>(kq.result.ToString());
                }
            }
            catch (Exception ex)
            {

                throw new System.ArgumentException(ex.Message + str);
            }
        }
        public static T _download_serialized_json_data<T>(string function) where T : new()
        {
            var url = serverGET + function;
            using (var w = new WebClient())
            {
                var json_data = string.Empty;
                w.Encoding = Encoding.UTF8;
                try
                {
                    json_data = w.DownloadString(url);
                }
                catch (Exception) { }
                if (!string.IsNullOrEmpty(json_data))
                {
                    var jsonSerialiser = new JavaScriptSerializer();
                    jsonSerialiser.RegisterConverters(new JavaScriptConverter[] { new DateTimeConverter() });
                    return jsonSerialiser.Deserialize<T>(json_data);
                }
                return new T();
            }
        }
        */
    }
}