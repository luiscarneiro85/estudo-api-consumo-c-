using CallApiTest.Models;
using CallApiTest.Services;
using Refit;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace CallApiTest
{
    class Program
    {
        static void Main(string[] args)
        {
            //RunAsync().Wait();
            RunRefit().Wait();
            Console.ReadKey();
        }

        /// <summary>
        /// Consumo de API utilizando nugget Refit
        /// </summary>
        /// <returns></returns>
        static async Task RunRefit()
        {
            string _baseUri = "http://localhost:51918";

            try
            {
                var client = RestService.For<IPlayerService>(_baseUri);

                //Player player = await client.GetPlayerAsync("1007");
                //Console.WriteLine(player.Name);

                //List<Player> players = new List<Player>();
                //players = await client.GetPlayersAsync();
                //foreach (Player p in players)
                //    Console.WriteLine(p.Name);

                await client.InsetPlayer(new Player()
                {
                    Name = "bug3",
                    Email = "bug3@gmail.com",
                    Psn = "psn.bug3"
                });
            }
            catch (Exception e)
            {
                Console.WriteLine("Erro na consulta: " + e.Message);
            }
        }

        /// <summary>
        /// Consumo de API utilizando HttpClient
        /// </summary>
        /// <returns></returns>
        static async Task RunAsync()
        {
            using (HttpClient client = new HttpClient())
            {
                string _baseUri = "http://localhost:51918/";
                client.BaseAddress = new Uri(_baseUri);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(
                    new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/jason"));

                //GET
                string _endPoint = "api/player";
                //string _endPoint = "api/player/{}";
                List<Player> players = new List<Player>();

                HttpResponseMessage response = await client.GetAsync(_endPoint);

                if (response.IsSuccessStatusCode)
                {
                    players = await response.Content.ReadAsAsync<List<Player>>();
                    foreach(Player p in players)
                        Console.WriteLine(p.Name);
                }

                //POST
                //string _enPoint = "api/player";
                //Player player = new Player() {
                //    Name = "Bruno",
                //    Email = "bruno@gmail.com",
                //    Psn = "Psn.bruno"
                //};

                //HttpResponseMessage response = await client.PostAsJsonAsync(_enPoint, player);
            }
        }
    }
}