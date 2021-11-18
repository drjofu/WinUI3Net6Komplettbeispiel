using System.Collections.Generic;
using System.Globalization;
using WinUI3Net6Beispiel.Models;
using WinUI3Net6Beispiel.Utilities;

namespace WinUI3Net6Beispiel.ViewModels
{
  /// <summary>
  /// ViewModel for settings view
  /// </summary>
  [Export(AsSingleton = true)]
  public class SettingsViewModel : ViewModelBase
  {
    public SettingsViewModel(IShell shell) : base(shell)
    {
      Title = "Settings";

      // get current settings
      (isAudioOn, isAudioSpacial) = shell.GetAudio();
      selectedCulture = CultureInfo.CurrentCulture; 
    }

    private bool isAudioOn;

    /// <summary>
    /// Audio status
    /// </summary>
    public bool IsAudioOn
    {
      get { return isAudioOn; }
      set { isAudioOn = value; shell.SetupAudio(isAudioOn, isAudioSpacial); }
    }

    private bool isAudioSpacial;

    /// <summary>
    /// Audio spacial setting
    /// </summary>
    public bool IsAudioSpacial
    {
      get { return isAudioSpacial; }
      set { isAudioSpacial = value; shell.SetupAudio(isAudioOn, isAudioSpacial); }
    }

    /// <summary>
    /// Get app version
    /// </summary>
    public string Version
    {
      get
      {
        var version = Windows.ApplicationModel.Package.Current.Id.Version;
        return $"{version.Major}.{version.Minor}.{version.Build}.{version.Revision}";
      }
    }

    /// <summary>
    /// Select or get current theme
    /// </summary>
    public bool? LightThemeSelected
    {
      get => shell.LightThemeSelected;
      set => shell.LightThemeSelected = value;
    }

    /// <summary>
    /// Cultures supported by this app. Static information for demo
    /// </summary>
    public List<CultureInfo> Cultures { get; set; } = new() { CultureInfo.GetCultureInfo("de-DE"), CultureInfo.GetCultureInfo("en-US") };

    private CultureInfo selectedCulture;

    /// <summary>
    /// Currently selected culture
    /// </summary>
    public CultureInfo SelectedCulture
    {
      get { return selectedCulture; }
      set
      {
        if (selectedCulture == value) return;
        selectedCulture = value;
        shell.SetResourceCulture(value.Name);
      }
    }

    /// <summary>
    /// For exercise: path to file mondial.xml
    /// </summary>
    public string PathMondial
    {
      get { return (string)Windows.Storage.ApplicationData.Current.LocalSettings.Values["pathMondial"]; }
      set { Windows.Storage.ApplicationData.Current.LocalSettings.Values["pathMondial"] = value; }
    }

  }
}
