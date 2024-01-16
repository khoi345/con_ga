using System;
using System.Net;
using BookSleeve;
using RedisBoost;

namespace RedisBus
{
	public class BookSleeveTestClient: IRedis
	{
		private RedisConnection _client;
		private int _dbIndex;
		public void Dispose()
		{
			if (_client!=null)
				_client.Dispose();
		}

		public void Connect(RedisConnectionStringBuilder connectionString)
		{
			_client = new RedisConnection(((IPEndPoint) connectionString.EndPoint).Address.ToString(), allowAdmin: true);
			_client.Open();
			_dbIndex = connectionString.DbIndex;
		}

		public void SetAsync(string key, string value)
		{
			_client.Strings.Set(_dbIndex, key, value);
		}

		public string GetString(string key)
		{
			return _client.Strings.GetString(_dbIndex, key).Result;
		}

		public void FlushDb()
		{
			_client.Server.FlushDb(_dbIndex).Wait();
		}

		public string ClientName
		{
			get { return "booksleeve"; }
		}

		public void IncrAsync(string key)
		{
			_client.Strings.Increment(_dbIndex, key);
		}

		public int GetInt(string key)
		{
			return (int)_client.Strings.GetInt64(_dbIndex, key).Result;
		}

		public IRedis CreateOne()
		{
			return new BookSleeveTestClient();
		}

		public void KeyExpire(string KeyName, TimeSpan time)
		{
			throw new NotImplementedException();
		}

		public void KeyExpire(string KeyName, int seconds)
		{
			throw new NotImplementedException();
		}
		public void Set(string key, string value, int second = 60)
		{
			_client.Strings.Set(_dbIndex, key, value,second).Wait();
		}
	}
}
