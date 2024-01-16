using RedisBoost;
using System;

namespace RedisBus
{
	public interface IRedis : IDisposable
	{
		string ClientName { get; }
		void Connect(RedisConnectionStringBuilder connectionString);
		void SetAsync(string key, string value);
		void Set(string key, string value, int second = 60);
		string GetString(string key);
		void FlushDb();
		void IncrAsync(string KeyName);
		void KeyExpire(string KeyName, int seconds);
		int GetInt(string key);
		IRedis CreateOne();
	}
}
