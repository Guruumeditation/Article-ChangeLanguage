using Windows.ApplicationModel.Resources;

namespace ChangeLanguageDemo
{
    public class Translation
    {
        public static string ChangeLanguageButton => ResourceLoader.GetForCurrentView().GetString("ChangeLanguageButton");
        public static string EnglishButton => ResourceLoader.GetForCurrentView().GetString("EnglishButton");
        public static string BackButton => ResourceLoader.GetForCurrentView().GetString("BackButton");
        public static string FrenchButton => ResourceLoader.GetForCurrentView().GetString("FrenchButton");
        public static string TestButton => ResourceLoader.GetForCurrentView().GetString("TestButton");
    }
}
