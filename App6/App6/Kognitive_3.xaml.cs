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
    public partial class Kognitive_3 : ContentPage, INotifyPropertyChanged
    {
        public bool InitialDataIsEmpty;

        public Kognitive_3()
        {
            InitializeComponent();
            BindingContext = this;

            BogenLabel.Text = AppResources.SurveyHeadline + " " + DBManagement.getYearCode(App.user.selected_mstr_ebqe) + " " + AppResources.SurveyHeadlineFor + " " + Erfassungsbogen.Bewohnerbezeichnung;

            t02Picker10.Items.Add("0 = vorhanden/unbeeinträchtigt");
            t02Picker10.Items.Add("1 = größtenteils vorhanden");
            t02Picker10.Items.Add("2 = in geringem Maße vorhanden");
            t02Picker10.Items.Add("3 = nicht vorhanden");

            t02Picker11.Items.Add("0 = vorhanden/unbeeinträchtigt");
            t02Picker11.Items.Add("1 = größtenteils vorhanden");
            t02Picker11.Items.Add("2 = in geringem Maße vorhanden");
            t02Picker11.Items.Add("3 = nicht vorhanden");
        }

        //Before page gets loaded this opertion is performed
        protected override async void OnAppearing()
        {
            base.OnAppearing();

            try
            {
                //ActivityIndicator = Loading...
                IsLoading = true;

                //WebRequest req = WebRequest.Create(DBManagement.DBConnection + "tbl_form_ebqe_t02_03_read.php");

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

                //if (split[0] != "" && split[1] != "")
                //{
                //    InitialDataIsEmpty = false;
                //}

                //Erfassungsbogen.t02field10 = split[0];
                //Erfassungsbogen.t02field11 = split[1];

                if (Erfassungsbogen.t02field10 == "0")
                {
                    t02Picker10.SelectedIndex = 0;                         // rb1 is the image file with checked box image
                }
                else if (Erfassungsbogen.t02field10 == "1")
                {
                    t02Picker10.SelectedIndex = 1;
                }
                else if (Erfassungsbogen.t02field10 == "2")
                {
                    t02Picker10.SelectedIndex = 2;
                }
                else if (Erfassungsbogen.t02field10 == "3")
                {
                    t02Picker10.SelectedIndex = 3;
                }
                else
                {
                    t02Picker10.SelectedIndex = -1;
                }

                if (Erfassungsbogen.t02field11 == "0")
                {
                    t02Picker11.SelectedIndex = 0; // rb1 is the image file with checked box image
                }
                else if (Erfassungsbogen.t02field11 == "1")
                {
                    t02Picker11.SelectedIndex = 1;
                }
                else if (Erfassungsbogen.t02field11 == "2")
                {
                    t02Picker11.SelectedIndex = 2;
                }
                else if (Erfassungsbogen.t02field11 == "3")
                {
                    t02Picker11.SelectedIndex = 3;
                }
                else
                {
                    t02Picker11.SelectedIndex = -1;
                }
                //ActivityIndicator = Idle
                IsLoading = false;

            }
            catch (Exception)
            {
                await DisplayAlert(AppResources.AppError, AppResources.AppErrorMsg, "OK");
            }
        }

        private void T02Picker10_SelectedIndexChanged(object sender, EventArgs e)
        {
            // picker T02 10
            if (t02Picker10.SelectedIndex == 0)
            {

                Erfassungsbogen.t02field10 = "0";
            }

            else if (t02Picker10.SelectedIndex == 1)
            {

                Erfassungsbogen.t02field10 = "1";
            }
            else if (t02Picker10.SelectedIndex == 2)
            {

                Erfassungsbogen.t02field10 = "2";
            }
            else if (t02Picker10.SelectedIndex == 3)
            {

                Erfassungsbogen.t02field10 = "3";
            }
        }

        private void T02Picker11_SelectedIndexChanged(object sender, EventArgs e)
        {
            // T02 11

            if (t02Picker11.SelectedIndex == 0)
            {
                Erfassungsbogen.t02field11 = "0";
            }
            else if (t02Picker11.SelectedIndex == 1)
            {
                Erfassungsbogen.t02field11 = "1";
            }
            else if (t02Picker11.SelectedIndex == 2)
            {
                Erfassungsbogen.t02field11 = "2";
            }
            else if (t02Picker11.SelectedIndex == 3)
            {
                Erfassungsbogen.t02field11 = "3";
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
                    await Navigation.PushAsync(new Kognitive_2());
                }
                else
                {
                    var BackQuestion = await DisplayAlert(AppResources.Information, AppResources.InformationSaveQuery, AppResources.Yes, AppResources.No);
                    if (BackQuestion == true)
                    {
                        t02field10.TextColor = t02field11.TextColor = AppManager.QuestionColor;

                        if ((Erfassungsbogen.t02field10 != "" && Erfassungsbogen.t02field10 != null) && (Erfassungsbogen.t02field11 != "" && Erfassungsbogen.t02field11 != null))
                        {
                            WebRequest req = WebRequest.Create(DBManagement.DBConnection + "tbl_form_ebqe_t02_03_update.php");

                            req.Method = "POST"; //POST
                            req.Timeout = 15000;
                            req.ContentType = "application/x-www-form-urlencoded";

                            string postData = "mstr=" + App.user.selected_mstr_ebqe + "&bewonerid=" + App.user.selected_id_bewohner + "&t02field10=" + Erfassungsbogen.t02field10 + "&t02field11=" + Erfassungsbogen.t02field11;

                            byte[] byteArray = Encoding.UTF8.GetBytes(postData);

                            req.ContentLength = byteArray.Length;

                            Stream ds = await req.GetRequestStreamAsync();
                            await ds.WriteAsync(byteArray, 0, byteArray.Length);
                            ds.Close();

                            await Navigation.PushAsync(new Kognitive_2());
                        }
                        else
                        {
                            if (Erfassungsbogen.t02field10 == "" || Erfassungsbogen.t02field10 == null)
                            {
                                t02field10.TextColor = Color.Red;
                            }
                            if (Erfassungsbogen.t02field11 == "" || Erfassungsbogen.t02field11 == null)
                            {
                                t02field11.TextColor = Color.Red;
                            }

                            await DisplayAlert(AppResources.Warning, AppResources.FieldsUnfilled, "OK");
                            BackButton.Source = "ic_arrow_back_ios.png";
                        }
                    }
                    else
                    {
                        Erfassungsbogen.t02field10 = Erfassungsbogen.t02field11 = "";

                        WebRequest req = WebRequest.Create(DBManagement.DBConnection + "tbl_form_ebqe_t02_03_update.php");

                        req.Method = "POST"; //POST
                        req.Timeout = 15000;
                        req.ContentType = "application/x-www-form-urlencoded";

                        string postData = "mstr=" + App.user.selected_mstr_ebqe + "&bewonerid=" + App.user.selected_id_bewohner + "&t02field10=" + Erfassungsbogen.t02field10 + "&t02field11=" + Erfassungsbogen.t02field11;

                        byte[] byteArray = Encoding.UTF8.GetBytes(postData);

                        req.ContentLength = byteArray.Length;

                        Stream ds = await req.GetRequestStreamAsync();
                        await ds.WriteAsync(byteArray, 0, byteArray.Length);
                        ds.Close();

                        await Navigation.PushAsync(new Kognitive_2());
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
                    t02field10.TextColor = t02field11.TextColor = AppManager.QuestionColor;

                    if ((Erfassungsbogen.t02field10 != "" && Erfassungsbogen.t02field10 != null) && (Erfassungsbogen.t02field11 != "" && Erfassungsbogen.t02field11 != null))
                    {
                        WebRequest req = WebRequest.Create(DBManagement.DBConnection + "tbl_form_ebqe_t02_03_update.php");

                        req.Method = "POST"; //POST
                        req.Timeout = 15000;
                        req.ContentType = "application/x-www-form-urlencoded";

                        string postData = "mstr=" + App.user.selected_mstr_ebqe + "&bewonerid=" + App.user.selected_id_bewohner + "&t02field10=" + Erfassungsbogen.t02field10 + "&t02field11=" + Erfassungsbogen.t02field11;

                        byte[] byteArray = Encoding.UTF8.GetBytes(postData);

                        req.ContentLength = byteArray.Length;

                        Stream ds = await req.GetRequestStreamAsync();
                        await ds.WriteAsync(byteArray, 0, byteArray.Length);
                        ds.Close();

                        await Navigation.PushAsync(new SearchPage());
                    }
                    else
                    {
                        if (Erfassungsbogen.t02field10 == "" || Erfassungsbogen.t02field10 == null)
                        {
                            t02field10.TextColor = Color.Red;
                        }
                        if (Erfassungsbogen.t02field11 == "" || Erfassungsbogen.t02field11 == null)
                        {
                            t02field11.TextColor = Color.Red;
                        }

                        await DisplayAlert(AppResources.Warning, AppResources.FieldsUnfilled, "OK");
                        SaveAllButton.Source = "ic_done_all.png";
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
                        WebRequest req = WebRequest.Create(DBManagement.DBConnection + "tbl_form_ebqe_t02_01-03_update_clear.php");

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