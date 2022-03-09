using App6.Model;
using System;
using System.IO;
using System.Net;
using System.Text;
using System.ComponentModel;
using App6.Management;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using App6.Resources;

namespace App6
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Bewaeltigung_2 : ContentPage, INotifyPropertyChanged
    {
        public bool InitialDataIsEmpty;

        public Bewaeltigung_2()
        {
            InitializeComponent();
            BindingContext = this;

            BogenLabel.Text = AppResources.SurveyHeadline + " " + DBManagement.getYearCode(App.user.selected_mstr_ebqe) + " " + AppResources.SurveyHeadlineFor + " " + Erfassungsbogen.Bewohnerbezeichnung;

            t05Picker04.Items.Add("entfällt");
            t05Picker04.Items.Add("selbständig");
            t05Picker04.Items.Add("pro Tag");
            t05Picker04.Items.Add("pro Woche");
            t05Picker04.Items.Add("pro Monat");

            t05Picker05.Items.Add("entfällt");
            t05Picker05.Items.Add("selbständig");
            t05Picker05.Items.Add("pro Tag");
            t05Picker05.Items.Add("pro Woche");
            t05Picker05.Items.Add("pro Monat");

            t05Picker06.Items.Add("entfällt");
            t05Picker06.Items.Add("selbständig");
            t05Picker06.Items.Add("pro Tag");
            t05Picker06.Items.Add("pro Woche");
            t05Picker06.Items.Add("pro Monat");
        }

        //Before page gets loaded this opertion is performed
        protected override async void OnAppearing()
        {
            base.OnAppearing();

            try
            {
                //ActivityIndicator = Loading...
                IsLoading = true;

                //WebRequest req = WebRequest.Create(DBManagement.DBConnection + "tbl_form_ebqe_t05_02_read.php");

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

                //Erfassungsbogen.t05field04_03 = split[0];
                //Erfassungsbogen.t05field04_02 = split[1];
                //Erfassungsbogen.t05field05_03 = split[2];
                //Erfassungsbogen.t05field05_02 = split[3];
                //Erfassungsbogen.t05field06_03 = split[4];
                //Erfassungsbogen.t05field06_02 = split[5];

                // first picker 5.4

                if (Erfassungsbogen.t05field04_03 == "e")
                {
                    t05Picker04.SelectedIndex = 0;

                    t05field04_2.Opacity = AppManager.QuestionDisabledOpacity;
                    t05Entry04.Opacity = AppManager.AnswerDisabledOpacity;
                    t05field04_2.IsEnabled = false;
                    t05Entry04.IsEnabled = false;
                }
                else if (Erfassungsbogen.t05field04_03 == "s")
                {
                    t05Picker04.SelectedIndex = 1;

                    t05field04_2.Opacity = AppManager.QuestionDisabledOpacity;
                    t05Entry04.Opacity = AppManager.AnswerDisabledOpacity;
                    t05field04_2.IsEnabled = false;
                    t05Entry04.IsEnabled = false;
                }
                else if (Erfassungsbogen.t05field04_03 == "1")
                {
                    t05Picker04.SelectedIndex = 2;
                }
                else if (Erfassungsbogen.t05field04_03 == "7")
                {
                    t05Picker04.SelectedIndex = 3;
                }
                else if (Erfassungsbogen.t05field04_03 == "30")
                {
                    t05Picker04.SelectedIndex = 4;
                }
                else
                {
                    t05Picker04.SelectedIndex = -1;
                }

                // number
                t05Entry04.Text = Erfassungsbogen.t05field04_02;

                //  picker 5.5

                if (Erfassungsbogen.t05field05_03 == "e")
                {
                    t05Picker05.SelectedIndex = 0;

                    t05field05_2.Opacity = AppManager.QuestionDisabledOpacity;
                    t05Entry05.Opacity = AppManager.AnswerDisabledOpacity;
                    t05field05_2.IsEnabled = false;
                    t05Entry05.IsEnabled = false;
                }
                else if (Erfassungsbogen.t05field05_03 == "s")
                {
                    t05Picker05.SelectedIndex = 1;

                    t05field05_2.Opacity = AppManager.QuestionDisabledOpacity;
                    t05Entry05.Opacity = AppManager.AnswerDisabledOpacity;
                    t05field05_2.IsEnabled = false;
                    t05Entry05.IsEnabled = false;

                }
                else if (Erfassungsbogen.t05field05_03 == "1")
                {
                    t05Picker05.SelectedIndex = 2;
                }
                else if (Erfassungsbogen.t05field05_03 == "7")
                {
                    t05Picker05.SelectedIndex = 3;
                }
                else if (Erfassungsbogen.t05field05_03 == "30")
                {
                    t05Picker05.SelectedIndex = 4;
                }
                else
                {
                    t05Picker05.SelectedIndex = -1;
                }

                // number 
                t05Entry05.Text = Erfassungsbogen.t05field05_02;

                // picker 5.6
                if (Erfassungsbogen.t05field06_03 == "e")
                {
                    t05Picker06.SelectedIndex = 0; // rb1 is the image file with checked box image

                    t05field06_2.Opacity = AppManager.QuestionDisabledOpacity;
                    t05Entry06.Opacity = AppManager.AnswerDisabledOpacity;
                    t05field06_2.IsEnabled = false;
                    t05Entry06.IsEnabled = false;
                }
                else if (Erfassungsbogen.t05field06_03 == "s")
                {
                    t05Picker06.SelectedIndex = 1;

                    t05field06_2.Opacity = AppManager.QuestionDisabledOpacity;
                    t05Entry06.Opacity = AppManager.AnswerDisabledOpacity;
                    t05field06_2.IsEnabled = false;
                    t05Entry06.IsEnabled = false;
                }
                else if (Erfassungsbogen.t05field06_03 == "1")
                {
                    t05Picker06.SelectedIndex = 2;
                }
                else if (Erfassungsbogen.t05field06_03 == "7")
                {
                    t05Picker06.SelectedIndex = 3;
                }
                else if (Erfassungsbogen.t05field06_03 == "30")
                {
                    t05Picker06.SelectedIndex = 4;
                }
                else
                {
                    t05Picker06.SelectedIndex = -1;
                }

                // number 5.3
                t05Entry06.Text = Erfassungsbogen.t05field06_02;

                //alle Häufigkeiten ausblenden falls nicht ausgefüllt
                if (Erfassungsbogen.t05field04_03 == "" | Erfassungsbogen.t05field04_03 == null)
                {
                    t05field04_2.Opacity = AppManager.QuestionDisabledOpacity;
                    t05Entry04.Opacity = AppManager.AnswerDisabledOpacity;
                }
               
                if (Erfassungsbogen.t05field05_03 == "" | Erfassungsbogen.t05field05_03 == null)
                {
                    t05field05_2.Opacity = AppManager.QuestionDisabledOpacity;
                    t05Entry05.Opacity = AppManager.AnswerDisabledOpacity;
                }
               
                if (Erfassungsbogen.t05field06_03 == "" | Erfassungsbogen.t05field06_03 == null)
                {
                    t05field06_2.Opacity = AppManager.QuestionDisabledOpacity;
                    t05Entry06.Opacity = AppManager.AnswerDisabledOpacity;
                }
                //ActivityIndicator = Idle
                IsLoading = false;

            }
            catch (Exception)
            {
                await DisplayAlert(AppResources.AppError, AppResources.AppErrorMsg, "OK");
            }
        }

        private void T05Picker04_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (t05Picker04.SelectedIndex == 0)
            {
                Erfassungsbogen.t05field04_03 = "e";

                t05field04_2.Opacity = AppManager.QuestionDisabledOpacity;
                t05Entry04.Opacity = AppManager.AnswerDisabledOpacity;
                t05field04_2.IsEnabled = false;
                t05Entry04.IsEnabled = false;
                
            }
            else if (t05Picker04.SelectedIndex == 1)
            {
                Erfassungsbogen.t05field04_03 = "s";

                t05field04_2.Opacity = AppManager.QuestionDisabledOpacity;
                t05Entry04.Opacity = AppManager.AnswerDisabledOpacity;
                t05field04_2.IsEnabled = false;
                t05Entry04.IsEnabled = false;
               
            }
            else if (t05Picker04.SelectedIndex == 2)
            {
                Erfassungsbogen.t05field04_03 = "1";
            }
            else if (t05Picker04.SelectedIndex == 3)
            {
                Erfassungsbogen.t05field04_03 = "7";
            }
            else if (t05Picker04.SelectedIndex == 4)
            {
                Erfassungsbogen.t05field04_03 = "30";
            }

            if (t05Picker04.SelectedIndex != 0 && t05Picker04.SelectedIndex != 1)
            {
                t05field04_2.Opacity = AppManager.QuestionOpacity;
                t05Entry04.Opacity = AppManager.AnswerOpacity;
                t05field04_2.IsEnabled = true;
                t05Entry04.IsEnabled = true;
            }
        }

        private void T05Picker05_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (t05Picker05.SelectedIndex == 0)
            {
                Erfassungsbogen.t05field05_03 = "e";

                t05field05_2.Opacity = AppManager.QuestionDisabledOpacity;
                t05Entry05.Opacity = AppManager.AnswerDisabledOpacity;
                t05field05_2.IsEnabled = false;
                t05Entry05.IsEnabled = false;
                
            }
            else if (t05Picker05.SelectedIndex == 1)
            {
                Erfassungsbogen.t05field05_03 = "s";

                t05field05_2.Opacity = AppManager.QuestionDisabledOpacity;
                t05Entry05.Opacity = AppManager.AnswerDisabledOpacity;
                t05field05_2.IsEnabled = false;
                t05Entry05.IsEnabled = false;
               
            }
            else if (t05Picker05.SelectedIndex == 2)
            {
                Erfassungsbogen.t05field05_03 = "1";
            }
            else if (t05Picker05.SelectedIndex == 3)
            {
                Erfassungsbogen.t05field05_03 = "7";
            }
            else if (t05Picker05.SelectedIndex == 4)
            {
                Erfassungsbogen.t05field05_03 = "30";
            }

            if (t05Picker05.SelectedIndex != 0 && t05Picker05.SelectedIndex != 1)
            {
                t05field05_2.Opacity = AppManager.QuestionOpacity;
                t05Entry05.Opacity = AppManager.AnswerOpacity;
                t05field05_2.IsEnabled =
                t05Entry05.IsEnabled = true;
            }
        }

        private void T05Picker06_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (t05Picker06.SelectedIndex == 0)
            {
                Erfassungsbogen.t05field06_03 = "e";

                t05field06_2.Opacity = AppManager.QuestionDisabledOpacity;
                t05Entry06.Opacity = AppManager.AnswerDisabledOpacity;
                t05field06_2.IsEnabled = false;
                t05Entry06.IsEnabled = false;
            }
            else if (t05Picker06.SelectedIndex == 1)
            {
                Erfassungsbogen.t05field06_03 = "s";

                t05field06_2.Opacity = AppManager.QuestionDisabledOpacity;
                t05Entry06.Opacity = AppManager.AnswerDisabledOpacity;
                t05field06_2.IsEnabled = false;
                t05Entry06.IsEnabled = false;
            }
            else if (t05Picker06.SelectedIndex == 2)
            {
                Erfassungsbogen.t05field06_03 = "1";
            }
            else if (t05Picker06.SelectedIndex == 3)
            {
                Erfassungsbogen.t05field06_03 = "7";
            }
            else if (t05Picker06.SelectedIndex == 4)
            {
                Erfassungsbogen.t05field06_03 = "30";
            }

            if (t05Picker06.SelectedIndex != 0 && t05Picker06.SelectedIndex != 1)
            {
                t05field06_2.Opacity = AppManager.QuestionOpacity;
                t05Entry06.Opacity = AppManager.AnswerOpacity;
                t05field06_2.IsEnabled = 
                t05Entry06.IsEnabled = true;
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
                    await Navigation.PushAsync(new Bewaeltigung_1());
                }
                else
                {
                    var BackQuestion = await DisplayAlert(AppResources.Information, AppResources.InformationSaveQuery, AppResources.Yes, AppResources.No);
                    if (BackQuestion == true)
                    {
                        //Set Text Entry Values in Erfassungsbogen
                        Erfassungsbogen.t05field04_02 = t05Entry04.Text;
                        Erfassungsbogen.t05field05_02 = t05Entry05.Text;
                        Erfassungsbogen.t05field06_02 = t05Entry06.Text;

                        t05field04_1.TextColor = t05field04_2.TextColor = t05field05_1.TextColor = t05field05_2.TextColor = t05field06_1.TextColor = t05field06_2.TextColor = AppManager.QuestionColor;

                        if ((Erfassungsbogen.t05field04_03 != "" && Erfassungsbogen.t05field04_03 != null) && (Erfassungsbogen.t05field05_03 != "" && Erfassungsbogen.t05field05_03 != null) && (Erfassungsbogen.t05field06_03 != "" && Erfassungsbogen.t05field06_03 != null))
                        {
                            bool h1 = true;
                            bool h2 = true;
                            bool h3 = true;

                            if (Erfassungsbogen.t05field04_03 != "e" && Erfassungsbogen.t05field04_03 != "s")
                            {
                                if (t05Entry04.Text == "" | t05Entry04.Text == null)
                                {
                                    t05field04_2.TextColor = Color.Red;
                                    h1 = false;
                                }
                            }
                            if (Erfassungsbogen.t05field04_03 == "e" || Erfassungsbogen.t05field04_03 == "s")
                            {
                                t05field04_2.IsEnabled = false;
                                t05Entry04.IsEnabled = false;
                                t05Entry04.Opacity = AppManager.AnswerDisabledOpacity;
                                t05Entry04.Text = "";
                                h1 = true;
                            }
                            if (Erfassungsbogen.t05field05_03 != "e" && Erfassungsbogen.t05field05_03 != "s")
                            {
                                if (t05Entry05.Text == "" | t05Entry05.Text == null)
                                {
                                    t05field05_2.TextColor = Color.Red;
                                    h2 = false;
                                }
                            }
                            if (Erfassungsbogen.t05field05_03 == "e" || Erfassungsbogen.t05field05_03 == "s")
                            {
                                t05field05_2.IsEnabled = false;
                                t05Entry05.IsEnabled = false;
                                t05Entry05.Opacity = AppManager.AnswerDisabledOpacity;
                                t05Entry05.Text = "";
                                h2 = true;
                            }
                            if (Erfassungsbogen.t05field06_03 != "e" && Erfassungsbogen.t05field06_03 != "s")
                            {
                                if (t05Entry06.Text == "" | t05Entry06.Text == null)
                                {
                                    t05field06_2.TextColor = Color.Red;
                                    h3 = false;
                                }
                            }
                            if (Erfassungsbogen.t05field06_03 == "e" || Erfassungsbogen.t05field06_03 == "s")
                            {
                                t05field06_2.IsEnabled = false;
                                t05Entry06.IsEnabled = false;
                                t05Entry06.Opacity = AppManager.AnswerDisabledOpacity;
                                t05Entry06.Text = "";
                                h3 = true;
                            }

                            if (h1 && h2 && h3)
                            {
                                WebRequest req = WebRequest.Create(DBManagement.DBConnection + "tbl_form_ebqe_t05_02_update.php");

                                req.Method = "POST"; //POST
                                req.Timeout = 15000;
                                req.ContentType = "application/x-www-form-urlencoded";

                                string postData = "mstr=" + App.user.selected_mstr_ebqe + "&bewonerid=" + App.user.selected_id_bewohner + "&t05field04_03=" + Erfassungsbogen.t05field04_03 + "&t05field04_02=" + t05Entry04.Text + "&t05field05_03=" + Erfassungsbogen.t05field05_03 + "&t05field05_02=" + t05Entry05.Text + "&t05field06_03=" + Erfassungsbogen.t05field06_03 + "&t05field06_02=" + t05Entry06.Text;

                                byte[] byteArray = Encoding.UTF8.GetBytes(postData);

                                req.ContentLength = byteArray.Length;

                                Stream ds = await req.GetRequestStreamAsync();
                                await ds.WriteAsync(byteArray, 0, byteArray.Length);
                                ds.Close();

                                await Navigation.PushAsync(new Bewaeltigung_1());
                            }
                        }
                        else
                        {
                            if (Erfassungsbogen.t05field04_03 == "" || Erfassungsbogen.t05field04_03 == null)
                            {
                                t05field04_1.TextColor = Color.Red;
                            }
                            if (Erfassungsbogen.t05field05_03 == "" || Erfassungsbogen.t05field05_03 == null)
                            {
                                t05field05_1.TextColor = Color.Red;
                            }
                            if (Erfassungsbogen.t05field06_03 == "" || Erfassungsbogen.t05field06_03 == null)
                            {
                                t05field06_1.TextColor = Color.Red;
                            }

                            await DisplayAlert(AppResources.Warning, AppResources.FieldsUnfilled, "OK");
                            BackButton.Source = "ic_arrow_back_ios.png";
                        }
                    }
                    else
                    {
                        Erfassungsbogen.t05field04_03 = Erfassungsbogen.t05field04_02 = Erfassungsbogen.t05field05_03 = Erfassungsbogen.t05field05_02 = Erfassungsbogen.t05field06_03 = Erfassungsbogen.t05field06_02 = "";
                        t05Entry04.Text = t05Entry05.Text = t05Entry06.Text = "";

                        WebRequest req = WebRequest.Create(DBManagement.DBConnection + "tbl_form_ebqe_t05_02_update.php");

                        req.Method = "POST"; //POST
                        req.Timeout = 15000;
                        req.ContentType = "application/x-www-form-urlencoded";

                        string postData = "mstr=" + App.user.selected_mstr_ebqe + "&bewonerid=" + App.user.selected_id_bewohner + "&t05field04_03=" + Erfassungsbogen.t05field04_03 + "&t05field04_02=" + t05Entry04.Text + "&t05field05_03=" + Erfassungsbogen.t05field05_03 + "&t05field05_02=" + t05Entry05.Text + "&t05field06_03=" + Erfassungsbogen.t05field06_03 + "&t05field06_02=" + t05Entry06.Text;

                        byte[] byteArray = Encoding.UTF8.GetBytes(postData);

                        req.ContentLength = byteArray.Length;

                        Stream ds = await req.GetRequestStreamAsync();
                        await ds.WriteAsync(byteArray, 0, byteArray.Length);
                        ds.Close();

                        await Navigation.PushAsync(new Bewaeltigung_1());
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
                    await Navigation.PushAsync(new Bewaeltigung_3());
                }
                else
                {
                    //Set Text Entry Values in Erfassungsbogen
                    Erfassungsbogen.t05field04_02 = t05Entry04.Text;
                    Erfassungsbogen.t05field05_02 = t05Entry05.Text;
                    Erfassungsbogen.t05field06_02 = t05Entry06.Text;

                    t05field04_1.TextColor = t05field04_2.TextColor = t05field05_1.TextColor = t05field05_2.TextColor = t05field06_1.TextColor = t05field06_2.TextColor = AppManager.QuestionColor;

                    if ((Erfassungsbogen.t05field04_03 != "" && Erfassungsbogen.t05field04_03 != null) && (Erfassungsbogen.t05field05_03 != "" && Erfassungsbogen.t05field05_03 != null) && (Erfassungsbogen.t05field06_03 != "" && Erfassungsbogen.t05field06_03 != null))
                    {
                        bool h1 = true;
                        bool h2 = true;
                        bool h3 = true;

                        if (Erfassungsbogen.t05field04_03 != "e" && Erfassungsbogen.t05field04_03 != "s")
                        {
                            if (t05Entry04.Text == "" | t05Entry04.Text == null)
                            {
                                t05field04_2.TextColor = Color.Red;
                                h1 = false;
                            }
                        }
                        if (Erfassungsbogen.t05field04_03 == "e" || Erfassungsbogen.t05field04_03 == "s")
                        {
                            t05field04_2.IsEnabled = false;
                            t05Entry04.IsEnabled = false;
                            t05Entry04.Opacity = AppManager.AnswerDisabledOpacity;
                            t05Entry04.Text = "";
                            h1 = true;
                        }
                        if (Erfassungsbogen.t05field05_03 != "e" && Erfassungsbogen.t05field05_03 != "s")
                        {
                            if (t05Entry05.Text == "" | t05Entry05.Text == null)
                            {
                                t05field05_2.TextColor = Color.Red;
                                h2 = false;
                            }
                        }
                        if (Erfassungsbogen.t05field05_03 == "e" || Erfassungsbogen.t05field05_03 == "s")
                        {
                            t05field05_2.IsEnabled = false;
                            t05Entry05.IsEnabled = false;
                            t05Entry05.Opacity = AppManager.AnswerDisabledOpacity;
                            t05Entry05.Text = "";
                            h2 = true;
                        }
                        if (Erfassungsbogen.t05field06_03 != "e" && Erfassungsbogen.t05field06_03 != "s")
                        {
                            if (t05Entry06.Text == "" | t05Entry06.Text == null)
                            {
                                t05field06_2.TextColor = Color.Red;
                                h3 = false;
                            }
                        }
                        if (Erfassungsbogen.t05field06_03 == "e" || Erfassungsbogen.t05field06_03 == "s")
                        {
                            t05field06_2.IsEnabled = false;
                            t05Entry06.IsEnabled = false;
                            t05Entry06.Opacity = AppManager.AnswerDisabledOpacity;
                            t05Entry06.Text = "";
                            h3 = true;
                        }

                        if (h1 && h2 && h3)
                        {
                            WebRequest req = WebRequest.Create(DBManagement.DBConnection + "tbl_form_ebqe_t05_02_update.php");

                            req.Method = "POST"; //POST
                            req.Timeout = 15000;
                            req.ContentType = "application/x-www-form-urlencoded";

                            string postData = "mstr=" + App.user.selected_mstr_ebqe + "&bewonerid=" + App.user.selected_id_bewohner + "&t05field04_03=" + Erfassungsbogen.t05field04_03 + "&t05field04_02=" + t05Entry04.Text +
                                "&t05field05_03=" + Erfassungsbogen.t05field05_03 + "&t05field05_02=" + t05Entry05.Text + "&t05field06_03=" + Erfassungsbogen.t05field06_03 + "&t05field06_02=" + t05Entry06.Text;

                            byte[] byteArray = Encoding.UTF8.GetBytes(postData);

                            req.ContentLength = byteArray.Length;

                            Stream ds = await req.GetRequestStreamAsync();
                            await ds.WriteAsync(byteArray, 0, byteArray.Length);
                            ds.Close();

                            await Navigation.PushAsync(new Bewaeltigung_3());
                        }
                    }
                    else
                    {
                        if (Erfassungsbogen.t05field04_03 == "" || Erfassungsbogen.t05field04_03 == null)
                        {
                            t05field04_1.TextColor = Color.Red;
                        }
                        if (Erfassungsbogen.t05field05_03 == "" || Erfassungsbogen.t05field05_03 == null)
                        {
                            t05field05_1.TextColor = Color.Red;
                        }
                        if (Erfassungsbogen.t05field06_03 == "" || Erfassungsbogen.t05field06_03 == null)
                        {
                            t05field06_1.TextColor = Color.Red;
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