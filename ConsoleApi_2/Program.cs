using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace ConsoleApi_2
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Ingrese numero de Pokemon:");
            int nroPokemon = int.Parse(Console.ReadLine());
            Console.Clear();
            using (var httpClient = new HttpClient()) 
            {
                HttpResponseMessage response = await httpClient.GetAsync($"https://pokeapi.co/api/v2/pokemon/{nroPokemon}");

                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    
                    var pokemon = JsonConvert.DeserializeObject<Pokemon>(json);
                    Console.WriteLine("*******************");
                    Console.WriteLine("Id: " + pokemon.Id);
                    Console.WriteLine($"Nombre: {pokemon.Name}");
                    Console.WriteLine($"Peso: {pokemon.Weight}");
                    Console.WriteLine("*******************");

                }
                else
                {
                    Console.WriteLine(response.StatusCode + ", Pokemon no encontrado");
                }



            }

                Console.ReadLine();
        }
        public class Pokemon
        {
            public int Id { get; set; }
            public string Name { get; set; } = string.Empty;           
            public float Weight { get; set; }
            
        }
    }
}