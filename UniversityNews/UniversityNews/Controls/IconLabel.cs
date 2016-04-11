using Xamarin.Forms;

namespace UniversityNews.Controls
{
    public class IconLabel:Label
    {
        public IconLabel()
        {
            if (Device.OS == TargetPlatform.iOS) FontFamily = "ElegantIcons";
            if (Device.OS == TargetPlatform.Windows) FontFamily = "/Assets/Fonts/IconFont.ttf#ElegantIcons";
            else
            {
                //
            }
        }
    }
}
