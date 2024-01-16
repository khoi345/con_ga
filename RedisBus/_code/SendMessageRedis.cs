//using System;
//using System.Net.Http;
//using System.Threading.Tasks;
//using RedisBoost;
//using System.Net;
//using StackExchange.Redis;
//using System.Web.Script.Serialization;
//using System.Threading;
//using Newtonsoft.Json;
//using System.IO;
//using System.Text;
//using Dto;
//using System.Net.Http.Headers;
//namespace RedisBus
//{


//    public class SendMessageRedis
//    {
//        public string _CSDL = "";
//        public const string QueueName1 = "_message_queue_lv1";
//        public const string QueueName2 = "_message_queue_lv2";
//        public const string QueueName3 = "_message_queue_lv3";
//        public const string QueueName4 = "_message_queue_lv4";
//        public const string QueueName5 = "_message_queue_lv5";
//        private static object lockObject = new object();

//#if DEBUG
//        private const double SoPhut = 5;
//#else
//        private const double SoPhut = 60;
//#endif

//        public async Task SendMessage(PostWebhook message, ConfigSend send, string connectionString = "127.0.0.1:6379")
//        {
//            ConnectionMultiplexer redis = ConnectionMultiplexer.Connect(connectionString);
//            IDatabase db = redis.GetDatabase();
//            var serializer = new JavaScriptSerializer();
//            var data = new DataMessage
//            {
//                data = message.data,
//                config = send,
//            };
//            string jsonMessage = serializer.Serialize(data);
//            string flag1 = send._CSDL + "-" + QueueName1;

//            await db.ListLeftPushAsync(flag1, jsonMessage);
//            //     TimeSpan ttl = TimeSpan.FromDays(2);
//            //     await db.KeyExpireAsync(send._CSDL + "-" + send._khachHang + "-" + QueueName1, ttl);
//            //await ProcessMessageQueue(db, new ConfigSend(send), message);
//        }

//        public async Task DuaVaoHangDoix(object data, string flag2, string connectionString = "127.0.0.1:6379")
//        {
//            ConnectionMultiplexer redis = ConnectionMultiplexer.Connect(connectionString);
//            IDatabase db = redis.GetDatabase();
//            DuaVaoHangDoi(data, flag2, db);
//        }

//        public async void DuaVaoHangDoi(object data, string flag2, IDatabase db)
//        {
//            TimeSpan ttl = TimeSpan.FromDays(2);
//            var serializer = new JavaScriptSerializer();
//            string json = serializer.Serialize(data);
//            await db.ListLeftPushAsync(flag2, json);
//            await db.KeyExpireAsync(flag2, ttl);
//            //    Thread.Sleep(TimeSpan.FromMinutes(SoPhut));
//        }
//        //string flag1 = _CSDL + "-" + QueueName1;
//        //string flag2 = _CSDL + "-" + QueueName2;
//        //string flag3 = _CSDL + "-" + QueueName3;
//        //string flag4 = _CSDL + "-" + QueueName4;
//        //string flag5 = _CSDL + "-" + QueueName5;

//        public async Task<DataMessage> GetMessageQueue(string flag1, string connectionString = "127.0.0.1:6379")
//        {
//            ConnectionMultiplexer redis = ConnectionMultiplexer.Connect(connectionString);
//            IDatabase db = redis.GetDatabase();
//            //  var serializer = new JavaScriptSerializer();
//            string jsonMessage = await db.ListRightPopAsync(flag1);
//            if (jsonMessage != null && jsonMessage != "")
//                return JsonConvert.DeserializeObject<DataMessage>(jsonMessage);
//            else
//                return null;
//        }
//        public async Task ProcessMessageQueue(string flag1, string flag2, string connectionString = "127.0.0.1:6379")
//        {
//            ConnectionMultiplexer redis = ConnectionMultiplexer.Connect(connectionString);
//            IDatabase db = redis.GetDatabase();
//            var serializer = new JavaScriptSerializer();

