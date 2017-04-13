using AutoMapper;
using SimpleHttpServer;
using SimpleMVC;
using SoftUniStore.BindingModel;
using SoftUniStore.Models;
using SoftUniStore.ViewModels;

namespace SoftUniStore
{
    class Program
    {
        static void Main(string[] args)
        {
            ConfigureMapper();
            HttpServer server = new HttpServer(8081, RouteTable.Routes);
            MvcEngine.Run(server, "SoftUniStore");
        }

        private static void ConfigureMapper()
        {
            Mapper.Initialize(expression =>
            {
                expression.CreateMap<UserRegisterBindingModel, User>();
                expression.CreateMap<Game, HomeViewModel>();
                expression.CreateMap<Game, GameDetailsViewModel>();
                expression.CreateMap<Game, AdminGamesViewModel>();
                expression.CreateMap<Game, DeleteGameViewModel>();
                expression.CreateMap<Game, EditGameViewModel>();
                expression.CreateMap<AddGameBindingModel, Game>();
            });
        }
    }
}
