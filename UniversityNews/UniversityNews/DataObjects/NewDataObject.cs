using System;

namespace UniversityNews.DataObjects
{
    public class NewDataObject
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string ImageUrl { get; set; }

        public string Details { get; set; }

        public DateTime Date { get; set; }

        public int NewType {get; set; }

        public string Owner { get; set; }

        public NewDataObject(/*int id, */string title, string imageUrl, string details, DateTime date, int newType, string owner)
        {
            //Id = id;
            Title = title;
            ImageUrl = imageUrl;
            Details = details;
            Date = date;
            NewType = newType;
            Owner = owner;
        }

        public NewDataObject()
        {
        }
    }
}
