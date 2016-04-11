using Xamarin.Forms;

namespace UniversityNews.Helpers
{
    public class ViewPage<T> : ContentPage where T : IViewModel, new()
    {
        readonly T _viewModel;

        public T ViewModel => _viewModel;

        public ViewPage()
        {
            _viewModel = new T()
            {
                Navigation = Navigation
            };
            BindingContext = _viewModel;
        }
    }
}
