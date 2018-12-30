using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SpaServices.ReactDevelopmentServer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SkillTeam.Models.Repository;
using SkillTeam.Models.Repository.Impl;

namespace SkillTeam
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
            //TODO: Configuração do mongodb, referencias: http://www.macoratti.net/17/11/aspncore_mongo1.htm
            DBContext.ConnectionString = Configuration.GetSection("MongoConnection:ConnectionString").Value;
            DBContext.DatabaseName = Configuration.GetSection("MongoConnection:Database").Value;
            DBContext.IsSSL = Convert.ToBoolean(this.Configuration.GetSection("MongoConnection:IsSSL").Value);

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            
            //TODO: Dependency Injection - referencia: http://www.macoratti.net/17/04/aspcore_di1.htm
            #region DI
            services.AddTransient<IEmployeeRepository, EmployeeRepositoryImpl>();
            #endregion
            
            // In production, the React files will be served from this directory
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp/build";
            });
            //TODO: Sagger Config, reference: https://docs.microsoft.com/pt-br/dotnet/standard/microservices-architecture/multi-container-microservice-net-applications/data-driven-crud-microservice
            #region configSwagger
            services.AddSwaggerGen(options =>
            {
                options.DescribeAllEnumsAsStrings();
                options.SwaggerDoc("v1", new Swashbuckle.AspNetCore.Swagger.Info{
                    Title = "SkillTeam - Api Doc"
                    , Version = "v1"
                    , Description = "Um projeto para conhecimentos de skills dos membros da empresa."
                    , TermsOfService = "Open Project"
                });
            });
            #endregion
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
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseSpaStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller}/{action=Index}/{id?}");
            });
            //TODO: Swagger Config - não colocar depois do SPA pq da erro
            #region Swagger
            app.UseSwagger().UseSwaggerUI(c => {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Api SkillTeam");
            });
            #endregion

            app.UseSpa(spa =>
            {
                spa.Options.SourcePath = "ClientApp";

                if (env.IsDevelopment())
                {
                    spa.UseReactDevelopmentServer(npmScript: "start");
                }
            });
            
        }
    }
}
