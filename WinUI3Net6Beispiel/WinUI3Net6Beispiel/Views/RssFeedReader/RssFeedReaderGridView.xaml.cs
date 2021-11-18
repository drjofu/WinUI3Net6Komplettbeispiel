﻿using Microsoft.UI.Xaml.Controls;
using WinUI3Net6Beispiel.Utilities;
using WinUI3Net6Beispiel.ViewModels;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace WinUI3Net6Beispiel.Views
{
  /// <summary>
  /// An empty page that can be used on its own or navigated to within a Frame.
  /// </summary>
  public sealed partial class RssFeedReaderGridView : Page
  {
    public RssFeedReaderViewModel ViewModel { get; set; }

    public RssFeedReaderGridView()
    {
      this.InitializeComponent();
      ViewModel = this.SetupViewModel<RssFeedReaderViewModel>();
      ViewModel.Title = "RSS-Feed-Reader Grid View";

    }
  }
}
