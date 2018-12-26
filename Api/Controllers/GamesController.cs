using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Data.Entities;
using Data.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route(StringResources.ApiPrefix + "[controller]")]
    [ApiController]
    public class GamesController : ControllerBase
    {
        private readonly IGameService _gameService;
        public GamesController(IGameService gameService)
        {
            _gameService = gameService;
        }
        [HttpGet("all")]
        public async Task<ActionResult<List<Game>>> Get()
        {
            return await _gameService.GetAllGames();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Game>> Get(int id)
        {
            if (id < 0)
            {
                return BadRequest();
            }

            var game = await _gameService.GetGame(id);

            if (game == null)
            {
                return NotFound();
            }

            return game;
        }

        [HttpPost]
        public async Task<ActionResult<Game>> Post([FromBody] Game newGame)
        {
            var createdGame = await _gameService.CreateNewGame(newGame);

            if(createdGame == null)
            {
                return BadRequest();
            }

            return Created(new Uri(StringResources.ApiPrefix + "games/" + createdGame.Id, UriKind.Relative), createdGame);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}