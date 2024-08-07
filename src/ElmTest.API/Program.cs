using ElmTest.Application;
using ElmTest.Application.Requests;
using ElmTest.Application.Validators;
using ElmTest.Domain.Factories;
using ElmTest.Infrastructure.Dapper;
using FluentValidation;
using System;
using ElmTest.Infrastructure;

namespace ElmTest.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddAutoMapper(typeof(ApiMapperProfile));
            builder.Services.AddMediatr();
            builder.Services.AddScoped<IBookFactory,  BookFactory>();
            builder.Services.AddScoped<IValidator<CreateBookRequest>, CreateBookRequestValidator>();
            builder.Services.AddDbServices();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }


           
            app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseRouting();
            app.UseAuthorization();
            app.UseCors(x => x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
            app.MapControllers();

            app.Run();
        }
    }
}
