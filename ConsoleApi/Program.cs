using System;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;

namespace ConsoleApi
{
    class Program
    {
        static async Task Main(string[] args)
        {
            using (var httpClient = new HttpClient())
            {

                HttpResponseMessage response = await httpClient.GetAsync("https://api.chucknorris.io/jokes/random");
                
                //Console.WriteLine(response);
                //Console.WriteLine(response.Content);
                //Console.WriteLine(response.StatusCode);
                //Console.WriteLine(response.RequestMessage);
                //Console.WriteLine(response.Headers);
                
                Console.WriteLine("--------");
                if (response.IsSuccessStatusCode)
                {
                    var chuckNorrisResponse = await response.Content.ReadAsStringAsync();
                    var respuesta = JsonConvert.DeserializeObject<ChuckNorrisJokesResponse>(chuckNorrisResponse);
                    Console.WriteLine($"Chuck Norris joke: {respuesta.Value}");
                }
                else
                {
                    Console.WriteLine("No se ha podido conectar");
                }
                
            }


            Console.ReadKey();
        }
    }
    public class ChuckNorrisJokesResponse
    {
        public string IconUrl { get; set; }
        public string Id { get; set; }
        public string Url { get; set; }
        public string Value { get; set; }
    }
}
