using System.Windows.Input;
using UniversityNews.Helpers;
using UniversityNews.Pages;
using UniversityNews.Pages.AdminPages;
using UniversityNews.ViewModels.AdminViewModel;
using Xamarin.Forms;

namespace UniversityNews.ViewModels
{
    public class MenuViewModel:BaseViewModel
    {
        public MenuViewModel()
        {
            MessagingCenter.Subscribe<SettingsViewModel>(this, Consts.TeacherMessage, page =>IsVisibleAddNew=Settings.IsTeacher );
            MessagingCenter.Subscribe<AdminLoginVewModel>(this, Consts.TeacherMessage, page =>IsVisibleAddNew=Settings.IsTeacher );
        }

        public bool IsVisibleAddNew { get; set; } = Settings.IsTeacher;
        private ICommand _selectedMenuItemCommand;

        public ICommand SelectedMenuItemCommand
            => _selectedMenuItemCommand ?? (_selectedMenuItemCommand = new Command(SelectedMenuItemCommandExecute));

        private async void SelectedMenuItemCommandExecute(object obj)
        {
            var itemType = (MenuItemType)obj;
            switch (itemType)
            {
                    case MenuItemType.MainPage:
                    await ((MasterDetailPage)(Application.Current.MainPage)).Detail.Navigation.PushAsync(new NewsListPage());
                    ((MasterDetailPage)(Application.Current.MainPage)).IsPresented = false;
                    break;
                    case MenuItemType.Settings:
                    await ((MasterDetailPage)(Application.Current.MainPage)).Detail.Navigation.PushAsync(new SettingsPage());
                    ((MasterDetailPage)(Application.Current.MainPage)).IsPresented = false;
                    break;
                case MenuItemType.SendNew:
                    await ((MasterDetailPage)(Application.Current.MainPage)).Detail.Navigation.PushAsync(new AdminSendNewPage());
                    ((MasterDetailPage)(Application.Current.MainPage)).IsPresented = false;
                    break;
            }
        }
    }
}
