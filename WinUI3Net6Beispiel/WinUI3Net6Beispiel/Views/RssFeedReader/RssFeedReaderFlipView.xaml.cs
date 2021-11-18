using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using WinUI3Net6Beispiel.Utilities;
using WinUI3Net6Beispiel.ViewModels;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace WinUI3Net6Beispiel.Views
{
  /// <summary>
  /// An empty page that can be used on its own or navigated to within a Frame.
  /// </summary>
  public sealed partial class RssFeedReaderFlipView : Page
  {
    public RssFeedReaderViewModel ViewModel { get; set; }
    public RssFeedReaderFlipView()
    {
      this.InitializeComponent();
      ViewModel = this.SetupViewModel<RssFeedReaderViewModel>();
      ViewModel.Title = "Flip View";
    }
  }
}
