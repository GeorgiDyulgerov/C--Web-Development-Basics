using System.IO;
using System.Linq;
using System.Text;
using SimpleMVC.Interfaces;

namespace SoftUniStore.Views.Admin
{
    class Addgame:IRenderable
    {
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
            string addGame = File.ReadAllText(Constants.ContentPath + Constants.AddGame);

            string footer = File.ReadAllText(Constants.ContentPath + Constants.Footer);

            StringBuilder builder = new StringBuilder();
            builder.Append(header);
            builder.Append(navigation);
            builder.Append(addGame);
            builder.Append(footer);

            return builder.ToString();
        }
    }
}
