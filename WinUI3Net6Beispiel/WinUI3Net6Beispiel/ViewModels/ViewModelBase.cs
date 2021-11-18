﻿using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Navigation;
using WinUI3Net6Beispiel.Models;
using WinUI3Net6Beispiel.Utilities;

namespace WinUI3Net6Beispiel.ViewModels
{
  /// <summary>
  /// Base class for view models
  /// </summary>
  [Export]
  public abstract class ViewModelBase : NotificationObject
  {
    public ViewModelBase(IShell shell)
    {
      this.shell = shell;
    }

    protected readonly IShell shell;

    private string title = "ohne Titel";

    // Title to be shown in UI
    public string Title
    {
      get { return title; }
      set { title = value; OnPropertyChanged(); }
    }

    // virtual methods that are connected to events and may be overridden in derived classes
    public virtual void PageLoaded(object sender, RoutedEventArgs e) { }
    public virtual void PageUnloaded(object sender, RoutedEventArgs e) { }
    public virtual void OnNavigatingFrom(NavigatingCancelEventArgs e) { }

  }
}