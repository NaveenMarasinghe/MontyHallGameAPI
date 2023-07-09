using MontyHall.DataAccess;
using MontyHall.DataAccess.Models;
using MontyHall.Models;
using System;

namespace MontyHall.BusinessLogic
{
    public class GameBL
    {
        public GameCardModel CreateGame(CreateGameModel newGame)
        {
            int newGameId;
            using(DataAdapter dataAdapter = new DataAdapter())
            {
                List<GameData> list = new List<GameData>();

                newGameId = dataAdapter.GameDataGenericRepository.GetAll().Select(x => x.GameId).DefaultIfEmpty(0).Max() + 1;

                for (int i = 0; i< newGame.NoOfSimulations; i++)
                {
                    GameData gameData = new GameData()
                    {
                        GameId = newGameId,
                        SwitchDoor = newGame.SwitchDoor,
                    };
                    list.Add(gameData);
                }
                dataAdapter.GameDataGenericRepository.AddRange(list);
                dataAdapter.Save();                
            }

            return GetGameCard(newGameId);
        }

        public void GetResults(int gameId) 
        {
            using(DataAdapter dataAdapter = new DataAdapter())
            {
                var gameData = dataAdapter.GameDataGenericRepository.GetByValues(x=>x.GameId == gameId);

                foreach(GameData data in gameData) 
                {
                    Random randomWinDoorNumber = new Random();
                    data.WinDoorNumber = randomWinDoorNumber.Next(1, 4);
                    dataAdapter.GameDataGenericRepository.Edit(data);
                }
                dataAdapter.Save();
            }
        }

        public List<GameCardModel> GetGameCards()
        {
            List<GameCardModel> results = new List<GameCardModel>();
            using (DataAdapter dataAdapter = new DataAdapter())
            {
                var gameData = dataAdapter.GameDataGenericRepository.GetAll();

                results = gameData.GroupBy(g => g.GameId)
                                             .Select(g => new GameCardModel
                                             {
                                                 GameId = g.Key,
                                                 SwitchDoor = g.First().SwitchDoor,
                                                 NoOfSimulations = g.Count()
                                             })
                                             .ToList();
            }
            return results;
        }

        public GameCardModel GetGameCard(int cardId)
        {
            List<GameCardModel> results = new List<GameCardModel>();
            using (DataAdapter dataAdapter = new DataAdapter())
            {
                var gameData = dataAdapter.GameDataGenericRepository.GetByValues(x=> x.GameId == cardId);

                results = gameData.GroupBy(g => g.GameId)
                                             .Select(g => new GameCardModel
                                             {
                                                 GameId = g.Key,
                                                 SwitchDoor = g.First().SwitchDoor,
                                                 NoOfSimulations = g.Count()
                                             })
                                             .ToList();
            }
            return results[0];
        }

        public List<GameData> GetGameData(int GameId)
        {
            List<GameData> results = new List<GameData>();
            using (DataAdapter dataAdapter = new DataAdapter())
            {
                 results = dataAdapter.GameDataGenericRepository.GetByValues(x=>x.GameId == GameId);
            }
            return results;
        }

        public List<GameData> RunGame(int gameId)
        {
            using (DataAdapter dataAdapter = new DataAdapter())
            {
                List<GameData> gameDataList = dataAdapter.GameDataGenericRepository.GetByValues(x => x.GameId == gameId);

                foreach(GameData gameData in gameDataList)
                {
                    Random randomNumber = new Random();
                    int doorId = randomNumber.Next(1,4);
                    int winningDoor = randomNumber.Next(1,4);
                    int revealDoor = GetRevealedDoor(winningDoor, doorId);

                    gameData.WinDoorNumber = winningDoor;
                    gameData.SelectedDoorNumber = doorId;

                    gameData.RevealDoorNumber = revealDoor;

                    if (gameData.SwitchDoor == true)
                    {
                        gameData.SelectedDoorNumber = GetSwitchedDoor(doorId, revealDoor);
                    }
                }

                dataAdapter.Save();
            }

            return GetGameData(gameId);
        }

        private static int GetRevealedDoor(int winningDoor, int selectedDoor)
        {
            int revealedDoor;
            Random random = new Random();
            do
            {
                revealedDoor = random.Next(1,4);
            } while (revealedDoor == winningDoor || revealedDoor == selectedDoor);

            return revealedDoor;
        }

        private static int GetSwitchedDoor(int selectedDoor, int revealedDoor)
        {
            int switchedDoor;
            Random random = new Random();
            do
            {
                switchedDoor = random.Next(1,4);
            } while (switchedDoor == selectedDoor || switchedDoor == revealedDoor);

            return switchedDoor;
        }
    }
}