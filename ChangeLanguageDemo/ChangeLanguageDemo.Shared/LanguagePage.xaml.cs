using System;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Navigation;
#if WINDOWS_PHONE_APP
using Windows.Phone.UI.Input;
#endif

namespace ChangeLanguageDemo
{
    public sealed partial class LanguagePage
    {
        public LanguagePage()
        {
            InitializeComponent();

#if WINDOWS_PHONE_APP
            HardwareButtons.BackPressed += HardwareButtons_BackPressed;

            NavigationCacheMode = NavigationCacheMode.Disabled;
#endif
        }

#if WINDOWS_PHONE_APP
        private void HardwareButtons_BackPressed(object sender, BackPressedEventArgs e)
        {
            Frame.GoBack();
            e.Handled = true;
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            HardwareButtons.BackPressed -= HardwareButtons_BackPressed;
            base.OnNavigatedFrom(e);
        }
#endif


        private async void EnglishButton_OnClick(object sender, RoutedEventArgs e)
        {
            ChangeLanguage("en");
        }

        private async void FrenchButton_OnClick(object sender, RoutedEventArgs e)
        {
            ChangeLanguage("fr");
        }

        private void BackButton_OnClick(object sender, RoutedEventArgs e)
        {
            Frame.GoBack();
        }

        private void ChangeLanguage(string language)
        {
            var culture = new System.Globalization.CultureInfo(language);

            Windows.Globalization.ApplicationLanguages.PrimaryLanguageOverride = culture.Name;

            Windows.ApplicationModel.Resources.Core.ResourceContext.GetForCurrentView().Reset();
            Windows.ApplicationModel.Resources.Core.ResourceContext.GetForViewIndependentUse().Reset();

            Reload();

        }

        private bool Reload(object param = null)
        {
            var type = Frame.CurrentSourcePageType;

            try
            {
                return Frame.Navigate(type, param);
            }
            finally
            {
                Frame.BackStack.Remove(Frame.BackStack.Last());
            }

        }

    }
}
