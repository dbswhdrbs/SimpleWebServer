using SimpleContents.SWAddress;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SimpleTestClient.Extensions
{
    public static class SendPacketEx
    {
        private static readonly string ServerUrl = "http://localhost:9010/";

        public static void SendPacket<T>(string requestUri, T sendData)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = new Uri(ServerUrl);

                    var response = client.PostAsJsonAsync(requestUri, sendData).Result;

                    if (response.IsSuccessStatusCode)
                    {
                        Console.WriteLine("[Success] Url : {0}, Status Code : {1}",
                            requestUri, response.StatusCode.ToString());
                    }
                    else
                    {
                        Console.WriteLine("[Error] Url : {0}, Status Code : {1}",
                            requestUri, response.StatusCode);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("[SendPacket] Exception : " + ex.ToString());
            }
        }
    }
}
