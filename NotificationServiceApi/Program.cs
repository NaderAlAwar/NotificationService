using Microsoft.AspNetCore.Hosting;


namespace NotificationServiceApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            WebServer.CreateWebHostBuilder().Build().Run();
        }
    }
}
