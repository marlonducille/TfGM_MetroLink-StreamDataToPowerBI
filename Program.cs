using System;
using System.Net.Http.Headers;
using System.Text;
using System.Net.Http;
using System.Web;
using Newtonsoft.Json.Linq;
using System.Threading.Tasks;

namespace GetData
{
    class Program
    {
        static void Main()
        {
            var pbiClient = new HttpClient();
            MakeRequest();



            Console.ReadLine();
        }

        static async void MakeRequest()
        {
            while (1 == 1)
            {
                for (int i = 0; i < 10; i++)
                {
                    var tfgmClient = new HttpClient();
                    var pbiClient = new HttpClient();
                    var queryString = HttpUtility.ParseQueryString(string.Empty);

                    tfgmClient.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", "0b641e140c9747b394c90da96677e5a2");
                    var tfgmResponse = await tfgmClient.GetAsync("https://api.tfgm.com/odata/Metrolinks?$top=" + i);

                    var jsonString = await tfgmResponse.Content.ReadAsStringAsync();
                    dynamic data = JObject.Parse(jsonString);
                    var result = data.value;

                    Console.WriteLine(result.ToString());



                    HttpContent content = new StringContent(result.ToString());
                    Uri url = new Uri("https://api.powerbi.com/beta/9762f411-438d-440c-8357-896b35ae8707/datasets/5c62f0c5-de59-46b6-874e-787d263dcef5/rows?key=brNHu4qPahxAiKHYdIjgqw75HwlFLq5yZAMt65YnX5jXg76MuEO2JKS7JhZdOn3oZXPuppNgTU7rq95ZTAHBrQ%3D%3D");
                    HttpResponseMessage pbiResponse = pbiClient.PostAsync(url, content).Result;
                    System.Threading.Thread.Sleep(10000);
                }

            }
            //  Console.WriteLine(result.ToString());



        }
    }



}