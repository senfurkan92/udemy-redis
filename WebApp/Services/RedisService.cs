using StackExchange.Redis;

namespace WebApp.Services
{
    public class RedisService
    {
        private readonly string Cstr;

        private ConnectionMultiplexer redis;

        public RedisService(IConfiguration config)
        {
            Cstr = config.GetConnectionString("Redis");
        }

        public void Connect ()
        { 
            redis = ConnectionMultiplexer.Connect(Cstr);
        }

        public IDatabase GetDb(int db)
        {
            if (!redis.IsConnected || redis.IsConnecting)
            {
                Connect(); 
            }
            return redis.GetDatabase(db);
        }
    }
}
