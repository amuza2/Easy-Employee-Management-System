using Microsoft.Extensions.DependencyInjection;
using System.Windows.Controls;

namespace EEMS.UI.Views.Shared.PageNativation
{
    public class NavigationService : INavigationService
    {
        private readonly IServiceProvider _serviceProvider;
        private Frame _mainFrame;

        public NavigationService(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public void SetFrame(Frame frame)
        {
            _mainFrame = frame;
        }

        public void NavigateTo<T>() where T : Page
        {
            var page = _serviceProvider.GetRequiredService<T>();
            _mainFrame.Navigate(page);
        }
    }
}
