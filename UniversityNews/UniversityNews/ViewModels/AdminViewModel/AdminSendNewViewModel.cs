using System;
using System.Windows.Input;
using Xamarin.Forms;

namespace UniversityNews.ViewModels.AdminViewModel
{
    public class AdminSendNewViewModel:BaseViewModel
    {
        private bool _showLoading;
        
        public AdminSendNewViewModel()
        {
            IsEvening = "]";
            IsDistance = "]";
            IsFullTime = "]";
            IsMaster = "]";
            FilterText = "Все";
        }
        public string IsFullTime { get; set; }
        public string IsDistance { get; set; }

        public string IsEvening { get; set; }
        public string IsMaster { get; set; }

        public string FilterText { get; set; }
        public event Action<BaseViewModel, bool> ShowFiltersChanged;

        public bool ShowLoading
        {
            get { return _showLoading; }
            set
            {
                _showLoading = value;
                ShowFiltersChanged?.Invoke(this, value);
            }
        }

        #region FilterClickCommand

        private ICommand _filterClickCommand;

        public ICommand FilterClickCommand
            => _filterClickCommand ?? (_filterClickCommand = new Command(FilterClickCommandExecute));

        private void FilterClickCommandExecute()
        {
            ShowLoading = !ShowLoading;
        }

        #endregion
    }
}
