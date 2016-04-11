using System.Threading.Tasks;
using UniversityNews.Helpers;
using UniversityNews.ViewModels.AdminViewModel;
using Xamarin.Forms;

namespace UniversityNews.Pages.AdminPages
{
    public class AdminSendNewpageBase : ViewPage<AdminSendNewViewModel>
    {
    }

    public partial class AdminSendNewPage : AdminSendNewpageBase
    {
        public AdminSendNewPage()
        {
            InitializeComponent();
            ViewModel.ShowFiltersChanged += (sender, value) =>
            {
                Device.BeginInvokeOnMainThread(() =>
                {
                    if (value)
                    {
                        MessageContainer.IsVisible = false;
                        Task.Delay(50);
                        FiltersContainer.IsVisible = true;
                        FiltersContainer.Animate("HeightRequest", d =>
                        {
                            foreach (var child in FiltersContainer.Children)
                            {
                                child.HeightRequest = d;
                            }
                        }, 0, 45,
                            16U, 500U,
                            Easing.Linear);
                    }
                    else
                    {
                        FiltersContainer.Animate("HeightRequest", d =>
                        {
                            foreach (var child in FiltersContainer.Children)
                            {
                                child.HeightRequest = d;
                            }
                        }, 45, 0,
                            16U, 500U,
                            Easing.Linear);
                        FiltersContainer.IsVisible = false;
                        Task.Delay(50);
                        MessageContainer.IsVisible = true;
                    }
                });
            };
        }
    }
}
                    