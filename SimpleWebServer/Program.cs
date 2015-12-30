using Microsoft.Owin.Hosting;
using SimpleContents;
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
                OnTestLogin();

                Console.ReadLine();
            }
        }

        /// <summary>
        /// 테스트 로그인 함수
        /// HttpClient 로 커스텀한 함수를 호출하여, 응답받는 코드
        /// </summary>
        public static void OnTestLogin()
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseAddress);

                AccountData testLoginAccount = new AccountData()
                {
                    Uid = 1,
                    name = "Dori",
                    lastLoginData = System.DateTime.UtcNow,
                };

                var response = client.PostAsJsonAsync("Account/OnRequestLogin", testLoginAccount).Result;

                Console.WriteLine(response);
            }
        }
    }
}
