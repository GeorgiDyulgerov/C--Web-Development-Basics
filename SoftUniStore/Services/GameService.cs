using AutoMapper;
using SoftUniStore.Models;
using SoftUniStore.ViewModels;

namespace SoftUniStore.Services
{
    public class GameService:Service
    {
        public GameDetailsViewModel GetGameDetails(int id)
        {
            Game game = this.Context.Games.Find(id);

            GameDetailsViewModel gameDetails = Mapper.Map<Game, GameDetailsViewModel>(game);

            return gameDetails;
        }

        public void BuyGame(User user, int id)
        {
            Game game = this.Context.Games.Find(id);
            if (game == null)
            {
                return;
            }
            user.Games.Add(game);
            this.Context.SaveChanges();
        }
    }
}
