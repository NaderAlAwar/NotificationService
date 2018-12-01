﻿using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace NotificationServiceApi
{
    public class WebServer
    {
        public static IWebHostBuilder CreateWebHostBuilder()
        {
            return WebHost.CreateDefaultBuilder()
                .UseStartup<Startup>();
        }
    }
}
