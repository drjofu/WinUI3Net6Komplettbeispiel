﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinUI3Net6Beispiel.Utilities
{
  public class SettingsProvider
  {
    Windows.Storage.ApplicationDataContainer localSettings = null;
    AppSettings appSettings;

    public SettingsProvider()
    {
      try
      {
        localSettings = Windows.Storage.ApplicationData.Current.LocalSettings;
      }
      catch (Exception)
      {
      }

      try
      {
        appSettings = AppSettings.Default;
      }
      catch (Exception)
      {
      }
    }

    public object this[string key]
    {
      get
      {
        if (localSettings != null)
          return localSettings.Values[key];


        object v = null;
        try
        {
          v = appSettings[key];
        }
        catch (Exception)
        {
        }
        return v;
      }
      set
      {
        if (localSettings != null)
        {
          localSettings.Values[key] = value;
        }
        else
        {
          try
          {
            appSettings[key] = value;
            appSettings.Save();

          }
          catch (Exception ex)
          {
            Debug.WriteLine($"Setting [{key}] not save: {ex.Message}");
          }
        }
      }
    }
  }
}
