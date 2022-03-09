using App6.Management;
using App6.Model;
using App6.Resources;
using Plugin.Multilingual;
using System;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using Xamarin.Forms;

namespace App6
{
    public partial class MainPage : ContentPage
    {
        public ObservableCollection<Language> Languages { get; }
        public MainPage()
        {
            //DBManagement.AppLanguage = CrossMultilingual.Current.DeviceCultureInfo;
            DBManagement.AppLanguage = new CultureInfo("de");
            AppResources.Culture = DBManagement.AppLanguage;
            CrossMultilingual.Current.CurrentCultureInfo = DBManagement.AppLanguage;

            InitializeComponent();

            Languages = new ObservableCollection<Language>()
            {
                new Language { DisplayName =  "English", ShortName = "en" },
                new Language { DisplayName =  "Français (🔧)", ShortName = "fr" },
                new Language { DisplayName =  "Deutsch", ShortName = "de" },
                //new Language { DisplayName =  "日本語", ShortName = "ja" },
                //new Language { DisplayName =  "한국어", ShortName = "ko" },
                //new Language { DisplayName =  "Română", ShortName = "ro" },
                new Language { DisplayName =  "Русский  (🔧)", ShortName = "ru" },
                new Language { DisplayName =  "Türkçe    (🔧)", ShortName = "tr" },
                new Language { DisplayName = "हिंदी", ShortName = "hi"}
            };

            BindingContext = this;

            LanguagePicker.SelectedIndex = Languages.IndexOf(Languages.Where(a => a.ShortName == DBManagement.AppLanguage.TwoLetterISOLanguageName).FirstOrDefault());

            LanguagePicker.SelectedIndexChanged += LanguagePicker_SelectedIndexChanged;
        }       

        private async void Button_LoginPage_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new LoginPage());
        }

        private void Button_ProjectInfo_Clicked(object sender, EventArgs e)
        {
            Device.OpenUri(new Uri("https://www.caritasnet.de/themen/alter-pflege/qualitaetssicherung/projekt-inqs/"));
        }        

        private void LanguagePicker_SelectedIndexChanged(object sender, EventArgs e)
        {
            var language = Languages[LanguagePicker.SelectedIndex];
           
            try
            {
                DBManagement.AppLanguage = new CultureInfo(language.ShortName);
                AppResources.Culture = DBManagement.AppLanguage;
                CrossMultilingual.Current.CurrentCultureInfo = DBManagement.AppLanguage;
            }
            catch (Exception)
            {

            }

            SignInButton.Text = AppResources.SignInButton;
            InformationButton.Text = AppResources.InformationButton;
            LanguagePickerLabel.Text = AppResources.Language;
        }
    }
}
