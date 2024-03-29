using KanjiLearn.Server.Data;
using KanjiLearn.Server.Services.KanjiService;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

namespace KanjiLearn.Server
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var connectionStringKanjiLearnDatabaseMSSQL = builder.Configuration.GetConnectionString("DefaultKanjiLearnDatabaseMSSQL");

            // Add services to the container.

            builder.Services.AddControllers();

            builder.Services.AddDbContext<KanjiLearnContext>(
                    options =>
                    {
                        options.UseSqlServer(connectionStringKanjiLearnDatabaseMSSQL).LogTo(Console.WriteLine, LogLevel.Information);
                        options.EnableSensitiveDataLogging();
                    }
               );

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddAutoMapper(typeof(Program).Assembly);
            builder.Services.AddScoped<IKanjiService, KanjiService>();

            builder.Services.AddControllers().AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
            });

            var app = builder.Build();

            app.UseDefaultFiles();
            app.UseStaticFiles();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.MapFallbackToFile("/index.html");

            app.Run();
        }
    }
}
