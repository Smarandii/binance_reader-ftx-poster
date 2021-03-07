using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace binance_reader_ftx_poster
{
    class FTXclient
    {
        private Uri BASE_URL = new Uri("https://ftx.com/api/");
        private string api_key;
        private string api_secret;
        private string sub_account;
        JavaScriptSerializer json_serializer = new JavaScriptSerializer();

        FTXclient (string api_key, string api_secret, string sub_account = "") {
            this.api_key = api_key;
            this.api_secret = api_secret;
            this.sub_account = sub_account;
        }

        private HttpRequestMessage sing_request(HttpRequestMessage request, string paramet) {

            var _nonce = (DateTime.UtcNow - DateTime.Parse("01/01/1970")).TotalMilliseconds.ToString().Remove(13, 3);
            double timestamp = System.Convert.ToDouble(_nonce);
            var hashMaker = new HMACSHA256(Encoding.UTF8.GetBytes(this.api_secret));
            var signaturePayload = $"{timestamp}{request.Method.ToString().ToUpper()}{request.RequestUri}{paramet}";
            var hash = hashMaker.ComputeHash(Encoding.UTF8.GetBytes(signaturePayload));
            var hashString = BitConverter.ToString(hash).Replace("-", string.Empty);
            var signature = hashString.ToLower();
            request.Headers.Add("FTX-KEY", this.api_key);
            request.Headers.Add("FTX-SIGN", signature);
            request.Headers.Add("FTX-TS", timestamp.ToString());
            return request;
        }

        private void send_request(HttpRequestMessage request, string paramet = "") {

            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = BASE_URL;
                if (request.Method == HttpMethod.Get) {
                    send_get_request(request, client, paramet);
                }
                if (request.Method == HttpMethod.Post)
                {
                    send_post_request(request, client, paramet);
                }
                if (request.Method == HttpMethod.Delete)
                {
                    send_delete_request(request, client, paramet);
                }

            }
        }

        async private void send_get_request(HttpRequestMessage request, HttpClient client, string paramet = "") {
            using (HttpResponseMessage response = await client.GetAsync(request.RequestUri))
            {
                Console.WriteLine(response.StatusCode.ToString());   
                using (HttpContent content = response.Content)
                {
                    Console.WriteLine("READING:");
                    Console.WriteLine(await content.ReadAsStringAsync());

                }

            }
        }
        async private void send_post_request(HttpRequestMessage request, HttpClient client, string paramet = "") {



            using (HttpResponseMessage response = await client.PostAsync(request.RequestUri, paramet))
            {
                Console.WriteLine(response.StatusCode.ToString());
                using (HttpContent content = response.Content)
                {
                    Console.WriteLine("READING:");
                    Console.WriteLine(await content.ReadAsStringAsync());

                }

            }
        }
        async private void send_delete_request(HttpRequestMessage request, HttpClient client, string paramet = "") {
            using (HttpResponseMessage response = await client.DeleteAsync(request.RequestUri))
            {
                Console.WriteLine(response.StatusCode.ToString());
                using (HttpContent content = response.Content)
                {
                    Console.WriteLine("READING:");
                    Console.WriteLine(await content.ReadAsStringAsync());

                }

            }
        }


        private HttpRequestMessage request(HttpMethod method, string path, string paramet = "") {
            var request = new HttpRequestMessage(method, path);
            request = sing_request(request, paramet);
            send_request(request);


            return request;
        }
    }
}
