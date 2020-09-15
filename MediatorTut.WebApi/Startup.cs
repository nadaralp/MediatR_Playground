using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatorTut.Services;
using MediatorTut.WebApi.Infrastructure;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace MediatorTut.WebApi
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

            // Exposes http context accessor in the DI Container with IHttpContextAccessor
            services.AddHttpContextAccessor();

            // To add Pipe for mediator
            services.AddScoped(typeof(IPipelineBehavior<,>), typeof(UserIdPipe<,>));
            // if you have multiple pipes. Add them in order top to bottom you need them. Same as middleware
            //services.AddScoped(typeof(IPipelineBehavior<,>), typeof(UserIdPipe<,>));

            // Provide the assembly where your handlers live. The important bit is the handlers.
            services.AddMediatR(typeof(HandlersAssemblyReference).Assembly);

            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
