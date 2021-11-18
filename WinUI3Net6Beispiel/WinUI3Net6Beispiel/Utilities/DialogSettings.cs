using Microsoft.UI.Xaml.Controls;

namespace WinUI3Net6Beispiel.Utilities
{
  /// <summary>
  /// Some settings for displaying dialogs
  /// </summary>
  public record DialogSettings(
    string Title, 
    string PrimaryButtonText, 
    string SecondaryButtonText,
    string CloseButtonText, 
    ContentDialogButton DefaultButton = ContentDialogButton.Primary);
}

