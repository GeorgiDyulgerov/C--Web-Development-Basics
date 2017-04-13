namespace SoftUniStore.ViewModels
{
    public class EditGameViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Trailer { get; set; }

        public string ImageThumbnail { get; set; }

        public double Size { get; set; }

        public decimal Price { get; set; }

        public string Description { get; set; }


        public override string ToString()
        {
            string representation = $"<main class=\"col-4 offset-4 text-center\">\r\n    <div class=\"container\">\r\n        <div class=\"row\">\r\n            <div class=\"col-12\">\r\n                <div class=\"text-center\"><h1 class=\"display-3\">Edit Game</h1></div>\r\n                <br/>\r\n " +
                                    $"  <form method=\"post\" id=\"new-game-form\">\r\n                    <input type=\"type\" hidden=\"hidden\" value=\"2\" />\r\n\r\n                    <div class=\"form-group row\">\r\n                        " +
                                    $"<label for=\"name\" class=\"form-control-label\">Title</label>\r\n                        <input type=\"text\" maxlength=\"100\" minlength=\"4\" id=\"name\" class=\"form-control\"\r\n                               placeholder=\"Enter Game Name\" value=\"{this.Title}\"/>\r\n                    </div>\r\n\r\n " +
                                    $"<div class=\"form-group row\">\r\n                        <label for=\"desc\" class=\"form-control-label\">Description</label>\r\n                        <textarea id=\"desc\" class=\"form-control\"\r\n                                  placeholder=\"Enter Game Description\" minlength=\"30\">{this.Description}</textarea>\r\n " +
                                    $"</div>\r\n\r\n                    <div class=\"form-group row\">\r\n                        <label for=\"thumbnail\" class=\"form-control-label\">Thumbnail</label>\r\n                        <input type=\"url\" id=\"thumbnail\" class=\"form-control\"\r\n                               placeholder=\"Enter URL to Image\"\r\n                               value=\"{this.ImageThumbnail}\"/>\r\n                    </div>\r\n\r\n           " +
                                    $" <div class=\"form-group row\">\r\n                        <label for=\"price\" class=\"form-control-label\">Price</label>\r\n                        <div class=\"input-group\">\r\n\r\n                            <input type=\"number\" step=\"0.01\" min=\"0\" id=\"price\" class=\"form-control\"\r\n                                   placeholder=\"Enter Price\" value=\"{this.Price}\"/>\r\n                            <span class=\"input-group-addon\"\r\n    " +
                                    $"     id=\"addon2\">&euro;</span>\r\n                        </div>\r\n                    </div>\r\n\r\n                    <div class=\"form-group row\">\r\n                        <label for=\"size\" class=\"form-control-label\">Size</label>\r\n                        <div class=\"input-group\">\r\n\r\n                            <input type=\"number\" step=\"0.1\" min=\"0\" id=\"size\" class=\"form-control\"\r\n                                   placeholder=\"Enter Size\" value=\"{this.Size}\"/>\r\n                            <span class=\"input-group-addon\"\r\n                                  id=\"addon3\">GB</span>\r\n                        </div>\r\n" +
                                    $"</div>\r\n\r\n                    <div class=\"form-group row\">\r\n                        <label for=\"video\" class=\"form-control-label\">YouTube Video URL</label>\r\n                        <div class=\"input-group\">\r\n                            <span class=\"input-group-addon\"\r\n                                  id=\"addon\">https://www.youtube.com/watch?v=</span>\r\n                            <input type=\"text\" class=\"form-control\" id=\"video\"\r\n                                   value=\"{this.Trailer}\"/>\r\n                        </div>\r\n                    </div>\r\n  " +
                                    $"<input type=\"submit\" id=\"btn-edit-game\" class=\"btn btn-outline-warning btn-lg btn-block\"\r\n                           value=\"Edit Game\"/>\r\n                </form>\r\n                <br/>\r\n            </div>\r\n        </div>\r\n    </div>\r\n</main>";

            return representation;
        }
    }
}
