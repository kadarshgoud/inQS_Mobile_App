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
    public partial class Bewaeltigung_5 : ContentPage, INotifyPropertyChanged
    {
        public bool InitialDataIsEmpty;

        public Bewaeltigung_5()
        {
            InitializeComponent();
            BindingContext = this;

            BogenLabel.Text = AppResources.SurveyHeadline + " " + DBManagement.getYearCode(App.user.selected_mstr_ebqe) + " " + AppResources.SurveyHeadlineFor + " " + Erfassungsbogen.Bewohnerbezeichnung;

            t05Picker13.Items.Add("entfällt");
            t05Picker13.Items.Add("selbständig");
            t05Picker13.Items.Add("wöchentlich");
            t05Picker13.Items.Add("monatlich");

            t05Picker14.Items.Add("entfällt");
            t05Picker14.Items.Add("selbständig");
            t05Picker14.Items.Add("wöchentlich");
            t05Picker14.Items.Add("monatlich");

            t05Picker15.Items.Add("entfällt");
            t05Picker15.Items.Add("selbständig");
            t05Picker15.Items.Add("wöchentlich");
            t05Picker15.Items.Add("monatlich");
        }

        //Before page gets loaded this opertion is performed
        protected override async void OnAppearing()
        {
            base.OnAppearing();

            try
            {
                //ActivityIndicator = Loading...
                IsLoading = true;

                //WebRequest req = WebRequest.Create(DBManagement.DBConnection + "tbl_form_ebqe_t05_05_read.php");

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

                //Erfassungsbogen.t05field13_03 = split[0];
                //Erfassungsbogen.t05field13_02 = split[1];
                //Erfassungsbogen.t05field14_03 = split[2];
                //Erfassungsbogen.t05field14_02 = split[3];
                //Erfassungsbogen.t05field15_03 = split[4];
                //Erfassungsbogen.t05field15_02 = split[5];

                // first picker 5.4

                if (Erfassungsbogen.t05field13_03 == "e")
                {
                    t05Picker13.SelectedIndex = 0;

                    t05field13_2.Opacity = AppManager.QuestionDisabledOpacity;
                    t05Entry13.Opacity = AppManager.AnswerDisabledOpacity;
                    t05field13_2.IsEnabled = false;
                    t05Entry13.IsEnabled = false;
                    t05Entry13.Text = "";
                }
                else if (Erfassungsbogen.t05field13_03 == "s")
                {
                    t05Picker13.SelectedIndex = 1;

                    t05field13_2.Opacity = AppManager.QuestionDisabledOpacity;
                    t05Entry13.Opacity = AppManager.AnswerDisabledOpacity;
                    t05field13_2.IsEnabled = false;
                    t05Entry13.IsEnabled = false;
                    t05Entry13.Text = "";
                }
                else if (Erfassungsbogen.t05field13_03 == "4.3")
                {
                    t05Picker13.SelectedIndex = 2;
                }
                else if (Erfassungsbogen.t05field13_03 == "1")
                {
                    t05Picker13.SelectedIndex = 3;
                }
                else
                {
                    t05Picker13.SelectedIndex = -1;
                }

                // number
                t05Entry13.Text = Erfassungsbogen.t05field13_02;

                //  picker 5.5

                if (Erfassungsbogen.t05field14_03 == "e")
                {
                    t05Picker14.SelectedIndex = 0;

                    t05field14_2.Opacity = AppManager.QuestionDisabledOpacity;
                    t05Entry14.Opacity = AppManager.AnswerDisabledOpacity;
                    t05field14_2.IsEnabled = false;
                    t05Entry14.IsEnabled = false;
                    t05Entry14.Text = "";
                }
                else if (Erfassungsbogen.t05field14_03 == "s")
                {
                    t05Picker14.SelectedIndex = 1;

                    t05field14_2.Opacity = AppManager.QuestionDisabledOpacity;
                    t05Entry14.Opacity = AppManager.AnswerDisabledOpacity;
                    t05field14_2.IsEnabled = false;
                    t05Entry14.IsEnabled = false;
                    t05Entry14.Text = "";
                }
                else if (Erfassungsbogen.t05field14_03 == "4.3")
                {
                    t05Picker14.SelectedIndex = 2;
                }
                else if (Erfassungsbogen.t05field14_03 == "1")
                {
                    t05Picker14.SelectedIndex = 3;
                }
                else
                {
                    t05Picker14.SelectedIndex = -1;
                }

                // number 
                t05Entry14.Text = Erfassungsbogen.t05field14_02;

                // picker 5.6


                if (Erfassungsbogen.t05field15_03 == "e")
                {
                    t05Picker15.SelectedIndex = 0; // rb1 is the image file with checked box image

                    t05field15_2.Opacity = AppManager.QuestionDisabledOpacity;
                    t05Entry15.Opacity = AppManager.AnswerDisabledOpacity;
                    t05field15_2.IsEnabled = false;
                    t05Entry15.IsEnabled = false;
                    t05Entry15.Text = "";
                }
                else if (Erfassungsbogen.t05field15_03 == "s")
                {
                    t05Picker15.SelectedIndex = 1;

                    t05field15_2.Opacity = AppManager.QuestionDisabledOpacity;
                    t05Entry15.Opacity = AppManager.AnswerDisabledOpacity;
                    t05field15_2.IsEnabled = false;
                    t05Entry15.IsEnabled = false;
                    t05Entry15.Text = "";
                }
                else if (Erfassungsbogen.t05field15_03 == "8.6")
                {
                    t05Picker15.SelectedIndex = 2;
                }
                else if (Erfassungsbogen.t05field15_03 == "2")
                {
                    t05Picker15.SelectedIndex = 3;
                }
                else
                {
                    t05Picker15.SelectedIndex = -1;
                }

                // number 5.3
                t05Entry15.Text = Erfassungsbogen.t05field15_02;

                //alle Häufigkeiten ausblenden falls nicht ausgefüllt
                if (Erfassungsbogen.t05field13_03 == "" | Erfassungsbogen.t05field13_03 == null)
                {
                    t05field13_2.Opacity = AppManager.QuestionDisabledOpacity;
                    t05Entry13.Opacity = AppManager.AnswerDisabledOpacity;
                }
                if (Erfassungsbogen.t05field14_03 == "" | Erfassungsbogen.t05field14_03 == null)
                {
                    t05field14_2.Opacity = AppManager.QuestionDisabledOpacity;
                    t05Entry14.Opacity = AppManager.AnswerDisabledOpacity;
                }
                if (Erfassungsbogen.t05field15_03 == "" | Erfassungsbogen.t05field15_03 == null)
                {
                    t05field15_2.Opacity = AppManager.QuestionDisabledOpacity;
                    t05Entry15.Opacity = AppManager.AnswerDisabledOpacity;
                }

                //ActivityIndicator = Idle
                IsLoading = false;

            }
            catch (Exception)
            {
                await DisplayAlert(AppResources.AppError, AppResources.AppErrorMsg, "OK");
            }
        }

        private void T05Picker13_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (t05Picker13.SelectedIndex == 0)
            {
                Erfassungsbogen.t05field13_03 = "e";

                t05field13_2.Opacity = AppManager.QuestionDisabledOpacity;
                t05Entry13.Opacity = AppManager.AnswerDisabledOpacity;
                t05field13_2.IsEnabled = false;
                t05Entry13.IsEnabled = false;
            }
            else if (t05Picker13.SelectedIndex == 1)
            {
                Erfassungsbogen.t05field13_03 = "s";

                t05field13_2.Opacity = AppManager.QuestionDisabledOpacity;
                t05Entry13.Opacity = AppManager.AnswerDisabledOpacity;
                t05field13_2.IsEnabled = false;
                t05Entry13.IsEnabled = false;
            }
            else if (t05Picker13.SelectedIndex == 2)
            {
                Erfassungsbogen.t05field13_03 = "4.3";
            }
            else if (t05Picker13.SelectedIndex == 3)
            {
                Erfassungsbogen.t05field13_03 = "1";
            }

            if (t05Picker13.SelectedIndex != 0 && t05Picker13.SelectedIndex != 1)
            {
                t05field13_2.Opacity = AppManager.QuestionOpacity;
                t05Entry13.Opacity = AppManager.AnswerOpacity;
                t05field13_2.IsEnabled = true;
                t05Entry13.IsEnabled = true;
            }
        }

        private void T05Picker14_SelectedIndexChanged(object sender, EventArgs e)
        {
            // T05 02_03 picker

            if (t05Picker14.SelectedIndex == 0)
            {
                Erfassungsbogen.t05field14_03 = "e";

                t05field14_2.Opacity = AppManager.QuestionDisabledOpacity;
                t05Entry14.Opacity = AppManager.AnswerDisabledOpacity;
                t05field14_2.IsEnabled = false;
                t05Entry14.IsEnabled = false;
            }
            else if (t05Picker14.SelectedIndex == 1)
            {
                Erfassungsbogen.t05field14_03 = "s";

                t05field14_2.Opacity = AppManager.QuestionDisabledOpacity;
                t05Entry14.Opacity = AppManager.AnswerDisabledOpacity;
                t05field14_2.IsEnabled = false;
                t05Entry14.IsEnabled = false;
            }
            else if (t05Picker14.SelectedIndex == 2)
            {
                Erfassungsbogen.t05field14_03 = "4.3";
            }
            else if (t05Picker14.SelectedIndex == 3)
            {
                Erfassungsbogen.t05field14_03 = "1";
            }

            if (t05Picker14.SelectedIndex != 0 && t05Picker14.SelectedIndex != 1)
            {
                t05field14_2.Opacity = AppManager.QuestionOpacity;
                t05Entry14.Opacity = AppManager.AnswerOpacity;
                t05field14_2.IsEnabled = 
                t05Entry14.IsEnabled = true;
            }
        }

        private void T05Picker15_SelectedIndexChanged(object sender, EventArgs e)
        {
            //T04 03

            if (t05Picker15.SelectedIndex == 0)
            {
                Erfassungsbogen.t05field15_03 = "e";

                t05field15_2.Opacity = AppManager.QuestionDisabledOpacity;
                t05Entry15.Opacity = AppManager.AnswerDisabledOpacity;
                t05field15_2.IsEnabled = false;
                t05Entry15.IsEnabled = false;

            }
            else if (t05Picker15.SelectedIndex == 1)
            {
                Erfassungsbogen.t05field15_03 = "s";

                t05field15_2.Opacity = AppManager.QuestionDisabledOpacity;
                t05Entry15.Opacity = AppManager.AnswerDisabledOpacity;
                t05field15_2.IsEnabled = false;
                t05Entry15.IsEnabled = false;
            }
            else if (t05Picker15.SelectedIndex == 2)
            {
                Erfassungsbogen.t05field15_03 = "8.6";
            }
            else if (t05Picker15.SelectedIndex == 3)
            {
                Erfassungsbogen.t05field15_03 = "2";
            }

            if (t05Picker15.SelectedIndex != 0 && t05Picker15.SelectedIndex != 1)
            {
                t05field15_2.Opacity = AppManager.QuestionOpacity;
                t05Entry15.Opacity = AppManager.AnswerOpacity;
                t05field15_2.IsEnabled = 
                t05Entry15.IsEnabled = true;
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
                    await Navigation.PushAsync(new Bewaeltigung_4());
                }
                else
                {
                    var BackQuestion = await DisplayAlert(AppResources.Information, AppResources.InformationSaveQuery, AppResources.Yes, AppResources.No);
                    if (BackQuestion == true)
                    {
                        //Set Text Entry Values in Erfassungsbogen
                        Erfassungsbogen.t05field13_02 = t05Entry13.Text;
                        Erfassungsbogen.t05field14_02 = t05Entry14.Text;
                        Erfassungsbogen.t05field15_02 = t05Entry15.Text;

                        t05field13_1.TextColor = t05field13_2.TextColor = t05field14_1.TextColor = t05field14_2.TextColor = t05field15_1.TextColor = t05field15_2.TextColor = AppManager.QuestionColor;

                        if ((Erfassungsbogen.t05field13_03 != "" && Erfassungsbogen.t05field13_03 != null) && (Erfassungsbogen.t05field14_03 != "" && Erfassungsbogen.t05field14_03 != null) && (Erfassungsbogen.t05field15_03 != "" && Erfassungsbogen.t05field15_03 != null))
                        {
                            bool h1 = true;
                            bool h2 = true;
                            bool h3 = true;

                            if (Erfassungsbogen.t05field13_03 != "e" && Erfassungsbogen.t05field13_03 != "s")
                            {
                                if (t05Entry13.Text == "" | t05Entry13.Text == null)
                                {
                                    t05field13_2.TextColor = Color.Red;
                                    h1 = false;
                                }
                            }
                            if (Erfassungsbogen.t05field13_03 == "e" || Erfassungsbogen.t05field13_03 == "s")
                            {
                                t05field13_2.IsEnabled = false;
                                t05Entry13.IsEnabled = false;
                                t05Entry13.Opacity = AppManager.AnswerDisabledOpacity;
                                t05Entry13.Text = "";
                                h1 = true;
                            }
                            if (Erfassungsbogen.t05field14_03 != "e" && Erfassungsbogen.t05field14_03 != "s")
                            {
                                if (t05Entry14.Text == "" | t05Entry14.Text == null)
                                {
                                    t05field14_2.TextColor = Color.Red;
                                    h2 = false;
                                }
                            }
                            if (Erfassungsbogen.t05field15_03 != "e" && Erfassungsbogen.t05field15_03 != "s")
                            {
                                if (t05Entry15.Text == "" | t05Entry15.Text == null)
                                {
                                    t05field15_2.TextColor = Color.Red;
                                    h3 = false;
                                }
                            }

                            if (h1 && h2 && h3)
                            {
                                WebRequest req = WebRequest.Create(DBManagement.DBConnection + "tbl_form_ebqe_t05_05_update.php");

                                req.Method = "POST"; //POST
                                req.Timeout = 15000;
                                req.ContentType = "application/x-www-form-urlencoded";

                                string postData = "mstr=" + App.user.selected_mstr_ebqe + "&bewonerid=" + App.user.selected_id_bewohner + "&t05field13_03=" + Erfassungsbogen.t05field13_03 + "&t05field13_02=" + t05Entry13.Text + "&t05field14_03=" + Erfassungsbogen.t05field14_03 + "&t05field14_02=" + t05Entry14.Text + "&t05field15_03=" + Erfassungsbogen.t05field15_03 + "&t05field15_02=" + t05Entry15.Text;

                                byte[] byteArray = Encoding.UTF8.GetBytes(postData);

                                req.ContentLength = byteArray.Length;

                                Stream ds = await req.GetRequestStreamAsync();
                                await ds.WriteAsync(byteArray, 0, byteArray.Length);
                                ds.Close();

                                await Navigation.PushAsync(new Bewaeltigung_4());
                            }
                            else
                            {
                                await DisplayAlert(AppResources.Warning, AppResources.FieldsUnfilled, "OK");
                                BackButton.Source = "ic_arrow_back_ios.png";
                            }
                        }
                        else
                        {
                            if (Erfassungsbogen.t05field13_03 == "" || Erfassungsbogen.t05field13_03 == null)
                            {
                                t05field13_1.TextColor = Color.Red;
                            }
                            if (Erfassungsbogen.t05field14_03 == "" || Erfassungsbogen.t05field14_03 == null)
                            {
                                t05field14_1.TextColor = Color.Red;
                            }
                            if (Erfassungsbogen.t05field15_03 == "" || Erfassungsbogen.t05field15_03 == null)
                            {
                                t05field15_1.TextColor = Color.Red;
                            }

                            await DisplayAlert(AppResources.Warning, AppResources.FieldsUnfilled, "OK");
                            BackButton.Source = "ic_arrow_back_ios.png";
                        }
                    }
                    else
                    {
                        Erfassungsbogen.t05field13_03 = Erfassungsbogen.t05field13_02 = Erfassungsbogen.t05field14_03 = Erfassungsbogen.t05field14_02 = Erfassungsbogen.t05field15_03 = Erfassungsbogen.t05field15_02 = "";
                        t05Entry13.Text = t05Entry14.Text = t05Entry15.Text = "";

                        WebRequest req = WebRequest.Create(DBManagement.DBConnection + "tbl_form_ebqe_t05_05_update.php");

                        req.Method = "POST"; //POST
                        req.Timeout = 15000;
                        req.ContentType = "application/x-www-form-urlencoded";

                        string postData = "mstr=" + App.user.selected_mstr_ebqe + "&bewonerid=" + App.user.selected_id_bewohner + "&t05field13_03=" + Erfassungsbogen.t05field13_03 + "&t05field13_02=" + t05Entry13.Text + "&t05field14_03=" + Erfassungsbogen.t05field14_03 + "&t05field14_02=" + t05Entry14.Text + "&t05field15_03=" + Erfassungsbogen.t05field15_03 + "&t05field15_02=" + t05Entry15.Text;

                        byte[] byteArray = Encoding.UTF8.GetBytes(postData);

                        req.ContentLength = byteArray.Length;

                        Stream ds = await req.GetRequestStreamAsync();
                        await ds.WriteAsync(byteArray, 0, byteArray.Length);
                        ds.Close();

                        await Navigation.PushAsync(new Bewaeltigung_4());
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
                    await Navigation.PushAsync(new Bewaeltigung_6());
                }
                else
                {
                    //Set Text Entry Values in Erfassungsbogen
                    Erfassungsbogen.t05field13_02 = t05Entry13.Text;
                    Erfassungsbogen.t05field14_02 = t05Entry14.Text;
                    Erfassungsbogen.t05field15_02 = t05Entry15.Text;

                    t05field13_1.TextColor = t05field13_2.TextColor = t05field14_1.TextColor = t05field14_2.TextColor = t05field15_1.TextColor = t05field15_2.TextColor = AppManager.QuestionColor;

                    if ((Erfassungsbogen.t05field13_03 != "" && Erfassungsbogen.t05field13_03 != null) && (Erfassungsbogen.t05field14_03 != "" && Erfassungsbogen.t05field14_03 != null) && (Erfassungsbogen.t05field15_03 != "" && Erfassungsbogen.t05field15_03 != null))
                    {
                        bool h1 = true;
                        bool h2 = true;
                        bool h3 = true;

                        if (Erfassungsbogen.t05field13_03 != "e" && Erfassungsbogen.t05field13_03 != "s")
                        {
                            if (t05Entry13.Text == "" | t05Entry13.Text == null)
                            {
                                t05field13_2.TextColor = Color.Red;
                                h1 = false;
                            }
                        }
                        if (Erfassungsbogen.t05field13_03 == "e" || Erfassungsbogen.t05field13_03 == "s")
                        {
                            t05field13_2.IsEnabled = false;
                            t05Entry13.IsEnabled = false;
                            t05Entry13.Opacity = AppManager.AnswerDisabledOpacity;
                            t05Entry13.Text = "";
                            h1 = true;
                        }
                        if (Erfassungsbogen.t05field14_03 != "e" && Erfassungsbogen.t05field14_03 != "s")
                        {
                            if (t05Entry14.Text == "" | t05Entry14.Text == null)
                            {
                                t05field14_2.TextColor = Color.Red;
                                h2 = false;
                            }
                        }
                        if (Erfassungsbogen.t05field14_03 == "e" || Erfassungsbogen.t05field14_03 == "s")
                        {
                            t05field14_2.IsEnabled = false;
                            t05Entry14.IsEnabled = false;
                            t05Entry14.Opacity = AppManager.AnswerDisabledOpacity;
                            t05Entry14.Text = "";
                            h2 = true;
                        }
                        if (Erfassungsbogen.t05field15_03 != "e" && Erfassungsbogen.t05field15_03 != "s")
                        {
                            if (t05Entry15.Text == "" | t05Entry15.Text == null)
                            {
                                t05field15_2.TextColor = Color.Red;
                                h3 = false;
                            }
                        }
                        if (Erfassungsbogen.t05field15_03 == "e" || Erfassungsbogen.t05field15_03 == "s")
                        {
                            t05field15_2.IsEnabled = false;
                            t05Entry15.IsEnabled = false;
                            t05Entry15.Opacity = AppManager.AnswerDisabledOpacity;
                            t05Entry15.Text = "";
                            h3 = true;
                        }

                        if (h1 && h2 && h3)
                        {
                            WebRequest req = WebRequest.Create(DBManagement.DBConnection + "tbl_form_ebqe_t05_05_update.php");

                            req.Method = "POST"; //POST
                            req.Timeout = 15000;
                            req.ContentType = "application/x-www-form-urlencoded";

                            string postData = "mstr=" + App.user.selected_mstr_ebqe + "&bewonerid=" + App.user.selected_id_bewohner + "&t05field13_03=" + Erfassungsbogen.t05field13_03 + "&t05field13_02=" + t05Entry13.Text +
                                "&t05field14_03=" + Erfassungsbogen.t05field14_03 + "&t05field14_02=" + t05Entry14.Text + "&t05field15_03=" + Erfassungsbogen.t05field15_03 + "&t05field15_02=" + t05Entry15.Text;

                            byte[] byteArray = Encoding.UTF8.GetBytes(postData);

                            req.ContentLength = byteArray.Length;

                            Stream ds = await req.GetRequestStreamAsync();
                            await ds.WriteAsync(byteArray, 0, byteArray.Length);
                            ds.Close();

                            await Navigation.PushAsync(new Bewaeltigung_6());
                        }
                        else
                        {
                            await DisplayAlert(AppResources.Warning, AppResources.FieldsUnfilled, "OK");
                            ForwardButton.Source = "ic_arrow_forward_ios.png";
                          
                        }
                    }
                    else
                    {
                        if (Erfassungsbogen.t05field13_03 == "" || Erfassungsbogen.t05field13_03 == null)
                        {
                            t05field13_1.TextColor = Color.Red;
                        }
                        if (Erfassungsbogen.t05field14_03 == "" || Erfassungsbogen.t05field14_03 == null)
                        {
                            t05field14_1.TextColor = Color.Red;
                        }
                        if (Erfassungsbogen.t05field15_03 == "" || Erfassungsbogen.t05field15_03 == null)
                        {
                            t05field15_1.TextColor = Color.Red;
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