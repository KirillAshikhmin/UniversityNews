using System.Collections.Generic;
using System.Windows.Input;
//using Plugin.Toasts;
using UniversityNews.Helpers;
using UniversityNews.Pages;
using UniversityNews.Pages.AdminPages;
using Xamarin.Forms;

namespace UniversityNews.ViewModels
{
    public class SettingsViewModel:BaseViewModel
    {
        private  bool _isFullTime;
        private  bool _isBachelor;


        public SettingsViewModel()
        {
            _isFullTime = Settings.IsFullTime;
            _isBachelor = Settings.IsBachelor;
            FacultyIndex = Settings.Faculty;
            CourseIndex = Settings.Course;
            GroupIndex = Settings.Group;
            IsSubscribe = Settings.IsSubscribe;
            FacultiesList = new List<string> {"ФМФ","ЕГФ","ГФ"};
            CoursesList = new List<string> {"1","2", "3"};
            GroupsList= new List<string> {"ПИ", "МИ"};

            IsFullTime = _isFullTime ? "\\" : "[";
            IsExtramural = !_isFullTime ? "\\" : "[";

            IsBachelor = _isBachelor ? "\\" : "[";
            IsMaster = !_isBachelor ? "\\" : "[";
        }

        public string LoginText => Settings.IsTeacher ? "Выйти" : "Войти как преподователь";
        public int SelectedIndex { get; set; }
        public bool IsSubscribe { get; set; }
        public List<string> FacultiesList { get; set; } 
        public List<string> CoursesList { get; set; } 
        public List<string> GroupsList { get; set; }

        public string IsFullTime { get; set; }
        public string IsExtramural { get; set; }

        public string IsBachelor { get; set; }
        public string IsMaster { get; set; }

        public string IsSubscription { get; set; }
        public int FacultyIndex { get; set; }
        public int GroupIndex { get; set; }
        public int CourseIndex { get; set; }

        //private async void ShowToast(ToastNotificationType type, string title, string description)
        //{
        //    var notificator = DependencyService.Get<IToastNotificator>();
        //    bool tapped = await notificator.Notify(type, title, description, TimeSpan.FromSeconds(3));
        //}

        #region SaveCommand
        private ICommand _saveCommand;
        public ICommand SaveCommand => _saveCommand ?? (_saveCommand = new Command(SaveCommandExecute));
        private void SaveCommandExecute()
        {
            Settings.Faculty = FacultyIndex;
            Settings.Course = CourseIndex;
            Settings.Group = GroupIndex;
            Settings.IsSubscribe = IsSubscribe;
            Settings.IsFullTime = _isFullTime;
            Settings.IsBachelor = _isBachelor;
            //ShowToast(ToastNotificationType.Custom, "", "Настройки сохранены");
            Application.Current.MainPage=new MainPage();
        }
     
        #endregion
#region SelectFormOfEducation
        private ICommand _selectFormEducationCommand;

        public ICommand SelectFormEducationCommand => _selectFormEducationCommand ?? (_selectFormEducationCommand = new Command(SelectFormEducationCommandExecute));

        private void SelectFormEducationCommandExecute(object value)
        {
            var itemType = bool.Parse((string) value);
            _isFullTime = itemType;
            IsFullTime = _isFullTime ? "\\" : "[";
            IsExtramural = !_isFullTime ? "\\" : "[";
        }

        #endregion
#region SelectLevelOfEducationCommand
        private ICommand _selectLevelOfEducationCommand;

        public ICommand SelectLevelOfEducationCommand => _selectLevelOfEducationCommand ?? (_selectLevelOfEducationCommand = new Command(SelectLevelOfEducationCommandExecute));

        private void SelectLevelOfEducationCommandExecute(object value)
        {
            var itemType = bool.Parse((string) value);
            _isBachelor = itemType;
            IsBachelor = _isBachelor ? "\\" : "[";
            IsMaster = !_isBachelor ? "\\" : "[";
        }

#endregion
#region AdminCommand
        private ICommand _adminCommand;

        public ICommand AdminCommand => _adminCommand ?? (_adminCommand = new Command(AdminCommandExecute));

        private void AdminCommandExecute(object value)
        {
            if (Settings.IsTeacher)
            {
                Settings.IsTeacher = !Settings.IsTeacher;
                Navigation.PopToRootAsync();
                MessagingCenter.Send(this, Consts.TeacherMessage);
            }
            else
            Navigation.PushAsync(new AdminLoginPage());
        }
        #endregion

        


    }
}
