using System.Linq;
using System.Threading.Tasks;
using PropertyChanged;
using UniversityNews.Helpers;
using Xamarin.Forms;

namespace UniversityNews.ViewModels
{
    [ImplementPropertyChanged]
    public class BaseViewModel : IViewModel
    {
        
    
        public bool IsInitialized { get; private set; }
        public bool ShowContent { get; set; }
        public INavigation Navigation { get; set; }

#pragma warning disable CS1998 // В асинхронном методе отсутствуют операторы await, будет выполнен синхронный метод
        public virtual async Task Init(bool showContent = true)
#pragma warning restore CS1998 // В асинхронном методе отсутствуют операторы await, будет выполнен синхронный метод
        {
            if (IsInitialized) return;
            IsInitialized = true;
        }
        
        
    }
}
