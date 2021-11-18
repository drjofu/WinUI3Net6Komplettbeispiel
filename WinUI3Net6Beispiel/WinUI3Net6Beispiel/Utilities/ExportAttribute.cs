using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinUI3Net6Beispiel.Utilities
{
  /// <summary>
  /// For convenience only. Classes with [Export] annotation are loaded for dependency injection
  /// </summary>
  [AttributeUsage(AttributeTargets.Class, Inherited =true)]
  public class ExportAttribute:Attribute
  {
    public bool AsSingleton { get; set; }
  }
}