//            int count = 0;
//            //   while (count < 200)
//            {
//                string jsonMessage = await db.ListRightPopAsync(flag1);
//                if (jsonMessage != null)
//                {
//                    DataMessage v = serializer.Deserialize<DataMessage>(jsonMessage);
//                    // await db.ListLeftPushAsync(flag1, jsonMessage);
//                    ThreadPool.QueueUserWorkItem(o => SendToPartnerWebhook2(new DataMessage(v), flag2));
//                    count++;
//                }
//                else
//                {
//                    // If there are no more items in the list, break out of the loop
//                    //   break;
//                }
//            }
//        }
//        public async Task<bool> SendToPartnerWebhook4(DataMessage data, string flag2, string connectionString = "127.0.0.1:6379")
//        {
//            // var url = $"https://aship.tpos.vn/api/ApiShippingWebhook/BKK";
//            var requestUri = new Uri(data.config._url_hook);
//            var hostHeader = requestUri.Host;
//            Console.WriteLine("dong 1");
//            //var url = $"{APIUrl}/Order/Add";
//            var handler = new HttpClientHandler
//            {
//                //UseProxy = true,
//                //Proxy = WebRequest.DefaultWebProxy,
//            };
//            var content = new StringContent("{\r\n    \"data\": {\r\n\t\t\"awb\": \"BKA000359036\",\r\n\t\t\"order_ref\": \"INV/2023/48003\",\r\n\t\t\"awb_ref1\": \"\",\r\n\t\t\"awb_ref2\": \"\",\r\n\t\t\"bill_statusdate\": \"2023-10-27 16:48:14\",\r\n\t\t\"bill_statusdate2\": \"0001-01-01 00:00:00\",\r\n\t\t\"bill_status\": 80,\r\n\t\t\"status_name\": \"Đang chờ Pickup\",\r\n\t\t\"localion_currently\": null,\r\n\t\t\"note\": \"Đang chờ Pickup-\",\r\n\t\t\"real_recipient\": null\r\n\t},\r\n    \"token\": \"QZKLiVaD0fTebRWWFTi3Mh5BBjhGMf88RTBJqrBJx78zEB57DBsdRuD4jhwCCu0z\"\r\n}", Encoding.UTF8, "application/json");
//            Console.WriteLine("dong 2");
//            // handler.ServerCertificateCustomValidationCallback += (sender, cert, chain, sslPolicyErrors) => true;


//            using (var client = new HttpClient(handler))
//            {
//                try
//                {
//                    Console.WriteLine("dong 3");
//                    if (data.config._url_hook.StartsWith("https", StringComparison.OrdinalIgnoreCase))
//                        System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3 | SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;


//                    client.BaseAddress = new Uri("https://aship.tpos.vn/");
//                    //   client.DefaultRequestHeaders.Add("Authorization", $"Bearer {token}");
//                    // client.DefaultRequestHeaders.Add("ems-key", _emsKey);
//                    Console.WriteLine("dong 4");
//                    var response = await client.PostAsync(requestUri.ToString(), content);
//                    //    var response = await client.PostAsync(url, new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json"));
//                    var body = await response.Content.ReadAsStringAsync();
//                    Console.WriteLine(body);
//                    Console.WriteLine("dong 5");
//                    return true;

//                }
//                catch (HttpRequestException e)
//                {
//                    Console.WriteLine(e.InnerException.Message);
//                    return false;
//                }
//                catch (Exception ex)
//                {
//                    Console.WriteLine(ex.InnerException.Message);
//                    return false;
//                }
//            }
//        }
//        public async Task<bool> SendToPartnerWebhook3(DataMessage data, string flag2, string connectionString = "127.0.0.1:6379")
//        {
//            GhiLog log = new GhiLog();


//            WebRequest tRequest;
//            if (data.config._url_hook.StartsWith("https", StringComparison.OrdinalIgnoreCase))
//                System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3 | SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;

//            //thiết lập FCM send
//            tRequest = WebRequest.Create(data.config._url_hook);
//            tRequest.Method = "POST";
//            tRequest.UseDefaultCredentials = true;
//            tRequest.PreAuthenticate = true;
//            tRequest.Credentials = CredentialCache.DefaultNetworkCredentials;
//            string txAuthorization = data.config._authToken;
//            tRequest.ContentType = "application/json";
//            System.Console.WriteLine("donng 1\n");

//            tRequest.Headers.Add(string.Format("Authorization: {0}", txAuthorization));
//            var ds = new PostWebhook
//            {
//                data = data.data,
//                token = data.config._authToken,
//            };
//            var jsonMessage = JsonConvert.SerializeObject(ds);

//            Byte[] byteArray = Encoding.UTF8.GetBytes(jsonMessage);
//            tRequest.ContentLength = byteArray.Length;
//            System.Console.WriteLine("donng 2\n");


//            Stream dataStream = tRequest.GetRequestStream();
//            try
//            {
//                System.Console.WriteLine("donng 3\n");

