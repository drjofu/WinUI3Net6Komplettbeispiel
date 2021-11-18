using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinUI3Net6Beispiel.Models
{
  public class Country
  {
    public string Name { get; set; }
    public string CarCode { get; set; }
    public int Population { get; set; }
    public DateTime? IndependenceDate { get; set; }
    public string Government { get; set; }
    public double Area { get; set; }

    public List<City> Cities { get; set; }

  }
}
