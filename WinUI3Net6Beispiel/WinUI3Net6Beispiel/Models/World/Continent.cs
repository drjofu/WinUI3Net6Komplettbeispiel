using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinUI3Net6Beispiel.Models
{
  public class Continent
  {
    public string Name { get; set; }
    public int Area { get; set; }
    public List<Country> Countries { get; set; }
  }
}
