﻿using System.Globalization;
using UniversityNews.DataObjects;
using Xamarin.Forms;

namespace UniversityNews.Models
{
    public class NewModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string ImageUrl { get; set; }

        public string Details { get; set; }

        public string Date { get; set; }

        public string Owner { get; set; }

        public Color ItemColor { get; set; }

        public static explicit operator NewModel(NewDataObject newDataObject)
        {
            var newModel = new NewModel
            {
                Owner = newDataObject.Owner,
                Id = newDataObject.Id,
                Date = newDataObject.Date.ToString(new CultureInfo("ru-ru")),
                Details = newDataObject.Details,
                ImageUrl = newDataObject.ImageUrl,
                Title = newDataObject.Title,
            };
            string color = "All";
            //string color = newDataObject.NewType;
            switch (color)
            {
                case "All":
                    newModel.ItemColor = Color.Red;
                    break;
                case "Faculty":
                    newModel.ItemColor = Color.Blue;
                    break;
                case "Group":
                    newModel.ItemColor = Color.Fuchsia;
                    break;
                default:
                    newModel.ItemColor = Color.White;
                    break;
            }
            return newModel;
        }
    }
}
