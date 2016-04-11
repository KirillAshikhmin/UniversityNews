using UniversityNews.Helpers;
using UniversityNews.Models;
using UniversityNews.ViewModels;

namespace UniversityNews.Pages
{ public class NewPageBase : ViewPage<NewViewModel> { }
    public partial class NewPage : NewPageBase
    {
        public NewPage(NewModel value)
        {
            ViewModel.NewModel = value;
            InitializeComponent();
        }
    }
}
