using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Serialization;
using System.Data.Common;
using System.Data.SqlClient;
using TeamBlackHatsAPI.Models;

namespace TeamBlackHatsAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {

            // Load environment variables
            DotEnvReader dotEnvReader = new DotEnvReader();
            bool dotEnvOk = dotEnvReader.LoadEnv();
            if (!dotEnvOk)
            {
                Console.WriteLine("Environment variable file not found or contains bad syntax. Ignoring...");
            }

            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            

            //JSON Serializer
            builder.Services.AddControllers().AddNewtonsoftJson(options=>options.SerializerSettings.ReferenceLoopHandling=Newtonsoft.Json.ReferenceLoopHandling.Ignore).AddNewtonsoftJson( 
                options=>options.SerializerSettings.ContractResolver=new DefaultContractResolver());

            // generate connection string
            var stringBuilder = new SqlConnectionStringBuilder();
            string? dbLocation = Environment.GetEnvironmentVariable("DB_LOCATION");
            string? dbUsername = Environment.GetEnvironmentVariable("DB_USERNAME");
            string? dbPassword = Environment.GetEnvironmentVariable("DB_PASSWORD");
            string? dbCatalog = Environment.GetEnvironmentVariable("DB_CATALOG");

            if (dbLocation == null) { dbLocation = "localhost"; }
            if (dbUsername == null) { dbUsername = "username"; }
            if (dbPassword == null) { dbPassword = "password"; }
            if (dbCatalog == null) { dbCatalog = "catalog"; }

            stringBuilder.DataSource = dbLocation;
            stringBuilder.UserID = dbUsername;
            stringBuilder.Password = dbPassword;
            stringBuilder.InitialCatalog = dbCatalog;
            stringBuilder.TrustServerCertificate = true;

            // use sql server
            builder.Services.AddDbContext<UserContext>(
                    options => options.UseSqlServer(stringBuilder.ConnectionString)
                );

            // Connect to the database
            NFLDBConnection.Connect(); // may raise exception if database didn't connect. let the program crash if so

            var app = builder.Build();

            //Enable CORS
            app.UseCors(c => c.AllowAnyHeader().AllowAnyOrigin().AllowAnyMethod());

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();

            NFLDBConnection.Disconnect();
        }
    }
}