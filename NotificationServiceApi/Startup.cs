using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Azure.ServiceBus;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace NotificationServiceApi
{
    public class Startup
    {

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            var config = Configuration.GetSection(typeof(NotificationServiceSettings).Name);
            NotificationServiceSettings settings = new NotificationServiceSettings();
            config.Bind(settings);

            IQueueClient client = new QueueClient(settings.ServiceBusConnectionString, settings.QueueName);
            services.AddSingleton<IQueueClient>(client);

            services.AddOptions();
            services.AddLogging();
            services.AddMvc();
            services.AddSignalR();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                loggerFactory.AddConsole();
                loggerFactory.AddDebug();
            }

            app.UseSignalR(routes =>
            {
                routes.MapHub<NotificationHub>("/notificationHub");
            });
            app.UseMvc();
        }
    }
}