//                dataStream.Write(byteArray, 0, byteArray.Length);
//                dataStream.Close();
//                WebResponse tResponse = tRequest.GetResponse();
//                System.Console.WriteLine("donng 4\n");

//                dataStream = tResponse.GetResponseStream();
//                StreamReader tReader = new StreamReader(dataStream);
//                System.Console.WriteLine("donng 5\n");

//                String sResponseFromServer = tReader.ReadToEnd();
//                System.Console.WriteLine("donng 6\n");

//                tReader.Close();
//                dataStream.Close();
//                tResponse.Close();

//                if (sResponseFromServer != null)
//                {
//                    System.Console.WriteLine("donng 7\n");
//                    //log.writeLog($"{DateTime.Now.ToString("hh:mm:ss")}\nRequest: {jsonMessage}\nResponse: {sResponseFromServer}", "SendToPartnerWebhook_done.txt");
//                    return true;
//                }
//                else
//                {
//                    System.Console.WriteLine("donng 8\n");
//                    log.writeLog($"{DateTime.Now.ToString("hh:mm:ss")}\nRequest: {jsonMessage}\nError Response: {sResponseFromServer}", "SendToPartnerWebhook_error.txt");
//                    ConnectionMultiplexer redis = ConnectionMultiplexer.Connect(connectionString);
//                    IDatabase db = redis.GetDatabase();
//                    DuaVaoHangDoi(data, flag2, db);
//                    System.Console.WriteLine("donng 9\n");
//                    return false;
//                }
//            }
//            catch (Exception ex)
//            {
//                System.Console.WriteLine(ex.Message.ToString());
//                System.Console.WriteLine("donng 10\n");
//                return false;
//            }
//        }
//        public async Task<bool> SendToPartnerWebhook2(DataMessage data, string flag2, string connectionString = "127.0.0.1:6379")
//        {
//            GhiLog log = new GhiLog();
//            System.Console.WriteLine("donng 1\n");
//            try
//            {
//                if (data == null || data.config == null || data.data == null || string.IsNullOrWhiteSpace(data.config._url_hook) || string.IsNullOrWhiteSpace(data.config._authToken))
//                {
//                    return false;
//                }
//                System.Console.WriteLine("donng 2\n");

//                string url = data.config._url_hook;
//                var client = new HttpClient();
//                client.BaseAddress = new Uri("https://aship.tpos.vn/");
//                var request = new HttpRequestMessage(HttpMethod.Post, new Uri(url));
//                System.Console.WriteLine("donng 3\n");
//                //   request.Headers.Add("User-Agent", "PostmanRuntime/7.32.3");
//                //    request.Headers.Add("Content-Type", "application/json; charset=utf-8");
//                //    request.Headers.Add("Content-Type", "application/json");
//                if (data.config._url_hook.StartsWith("https", StringComparison.OrdinalIgnoreCase))
//                {
//                    System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3 | SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;

//                    System.Console.WriteLine("donng 4\n");
//                }
//                var ds = new PostWebhook
//                {
//                    data = data.data,
//                    token = data.config._authToken,
//                };
//                var jsonMessage = JsonConvert.SerializeObject(ds);
//                request.Content = new StringContent(jsonMessage, Encoding.UTF8, "application/json");
//                System.Console.WriteLine("donng 5\n");
//                var response = await client.SendAsync(request);

//                var resultStream = await response.Content.ReadAsStringAsync();
//                System.Console.WriteLine("donng 6\n");
//                switch (response.StatusCode)
//                {
//                    case HttpStatusCode.OK:
//                        System.Console.WriteLine("donng 7\n");
//                        log.writeLog($"{DateTime.Now.ToString("hh:mm:ss")}\nRequest: {jsonMessage}\nResponse: {resultStream}", "SendToPartnerWebhook_done.txt");
//                        return true;
//                    /*
//                     *  case HttpStatusCode.Unauthorized:
//            log.writeLog($"{DateTime.Now.ToString("hh:mm:ss")}\nRequest: {jsonMessage}\nError Response: {response.StatusCode}", "SendToPartnerWebhook_error.txt");
//            ConnectionMultiplexer redis = ConnectionMultiplexer.Connect(connectionString);
//            IDatabase db = redis.GetDatabase();
//            DuaVaoHangDoi(data, flag2, db);
//            return false;*/

