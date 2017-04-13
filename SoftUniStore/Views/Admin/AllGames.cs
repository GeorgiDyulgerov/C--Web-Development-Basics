using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using SimpleMVC.Interfaces.Generic;
using SoftUniStore.ViewModels;

namespace SoftUniStore.Views.Admin
{
    public class Allgames : IRenderable<IEnumerable<AdminGamesViewModel>>
    {
        public IEnumerable<AdminGamesViewModel> Model { get; set; }

        public string Render()
        {
            string header = File.ReadAllText(Constants.ContentPath + Constants.Header);
            string navigation;
            if (Data.Data.Context.Logins.Any(log => log.IsActive == true))
            {
                navigation = File.ReadAllText(Constants.ContentPath + Constants.NavLog);
            }
            else
            {
                navigation = File.ReadAllText(Constants.ContentPath + Constants.NavNotLog);
            }
            StringBuilder games = new StringBuilder();
            games.Append(
                "<main>\r\n    <div class=\"container\">\r\n        <div class=\"row\">\r\n            <h2 class=\"m-1\">All Games &ndash;&nbsp;</h2> <a href=\"/admin/addgame\" class=\"btn btn-warning m-1\"><strong>+</strong> Add\r\n            Game</a>\r\n            <table class=\"table table-striped table-hover\">\r\n                <thead>\r\n                    <tr>\r\n                        <th>Name</th>\r\n                        <th>Size</th>\r\n                        <th>Price</th>\r\n                        <th>Actions</th>\r\n                    </tr>\r\n                </thead>\r\n                <tbody>");

            foreach (var vm in this.Model)
            {
                games.Append(vm);
            }
            

            games.Append("                </tbody>\r\n            </table>\r\n\r\n        </div>\r\n    </div>\r\n</main>");
            string footer = File.ReadAllText(Constants.ContentPath + Constants.Footer);

            StringBuilder builder = new StringBuilder();
            builder.Append(header);
            builder.Append(navigation);
            builder.Append(games);
            builder.Append(footer);

            return builder.ToString();
        }


    }
}
