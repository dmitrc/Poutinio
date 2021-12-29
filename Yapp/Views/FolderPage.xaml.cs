using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using Yapp.ViewModels;

namespace Yapp.Views
{
    public sealed partial class FolderPage : Page
    {
        public FolderViewModel ViewModel { get; } = new FolderViewModel();

        public FolderPage()
        {
            InitializeComponent();
            DataContext = ViewModel;
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            var parentId = e.Parameter as long?;
            if (parentId != null)
            {
                ViewModel.ParentId = parentId;
            }
        }
    }
}
