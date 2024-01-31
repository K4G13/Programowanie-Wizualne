using BLC;
using Interfaces;

namespace API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var libraryName = builder.Configuration.GetValue<string>("DAOLibraryName")!;
            BLC.BLC blc = new BLC.BLC(libraryName);
            blc.checkDBConnection();
            // Add services to the container.

            builder.Services.AddControllers();
            builder.Services.AddSingleton(typeof(IBLC), blc);
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

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
        }

    }
}
