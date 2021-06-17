using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Mvc.Formatters;
using webapiejemplo.Context;
using Microsoft.EntityFrameworkCore;
using webapiejemplo.Services;

namespace apiWeb
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers(action => {
                action.ReturnHttpNotAcceptable = true;
                
            }).AddXmlDataContractSerializerFormatters()
            .AddNewtonsoftJson();
            string connectionString = "Server=127.0.0.1; Port=5432; Database=movie; User Id=Andres; Password=1234;";
            services.AddDbContext<MovieInfoContext>( o =>
            {
                o.UseNpgsql(connectionString);
            });
            services.AddScoped<IMovieInfoRepository, MovieRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
