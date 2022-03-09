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
    public partial class Allgemeines_4 : ContentPage, INotifyPropertyChanged
    {
        public bool InitialDataIsEmpty;

        public Allgemeines_4()
        {
            InitializeComponent();
            BindingContext = this;

            BogenLabel.Text = AppResources.SurveyHeadline + " " + DBManagement.getYearCode(App.user.selected_mstr_ebqe) + " " + AppResources.SurveyHeadlineFor + " " + Erfassungsbogen.Bewohnerbezeichnung;

            t00field12.Items.Add("ja, bewegt sich immer (oder fast immer) in einem Rollstuhl");
            t00field12.Items.Add("zum Teil, geht auch regelmäßig zu Fuß (ggf. unter Nutzung von Gehhilfen)");
            t00field12.Items.Add("nein, nie (oder fast nie): geht zu Fuß");
            t00field12.Items.Add("Rollstuhl ausschließlich zur Außennutzung");

            t00field11.Items.Add("überwiegend sitzend, geht aber zwischendurch einige Schritte");
            t00field11.Items.Add("ausschließlich sitzend oder liegend");
            t00field11.Items.Add("Bewohner verlässt das Bett nicht (in diesem Fall: weiter mit 0.13");

            t00field10.Items.Add("wach");
            t00field10.Items.Add("schläfrig");
            t00field10.Items.Add("somnolent");
            t00field10.Items.Add("komatös");
            t00field10.Items.Add("Wachkoma");

            t00field09.Items.Add("ja, invasive Beatmung");
            t00field09.Items.Add("ja, aber nicht invasiv");
            t00field09.Items.Add("nein");
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
                    await Navigation.PushAsync(new Allgemeines_3());
                }
                else
                {
                    var BackQuestion = await DisplayAlert(AppResources.Information, AppResources.InformationSaveQuery, AppResources.Yes, AppResources.No);
                    if (BackQuestion == true)
                    {
                        t00label09.TextColor = t00label10.TextColor = t00label11.TextColor = t00label12.TextColor = AppManager.QuestionColor;

                        if (Erfassungsbogen.t00field09 != "" && Erfassungsbogen.t00field09 != null && Erfassungsbogen.t00field10 != "" && Erfassungsbogen.t00field10 != null && Erfassungsbogen.t00field11 != "" && Erfassungsbogen.t00field11 != null)
                        {
                            if (Erfassungsbogen.t00field11 == "3")
                            {
                                Erfassungsbogen.t00field12 = "";

                                WebRequest req = WebRequest.Create(DBManagement.DBConnection + "tbl_form_ebqe_t00_04_update.php");

                                req.Method = "POST"; //POST
                                req.Timeout = 15000;
                                req.ContentType = "application/x-www-form-urlencoded";

                                string postData = "mstr=" + App.user.selected_mstr_ebqe + "&bewonerid=" + App.user.selected_id_bewohner + "&t00field09=" + Erfassungsbogen.t00field09 + "&t00field10=" + Erfassungsbogen.t00field10 + "&t00field11=" + Erfassungsbogen.t00field11 + "&t00field12=" + Erfassungsbogen.t00field12;

                                byte[] byteArray = Encoding.UTF8.GetBytes(postData);

                                req.ContentLength = byteArray.Length;

                                Stream ds = await req.GetRequestStreamAsync();
                                await ds.WriteAsync(byteArray, 0, byteArray.Length);
                                ds.Close();

                                await Navigation.PushAsync(new Allgemeines_3());
                            }
                            else
                            {
                                if (Erfassungsbogen.t00field12 != "" && Erfassungsbogen.t00field12 != null)
                                {
                                    WebRequest req = WebRequest.Create(DBManagement.DBConnection + "tbl_form_ebqe_t00_04_update.php");

                                    req.Method = "POST"; //POST
                                    req.Timeout = 15000;
                                    req.ContentType = "application/x-www-form-urlencoded";

                                    string postData = "mstr=" + App.user.selected_mstr_ebqe + "&bewonerid=" + App.user.selected_id_bewohner + "&t00field09=" + Erfassungsbogen.t00field09 + "&t00field10=" + Erfassungsbogen.t00field10 + "&t00field11=" + Erfassungsbogen.t00field11 + "&t00field12=" + Erfassungsbogen.t00field12;

                                    byte[] byteArray = Encoding.UTF8.GetBytes(postData);

                                    req.ContentLength = byteArray.Length;

                                    Stream ds = await req.GetRequestStreamAsync();
                                    await ds.WriteAsync(byteArray, 0, byteArray.Length);
                                    ds.Close();

                                    await Navigation.PushAsync(new Allgemeines_3());
                                }
                                else
                                {
                                    if (Erfassungsbogen.t00field12 == "" || Erfassungsbogen.t00field12 == null)
                                    {
                                        t00label12.TextColor = Color.Red;
                                    }
                                    await DisplayAlert(AppResources.Warning, AppResources.FieldsUnfilled, "OK");
                                    BackButton.Source = "ic_arrow_back_ios.png";
                                }
                            }
                        }
                        else
                        {
                            if (Erfassungsbogen.t00field09 == "" || Erfassungsbogen.t00field09 == null)
                            {
                                t00label09.TextColor = Color.Red;
                            }
                            if (Erfassungsbogen.t00field10 == "" || Erfassungsbogen.t00field10 == null)
                            {
                                t00label10.TextColor = Color.Red;
                            }
                            if (Erfassungsbogen.t00field11 == "" || Erfassungsbogen.t00field11 == null)
                            {
                                t00label11.TextColor = Color.Red;
                            }
                            if (Erfassungsbogen.t00field11 == "1" || Erfassungsbogen.t00field11 == "2")
                            {
                                if (Erfassungsbogen.t00field12 == "" || Erfassungsbogen.t00field11 == null)
                                {
                                    t00label12.TextColor = Color.Red;
                                }
                            }
                            await DisplayAlert(AppResources.Warning, AppResources.FieldsUnfilled, "OK");
                            BackButton.Source = "ic_arrow_back_ios.png";
                        }
                    }
                    else
                    {
                        Erfassungsbogen.t00field09 = Erfassungsbogen.t00field10 = Erfassungsbogen.t00field11 = Erfassungsbogen.t00field12 = "";

                        WebRequest req = WebRequest.Create(DBManagement.DBConnection + "tbl_form_ebqe_t00_04_update.php");

                        req.Method = "POST"; //POST
                        req.Timeout = 15000;
                        req.ContentType = "application/x-www-form-urlencoded";

                        string postData = "mstr=" + App.user.selected_mstr_ebqe + "&bewonerid=" + App.user.selected_id_bewohner + "&t00field09=" + Erfassungsbogen.t00field09 + "&t00field10=" + Erfassungsbogen.t00field10 + "&t00field11=" + Erfassungsbogen.t00field11 + "&t00field12=" + Erfassungsbogen.t00field12;

                        byte[] byteArray = Encoding.UTF8.GetBytes(postData);

                        req.ContentLength = byteArray.Length;

                        Stream ds = await req.GetRequestStreamAsync();
                        await ds.WriteAsync(byteArray, 0, byteArray.Length);
                        ds.Close();

                        await Navigation.PushAsync(new Allgemeines_3());
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
                    await Navigation.PushAsync(new Allgemeines_5());
                }
                else
                {
                    t00label09.TextColor = t00label10.TextColor = t00label11.TextColor = t00label12.TextColor = AppManager.QuestionColor;

                    if (Erfassungsbogen.t00field09 != "" && Erfassungsbogen.t00field09 != null && Erfassungsbogen.t00field10 != "" && Erfassungsbogen.t00field10 != null && Erfassungsbogen.t00field11 != "" && Erfassungsbogen.t00field11 != null)
                    {
                        if (Erfassungsbogen.t00field11 == "3")
                        {
                            Erfassungsbogen.t00field12 = "";

                            WebRequest req = WebRequest.Create(DBManagement.DBConnection + "tbl_form_ebqe_t00_04_update.php");

                            req.Method = "POST"; //POST
                            req.Timeout = 15000;
                            req.ContentType = "application/x-www-form-urlencoded";

                            string postData = "mstr=" + App.user.selected_mstr_ebqe + "&bewonerid=" + App.user.selected_id_bewohner + "&t00field09=" + Erfassungsbogen.t00field09 + "&t00field10=" + Erfassungsbogen.t00field10 + "&t00field11=" + Erfassungsbogen.t00field11
                            + "&t00field12=" + Erfassungsbogen.t00field12;

                            byte[] byteArray = Encoding.UTF8.GetBytes(postData);

                            req.ContentLength = byteArray.Length;

                            Stream ds = await req.GetRequestStreamAsync();
                            await ds.WriteAsync(byteArray, 0, byteArray.Length);
                            ds.Close();

                            await Navigation.PushAsync(new Allgemeines_5());
                        }
                        else
                        {
                            if (Erfassungsbogen.t00field12 != "" && Erfassungsbogen.t00field12 != null)
                            {
                                WebRequest req = WebRequest.Create(DBManagement.DBConnection + "tbl_form_ebqe_t00_04_update.php");

                                req.Method = "POST"; //POST
                                req.Timeout = 15000;
                                req.ContentType = "application/x-www-form-urlencoded";

                                string postData = "mstr=" + App.user.selected_mstr_ebqe + "&bewonerid=" + App.user.selected_id_bewohner + "&t00field09=" + Erfassungsbogen.t00field09 + "&t00field10=" + Erfassungsbogen.t00field10 + "&t00field11=" + Erfassungsbogen.t00field11
                                + "&t00field12=" + Erfassungsbogen.t00field12;

                                byte[] byteArray = Encoding.UTF8.GetBytes(postData);

                                req.ContentLength = byteArray.Length;

                                Stream ds = await req.GetRequestStreamAsync();
                                await ds.WriteAsync(byteArray, 0, byteArray.Length);
                                ds.Close();

                                await Navigation.PushAsync(new Allgemeines_5());
                            }
                            else
                            {
                                if (Erfassungsbogen.t00field12 == "" || Erfassungsbogen.t00field12 == null)
                                {
                                    t00label12.TextColor = Color.Red;
                                }
                                await DisplayAlert(AppResources.Warning, AppResources.FieldsUnfilled, "OK");
                                ForwardButton.Source = "ic_arrow_forward_ios.png";
                            }
                        }
                    }
                    else
                    {
                        if (Erfassungsbogen.t00field09 == "" || Erfassungsbogen.t00field09 == null)
                        {
                            t00label09.TextColor = Color.Red;
                        }
                        if (Erfassungsbogen.t00field10 == "" || Erfassungsbogen.t00field10 == null)
                        {
                            t00label10.TextColor = Color.Red;
                        }
                        if (Erfassungsbogen.t00field11 == "" || Erfassungsbogen.t00field11 == null)
                        {
                            t00label11.TextColor = Color.Red;
                        }
                        if (Erfassungsbogen.t00field11 == "1" || Erfassungsbogen.t00field11 == "2")
                        {
                            if (Erfassungsbogen.t00field12 == "" || Erfassungsbogen.t00field11 == null)
                            {
                                t00label12.TextColor = Color.Red;
                            }
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

        //Before page gets loaded this opertion is performed
        protected override async void OnAppearing()
        {
            base.OnAppearing();

            try
            {
                //ActivityIndicator = Loading...
                IsLoading = true;

                //WebRequest req = WebRequest.Create(DBManagement.DBConnection + "tbl_form_ebqe_t00_04_read.php");

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

                //if (split[0] != "" && split[1] != "" && split[2] != "" && split[3] != "")
                //{
                //    InitialDataIsEmpty = false;
                //}

                //Erfassungsbogen.t00field09 = split[0];
                //Erfassungsbogen.t00field10 = split[1];
                //Erfassungsbogen.t00field11 = split[2];
                //Erfassungsbogen.t00field12 = split[3];

                // picker 09

                if (Erfassungsbogen.t00field09 == "1")
                {
                    t00field09.SelectedIndex = 0;                         // rb1 is the image file with checked box image
                }
                else if (Erfassungsbogen.t00field09 == "2")
                {
                    t00field09.SelectedIndex = 1;
                }
                else if (Erfassungsbogen.t00field09 == "0")
                {
                    t00field09.SelectedIndex = 2;
                }
                else
                {
                    t00field09.SelectedIndex = -1;
                }

                // picker 10

                if (Erfassungsbogen.t00field10 == "1")
                {
                    t00field10.SelectedIndex = 0;                         // rb1 is the image file with checked box image
                }
                else if (Erfassungsbogen.t00field10 == "2")
                {
                    t00field10.SelectedIndex = 1;
                }
                else if (Erfassungsbogen.t00field10 == "3")
                {
                    t00field10.SelectedIndex = 2;
                }
                else if (Erfassungsbogen.t00field10 == "4")
                {
                    t00field10.SelectedIndex = 3;                         // rb1 is the image file with checked box image
                }
                else if (Erfassungsbogen.t00field10 == "5")
                {
                    t00field10.SelectedIndex = 4;
                }

                else
                {
                    t00field10.SelectedIndex = -1;
                }

                // picker 11

                if (Erfassungsbogen.t00field11 == "1")
                {
                    t00field11.SelectedIndex = 0;                         // rb1 is the image file with checked box image
                }
                else if (Erfassungsbogen.t00field11 == "2")
                {
                    t00field11.SelectedIndex = 1;
                }
                else if (Erfassungsbogen.t00field11 == "3")
                {
                    t00field11.SelectedIndex = 2;
                }
                else
                {
                    t00field11.SelectedIndex = -1;
                }

                if (Erfassungsbogen.t00field11 != "3")
                {
                    t00label12.Opacity = AppManager.QuestionOpacity;
                    t00field12.Opacity = AppManager.AnswerOpacity;
                }
                else
                {
                    //weil nicht aus Bett, kein Rollstuhl
                    t00label12.Opacity = AppManager.QuestionDisabledOpacity;
                    t00field12.Opacity = AppManager.AnswerDisabledOpacity;
                }

                // picker 12

                if (Erfassungsbogen.t00field12 == "1")
                {
                    t00field12.SelectedIndex = 0;                         // rb1 is the image file with checked box image
                }
                else if (Erfassungsbogen.t00field12 == "2")
                {
                    t00field12.SelectedIndex = 1;
                }
                else if (Erfassungsbogen.t00field12 == "0")
                {
                    t00field12.SelectedIndex = 2;
                }
                else if (Erfassungsbogen.t00field12 == "3")
                {
                    t00field12.SelectedIndex = 3;
                }
                else
                {
                    t00field12.SelectedIndex = -1;
                }
                //ActivityIndicator = Idle
                IsLoading = false;

            }
            catch (Exception)
            {
                await DisplayAlert(AppResources.AppError, AppResources.AppErrorMsg, "OK");
            }
        }

        private void T00field09_SelectedIndexChanged(object sender, EventArgs e)
        {
            // picker T00 09

            if (t00field09.SelectedIndex == 0)
            {
                Erfassungsbogen.t00field09 = "1";

            }
            else if (t00field09.SelectedIndex == 1)
            {
                Erfassungsbogen.t00field09 = "2";

            }
            else if (t00field09.SelectedIndex == 2)
            {
                Erfassungsbogen.t00field09 = "0";
            }
        }

        private void T00field10_SelectedIndexChanged(object sender, EventArgs e)
        {
            // picker T00 10

            if (t00field10.SelectedIndex == 0)
            {
                Erfassungsbogen.t00field10 = "1";

            }
            else if (t00field10.SelectedIndex == 1)
            {
                Erfassungsbogen.t00field10 = "2";

            }
            else if (t00field10.SelectedIndex == 2)
            {
                Erfassungsbogen.t00field10 = "3";
            }
            else if (t00field10.SelectedIndex == 3)
            {
                Erfassungsbogen.t00field10 = "4";

            }
            else if (t00field10.SelectedIndex == 4)
            {
                Erfassungsbogen.t00field10 = "5";
            }
        }

        private void T00field11_SelectedIndexChanged(object sender, EventArgs e)
        {
            // picker T00 11

            if (t00field11.SelectedIndex == 0)
            {
                Erfassungsbogen.t00field11 = "1";

            }
            if (t00field11.SelectedIndex == 1)
            {
                Erfassungsbogen.t00field11 = "2";

            }
            if (t00field11.SelectedIndex == 2)
            {
                Erfassungsbogen.t00field11 = "3";

                //weil nicht aus Bett, kein Rollstuhl
                t00label12.Opacity = AppManager.QuestionDisabledOpacity;
                t00field12.Opacity = AppManager.AnswerDisabledOpacity;
            }
            if (t00field11.SelectedIndex != 2)
            {
                t00label12.Opacity = AppManager.QuestionOpacity;
                t00field12.Opacity = AppManager.AnswerOpacity;
            }
        }

        private void T00field12_SelectedIndexChanged(object sender, EventArgs e)
        {
            // picker T00 12

            if (t00field12.SelectedIndex == 0)
            {
                Erfassungsbogen.t00field12 = "1";

            }
            else if (t00field12.SelectedIndex == 1)
            {
                Erfassungsbogen.t00field12 = "2";

            }
            else if (t00field12.SelectedIndex == 2)
            {
                Erfassungsbogen.t00field12 = "0";
            }
            else if (t00field12.SelectedIndex == 3)
            {
                Erfassungsbogen.t00field12 = "3";
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