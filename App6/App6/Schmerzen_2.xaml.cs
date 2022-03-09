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
    public partial class Schmerzen_2 : ContentPage, INotifyPropertyChanged
    {
        public bool InitialDataIsEmpty;

        public Schmerzen_2()
        {
            InitializeComponent();
            BindingContext = this;

            BogenLabel.Text = AppResources.SurveyHeadline + " " + DBManagement.getYearCode(App.user.selected_mstr_ebqe) + " " + AppResources.SurveyHeadlineFor + " " + Erfassungsbogen.Bewohnerbezeichnung;

            t11Picker04.Items.Add("ja");
            t11Picker04.Items.Add("nein (bei nein weiter mit Frage 11.4)");

            t11Picker05.Items.Add("ja");
            t11Picker05.Items.Add("nein");
        }

        //Before page gets loaded this opertion is performed
        protected override async void OnAppearing()
        {
            base.OnAppearing();

            try
            {
                //ActivityIndicator = Loading...
                IsLoading = true;

                //WebRequest req = WebRequest.Create(DBManagement.DBConnection + "tbl_form_ebqe_t11_02_read.php");

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

                //if (split[0] != "" && split[1] != "" && split[2] != "" && split[3] != "" && split[4] != "")
                //{
                //    InitialDataIsEmpty = false;
                //}

                //Erfassungsbogen.t11field02_05 = split[0];
                //Erfassungsbogen.t11field02_06 = split[1];
                //Erfassungsbogen.t11field03_01 = split[2];
                //Erfassungsbogen.t11field03_02 = split[3];

                //Erfassungsbogen.t11field04 = split[4];

                if (Erfassungsbogen.t11field01a == "0" && Erfassungsbogen.t11field02_01 == "1")
                {
                    Label_t11field02_05.IsEnabled =
                    DatePicker_t11field02_05.IsEnabled =
                    Entry_t11field02_05.IsEnabled =
                    ResetLabel_t11field02_05.IsEnabled =
                    Label_t11field02_06.IsEnabled =
                    DatePicker_t11field02_06.IsEnabled =
                    Entry_t11field02_06.IsEnabled =
                    ResetLabel_t11field02_06.IsEnabled =
                    Picker01.IsEnabled =
                    t11Picker04.IsEnabled =
                      Label_t11field03_02.IsEnabled =
                     DatePicker_t11field03_02.IsEnabled =
                     Entry_t11field03_02.IsEnabled =
                     ResetLabel_t11field03_02.IsEnabled =
                    Picker02.IsEnabled =
                    t11Picker05.IsEnabled = true;

                    Label_t11field02_05.Opacity =
                   DatePicker_t11field02_05.Opacity =
                   Entry_t11field02_05.Opacity =
                   ResetLabel_t11field02_05.Opacity =
                   Label_t11field02_06.Opacity =
                   DatePicker_t11field02_06.Opacity =
                   Entry_t11field02_06.Opacity =
                   ResetLabel_t11field02_06.Opacity =
                   Picker01.Opacity =
                   t11Picker04.Opacity =
                     Label_t11field03_02.Opacity =
                    DatePicker_t11field03_02.Opacity =
                    Entry_t11field03_02.Opacity =
                    ResetLabel_t11field03_02.Opacity =
                   Picker02.Opacity =
                   t11Picker05.Opacity = AppManager.QuestionOpacity;
                }
                else
                {
                    Label_t11field02_05.IsEnabled =
                   DatePicker_t11field02_05.IsEnabled =
                   Entry_t11field02_05.IsEnabled =
                   ResetLabel_t11field02_05.IsEnabled =
                   Label_t11field02_06.IsEnabled =
                   DatePicker_t11field02_06.IsEnabled =
                   Entry_t11field02_06.IsEnabled =
                   ResetLabel_t11field02_06.IsEnabled =
                   Picker01.IsEnabled =
                   t11Picker04.IsEnabled =
                     Label_t11field03_02.IsEnabled =
                    DatePicker_t11field03_02.IsEnabled =
                    Entry_t11field03_02.IsEnabled =
                    ResetLabel_t11field03_02.IsEnabled =
                   Picker02.IsEnabled =
                   t11Picker05.IsEnabled = false;

                    Label_t11field02_05.Opacity =
                   DatePicker_t11field02_05.Opacity =
                   Entry_t11field02_05.Opacity =
                   ResetLabel_t11field02_05.Opacity =
                   Label_t11field02_06.Opacity =
                   DatePicker_t11field02_06.Opacity =
                   Entry_t11field02_06.Opacity =
                   ResetLabel_t11field02_06.Opacity =
                   Picker01.Opacity =
                   t11Picker04.Opacity =
                     Label_t11field03_02.Opacity =
                    DatePicker_t11field03_02.Opacity =
                    Entry_t11field03_02.Opacity =
                    ResetLabel_t11field03_02.Opacity =
                   Picker02.Opacity =
                   t11Picker05.Opacity = AppManager.QuestionDisabledOpacity;
                }

                if (Erfassungsbogen.t11field01a == "0" && Erfassungsbogen.t11field02_01 == "1" && Erfassungsbogen.t11field02_04 == "2")
                {
                    DatePicker_t11field02_06.IsEnabled =
                    DatePicker_t11field02_06.IsEnabled =
                    Entry_t11field02_06.IsEnabled =
                    ResetLabel_t11field02_06.IsEnabled = false;

                    DatePicker_t11field02_06.Opacity =
                   DatePicker_t11field02_06.Opacity =
                   Entry_t11field02_06.Opacity =
                   ResetLabel_t11field02_06.Opacity = AppManager.QuestionDisabledOpacity;
                }

                if (Erfassungsbogen.t11field03_01 == "0")
                {
                    Label_t11field03_02.IsEnabled =
                    DatePicker_t11field03_02.IsEnabled =
                    Entry_t11field03_02.IsEnabled =
                    ResetLabel_t11field03_02.IsEnabled = false;

                    Label_t11field03_02.Opacity =
                   DatePicker_t11field03_02.Opacity =
                   Entry_t11field03_02.Opacity =
                   ResetLabel_t11field03_02.Opacity = AppManager.QuestionDisabledOpacity;
                }

                // date 02_05
                if (Erfassungsbogen.t11field02_05 != "")
                {
                    DatePicker_t11field02_05.Date = DateTime.ParseExact(Erfassungsbogen.t11field02_05.Replace('.', '/'), "dd/MM/yyyy", null).Date;
                    Entry_t11field02_05.Text = Erfassungsbogen.t11field02_05;
                }

                // date 02_06
                if (Erfassungsbogen.t11field02_06 != "")
                {
                    DatePicker_t11field02_06.Date = DateTime.ParseExact(Erfassungsbogen.t11field02_06.Replace('.', '/'), "dd/MM/yyyy", null).Date;
                    Entry_t11field02_06.Text = Erfassungsbogen.t11field02_06;
                }

                // picker 03_ 01
                if (Erfassungsbogen.t11field03_01 == "1")
                {
                    t11Picker04.SelectedIndex = 0;
                }
                else if (Erfassungsbogen.t11field03_01 == "0")
                {
                    t11Picker04.SelectedIndex = 1;
                }
                else
                {
                    t11Picker04.SelectedIndex = -1;
                }

                // date 03_02
                if (Erfassungsbogen.t11field03_02 != "")
                {
                    DatePicker_t11field03_02.Date = DateTime.ParseExact(Erfassungsbogen.t11field03_02.Replace('.', '/'), "dd/MM/yyyy", null).Date;
                    Entry_t11field03_02.Text = Erfassungsbogen.t11field03_02;
                }

                // picker tbl11_field04

                if (Erfassungsbogen.t11field04 == "1")
                {
                    t11Picker05.SelectedIndex = 0;                         // whether ja==0 by default or not ??
                }
                else if (Erfassungsbogen.t11field04 == "0")
                {
                    t11Picker05.SelectedIndex = 1;
                }
                else
                {
                    t11Picker05.SelectedIndex = -1;
                }
                //ActivityIndicator = Idle
                IsLoading = false;

            }
            catch (Exception)
            {
                await DisplayAlert(AppResources.AppError, AppResources.AppErrorMsg, "OK");
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
                    await Navigation.PushAsync(new Schmerzen_1());
                }
                else
                {
                    var BackQuestion = await DisplayAlert(AppResources.Information, AppResources.InformationSaveQuery, AppResources.Yes, AppResources.No);
                    if (BackQuestion == true)
                    {
                        Label_t11field02_05.TextColor = Label_t11field02_06.TextColor = Picker01.TextColor = Label_t11field03_02.TextColor = Picker02.TextColor = AppManager.QuestionColor;

                        if (Erfassungsbogen.t11field01 == "0")
                        {
                            WebRequest req = WebRequest.Create(DBManagement.DBConnection + "tbl_form_ebqe_t11_02_update.php");

                            req.Method = "POST"; //POST
                            req.Timeout = 15000;
                            req.ContentType = "application/x-www-form-urlencoded";

                            string postData = "mstr=" + App.user.selected_mstr_ebqe + "&bewonerid=" + App.user.selected_id_bewohner + "&t11field02_05=" + Erfassungsbogen.t11field02_05 + "&t11field02_06=" + Erfassungsbogen.t11field02_06 + "&t11field03_01=" + Erfassungsbogen.t11field03_01 + "&t11field03_02=" + Erfassungsbogen.t11field03_02 + "&t11field04=" + Erfassungsbogen.t11field04;

                            byte[] byteArray = Encoding.UTF8.GetBytes(postData);

                            req.ContentLength = byteArray.Length;

                            Stream ds = await req.GetRequestStreamAsync();
                            await ds.WriteAsync(byteArray, 0, byteArray.Length);
                            ds.Close();

                            await Navigation.PushAsync(new Schmerzen_1());
                        }
                        else
                        {
                            if (Erfassungsbogen.t11field01a == "1")
                            {
                                WebRequest req = WebRequest.Create(DBManagement.DBConnection + "tbl_form_ebqe_t11_02_update.php");

                                req.Method = "POST"; //POST
                                req.Timeout = 15000;
                                req.ContentType = "application/x-www-form-urlencoded";

                                string postData = "mstr=" + App.user.selected_mstr_ebqe + "&bewonerid=" + App.user.selected_id_bewohner + "&t11field02_05=" + Erfassungsbogen.t11field02_05 + "&t11field02_06=" + Erfassungsbogen.t11field02_06 + "&t11field03_01=" + Erfassungsbogen.t11field03_01 + "&t11field03_02=" + Erfassungsbogen.t11field03_02 + "&t11field04=" + Erfassungsbogen.t11field04;

                                byte[] byteArray = Encoding.UTF8.GetBytes(postData);

                                req.ContentLength = byteArray.Length;

                                Stream ds = await req.GetRequestStreamAsync();
                                await ds.WriteAsync(byteArray, 0, byteArray.Length);
                                ds.Close();

                                await Navigation.PushAsync(new Schmerzen_1());
                            }
                            else
                            {
                                if (Erfassungsbogen.t11field02_01 == "0")
                                {
                                    WebRequest req = WebRequest.Create(DBManagement.DBConnection + "tbl_form_ebqe_t11_02_update.php");

                                    req.Method = "POST"; //POST
                                    req.Timeout = 15000;
                                    req.ContentType = "application/x-www-form-urlencoded";

                                    string postData = "mstr=" + App.user.selected_mstr_ebqe + "&bewonerid=" + App.user.selected_id_bewohner + "&t11field02_05=" + Erfassungsbogen.t11field02_05 + "&t11field02_06=" + Erfassungsbogen.t11field02_06 + "&t11field03_01=" + Erfassungsbogen.t11field03_01 + "&t11field03_02=" + Erfassungsbogen.t11field03_02 + "&t11field04=" + Erfassungsbogen.t11field04;

                                    byte[] byteArray = Encoding.UTF8.GetBytes(postData);

                                    req.ContentLength = byteArray.Length;

                                    Stream ds = await req.GetRequestStreamAsync();
                                    await ds.WriteAsync(byteArray, 0, byteArray.Length);
                                    ds.Close();

                                    await Navigation.PushAsync(new Schmerzen_1());
                                }
                                else
                                {
                                    if (Erfassungsbogen.t11field02_05 != "" && Erfassungsbogen.t11field02_05 != null)
                                    {
                                        if (Erfassungsbogen.t11field02_04 != "2")
                                        {
                                            //Mit vorletzter Schmerzeinschätzung
                                            if (Erfassungsbogen.t11field02_06 != "" && Erfassungsbogen.t11field02_06 != null)
                                            {
                                                if (Erfassungsbogen.t11field03_01 != "" && Erfassungsbogen.t11field03_01 != null)
                                                {
                                                    if (Erfassungsbogen.t11field03_01 != "0")
                                                    {
                                                        if (Erfassungsbogen.t11field03_02 != "" && Erfassungsbogen.t11field03_02 != null)
                                                        {

                                                        }
                                                        else
                                                        {
                                                            Label_t11field03_02.TextColor = Color.Red;

                                                            await DisplayAlert(AppResources.Warning, AppResources.FieldsUnfilled, "OK");
                                                            BackButton.Source = "ic_arrow_back_ios.png";
                                                        }
                                                    }
                                                    else
                                                    {
                                                        if (Erfassungsbogen.t11field04 != "" && Erfassungsbogen.t11field04 != null)
                                                        {
                                                            WebRequest req = WebRequest.Create(DBManagement.DBConnection + "tbl_form_ebqe_t11_02_update.php");

                                                            req.Method = "POST"; //POST
                                                            req.Timeout = 15000;
                                                            req.ContentType = "application/x-www-form-urlencoded";

                                                            string postData = "mstr=" + App.user.selected_mstr_ebqe + "&bewonerid=" + App.user.selected_id_bewohner + "&t11field02_05=" + Erfassungsbogen.t11field02_05 + "&t11field02_06=" + Erfassungsbogen.t11field02_06 + "&t11field03_01=" + Erfassungsbogen.t11field03_01 + "&t11field03_02=" + Erfassungsbogen.t11field03_02 + "&t11field04=" + Erfassungsbogen.t11field04;

                                                            byte[] byteArray = Encoding.UTF8.GetBytes(postData);

                                                            req.ContentLength = byteArray.Length;

                                                            Stream ds = await req.GetRequestStreamAsync();
                                                            await ds.WriteAsync(byteArray, 0, byteArray.Length);
                                                            ds.Close();

                                                            await Navigation.PushAsync(new Schmerzen_1());
                                                        }
                                                        else
                                                        {
                                                            Picker02.TextColor = Color.Red;

                                                            await DisplayAlert(AppResources.Warning, AppResources.FieldsUnfilled, "OK");
                                                            BackButton.Source = "ic_arrow_back_ios.png";
                                                        }
                                                    }
                                                }
                                                else
                                                {
                                                    Picker01.TextColor = Color.Red;

                                                    await DisplayAlert(AppResources.Warning, AppResources.FieldsUnfilled, "OK");
                                                    BackButton.Source = "ic_arrow_back_ios.png";
                                                }
                                            }
                                            else
                                            {
                                                Label_t11field02_06.TextColor = Color.Red;

                                                await DisplayAlert(AppResources.Warning, AppResources.FieldsUnfilled, "OK");
                                                BackButton.Source = "ic_arrow_back_ios.png";
                                            }
                                        }
                                        else
                                        {
                                            //Keine vorletzte Schmerzeinschätzung
                                            if (Erfassungsbogen.t11field03_01 != "" && Erfassungsbogen.t11field03_01 != null)
                                            {
                                                if (Erfassungsbogen.t11field03_01 != "0")
                                                {
                                                    if (Erfassungsbogen.t11field03_02 != "" && Erfassungsbogen.t11field03_02 != null)
                                                    {

                                                    }
                                                    else
                                                    {
                                                        Label_t11field03_02.TextColor = Color.Red;

                                                        await DisplayAlert(AppResources.Warning, AppResources.FieldsUnfilled, "OK");
                                                        BackButton.Source = "ic_arrow_back_ios.png";
                                                    }
                                                }
                                                else
                                                {
                                                    if (Erfassungsbogen.t11field04 != "" && Erfassungsbogen.t11field04 != null)
                                                    {
                                                        WebRequest req = WebRequest.Create(DBManagement.DBConnection + "tbl_form_ebqe_t11_02_update.php");

                                                        req.Method = "POST"; //POST
                                                        req.Timeout = 15000;
                                                        req.ContentType = "application/x-www-form-urlencoded";

                                                        string postData = "mstr=" + App.user.selected_mstr_ebqe + "&bewonerid=" + App.user.selected_id_bewohner + "&t11field02_05=" + Erfassungsbogen.t11field02_05 + "&t11field02_06=" + Erfassungsbogen.t11field02_06 + "&t11field03_01=" + Erfassungsbogen.t11field03_01 + "&t11field03_02=" + Erfassungsbogen.t11field03_02 + "&t11field04=" + Erfassungsbogen.t11field04;

                                                        byte[] byteArray = Encoding.UTF8.GetBytes(postData);

                                                        req.ContentLength = byteArray.Length;

                                                        Stream ds = await req.GetRequestStreamAsync();
                                                        await ds.WriteAsync(byteArray, 0, byteArray.Length);
                                                        ds.Close();

                                                        await Navigation.PushAsync(new Schmerzen_1());
                                                    }
                                                    else
                                                    {
                                                        Picker02.TextColor = Color.Red;

                                                        await DisplayAlert(AppResources.Warning, AppResources.FieldsUnfilled, "OK");
                                                        BackButton.Source = "ic_arrow_back_ios.png";
                                                    }
                                                }
                                            }
                                            else
                                            {
                                                Picker01.TextColor = Color.Red;

                                                await DisplayAlert(AppResources.Warning, AppResources.FieldsUnfilled, "OK");
                                                BackButton.Source = "ic_arrow_back_ios.png";
                                            }
                                        }

                                    }
                                    else
                                    {
                                        Label_t11field02_05.TextColor = Color.Red;

                                        await DisplayAlert(AppResources.Warning, AppResources.FieldsUnfilled, "OK");
                                        BackButton.Source = "ic_arrow_back_ios.png";
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        Erfassungsbogen.t11field02_05 = Erfassungsbogen.t11field02_06 = Erfassungsbogen.t11field03_01 = Erfassungsbogen.t11field03_02 = Erfassungsbogen.t11field04 = "";

                        WebRequest req = WebRequest.Create(DBManagement.DBConnection + "tbl_form_ebqe_t11_02_update.php");

                        req.Method = "POST"; //POST
                        req.Timeout = 15000;
                        req.ContentType = "application/x-www-form-urlencoded";

                        string postData = "mstr=" + App.user.selected_mstr_ebqe + "&bewonerid=" + App.user.selected_id_bewohner + "&t11field02_05=" + Erfassungsbogen.t11field02_05 + "&t11field02_06=" + Erfassungsbogen.t11field02_06 + "&t11field03_01=" + Erfassungsbogen.t11field03_01 + "&t11field03_02=" + Erfassungsbogen.t11field03_02 + "&t11field04=" + Erfassungsbogen.t11field04;

                        byte[] byteArray = Encoding.UTF8.GetBytes(postData);

                        req.ContentLength = byteArray.Length;

                        Stream ds = await req.GetRequestStreamAsync();
                        await ds.WriteAsync(byteArray, 0, byteArray.Length);
                        ds.Close();

                        await Navigation.PushAsync(new Schmerzen_1());
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

        private void T11Picker04_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            // T11 03_01
            if (t11Picker04.SelectedIndex == 0)
            {
                Erfassungsbogen.t11field03_01 = "1";

                Label_t11field03_02.IsEnabled =
                DatePicker_t11field03_02.IsEnabled =
                Entry_t11field03_02.IsEnabled =
                ResetLabel_t11field03_02.IsEnabled = true;

                Label_t11field03_02.Opacity =
                DatePicker_t11field03_02.Opacity =
                Entry_t11field03_02.Opacity =
                ResetLabel_t11field03_02.Opacity = 1;
            }
            else if (t11Picker04.SelectedIndex == 1)
            {
                Erfassungsbogen.t11field03_01 = "0";

                Label_t11field03_02.IsEnabled =
               DatePicker_t11field03_02.IsEnabled =
               Entry_t11field03_02.IsEnabled =
               ResetLabel_t11field03_02.IsEnabled = false;

                Label_t11field03_02.Opacity =
                DatePicker_t11field03_02.Opacity =
                Entry_t11field03_02.Opacity =
                ResetLabel_t11field03_02.Opacity = 0.25;
            }
        }

        private void T11Picker05_SelectedIndexChanged(object sender, EventArgs e)
        {
            //t11 04
            if (t11Picker05.SelectedIndex == 0)
            {
                Erfassungsbogen.t11field04 = "1";
            }
            else if (t11Picker05.SelectedIndex == 1)
            {
                Erfassungsbogen.t11field04 = "0";
            }
        }

        private async void SaveDataAndGoToMenuButton_TappedAsync(object sender, EventArgs e)
        {
            SaveAllButton.Source = "ic_done_all_tapped.png";

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
                    Label_t11field02_05.TextColor = Label_t11field02_06.TextColor = Picker01.TextColor = Label_t11field03_02.TextColor = Picker02.TextColor = AppManager.QuestionColor;

                    if (Erfassungsbogen.t11field01 == "0")
                    {
                        WebRequest req = WebRequest.Create(DBManagement.DBConnection + "tbl_form_ebqe_t11_02_update.php");

                        req.Method = "POST"; //POST
                        req.Timeout = 15000;
                        req.ContentType = "application/x-www-form-urlencoded";

                        string postData = "mstr=" + App.user.selected_mstr_ebqe + "&bewonerid=" + App.user.selected_id_bewohner + "&t11field02_05=" + Erfassungsbogen.t11field02_05 + "&t11field02_06=" + Erfassungsbogen.t11field02_06 + "&t11field03_01=" + Erfassungsbogen.t11field03_01 + "&t11field03_02=" + Erfassungsbogen.t11field03_02 + "&t11field04=" + Erfassungsbogen.t11field04;

                        byte[] byteArray = Encoding.UTF8.GetBytes(postData);

                        req.ContentLength = byteArray.Length;

                        Stream ds = await req.GetRequestStreamAsync();
                        await ds.WriteAsync(byteArray, 0, byteArray.Length);
                        ds.Close();

                        await Navigation.PushAsync(new SearchPage());
                    }
                    else
                    {
                        if (Erfassungsbogen.t11field01a == "1")
                        {
                            WebRequest req = WebRequest.Create(DBManagement.DBConnection + "tbl_form_ebqe_t11_02_update.php");

                            req.Method = "POST"; //POST
                            req.Timeout = 15000;
                            req.ContentType = "application/x-www-form-urlencoded";

                            string postData = "mstr=" + App.user.selected_mstr_ebqe + "&bewonerid=" + App.user.selected_id_bewohner + "&t11field02_05=" + Erfassungsbogen.t11field02_05 + "&t11field02_06=" + Erfassungsbogen.t11field02_06 + "&t11field03_01=" + Erfassungsbogen.t11field03_01 + "&t11field03_02=" + Erfassungsbogen.t11field03_02 + "&t11field04=" + Erfassungsbogen.t11field04;

                            byte[] byteArray = Encoding.UTF8.GetBytes(postData);

                            req.ContentLength = byteArray.Length;

                            Stream ds = await req.GetRequestStreamAsync();
                            await ds.WriteAsync(byteArray, 0, byteArray.Length);
                            ds.Close();

                            await Navigation.PushAsync(new SearchPage());
                        }
                        else
                        {
                            if (Erfassungsbogen.t11field02_01 == "0")
                            {
                                WebRequest req = WebRequest.Create(DBManagement.DBConnection + "tbl_form_ebqe_t11_02_update.php");

                                req.Method = "POST"; //POST
                                req.Timeout = 15000;
                                req.ContentType = "application/x-www-form-urlencoded";

                                string postData = "mstr=" + App.user.selected_mstr_ebqe + "&bewonerid=" + App.user.selected_id_bewohner + "&t11field02_05=" + Erfassungsbogen.t11field02_05 + "&t11field02_06=" + Erfassungsbogen.t11field02_06 + "&t11field03_01=" + Erfassungsbogen.t11field03_01 + "&t11field03_02=" + Erfassungsbogen.t11field03_02 + "&t11field04=" + Erfassungsbogen.t11field04;

                                byte[] byteArray = Encoding.UTF8.GetBytes(postData);

                                req.ContentLength = byteArray.Length;

                                Stream ds = await req.GetRequestStreamAsync();
                                await ds.WriteAsync(byteArray, 0, byteArray.Length);
                                ds.Close();

                                await Navigation.PushAsync(new SearchPage());
                            }
                            else
                            {
                                if (Erfassungsbogen.t11field02_05 != "" && Erfassungsbogen.t11field02_05 != null)
                                {
                                    if (Erfassungsbogen.t11field02_04 != "2")
                                    {
                                        //Mit vorletzter Schmerzeinschätzung
                                        if (Erfassungsbogen.t11field02_06 != "" && Erfassungsbogen.t11field02_06 != null)
                                        {
                                            if (Erfassungsbogen.t11field03_01 != "" && Erfassungsbogen.t11field03_01 != null)
                                            {
                                                if (Erfassungsbogen.t11field03_01 != "0")
                                                {
                                                    if (Erfassungsbogen.t11field03_02 != "" && Erfassungsbogen.t11field03_02 != null)
                                                    {

                                                    }
                                                    else
                                                    {
                                                        Label_t11field03_02.TextColor = Color.Red;

                                                        await DisplayAlert(AppResources.Warning, AppResources.FieldsUnfilled, "OK");
                                                        SaveAllButton.Source = "ic_done_all.png";
                                                    }
                                                }
                                                else
                                                {
                                                    if (Erfassungsbogen.t11field04 != "" && Erfassungsbogen.t11field04 != null)
                                                    {
                                                        WebRequest req = WebRequest.Create(DBManagement.DBConnection + "tbl_form_ebqe_t11_02_update.php");

                                                        req.Method = "POST"; //POST
                                                        req.Timeout = 15000;
                                                        req.ContentType = "application/x-www-form-urlencoded";

                                                        string postData = "mstr=" + App.user.selected_mstr_ebqe + "&bewonerid=" + App.user.selected_id_bewohner + "&t11field02_05=" + Erfassungsbogen.t11field02_05 + "&t11field02_06=" + Erfassungsbogen.t11field02_06 + "&t11field03_01=" + Erfassungsbogen.t11field03_01 + "&t11field03_02=" + Erfassungsbogen.t11field03_02 + "&t11field04=" + Erfassungsbogen.t11field04;

                                                        byte[] byteArray = Encoding.UTF8.GetBytes(postData);

                                                        req.ContentLength = byteArray.Length;

                                                        Stream ds = await req.GetRequestStreamAsync();
                                                        await ds.WriteAsync(byteArray, 0, byteArray.Length);
                                                        ds.Close();

                                                        await Navigation.PushAsync(new SearchPage());
                                                    }
                                                    else
                                                    {
                                                        Picker02.TextColor = Color.Red;

                                                        await DisplayAlert(AppResources.Warning, AppResources.FieldsUnfilled, "OK");
                                                        SaveAllButton.Source = "ic_done_all.png";
                                                    }
                                                }
                                            }
                                            else
                                            {
                                                Picker01.TextColor = Color.Red;

                                                await DisplayAlert(AppResources.Warning, AppResources.FieldsUnfilled, "OK");
                                                SaveAllButton.Source = "ic_done_all.png";
                                            }
                                        }
                                        else
                                        {
                                            Label_t11field02_06.TextColor = Color.Red;

                                            await DisplayAlert(AppResources.Warning, AppResources.FieldsUnfilled, "OK");
                                            SaveAllButton.Source = "ic_done_all.png";
                                        }
                                    }
                                    else
                                    {
                                        //Keine vorletzte Schmerzeinschätzung
                                        if (Erfassungsbogen.t11field03_01 != "" && Erfassungsbogen.t11field03_01 != null)
                                        {
                                            if (Erfassungsbogen.t11field03_01 != "0")
                                            {
                                                if (Erfassungsbogen.t11field03_02 != "" && Erfassungsbogen.t11field03_02 != null)
                                                {

                                                }
                                                else
                                                {
                                                    Label_t11field03_02.TextColor = Color.Red;

                                                    await DisplayAlert(AppResources.Warning, AppResources.FieldsUnfilled, "OK");
                                                    SaveAllButton.Source = "ic_done_all.png";
                                                }
                                            }
                                            else
                                            {
                                                if (Erfassungsbogen.t11field04 != "" && Erfassungsbogen.t11field04 != null)
                                                {
                                                    WebRequest req = WebRequest.Create(DBManagement.DBConnection + "tbl_form_ebqe_t11_02_update.php");

                                                    req.Method = "POST"; //POST
                                                    req.Timeout = 15000;
                                                    req.ContentType = "application/x-www-form-urlencoded";

                                                    string postData = "mstr=" + App.user.selected_mstr_ebqe + "&bewonerid=" + App.user.selected_id_bewohner + "&t11field02_05=" + Erfassungsbogen.t11field02_05 + "&t11field02_06=" + Erfassungsbogen.t11field02_06 + "&t11field03_01=" + Erfassungsbogen.t11field03_01 + "&t11field03_02=" + Erfassungsbogen.t11field03_02 + "&t11field04=" + Erfassungsbogen.t11field04;

                                                    byte[] byteArray = Encoding.UTF8.GetBytes(postData);

                                                    req.ContentLength = byteArray.Length;

                                                    Stream ds = await req.GetRequestStreamAsync();
                                                    await ds.WriteAsync(byteArray, 0, byteArray.Length);
                                                    ds.Close();

                                                    await Navigation.PushAsync(new SearchPage());
                                                }
                                                else
                                                {
                                                    Picker02.TextColor = Color.Red;

                                                    await DisplayAlert(AppResources.Warning, AppResources.FieldsUnfilled, "OK");
                                                    SaveAllButton.Source = "ic_done_all.png";
                                                }
                                            }
                                        }
                                        else
                                        {
                                            Picker01.TextColor = Color.Red;

                                            await DisplayAlert(AppResources.Warning, AppResources.FieldsUnfilled, "OK");
                                            SaveAllButton.Source = "ic_done_all.png";
                                        }
                                    }

                                }
                                else
                                {
                                    Label_t11field02_05.TextColor = Color.Red;

                                    await DisplayAlert(AppResources.Warning, AppResources.FieldsUnfilled, "OK");
                                    SaveAllButton.Source = "ic_done_all.png";
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
                SaveAllButton.Source = "ic_done_all.png";
            }
        }

        private async void ResetAllDataFromCategoryButton_TappedAsync(object sender, EventArgs e)
        {
            try
            {
                //ActivityIndicator = Loading...
                IsLoading = true;

                if (App.user.selected_mstr_ebqe != DBManagement.CurrentEvaluationID)
                {
                    await DisplayAlert(AppResources.Warning, AppResources.ResetCategoryImpossibleWarning, "OK");
                }
                else
                {
                    var ResetButton = await DisplayAlert(AppResources.Warning, AppResources.ResetCategoryWarning, AppResources.Yes, AppResources.No);
                    if (ResetButton == true)
                    {
                        WebRequest req = WebRequest.Create(DBManagement.DBConnection + "tbl_form_ebqe_t11_01-02_update_clear.php");

                        req.Method = "POST"; //POST
                        req.Timeout = 15000;
                        req.ContentType = "application/x-www-form-urlencoded";

                        string postData = "mstr=" + App.user.selected_mstr_ebqe + "&bewonerid=" + App.user.selected_id_bewohner;

                        byte[] byteArray = Encoding.UTF8.GetBytes(postData);

                        req.ContentLength = byteArray.Length;

                        Stream ds = await req.GetRequestStreamAsync();
                        await ds.WriteAsync(byteArray, 0, byteArray.Length);
                        ds.Close();

                        Erfassungsbogen.loadedFromDB = false;

                        await Navigation.PushAsync(new SearchPage());
                    }
                    else
                    {
                        await Navigation.PushAsync(new SearchPage());
                    }
                }
                //ActivityIndicator = Idle
                IsLoading = false;

            }
            catch (Exception)
            {
                await DisplayAlert(AppResources.AppError, AppResources.AppErrorMsg, "OK");
            }
        }

        #region t11field02_05

        private void ResetLabel_t11field02_05_Tapped(object sender, EventArgs e)
        {
            Erfassungsbogen.t11field02_05 = "";
            Entry_t11field02_05.Text = "";
        }

        private void Entry_t11field02_05_Focused(object sender, FocusEventArgs e)
        {
            Entry_t11field02_05.Unfocus();
            DatePicker_t11field02_05.Focus();
        }

        private void DatePicker_t11field02_05_Unfocused(object sender, DateChangedEventArgs e)
        {
            Erfassungsbogen.t11field02_05 = DatePicker_t11field02_05.Date.ToString("dd.MM.yyyy");
            Entry_t11field02_05.Text = DatePicker_t11field02_05.Date.ToString("dd.MM.yyyy");
        }

        private void DatePicker_t11field02_05_DateSelected(object sender, DateChangedEventArgs e)
        {
            Erfassungsbogen.t11field02_05 = DatePicker_t11field02_05.Date.ToString("dd.MM.yyyy");
            Entry_t11field02_05.Text = DatePicker_t11field02_05.Date.ToString("dd.MM.yyyy");
        }

        #endregion

        #region t11field02_06

        private void ResetLabel_t11field02_06_Tapped(object sender, EventArgs e)
        {
            Erfassungsbogen.t11field02_06 = "";
            Entry_t11field02_06.Text = "";
        }

        private void Entry_t11field02_06_Focused(object sender, FocusEventArgs e)
        {
            Entry_t11field02_06.Unfocus();
            DatePicker_t11field02_06.Focus();
        }

        private void DatePicker_t11field02_06_Unfocused(object sender, DateChangedEventArgs e)
        {
            Erfassungsbogen.t11field02_06 = DatePicker_t11field02_06.Date.ToString("dd.MM.yyyy");
            Entry_t11field02_06.Text = DatePicker_t11field02_06.Date.ToString("dd.MM.yyyy");
        }

        private void DatePicker_t11field02_06_DateSelected(object sender, DateChangedEventArgs e)
        {
            Erfassungsbogen.t11field02_06 = DatePicker_t11field02_06.Date.ToString("dd.MM.yyyy");
            Entry_t11field02_06.Text = DatePicker_t11field02_06.Date.ToString("dd.MM.yyyy");
        }

        #endregion

        #region t11field03_02

        private void ResetLabel_t11field03_02_Tapped(object sender, EventArgs e)
        {
            Erfassungsbogen.t11field03_02 = "";
            Entry_t11field03_02.Text = "";
        }

        private void Entry_t11field03_02_Focused(object sender, FocusEventArgs e)
        {
            Entry_t11field03_02.Unfocus();
            DatePicker_t11field03_02.Focus();
        }

        private void DatePicker_t11field03_02_Unfocused(object sender, DateChangedEventArgs e)
        {
            Erfassungsbogen.t11field03_02 = DatePicker_t11field03_02.Date.ToString("dd.MM.yyyy");
            Entry_t11field03_02.Text = DatePicker_t11field03_02.Date.ToString("dd.MM.yyyy");
        }

        private void DatePicker_t11field03_02_DateSelected(object sender, DateChangedEventArgs e)
        {
            Erfassungsbogen.t11field03_02 = DatePicker_t11field03_02.Date.ToString("dd.MM.yyyy");
            Entry_t11field03_02.Text = DatePicker_t11field03_02.Date.ToString("dd.MM.yyyy");
        }

        #endregion

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
