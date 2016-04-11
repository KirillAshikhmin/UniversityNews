using System;

namespace UniversityNews.DataObjects
{
    public class NewDataObject
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string ImageUrl { get; set; }

        public string Details { get; set; }

        public string Date { get; set; }

        public string NewType {get; set; }

        public NewDataObject()
        {
            Id = 1;
            Title = "static Title";
            ImageUrl = "http://cs.pikabu.ru/images/logo2013.png";
            Details = "static details";
            Date = DateTime.Now.ToString("d");
            NewType = "All";
        }
    }
}
