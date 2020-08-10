using Dapper.Domain.StoreContext.Handlers;
using Dapper.Domain.StoreContext.Repositories;
using Dapper.Infra.Repositories;
using Dapper.Infra.StoreContext.DataContext;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace Dapper.Api
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddResponseCompression();

            services.AddMvc();
            services.AddScoped<DataContext,DataContext>();
            services.AddTransient<ICustomerRepository,CustomerRepository>();
            services.AddTransient<CustomerHandler,CustomerHandler>();

            services.AddSwaggerGen(x=> {
                x.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo {Title="Balta Store", Version = "v1"});
            });
            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            
            
            app.UseMvc();

            app.UseResponseCompression();

            app.UseSwagger();
            app.UseSwaggerUI(c => {
                c.SwaggerEndpoint("/swagger/v1/swagger.json","Balta stpre - V1");
            });
            

        }
    }
}
