using Microsoft.Extensions.DependencyInjection;
using Microsoft.UI.Xaml;
using System;
using System.Reflection;
using WinUI3Net6Beispiel.Models;
using WinUI3Net6Beispiel.Utilities;
using WinUI3Net6Beispiel.ViewModels;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace WinUI3Net6Beispiel
{
  /// <summary>
  /// Provides application-specific behavior to supplement the default Application class.
  /// </summary>
  public partial class App : Application
  {
    /// <summary>
    /// Initializes the singleton application object.  This is the first line of authored code
    /// executed, and as such is the logical equivalent of main() or WinMain().
    /// </summary>
    public App()
    {
      this.InitializeComponent();
    }

    /// <summary>
    /// Invoked when the application is launched normally by the end user.  Other entry points
    /// will be used such as when the application is launched to open a specific file.
    /// </summary>
    /// <param name="args">Details about the launch request and process.</param>
    protected override void OnLaunched(Microsoft.UI.Xaml.LaunchActivatedEventArgs args)
    {
      m_window = new MainWindow();

      // Setup dependency injection
      services = ConfigureServices();

      // Setup ViewModel of main window
      ((MainWindow)m_window).ViewModel = Services.GetService<MainViewModel>();

      m_window.Activate();
    }

    // Setup dependency injection
    private IServiceProvider ConfigureServices()
    {
      var services = new ServiceCollection();
      services.AddSingleton(typeof(IShell), m_window); // add shell
      services.AddSingleton<SettingsProvider>();

      //services.AddSingleton<MainViewModel>();
      //services.AddTransient<Sample1ViewModel>();
      //services.AddTransient<Sample2ViewModel>();
      //services.AddTransient<StartPageViewModel>();

      // add services with [Export] annotation for this assembly
      AddServicesFromAssembly(services, Assembly.GetExecutingAssembly());

      return services.BuildServiceProvider();
    }

    // add services with [Export] annotation for given assembly
    private void AddServicesFromAssembly(ServiceCollection services, Assembly assembly)
    {
      foreach (var type in assembly.GetTypes())
      {
        var exportAttr = type.GetCustomAttribute<ExportAttribute>();
        if (exportAttr != null && !type.IsAbstract)
          if (exportAttr.AsSingleton)
            services.AddSingleton(type);
          else
            services.AddTransient(type);
      }
    }

    private Window m_window;
    private IServiceProvider services;
    public IServiceProvider Services => services;
  }
}
