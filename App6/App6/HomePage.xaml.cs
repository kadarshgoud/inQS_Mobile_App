using App6.Management;
using App6.Model;
using App6.Resources;
using Plugin.Multilingual;
using System;
using System.Collections.ObjectModel;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App6
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomePage : ContentPage
    {
        public ObservableCollection<Language> Languages { get; }

        public HomePage()
        {
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

            LanguagePickerLabel.Text = AppResources.Language;
            PreferenceLabel.Text = AppResources.PreferenceLabel;
            PreferenceLabelBenutzername.Text = AppResources.PreferenceLabelBenutzername;
            PreferenceLabelBenutzerrolle.Text = AppResources.PreferenceLabelBenutzerrolle;
            PreferenceLabelEinrichtung.Text = AppResources.PreferenceLabelEinrichtung;
            PreferenceLabelWohnbereich.Text = AppResources.PreferenceLabelWohnbereich;

            BindingContext = this;

            LanguagePicker.SelectedIndex = Languages.IndexOf(Languages.Where(a => a.ShortName == DBManagement.AppLanguage.TwoLetterISOLanguageName).FirstOrDefault());

            LanguagePicker.SelectedIndexChanged += LanguagePicker_SelectedIndexChanged;
        }

        //Before page gets loaded this opertion is performed
        protected override async void OnAppearing()
        {
            base.OnAppearing();

            try
            {
                WebRequest req = WebRequest.Create(DBManagement.DBConnection + "tbl_orga_benutzername_rolle_read.php");

                req.Method = "POST";
req.Timeout = 15000;
                req.ContentType = "application/x-www-form-urlencoded";

                string postData = "einrichtung=" + App.user.id_org_einrichtung + "&wohnbereich=" + App.user.id_org_wohnbereich + "&idBew=" + App.user.id_benutzer;
                byte[] byteArray = Encoding.UTF8.GetBytes(postData);

                req.ContentLength = byteArray.Length;

                Stream ds = await req.GetRequestStreamAsync();
                await ds.WriteAsync(byteArray, 0, byteArray.Length);
                ds.Close();

                WebResponse response = await req.GetResponseAsync();

                Stream dataStream = response.GetResponseStream();

                StreamReader reader = new StreamReader(dataStream);

                string s = reader.ReadToEnd();

                string[] split = s.Split(new char[] { ':' });

                App.user.username = split[0];
                App.user.benutzer_gruppe = Convert.ToInt32(split[1]);

                Benutzername.Text = App.user.username;

                if (App.user.benutzer_gruppe == 1)
                {
                    Benutzerrolle.Text = "Benutzerrolle 1";
                }
                if (App.user.benutzer_gruppe == 2)
                {
                    Benutzerrolle.Text = "Benutzerrolle 2";
                }
                if (App.user.benutzer_gruppe == 3)
                {
                    Benutzerrolle.Text = "Benutzerrolle 3";
                }
                //Admin
                //if (App.user.benutzer_gruppe == 4)
                //{
                //    Benutzerrolle.Text = "Benutzerrolle 4";
                //}

                #region Read script for einrichtung address

                WebRequest req1 = WebRequest.Create(DBManagement.DBConnection + "tbl_orga_Einrichtung_Address.php");

                req1.Method = "POST";
                req1.ContentType = "application/x-www-form-urlencoded";

                string postData1 = "idBew=" + App.user.id_org_einrichtung;
                byte[] byteArray1 = Encoding.UTF8.GetBytes(postData1);

                req1.ContentLength = byteArray1.Length;

                Stream ds1 = req1.GetRequestStream();
                ds1.Write(byteArray1, 0, byteArray1.Length);
                ds1.Close();

                WebResponse response1 = req1.GetResponse();

                Stream dataStream1 = response1.GetResponseStream();

                StreamReader reader1 = new StreamReader(dataStream1);

                string s1 = reader1.ReadToEnd();

                App.user.einrichtung_address = s1;

                EinrichtungBox.Text = App.user.einrichtung_address;

                #endregion

                #region Reading the Wohnbereich address

                WebRequest req2 = WebRequest.Create(DBManagement.DBConnection + "tbl_orga_Wohnbereich_Address.php");

                req2.Method = "POST";
                req2.ContentType = "application/x-www-form-urlencoded";

                string postData2 = "einrichtung=" + App.user.id_org_einrichtung + "&idBew=" + App.user.id_org_wohnbereich;
                byte[] byteArray2 = Encoding.UTF8.GetBytes(postData2);

                req2.ContentLength = byteArray2.Length;

                Stream ds2 = req2.GetRequestStream();
                ds2.Write(byteArray2, 0, byteArray2.Length);
                ds2.Close();

                WebResponse response2 = req2.GetResponse();

                Stream dataStream2 = response2.GetResponseStream();

                StreamReader reader2 = new StreamReader(dataStream2);


                string s2 = reader2.ReadToEnd();

                App.user.wohnbereich_address = s2;
                WohnbereichBox.Text = App.user.wohnbereich_address;

                #endregion
            }
            catch (Exception)
            {
                await DisplayAlert(AppResources.AppError, AppResources.AppErrorMsg, "OK");
            }            
        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            Navigation.PushAsync(new FirstPage_2019_2());
        }

        private void TapGestureRecognizer_Tapped_1(object sender, EventArgs e)
        {
            Navigation.PushAsync(new SearchPage());
        }

        private void TapGestureRecognizer_Tapped_2(object sender, EventArgs e)
        {
            Navigation.PushAsync(new LoginPage());
        }

        private void TapGestureRecognizer_Tapped_3(object sender, EventArgs e)
        {

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

            LanguagePickerLabel.Text = AppResources.Language;
            PreferenceLabel.Text = AppResources.PreferenceLabel;
            PreferenceLabelBenutzername.Text = AppResources.PreferenceLabelBenutzername;
            PreferenceLabelBenutzerrolle.Text = AppResources.PreferenceLabelBenutzerrolle;
            PreferenceLabelEinrichtung.Text = AppResources.PreferenceLabelEinrichtung;
            PreferenceLabelWohnbereich.Text = AppResources.PreferenceLabelWohnbereich;
        }

        private async void Button_Clicked_1(object sender, EventArgs e)
        {
            await DisplayAlert("Abmeldung", "Sie sind erfolgreich abgemeldet", "ok");
            await Navigation.PushAsync(new MainPage());
        }

        private async void DatenschutzerklaerungButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Datenschutz());
        }
    }
}