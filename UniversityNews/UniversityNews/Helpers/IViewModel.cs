using System.Threading.Tasks;
using Xamarin.Forms;

namespace UniversityNews.Helpers
{
    public interface IViewModel
    {
        bool IsInitialized { get; }
        INavigation Navigation { get; set; }
        Task Init(bool showContent = true);
    }
}