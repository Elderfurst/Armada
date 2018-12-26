using Data.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Data.Services.Interfaces
{
    public interface IGameService
    {
        Task<List<Game>> GetAllGames();
        Task<Game> GetGame(int id);
        Task<Game> CreateNewGame(Game newGame);
    }
}
