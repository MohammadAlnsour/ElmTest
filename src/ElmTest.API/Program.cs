using ElmTest.Application;
using ElmTest.Application.Requests;
using ElmTest.Application.Validators;
using ElmTest.Domain.Factories;
using ElmTest.Infrastructure.Dapper;
using FluentValidation;
using System;
using ElmTest.Infrastructure;
using ElmTest.API.Middlewares;
using Serilog;
using ElmTest.Shared.Config;

namespace ElmTest.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            var config = new ConfigurationBuilder()
                            .AddJsonFile("appsettings.json", optional: false)
                            .Build();

            // Add services to the container.
            builder.Services.AddCors();
            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddAutoMapper(typeof(ApiMapperProfile));
            builder.Services.AddMediatr();
            builder.Services.AddScoped<IBookFactory, BookFactory>();
            builder.Services.AddScoped<IValidator<CreateBookRequest>, CreateBookRequestValidator>();
            builder.Services.AddDbServices();
            builder.Services.AddRedisConfig(config);
            builder.AddSerilogConfig(config);

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseRouting();

            app.UseSerilogRequestLogging();

            //app.UseCors(x => x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

            app.UseCors(builder => builder
               .AllowAnyHeader()
               .AllowAnyMethod()
               .SetIsOriginAllowed((host) => true)
               .AllowCredentials()
               );

            //app.UseAuthentication();
            //app.UseAuthorization();
            app.MapControllers();
            app.UseApiKeyMiddleware();
            app.UseErrorLogMiddleware();

            app.Run();
        }
    }
}
