using Windows.UI.Xaml.Controls;
using Microsoft.Toolkit.Mvvm.DependencyInjection;
using Poutinio.Core.Services;
using Poutinio.Services;

namespace Poutinio.Views
{
    public sealed partial class ShellPage : Page
    {
        public ShellPage()
        {
            InitializeComponent();

            var navService = Ioc.Default.GetRequiredService<INavigationService>();
            if (navService is NavigationService uwpNavService)
            {
                uwpNavService.Init(shellFrame);
            }
        }
    }
}
