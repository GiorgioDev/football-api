using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Santex_Football.Application;
using Santex_Football.Application.Mapper;
using Santex_Football.Application.Services;
using Santex_Football.Database;
using Santex_Football.Infrastructure.Repositories;

namespace Santex_Football
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
            services.AddMvc();
            SetupApplicationDependencies(services);
            SetupInfraestructureDependencies(services);
            SetupDB(services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }

        private void SetupDB(IServiceCollection services)
        {
            
            var connection = Configuration.GetConnectionString("FootballConnection");
            services.AddDbContext<LeagueContext>(options => options.UseSqlServer(connection, b => b.MigrationsAssembly("Santex-Football.Web")));
        }

        private void SetupApplicationDependencies(IServiceCollection services)
        {
            services.AddScoped<ILeagueService, LeagueService>();
            services.AddScoped<IImportService, ImportService>();
            services.AddScoped<IMapper, Mapper>();
            services.AddScoped<IPersistenceService, PersistenceService>();
        }
        private void SetupInfraestructureDependencies(IServiceCollection services)
        {
            services.AddScoped<ILeagueCodeRepository, LeagueCodeRepository>();
            services.AddScoped<ILeagueRepository, LeagueRepository>();
            services.AddScoped<IPlayersRepository, PlayersRepository>();
        }
    }
}
