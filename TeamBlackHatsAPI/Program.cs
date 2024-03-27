
using Newtonsoft.Json.Serialization;
using System.Data.Common;

namespace TeamBlackHatsAPI
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
            

            //JSON Serializer
            builder.Services.AddControllers().AddNewtonsoftJson(options=>options.SerializerSettings.ReferenceLoopHandling=Newtonsoft.Json.ReferenceLoopHandling.Ignore).AddNewtonsoftJson( 
                options=>options.SerializerSettings.ContractResolver=new DefaultContractResolver());


            // Load environment variables
            DotEnvReader dotEnvReader = new DotEnvReader();
            bool dotEnvOk = dotEnvReader.LoadEnv();

            // Create database connection
            if (!dotEnvOk)
            {
                Console.WriteLine("Environment variable file not found or contains bad syntax. Ignoring...");
            }

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