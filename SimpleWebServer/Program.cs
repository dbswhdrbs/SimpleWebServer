using Microsoft.Owin.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SimpleWebServer
{
    public class Program
    {
        private static string baseAddress
        {
            get
            {
                return string.Format("{0}:{1}",
                    Properties.Settings.Default.BASE_ADDRESS,
                    Properties.Settings.Default.PORT);
            }
        }

        static void Main(string[] args)
        {
            using (WebApp.Start<Startup>(url: baseAddress))
            {
            }
        }
    }
}
