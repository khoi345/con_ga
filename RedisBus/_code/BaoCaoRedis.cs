using RedisBoost;
using ServiceStack.Redis.Pipeline;
using System;
using System.Linq;
using System.Net;
using System.Threading;

namespace RedisBus
{ 
    public class BaoCaoRedis : IRedis
    {

		private ServiceStack.Redis.RedisClient _client;
		private int _pipelineMode = 0;
		private IRedisPipeline _pipeline;
		public void Dispose()
		{
			if (_pipeline != null)
				_pipeline.Dispose();
			if (_client != null)
				_client.Dispose();
		}

		public string ClientName { get { return "servicestack"; } }
		public void Connect(RedisConnectionStringBuilder connectionString)
		{

			_client = new ServiceStack.Redis.RedisClient(((IPEndPoint)connectionString.EndPoint).Address.ToString(),
														 ((IPEndPoint)connectionString.EndPoint).Port);
		}

		public void SetAsync(string key, string value)
		{
			EnterPipeline();
			_pipeline.QueueCommand(c => c.Set(key, value));
		}

		private void EnterPipeline()
		{
			if (Interlocked.CompareExchange(ref _pipelineMode, 1, 0) == 0)
				_pipeline = _client.CreatePipeline();
		}

		private void LeavePipelining()
		{
			if (Interlocked.CompareExchange(ref _pipelineMode, 0, 1) == 1)
			{
				_pipeline.Flush();
				_pipeline.Dispose();
			}
		}

		public string GetString(string key)
		{
			LeavePipelining();
			return _client.Get<string>(key);
		}

		public void FlushDb()
		{
			LeavePipelining();
			_client.FlushDb();
		}

		public void IncrAsync(string KeyName)
		{
			EnterPipeline();
			_pipeline.QueueCommand(c => c.Increment(KeyName, 1));
		}

		public int GetInt(string key)
		{
			LeavePipelining();
			return _client.Get<int>(key);
		}

		public IRedis CreateOne()
		{
			return new ServiceStackTestClient();
		}

		public void KeyExpire(string KeyName, int seconds)
		{
			_client.Expire(KeyName, seconds);
		}

		public void Set(string key, string value, int second = 30)
		{
			LeavePipelining();
			_client.Set(key, value,DateTime.Now.AddSeconds(second));
		}
		public void Delete(string key)
		{
			LeavePipelining();
		//	_client.Set(key, value,DateTime.Now.AddSeconds(second));
			_client.Del(key);

		}
		public void DeleteKeysWithPrefix(string prefix)
		{
			if (_client != null)
			{
				var allKeys = _client.GetAllKeys();
				var keysToDelete = allKeys.Where(k => k.StartsWith(prefix)).ToList();
				if (keysToDelete.Any())
				{
					foreach (var key in keysToDelete)
					{
						_client.RemoveEntry(key);
					}
					Console.WriteLine($"Đã xóa {keysToDelete.Count} khóa có tiền tố '{prefix}'");
				}
				else
				{
					Console.WriteLine($"Không tìm thấy khóa nào có tiền tố '{prefix}'");
				}
			}
		}

	}
}
