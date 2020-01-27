using Calc.Api.Operations;
using Calc.Api.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Calc.Api
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddScoped<IOperationsMapCreator, OperationsMapCreator>();
            services.AddScoped<ICalculator,SimpleCalculator>();
            services.AddScoped<IPostCalculationProcessor, PostCalculationProcessor>();

            services.AddCors(c =>
            {
                c.AddPolicy("AllowOriginPolicy", builder => builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod().Build());
            });


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
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseCors("AllowOriginPolicy");
            app.UseMvc();
        }
    }
}
