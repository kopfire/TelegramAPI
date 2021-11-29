using Hangfire;
using Hangfire.Mongo;
using Hangfire.Mongo.Migration.Strategies;
using Hangfire.Mongo.Migration.Strategies.Backup;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MongoDB.Driver;
using TelegramAPI.Helpers.Parser;
using TelegramAPI.Repository;
using TelegramAPI.Repository.Impl;
using testAPI.Attributes;

namespace testAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        public void ConfigureServices(IServiceCollection services)
        {

            var mongoUrlBuilder = new MongoUrlBuilder("mongodb://localhost:27017/Telegram");
            var mongoClient = new MongoClient(mongoUrlBuilder.ToMongoUrl());

            services.AddScoped<ICitiesRepository, CitiesRepository>();
            services.AddScoped<ICountriesRepository, CountriesRepository>();
            services.AddScoped<IFacultiesRepository, FacultiesRepository>();
            services.AddScoped<ISpecialtiesRepository, SpecialtiesRepository>();
            services.AddScoped<ITimeTableRepository, TimeTablesRepository>();
            services.AddScoped<IUniversitiesRepository, UniversitiesRepository>();
            services.AddScoped<IUsersRepository, UsersRepository>();

            // Add Hangfire services. Hangfire.AspNetCore nuget required
            services.AddHangfire(configuration => configuration
                .SetDataCompatibilityLevel(CompatibilityLevel.Version_170)
                .UseSimpleAssemblyNameTypeSerializer()
                .UseRecommendedSerializerSettings()
                .UseMongoStorage(mongoClient, mongoUrlBuilder.DatabaseName, new MongoStorageOptions
                {
                    MigrationOptions = new MongoMigrationOptions
                    {
                        MigrationStrategy = new MigrateMongoMigrationStrategy(),
                        BackupStrategy = new CollectionMongoBackupStrategy()
                    },
                    Prefix = "hangfire.mongo",
                    CheckQueuedJobsStrategy = CheckQueuedJobsStrategy.TailNotificationsCollection,
                    CheckConnection = true
                    
            })
            );
            // Add the processing server as IHostedService
            services.AddHangfireServer(serverOptions =>
            {
                serverOptions.ServerName = "Hangfire.Mongo server 1";
            });


            services.AddControllersWithViews();

            services.AddMvc(options =>
            {
                options.Filters.Add(typeof(ApiExceptionFilterAttribute));
            });
            
            services.AddControllersWithViews();
        }

        

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
            
            app.UseHangfireDashboard();

            RecurringJob.AddOrUpdate("easyjob", () => ASU.Pars(), "0 0 20 * * ?");
        }
    }
}
