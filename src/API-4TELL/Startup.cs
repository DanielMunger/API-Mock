using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using API_4TELL.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace API_4TELL
{
    public class Startup
    {
        public IConfigurationRoot Configuration { get; set; }
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json");
            Configuration = builder.Build();
        }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddEntityFramework()
                .AddDbContext<ApplicationContext>(options =>
                    options.UseSqlServer(Configuration["ConnectionStrings:DefaultConnection"]));
            services.AddMvc();

           
        }


        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseMvc();
            env.EnvironmentName = EnvironmentName.Production;
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/error");
            }
        }
    }
}