//                    default:
//                        //System.Console.WriteLine("donng 8\n");
//                        log.writeLog($"{DateTime.Now.ToString("hh:mm:ss")}\nRequest: {jsonMessage}\nError Response: {response.StatusCode}", "SendToPartnerWebhook_error.txt");
//                        ConnectionMultiplexer redis = ConnectionMultiplexer.Connect(connectionString);
//                        IDatabase db = redis.GetDatabase();
//                        DuaVaoHangDoi(data, flag2, db);
//                        System.Console.WriteLine("donng 9\n");
//                        return false;
//                }
//            }
//            catch (Exception ex)
//            {
//                System.Console.WriteLine("donng 10\n");
//                log.writeLog($"{DateTime.Now.ToString("hh:mm:ss")}\n{ex.Message}", "SendToPartnerWebhook_error.txt");
//                return false;
//            }
//        }
//        public async Task<bool> SendToPartnerWebhook(DataMessage data, string flag2, string connectionString = "127.0.0.1:6379")
//        {
//            GhiLog log = new GhiLog();
//            var serializer = new JavaScriptSerializer();
//            serializer.RegisterConverters(new JavaScriptConverter[] { new DateTimeConverter() });
//            System.Console.WriteLine("donng 1\n");
//            try
//            {
//                if (data == null || data.config == null || data.config._url_hook == null || data.data == null || data.config._url_hook == null)
//                {
//                    return false;
//                }
//                System.Console.WriteLine("donng 2\n");
//                var requestUri = new Uri(data.config._url_hook);
//                var hostHeader = requestUri.Host;
//                string str = serializer.Serialize(data);
//                using (var httpClient = new HttpClient())
//                {
//                    httpClient.BaseAddress = new Uri("https://aship.tpos.vn/");
//                    System.Console.WriteLine("donng 3\n");
//                    if (data.config._url_hook.StartsWith("https", StringComparison.OrdinalIgnoreCase))
//                    {
//                        System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3 | SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;

//                    }
//                    httpClient.DefaultRequestHeaders.Add("Host", hostHeader); // Thêm Host

//                    var ds = new PostWebhook
//                    {
//                        data = data.data,
//                        token = data.config._authToken,
//                    };
//                    System.Console.WriteLine("donng 4\n");
//                    var jsonMessage = serializer.Serialize(ds);
//                    var request = new HttpRequestMessage(HttpMethod.Post, data.config._url_hook);

//                    // Đặt tiêu đề "Content-Type" cho nội dung yêu cầu HTTP
//                    //    request.Content.Headers.Add("Content-Type", "application/json");

//                    var content = new StringContent(jsonMessage, Encoding.UTF8, "application/json");
//                    System.Console.WriteLine("donng 5\n");
//                    // Gán nội dung cho yêu cầu HTTP
//                    request.Content = content;

//                    using (var response = await httpClient.SendAsync(request))
//                    {
//                        System.Console.WriteLine("donng 6\n");
//                        var res = await response.Content.ReadAsStringAsync();

//                        if (response.IsSuccessStatusCode)
//                        {
//                            System.Console.WriteLine("donng 7\n");
//                            log.writeLog($"{DateTime.Now.ToString("hh:mm:ss")}\nRequest: {jsonMessage}\nResponse: {res}", "SendToPartnerWebhook_done.txt");
//                            return true;
//                        }
//                        else
//                        {
//                            System.Console.WriteLine("donng 8\n");
//                            log.writeLog($"{DateTime.Now.ToString("hh:mm:ss")}\nRequest: {jsonMessage}\nError Response: {response.StatusCode}", "SendToPartnerWebhook_error.txt");
//                            ConnectionMultiplexer redis = ConnectionMultiplexer.Connect(connectionString);
//                            IDatabase db = redis.GetDatabase();
//                            DuaVaoHangDoi(data, flag2, db);
//                            System.Console.WriteLine("donng 9\n");
//                            return false;
//                        }

//                    }
//                }
//            }
//            catch (Exception ex)
//            {
//                System.Console.WriteLine("donng 10\n");
//                log.writeLog($"{DateTime.Now.ToString("hh:mm:ss")}\n{ex.Message.ToString()}", "SendToPartnerWebhook_error.txt");
//                return false;
//            }
//        }

//        /*
//        public async Task<bool> SendToPartnerWebhook(DataMessage data, string flag2, string connectionString = "127.0.0.1:6379")
//        {
//            GhiLog log = new GhiLog();
//            var serializer = new JavaScriptSerializer();
//            serializer.RegisterConverters(new JavaScriptConverter[] { new DateTimeConverter() });
//            try
//            {
//                string str = serializer.Serialize(data);
//                if (data != null && data.config != null && data.config.url_hook != null && data.data != null)
//                {
//                    var jsonMessage = serializer.Serialize(data.data);
//                    if (jsonMessage != null)
//                    {
//                        using (var httpClient = new HttpClient())
//                        {
//                            // Add the Authorization header with the bearer token
//                            httpClient.DefaultRequestHeaders.Add("Authorization", data.config._authToken);

