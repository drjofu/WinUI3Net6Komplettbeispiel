using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using WinUI3Net6Beispiel.Utilities;

namespace WinUI3Net6Beispiel.Models
{
  /// <summary>
  /// World data extracted from mondial.xml (selected information of continents, countries and cities)
  /// Make sure localSettings.Values["pathMondial"] points to the path of mondial.xml or change the path inside the constructor
  /// </summary>
  [Export(AsSingleton = true)]
  public class World
  {
    public string Title { get; set; } = "Our world";

    public List<Continent> Continents { get; }

    public World()
    {
      Windows.Storage.ApplicationDataContainer localSettings = Windows.Storage.ApplicationData.Current.LocalSettings;
      string path = (string)localSettings.Values["pathMondial"];
      try
      {
        XDocument xDoc = XDocument.Load(path);
        Continents = xDoc.Root
          .Elements("continent")
          .Select(xContinent => new Continent
          {
            Name = xContinent.Element("name").Value,
            Area = (int)xContinent.Element("area"),
            Countries = xDoc.Root.Elements("country")
              .Where(xCountry => xCountry.Element("encompassed").Attribute("continent").Value == xContinent.Attribute("id").Value)
              .Select(xCountry => new Country
              {
                Name = xCountry.Element("name").Value,
                Area = (double)xCountry.Attribute("area"),
                CarCode = xCountry.Attribute("car_code").Value,
                Government = xCountry.Element("government")?.Value,
                Population = (int)xCountry.Element("population"),
                IndependenceDate = (DateTime?)xCountry.Element("indep_date"),
                Cities = xCountry.Descendants("city")
                  .Select(xCity => new City
                  {
                    Name = xCity.Element("name").Value,
                    Population = (int?)xCity.Element("population")
                  })
                  .ToList()
              })
              .ToList()
          })
          .ToList();

      }
      catch (Exception)
      {
        localSettings.Values.Remove("pathMondial");
      }
    }
  }
}
