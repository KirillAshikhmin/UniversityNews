using System;
using System.Threading.Tasks;
using UniversityNews.Models;

namespace UniversityNews.ViewModels
{
    public class NewViewModel:BaseViewModel
    {
        public string Title { get; set; } = "StaticTitle";

        public string ImageUrl { get; set; } = "http://cs.pikabu.ru/images/logo2013.png";

        public string Date { get; set; } = DateTime.Now.ToString("d");

        public string Details { get; set; } = "Static Details";

        public NewModel NewModel { get; set; }

        public override Task Init(bool showContent = true)
        {
            ShowContent = false;
            Title = NewModel.Title;
            ImageUrl = NewModel.ImageUrl;
            Date = NewModel.Date;
            Details = NewModel.Details;
            ShowContent = true;
            return base.Init(showContent);
        }
    }
}
