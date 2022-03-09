using App6.Model;
using System;
using System.IO;
using System.Net;
using System.Text;
using App6.Management;
using Xamarin.Forms;
using System.ComponentModel;
using Xamarin.Forms.Xaml;
using App6.Resources;

namespace App6
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Bewaeltigung_3 : ContentPage, INotifyPropertyChanged
    {
        public bool InitialDataIsEmpty;

        public Bewaeltigung_3()
        {
            InitializeComponent();
            BindingContext = this;

            BogenLabel.Text = AppResources.SurveyHeadline + " " + DBManagement.getYearCode(App.user.selected_mstr_ebqe) + " " + AppResources.SurveyHeadlineFor + " " + Erfassungsbogen.Bewohnerbezeichnung;

            t05Picker07.Items.Add("entfällt");
            t05Picker07.Items.Add("selbständig");
            t05Picker07.Items.Add("pro Tag");
            t05Picker07.Items.Add("pro Woche");
            t05Picker07.Items.Add("pro Monat");

            t05Picker08.Items.Add("entfällt");
            t05Picker08.Items.Add("selbständig");
            t05Picker08.Items.Add("pro Tag");
            t05Picker08.Items.Add("pro Woche");
            t05Picker08.Items.Add("pro Monat");

            t05Picker09.Items.Add("entfällt");
            t05Picker09.Items.Add("selbständig");
            t05Picker09.Items.Add("pro Tag");
            t05Picker09.Items.Add("pro Woche");
            t05Picker09.Items.Add("pro Monat");
        }

        //Before page gets loaded this opertion is performed
        protected override async void OnAppearing()
        {
            base.OnAppearing();

            try
            {
                //ActivityIndicator = Loading...
                IsLoading = true;

                //WebRequest req = WebRequest.Create(DBManagement.DBConnection + "tbl_form_ebqe_t05_03_read.php");

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

                //Erfassungsbogen.t05field07_03 = split[0];
                //Erfassungsbogen.t05field07_02 = split[1];
                //Erfassungsbogen.t05field08_03 = split[2];
                //Erfassungsbogen.t05field08_02 = split[3];
                //Erfassungsbogen.t05field09_03 = split[4];
                //Erfassungsbogen.t05field09_02 = split[5];

                // first picker 5.4

                if (Erfassungsbogen.t05field07_03 == "e")
                {
                    t05Picker07.SelectedIndex = 0;

                    t05field07_2.Opacity = AppManager.QuestionDisabledOpacity;
                    t05Entry07.Opacity = AppManager.AnswerDisabledOpacity;
                }
                else if (Erfassungsbogen.t05field07_03 == "s")
                {
                    t05Picker07.SelectedIndex = 1;

                    t05field07_2.Opacity = AppManager.QuestionDisabledOpacity;
                    t05Entry07.Opacity = AppManager.AnswerDisabledOpacity;
                }
                else if (Erfassungsbogen.t05field07_03 == "1")
                {
                    t05Picker07.SelectedIndex = 2;
                }
                else if (Erfassungsbogen.t05field07_03 == "7")
                {
                    t05Picker07.SelectedIndex = 3;
                }
                else if (Erfassungsbogen.t05field07_03 == "30")
                {
                    t05Picker07.SelectedIndex = 4;
                }
                else
                {
                    t05Picker07.SelectedIndex = -1;
                }

                // number
                t05Entry07.Text = Erfassungsbogen.t05field07_02;

                //  picker 5.5

                if (Erfassungsbogen.t05field08_03 == "e")
                {
                    t05Picker08.SelectedIndex = 0;

                    t05field08_2.Opacity = AppManager.QuestionDisabledOpacity;
                    t05Entry08.Opacity = AppManager.AnswerDisabledOpacity;
                }
                else if (Erfassungsbogen.t05field08_03 == "s")
                {
                    t05Picker08.SelectedIndex = 1;

                    t05field08_2.Opacity = AppManager.QuestionDisabledOpacity;
                    t05Entry08.Opacity = AppManager.AnswerDisabledOpacity;
                }
                else if (Erfassungsbogen.t05field08_03 == "1")
                {
                    t05Picker08.SelectedIndex = 2;
                }
                else if (Erfassungsbogen.t05field08_03 == "7")
                {
                    t05Picker08.SelectedIndex = 3;
                }
                else if (Erfassungsbogen.t05field08_03 == "30")
                {
                    t05Picker08.SelectedIndex = 4;
                }
                else
                {
                    t05Picker08.SelectedIndex = -1;
                }

                // number 
                t05Entry08.Text = Erfassungsbogen.t05field08_02;

                // picker 5.6


                if (Erfassungsbogen.t05field09_03 == "e")
                {
                    t05Picker09.SelectedIndex = 0; // rb1 is the image file with checked box image

                    t05field09_2.Opacity = AppManager.QuestionDisabledOpacity;
                    t05Entry09.Opacity = AppManager.AnswerDisabledOpacity;
                }
                else if (Erfassungsbogen.t05field09_03 == "s")
                {
                    t05Picker09.SelectedIndex = 1;

                    t05field09_2.Opacity = AppManager.QuestionDisabledOpacity;
                    t05Entry09.Opacity = AppManager.AnswerDisabledOpacity;
                }
                else if (Erfassungsbogen.t05field09_03 == "1")
                {
                    t05Picker09.SelectedIndex = 2;
                }
                else if (Erfassungsbogen.t05field09_03 == "7")
                {
                    t05Picker09.SelectedIndex = 3;
                }
                else if (Erfassungsbogen.t05field09_03 == "30")
                {
                    t05Picker09.SelectedIndex = 4;
                }
                else
                {
                    t05Picker09.SelectedIndex = -1;
                }

                // number 5.3
                t05Entry09.Text = Erfassungsbogen.t05field09_02;

                //alle Häufigkeiten ausblenden falls nicht ausgefüllt
                if (Erfassungsbogen.t05field07_03 == "" | Erfassungsbogen.t05field07_03 == null)
                {
                    t05field07_2.Opacity = AppManager.QuestionDisabledOpacity;
                    t05Entry07.Opacity = AppManager.AnswerDisabledOpacity;
                }
                if (Erfassungsbogen.t05field07_03 == "e" || Erfassungsbogen.t05field07_03 == "s")
                {
                    t05field07_2.IsEnabled = false;
                    t05Entry07.IsEnabled = false;
                    t05Entry07.Text = "";
                }
                if (Erfassungsbogen.t05field08_03 == "" | Erfassungsbogen.t05field08_03 == null)
                {
                    t05field08_2.Opacity = AppManager.QuestionDisabledOpacity;
                    t05Entry08.Opacity = AppManager.AnswerDisabledOpacity;
                }
                if (Erfassungsbogen.t05field08_03 == "e" || Erfassungsbogen.t05field08_03 == "s")
                {
                    t05field08_2.IsEnabled = false;
                    t05Entry08.IsEnabled = false;
                    t05Entry08.Text = "";
                }
                if (Erfassungsbogen.t05field09_03 == "" | Erfassungsbogen.t05field09_03 == null)
                {
                    t05field09_2.Opacity = AppManager.QuestionDisabledOpacity;
                    t05Entry09.Opacity = AppManager.AnswerDisabledOpacity;
                }
                if (Erfassungsbogen.t05field09_03 == "e" || Erfassungsbogen.t05field09_03 == "s")
                {
                    t05field09_2.IsEnabled = false;
                    t05Entry09.IsEnabled = false;
                    t05Entry09.Text = "";
                }
                //ActivityIndicator = Idle
                IsLoading = false;

            }
            catch (Exception)
            {
                await DisplayAlert(AppResources.AppError, AppResources.AppErrorMsg, "OK");
            }
        }

        private void T05Picker07_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (t05Picker07.SelectedIndex == 0)
            {
                Erfassungsbogen.t05field07_03 = "e";

                t05field07_2.Opacity = AppManager.QuestionDisabledOpacity;
                t05Entry07.Opacity = AppManager.AnswerDisabledOpacity;
                t05field07_2.IsEnabled = false;
                t05Entry07.IsEnabled = false;
            }
            else if (t05Picker07.SelectedIndex == 1)
            {
                Erfassungsbogen.t05field07_03 = "s";

                t05field07_2.Opacity = AppManager.QuestionDisabledOpacity;
                t05Entry07.Opacity = AppManager.AnswerDisabledOpacity;
                t05field07_2.IsEnabled = false;
                t05Entry07.IsEnabled = false;
            }
            else if (t05Picker07.SelectedIndex == 2)
            {
                Erfassungsbogen.t05field07_03 = "1";
            }
            else if (t05Picker07.SelectedIndex == 3)
            {
                Erfassungsbogen.t05field07_03 = "7";
            }
            else if (t05Picker07.SelectedIndex == 4)
            {
                Erfassungsbogen.t05field07_03 = "30";
            }

            if (t05Picker07.SelectedIndex != 0 && t05Picker07.SelectedIndex != 1)
            {
                t05field07_2.Opacity = AppManager.QuestionOpacity;
                t05Entry07.Opacity = AppManager.AnswerOpacity;
                t05field07_2.IsEnabled = 
                t05Entry07.IsEnabled = true;
            }
        }

        private void T05Picker08_SelectedIndexChanged(object sender, EventArgs e)
        {
            // T05 02_03 picker

            if (t05Picker08.SelectedIndex == 0)
            {
                Erfassungsbogen.t05field08_03 = "e";

                t05field08_2.Opacity = AppManager.QuestionDisabledOpacity;
                t05Entry08.Opacity = AppManager.AnswerDisabledOpacity;
                t05field08_2.IsEnabled = false;
                t05Entry08.IsEnabled = false; 
            }
            else if (t05Picker08.SelectedIndex == 1)
            {
                Erfassungsbogen.t05field08_03 = "s";

                t05field08_2.Opacity = AppManager.QuestionDisabledOpacity;
                t05Entry08.Opacity = AppManager.AnswerDisabledOpacity;
                t05field08_2.IsEnabled = false;
                t05Entry08.IsEnabled = false;
            }
            else if (t05Picker08.SelectedIndex == 2)
            {
                Erfassungsbogen.t05field08_03 = "1";
            }
            else if (t05Picker08.SelectedIndex == 3)
            {
                Erfassungsbogen.t05field08_03 = "7";
            }
            else if (t05Picker08.SelectedIndex == 4)
            {
                Erfassungsbogen.t05field08_03 = "30";
            }

            if (t05Picker08.SelectedIndex != 0 && t05Picker08.SelectedIndex != 1)
            {
                t05field08_2.Opacity = AppManager.QuestionOpacity;
                t05Entry08.Opacity = AppManager.AnswerOpacity;
                t05field08_2.IsEnabled = 
                t05Entry08.IsEnabled = true;
            }
        }

        private void T05Picker09_SelectedIndexChanged(object sender, EventArgs e)
        {
            //T04 03

            if (t05Picker09.SelectedIndex == 0)
            {
                Erfassungsbogen.t05field09_03 = "e";

                t05field09_2.Opacity = AppManager.QuestionDisabledOpacity;
                t05Entry09.Opacity = AppManager.AnswerDisabledOpacity;
                t05field09_2.IsEnabled = false;
                t05Entry09.IsEnabled = false;
            }
            else if (t05Picker09.SelectedIndex == 1)
            {
                Erfassungsbogen.t05field09_03 = "s";

                t05field09_2.Opacity = AppManager.QuestionDisabledOpacity;
                t05Entry09.Opacity = AppManager.AnswerDisabledOpacity;
                t05field09_2.IsEnabled = false;
                t05Entry09.IsEnabled = false;
            }
            else if (t05Picker09.SelectedIndex == 2)
            {
                Erfassungsbogen.t05field09_03 = "1";
            }
            else if (t05Picker09.SelectedIndex == 3)
            {
                Erfassungsbogen.t05field09_03 = "7";
            }
            else if (t05Picker09.SelectedIndex == 4)
            {
                Erfassungsbogen.t05field09_03 = "30";
            }

            if (t05Picker09.SelectedIndex != 0 && t05Picker09.SelectedIndex != 1)
            {
                t05field09_2.Opacity = AppManager.QuestionOpacity;
                t05Entry09.Opacity = AppManager.AnswerOpacity;
                t05field09_2.IsEnabled = 
                t05Entry09.IsEnabled = true;
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
                    await Navigation.PushAsync(new Bewaeltigung_2());
                }
                else
                {
                    var BackQuestion = await DisplayAlert(AppResources.Information, AppResources.InformationSaveQuery, AppResources.Yes, AppResources.No);
                    if (BackQuestion == true)
                    {
                        //Set Text Entry Values in Erfassungsbogen
                        Erfassungsbogen.t05field07_02 = t05Entry07.Text;
                        Erfassungsbogen.t05field08_02 = t05Entry08.Text;
                        Erfassungsbogen.t05field09_02 = t05Entry09.Text;

                        t05field07_1.TextColor = t05field07_2.TextColor = t05field08_1.TextColor = t05field08_2.TextColor = t05field09_1.TextColor = t05field09_2.TextColor = AppManager.QuestionColor;

                        if ((Erfassungsbogen.t05field07_03 != "" && Erfassungsbogen.t05field07_03 != null) && (Erfassungsbogen.t05field08_03 != "" && Erfassungsbogen.t05field08_03 != null) && (Erfassungsbogen.t05field09_03 != "" && Erfassungsbogen.t05field09_03 != null))
                        {
                            bool h1 = true;
                            bool h2 = true;
                            bool h3 = true;

                            if (Erfassungsbogen.t05field07_03 != "e" && Erfassungsbogen.t05field07_03 != "s")
                            {
                                if (t05Entry07.Text == "" | t05Entry07.Text == null)
                                {
                                    t05field07_2.TextColor = Color.Red;
                                    h1 = false;
                                }
                            }
                            if (Erfassungsbogen.t05field07_03 == "e" || Erfassungsbogen.t05field07_03 == "s")
                            {
                                t05field07_2.IsEnabled = false;
                                t05Entry07.IsEnabled = false;
                                t05Entry07.Opacity = AppManager.AnswerDisabledOpacity;
                                t05Entry07.Text = "";
                                h1 = true;
                            }
                            if (Erfassungsbogen.t05field08_03 != "e" && Erfassungsbogen.t05field08_03 != "s")
                            {
                                if (t05Entry08.Text == "" | t05Entry08.Text == null)
                                {
                                    t05field08_2.TextColor = Color.Red;
                                    h2 = false;
                                }
                            }
                            if (Erfassungsbogen.t05field08_03 == "e" || Erfassungsbogen.t05field08_03 == "s")
                            {
                                t05field08_2.IsEnabled = false;
                                t05Entry08.IsEnabled = false;
                                t05Entry08.Text = "";
                                h2 = true;
                            }
                            if (Erfassungsbogen.t05field09_03 != "e" && Erfassungsbogen.t05field09_03 != "s")
                            {
                                if (t05Entry09.Text == "" | t05Entry09.Text == null)
                                {
                                    t05field09_2.TextColor = Color.Red;
                                    h3 = false;
                                }
                            }
                            if (Erfassungsbogen.t05field09_03 == "e" || Erfassungsbogen.t05field09_03 == "s")
                            {
                                t05field09_2.IsEnabled = false;
                                t05Entry09.IsEnabled = false;
                                t05Entry09.Text = "";
                                h3 = true;
                            }

                            if (h1 && h2 && h3)
                            {
                                WebRequest req = WebRequest.Create(DBManagement.DBConnection + "tbl_form_ebqe_t05_03_update.php");

                                req.Method = "POST"; //POST
                                req.Timeout = 15000;
                                req.ContentType = "application/x-www-form-urlencoded";

                                string postData = "mstr=" + App.user.selected_mstr_ebqe + "&bewonerid=" + App.user.selected_id_bewohner + "&t05field07_03=" + Erfassungsbogen.t05field07_03 + "&t05field07_02=" + t05Entry07.Text + "&t05field08_03=" + Erfassungsbogen.t05field08_03 + "&t05field08_02=" + t05Entry08.Text + "&t05field09_03=" + Erfassungsbogen.t05field09_03 + "&t05field09_02=" + t05Entry09.Text;

                                byte[] byteArray = Encoding.UTF8.GetBytes(postData);

                                req.ContentLength = byteArray.Length;

                                Stream ds = await req.GetRequestStreamAsync();
                                await ds.WriteAsync(byteArray, 0, byteArray.Length);
                                ds.Close();

                                await Navigation.PushAsync(new Bewaeltigung_2());
                            }
                        }
                        else
                        {
                            if (Erfassungsbogen.t05field07_03 == "" || Erfassungsbogen.t05field07_03 == null)
                            {
                                t05field07_1.TextColor = Color.Red;
                            }
                            if (Erfassungsbogen.t05field08_03 == "" || Erfassungsbogen.t05field08_03 == null)
                            {
                                t05field08_1.TextColor = Color.Red;
                            }
                            if (Erfassungsbogen.t05field09_03 == "" || Erfassungsbogen.t05field09_03 == null)
                            {
                                t05field09_1.TextColor = Color.Red;
                            }

                            await DisplayAlert(AppResources.Warning, AppResources.FieldsUnfilled, "OK");
                            BackButton.Source = "ic_arrow_back_ios.png";
                        }
                    }
                    else
                    {
                        Erfassungsbogen.t05field07_03 = Erfassungsbogen.t05field07_02 = Erfassungsbogen.t05field08_03 = Erfassungsbogen.t05field08_02 = Erfassungsbogen.t05field09_03 = Erfassungsbogen.t05field09_02 = "";
                        t05Entry07.Text = t05Entry08.Text = t05Entry09.Text = "";

                        WebRequest req = WebRequest.Create(DBManagement.DBConnection + "tbl_form_ebqe_t05_03_update.php");

                        req.Method = "POST"; //POST
                        req.Timeout = 15000;
                        req.ContentType = "application/x-www-form-urlencoded";

                        string postData = "mstr=" + App.user.selected_mstr_ebqe + "&bewonerid=" + App.user.selected_id_bewohner + "&t05field07_03=" + Erfassungsbogen.t05field07_03 + "&t05field07_02=" + t05Entry07.Text + "&t05field08_03=" + Erfassungsbogen.t05field08_03 + "&t05field08_02=" + t05Entry08.Text + "&t05field09_03=" + Erfassungsbogen.t05field09_03 + "&t05field09_02=" + t05Entry09.Text;

                        byte[] byteArray = Encoding.UTF8.GetBytes(postData);

                        req.ContentLength = byteArray.Length;

                        Stream ds = await req.GetRequestStreamAsync();
                        await ds.WriteAsync(byteArray, 0, byteArray.Length);
                        ds.Close();

                        await Navigation.PushAsync(new Bewaeltigung_2());
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
                    await Navigation.PushAsync(new Bewaeltigung_4());
                }
                else
                {
                    //Set Text Entry Values in Erfassungsbogen
                    Erfassungsbogen.t05field07_02 = t05Entry07.Text;
                    Erfassungsbogen.t05field08_02 = t05Entry08.Text;
                    Erfassungsbogen.t05field09_02 = t05Entry09.Text;

                    t05field07_1.TextColor = t05field07_2.TextColor = t05field08_1.TextColor = t05field08_2.TextColor = t05field09_1.TextColor = t05field09_2.TextColor = AppManager.QuestionColor;

                    if ((Erfassungsbogen.t05field07_03 != "" && Erfassungsbogen.t05field07_03 != null) && (Erfassungsbogen.t05field08_03 != "" && Erfassungsbogen.t05field08_03 != null) && (Erfassungsbogen.t05field09_03 != "" && Erfassungsbogen.t05field09_03 != null))
                    {
                        bool h1 = true;
                        bool h2 = true;
                        bool h3 = true;

                        if (Erfassungsbogen.t05field07_03 != "e" && Erfassungsbogen.t05field07_03 != "s")
                        {
                            if (t05Entry07.Text == "" | t05Entry07.Text == null)
                            {
                                t05field07_2.TextColor = Color.Red;
                                h1 = false;
                            }
                        }
                        if (Erfassungsbogen.t05field07_03 == "e" || Erfassungsbogen.t05field07_03 == "s")
                        {
                            t05field07_2.IsEnabled = false;
                            t05Entry07.IsEnabled = false;
                            t05Entry07.Opacity = AppManager.AnswerDisabledOpacity;
                            t05Entry07.Text = "";
                            h1 = true;
                        }
                        if (Erfassungsbogen.t05field08_03 != "e" && Erfassungsbogen.t05field08_03 != "s")
                        {
                            if (t05Entry08.Text == "" | t05Entry08.Text == null)
                            {
                                t05field08_2.TextColor = Color.Red;
                                h2 = false;
                            }
                        }
                        if (Erfassungsbogen.t05field08_03 == "e" || Erfassungsbogen.t05field08_03 == "s")
                        {
                            t05field08_2.IsEnabled = false;
                            t05Entry08.IsEnabled = false;
                            t05Entry08.Text = "";
                            h2 = true;
                        }
                        if (Erfassungsbogen.t05field09_03 != "e" && Erfassungsbogen.t05field09_03 != "s")
                        {
                            if (t05Entry09.Text == "" | t05Entry09.Text == null)
                            {
                                t05field09_2.TextColor = Color.Red;
                                h3 = false;
                            }
                        }
                        if (Erfassungsbogen.t05field09_03 == "e" || Erfassungsbogen.t05field09_03 == "s")
                        {
                            t05field09_2.IsEnabled = false;
                            t05Entry09.IsEnabled = false;
                            t05Entry09.Text = "";
                            h3 = true;
                        }

                        if (h1 && h2 && h3)
                        {
                            WebRequest req = WebRequest.Create(DBManagement.DBConnection + "tbl_form_ebqe_t05_03_update.php");

                            req.Method = "POST"; //POST
                            req.Timeout = 15000;
                            req.ContentType = "application/x-www-form-urlencoded";

                            string postData = "mstr=" + App.user.selected_mstr_ebqe + "&bewonerid=" + App.user.selected_id_bewohner + "&t05field07_03=" + Erfassungsbogen.t05field07_03 + "&t05field07_02=" + t05Entry07.Text +
                                "&t05field08_03=" + Erfassungsbogen.t05field08_03 + "&t05field08_02=" + t05Entry08.Text + "&t05field09_03=" + Erfassungsbogen.t05field09_03 + "&t05field09_02=" + t05Entry09.Text;

                            byte[] byteArray = Encoding.UTF8.GetBytes(postData);

                            req.ContentLength = byteArray.Length;

                            Stream ds = await req.GetRequestStreamAsync();
                            await ds.WriteAsync(byteArray, 0, byteArray.Length);
                            ds.Close();

                            await Navigation.PushAsync(new Bewaeltigung_4());
                        }
                    }
                    else
                    {
                        if (Erfassungsbogen.t05field07_03 == "" || Erfassungsbogen.t05field07_03 == null)
                        {
                            t05field07_1.TextColor = Color.Red;
                        }
                        if (Erfassungsbogen.t05field08_03 == "" || Erfassungsbogen.t05field08_03 == null)
                        {
                            t05field08_1.TextColor = Color.Red;
                        }
                        if (Erfassungsbogen.t05field09_03 == "" || Erfassungsbogen.t05field09_03 == null)
                        {
                            t05field09_1.TextColor = Color.Red;
                        }

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