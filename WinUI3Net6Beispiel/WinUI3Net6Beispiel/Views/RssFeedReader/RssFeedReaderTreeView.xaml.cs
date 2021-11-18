using Microsoft.UI.Xaml.Controls;
using WinUI3Net6Beispiel.Utilities;
using WinUI3Net6Beispiel.ViewModels;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace WinUI3Net6Beispiel.Views
{
  /// <summary>
  /// An empty page that can be used on its own or navigated to within a Frame.
  /// </summary>
  public sealed partial class RssFeedReaderTreeView : Page
  {
    public RssFeedReaderViewModel ViewModel { get; set; }

    public RssFeedReaderTreeView()
    {
      this.InitializeComponent();
      ViewModel = this.SetupViewModel<RssFeedReaderViewModel>();
      ViewModel.Title = "Tree View";
    }
  }
}
