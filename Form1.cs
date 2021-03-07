using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Binance.Net;
using Binance.Net.Enums;
using Binance.Net.Objects;
using Binance.Net.Objects.Spot;
using CryptoExchange.Net.Authentication;
using CryptoExchange.Net.Logging;
using CryptoExchange.Net.Objects;
using Binance.Net.Objects.Spot.MarketData;
using System.Net.Http;
using System.Security.Cryptography;
using System.IO;
using System.Net;

namespace binance_reader_ftx_poster
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }
        private void change_status() {
            if (this.status_label.Text == "INACTIVE")
            {
                this.status_label.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
                this.status_label.Text = "ACTIVE";

                
            }
            else {
                this.status_label.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
                this.status_label.Text = "INACTIVE";
            }
        }

        private decimal calculateOrderPrice() {
            return System.Convert.ToDecimal(this.binanceBID.Text) * System.Convert.ToDecimal(this.coeff_form.Text);
        }

        private decimal getBestBinanceBid(BinanceClient client, string symbol) {
            WebCallResult<BinanceOrderBook> ordr_book = client.FuturesCoin.Market.GetOrderBook(symbol);
            decimal best_bid = 0;
            //Console.WriteLine(ordr_book.Error.Code.Value.ToString());
            foreach (var bid in ordr_book.Data.Bids)
                if (best_bid < bid.Price)
                    best_bid = bid.Price;
            return best_bid;
        }

        private HttpRequestMessage prepare_ftx_request(HttpMethod method, string endpoint, string paramet) {
            var request = new HttpRequestMessage(method, endpoint);
            var _nonce = (DateTime.UtcNow - DateTime.Parse("01/01/1970")).TotalMilliseconds.ToString().Remove(13, 3);
            double timestamp = System.Convert.ToDouble(_nonce);
            var hashMaker = new HMACSHA256(Encoding.UTF8.GetBytes(this.apiSecretFTX.Text));
            var signaturePayload = $"{timestamp}{method.ToString().ToUpper()}/api/orders{paramet}";
            var hash = hashMaker.ComputeHash(Encoding.UTF8.GetBytes(signaturePayload));
            var hashString = BitConverter.ToString(hash).Replace("-", string.Empty);
            var signature = hashString.ToLower();
            request.Headers.Add("FTX-KEY", this.apiKeyFTX.Text);
            request.Headers.Add("FTX-SIGN", signature);
            request.Headers.Add("FTX-TS", timestamp.ToString());

            return request;
        }

        async private void place_ftx_limit_order() {
            var method = HttpMethod.Post;
            var endpoint = $"/orders";
            string paramet = "{\"market\": \"BTC/USD\", \"side\": \"buy\", \"price\": " + calculateOrderPrice().ToString() + ", \"size\": 0.001, \"type\": \"limit\", \"reduceOnly\": false, \"ioc\": false, \"postOnly\": false, \"clientId\": null}";

            HttpRequestMessage request = prepare_ftx_request(method, endpoint, paramet);

            using ( HttpClient client = new HttpClient() ) {
                client.BaseAddress = new Uri("https://ftx.com/api");
                using (HttpResponseMessage response = await client.PostAsync(request.RequestUri, request.Content)) {
                    Console.WriteLine(request.Headers.ToString());
                    Console.WriteLine(response.StatusCode.ToString());
                    using (HttpContent content = response.Content) {
                        Console.WriteLine("READING:");
                        Console.WriteLine(await content.ReadAsStringAsync());
                    }
                
                }
                
            }

        }

        async private void test_request() {
            var method = HttpMethod.Post;
            var endpoint = "orders";
            //string paramet = "";
            string paramet = "{\"market\": \"BTC/USD\", \"side\": \"buy\", \"price\": " + calculateOrderPrice().ToString() + ", \"size\": 0.0001, \"type\": \"limit\", \"reduceOnly\": false, \"ioc\": false, \"postOnly\": false, \"clientId\": null}";
            var request = new HttpRequestMessage(method, endpoint);
            var _nonce = (DateTime.UtcNow - DateTime.Parse("01/01/1970")).TotalMilliseconds.ToString().Remove(13, 3);
            double timestamp = System.Convert.ToDouble(_nonce);
            var hashMaker = new HMACSHA256(Encoding.UTF8.GetBytes(this.apiSecretFTX.Text));
            var signaturePayload = $"{timestamp}{method.ToString().ToUpper()}{endpoint}{paramet}";
            var hash = hashMaker.ComputeHash(Encoding.UTF8.GetBytes(signaturePayload));
            var hashString = BitConverter.ToString(hash).Replace("-", string.Empty);
            var signature = hashString.ToLower();
            request.Headers.Add("FTX-KEY", this.apiKeyFTX.Text);
            request.Headers.Add("FTX-SIGN", signature);
            request.Headers.Add("FTX-TS", timestamp.ToString());

            


            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://ftx.com/api/");
                using (HttpResponseMessage response = await client.GetAsync(request.RequestUri))
                {
                    Console.WriteLine(request.Headers.ToString());
                    Console.WriteLine(response.StatusCode.ToString());
                    Console.WriteLine(response.GetType());
                    using (HttpContent content = response.Content)
                    {
                        Console.WriteLine("READING:");
                        Console.WriteLine(await content.ReadAsStringAsync());
                        
                    }

                }

            }
        }

        async private void cancel_ftx_orders() {
            var method = HttpMethod.Delete;
            var endpoint = "/orders";
            string paramet = "\"market\": \"BTC/USD\"";
            HttpRequestMessage request = prepare_ftx_request(method, endpoint, paramet);
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://ftx.com/api");
                using (HttpResponseMessage response = await client.DeleteAsync(request.RequestUri))
                {
                    Console.WriteLine(request.Headers.ToString());
                    Console.WriteLine(response.StatusCode.ToString());
                    Console.WriteLine((await response.Content.ReadAsStringAsync()).ToString());
                    using (HttpContent content = response.Content)
                    {
                        Console.WriteLine("READING:");
                        Console.WriteLine(content.ReadAsStringAsync());
                    }

                }

            }

        }

        private void start_button_Click(object sender, EventArgs e)
        {
            try { 
            using (var client = new BinanceClient(new BinanceClientOptions{ApiCredentials = new ApiCredentials(this.apiKeyBinance.Text, this.apiSecretBinance.Text)}))
            {
                 
                this.status_label.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
                this.binanceBID.Text = getBestBinanceBid(client, "BTCUSD_210326").ToString();
                place_ftx_limit_order();
                this.status_label.Text = "ACTIVE";




                }
            }
            catch (System.ArgumentException) {
                this.apiKeyBinance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
                this.apiSecretBinance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            }
            test_request();
        }

        private void stop_button_Click(object sender, EventArgs e)
        {
            this.status_label.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            cancel_ftx_orders();
            this.status_label.Text = "INACTIVE";
        
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void apiKeyBinance_TextChanged(object sender, EventArgs e)
        {
            Console.WriteLine(this.apiKeyBinance.Text);
            this.apiKeyBinance.BackColor = System.Drawing.Color.Snow;
            this.apiSecretBinance.BackColor = System.Drawing.Color.Snow;

        }

        private void apiKeyFTX_TextChanged(object sender, EventArgs e)
        {
            Console.WriteLine(this.apiKeyFTX.Text);
        }

        private void apiSecretBinance_TextChanged(object sender, EventArgs e)
        {
            Console.WriteLine(this.apiSecretBinance.Text.Length);
            this.apiKeyBinance.BackColor = System.Drawing.Color.Snow;
            this.apiSecretBinance.BackColor = System.Drawing.Color.Snow;

        }

        private void apiSecretFTX_TextChanged(object sender, EventArgs e)
        {
            Console.WriteLine(this.apiSecretFTX.Text);
        }

        private void coeff_form_TextChanged(object sender, EventArgs e)
        {
            Console.WriteLine(this.coeff_form.Text);
        }

        private void binanceBID_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
