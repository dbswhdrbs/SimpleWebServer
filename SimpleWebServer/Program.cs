using Microsoft.Owin.Hosting;
using SimpleWebServer.Contents;
using SimpleWebServer.DBSQL;
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

        private void OnTestLogin()
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseAddress);
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                Account testLoginAccount = new Account()
                {
                    Uid = 1,
                    name = "Dori",
                    lastLoginData = System.DateTime.UtcNow,
                };

                //var task = client.PostAsJsonAsync<Account>("AAAA", testLoginAccount).ContinueWith(x => x.Result.Content.ReadAsAsync<bool>().Result);
                var task = client.PostAsJsonAsync<Account>("AAAA", testLoginAccount).Result;
            }
        }
    }
}
