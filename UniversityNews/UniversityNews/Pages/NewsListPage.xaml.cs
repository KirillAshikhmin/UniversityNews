using UniversityNews.Helpers;
using UniversityNews.ViewModels;

namespace UniversityNews.Pages
{
    public class NewsListPageBase : ViewPage<NewsListViewModel> { }
    public partial class NewsListPage : NewsListPageBase
    {
        public NewsListPage()
        {
            InitializeComponent();
        }
    }
}
