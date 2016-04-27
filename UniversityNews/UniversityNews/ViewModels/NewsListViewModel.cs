using System.Collections.Generic;
using System.Linq;
using UniversityNews.DataObjects;
using UniversityNews.Helpers;
using UniversityNews.Models;
using UniversityNews.Pages;
using UniversityNews.Services;
using Xamarin.Forms;

namespace UniversityNews.ViewModels
{
    public class NewsListViewModel:BaseViewModel
    {
        public NewsListViewModel()
        {
            var newList = new List<NewDataObject>()
                {
                    new NewDataObject(),
                    new NewDataObject(),
                    new NewDataObject(), new NewDataObject(),new NewDataObject(),new NewDataObject()
                };
            //NewsHelper.BeginReadXmlStream("192.168.1.2/api/News");
            NewsList.AddRange(DataLoad.News.Select(item=> (NewModel)item));
        }

        private NewModel  _selectedNewModel;
        public List<NewModel> NewsList { get; set; }

        public NewModel SelectedNewModel
        {
            get { return _selectedNewModel; }
            set { SelectedNewModelExecute(value); }
        }

        private async void SelectedNewModelExecute(NewModel value)
        {
            await ((MasterDetailPage)(Application.Current.MainPage)).Detail.Navigation.PushAsync(new NewPage(value));
            ((MasterDetailPage)(Application.Current.MainPage)).IsPresented = false;
        }
    }
    
}
