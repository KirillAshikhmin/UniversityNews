using Android.Graphics;
using UniversityNews.Controls;
using UniversityNews.Droid.Renderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(IconLabel), typeof(MyLabelRenderer))]
namespace UniversityNews.Droid.Renderers
{

    public class MyLabelRenderer : LabelRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Label> e)
        {
            base.OnElementChanged(e);
            var label = Control;
            Typeface font = Typeface.CreateFromAsset(Forms.Context.Assets, "Fonts/IconFont.ttf");
            label.Typeface = font;
        }
    }
}
