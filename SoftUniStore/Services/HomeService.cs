using System.Collections;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using SoftUniStore.Models;
using SoftUniStore.ViewModels;

namespace SoftUniStore.Services
{
    public class HomeService : Service
    {
        public IEnumerable<HomeViewModel> GetGames()
        {
            IEnumerable<Game> games = this.Context.Games.Entities;

            IEnumerable<HomeViewModel> gameVM = Mapper.Map<IEnumerable<Game>,IEnumerable<HomeViewModel>>(games);
            
            return gameVM;
        }

        public IEnumerable<HomeViewModel> GetOwnedGames(User user)
        {
            if (user.Games.Count == 0)
            {
                return null;
            }

            IEnumerable<Game> games = user.Games;

            IEnumerable<HomeViewModel> gameVM = Mapper.Map<IEnumerable<Game>, IEnumerable<HomeViewModel>>(games);

            return gameVM;
        }
    }
}
