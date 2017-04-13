using System.Collections.Generic;
using System.Text.RegularExpressions;
using AutoMapper;
using SoftUniStore.BindingModel;
using SoftUniStore.Models;
using SoftUniStore.ViewModels;

namespace SoftUniStore.Services
{
    public class AdminService:Service
    {
        public IEnumerable<AdminGamesViewModel> GetAllGames()
        {
            IEnumerable<Game> games = this.Context.Games.Entities;

            IEnumerable<AdminGamesViewModel> gamesVM =Mapper.Map<IEnumerable<Game>, IEnumerable<AdminGamesViewModel>>(games);

            return gamesVM;
        }

        public Game GetGameFromBind(AddGameBindingModel bind)
        {
            Game game = Mapper.Map<AddGameBindingModel,Game>(bind);
            return game;
        }

        public bool GameIsValid(AddGameBindingModel bind)
        {
            if (char.IsUpper(bind.Title[0]) || bind.Title.Length<3||bind.Title.Length>100)
            {
                return false;
            }
            if (bind.Price<0)
            {
                return false;
            }
            if (bind.Size<0)
            {
                return false;
            }
            if (bind.Trailer.Length!=11)
            {
                return false;
            }

            Regex thumbRegx = new Regex("^(http|https)://");
            if (!thumbRegx.IsMatch(bind.ImageThumbnail))
            {
                return false;
            }

            if (bind.Description.Length<30)
            {
                return false;
            }


            return true;
        }

        public void AddGame(Game game)
        {
            this.Context.Games.Add(game);
            this.Context.SaveChanges();
        }

        public DeleteGameViewModel GetGameForDeleteVM(int id)
        {
            Game game = this.Context.Games.Find(id);

            DeleteGameViewModel deleteGameVM = Mapper.Map<Game,DeleteGameViewModel>(game);

            return deleteGameVM;
        }

        public Game GetGameForDelete(int id)
        {
            return this.Context.Games.Find(id);
        }


        public void DeleteGame(Game game)
        {
            this.Context.Games.Remove(game);
            this.Context.SaveChanges();
        }

        public EditGameViewModel GetGameForEditVM(int id)
        {
            Game game = this.Context.Games.Find(id);

            EditGameViewModel editGameVM = Mapper.Map<Game, EditGameViewModel>(game);

            return editGameVM;
        }
    }
}
