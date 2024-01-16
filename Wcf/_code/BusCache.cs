using Dto;
using Dao;
using RedisBus;
using RedisBoost;
using System;
using System.Web.Script.Serialization;

namespace Wcf
{
    public class BusCache
    {
        public static bool IsCache = true;
        public string KeyName = "";
        public bool isDelete = false;
        public BaoCaoRedis testClient;
        public RedisConnectionStringBuilder _cs = new RedisConnectionStringBuilder(Conection._SERVER_REDIS);

        // Thiếu trường hợp xóa 1 các list vẫn còn
        // Thiếu trường hợp up date các list vẫn còn

        public BusCache()
        {

        }
        public void ClearAllCache()
        {
            KeyName = Conection.connStringBuilder.InitialCatalog;
            isDelete = true;
            if (isDelete)
            {
                using (testClient = new BaoCaoRedis())
                {
                    testClient.Connect(_cs);
                    testClient.DeleteKeysWithPrefix(KeyName);
                }
            }
        }
        public void ClearAllCacheByOject(_Dto dto)
        {
            KeyName = Conection.connStringBuilder.InitialCatalog + "-" + dto.Obj;
            isDelete = true;
            if (isDelete)
            {
                using (testClient = new BaoCaoRedis())
                {
                    testClient.Connect(_cs);
                    testClient.DeleteKeysWithPrefix(KeyName);
                }
            }
        }
        public void TaoName(_Dto obj)
        {
            KeyName = Conection.connStringBuilder.InitialCatalog + "-" + obj.ObjName + "-" + obj.ThaoTac + "-" + new _Dto().MD5(obj.Obj != null ? obj.Obj : "");
            isDelete = false;

        }
        public void XoaListCache(_Dto obj)
        {
            KeyName = Conection.connStringBuilder.InitialCatalog + "-" + obj.ObjName;
            isDelete = true;
        }
        public void XoaCacheByID(_Dto obj)
        {
            var jsonSerialiser = new JavaScriptSerializer();
            TableID o = jsonSerialiser.Deserialize<TableID>(obj.Obj);
            KeyName = $"{Conection.connStringBuilder.InitialCatalog}-{obj.ObjName}-{obj.ThaoTac}-{new _Dto().MD5((o.KeyID ?? "") + (o.ID ?? "") + (o.Ma ?? "") + (o.IDMaster ?? ""))}";
            isDelete = true;
        }

        public void TaoCacheByID(_Dto obj)
        {
            var jsonSerialiser = new JavaScriptSerializer();
            TableID o = jsonSerialiser.Deserialize<TableID>(obj.Obj);

            KeyName = $"{Conection.connStringBuilder.InitialCatalog}-{obj.ObjName}-{obj.ThaoTac}-{new _Dto().MD5((o.KeyID ?? "") + (o.ID ?? "") + (o.Ma ?? "") + (o.IDMaster ?? ""))}";

            isDelete = false;
        }

        public string LayCache(KetQua kq, string thaoTac)
        {
            if (IsCache)
            {
                try
                {
                    using (testClient = new BaoCaoRedis())
                    {
                        testClient.Connect(_cs);

                        if (isDelete)
                        {
                            testClient.DeleteKeysWithPrefix(KeyName);
                        }

                        kq.result = testClient.GetString(KeyName);
                        if (kq.result != null && kq.result.Trim() != "" && kq.result.Length > 10)
                        {
                            thaoTac = "";
                        }
                    }
                }
                catch (Exception ex)
                {
                    IsCache = false;
                }
            }
            return thaoTac;
        }
        public void SetCache(KetQua kq, int second = 30)
        {
            if (IsCache)
            {
                using (testClient = new BaoCaoRedis())
                {
                    testClient.Connect(_cs);
                    testClient.Set(KeyName, kq.result, second);
                }
            }
        }
        public void SysCache()
        {
            if (isDelete)
            {
                using (testClient = new BaoCaoRedis())
                {
                    testClient.Connect(_cs);
                    testClient.DeleteKeysWithPrefix(KeyName);
                }
            }
        }




    }
    public class TableID
    {
        public string KeyID { get; set; }
        public string ID { get; set; }
        public string IDMaster { get; set; }
        public string Ma { get; set; }
    }
}