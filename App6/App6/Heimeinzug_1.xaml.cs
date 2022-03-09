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
    public partial class Heimeinzug_1 : ContentPage, INotifyPropertyChanged
    {
        public bool InitialDataIsEmpty;

        public Heimeinzug_1()
        {
            InitializeComponent();
            BindingContext = this;

            BogenLabel.Text = AppResources.SurveyHeadline + " " + DBManagement.getYearCode(App.user.selected_mstr_ebqe) + " " + AppResources.SurveyHeadlineFor + " " + Erfassungsbogen.Bewohnerbezeichnung;

            t12Picker00.Items.Add("ja");
            t12Picker00.Items.Add("nein (bei nein weiter mit Frage 13)");

            t12Picker01.Items.Add("ja");
            t12Picker01.Items.Add("nein");

            t12Picker04.Items.Add("ja");
            t12Picker04.Items.Add("nicht möglich aufgrund fehlender Vertrauenspersonen des Bewohners (weiter mit Frage 13)");
            t12Picker04.Items.Add("nein, aus anderen Gründen (weiter mit Frage 13)");
        }

        //Before page gets loaded this opertion is performed
        protected override async void OnAppearing()
        {
            base.OnAppearing();

            try
            {
                //ActivityIndicator = Loading...
                IsLoading = true;

                //WebRequest req = WebRequest.Create(DBManagement.DBConnection + "tbl_form_ebqe_t12_01_read.php");

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

                //Erfassungsbogen.t12field00 = split[0];

                //Erfassungsbogen.t12field01_01 = split[1];

                //Erfassungsbogen.t12field01_02 = split[2];
                //Erfassungsbogen.t12field01_03 = split[3];

                //Erfassungsbogen.t12field02_01 = split[4];

                //Erfassungsbogen.t12field02_02 = split[5];

                if (Erfassungsbogen.t12field00 == "0")
                {
                    t12field01_01.IsEnabled =
                 t12Picker01.IsEnabled =
                 Label_t12field01_02.IsEnabled =
                 DatePicker_t12field01_02.IsEnabled =
                 ResetLabel_t12field01_02.IsEnabled =
                 Label_t12field01_03.IsEnabled =
                 DatePicker_t12field01_03.IsEnabled =
                 ResetLabel_t12field01_03.IsEnabled =
                 t12field04.IsEnabled =
                 t12Picker04.IsEnabled =
                 t12field04_4.IsEnabled =
                 Label_t12field02_02.IsEnabled =
                 DatePicker_t12field02_02.IsEnabled =
                 Entry_t12field02_02.IsEnabled =
                 ResetLabel_t12field02_02.IsEnabled =
                 Entry_t12field01_03.IsEnabled =
                 Entry_t12field01_02.IsEnabled = false;

                    t12field01_01.Opacity =
                       t12Picker01.Opacity =
                       Label_t12field01_02.Opacity =
                       DatePicker_t12field01_02.Opacity =
                       ResetLabel_t12field01_02.Opacity =
                       Label_t12field01_03.Opacity =
                       DatePicker_t12field01_03.Opacity =
                       ResetLabel_t12field01_03.Opacity =
                       t12field04.Opacity =
                       t12Picker04.Opacity =
                       Label_t12field02_02.Opacity =
                       DatePicker_t12field02_02.Opacity =
                       Entry_t12field02_02.Opacity =
                       ResetLabel_t12field02_02.Opacity =
                       Entry_t12field01_03.Opacity =
                       Entry_t12field01_02.Opacity =

                    t12field04_4.Opacity = AppManager.AnswerDisabledOpacity;
                }

                // picker 1

                if (Erfassungsbogen.t12field00 == "1")
                {
                    t12Picker00.SelectedIndex = 0;                         // whether ja==0 by default or not ??
                }
                else if (Erfassungsbogen.t12field00 == "0")
                {
                    t12Picker00.SelectedIndex = 1;

                }
                else
                {
                    t12Picker00.SelectedIndex = -1;
                }

                // picker 2

                if (Erfassungsbogen.t12field01_01 == "1")
                {
                    t12Picker01.SelectedIndex = 0;                         // whether ja==0 by default or not ??
                }
                else if (Erfassungsbogen.t12field01_01 == "0")
                {
                    t12Picker01.SelectedIndex = 1;
                }
                else
                {
                    t12Picker01.SelectedIndex = -1;
                }

                // date 01_02
                if (Erfassungsbogen.t12field01_02 != "")
                {
                    DatePicker_t12field01_02.Date = DateTime.ParseExact(Erfassungsbogen.t12field01_02.Replace('.', '/'), "dd/MM/yyyy", null).Date;
                    Entry_t12field01_02.Text = Erfassungsbogen.t12field01_02;
                }

                // date 01_03
                if (Erfassungsbogen.t12field01_03 != "")
                {
                    DatePicker_t12field01_03.Date = DateTime.ParseExact(Erfassungsbogen.t12field01_03.Replace('.', '/'), "dd/MM/yyyy", null).Date;
                    Entry_t12field01_03.Text = Erfassungsbogen.t12field01_03;
                }

                // picker 02_01

                if (Erfassungsbogen.t12field02_01 == "1")
                {
                    t12Picker04.SelectedIndex = 0;      // rb1 is the image file with checked box image
                }
                else if (Erfassungsbogen.t12field02_01 == "0.01")
                {
                    t12Picker04.SelectedIndex = 1;
                }
                else if (Erfassungsbogen.t12field02_01 == "0.02")
                {
                    t12Picker04.SelectedIndex = 2;
                }
                else
                {
                    t12Picker04.SelectedIndex = -1;
                }

                // date 02_02
                if (Erfassungsbogen.t12field02_02 != "")
                {
                    DatePicker_t12field02_02.Date = DateTime.ParseExact(Erfassungsbogen.t12field02_02.Replace('.', '/'), "dd/MM/yyyy", null).Date;
                    Entry_t12field02_02.Text = Erfassungsbogen.t12field02_02;
                }
                //ActivityIndicator = Idle
                IsLoading = false;

            }
            catch (Exception)
            {
                await DisplayAlert(AppResources.AppError, AppResources.AppErrorMsg, "OK");
            }
        }

        private void T12Picker00_SelectedIndexChanged(object sender, EventArgs e)
        {
            // T12 00
            if (t12Picker00.SelectedIndex == 0)
            {
                Erfassungsbogen.t12field00 = "1";

                t12field01_01.IsEnabled =
                    t12Picker01.IsEnabled =
                    Label_t12field01_02.IsEnabled =
                    DatePicker_t12field01_02.IsEnabled =
                    ResetLabel_t12field01_02.IsEnabled =
                    Label_t12field01_03.IsEnabled =
                    DatePicker_t12field01_03.IsEnabled =
                    ResetLabel_t12field01_03.IsEnabled =
                    t12field04.IsEnabled =
                    t12Picker04.IsEnabled =
                    t12field04_4.IsEnabled =
                    Label_t12field02_02.IsEnabled =
                    DatePicker_t12field02_02.IsEnabled =
                    Entry_t12field02_02.IsEnabled =
                    ResetLabel_t12field02_02.IsEnabled =
                    Entry_t12field01_03.IsEnabled =
                    Entry_t12field01_02.IsEnabled = true;

                t12field01_01.Opacity =
                   t12Picker01.Opacity =
                   Label_t12field01_02.Opacity =
                   DatePicker_t12field01_02.Opacity =
                   ResetLabel_t12field01_02.Opacity =
                   Label_t12field01_03.Opacity =
                   DatePicker_t12field01_03.Opacity =
                   ResetLabel_t12field01_03.Opacity =
                   t12field04.Opacity =
                   t12Picker04.Opacity =
                   t12field04_4.Opacity =
                   Label_t12field02_02.Opacity =
                   DatePicker_t12field02_02.Opacity =
                   Entry_t12field02_02.Opacity =
                   ResetLabel_t12field02_02.Opacity =
                   Entry_t12field01_03.Opacity =
                   Entry_t12field01_02.Opacity = 1;
            }
            else if (t12Picker00.SelectedIndex == 1)
            {
                Erfassungsbogen.t12field00 = "0";

                t12field01_01.IsEnabled =
                   t12Picker01.IsEnabled =
                   Label_t12field01_02.IsEnabled =
                   DatePicker_t12field01_02.IsEnabled =
                   ResetLabel_t12field01_02.IsEnabled =
                   Label_t12field01_03.IsEnabled =
                   DatePicker_t12field01_03.IsEnabled =
                   ResetLabel_t12field01_03.IsEnabled =
                   t12field04.IsEnabled =
                   t12Picker04.IsEnabled =
                   t12field04_4.IsEnabled =
                   Label_t12field02_02.IsEnabled =
                   DatePicker_t12field02_02.IsEnabled =
                   Entry_t12field02_02.IsEnabled =
                   ResetLabel_t12field02_02.IsEnabled =
                   Entry_t12field01_03.IsEnabled =
                   Entry_t12field01_02.IsEnabled = false;

                t12field01_01.Opacity =
                   t12Picker01.Opacity =
                   Label_t12field01_02.Opacity =
                   DatePicker_t12field01_02.Opacity =
                   ResetLabel_t12field01_02.Opacity =
                   Label_t12field01_03.Opacity =
                   DatePicker_t12field01_03.Opacity =
                   ResetLabel_t12field01_03.Opacity =
                   t12field04.Opacity =
                   t12Picker04.Opacity =
                   Label_t12field02_02.Opacity =
                   DatePicker_t12field02_02.Opacity =
                   Entry_t12field02_02.Opacity =
                   ResetLabel_t12field02_02.Opacity =
                   Entry_t12field01_03.Opacity =
                   Entry_t12field01_02.Opacity =
                t12field04_4.Opacity = AppManager.AnswerDisabledOpacity;
            }
        }

        private void T12Picker01_SelectedIndexChanged(object sender, EventArgs e)
        {
            //t12 01_01
            if (t12Picker01.SelectedIndex == 0)
            {
                Erfassungsbogen.t12field01_01 = "1";

                Label_t12field01_02.Opacity =
                DatePicker_t12field01_02.Opacity =
                Entry_t12field01_02.Opacity =
                       ResetLabel_t12field01_02.Opacity =
                       Label_t12field01_03.Opacity =
                       Entry_t12field01_03.Opacity =
                       DatePicker_t12field01_03.Opacity =
                       ResetLabel_t12field01_03.Opacity = AppManager.QuestionOpacity;

                Label_t12field01_02.IsEnabled =
                DatePicker_t12field01_02.IsEnabled =
                Entry_t12field01_02.IsEnabled =
                Entry_t12field01_03.IsEnabled =
                       ResetLabel_t12field01_02.IsEnabled =
                       Label_t12field01_03.IsEnabled =
                       DatePicker_t12field01_03.IsEnabled =
                       ResetLabel_t12field01_03.IsEnabled = true;
            }
            else if (t12Picker01.SelectedIndex == 1)
            {
                Erfassungsbogen.t12field01_01 = "0";

                Label_t12field01_02.Opacity =
                DatePicker_t12field01_02.Opacity =
                Entry_t12field01_02.Opacity =
                Entry_t12field01_03.Opacity =
                       ResetLabel_t12field01_02.Opacity =
                       Label_t12field01_03.Opacity =
                       DatePicker_t12field01_03.Opacity =
                       ResetLabel_t12field01_03.Opacity = AppManager.QuestionDisabledOpacity;

                Label_t12field01_02.IsEnabled =
                DatePicker_t12field01_02.IsEnabled =
                Entry_t12field01_02.IsEnabled =
                Entry_t12field01_03.IsEnabled =
                       ResetLabel_t12field01_02.IsEnabled =
                       Label_t12field01_03.IsEnabled =
                       DatePicker_t12field01_03.IsEnabled =
                       ResetLabel_t12field01_03.IsEnabled = false;
            }
        }

        private void T12Picker04_SelectedIndexChanged(object sender, EventArgs e)
        {
            // t11 02_02
            if (t12Picker04.SelectedIndex == 0)
            {
                Erfassungsbogen.t12field02_01 = "1";

                if (Erfassungsbogen.t12field00 == "1")
                {
                    t12field04_4.IsEnabled =
                 Label_t12field02_02.IsEnabled =
                 DatePicker_t12field02_02.IsEnabled =
                 Entry_t12field02_02.IsEnabled =
                 ResetLabel_t12field02_02.IsEnabled = true;


                    Label_t12field02_02.Opacity =
                       DatePicker_t12field02_02.Opacity =
                       Entry_t12field02_02.Opacity =
                       ResetLabel_t12field02_02.Opacity = 1;

                    t12field04_4.Opacity = 1;

                }
            }
            else if (t12Picker04.SelectedIndex == 1)
            {
                Erfassungsbogen.t12field02_01 = "0.01";

                if (Erfassungsbogen.t12field00 == "1")
                {
                    t12field04_4.IsEnabled =
                 Label_t12field02_02.IsEnabled =
                 DatePicker_t12field02_02.IsEnabled =
                 Entry_t12field02_02.IsEnabled =
                 ResetLabel_t12field02_02.IsEnabled = false;


                    Label_t12field02_02.Opacity =
                       DatePicker_t12field02_02.Opacity =
                       Entry_t12field02_02.Opacity =
                       ResetLabel_t12field02_02.Opacity =

                    t12field04_4.Opacity = AppManager.QuestionDisabledOpacity;

                }
            }
            else if (t12Picker04.SelectedIndex == 2)
            {
                Erfassungsbogen.t12field02_01 = "0.02";

                if (Erfassungsbogen.t12field00 == "1")
                {
                    t12field04_4.IsEnabled =
                 Label_t12field02_02.IsEnabled =
                 DatePicker_t12field02_02.IsEnabled =
                 Entry_t12field02_02.IsEnabled =
                 ResetLabel_t12field02_02.IsEnabled = false;

                    Label_t12field02_02.Opacity =
                       DatePicker_t12field02_02.Opacity =
                       Entry_t12field02_02.Opacity =
                       ResetLabel_t12field02_02.Opacity =

                    t12field04_4.Opacity = AppManager.QuestionDisabledOpacity;

                }
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
                        t12field00.TextColor = t12field01_01.TextColor = Label_t12field01_02.TextColor = Label_t12field01_03.TextColor = t12field04.TextColor = Label_t12field02_02.TextColor = AppManager.QuestionColor;

                        bool h1 = true;
                        bool h2 = true;
                        bool h3 = true;
                        bool h4 = true;

                        if (Erfassungsbogen.t12field00 == "" | Erfassungsbogen.t12field00 == null)
                        {
                            t12field00.TextColor = Color.Red;
                        }
                        else
                        {
                            h1 = true;

                            if (Erfassungsbogen.t12field00 == "1")
                            {
                                if (Erfassungsbogen.t12field01_01 == "" | Erfassungsbogen.t12field01_01 == null)
                                {
                                    t12field01_01.TextColor = Color.Red;
                                    h2 = false;
                                }
                                else
                                {
                                    h2 = true;
                                    if (Erfassungsbogen.t12field01_01 == "1")
                                    {
                                        // checking for the manditory fields
                                        if (Erfassungsbogen.t12field01_02 == "" | Erfassungsbogen.t12field01_02 == null | Erfassungsbogen.t12field01_03 == "" | Erfassungsbogen.t12field01_03 == null)
                                        {
                                            h3 = false;
                                            Label_t12field01_02.TextColor = Color.Red;
                                            Label_t12field01_03.TextColor = Color.Red;
                                        }
                                        else
                                        {
                                            h3 = true;
                                        }
                                    }
                                    else
                                    {
                                        h3 = true;
                                    }
                                }

                                if (Erfassungsbogen.t12field02_01 == "" | Erfassungsbogen.t12field02_01 == null)
                                {
                                    h4 = false;
                                    t12field04.TextColor = Color.Red;
                                }
                                else
                                {
                                    h4 = true;
                                    if (Erfassungsbogen.t12field02_01 == "1")
                                    {
                                        if (Erfassungsbogen.t12field02_02 == "" && Erfassungsbogen.t12field02_02 == null)
                                        {
                                            h4 = false;
                                            t12field04_4.TextColor = Color.Red;
                                            Label_t12field02_02.TextColor = Color.Red;
                                        }
                                        else
                                        {
                                            h4 = true;
                                        }
                                    }
                                    else
                                    {
                                        h4 = true;
                                    }
                                }

                                if (h1 & h2 & h3 & h4)
                                {
                                    WebRequest req = WebRequest.Create(DBManagement.DBConnection + "tbl_form_ebqe_t12_01_update.php");

                                    req.Method = "POST"; //POST
                                    req.Timeout = 15000;
                                    req.ContentType = "application/x-www-form-urlencoded";

                                    string postData = "mstr=" + App.user.selected_mstr_ebqe + "&bewonerid=" + App.user.selected_id_bewohner + "&t12field00=" + Erfassungsbogen.t12field00 + "&t12field01_01=" + Erfassungsbogen.t12field01_01 + "&t12field01_02=" + Erfassungsbogen.t12field01_02 + "&t12field01_03=" + Erfassungsbogen.t12field01_03 + "&t12field02_01=" + Erfassungsbogen.t12field02_01 + "&t12field02_02=" + Erfassungsbogen.t12field02_02;

                                    byte[] byteArray = Encoding.UTF8.GetBytes(postData);

                                    req.ContentLength = byteArray.Length;

                                    Stream ds = await req.GetRequestStreamAsync();
                                    await ds.WriteAsync(byteArray, 0, byteArray.Length);
                                    ds.Close();

                                    await Navigation.PushAsync(new Heimeinzug_2());
                                }
                                else
                                {
                                    await DisplayAlert(AppResources.Warning, AppResources.FieldsUnfilled, "OK");
                                    BackButton.Source = "ic_arrow_back_ios.png";
                                }
                            }
                            else
                            {
                                Erfassungsbogen.t12field01_01 = "";
                                Erfassungsbogen.t12field01_02 = "";
                                Erfassungsbogen.t12field01_03 = "";
                                Erfassungsbogen.t12field02_01 = "";
                                Erfassungsbogen.t12field02_02 = "";

                                if (App.user.selected_mstr_ebqe == DBManagement.CurrentEvaluationID)
                                {
                                    WebRequest req = WebRequest.Create(DBManagement.DBConnection + "tbl_form_ebqe_t12_01_update.php");

                                    req.Method = "POST"; //POST
                                    req.Timeout = 15000;
                                    req.ContentType = "application/x-www-form-urlencoded";

                                    string postData = "mstr=" + App.user.selected_mstr_ebqe + "&bewonerid=" + App.user.selected_id_bewohner + "&t12field00=" + Erfassungsbogen.t12field00 + "&t12field01_01=" + Erfassungsbogen.t12field01_01 +
                                        "&t12field01_02=" + Erfassungsbogen.t12field01_02 + "&t12field01_03=" + Erfassungsbogen.t12field01_03 + "&t12field02_01=" + Erfassungsbogen.t12field02_01 + "&t12field02_02=" + Erfassungsbogen.t12field02_02;

                                    byte[] byteArray = Encoding.UTF8.GetBytes(postData);

                                    req.ContentLength = byteArray.Length;

                                    Stream ds = await req.GetRequestStreamAsync();
                                    await ds.WriteAsync(byteArray, 0, byteArray.Length);
                                    ds.Close();
                                }
                                await Navigation.PushAsync(new Heimeinzug_2());
                            }
                        }
                    }
                    else
                    {
                        Erfassungsbogen.t12field00 = Erfassungsbogen.t12field01_01 = Erfassungsbogen.t12field01_02 = Erfassungsbogen.t12field01_03 = Erfassungsbogen.t12field02_01 = Erfassungsbogen.t12field02_02 = "";

                        WebRequest req = WebRequest.Create(DBManagement.DBConnection + "tbl_form_ebqe_t12_01_update.php");

                        req.Method = "POST"; //POST
                        req.Timeout = 15000;
                        req.ContentType = "application/x-www-form-urlencoded";

                        string postData = "mstr=" + App.user.selected_mstr_ebqe + "&bewonerid=" + App.user.selected_id_bewohner + "&t12field00=" + Erfassungsbogen.t12field00 + "&t12field01_01=" + Erfassungsbogen.t12field01_01 + "&t12field01_02=" + Erfassungsbogen.t12field01_02 + "&t12field01_03=" + Erfassungsbogen.t12field01_03 + "&t12field02_01=" + Erfassungsbogen.t12field02_01 + "&t12field02_02=" + Erfassungsbogen.t12field02_02;

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
                    await Navigation.PushAsync(new Heimeinzug_2());
                }
                else
                {
                    t12field00.TextColor = t12field01_01.TextColor = Label_t12field01_02.TextColor = Label_t12field01_03.TextColor = t12field04.TextColor = Label_t12field02_02.TextColor = AppManager.QuestionColor;

                    bool h1 = true;
                    bool h2 = true;
                    bool h3 = true;
                    bool h4 = true;

                    if (Erfassungsbogen.t12field00 == "" | Erfassungsbogen.t12field00 == null)
                    {
                        t12field00.TextColor = Color.Red;
                    }
                    else
                    {
                        h1 = true;

                        if (Erfassungsbogen.t12field00 == "1")
                        {
                            if (Erfassungsbogen.t12field01_01 == "" | Erfassungsbogen.t12field01_01 == null)
                            {
                                t12field01_01.TextColor = Color.Red;
                                h2 = false;
                            }
                            else
                            {
                                h2 = true;
                                if (Erfassungsbogen.t12field01_01 == "1")
                                {
                                    // checking for the manditory fields
                                    if (Erfassungsbogen.t12field01_02 == "" | Erfassungsbogen.t12field01_02 == null | Erfassungsbogen.t12field01_03 == "" | Erfassungsbogen.t12field01_03 == null)
                                    {
                                        h3 = false;
                                        Label_t12field01_02.TextColor = Color.Red;
                                        Label_t12field01_03.TextColor = Color.Red;
                                    }
                                    else
                                    {
                                        h3 = true;
                                    }
                                }
                                else
                                {
                                    h3 = true;
                                }
                            }

                            if (Erfassungsbogen.t12field02_01 == "" | Erfassungsbogen.t12field02_01 == null)
                            {
                                h4 = false;
                                t12field04.TextColor = Color.Red;
                            }
                            else
                            {
                                h4 = true;
                                if (Erfassungsbogen.t12field02_01 == "1")
                                {
                                    if (Erfassungsbogen.t12field02_02 == "" && Erfassungsbogen.t12field02_02 == null)
                                    {
                                        h4 = false;
                                        t12field04_4.TextColor = Color.Red;
                                        Label_t12field02_02.TextColor = Color.Red;
                                    }
                                    else
                                    {
                                        h4 = true;
                                    }
                                }
                                else
                                {
                                    h4 = true;
                                }
                            }

                            if (h1 & h2 & h3 & h4)
                            {
                                WebRequest req = WebRequest.Create(DBManagement.DBConnection + "tbl_form_ebqe_t12_01_update.php");

                                req.Method = "POST"; //POST
                                req.Timeout = 15000;
                                req.ContentType = "application/x-www-form-urlencoded";

                                string postData = "mstr=" + App.user.selected_mstr_ebqe + "&bewonerid=" + App.user.selected_id_bewohner + "&t12field00=" + Erfassungsbogen.t12field00 + "&t12field01_01=" + Erfassungsbogen.t12field01_01 + "&t12field01_02=" + Erfassungsbogen.t12field01_02 + "&t12field01_03=" + Erfassungsbogen.t12field01_03 + "&t12field02_01=" + Erfassungsbogen.t12field02_01 + "&t12field02_02=" + Erfassungsbogen.t12field02_02;

                                byte[] byteArray = Encoding.UTF8.GetBytes(postData);

                                req.ContentLength = byteArray.Length;

                                Stream ds = await req.GetRequestStreamAsync();
                                await ds.WriteAsync(byteArray, 0, byteArray.Length);
                                ds.Close();

                                await Navigation.PushAsync(new Heimeinzug_2());
                            }
                            else
                            {
                                await DisplayAlert(AppResources.Warning, AppResources.FieldsUnfilled, "OK");
                                ForwardButton.Source = "ic_arrow_forward_ios.png";
                            }                           
                        }
                        else
                        {
                            Erfassungsbogen.t12field01_01 = "";
                            Erfassungsbogen.t12field01_02 = "";
                            Erfassungsbogen.t12field01_03 = "";
                            Erfassungsbogen.t12field02_01 = "";
                            Erfassungsbogen.t12field02_02 = "";

                            if (App.user.selected_mstr_ebqe == DBManagement.CurrentEvaluationID)
                            {
                                WebRequest req = WebRequest.Create(DBManagement.DBConnection + "tbl_form_ebqe_t12_01_update.php");

                                req.Method = "POST"; //POST
                                req.Timeout = 15000;
                                req.ContentType = "application/x-www-form-urlencoded";

                                string postData = "mstr=" + App.user.selected_mstr_ebqe + "&bewonerid=" + App.user.selected_id_bewohner + "&t12field00=" + Erfassungsbogen.t12field00 + "&t12field01_01=" + Erfassungsbogen.t12field01_01 +
                                    "&t12field01_02=" + Erfassungsbogen.t12field01_02 + "&t12field01_03=" + Erfassungsbogen.t12field01_03 + "&t12field02_01=" + Erfassungsbogen.t12field02_01 + "&t12field02_02=" + Erfassungsbogen.t12field02_02;

                                byte[] byteArray = Encoding.UTF8.GetBytes(postData);

                                req.ContentLength = byteArray.Length;

                                Stream ds = await req.GetRequestStreamAsync();
                                await ds.WriteAsync(byteArray, 0, byteArray.Length);
                                ds.Close();
                            }
                            await Navigation.PushAsync(new Heimeinzug_2());
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

        #region t12field01_02

        private void ResetLabel_t12field01_02_Tapped(object sender, EventArgs e)
        {
            Erfassungsbogen.t12field01_02 = "";
            Entry_t12field01_02.Text = "";
        }

        private void Entry_t12field01_02_Focused(object sender, FocusEventArgs e)
        {
            Entry_t12field01_02.Unfocus();
            DatePicker_t12field01_02.Focus();
        }

        private void DatePicker_t12field01_02_Unfocused(object sender, DateChangedEventArgs e)
        {
            Erfassungsbogen.t12field01_02 = DatePicker_t12field01_02.Date.ToString("dd.MM.yyyy");
            Entry_t12field01_02.Text = DatePicker_t12field01_02.Date.ToString("dd.MM.yyyy");
        }

        private void DatePicker_t12field01_02_DateSelected(object sender, DateChangedEventArgs e)
        {
            Erfassungsbogen.t12field01_02 = DatePicker_t12field01_02.Date.ToString("dd.MM.yyyy");
            Entry_t12field01_02.Text = DatePicker_t12field01_02.Date.ToString("dd.MM.yyyy");
        }

        #endregion

        #region t12field01_03

        private void ResetLabel_t12field01_03_Tapped(object sender, EventArgs e)
        {
            Erfassungsbogen.t12field01_03 = "";
            Entry_t12field01_03.Text = "";
        }

        private void Entry_t12field01_03_Focused(object sender, FocusEventArgs e)
        {
            Entry_t12field01_03.Unfocus();
            DatePicker_t12field01_03.Focus();
        }

        private void DatePicker_t12field01_03_Unfocused(object sender, DateChangedEventArgs e)
        {
            Erfassungsbogen.t12field01_03 = DatePicker_t12field01_03.Date.ToString("dd.MM.yyyy");
            Entry_t12field01_03.Text = DatePicker_t12field01_03.Date.ToString("dd.MM.yyyy");
        }

        private void DatePicker_t12field01_03_DateSelected(object sender, DateChangedEventArgs e)
        {
            Erfassungsbogen.t12field01_03 = DatePicker_t12field01_03.Date.ToString("dd.MM.yyyy");
            Entry_t12field01_03.Text = DatePicker_t12field01_03.Date.ToString("dd.MM.yyyy");
        }

        #endregion

        #region t12field02_02

        private void ResetLabel_t12field02_02_Tapped(object sender, EventArgs e)
        {
            Erfassungsbogen.t12field02_02 = "";
            Entry_t12field02_02.Text = "";
        }

        private void Entry_t12field02_02_Focused(object sender, FocusEventArgs e)
        {
            Entry_t12field02_02.Unfocus();
            DatePicker_t12field02_02.Focus();
        }

        private void DatePicker_t12field02_02_Unfocused(object sender, DateChangedEventArgs e)
        {
            Erfassungsbogen.t12field02_02 = DatePicker_t12field02_02.Date.ToString("dd.MM.yyyy");
            Entry_t12field02_02.Text = DatePicker_t12field02_02.Date.ToString("dd.MM.yyyy");
        }

        private void DatePicker_t12field02_02_DateSelected(object sender, DateChangedEventArgs e)
        {
            Erfassungsbogen.t12field02_02 = DatePicker_t12field02_02.Date.ToString("dd.MM.yyyy");
            Entry_t12field02_02.Text = DatePicker_t12field02_02.Date.ToString("dd.MM.yyyy");
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