//                            // Check if the URL contains "http://" or "https://" and adjust the request accordingly
//                            if (data.config.url_hook.StartsWith("https://", StringComparison.OrdinalIgnoreCase))
//                            {
//                                // For HTTPS, set the TLS protocol to TLS 1.2
//                                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
//                            }
//                            var content = new StringContent(jsonMessage, Encoding.UTF8, "application/json");
//                            using (var response = await httpClient.PostAsync(data.config.url_hook, content))
//                            {

                              
//                                if (response.IsSuccessStatusCode)
//                                {
//                                    var res = await response.Content.ReadAsStringAsync();
//                                    response.EnsureSuccessStatusCode();
//                                    log.writeLog($"{DateTime.Now.ToString("hh:mm:ss")}\nRequest: {jsonMessage}\nResponse: {res}", "SendToPartnerWebhook_done.txt");
//                                }
//                                else
//                                {
//                                    ConnectionMultiplexer redis = ConnectionMultiplexer.Connect(connectionString);
//                                    IDatabase db = redis.GetDatabase();
//                                    DuaVaoHangDoi(data, flag2, db);
//                                    log.writeLog($"{DateTime.Now.ToString("hh:mm:ss")}\n{jsonMessage}", "SendToPartnerWebhook_false.txt");
//                                    return false;
//                                }
//                                return true;
//                            }
//                        }
//                    }
//                }
//                return false;
//            }
//            catch (Exception ex)
//            {

//                var errorMessage = ex.Message.ToString() + $"{serializer.Serialize(data)}";
//                log.writeLog($"{DateTime.Now.ToString("hh:mm:ss")}\n{errorMessage}", "SendToPartnerWebhook.txt");
//                return false;
//            }
//        }*/
//        //public async Task<bool> SendToPartnerWebhook(DataMessage data)
//        //{
//        //    var serializer = new JavaScriptSerializer();
//        //    try
//        //    {
//        //        if (data != null && data.config != null && data.config.url_hook != null)
//        //        {
//        //            var jsonMessage = serializer.Serialize(data.data);

//        //            using (var httpClient = new HttpClient())
//        //            {
//        //                var content = new StringContent(jsonMessage, System.Text.Encoding.UTF8, "application/json");
//        //                // Add the Authorization header with the bearer token
//        //                httpClient.DefaultRequestHeaders.Add("Authorization", data.config._authToken);

//        //                // Check if the URL contains "http://" or "https://" and adjust the request accordingly
//        //                if (data.config.url_hook.StartsWith("https://", StringComparison.OrdinalIgnoreCase))
//        //                    // For HTTPS, set the TLS protocol to TLS 1.2
//        //                    ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
//        //                var response = await httpClient.PostAsync(data.config.url_hook, content);
//        //                if (response.IsSuccessStatusCode)
//        //                    //await db.ListRemoveAsync(xoa_cache, jsonMessage);
//        //                    return true;
//        //                return false;
//        //            }
//        //        }
//        //        return true;
//        //    }
//        //    catch (Exception ex)
//        //    {
//        //        GhiLog ghi = new GhiLog();
//        //        ghi.writeLog(ex.Message.ToString()+"\n"+ JsonConvert.SerializeObject(data), "SendToPartnerWebhook.txt");
//        //        return false;
//        //    }
//        //}
//    }
//    public class GhiLog
//    {
//        private static object lockObject = new object();

//        public void writeLog(string data, string filName)
//        {
//            try
//            {
//                DateTime dt = DateTime.Now;
//                string path = "C:\\MyLog\\" + dt.ToString("yyyy-MM-dd ") + filName;
//                // Sử dụng lock để đảm bảo chỉ một luồng được phép thực hiện ghi vào tệp tại một thời điểm.
//                lock (lockObject)
//                {
//                    using (StreamWriter sw = (File.Exists(path)) ? File.AppendText(path) : File.CreateText(path))
//                    {
//                        sw.WriteLine(data);
//                    }
//                }
//            }
//            catch
//            {
//                // Xử lý ngoại lệ ở đây
//            }
//        }
//    }
//}