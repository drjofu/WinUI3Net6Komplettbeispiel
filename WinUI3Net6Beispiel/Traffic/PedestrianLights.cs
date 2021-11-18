using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Shapes;
using Windows.UI;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace Traffic
{
  [TemplatePart(Name = "PART_LampeRot", Type = typeof(Shape))]
  [TemplatePart(Name = "PART_LampeGruen", Type = typeof(Shape))]
  public sealed class PedestrianLights : Control
  {
    public PedestrianLights()
    {
      // OverrideMetadata wie in WPF gibt es hier nicht!
      this.DefaultStyleKey = typeof(PedestrianLights);
      this.Width = 80;
      this.Height = 130;
      this.Background = new SolidColorBrush(Color.FromArgb(0xff, 20, 20, 20));
      
    }

    private Shape lightRed;
    private Shape lightGreen;



    public bool? IsRed
    {
      get { return (bool?)GetValue(IsRedProperty); }
      set { SetValue(IsRedProperty, value); }
    }

    // Using a DependencyProperty as the backing store for IsRed.  This enables animation, styling, binding, etc...
    public static readonly DependencyProperty IsRedProperty =
        DependencyProperty.Register("IsRed", typeof(bool?), typeof(PedestrianLights), new PropertyMetadata(true,OnIsRedChanged));

    private static void OnIsRedChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
      var pedLight = d as PedestrianLights;
      pedLight.Switch();
    }

    protected override void OnApplyTemplate()
    {
      base.OnApplyTemplate();
      lightRed = (Shape)this.GetTemplateChild("PART_LightRed");
      lightGreen = (Shape)this.GetTemplateChild("PART_LightGreen");
      Switch();

    }

    private void Switch()
    {
      if (lightRed == null) return;

      if (IsRed ?? true)
      {
        lightRed.Opacity = 1;
        lightGreen.Opacity = 0.2;
      }
      else
      {
        lightRed.Opacity = 0.2;
        lightGreen.Opacity = 1;
      }
    }

  }
}
