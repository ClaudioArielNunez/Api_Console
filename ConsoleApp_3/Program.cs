using Newtonsoft.Json;
using System.Text.Json.Serialization;
using static ConsoleApp_3.Program;

namespace ConsoleApp_3
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            using (var httpClient = new HttpClient())
            {
                HttpResponseMessage response = await httpClient.GetAsync("https://dragonball-api.com/api/characters");

                if (response.IsSuccessStatusCode)
                {

                    var json = await response.Content.ReadAsStringAsync();

                    //En este caso estoy deserializando en un Personaje
                    //var personaje = JsonConvert.DeserializeObject<Personaje>(json);


                    //Aqui el JSON que estás tratando de deserializar no es un array, sino un objeto JSON que contiene una
                    //propiedad que es un array. Este es un escenario común en las APIs que envían datos dentro de un objeto
                    //con una estructura específica.
                    
                    //En este caso estoy deserializando en un PersonajeResponse que tiene como prop un array de Personaje
                    var personajesResponse = JsonConvert.DeserializeObject<PersonajeResponse>(json);

                    //creo un array de Personaje y guardo esa prop
                    Personaje[] personajes = personajesResponse.items;

                    foreach (var personaje in personajes)
                    {
                        //Console.WriteLine("**********************");
                        Console.WriteLine("Id: " + personaje.id);
                        Console.WriteLine("Id: " + personaje.name);
                        Console.WriteLine("Id: " + personaje.ki);
                        Console.WriteLine("Id: " + personaje.maxki);
                        Console.WriteLine("Id: " + personaje.race);
                        Console.WriteLine("Id: " + personaje.gender);
                        Console.WriteLine("Id: " + personaje.description);
                        Console.WriteLine("**********************");
                    }

                    
                }
                else
                {
                    Console.WriteLine(response.StatusCode + ", Personaje no encontrado!");
                }
            }
        }

        public class PersonajeResponse
        {
            public Personaje[] items { get; set; }
        }

        public class Personaje
        {
            public int id { get; set; }
            public string name { get; set; } = string.Empty;
            public string ki { get; set; }
            public string maxki { get; set; }
            public string race { get; set; } = string.Empty;
            public string gender { get; set; } = string.Empty;
            public string description { get; set; } = string.Empty;

        }
    }
}