using Microsoft.UI.Xaml;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinUI3Net6Beispiel.Models;
using WinUI3Net6Beispiel.Views;

namespace WinUI3Net6Beispiel.ViewModels
{
  /// <summary>
  /// Common ViewModel for all RSS feed reader views
  /// </summary>
  public class RssFeedReaderViewModel : ViewModelBase
  {
    public RssFeedReaderViewModel(IShell shell, RssFeedReader feedReader) : base(shell)
    {
      FeedReader = feedReader;
    }

    // the news feed
    public RssFeedReader FeedReader { get; }

    // read feed when page is loaded
    public async override void PageLoaded(object sender, RoutedEventArgs e)
    {
      if (!FeedReader.IsLoaded)
        await FeedReader.ReadFeed();
    }

    /// <summary>
    /// Show selected item in browser (internal view)
    /// </summary>
    public void ShowBrowserView()
    {
      shell.NavigateTo<RssFeedBrowserView>();
    }

    /// <summary>
    /// Show selected item in browser (dialog window)
    /// </summary>
    public async void ShowBrowserDialog()
    {
      var result = await shell.ShowDialog<RssFeedBrowserView>(
        new(FeedReader.SelectedItem.Title, "Aha", "mag sein", "schnell weg"));

      Debug.WriteLine(result);
    }

  }
}
