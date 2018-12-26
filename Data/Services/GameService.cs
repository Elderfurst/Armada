using Data.Entities;
using Data.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Data.Services
{
    public class GameService : IGameService
    {
        private readonly ArmadaContext _armadaContext;

        public GameService(ArmadaContext armadaContext)
        {
            _armadaContext = armadaContext;
        }
        public async Task<List<Game>> GetAllGames()
        {
            return await _armadaContext.Games.ToListAsync();
        }
        public async Task<Game> GetGame(int id)
        {
            return await _armadaContext.Games.FirstAsync(x => x.Id == id);
        }
        public async Task<Game> CreateNewGame(Game newGame)
        {
            _armadaContext.Games.Add(newGame);

            var saved = await _armadaContext.SaveChangesAsync();

            return saved > 0 ? newGame : null;
        }
    }
}
