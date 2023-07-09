using MontyHall.Models;
using Microsoft.AspNetCore.Mvc;
using MontyHall.BusinessLogic;
using Microsoft.EntityFrameworkCore;
using MontyHall.DataAccess.Models;
using System;

namespace DMS.DEMO.TESTAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/Game/[action]")]
    [ApiController]
    public class GameDataController : ControllerBase
    {
        public GameBL _oGameBL = null;

        public GameDataController()
        {
            _oGameBL = new GameBL();
        }

        [HttpPost]
        [ActionName("CreateGame")]
        public GameCardModel CreateGame([FromBody] CreateGameModel newGame)
        {
            return _oGameBL.CreateGame(newGame);
        }

        [HttpGet("{Num}")]
        [ActionName("GetResults")]
        public string GetResults([FromRoute] int Num)
        {
            _oGameBL.GetResults(Num);
            return "You have send " + Num;
        }

        [HttpGet("{GameId}")]
        [ActionName("RunGame")]

        public List<GameData> RunGame([FromRoute] int GameId)
        {
            return _oGameBL.RunGame(GameId);
        }

        [HttpGet()]
        [ActionName("GetGameCards")]
        public List<GameCardModel> GetGameCards()
        {
            List<GameCardModel> results = _oGameBL.GetGameCards();
            return results;
        }

        [HttpGet("{GameId}")]
        [ActionName("GetGameCard")]
        public GameCardModel GetGameCard([FromRoute] int GameId)
        {
            GameCardModel results = _oGameBL.GetGameCard(GameId);
            return results;
        }

        [HttpGet("{GameId}")]
        [ActionName("GetGameData")]
        public List<GameData> GetGameData([FromRoute] int GameId)
        {
            List<GameData> results = _oGameBL.GetGameData(GameId);
            return results;
        }


    }
}