using Plugin.Settings;
using Plugin.Settings.Abstractions;

namespace UniversityNews.Helpers
{
    /// <summary>
    /// This is the Settings static class that can be used in your Core solution or in any
    /// of your client applications. All settings are laid out the same exact way with getters
    /// and setters. 
    /// </summary>
    public static class Settings
    {
        private static ISettings AppSettings => CrossSettings.Current;

     
        public static int Faculty
        {
            get { return AppSettings.GetValueOrDefault("FacultyKey", default(int)); }
            set { AppSettings.AddOrUpdateValue("FacultyKey", value); }
        }

        public static int Course
        {
            get { return AppSettings.GetValueOrDefault("CourseKey", 1); }
            set { AppSettings.AddOrUpdateValue("CourseKey", value); }
        }

        public static int Group
        {
            get { return AppSettings.GetValueOrDefault("GroupKey", default(int)); }
            set { AppSettings.AddOrUpdateValue("GroupKey", value); }
        }
        //Форма обучения Очная=true Заочная=false
        public static bool IsFullTime
        {
            get { return AppSettings.GetValueOrDefault("IsFullTimeKey", default(bool)); }
            set { AppSettings.AddOrUpdateValue("IsFullTimeKey", value); }
        }
        public static bool IsBachelor
        {
            get { return AppSettings.GetValueOrDefault("IsBachelorKey", default(bool)); }
            set { AppSettings.AddOrUpdateValue("IsBachelorKey", value); }
        }
        public static bool IsSubscribe
        {
            get { return AppSettings.GetValueOrDefault("SubscribeKey", true); }
            set { AppSettings.AddOrUpdateValue("SubscribeKey", value); }
        }

        public static bool IsTeacher
        {
            get { return AppSettings.GetValueOrDefault("IsTeacher", false); }
            set { AppSettings.AddOrUpdateValue("IsTeacher", value); }
        }

    }
}