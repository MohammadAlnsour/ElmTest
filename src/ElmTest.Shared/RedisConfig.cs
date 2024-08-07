using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StackExchange.Redis;

namespace ElmTest.Shared
{
    public static class RedisConfig
    {
        public static IServiceCollection AddRedisConfig(this IServiceCollection services, IConfiguration configuration)
        {
            var redisServer = configuration["redis:server"];
            var redisServerPassword = configuration["redis:password"];

            services.AddScoped<IDatabase>(cfg =>
             {
                 IConnectionMultiplexer multiplexer = ConnectionMultiplexer.Connect($"{redisServer}");
                 return multiplexer.GetDatabase();
             });
            return services;
        }


    }
}
