using RedisBoost;
using System;

namespace RedisBus
{
	public class RedisBoostTestClient: IRedis
	{
		private IRedisClient _client;
		public void Dispose()
		{
			if (_client!=null)
				_client.Dispose();
		}

		public void Connect(RedisConnectionStringBuilder connectionString)
		{
			try
			{
				_client = RedisClient.ConnectAsync(connectionString.EndPoint, connectionString.DbIndex).Result;
			}
			catch (Exception ex)
			{
				throw ex;
			}

		}

		public void SetAsync(string key, string value)
		{
			_client.SetAsync(key, value);
		}

		public string GetString(string key)
		{
			return _client.GetAsync(key).Result.As<string>();
		}

		public void FlushDb()
		{
			_client.FlushDbAsync().Wait();
		}
		
		public string ClientName
		{
			get { return "redisboost"; }
		}
		public void IncrAsync(string key)
		{
			_client.IncrAsync(key);
		}

		public int GetInt(string key)
		{
			return _client.GetAsync(key).Result.As<int>();
		}

		public IRedis CreateOne()
		{
			return new RedisBoostTestClient();
		}

		public void Set(string key, string value)
		{
			_client.SetAsync(key, value).Wait();
		}

	

		public void KeyExpire(string KeyName, int seconds)
		{
			_client.ExpireAsync(KeyName, seconds);
		}

		public void KeyExpire(string KeyName, TimeSpan time)
		{
			throw new NotImplementedException();
		}

		public void Set(string key, string value, int second = 60)
		{
			throw new NotImplementedException();
		}
	}
}
