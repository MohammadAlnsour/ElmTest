using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Serilog;

namespace ElmTest.Shared.Config
{
    public static class SerilogConfig
    {
        public static WebApplicationBuilder AddSerilogConfig(this WebApplicationBuilder builder, IConfiguration configuration)
        {
            builder.Host.UseSerilog((context, configuration) => configuration.ReadFrom.Configuration(context.Configuration));
            return builder;
        }
    }
}
