using CallApiTest.Models;
using Refit;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CallApiTest.Services
{
    public interface IPlayerService
    {
        [Get("/api/player/{id}")]
        Task<Player> GetPlayerAsync(string id);

        [Get("/api/player")]
        Task<List<Player>> GetPlayersAsync();

        [Post("/api/player")]
        Task InsetPlayer(Player player);
    }
}