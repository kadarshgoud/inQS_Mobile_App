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
    public partial class Kognitive_2 : ContentPage, INotifyPropertyChanged
    {
        public bool InitialDataIsEmpty;

        public Kognitive_2()
        {
            InitializeComponent();
            BindingContext = this;

            BogenLabel.Text = AppResources.SurveyHeadline + " " + DBManagement.getYearCode(App.user.selected_mstr_ebqe) + " " + AppResources.SurveyHeadlineFor + " " + Erfassungsbogen.Bewohnerbezeichnung;

            t02Picker09.Items.Add("0 = vorhanden/unbeeinträchtigt");
            t02Picker09.Items.Add("1 = größtenteils vorhanden");
            t02Picker09.Items.Add("2 = in geringem Maße vorhanden");
            t02Picker09.Items.Add("3 = nicht vorhanden");

            t02Picker06.Items.Add("0 = vorhanden/unbeeinträchtigt");
            t02Picker06.Items.Add("1 = größtenteils vorhanden");
            t02Picker06.Items.Add("2 = in geringem Maße vorhanden");
            t02Picker06.Items.Add("3 = nicht vorhanden");

            t02Picker07.Items.Add("0 = vorhanden/unbeeinträchtigt");
            t02Picker07.Items.Add("1 = größtenteils vorhanden");
            t02Picker07.Items.Add("2 = in geringem Maße vorhanden");
            t02Picker07.Items.Add("3 = nicht vorhanden");

            t02Picker08.Items.Add("0 = vorhanden/unbeeinträchtigt");
            t02Picker08.Items.Add("1 = größtenteils vorhanden");
            t02Picker08.Items.Add("2 = in geringem Maße vorhanden");
            t02Picker08.Items.Add("3 = nicht vorhanden");
        }

        //Before page gets loaded this opertion is performed
        protected override async void OnAppearing()
        {
            base.OnAppearing();

            try
            {
                //ActivityIndicator = Loading...
                IsLoading = true;

                //WebRequest req = WebRequest.Create(DBManagement.DBConnection + "tbl_form_ebqe_t02_02_read.php");

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

                //Erfassungsbogen.t02field06 = split[0];
                //Erfassungsbogen.t02field07 = split[1];
                //Erfassungsbogen.t02field08 = split[2];
                //Erfassungsbogen.t02field09 = split[3];

                if (Erfassungsbogen.t02field06 == "0")
                {
                    t02Picker06.SelectedIndex = 0;                         // rb1 is the image file with checked box image
                }
                else if (Erfassungsbogen.t02field06 == "1")
                {
                    t02Picker06.SelectedIndex = 1;
                }
                else if (Erfassungsbogen.t02field06 == "2")
                {
                    t02Picker06.SelectedIndex = 2;
                }
                else if (Erfassungsbogen.t02field06 == "3")
                {
                    t02Picker06.SelectedIndex = 3;
                }
                else
                {
                    t02Picker06.SelectedIndex = -1;
                }

                if (Erfassungsbogen.t02field07 == "0")
                {
                    t02Picker07.SelectedIndex = 0; // rb1 is the image file with checked box image
                }
                else if (Erfassungsbogen.t02field07 == "1")
                {
                    t02Picker07.SelectedIndex = 1;
                }
                else if (Erfassungsbogen.t02field07 == "2")
                {
                    t02Picker07.SelectedIndex = 2;
                }
                else if (Erfassungsbogen.t02field07 == "3")
                {
                    t02Picker07.SelectedIndex = 3;
                }
                else
                {
                    t02Picker07.SelectedIndex = -1;
                }

                if (Erfassungsbogen.t02field08 == "0")
                {
                    t02Picker08.SelectedIndex = 0; // rb1 is the image file with checked box image
                }
                else if (Erfassungsbogen.t02field08 == "1")
                {
                    t02Picker08.SelectedIndex = 1;
                }
                else if (Erfassungsbogen.t02field08 == "2")
                {
                    t02Picker08.SelectedIndex = 2;
                }
                else if (Erfassungsbogen.t02field08 == "3")
                {
                    t02Picker08.SelectedIndex = 3;
                }
                else
                {
                    t02Picker08.SelectedIndex = -1;
                }
                if (Erfassungsbogen.t02field09 == "0")
                {
                    t02Picker09.SelectedIndex = 0; // rb1 is the image file with checked box image
                }
                else if (Erfassungsbogen.t02field09 == "1")
                {
                    t02Picker09.SelectedIndex = 1;
                }
                else if (Erfassungsbogen.t02field09 == "2")
                {
                    t02Picker09.SelectedIndex = 2;
                }
                else if (Erfassungsbogen.t02field09 == "3")
                {
                    t02Picker09.SelectedIndex = 3;
                }
                else
                {
                    t02Picker09.SelectedIndex = -1;
                }
                //ActivityIndicator = Idle
                IsLoading = false;

            }
            catch (Exception)
            {
                await DisplayAlert(AppResources.AppError, AppResources.AppErrorMsg, "OK");
            }
        }

        private void T02Picker06_SelectedIndexChanged(object sender, EventArgs e)
        {
            // picker T02 06
            if (t02Picker06.SelectedIndex == 0)
            {

                Erfassungsbogen.t02field06 = "0";
            }

            else if (t02Picker06.SelectedIndex == 1)
            {

                Erfassungsbogen.t02field06 = "1";
            }
            else if (t02Picker06.SelectedIndex == 2)
            {

                Erfassungsbogen.t02field06 = "2";
            }
            else if (t02Picker06.SelectedIndex == 3)
            {

                Erfassungsbogen.t02field06 = "3";
            }
        }

        private void T02Picker07_SelectedIndexChanged(object sender, EventArgs e)
        {
            // T02 07

            if (t02Picker07.SelectedIndex == 0)
            {
                Erfassungsbogen.t02field07 = "0";
            }
            else if (t02Picker07.SelectedIndex == 1)
            {
                Erfassungsbogen.t02field07 = "1";
            }
            else if (t02Picker07.SelectedIndex == 2)
            {
                Erfassungsbogen.t02field07 = "2";
            }
            else if (t02Picker07.SelectedIndex == 3)
            {
                Erfassungsbogen.t02field07 = "3";
            }
        }

        private void T02Picker09_SelectedIndexChanged(object sender, EventArgs e)
        {
            // T02 09

            if (t02Picker09.SelectedIndex == 0)
            {
                Erfassungsbogen.t02field09 = "0";
            }
            else if (t02Picker09.SelectedIndex == 1)
            {
                Erfassungsbogen.t02field09 = "1";
            }
            else if (t02Picker09.SelectedIndex == 2)
            {
                Erfassungsbogen.t02field09 = "2";
            }
            else if (t02Picker09.SelectedIndex == 3)
            {
                Erfassungsbogen.t02field09 = "3";
            }
        }

        private void T02Picker08_SelectedIndexChanged(object sender, EventArgs e)
        {
            //T02 08

            if (t02Picker08.SelectedIndex == 0)
            {
                Erfassungsbogen.t02field08 = "0";
            }
            else if (t02Picker08.SelectedIndex == 1)
            {
                Erfassungsbogen.t02field08 = "1";
            }
            else if (t02Picker08.SelectedIndex == 2)
            {
                Erfassungsbogen.t02field08 = "2";
            }
            else if (t02Picker08.SelectedIndex == 3)
            {
                Erfassungsbogen.t02field08 = "3";
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
                    await Navigation.PushAsync(new Kognitive_1());
                }
                else
                {
                    var BackQuestion = await DisplayAlert(AppResources.Information, AppResources.InformationSaveQuery, AppResources.Yes, AppResources.No);
                    if (BackQuestion == true)
                    {
                        t02field06.TextColor = t02field07.TextColor = t02field08.TextColor = t02field09.TextColor = AppManager.QuestionColor;

                        if ((Erfassungsbogen.t02field06 != "" && Erfassungsbogen.t02field06 != null) && (Erfassungsbogen.t02field07 != "" && Erfassungsbogen.t02field07 != null) && (Erfassungsbogen.t02field08 != "" && Erfassungsbogen.t02field08 != null) && (Erfassungsbogen.t02field09 != "" && Erfassungsbogen.t02field09 != null))
                        {
                            if (App.user.selected_mstr_ebqe == DBManagement.CurrentEvaluationID)
                            {
                                WebRequest req = WebRequest.Create(DBManagement.DBConnection + "tbl_form_ebqe_t02_02_update.php");

                                req.Method = "POST"; //POST
                                req.Timeout = 15000;
                                req.ContentType = "application/x-www-form-urlencoded";

                                string postData = "mstr=" + App.user.selected_mstr_ebqe + "&bewonerid=" + App.user.selected_id_bewohner + "&t02field06=" + Erfassungsbogen.t02field06 + "&t02field07=" + Erfassungsbogen.t02field07 + "&t02field08=" + Erfassungsbogen.t02field08 + "&t02field09=" + Erfassungsbogen.t02field09;

                                byte[] byteArray = Encoding.UTF8.GetBytes(postData);

                                req.ContentLength = byteArray.Length;

                                Stream ds = await req.GetRequestStreamAsync();
                                await ds.WriteAsync(byteArray, 0, byteArray.Length);
                                ds.Close();
                            }

                            await Navigation.PushAsync(new Kognitive_1());
                        }
                        else
                        {
                            if (Erfassungsbogen.t02field06 == "" || Erfassungsbogen.t02field06 == null)
                            {
                                t02field06.TextColor = Color.Red;
                            }
                            if (Erfassungsbogen.t02field07 == "" || Erfassungsbogen.t02field07 == null)
                            {
                                t02field07.TextColor = Color.Red;
                            }
                            if (Erfassungsbogen.t02field08 == "" || Erfassungsbogen.t02field08 == null)
                            {
                                t02field08.TextColor = Color.Red;
                            }
                            if (Erfassungsbogen.t02field09 == "" || Erfassungsbogen.t02field09 == null)
                            {
                                t02field09.TextColor = Color.Red;
                            }
                            await DisplayAlert(AppResources.Warning, AppResources.FieldsUnfilled, "OK");
                            BackButton.Source = "ic_arrow_back_ios.png";
                        }
                    }
                    else
                    {
                        Erfassungsbogen.t02field06 = Erfassungsbogen.t02field07 = Erfassungsbogen.t02field08 = Erfassungsbogen.t02field09 = "";

                        WebRequest req = WebRequest.Create(DBManagement.DBConnection + "tbl_form_ebqe_t02_02_update.php");

                        req.Method = "POST"; //POST
                        req.Timeout = 15000;
                        req.ContentType = "application/x-www-form-urlencoded";

                        string postData = "mstr=" + App.user.selected_mstr_ebqe + "&bewonerid=" + App.user.selected_id_bewohner + "&t02field06=" + Erfassungsbogen.t02field06 + "&t02field07=" + Erfassungsbogen.t02field07 + "&t02field08=" + Erfassungsbogen.t02field08 + "&t02field09=" + Erfassungsbogen.t02field09;

                        byte[] byteArray = Encoding.UTF8.GetBytes(postData);

                        req.ContentLength = byteArray.Length;

                        Stream ds = await req.GetRequestStreamAsync();
                        await ds.WriteAsync(byteArray, 0, byteArray.Length);
                        ds.Close();

                        await Navigation.PushAsync(new Kognitive_1());
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
                    await Navigation.PushAsync(new Kognitive_3());
                }
                else
                {
                    t02field06.TextColor = t02field07.TextColor = t02field08.TextColor = t02field09.TextColor = AppManager.QuestionColor;

                    if ((Erfassungsbogen.t02field06 != "" && Erfassungsbogen.t02field06 != null) && (Erfassungsbogen.t02field07 != "" && Erfassungsbogen.t02field07 != null) && (Erfassungsbogen.t02field08 != "" && Erfassungsbogen.t02field08 != null) && (Erfassungsbogen.t02field09 != "" && Erfassungsbogen.t02field09 != null))
                    {
                        if (App.user.selected_mstr_ebqe == DBManagement.CurrentEvaluationID)
                        {
                            WebRequest req = WebRequest.Create(DBManagement.DBConnection + "tbl_form_ebqe_t02_02_update.php");

                            req.Method = "POST"; //POST
                            req.Timeout = 15000;
                            req.ContentType = "application/x-www-form-urlencoded";

                            string postData = "mstr=" + App.user.selected_mstr_ebqe + "&bewonerid=" + App.user.selected_id_bewohner + "&t02field06=" + Erfassungsbogen.t02field06 + "&t02field07=" + Erfassungsbogen.t02field07 +
                                "&t02field08=" + Erfassungsbogen.t02field08 + "&t02field09=" + Erfassungsbogen.t02field09;

                            byte[] byteArray = Encoding.UTF8.GetBytes(postData);

                            req.ContentLength = byteArray.Length;

                            Stream ds = await req.GetRequestStreamAsync();
                            await ds.WriteAsync(byteArray, 0, byteArray.Length);
                            ds.Close();
                        }

                        await Navigation.PushAsync(new Kognitive_3());
                    }
                    else
                    {
                        if (Erfassungsbogen.t02field06 == "" || Erfassungsbogen.t02field06 == null)
                        {
                            t02field06.TextColor = Color.Red;
                        }
                        if (Erfassungsbogen.t02field07 == "" || Erfassungsbogen.t02field07 == null)
                        {
                            t02field07.TextColor = Color.Red;
                        }
                        if (Erfassungsbogen.t02field08 == "" || Erfassungsbogen.t02field08 == null)
                        {
                            t02field08.TextColor = Color.Red;
                        }
                        if (Erfassungsbogen.t02field09 == "" || Erfassungsbogen.t02field09 == null)
                        {
                            t02field09.TextColor = Color.Red;
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