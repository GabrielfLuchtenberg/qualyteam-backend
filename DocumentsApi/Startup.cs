using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using DocumentsApi.Models;
using Newtonsoft.Json;
using DocumentsApi.Middlewares;
using DocumentsApi.Services;
namespace DocumentsApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IDocumentService,DocumentService>();
            string connectionString = "";
            if(Environment.GetEnvironmentVariable("DB_CONNECTION_STRING")!= null){
                connectionString = Environment.GetEnvironmentVariable("DB_CONNECTION_STRING");
            }else{
                connectionString = Configuration.GetConnectionString("DocumentsDatabase");

            }
            // docker container exec -i $(docker-compose ps -q postgres) psql exampledatabase < exampledata.sql
            // services.AddDbContext<DatabaseContext>(opt => opt.UseNpgsql(Configuration.GetConnectionString("DocumentsDatabase")));
            services.AddDbContext<DatabaseContext>(opt => opt.UseNpgsql(connectionString));
            services.AddMvc().AddJsonOptions(options =>
            {
                options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            }).SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseMiddleware<ApiExceptionHandler>();
            // app.UseHttpsRedirection();
            app.UseCors(C => C.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());
            app.UseMvc();
        }
    }
}
