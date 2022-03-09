using App6.Model;
using System;
using System.IO;
using System.Net;
using System.Text;
using App6.Management;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using App6.Resources;
using System.ComponentModel;

namespace App6
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Schmerzen_1 : ContentPage, INotifyPropertyChanged
    {
        public bool InitialDataIsEmpty;

        public Schmerzen_1()
        {
            InitializeComponent();
            BindingContext = this;

            BogenLabel.Text = AppResources.SurveyHeadline + " " + DBManagement.getYearCode(App.user.selected_mstr_ebqe) + " " + AppResources.SurveyHeadlineFor + " " + Erfassungsbogen.Bewohnerbezeichnung;

            t11Picker01.Items.Add("ja");
            t11Picker01.Items.Add("nein (bei nein weiter mit Frage 12)");

            t11Picker01a.Items.Add("ja (bei ja weiter mit Frage 12)");
            t11Picker01a.Items.Add("nein");

            t11Picker02_1.Items.Add("ja");
            t11Picker02_1.Items.Add("nein");

            t11Picker02_2.Items.Add("ohne Nutzung eines Instrumentes");
            t11Picker02_2.Items.Add("mit Hilfe eines Einschätzungsinstrumentes:");

            t11Picker02_3.Items.Add("NRS");
            t11Picker02_3.Items.Add("ECPA");
            t11Picker02_3.Items.Add("BESD");
            t11Picker02_3.Items.Add("VRS");
            t11Picker02_3.Items.Add("Andere");

            t11Picker02_4.Items.Add("ja");
            t11Picker02_4.Items.Add("nein");
            t11Picker02_4.Items.Add("es wurde bislang nur eine Einschätzung vorgenommen");
        }

        //Before page gets loaded this opertion is performed
        protected override async void OnAppearing()
        {
            base.OnAppearing();

            try
            {
                //ActivityIndicator = Loading...
                IsLoading = true;

                //WebRequest req = WebRequest.Create(DBManagement.DBConnection + "tbl_form_ebqe_t11_01_read.php");

                //req.Method = "POST";
                //req.Timeout = 15000;
                //req.ContentType = "application/x-www-form-urlencoded";

                //string postData = "id=" + App.user.selected_mstr_ebqe + "&einrichtung=" + App.user.id_org_einrichtung +
                //                    "&wohnbereich=" + App.user.id_org_wohnbereich + "&bewonerid=" + App.user.selected_id_bewohner;
                //byte[] byteArray = Encoding.UTF8.GetBytes(postData);

                //req.ContentLength = byteArray.Length;

                //Stream ds = await req.GetRequestStreamAsync();
                //await ds.WriteAsync(byteArray, 0, byteArray.Length);
                //ds.Close();

                //WebResponse response = await req.GetResponseAsync();

                //Stream dataStream = response.GetResponseStream();

                //StreamReader reader = new StreamReader(dataStream);

                //string s = reader.ReadToEnd();

                //string[] split = s.Split(new char[] { ':' });

                //if (split[0] != "" && split[1] != "" && split[2] != "" && split[3] != "" && split[4] != "" && split[5] != "")
                //{
                //    InitialDataIsEmpty = false;
                //}

                //Erfassungsbogen.t11field01 = split[0];
                //Erfassungsbogen.t11field01a = split[1];
                //Erfassungsbogen.t11field02_01 = split[2];
                //Erfassungsbogen.t11field02_02 = split[3];
                //Erfassungsbogen.t11field02_03 = split[4];
                //Erfassungsbogen.t11field02_04 = split[5];

                if (Erfassungsbogen.t11field01 == "0")
                {
                    t11Picker01a.IsEnabled =
                    t11field01a.IsEnabled =
                    t11field02_1.IsEnabled =
                    t11Picker02_1.IsEnabled =
                    t11field02_2.IsEnabled =
                    t11Picker02_2.IsEnabled =
                    t11field02_3.IsEnabled =
                    t11Picker02_3.IsEnabled =
                    t11field02_4.IsEnabled =
                    t11Picker02_4.IsEnabled = false;

                    t11Picker01a.Opacity =
                    t11field01a.Opacity =
                    t11field02_1.Opacity =
                    t11Picker02_1.Opacity =
                    t11field02_2.Opacity =
                    t11Picker02_2.Opacity =
                    t11field02_3.Opacity =
                    t11Picker02_3.Opacity =
                    t11field02_4.Opacity =
                    t11Picker02_4.Opacity = AppManager.QuestionDisabledOpacity;
                }

                // picker 1

                if (Erfassungsbogen.t11field01 == "1")
                {
                    t11Picker01.SelectedIndex = 0;                         // whether ja==0 by default or not ??
                }
                else if (Erfassungsbogen.t11field01 == "0")
                {
                    t11Picker01.SelectedIndex = 1;
                }
                else
                {
                    t11Picker01.SelectedIndex = -1;
                }

                //picker 1a

                if (Erfassungsbogen.t11field01a == "1")
                {
                    t11Picker01a.SelectedIndex = 0;                         // whether ja==0 by default or not ??

                    t11field02_1.IsEnabled =
                   t11Picker02_1.IsEnabled =
                   t11field02_2.IsEnabled =
                   t11Picker02_2.IsEnabled =
                   t11field02_3.IsEnabled =
                   t11Picker02_3.IsEnabled =
                   t11field02_4.IsEnabled =
                   t11Picker02_4.IsEnabled = false;

                    t11field02_1.Opacity =
                    t11Picker02_1.Opacity =
                    t11field02_2.Opacity =
                    t11Picker02_2.Opacity =
                    t11field02_3.Opacity =
                    t11Picker02_3.Opacity =
                    t11field02_4.Opacity =
                    t11Picker02_4.Opacity = AppManager.QuestionDisabledOpacity;
                }
                else if (Erfassungsbogen.t11field01a == "0")
                {
                    t11Picker01a.SelectedIndex = 1;

                    t11field02_1.IsEnabled =
                    t11Picker02_1.IsEnabled =
                    t11field02_2.IsEnabled =
                    t11Picker02_2.IsEnabled =
                    t11field02_3.IsEnabled =
                    t11Picker02_3.IsEnabled =
                    t11field02_4.IsEnabled =
                    t11Picker02_4.IsEnabled = true;

                    t11field02_1.Opacity =
                    t11Picker02_1.Opacity =
                    t11field02_2.Opacity =
                    t11Picker02_2.Opacity =
                    t11field02_3.Opacity =
                    t11Picker02_3.Opacity =
                    t11field02_4.Opacity =
                    t11Picker02_4.Opacity = AppManager.QuestionOpacity;
                }
                else
                {
                    t11Picker01a.SelectedIndex = -1;
                }

                // picker 2
                if (Erfassungsbogen.t11field02_01 == "1")
                {
                    t11Picker02_1.SelectedIndex = 0;

                    t11field02_2.IsEnabled =
                   t11Picker02_2.IsEnabled =
                   t11field02_3.IsEnabled =
                   t11Picker02_3.IsEnabled =
                   t11field02_4.IsEnabled =
                   t11Picker02_4.IsEnabled = true;

                    t11field02_2.Opacity =
                    t11Picker02_2.Opacity =
                    t11field02_3.Opacity =
                    t11Picker02_3.Opacity =
                    t11field02_4.Opacity =
                    t11Picker02_4.Opacity = AppManager.QuestionOpacity;
                }
                else if (Erfassungsbogen.t11field02_01 == "0")
                {
                    t11Picker02_1.SelectedIndex = 1;

                    t11field02_2.IsEnabled =
                  t11Picker02_2.IsEnabled =
                  t11field02_3.IsEnabled =
                  t11Picker02_3.IsEnabled =
                  t11field02_4.IsEnabled =
                  t11Picker02_4.IsEnabled = false;

                    t11field02_2.Opacity =
                    t11Picker02_2.Opacity =
                    t11field02_3.Opacity =
                    t11Picker02_3.Opacity =
                    t11field02_4.Opacity =
                    t11Picker02_4.Opacity = AppManager.QuestionDisabledOpacity;
                }
                else
                {
                    t11Picker02_1.SelectedIndex = -1;
                }

                // picker 3
                if (Erfassungsbogen.t11field02_02 == "0")
                {
                    t11Picker02_2.SelectedIndex = 0;      // rb1 is the image file with checked box image
                }
                else if (Erfassungsbogen.t11field02_02 == "1")
                {
                    t11Picker02_2.SelectedIndex = 1;
                }

                else
                {
                    t11Picker02_2.SelectedIndex = -1;
                }

                // picker 4
                if (Erfassungsbogen.t11field02_03 == "NRS")
                {
                    t11Picker02_3.SelectedIndex = 0; // rb1 is the image file with checked box image
                }
                else if (Erfassungsbogen.t11field02_03 == "ECPA")
                {
                    t11Picker02_3.SelectedIndex = 1;
                }
                else if (Erfassungsbogen.t11field02_03 == "BESD")
                {
                    t11Picker02_3.SelectedIndex = 2;
                }
                else if (Erfassungsbogen.t11field02_03 == "VRS")
                {
                    t11Picker02_3.SelectedIndex = 3;
                }
                else if (Erfassungsbogen.t11field02_03 == "0")
                {
                    t11Picker02_3.SelectedIndex = 4;
                }
                else
                {
                    t11Picker02_3.SelectedIndex = -1;
                }

                // picker 5

                if (Erfassungsbogen.t11field02_04 == "1")
                {
                    t11Picker02_4.SelectedIndex = 0; // rb1 is the image file with checked box image
                }
                else if (Erfassungsbogen.t11field02_04 == "2")
                {
                    t11Picker02_4.SelectedIndex = 2;
                }
                else if (Erfassungsbogen.t11field02_04 == "0")
                {
                    t11Picker02_4.SelectedIndex = 1;
                }

                else
                {
                    t11Picker02_4.SelectedIndex = -1;
                }
                //ActivityIndicator = Idle
                IsLoading = false;

            }
            catch (Exception)
            {
                await DisplayAlert(AppResources.AppError, AppResources.AppErrorMsg, "OK");
            }
        }

        private void T11Picker01_SelectedIndexChanged(object sender, EventArgs e)
        {
            // T11 01
            if (t11Picker01.SelectedIndex == 0)
            {
                Erfassungsbogen.t11field01 = "1";

                t11Picker01a.IsEnabled =
                t11field01a.IsEnabled =
                t11field02_1.IsEnabled =
                t11Picker02_1.IsEnabled =
                t11field02_2.IsEnabled =
                t11Picker02_2.IsEnabled =
                t11field02_3.IsEnabled =
                t11Picker02_3.IsEnabled =
                t11field02_4.IsEnabled =
                t11Picker02_4.IsEnabled = true;

                t11Picker01a.Opacity =
                t11field01a.Opacity =
                t11field02_1.Opacity =
                t11Picker02_1.Opacity =
                t11field02_2.Opacity =
                t11Picker02_2.Opacity =
                t11field02_3.Opacity =
                t11Picker02_3.Opacity =
                t11field02_4.Opacity =
                t11Picker02_4.Opacity = AppManager.QuestionOpacity;

            }
            else if (t11Picker01.SelectedIndex == 1)
            {
                Erfassungsbogen.t11field01 = "0";

                t11Picker01a.IsEnabled =
                t11field01a.IsEnabled =
                t11field02_1.IsEnabled =
                t11Picker02_1.IsEnabled =
                t11field02_2.IsEnabled =
                t11Picker02_2.IsEnabled =
                t11field02_3.IsEnabled =
                t11Picker02_3.IsEnabled =
                t11field02_4.IsEnabled =
                t11Picker02_4.IsEnabled = false;

                t11Picker01a.Opacity =
                t11field01a.Opacity =
                t11field02_1.Opacity =
                t11Picker02_1.Opacity =
                t11field02_2.Opacity =
                t11Picker02_2.Opacity =
                t11field02_3.Opacity =
                t11Picker02_3.Opacity =
                t11field02_4.Opacity =
                t11Picker02_4.Opacity = AppManager.QuestionDisabledOpacity;
            }
        }

        private void T11Picker01a_SelectedIndexChanged(object sender, EventArgs e)
        {
            // T11 01
            if (t11Picker01a.SelectedIndex == 0)
            {
                Erfassungsbogen.t11field01a = "1";

                t11field02_1.IsEnabled =
                t11Picker02_1.IsEnabled =
                t11field02_2.IsEnabled =
                t11Picker02_2.IsEnabled =
                t11field02_3.IsEnabled =
                t11Picker02_3.IsEnabled =
                t11field02_4.IsEnabled =
                t11Picker02_4.IsEnabled = false;

                t11field02_1.Opacity =
                t11Picker02_1.Opacity =
                t11field02_2.Opacity =
                t11Picker02_2.Opacity =
                t11field02_3.Opacity =
                t11Picker02_3.Opacity =
                t11field02_4.Opacity =
                t11Picker02_4.Opacity = AppManager.QuestionDisabledOpacity;

            }
            else if (t11Picker01a.SelectedIndex == 1)
            {
                Erfassungsbogen.t11field01a = "0";

                t11field02_1.IsEnabled =
                t11Picker02_1.IsEnabled =
                t11field02_2.IsEnabled =
                t11Picker02_2.IsEnabled =
                t11field02_3.IsEnabled =
                t11Picker02_3.IsEnabled =
                t11field02_4.IsEnabled =
                t11Picker02_4.IsEnabled = true;

                t11field02_1.Opacity =
                t11Picker02_1.Opacity =
                t11field02_2.Opacity =
                t11Picker02_2.Opacity =
                t11field02_3.Opacity =
                t11Picker02_3.Opacity =
                t11field02_4.Opacity =
                t11Picker02_4.Opacity = AppManager.QuestionOpacity;
            }
        }

        private void T11Picker02_1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //t11 02_01
            if (t11Picker02_1.SelectedIndex == 0)
            {
                Erfassungsbogen.t11field02_01 = "1";

                t11field02_2.IsEnabled =
                t11Picker02_2.IsEnabled =
                t11field02_3.IsEnabled =
                t11Picker02_3.IsEnabled =
                t11field02_4.IsEnabled =
                t11Picker02_4.IsEnabled = true;

                t11field02_2.Opacity =
                t11Picker02_2.Opacity =
                t11field02_3.Opacity =
                t11Picker02_3.Opacity =
                t11field02_4.Opacity =
                t11Picker02_4.Opacity = AppManager.QuestionOpacity;
            }
            else if (t11Picker02_1.SelectedIndex == 1)
            {
                Erfassungsbogen.t11field02_01 = "0";

                t11field02_2.IsEnabled =
                t11Picker02_2.IsEnabled =
                t11field02_3.IsEnabled =
                t11Picker02_3.IsEnabled =
                t11field02_4.IsEnabled =
                t11Picker02_4.IsEnabled = false;

                t11field02_2.Opacity =
                t11Picker02_2.Opacity =
                t11field02_3.Opacity =
                t11Picker02_3.Opacity =
                t11field02_4.Opacity =
                t11Picker02_4.Opacity = AppManager.QuestionDisabledOpacity;
            }
        }

        private async void BackButton_TappedAsync(object sender, EventArgs e)
        {
            BackButton.Source = "ic_arrow_back_ios_tapped.png";

            try
            {
                //ActivityIndicator = Loading...
                IsLoading = true;

                if (App.user.selected_mstr_ebqe != DBManagement.CurrentEvaluationID)
                {
                    await Navigation.PushAsync(new SearchPage());
                }
                else
                {
                    var BackQuestion = await DisplayAlert(AppResources.Information, AppResources.InformationSaveQuery, AppResources.Yes, AppResources.No);
                    if (BackQuestion == true)
                    {
                        t11field01.TextColor = t11field02_1.TextColor = t11field02_2.TextColor = t11field02_3.TextColor = t11field02_4.TextColor = AppManager.QuestionColor;

                        if ((Erfassungsbogen.t11field01 == "") || (Erfassungsbogen.t11field01 == null))
                        {
                            t11field01.TextColor = Color.Red;

                            await DisplayAlert(AppResources.Warning, AppResources.FieldsUnfilled, "OK");
                            BackButton.Source = "ic_arrow_back_ios.png";
                        }
                        else
                        {
                            if (Erfassungsbogen.t11field01 == "0")
                            {
                                WebRequest req = WebRequest.Create(DBManagement.DBConnection + "tbl_form_ebqe_t11_01_update.php");

                                req.Method = "POST"; //POST
                                req.Timeout = 15000;
                                req.ContentType = "application/x-www-form-urlencoded";

                                string postData = "mstr=" + App.user.selected_mstr_ebqe + "&bewonerid=" + App.user.selected_id_bewohner + "&t11field01=" + Erfassungsbogen.t11field01 + "&t11field01a=" + Erfassungsbogen.t11field01a + "&t11field02_01=" + Erfassungsbogen.t11field02_01 + "&t11field02_02=" + Erfassungsbogen.t11field02_02 + "&t11field02_03=" + Erfassungsbogen.t11field02_03 + "&t11field02_04=" + Erfassungsbogen.t11field02_04;

                                byte[] byteArray = Encoding.UTF8.GetBytes(postData);

                                req.ContentLength = byteArray.Length;

                                Stream ds = await req.GetRequestStreamAsync();
                                await ds.WriteAsync(byteArray, 0, byteArray.Length);
                                ds.Close();

                                await Navigation.PushAsync(new SearchPage());
                            }

                            if (Erfassungsbogen.t11field01 == "1")
                            {
                                if (Erfassungsbogen.t11field01a == "" | Erfassungsbogen.t11field01a == null)
                                {
                                    t11field01a.TextColor = Color.Red;

                                    await DisplayAlert(AppResources.Warning, AppResources.FieldsUnfilled, "OK");
                                    BackButton.Source = "ic_arrow_back_ios.png";
                                }
                                else
                                {
                                    if (Erfassungsbogen.t11field01a == "1")
                                    {
                                        WebRequest req = WebRequest.Create(DBManagement.DBConnection + "tbl_form_ebqe_t11_01_update.php");

                                        req.Method = "POST"; //POST
                                        req.Timeout = 15000;
                                        req.ContentType = "application/x-www-form-urlencoded";

                                        string postData = "mstr=" + App.user.selected_mstr_ebqe + "&bewonerid=" + App.user.selected_id_bewohner + "&t11field01=" + Erfassungsbogen.t11field01 + "&t11field01a=" + Erfassungsbogen.t11field01a + "&t11field02_01=" + Erfassungsbogen.t11field02_01 + "&t11field02_02=" + Erfassungsbogen.t11field02_02 + "&t11field02_03=" + Erfassungsbogen.t11field02_03 + "&t11field02_04=" + Erfassungsbogen.t11field02_04;

                                        byte[] byteArray = Encoding.UTF8.GetBytes(postData);

                                        req.ContentLength = byteArray.Length;

                                        Stream ds = await req.GetRequestStreamAsync();
                                        await ds.WriteAsync(byteArray, 0, byteArray.Length);
                                        ds.Close();

                                        await Navigation.PushAsync(new SearchPage());
                                    }

                                    if (Erfassungsbogen.t11field01a == "0")
                                    {
                                        if (Erfassungsbogen.t11field02_01 == "" || Erfassungsbogen.t11field02_01 == null)
                                        {
                                            t11field02_1.TextColor = Color.Red;

                                            await DisplayAlert(AppResources.Warning, AppResources.FieldsUnfilled, "OK");
                                            BackButton.Source = "ic_arrow_back_ios.png";
                                        }
                                        else
                                        {
                                            if (Erfassungsbogen.t11field02_01 == "0")
                                            {
                                                WebRequest req = WebRequest.Create(DBManagement.DBConnection + "tbl_form_ebqe_t11_01_update.php");

                                                req.Method = "POST"; //POST
                                                req.Timeout = 15000;
                                                req.ContentType = "application/x-www-form-urlencoded";

                                                string postData = "mstr=" + App.user.selected_mstr_ebqe + "&bewonerid=" + App.user.selected_id_bewohner + "&t11field01=" + Erfassungsbogen.t11field01 + "&t11field01a=" + Erfassungsbogen.t11field01a + "&t11field02_01=" + Erfassungsbogen.t11field02_01 + "&t11field02_02=" + Erfassungsbogen.t11field02_02 + "&t11field02_03=" + Erfassungsbogen.t11field02_03 + "&t11field02_04=" + Erfassungsbogen.t11field02_04;

                                                byte[] byteArray = Encoding.UTF8.GetBytes(postData);

                                                req.ContentLength = byteArray.Length;

                                                Stream ds = await req.GetRequestStreamAsync();
                                                await ds.WriteAsync(byteArray, 0, byteArray.Length);
                                                ds.Close();

                                                await Navigation.PushAsync(new SearchPage());
                                            }

                                            if (Erfassungsbogen.t11field02_01 == "1")
                                            {
                                                if (Erfassungsbogen.t11field02_02 == "" || Erfassungsbogen.t11field02_02 == null)
                                                {
                                                    t11field02_2.TextColor = Color.Red;

                                                    await DisplayAlert(AppResources.Warning, AppResources.FieldsUnfilled, "OK");
                                                    BackButton.Source = "ic_arrow_back_ios.png";
                                                }

                                                if (Erfassungsbogen.t11field02_02 == "1")
                                                {
                                                    if (Erfassungsbogen.t11field02_03 == "" || Erfassungsbogen.t11field02_03 == null)
                                                    {
                                                        t11field02_3.TextColor = Color.Red;

                                                        await DisplayAlert(AppResources.Warning, AppResources.FieldsUnfilled, "OK");
                                                        BackButton.Source = "ic_arrow_back_ios.png";
                                                    }

                                                    if (Erfassungsbogen.t11field02_03 != "")
                                                    {
                                                        if (Erfassungsbogen.t11field02_04 == "" || Erfassungsbogen.t11field02_04 == null)
                                                        {
                                                            t11field02_4.TextColor = Color.Red;

                                                            await DisplayAlert(AppResources.Warning, AppResources.FieldsUnfilled, "OK");
                                                            BackButton.Source = "ic_arrow_back_ios.png";
                                                        }

                                                        if (Erfassungsbogen.t11field02_04 != "")
                                                        {
                                                            WebRequest req = WebRequest.Create(DBManagement.DBConnection + "tbl_form_ebqe_t11_01_update.php");

                                                            req.Method = "POST"; //POST
                                                            req.Timeout = 15000;
                                                            req.ContentType = "application/x-www-form-urlencoded";

                                                            string postData = "mstr=" + App.user.selected_mstr_ebqe + "&bewonerid=" + App.user.selected_id_bewohner + "&t11field01=" + Erfassungsbogen.t11field01 + "&t11field01a=" + Erfassungsbogen.t11field01a + "&t11field02_01=" + Erfassungsbogen.t11field02_01 + "&t11field02_02=" + Erfassungsbogen.t11field02_02 + "&t11field02_03=" + Erfassungsbogen.t11field02_03 + "&t11field02_04=" + Erfassungsbogen.t11field02_04;

                                                            byte[] byteArray = Encoding.UTF8.GetBytes(postData);

                                                            req.ContentLength = byteArray.Length;

                                                            Stream ds = await req.GetRequestStreamAsync();
                                                            await ds.WriteAsync(byteArray, 0, byteArray.Length);
                                                            ds.Close();

                                                            await Navigation.PushAsync(new SearchPage());
                                                        }
                                                    }
                                                }
                                                else
                                                {
                                                    if (Erfassungsbogen.t11field02_04 == "" || Erfassungsbogen.t11field02_04 == null)
                                                    {
                                                        t11field02_4.TextColor = Color.Red;

                                                        await DisplayAlert(AppResources.Warning, AppResources.FieldsUnfilled, "OK");
                                                        BackButton.Source = "ic_arrow_back_ios.png";
                                                    }

                                                    if (Erfassungsbogen.t11field02_04 != "")
                                                    {
                                                        WebRequest req = WebRequest.Create(DBManagement.DBConnection + "tbl_form_ebqe_t11_01_update.php");

                                                        req.Method = "POST"; //POST
                                                        req.Timeout = 15000;
                                                        req.ContentType = "application/x-www-form-urlencoded";

                                                        string postData = "mstr=" + App.user.selected_mstr_ebqe + "&bewonerid=" + App.user.selected_id_bewohner + "&t11field01=" + Erfassungsbogen.t11field01 + "&t11field01a=" + Erfassungsbogen.t11field01a + "&t11field02_01=" + Erfassungsbogen.t11field02_01 + "&t11field02_02=" + Erfassungsbogen.t11field02_02 + "&t11field02_03=" + Erfassungsbogen.t11field02_03 + "&t11field02_04=" + Erfassungsbogen.t11field02_04;

                                                        byte[] byteArray = Encoding.UTF8.GetBytes(postData);

                                                        req.ContentLength = byteArray.Length;

                                                        Stream ds = await req.GetRequestStreamAsync();
                                                        await ds.WriteAsync(byteArray, 0, byteArray.Length);
                                                        ds.Close();

                                                        await Navigation.PushAsync(new SearchPage());
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        Erfassungsbogen.t11field01 = Erfassungsbogen.t11field01a = Erfassungsbogen.t11field02_01 = Erfassungsbogen.t11field02_02 = Erfassungsbogen.t11field02_03 = Erfassungsbogen.t11field02_04 = "";

                        WebRequest req = WebRequest.Create(DBManagement.DBConnection + "tbl_form_ebqe_t11_01_update.php");

                        req.Method = "POST"; //POST
                        req.Timeout = 15000;
                        req.ContentType = "application/x-www-form-urlencoded";

                        string postData = "mstr=" + App.user.selected_mstr_ebqe + "&bewonerid=" + App.user.selected_id_bewohner + "&t11field01=" + Erfassungsbogen.t11field01 + "&t11field01a=" + Erfassungsbogen.t11field01a + "&t11field02_01=" + Erfassungsbogen.t11field02_01 + "&t11field02_02=" + Erfassungsbogen.t11field02_02 + "&t11field02_03=" + Erfassungsbogen.t11field02_03 + "&t11field02_04=" + Erfassungsbogen.t11field02_04;

                        byte[] byteArray = Encoding.UTF8.GetBytes(postData);

                        req.ContentLength = byteArray.Length;

                        Stream ds = await req.GetRequestStreamAsync();
                        await ds.WriteAsync(byteArray, 0, byteArray.Length);
                        ds.Close();

                        await Navigation.PushAsync(new SearchPage());
                    }
                }
                //ActivityIndicator = Idle
                IsLoading = false;

            }
            catch (Exception)
            {
                await DisplayAlert(AppResources.AppError, AppResources.AppErrorMsg, "OK");
                BackButton.Source = "ic_arrow_back_ios.png";
            }
        }

        private async void ForwardButton_TappedAsync(object sender, EventArgs e)
        {
            ForwardButton.Source = "ic_arrow_forward_ios_tapped.png";

            try
            {
                //ActivityIndicator = Loading...
                IsLoading = true;

                if (App.user.selected_mstr_ebqe != DBManagement.CurrentEvaluationID)
                {
                    await Navigation.PushAsync(new Schmerzen_2());
                }
                else
                {
                    t11field01.TextColor = t11field02_1.TextColor = t11field02_2.TextColor = t11field02_3.TextColor = t11field02_4.TextColor = AppManager.QuestionColor;

                    if ((Erfassungsbogen.t11field01 == "") || (Erfassungsbogen.t11field01 == null))
                    {
                        t11field01.TextColor = Color.Red;

                        await DisplayAlert(AppResources.Warning, AppResources.FieldsUnfilled, "OK");
                        ForwardButton.Source = "ic_arrow_forward_ios.png";
                    }
                    else
                    {
                        if (Erfassungsbogen.t11field01 == "0")
                        {
                            WebRequest req = WebRequest.Create(DBManagement.DBConnection + "tbl_form_ebqe_t11_01_update.php");

                            req.Method = "POST"; //POST
                            req.Timeout = 15000;
                            req.ContentType = "application/x-www-form-urlencoded";

                            string postData = "mstr=" + App.user.selected_mstr_ebqe + "&bewonerid=" + App.user.selected_id_bewohner + "&t11field01=" + Erfassungsbogen.t11field01 + "&t11field01a=" + Erfassungsbogen.t11field01a + "&t11field02_01=" + Erfassungsbogen.t11field02_01 + "&t11field02_02=" + Erfassungsbogen.t11field02_02 + "&t11field02_03=" + Erfassungsbogen.t11field02_03 + "&t11field02_04=" + Erfassungsbogen.t11field02_04;

                            byte[] byteArray = Encoding.UTF8.GetBytes(postData);

                            req.ContentLength = byteArray.Length;

                            Stream ds = await req.GetRequestStreamAsync();
                            await ds.WriteAsync(byteArray, 0, byteArray.Length);
                            ds.Close();

                            await Navigation.PushAsync(new Schmerzen_2());
                        }

                        if (Erfassungsbogen.t11field01 == "1")
                        {
                            if (Erfassungsbogen.t11field01a == "" | Erfassungsbogen.t11field01a == null)
                            {
                                t11field01a.TextColor = Color.Red;

                                await DisplayAlert(AppResources.Warning, AppResources.FieldsUnfilled, "OK");
                                ForwardButton.Source = "ic_arrow_forward_ios.png";
                            }
                            else
                            {
                                if (Erfassungsbogen.t11field01a == "1")
                                {
                                    WebRequest req = WebRequest.Create(DBManagement.DBConnection + "tbl_form_ebqe_t11_01_update.php");

                                    req.Method = "POST"; //POST
                                    req.Timeout = 15000;
                                    req.ContentType = "application/x-www-form-urlencoded";

                                    string postData = "mstr=" + App.user.selected_mstr_ebqe + "&bewonerid=" + App.user.selected_id_bewohner + "&t11field01=" + Erfassungsbogen.t11field01 + "&t11field01a=" + Erfassungsbogen.t11field01a + "&t11field02_01=" + Erfassungsbogen.t11field02_01 + "&t11field02_02=" + Erfassungsbogen.t11field02_02 + "&t11field02_03=" + Erfassungsbogen.t11field02_03 + "&t11field02_04=" + Erfassungsbogen.t11field02_04;

                                    byte[] byteArray = Encoding.UTF8.GetBytes(postData);

                                    req.ContentLength = byteArray.Length;

                                    Stream ds = await req.GetRequestStreamAsync();
                                    await ds.WriteAsync(byteArray, 0, byteArray.Length);
                                    ds.Close();

                                    await Navigation.PushAsync(new Schmerzen_2());
                                }

                                if (Erfassungsbogen.t11field01a == "0")
                                {
                                    if (Erfassungsbogen.t11field02_01 == "" || Erfassungsbogen.t11field02_01 == null)
                                    {
                                        t11field02_1.TextColor = Color.Red;

                                        await DisplayAlert(AppResources.Warning, AppResources.FieldsUnfilled, "OK");
                                        ForwardButton.Source = "ic_arrow_forward_ios.png";
                                    }
                                    else
                                    {
                                        if (Erfassungsbogen.t11field02_01 == "0")
                                        {
                                            WebRequest req = WebRequest.Create(DBManagement.DBConnection + "tbl_form_ebqe_t11_01_update.php");

                                            req.Method = "POST"; //POST
                                            req.Timeout = 15000;
                                            req.ContentType = "application/x-www-form-urlencoded";

                                            string postData = "mstr=" + App.user.selected_mstr_ebqe + "&bewonerid=" + App.user.selected_id_bewohner + "&t11field01=" + Erfassungsbogen.t11field01 + "&t11field01a=" + Erfassungsbogen.t11field01a + "&t11field02_01=" + Erfassungsbogen.t11field02_01 + "&t11field02_02=" + Erfassungsbogen.t11field02_02 + "&t11field02_03=" + Erfassungsbogen.t11field02_03 + "&t11field02_04=" + Erfassungsbogen.t11field02_04;

                                            byte[] byteArray = Encoding.UTF8.GetBytes(postData);

                                            req.ContentLength = byteArray.Length;

                                            Stream ds = await req.GetRequestStreamAsync();
                                            await ds.WriteAsync(byteArray, 0, byteArray.Length);
                                            ds.Close();

                                            await Navigation.PushAsync(new Schmerzen_2());
                                        }

                                        if (Erfassungsbogen.t11field02_01 == "1")
                                        {
                                            if (Erfassungsbogen.t11field02_02 == "" || Erfassungsbogen.t11field02_02 == null)
                                            {
                                                t11field02_2.TextColor = Color.Red;

                                                await DisplayAlert(AppResources.Warning, AppResources.FieldsUnfilled, "OK");
                                                ForwardButton.Source = "ic_arrow_forward_ios.png";
                                            }

                                            if (Erfassungsbogen.t11field02_02 == "1")
                                            {
                                                if (Erfassungsbogen.t11field02_03 == "" || Erfassungsbogen.t11field02_03 == null)
                                                {
                                                    t11field02_3.TextColor = Color.Red;

                                                    await DisplayAlert(AppResources.Warning, AppResources.FieldsUnfilled, "OK");
                                                    ForwardButton.Source = "ic_arrow_forward_ios.png";
                                                }

                                                if (Erfassungsbogen.t11field02_03 != "")
                                                {
                                                    if (Erfassungsbogen.t11field02_04 == "" || Erfassungsbogen.t11field02_04 == null)
                                                    {
                                                        t11field02_4.TextColor = Color.Red;

                                                        await DisplayAlert(AppResources.Warning, AppResources.FieldsUnfilled, "OK");
                                                        ForwardButton.Source = "ic_arrow_forward_ios.png";
                                                    }

                                                    if (Erfassungsbogen.t11field02_04 != "")
                                                    {
                                                        WebRequest req = WebRequest.Create(DBManagement.DBConnection + "tbl_form_ebqe_t11_01_update.php");

                                                        req.Method = "POST"; //POST
                                                        req.Timeout = 15000;
                                                        req.ContentType = "application/x-www-form-urlencoded";

                                                        string postData = "mstr=" + App.user.selected_mstr_ebqe + "&bewonerid=" + App.user.selected_id_bewohner + "&t11field01=" + Erfassungsbogen.t11field01 + "&t11field01a=" + Erfassungsbogen.t11field01a + "&t11field02_01=" + Erfassungsbogen.t11field02_01 + "&t11field02_02=" + Erfassungsbogen.t11field02_02 + "&t11field02_03=" + Erfassungsbogen.t11field02_03 + "&t11field02_04=" + Erfassungsbogen.t11field02_04;

                                                        byte[] byteArray = Encoding.UTF8.GetBytes(postData);

                                                        req.ContentLength = byteArray.Length;

                                                        Stream ds = await req.GetRequestStreamAsync();
                                                        await ds.WriteAsync(byteArray, 0, byteArray.Length);
                                                        ds.Close();

                                                        await Navigation.PushAsync(new Schmerzen_2());
                                                    }
                                                }
                                            }
                                            else
                                            {
                                                if (Erfassungsbogen.t11field02_04 == "" || Erfassungsbogen.t11field02_04 == null)
                                                {
                                                    t11field02_4.TextColor = Color.Red;

                                                    await DisplayAlert(AppResources.Warning, AppResources.FieldsUnfilled, "OK");
                                                    ForwardButton.Source = "ic_arrow_forward_ios.png";
                                                }

                                                if (Erfassungsbogen.t11field02_04 != "")
                                                {
                                                    WebRequest req = WebRequest.Create(DBManagement.DBConnection + "tbl_form_ebqe_t11_01_update.php");

                                                    req.Method = "POST"; //POST
                                                    req.Timeout = 15000;
                                                    req.ContentType = "application/x-www-form-urlencoded";

                                                    string postData = "mstr=" + App.user.selected_mstr_ebqe + "&bewonerid=" + App.user.selected_id_bewohner + "&t11field01=" + Erfassungsbogen.t11field01 + "&t11field01a=" + Erfassungsbogen.t11field01a + "&t11field02_01=" + Erfassungsbogen.t11field02_01 + "&t11field02_02=" + Erfassungsbogen.t11field02_02 + "&t11field02_03=" + Erfassungsbogen.t11field02_03 + "&t11field02_04=" + Erfassungsbogen.t11field02_04;

                                                    byte[] byteArray = Encoding.UTF8.GetBytes(postData);

                                                    req.ContentLength = byteArray.Length;

                                                    Stream ds = await req.GetRequestStreamAsync();
                                                    await ds.WriteAsync(byteArray, 0, byteArray.Length);
                                                    ds.Close();

                                                    await Navigation.PushAsync(new Schmerzen_2());
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                //ActivityIndicator = Idle
                IsLoading = false;

            }
            catch (Exception)
            {
                await DisplayAlert(AppResources.AppError, AppResources.AppErrorMsg, "OK");
                ForwardButton.Source = "ic_arrow_forward_ios.png";
            }
        }

        private void T11Picker02_2_SelectedIndexChanged(object sender, EventArgs e)
        {
            // t11 02_02
            if (t11Picker02_2.SelectedIndex == 0)
            {
                Erfassungsbogen.t11field02_02 = "0";

                t11field02_3.IsEnabled = t11Picker02_3.IsEnabled = false;
                t11field02_3.Opacity = AppManager.QuestionDisabledOpacity;
            }
            else if (t11Picker02_2.SelectedIndex == 1)
            {
                t11field02_3.IsEnabled = t11Picker02_3.IsEnabled = true;
                t11field02_3.Opacity = AppManager.QuestionOpacity;

                Erfassungsbogen.t11field02_02 = "1";
            }
        }

        private void T11Picker02_3_SelectedIndexChanged(object sender, EventArgs e)
        {
            // T11 02_03

            if (t11Picker02_3.SelectedIndex == 0)
            {
                Erfassungsbogen.t11field02_03 = "NRS";
            }
            else if (t11Picker02_3.SelectedIndex == 1)
            {
                Erfassungsbogen.t11field02_03 = "ECPA";
            }
            else if (t11Picker02_3.SelectedIndex == 2)
            {
                Erfassungsbogen.t11field02_03 = "BESD";
            }
            else if (t11Picker02_3.SelectedIndex == 3)
            {
                Erfassungsbogen.t11field02_03 = "VRS";
            }
            else if (t11Picker02_3.SelectedIndex == 4)
            {
                Erfassungsbogen.t11field02_03 = "0";
            }
        }

        private void T11Picker02_4_SelectedIndexChanged(object sender, EventArgs e)
        {
            // T11 02_04
            if (t11Picker02_4.SelectedIndex == 0)
            {
                Erfassungsbogen.t11field02_04 = "1";
            }
            else if (t11Picker02_4.SelectedIndex == 1)
            {
                Erfassungsbogen.t11field02_04 = "0";
            }
            else if (t11Picker02_4.SelectedIndex == 2)
            {
                Erfassungsbogen.t11field02_04 = "2";
            }
        }

        #region Activity Indicator Properties + INotifyPropertyChanged

        private bool isLoading;
        public bool IsLoading
        {
            get
            {
                return isLoading;
            }

            set
            {
                isLoading = value;
                RaisePropertyChanged("IsLoading");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void RaisePropertyChanged(string propName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }

        #endregion
    }
}