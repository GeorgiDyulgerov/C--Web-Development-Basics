using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleMVC.Interfaces;
using SimpleMVC.Interfaces.Generic;
using SoftUniStore.ViewModels;

namespace SoftUniStore.Views.Game
{
    public class Details : IRenderable<GameDetailsViewModel>
    {
        public GameDetailsViewModel Model { get; set; }

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
            StringBuilder gameDetail = new StringBuilder();
            gameDetail.Append("<main>\r\n    <div class=\"container\">\r\n        <div class=\"row\">\r\n            <div class=\"col-12 text-center\">");

            gameDetail.Append(this.Model);

            gameDetail.Append("            </div>\r\n        </div>\r\n    </div>\r\n</main>");
            string footer = File.ReadAllText(Constants.ContentPath + Constants.Footer);

            StringBuilder builder = new StringBuilder();
            builder.Append(header);
            builder.Append(navigation);
            builder.Append(gameDetail);
            builder.Append(footer);

            return builder.ToString();
        }

 
    }
}
