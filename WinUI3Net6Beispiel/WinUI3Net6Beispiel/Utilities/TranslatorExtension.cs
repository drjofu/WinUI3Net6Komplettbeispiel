using Microsoft.UI.Xaml.Markup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinUI3Net6Beispiel.Utilities
{
  /// <summary>
  /// Utility for using language resources inside XAML
  /// </summary>
  public class TranslatorExtension : MarkupExtension
  {
    public string ResourceId { get; set; }
    public TranslatorExtension()
    {
    }

    public TranslatorExtension(string resourceId)
    {
      this.ResourceId = resourceId;
    }

    protected override object ProvideValue()
    {
      var shell = this.GetShell();
      var text = shell.GetResourceString(ResourceId);
      if (text == null) text = $"*** {ResourceId} ***";
      return text;
    }
  }
}
