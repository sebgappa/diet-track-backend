using DietTrack.SuperMarket.Infrastructure.Filters;
using DietTrack.SuperMarket.Infrastructure.SimpleInjector;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SimpleInjector;

namespace DietTrack.SuperMarket
{
    public class Startup
    {
        private readonly Container _container = new Container();

        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc(option =>
            {
                option.Filters.Add<ApiExceptionFilter>();
            })
            .SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.AddSimpleInjector(_container, options =>
            {
                options.AddAspNetCore()
                    .AddControllerActivation();
            });

            string clientUrl = Configuration.GetValue<string>("ClientUrl");
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseSimpleInjector(_container, options =>
            {
                options.UseLogging();
                options.AutoCrossWireFrameworkComponents = true;
            });

            new ContainerBuilder(_container)
                .Build();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }
    }
}
