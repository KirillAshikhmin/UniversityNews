using System.Windows.Input;
using UniversityNews.Helpers;
using Xamarin.Forms;

namespace UniversityNews.ViewModels.AdminViewModel
{
    public class AdminLoginVewModel:BaseViewModel
    {
        public string Login { get; set; }
        public string Password { get; set; }

        #region LoginCommand
        private ICommand _loginCommand;

        public ICommand LoginCommand => _loginCommand ?? (_loginCommand = new Command(LoginCommandExecute));

        private void LoginCommandExecute(object value)
        {
            Navigation.PopToRootAsync(false);
            Settings.IsTeacher = true;
            MessagingCenter.Send(this, Consts.TeacherMessage);
        }

        #endregion
    }
}
