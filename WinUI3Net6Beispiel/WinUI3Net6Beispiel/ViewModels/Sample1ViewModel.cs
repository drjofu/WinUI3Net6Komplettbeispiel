using Microsoft.UI.Xaml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinUI3Net6Beispiel.Models;

namespace WinUI3Net6Beispiel.ViewModels
{
  /// <summary>
  /// Example to play around 
  /// </summary>
  public class Sample1ViewModel:ViewModelBase
  {
    private readonly RssFeedReader rssFeedReader;

    public Sample1ViewModel(IShell shell, RssFeedReader rssFeedReader):base(shell)
    {
      Title = "Sample 1";
      this.rssFeedReader = rssFeedReader;
    }

    public string Info { get; set; } = "Hallo von Sample1ViewModel";

    public async override void PageLoaded(object sender, RoutedEventArgs e)
    {
      base.PageLoaded(sender, e);
      await rssFeedReader.ReadFeed();

    }
  }
}
