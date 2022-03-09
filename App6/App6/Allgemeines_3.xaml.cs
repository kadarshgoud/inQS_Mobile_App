using App6.Management;
using App6.Model;
using App6.Resources;
using System;
using System.IO;
using System.Net;
using System.Text;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App6
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Allgemeines_3 : ContentPage, INotifyPropertyChanged
    {
        public bool InitialDataIsEmpty;

        public Allgemeines_3()
        {
            InitializeComponent();
            BindingContext = this;

            BogenLabel.Text = AppResources.SurveyHeadline + " " + DBManagement.getYearCode(App.user.selected_mstr_ebqe) + " " + AppResources.SurveyHeadlineFor + " " + Erfassungsbogen.Bewohnerbezeichnung;

            t00field08.Items.Add("ja, einmal");
            t00field08.Items.Add("ja, mehrmals");
            t00field08.Items.Add("nein");

            t00field08_03.Items.Add("Bluthochdruck");
            t00field08_03.Items.Add("Diabetis Mellitus");
            t00field08_03.Items.Add("Chronische Bronchitis");
            t00field08_03.Items.Add("Lungenerkrankung");
            t00field08_03.Items.Add("Augenleiden");
            t00field08_03.Items.Add("Rheuma");
            t00field08_03.Items.Add("Sturz");
            t00field08_03.Items.Add("Infektion");
            t00field08_03.Items.Add("Krebserkrankung");
            t00field08_03.Items.Add("Sonstige Erkrankung");
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
                    await Navigation.PushAsync(new Allgemeines_2());
                }
                else
                {
                    var BackQuestion = await DisplayAlert(AppResources.Information, AppResources.InformationSaveQuery, AppResources.Yes, AppResources.No);
                    if (BackQuestion == true)
                    {
                        bool SavePossible = false;

                        //Set Text Entry Values in Erfassungsbogen
                        Erfassungsbogen.t00field08_04 = t00field08_04.Text;
                        Erfassungsbogen.t00field08_05 = t00field08_05.Text;

                        t00label08.TextColor = t00label08_p.TextColor = Label_t00field08_01.TextColor = Label_t00field08_02.TextColor = t00label08_03.TextColor = t00label08_04.TextColor = t00label08_05.TextColor = AppManager.QuestionColor;

                        if (Erfassungsbogen.t00field08 == null | Erfassungsbogen.t00field08 == "")
                        {
                            t00label08.TextColor = Color.Red;
                        }

                        if (Erfassungsbogen.t00field08 == "0")
                        {
                            SavePossible = true;
                        }
                        if (Erfassungsbogen.t00field08 == "1" | Erfassungsbogen.t00field08 == "2")
                        {
                            if (Erfassungsbogen.t00field08_01 == "" || Erfassungsbogen.t00field08_01 == null)
                            {
                                t00label08_p.TextColor = Color.Red;
                                Label_t00field08_01.TextColor = Color.Red;
                            }
                            if (Erfassungsbogen.t00field08_02 == "" || Erfassungsbogen.t00field08_02 == null)
                            {
                                t00label08_p.TextColor = Color.Red;
                                Label_t00field08_02.TextColor = Color.Red;
                            }
                            if (Erfassungsbogen.t00field08_03 == "" || Erfassungsbogen.t00field08_03 == null)
                            {
                                t00label08_p.TextColor = Color.Red;
                                t00label08_03.TextColor = Color.Red;
                            }
                            if (t00field08_04.Text == "" || t00field08_04.Text == null)
                            {
                                t00label08_04.TextColor = Color.Red;
                            }
                            if (t00field08_05.Text == "" || t00field08_05.Text == null)
                            {
                                t00label08_05.TextColor = Color.Red;
                            }

                            if (Erfassungsbogen.t00field08_01 != "" && Erfassungsbogen.t00field08_01 != null && Erfassungsbogen.t00field08_02 != "" && Erfassungsbogen.t00field08_02 != null && Erfassungsbogen.t00field08_03 != "" && Erfassungsbogen.t00field08_03 != null && t00field08_04.Text != "" && t00field08_04.Text != null && t00field08_05.Text != "" && t00field08_05.Text != null)
                            {
                                SavePossible = true;
                            }
                        }

                        if (SavePossible)
                        {
                            if (Erfassungsbogen.t00field08 == "0")
                            {
                                Erfassungsbogen.t00field08_01 = "";
                                Erfassungsbogen.t00field08_02 = "";
                                Erfassungsbogen.t00field08_03 = "";
                                t00field08_04.Text = "";
                                t00field08_05.Text = "";
                            }

                            WebRequest req = WebRequest.Create(DBManagement.DBConnection + "tbl_form_ebqe_t00_03_update.php");

                            req.Method = "POST"; //POST
                            req.Timeout = 15000;
                            req.ContentType = "application/x-www-form-urlencoded";

                            string postData = "mstr=" + App.user.selected_mstr_ebqe + "&bewonerid=" + App.user.selected_id_bewohner + "&t00field08=" + Erfassungsbogen.t00field08 + "&t00field08_01=" + Erfassungsbogen.t00field08_01 + "&t00field08_02=" + Erfassungsbogen.t00field08_02 + "&t00field08_03=" + Erfassungsbogen.t00field08_03 + "&t00field08_04=" + t00field08_04.Text + "&t00field08_05=" + t00field08_05.Text;

                            byte[] byteArray = Encoding.UTF8.GetBytes(postData);

                            req.ContentLength = byteArray.Length;

                            Stream ds = await req.GetRequestStreamAsync();
                            await ds.WriteAsync(byteArray, 0, byteArray.Length);
                            ds.Close();

                            await Navigation.PushAsync(new Allgemeines_2());
                        }
                        else
                        {
                            await DisplayAlert(AppResources.Warning, AppResources.FieldsUnfilled, "OK");
                            BackButton.Source = "ic_arrow_back_ios.png";
                        }
                    }
                    else
                    {
                        Erfassungsbogen.t00field08 = Erfassungsbogen.t00field08_01 = Erfassungsbogen.t00field08_02 = Erfassungsbogen.t00field08_03 = Erfassungsbogen.t00field08_04 = Erfassungsbogen.t00field08_05 = "";
                        t00field08_04.Text = t00field08_05.Text = "";

                        WebRequest req = WebRequest.Create(DBManagement.DBConnection + "tbl_form_ebqe_t00_03_update.php");

                        req.Method = "POST"; //POST
                        req.Timeout = 15000;
                        req.ContentType = "application/x-www-form-urlencoded";

                        string postData = "mstr=" + App.user.selected_mstr_ebqe + "&bewonerid=" + App.user.selected_id_bewohner + "&t00field08=" + Erfassungsbogen.t00field08 + "&t00field08_01=" + Erfassungsbogen.t00field08_01 + "&t00field08_02=" + Erfassungsbogen.t00field08_02 + "&t00field08_03=" + Erfassungsbogen.t00field08_03 + "&t00field08_04=" + t00field08_04.Text + "&t00field08_05=" + t00field08_05.Text;

                        byte[] byteArray = Encoding.UTF8.GetBytes(postData);

                        req.ContentLength = byteArray.Length;

                        Stream ds = await req.GetRequestStreamAsync();
                        await ds.WriteAsync(byteArray, 0, byteArray.Length);
                        ds.Close();

                        await Navigation.PushAsync(new Allgemeines_2());
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
                    await Navigation.PushAsync(new Allgemeines_4());
                }
                else
                {
                    bool SavePossible = false;

                    //Set Text Entry Values in Erfassungsbogen
                    Erfassungsbogen.t00field08_04 = t00field08_04.Text;
                    Erfassungsbogen.t00field08_05 = t00field08_05.Text;

                    t00label08.TextColor = t00label08_p.TextColor = Label_t00field08_01.TextColor = Label_t00field08_02.TextColor = t00label08_03.TextColor = t00label08_04.TextColor = t00label08_05.TextColor = AppManager.QuestionColor;

                    if (Erfassungsbogen.t00field08 == null | Erfassungsbogen.t00field08 == "")
                    {
                        t00label08.TextColor = Color.Red;
                    }

                    if (Erfassungsbogen.t00field08 == "0")
                    {

                        SavePossible = true;
                    }
                    if (Erfassungsbogen.t00field08 == "1" | Erfassungsbogen.t00field08 == "2")
                    {
                        if (Erfassungsbogen.t00field08_01 == "" || Erfassungsbogen.t00field08_01 == null)
                        {
                            t00label08_p.TextColor = Color.Red;
                            Label_t00field08_01.TextColor = Color.Red;
                        }
                        if (Erfassungsbogen.t00field08_02 == "" || Erfassungsbogen.t00field08_02 == null)
                        {
                            t00label08_p.TextColor = Color.Red;
                            Label_t00field08_02.TextColor = Color.Red;
                        }
                        if (Erfassungsbogen.t00field08_03 == "" || Erfassungsbogen.t00field08_03 == null)
                        {
                            t00label08_p.TextColor = Color.Red;
                            t00label08_03.TextColor = Color.Red;
                        }
                        if (t00field08_04.Text == "" || t00field08_04.Text == null)
                        {
                            t00label08_04.TextColor = Color.Red;
                        }
                        if (t00field08_05.Text == "" || t00field08_05.Text == null)
                        {
                            t00label08_05.TextColor = Color.Red;
                        }

                        if (Erfassungsbogen.t00field08_01 != "" && Erfassungsbogen.t00field08_01 != null && Erfassungsbogen.t00field08_02 != "" && Erfassungsbogen.t00field08_02 != null && Erfassungsbogen.t00field08_03 != "" && Erfassungsbogen.t00field08_03 != null && t00field08_04.Text != "" && t00field08_04.Text != null && t00field08_05.Text != "" && t00field08_05.Text != null)
                        {
                            SavePossible = true;
                        }
                    }

                    if (SavePossible)
                    {

                        if (Erfassungsbogen.t00field08 == "0")
                        {
                            Erfassungsbogen.t00field08_01 = "";
                            Erfassungsbogen.t00field08_02 = "";
                            Erfassungsbogen.t00field08_03 = "";
                            t00field08_04.Text = "";
                            t00field08_05.Text = "";
                        }

                        WebRequest req = WebRequest.Create(DBManagement.DBConnection + "tbl_form_ebqe_t00_03_update.php");

                        req.Method = "POST"; //POST
                        req.Timeout = 15000;
                        req.ContentType = "application/x-www-form-urlencoded";

                        string postData = "mstr=" + App.user.selected_mstr_ebqe + "&bewonerid=" + App.user.selected_id_bewohner + "&t00field08=" + Erfassungsbogen.t00field08 + "&t00field08_01=" + Erfassungsbogen.t00field08_01 + "&t00field08_02=" + Erfassungsbogen.t00field08_02 + "&t00field08_03=" + Erfassungsbogen.t00field08_03 + "&t00field08_04=" + t00field08_04.Text + "&t00field08_05=" + t00field08_05.Text;

                        byte[] byteArray = Encoding.UTF8.GetBytes(postData);

                        req.ContentLength = byteArray.Length;

                        Stream ds = await req.GetRequestStreamAsync();
                        await ds.WriteAsync(byteArray, 0, byteArray.Length);
                        ds.Close();


                        await Navigation.PushAsync(new Allgemeines_4());
                    }
                    else
                    {
                        await DisplayAlert(AppResources.Warning, AppResources.FieldsUnfilled, "OK");
                        ForwardButton.Source = "ic_arrow_forward_ios.png";
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

        //Before page gets loaded this opertion is performed
        protected override async void OnAppearing()
        {
            base.OnAppearing();

            try
            {
                //ActivityIndicator = Loading...
                IsLoading = true;

                //WebRequest req = WebRequest.Create(DBManagement.DBConnection + "tbl_form_ebqe_t00_03_read.php");

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

                //Erfassungsbogen.t00field08 = split[0];
                //Erfassungsbogen.t00field08_01 = split[1];
                //Erfassungsbogen.t00field08_02 = split[2];
                //Erfassungsbogen.t00field08_03 = split[3];
                //Erfassungsbogen.t00field08_04 = split[4];
                //Erfassungsbogen.t00field08_05 = split[5];

                // date picker
                if (Erfassungsbogen.t00field08_01 != "")
                {
                    DatePicker_t00field08_01.Date = DateTime.ParseExact(Erfassungsbogen.t00field08_01.Replace('.', '/'), "dd/MM/yyyy", null).Date;
                    Entry_t00field08_01.Text = Erfassungsbogen.t00field08_01;
                }

                // date picker 2
                if (Erfassungsbogen.t00field08_02 != "")
                {
                    DatePicker_t00field08_02.Date = DateTime.ParseExact(Erfassungsbogen.t00field08_02.Replace('.', '/'), "dd/MM/yyyy", null).Date;
                    Entry_t00field08_02.Text = Erfassungsbogen.t00field08_02;
                }

                // picker 08 

                if (Erfassungsbogen.t00field08 == "1")
                {
                    t00field08.SelectedIndex = 0;                         // rb1 is the image file with checked box image
                }
                else if (Erfassungsbogen.t00field08 == "2")
                {
                    t00field08.SelectedIndex = 1;
                }
                else if (Erfassungsbogen.t00field08 == "0")
                {
                    t00field08.SelectedIndex = 2;
                }
                else
                {
                    t00field08.SelectedIndex = -1;
                }
                //make stuff opacity
                if (Erfassungsbogen.t00field08 == "0" | Erfassungsbogen.t00field08 == null | Erfassungsbogen.t00field08 == "")
                {
                    //Wenn ja
                    t00label08_p.Opacity = AppManager.QuestionDisabledOpacity;

                    //vom:
                    Label_t00field08_01.Opacity = AppManager.QuestionDisabledOpacity;
                    DatePicker_t00field08_01.Opacity = AppManager.AnswerDisabledOpacity;
                    Entry_t00field08_01.Opacity = AppManager.AnswerDisabledOpacity;
                    ResetLabel_t00field08_01.Opacity = AppManager.AnswerDisabledOpacity;

                    //bis:
                    Label_t00field08_02.Opacity = AppManager.QuestionDisabledOpacity;
                    DatePicker_t00field08_02.Opacity = AppManager.AnswerDisabledOpacity;
                    Entry_t00field08_02.Opacity = AppManager.AnswerDisabledOpacity;
                    ResetLabel_t00field08_02.Opacity = AppManager.AnswerDisabledOpacity;

                    //Grund:
                    t00label08_03.Opacity = AppManager.QuestionDisabledOpacity;
                    t00field08_03.Opacity = AppManager.AnswerDisabledOpacity;

                    //Anzahl Aufenthalte
                    t00label08_04.Opacity = AppManager.QuestionDisabledOpacity;
                    t00field08_04.Opacity = AppManager.AnswerDisabledOpacity;

                    //Gesamtzahl Tage
                    t00label08_05.Opacity = AppManager.QuestionDisabledOpacity;
                    t00field08_05.Opacity = AppManager.AnswerDisabledOpacity;
                }
                else
                {
                    //Wenn ja
                    t00label08_p.Opacity = AppManager.QuestionOpacity;

                    //vom:
                    Label_t00field08_01.Opacity = AppManager.QuestionOpacity;
                    DatePicker_t00field08_01.Opacity = AppManager.AnswerOpacity;
                    Entry_t00field08_01.Opacity = AppManager.AnswerOpacity;
                    ResetLabel_t00field08_01.Opacity = AppManager.AnswerOpacity;

                    //bis:
                    Label_t00field08_02.Opacity = AppManager.QuestionOpacity;
                    DatePicker_t00field08_02.Opacity = AppManager.AnswerOpacity;
                    Entry_t00field08_02.Opacity = AppManager.AnswerOpacity;
                    ResetLabel_t00field08_02.Opacity = AppManager.AnswerOpacity;

                    //Grund:
                    t00label08_03.Opacity = AppManager.QuestionOpacity;
                    t00field08_03.Opacity = AppManager.AnswerOpacity;

                    //Anzahl Aufenthalte
                    t00label08_04.Opacity = AppManager.QuestionOpacity;
                    t00field08_04.Opacity = AppManager.AnswerOpacity;

                    //Gesamtzahl Tage
                    t00label08_05.Opacity = AppManager.QuestionOpacity;
                    t00field08_05.Opacity = AppManager.AnswerOpacity;
                }

                // picker 08_03 10options

                if (Erfassungsbogen.t00field08_03 == "Bluthochdruck")
                {
                    t00field08_03.SelectedIndex = 0;                         // rb1 is the image file with checked box image
                }
                else if (Erfassungsbogen.t00field08_03 == "Diabetis Mellitus")
                {
                    t00field08_03.SelectedIndex = 1;
                }
                else if (Erfassungsbogen.t00field08_03 == "Chronische Bronchitis")
                {
                    t00field08_03.SelectedIndex = 2;
                }
                else if (Erfassungsbogen.t00field08_03 == "Lungenerkrankung")
                {
                    t00field08_03.SelectedIndex = 3;                         // rb1 is the image file with checked box image
                }
                else if (Erfassungsbogen.t00field08_03 == "Augenleiden")
                {
                    t00field08_03.SelectedIndex = 4;
                }
                else if (Erfassungsbogen.t00field08_03 == "Rheuma")
                {
                    t00field08_03.SelectedIndex = 5;
                }
                else if (Erfassungsbogen.t00field08_03 == "Sturz")
                {
                    t00field08_03.SelectedIndex = 6;                         // rb1 is the image file with checked box image
                }
                else if (Erfassungsbogen.t00field08_03 == "Infektion")
                {
                    t00field08_03.SelectedIndex = 7;
                }
                else if (Erfassungsbogen.t00field08_03 == "Krebserkrankung")
                {
                    t00field08_03.SelectedIndex = 8;
                }
                else if (Erfassungsbogen.t00field08_03 == "Sonstige Erkrankung")
                {
                    t00field08_03.SelectedIndex = 9;                         // rb1 is the image file with checked box image
                }
                else
                {
                    t00field08_03.SelectedIndex = -1;
                }

                // text box 08_04

                t00field08_04.Text = Erfassungsbogen.t00field08_04;

                t00field08_05.Text = Erfassungsbogen.t00field08_05;
                //ActivityIndicator = Idle
                IsLoading = false;

            }
            catch (Exception)
            {
                await DisplayAlert(AppResources.AppError, AppResources.AppErrorMsg, "OK");
            }
        }

        private void T00field08_SelectedIndexChanged(object sender, EventArgs e)
        {
            // picker T00 08

            if (t00field08.SelectedIndex == 0)
            {
                Erfassungsbogen.t00field08 = "1";

            }
            else if (t00field08.SelectedIndex == 1)
            {
                Erfassungsbogen.t00field08 = "2";

            }
            else if (t00field08.SelectedIndex == 2)
            {
                Erfassungsbogen.t00field08 = "0";
            }

            //make stuff opacity
            if (Erfassungsbogen.t00field08 == "0")
            {
                //Wenn ja
                t00label08_p.Opacity = AppManager.QuestionDisabledOpacity;

                //vom:
                Label_t00field08_01.Opacity = AppManager.QuestionDisabledOpacity;
                DatePicker_t00field08_01.Opacity = AppManager.AnswerDisabledOpacity;
                Entry_t00field08_01.Opacity = AppManager.AnswerDisabledOpacity;
                ResetLabel_t00field08_01.Opacity = AppManager.AnswerDisabledOpacity;

                //bis:
                Label_t00field08_02.Opacity = AppManager.QuestionDisabledOpacity;
                DatePicker_t00field08_02.Opacity = AppManager.AnswerDisabledOpacity;
                Entry_t00field08_02.Opacity = AppManager.AnswerDisabledOpacity;
                ResetLabel_t00field08_02.Opacity = AppManager.AnswerDisabledOpacity;

                //Grund:
                t00label08_03.Opacity = AppManager.QuestionDisabledOpacity;
                t00field08_03.Opacity = AppManager.AnswerDisabledOpacity;

                //Anzahl Aufenthalte
                t00label08_04.Opacity = AppManager.QuestionDisabledOpacity;
                t00field08_04.Opacity = AppManager.AnswerDisabledOpacity;

                //Gesamtzahl Tage
                t00label08_05.Opacity = AppManager.QuestionDisabledOpacity;
                t00field08_05.Opacity = AppManager.AnswerDisabledOpacity;
            }
            else
            {
                //Wenn ja
                t00label08_p.Opacity = AppManager.QuestionOpacity;

                //vom:
                Label_t00field08_01.Opacity = AppManager.QuestionOpacity;
                DatePicker_t00field08_01.Opacity = AppManager.AnswerOpacity;
                Entry_t00field08_01.Opacity = AppManager.AnswerOpacity;
                ResetLabel_t00field08_01.Opacity = AppManager.AnswerOpacity;

                //bis:
                Label_t00field08_02.Opacity = AppManager.QuestionOpacity;
                DatePicker_t00field08_02.Opacity = AppManager.AnswerOpacity;
                Entry_t00field08_02.Opacity = AppManager.AnswerOpacity;
                ResetLabel_t00field08_02.Opacity = AppManager.AnswerOpacity;

                //Grund:
                t00label08_03.Opacity = AppManager.QuestionOpacity;
                t00field08_03.Opacity = AppManager.AnswerOpacity;

                //Anzahl Aufenthalte
                t00label08_04.Opacity = AppManager.QuestionOpacity;
                t00field08_04.Opacity = AppManager.AnswerOpacity;

                //Gesamtzahl Tage
                t00label08_05.Opacity = AppManager.QuestionOpacity;
                t00field08_05.Opacity = AppManager.AnswerOpacity;
            }
        }

        private void T00field08_03_SelectedIndexChanged(object sender, EventArgs e)
        {
            // 08 03

            if (t00field08_03.SelectedIndex == 0)
            {
                Erfassungsbogen.t00field08_03 = "Bluthochdruck";

            }
            else if (t00field08_03.SelectedIndex == 1)
            {
                Erfassungsbogen.t00field08_03 = "Diabetis Mellitus";

            }
            else if (t00field08_03.SelectedIndex == 2)
            {
                Erfassungsbogen.t00field08_03 = "Chronische Bronchitis";

            }
            else if (t00field08_03.SelectedIndex == 3)
            {
                Erfassungsbogen.t00field08_03 = "Lungenerkrankung";

            }
            else if (t00field08_03.SelectedIndex == 4)
            {
                Erfassungsbogen.t00field08_03 = "Augenleiden";

            }
            else if (t00field08_03.SelectedIndex == 5)
            {
                Erfassungsbogen.t00field08_03 = "Rheuma";

            }
            else if (t00field08_03.SelectedIndex == 6)
            {
                Erfassungsbogen.t00field08_03 = "Sturz";

            }
            else if (t00field08_03.SelectedIndex == 7)
            {
                Erfassungsbogen.t00field08_03 = "Infektion";

            }
            else if (t00field08_03.SelectedIndex == 8)
            {
                Erfassungsbogen.t00field08_03 = "Krebserkrankung";
            }
            else if (t00field08_03.SelectedIndex == 9)
            {
                Erfassungsbogen.t00field08_03 = "Sonstige Erkrankung";
            }
        }

        #region t00field08_01

        private void ResetLabel_t00field08_01_Tapped(object sender, EventArgs e)
        {
            Erfassungsbogen.t00field08_01 = "";
            Entry_t00field08_01.Text = "";
        }

        private void Entry_t00field08_01_Focused(object sender, FocusEventArgs e)
        {
            Entry_t00field08_01.Unfocus();
            DatePicker_t00field08_01.Focus();
        }

        private void DatePicker_t00field08_01_Unfocused(object sender, DateChangedEventArgs e)
        {
            Erfassungsbogen.t00field08_01 = DatePicker_t00field08_01.Date.ToString("dd.MM.yyyy");
            Entry_t00field08_01.Text = DatePicker_t00field08_01.Date.ToString("dd.MM.yyyy");
        }

        private void DatePicker_t00field08_01_DateSelected(object sender, DateChangedEventArgs e)
        {
            Erfassungsbogen.t00field08_01 = DatePicker_t00field08_01.Date.ToString("dd.MM.yyyy");
            Entry_t00field08_01.Text = DatePicker_t00field08_01.Date.ToString("dd.MM.yyyy");
        }

        #endregion

        #region t00field08_02

        private void ResetLabel_t00field08_02_Tapped(object sender, EventArgs e)
        {
            Erfassungsbogen.t00field08_02 = "";
            Entry_t00field08_02.Text = "";
        }

        private void Entry_t00field08_02_Focused(object sender, FocusEventArgs e)
        {
            Entry_t00field08_02.Unfocus();
            DatePicker_t00field08_02.Focus();
        }

        private void DatePicker_t00field08_02_Unfocused(object sender, DateChangedEventArgs e)
        {
            Erfassungsbogen.t00field08_02 = DatePicker_t00field08_02.Date.ToString("dd.MM.yyyy");
            Entry_t00field08_02.Text = DatePicker_t00field08_02.Date.ToString("dd.MM.yyyy");
        }

        private void DatePicker_t00field08_02_DateSelected(object sender, DateChangedEventArgs e)
        {
            Erfassungsbogen.t00field08_02 = DatePicker_t00field08_02.Date.ToString("dd.MM.yyyy");
            Entry_t00field08_02.Text = DatePicker_t00field08_02.Date.ToString("dd.MM.yyyy");
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