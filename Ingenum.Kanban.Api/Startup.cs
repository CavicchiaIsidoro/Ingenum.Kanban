using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ingenum.Kaban.Business.Repository;
using Ingenum.Kanban.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Ingenum.Kanban.Api
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
            
            //For LocalDB use "Local" For SqlServer use "SqlServer"
            var connectionString = Configuration.GetConnectionString("Local");

            services.AddDbContext<IngenumKanbanContext>(options =>
                options.UseSqlServer(connectionString, c => c.MigrationsAssembly("Ingenum.Kanban.Data")));

            services.AddTransient<BoardRepository>();
            services.AddTransient<TaskReposiroty>();

            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            CreateDB(app);            

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

        /// <summary>
        /// Create Database if doesn't exist
        /// </summary>
        /// <param name="app"></param>
        private void CreateDB(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetRequiredService<IngenumKanbanContext>();
                context.Database.EnsureCreated();
            }
        }
    }
}
