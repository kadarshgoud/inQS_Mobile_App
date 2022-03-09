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
using System.Threading.Tasks;
using System.Threading;

namespace App6
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Bewaeltigung_1 : ContentPage, INotifyPropertyChanged
    {
        public bool InitialDataIsEmpty;
        
        public Bewaeltigung_1()
        {
            InitializeComponent();
            BindingContext = this;

            BogenLabel.Text = AppResources.SurveyHeadline + " " + DBManagement.getYearCode(App.user.selected_mstr_ebqe) + " " + AppResources.SurveyHeadlineFor + " " + Erfassungsbogen.Bewohnerbezeichnung;

            t05Picker01.Items.Add("entfällt");
            t05Picker01.Items.Add("selbständig");
            t05Picker01.Items.Add("pro Tag");
            t05Picker01.Items.Add("pro Woche");
            t05Picker01.Items.Add("pro Monat");

            t05Picker02.Items.Add("entfällt");
            t05Picker02.Items.Add("selbständig");
            t05Picker02.Items.Add("pro Tag");
            t05Picker02.Items.Add("pro Woche");
            t05Picker02.Items.Add("pro Monat");

            t05Picker03.Items.Add("entfällt");
            t05Picker03.Items.Add("selbständig");
            t05Picker03.Items.Add("pro Tag");
            t05Picker03.Items.Add("pro Woche");
            t05Picker03.Items.Add("pro Monat");
        }


        //Before page gets loaded this opertion is performed
        protected override async void OnAppearing()
        {
            base.OnAppearing();

            try
            {
                //ActivityIndicator = Loading...
                IsLoading = true;

                //WebRequest req = WebRequest.Create(DBManagement.DBConnection + "tbl_form_ebqe_t05_01_read.php");

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

                //Erfassungsbogen.t05field01_03 = split[0];
                //Erfassungsbogen.t05field01_02 = split[1];
                //Erfassungsbogen.t05field02_03 = split[2];
                //Erfassungsbogen.t05field02_02 = split[3];
                //Erfassungsbogen.t05field03_03 = split[4];
                //Erfassungsbogen.t05field03_02 = split[5];

                // first picker 5.1

                if (Erfassungsbogen.t05field01_03 == "e")
                {
                    t05Picker01.SelectedIndex = 0;

                    t05field01_2.Opacity = AppManager.QuestionDisabledOpacity;
                    t05Entry01.Opacity = AppManager.AnswerDisabledOpacity;
                    t05field01_2.IsEnabled = false;

                    t05Entry01.IsEnabled = false;
                    t05Entry01.Text = "";
                }
                else if (Erfassungsbogen.t05field01_03 == "s")
                {
                    t05Picker01.SelectedIndex = 1;

                    t05field01_2.Opacity = AppManager.QuestionDisabledOpacity;
                    t05Entry01.Opacity = AppManager.AnswerDisabledOpacity;
                    t05field01_2.IsEnabled = false;

                    t05Entry01.IsEnabled = false;
                    t05Entry01.Text = "";
                }
                else if (Erfassungsbogen.t05field01_03 == "1")
                {
                    t05Picker01.SelectedIndex = 2;
                }
                else if (Erfassungsbogen.t05field01_03 == "7")
                {
                    t05Picker01.SelectedIndex = 3;
                }
                else if (Erfassungsbogen.t05field01_03 == "30")
                {
                    t05Picker01.SelectedIndex = 4;
                }
                else
                {
                    t05Picker01.SelectedIndex = -1;
                }

                // number
                t05Entry01.Text = Erfassungsbogen.t05field01_02;

                //  picker 5.2

                if (Erfassungsbogen.t05field02_03 == "e")
                {
                    t05Picker02.SelectedIndex = 0;

                    t05field02_2.Opacity = AppManager.QuestionDisabledOpacity;
                    t05Entry02.Opacity = AppManager.AnswerDisabledOpacity;
                    t05field02_2.IsEnabled = false;
                    t05Entry02.IsEnabled = false;
                    t05Entry02.Text = "";
                }
                else if (Erfassungsbogen.t05field02_03 == "s")
                {
                    t05Picker02.SelectedIndex = 1;

                    t05field02_2.Opacity = AppManager.QuestionDisabledOpacity;
                    t05Entry02.Opacity = AppManager.AnswerDisabledOpacity;
                    t05field02_2.IsEnabled = false;
                    t05Entry02.IsEnabled = false;
                    t05Entry02.Text = "";
                }
                else if (Erfassungsbogen.t05field02_03 == "1")
                {
                    t05Picker02.SelectedIndex = 2;
                }
                else if (Erfassungsbogen.t05field02_03 == "7")
                {
                    t05Picker02.SelectedIndex = 3;
                }
                else if (Erfassungsbogen.t05field02_03 == "30")
                {
                    t05Picker02.SelectedIndex = 4;
                }
                else
                {
                    t05Picker02.SelectedIndex = -1;
                }

                // number 5.2
                t05Entry02.Text = Erfassungsbogen.t05field02_02;

                // picker 5.3


                if (Erfassungsbogen.t05field03_03 == "e")
                {
                    t05Picker03.SelectedIndex = 0; // rb1 is the image file with checked box image

                    t05field03_2.Opacity = AppManager.QuestionDisabledOpacity;
                    t05Entry03.Opacity = AppManager.AnswerDisabledOpacity;
                    t05field03_2.IsEnabled = false;
                    t05Entry03.IsEnabled = false;
                    t05Entry03.Text = "";
                }
                else if (Erfassungsbogen.t05field03_03 == "s")
                {
                    t05Picker03.SelectedIndex = 1;

                    t05field03_2.Opacity = AppManager.QuestionDisabledOpacity;
                    t05Entry03.Opacity = AppManager.AnswerDisabledOpacity;
                    t05field03_2.IsEnabled = false;
                    t05Entry03.IsEnabled = false;
                    t05Entry03.Text = "";
                }
                else if (Erfassungsbogen.t05field03_03 == "1")
                {
                    t05Picker03.SelectedIndex = 2;
                }
                else if (Erfassungsbogen.t05field03_03 == "7")
                {
                    t05Picker03.SelectedIndex = 3;
                }
                else if (Erfassungsbogen.t05field03_03 == "30")
                {
                    t05Picker03.SelectedIndex = 4;
                }
                else
                {
                    t05Picker03.SelectedIndex = -1;
                }

                // number 5.3
                t05Entry03.Text = Erfassungsbogen.t05field03_02;


                //alle Häufigkeiten ausblenden falls nicht ausgefüllt
                if (Erfassungsbogen.t05field01_03 == "" | Erfassungsbogen.t05field01_03 == null)
                {
                    t05field01_2.Opacity = AppManager.QuestionDisabledOpacity;
                    t05Entry01.Opacity = AppManager.AnswerDisabledOpacity;
                }
                if (Erfassungsbogen.t05field02_03 == "" | Erfassungsbogen.t05field02_03 == null)
                {
                    t05field02_2.Opacity = AppManager.QuestionDisabledOpacity;
                    t05Entry02.Opacity = AppManager.AnswerDisabledOpacity;
                }

                if (Erfassungsbogen.t05field03_03 == "" | Erfassungsbogen.t05field03_03 == null)
                {
                    t05field03_2.Opacity = AppManager.QuestionDisabledOpacity;
                    t05Entry03.Opacity = AppManager.AnswerDisabledOpacity;
                }
                if (Erfassungsbogen.t05field03_03 == "e" && Erfassungsbogen.t05field03_03 == "s")
                {

                }
                //ActivityIndicator = Idle
                IsLoading = false;

            }
            catch (Exception)
            {

                await DisplayAlert(AppResources.AppError, AppResources.AppErrorMsg, "OK");

            }
        }

        private void T05Picker01_SelectedIndexChanged(object sender, EventArgs e)
        {
            // picker T05 01_03 --- T05 01_02 textbox
            if (t05Picker01.SelectedIndex == 0)
            {
                Erfassungsbogen.t05field01_03 = "e";

                t05field01_2.Opacity = AppManager.QuestionDisabledOpacity;
                t05Entry01.Opacity = AppManager.AnswerDisabledOpacity;
                t05field01_2.IsEnabled = false;
                t05Entry01.IsEnabled = false;
               
            }
            else if (t05Picker01.SelectedIndex == 1)
            {
                Erfassungsbogen.t05field01_03 = "s";

                t05field01_2.Opacity = AppManager.QuestionDisabledOpacity;
                t05Entry01.Opacity = AppManager.AnswerDisabledOpacity;
                t05field01_2.IsEnabled = false;
                t05Entry01.IsEnabled = false;
                
            }
            else if (t05Picker01.SelectedIndex == 2)
            {
                t05field01_2.IsEnabled =
                t05Entry01.IsEnabled = true;
                Erfassungsbogen.t05field01_03 = "1";
            }
            else if (t05Picker01.SelectedIndex == 3)
            {
                t05field01_2.IsEnabled =
                t05Entry01.IsEnabled = true;
                Erfassungsbogen.t05field01_03 = "7";
            }
            else if (t05Picker01.SelectedIndex == 4)
            {
                t05field01_2.IsEnabled =
                t05Entry01.IsEnabled = true;
                Erfassungsbogen.t05field01_03 = "30";
            }

            if (t05Picker01.SelectedIndex != 0 && t05Picker01.SelectedIndex != 1)
            {
                t05field01_2.Opacity = AppManager.QuestionOpacity;
                t05Entry01.Opacity = AppManager.AnswerOpacity;
                t05field01_2.IsEnabled =
                t05Entry01.IsEnabled = true;
            }
        }

        private void T05Picker02_SelectedIndexChanged(object sender, EventArgs e)
        {
            // T05 02_03 picker

            if (t05Picker02.SelectedIndex == 0)
            {
                Erfassungsbogen.t05field02_03 = "e";

                t05field02_2.Opacity = AppManager.QuestionDisabledOpacity;
                t05Entry02.Opacity = AppManager.AnswerDisabledOpacity;
                t05field02_2.IsEnabled = false;
                t05Entry02.IsEnabled = false;
                
            }
            else if (t05Picker02.SelectedIndex == 1)
            {
                Erfassungsbogen.t05field02_03 = "s";

                t05field02_2.Opacity = AppManager.QuestionDisabledOpacity;
                t05Entry02.Opacity = AppManager.AnswerDisabledOpacity;
                t05field02_2.IsEnabled = false;
                t05Entry02.IsEnabled = false;
             
            }
            else if (t05Picker02.SelectedIndex == 2)
            {
                Erfassungsbogen.t05field02_03 = "1";
            }
            else if (t05Picker02.SelectedIndex == 3)
            {
                Erfassungsbogen.t05field02_03 = "7";
            }
            else if (t05Picker02.SelectedIndex == 4)
            {
                Erfassungsbogen.t05field02_03 = "30";
            }

            if (t05Picker02.SelectedIndex != 0 && t05Picker02.SelectedIndex != 1)
            {
                t05field02_2.Opacity = AppManager.QuestionOpacity;
                t05Entry02.Opacity = AppManager.AnswerOpacity;
                t05field02_2.IsEnabled = 
                t05Entry02.IsEnabled = true;
            }
        }

        private void T05Picker03_SelectedIndexChanged(object sender, EventArgs e)
        {
            //T04 03

            if (t05Picker03.SelectedIndex == 0)
            {
                Erfassungsbogen.t05field03_03 = "e";

                t05field03_2.Opacity = AppManager.QuestionDisabledOpacity;
                t05Entry03.Opacity = AppManager.AnswerDisabledOpacity;
                t05field03_2.IsEnabled = false;
                t05Entry03.IsEnabled = false;
               
            }
            else if (t05Picker03.SelectedIndex == 1)
            {
                Erfassungsbogen.t05field03_03 = "s";

                t05field03_2.Opacity = AppManager.QuestionDisabledOpacity;
                t05Entry03.Opacity = AppManager.AnswerDisabledOpacity;
                t05field03_2.IsEnabled = false;
                t05Entry03.IsEnabled = false;
                
            }
            else if (t05Picker03.SelectedIndex == 2)
            {
                Erfassungsbogen.t05field03_03 = "1";
            }
            else if (t05Picker03.SelectedIndex == 3)
            {
                Erfassungsbogen.t05field03_03 = "7";
            }
            else if (t05Picker03.SelectedIndex == 4)
            {
                Erfassungsbogen.t05field03_03 = "30";
            }

            if (t05Picker03.SelectedIndex != 0 && t05Picker03.SelectedIndex != 1)
            {
                t05field03_2.Opacity = AppManager.QuestionOpacity;
                t05Entry03.Opacity = AppManager.AnswerOpacity;
                t05field03_2.IsEnabled = true;
                t05Entry03.IsEnabled = true;
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
                        //Set Text Entry Values in Erfassungsbogen
                        Erfassungsbogen.t05field01_02 = t05Entry01.Text;
                        Erfassungsbogen.t05field02_02 = t05Entry02.Text;
                        Erfassungsbogen.t05field03_02 = t05Entry03.Text;

                        t05field01_1.TextColor = t05field01_2.TextColor = t05field02_1.TextColor = t05field02_2.TextColor = t05field03_1.TextColor = t05field03_2.TextColor = AppManager.QuestionColor;

                        if ((Erfassungsbogen.t05field01_03 != "" && Erfassungsbogen.t05field01_03 != null) && (Erfassungsbogen.t05field02_03 != "" && Erfassungsbogen.t05field02_03 != null) && (Erfassungsbogen.t05field03_03 != "" && Erfassungsbogen.t05field03_03 != null))
                        {
                            bool h1 = true;
                            bool h2 = true;
                            bool h3 = true;

                            if (Erfassungsbogen.t05field01_03 != "e" && Erfassungsbogen.t05field01_03 != "s")
                            {
                                if (t05Entry01.Text == "" | t05Entry01.Text == null)
                                {
                                    t05field01_2.TextColor = Color.Red;
                                    h1 = false;
                                }
                            }
                            if (Erfassungsbogen.t05field01_03 == "e" || Erfassungsbogen.t05field01_03 == "s")
                            {
                                t05field01_2.IsEnabled = false;
                                t05Entry01.IsEnabled = false;
                                t05Entry01.Text = "";
                                h1 = true;
                            }
                            if (Erfassungsbogen.t05field02_03 != "e" && Erfassungsbogen.t05field02_03 != "s")
                            {
                                if (t05Entry02.Text == "" | t05Entry02.Text == null)
                                {
                                    t05field02_2.TextColor = Color.Red;
                                    h2 = false;
                                }
                            }
                            if (Erfassungsbogen.t05field02_03 == "e" && Erfassungsbogen.t05field02_03 == "s")
                            {
                                t05field02_2.IsEnabled = false;
                                t05Entry02.IsEnabled = false;
                                t05Entry02.Text = "";
                                h2 = true;
                            }
                            if (Erfassungsbogen.t05field03_03 != "e" && Erfassungsbogen.t05field03_03 != "s")
                            {
                                if (t05Entry03.Text == "" | t05Entry03.Text == null)
                                {
                                    t05field03_2.TextColor = Color.Red;
                                    h3 = false;
                                }
                            }
                            if (Erfassungsbogen.t05field03_03 == "e" && Erfassungsbogen.t05field03_03 == "s")
                            {
                                t05field03_2.IsEnabled = false;
                                t05Entry03.IsEnabled = false;
                                t05Entry03.Text = "";
                                h3 = true;
                            }

                            if (h1 && h2 && h3)
                            {
                                WebRequest req = WebRequest.Create(DBManagement.DBConnection + "tbl_form_ebqe_t05_01_update.php");

                                req.Method = "POST"; //POST
                                req.Timeout = 15000;
                                req.ContentType = "application/x-www-form-urlencoded";

                                string postData = "mstr=" + App.user.selected_mstr_ebqe + "&bewonerid=" + App.user.selected_id_bewohner + "&t05field01_03=" + Erfassungsbogen.t05field01_03 + "&t05field01_02=" + t05Entry01.Text + "&t05field02_03=" + Erfassungsbogen.t05field02_03 + "&t05field02_02=" + t05Entry02.Text + "&t05field03_03=" + Erfassungsbogen.t05field03_03 + "&t05field03_02=" + t05Entry03.Text;

                                byte[] byteArray = Encoding.UTF8.GetBytes(postData);

                                req.ContentLength = byteArray.Length;

                                Stream ds = await req.GetRequestStreamAsync();
                                await ds.WriteAsync(byteArray, 0, byteArray.Length);
                                ds.Close();

                                await Navigation.PushAsync(new SearchPage());
                            }
                        }
                        else
                        {
                            if (Erfassungsbogen.t05field01_03 == "" || Erfassungsbogen.t05field01_03 == null)
                            {
                                t05field01_1.TextColor = Color.Red;
                            }
                            if (Erfassungsbogen.t05field02_03 == "" || Erfassungsbogen.t05field02_03 == null)
                            {
                                t05field02_1.TextColor = Color.Red;
                            }
                            if (Erfassungsbogen.t05field03_03 == "" || Erfassungsbogen.t05field03_03 == null)
                            {
                                t05field03_1.TextColor = Color.Red;
                            }

                            await DisplayAlert(AppResources.Warning, AppResources.FieldsUnfilled, "OK");
                            BackButton.Source = "ic_arrow_back_ios.png";
                        }
                    }
                    else
                    {
                        Erfassungsbogen.t05field01_03 = Erfassungsbogen.t05field01_02 = Erfassungsbogen.t05field02_03 = Erfassungsbogen.t05field02_02 = Erfassungsbogen.t05field03_03 = Erfassungsbogen.t05field03_02 = "";
                        t05Entry01.Text = t05Entry02.Text = t05Entry03.Text = "";

                        WebRequest req = WebRequest.Create(DBManagement.DBConnection + "tbl_form_ebqe_t05_01_update.php");

                        req.Method = "POST"; //POST
                        req.Timeout = 15000;
                        req.ContentType = "application/x-www-form-urlencoded";

                        string postData = "mstr=" + App.user.selected_mstr_ebqe + "&bewonerid=" + App.user.selected_id_bewohner + "&t05field01_03=" + Erfassungsbogen.t05field01_03 + "&t05field01_02=" + t05Entry01.Text + "&t05field02_03=" + Erfassungsbogen.t05field02_03 + "&t05field02_02=" + t05Entry02.Text + "&t05field03_03=" + Erfassungsbogen.t05field03_03 + "&t05field03_02=" + t05Entry03.Text;

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
                    await Navigation.PushAsync(new Bewaeltigung_2());
                }
                else
                {
                    //Set Text Entry Values in Erfassungsbogen
                    Erfassungsbogen.t05field01_02 = t05Entry01.Text;
                    Erfassungsbogen.t05field02_02 = t05Entry02.Text;
                    Erfassungsbogen.t05field03_02 = t05Entry03.Text;

                    t05field01_1.TextColor = t05field01_2.TextColor = t05field02_1.TextColor = t05field02_2.TextColor = t05field03_1.TextColor = t05field03_2.TextColor = AppManager.QuestionColor;

                    if ((Erfassungsbogen.t05field01_03 != "" && Erfassungsbogen.t05field01_03 != null) && (Erfassungsbogen.t05field02_03 != "" && Erfassungsbogen.t05field02_03 != null) && (Erfassungsbogen.t05field03_03 != "" && Erfassungsbogen.t05field03_03 != null))
                    {
                        bool h1 = true;
                        bool h2 = true;
                        bool h3 = true;

                        if (Erfassungsbogen.t05field01_03 != "e" && Erfassungsbogen.t05field01_03 != "s")
                        {
                            if (t05Entry01.Text == "" | t05Entry01.Text == null)
                            {
                                t05field01_2.TextColor = Color.Red;
                                h1 = false;
                            }
                        }
                        if(Erfassungsbogen.t05field01_03 == "e" || Erfassungsbogen.t05field01_03 == "s")
                        {
                            t05field01_2.IsEnabled = false;
                            t05Entry01.IsEnabled = false;
                            t05Entry01.Text = "";
                            h1 = true;
                        }
                        if (Erfassungsbogen.t05field02_03 != "e" && Erfassungsbogen.t05field02_03 != "s")
                        {
                            if (t05Entry02.Text == "" | t05Entry02.Text == null)
                            {
                                t05field02_2.TextColor = Color.Red;
                                h2 = false;
                            }
                        }
                        if (Erfassungsbogen.t05field02_03 == "e" || Erfassungsbogen.t05field02_03 == "s")
                        {
                            t05field02_2.IsEnabled = false;
                            t05Entry02.IsEnabled = false;
                            t05Entry02.Text = "";
                            h2 = true;
                        }

                       if (Erfassungsbogen.t05field03_03 != "e" && Erfassungsbogen.t05field03_03 != "s")
                        {
                            if (t05Entry03.Text == "" | t05Entry03.Text == null)
                            {
                                t05field03_2.TextColor = Color.Red;
                                h3 = false;
                            }
                        }
                        if (Erfassungsbogen.t05field03_03 == "e" || Erfassungsbogen.t05field03_03 == "s")
                        {
                            t05field03_2.IsEnabled = false;
                            t05Entry03.IsEnabled = false;
                            t05Entry03.Text = "";
                            h3 = true;
                        }


                            if (h1 && h2 && h3)
                        {
                            WebRequest req = WebRequest.Create(DBManagement.DBConnection + "tbl_form_ebqe_t05_01_update.php");

                            req.Method = "POST"; //POST
                            req.Timeout = 15000;
                            req.ContentType = "application/x-www-form-urlencoded";

                            string postData = "mstr=" + App.user.selected_mstr_ebqe + "&bewonerid=" + App.user.selected_id_bewohner + "&t05field01_03=" + Erfassungsbogen.t05field01_03 + "&t05field01_02=" + t05Entry01.Text +
                                "&t05field02_03=" + Erfassungsbogen.t05field02_03 + "&t05field02_02=" + t05Entry02.Text + "&t05field03_03=" + Erfassungsbogen.t05field03_03 + "&t05field03_02=" + t05Entry03.Text;

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
                        if (Erfassungsbogen.t05field01_03 == "" || Erfassungsbogen.t05field01_03 == null)
                        {
                            t05field01_1.TextColor = Color.Red;
                        }
                        if (Erfassungsbogen.t05field02_03 == "" || Erfassungsbogen.t05field02_03 == null)
                        {
                            t05field02_1.TextColor = Color.Red;
                        }
                        if (Erfassungsbogen.t05field03_03 == "" || Erfassungsbogen.t05field03_03 == null)
                        {
                            t05field03_1.TextColor = Color.Red;
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