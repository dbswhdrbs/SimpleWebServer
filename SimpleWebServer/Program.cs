using Microsoft.Owin.Hosting;
using SimpleContents;
using SimpleContents.SWAddress;
using System;
using System.Net.Http;

namespace SimpleWebServer
{
    public class Program
    {
        private static string baseAddress
        {
            get
            {
                return string.Format("http://{0}:{1}/",
                    Properties.Settings.Default.BASE_ADDRESS,
                    Properties.Settings.Default.PORT);
            }
        }

        static void Main(string[] args)
        {
            using (WebApp.Start<Startup>(url: baseAddress))
            {
                Console.WriteLine("[Simple Web Server] Start . . .");

                Console.ReadLine();
            }
        }
    }
}
