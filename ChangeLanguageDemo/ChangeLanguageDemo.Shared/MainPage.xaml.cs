using System;
using System.Linq;
using Windows.ApplicationModel.Resources;
using Windows.UI.Popups;
using Windows.UI.Xaml;

namespace ChangeLanguageDemo
{
    public sealed partial class MainPage
    {
        public MainPage()
        {
            InitializeComponent();
        }


        private void LanguageButton_OnClick(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof (LanguagePage));
        }

        private async void TestButton_OnClick(object sender, RoutedEventArgs e)
        {
            var dials = new MessageDialog(ResourceLoader.GetForCurrentView().GetString("HelloWorld"));

            await dials.ShowAsync();

            var t = Frame.BackStack.ToList();
        }
    }
}
