using UniversityNews.Helpers;
using UniversityNews.ViewModels;

namespace UniversityNews.Pages
{
    public class MenuPageBase : ViewPage<MenuViewModel> { }
    public partial class MenuPage : MenuPageBase
    {
        public MenuPage()
        {
            InitializeComponent();
        }
    }
}
