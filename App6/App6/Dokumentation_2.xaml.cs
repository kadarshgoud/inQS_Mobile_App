using App6.Model;
using System;
using System.IO;
using System.Net;
using System.Text;
using App6.Management;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using App6.Resources;

namespace App6
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Dokumentation_2 : ContentPage, INotifyPropertyChanged
    {
        public bool InitialDataIsEmpty;

        public Dokumentation_2()
        {
            InitializeComponent();
            BindingContext = this;

            BogenLabel.Text = AppResources.SurveyHeadline + " " + DBManagement.getYearCode(App.user.selected_mstr_ebqe) + " " + AppResources.SurveyHeadlineFor + " " + Erfassungsbogen.Bewohnerbezeichnung;

            t16Picker03.Items.Add("ja");
            t16Picker03.Items.Add("nein");

            t16Picker04.Items.Add("ja");
            t16Picker04.Items.Add("nein");
        }

        private void T16Picker03_SelectedIndexChanged(object sender, EventArgs e)
        {
            // T16 10
            if (t16Picker03.SelectedIndex == 0)
            {
                Erfassungsbogen.t16field10 = "1";
                t16field04.IsEnabled = t16Picker04.IsEnabled = false;
                t16field04.Opacity = t16Picker04.Opacity = AppManager.QuestionDisabledOpacity;
            }
            else if (t16Picker03.SelectedIndex == 1)
            {
                Erfassungsbogen.t16field10 = "0";

                t16field04.IsEnabled = t16Picker04.IsEnabled = true;
                t16field04.Opacity = t16Picker04.Opacity = AppManager.QuestionOpacity;
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

                //WebRequest req = WebRequest.Create(DBManagement.DBConnection + "tbl_form_ebqe_t16_02_read.php");

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

                //Erfassungsbogen.t16field10 = split[0];

                //Erfassungsbogen.t16field11 = split[1];

                // picker 16_10

                if (Erfassungsbogen.t16field10 == "1")
                {
                    t16Picker03.SelectedIndex = 0;                         // rb1 is the image file with checked box image

                    t16field04.IsEnabled = t16Picker04.IsEnabled = false;
                    t16field04.Opacity = t16Picker04.Opacity = AppManager.QuestionDisabledOpacity;
                }
                else if (Erfassungsbogen.t16field10 == "0")
                {
                    t16Picker03.SelectedIndex = 1;

                    t16field04.IsEnabled = t16Picker04.IsEnabled = true;
                    t16field04.Opacity = t16Picker04.Opacity = AppManager.QuestionOpacity;
                }
                else
                {
                    t16field04.IsEnabled = t16Picker04.IsEnabled = false;
                    t16field04.Opacity = t16Picker04.Opacity = AppManager.QuestionDisabledOpacity;

                    t16Picker03.SelectedIndex = -1;
                }

                // picker 16_11

                if (Erfassungsbogen.t16field11 == "1")
                {
                    t16Picker04.SelectedIndex = 0;                         // rb1 is the image file with checked box image
                }
                else if (Erfassungsbogen.t16field11 == "0")
                {
                    t16Picker04.SelectedIndex = 1;
                }
                else
                {
                    t16Picker04.SelectedIndex = -1;
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
                    await Navigation.PushAsync(new Dokumentation_1());
                }
                else
                {
                    var BackQuestion = await DisplayAlert(AppResources.Information, AppResources.InformationSaveQuery, AppResources.Yes, AppResources.No);
                    if (BackQuestion == true)
                    {
                        t16field03_01.TextColor = t16field04.TextColor = AppManager.QuestionColor;

                        if (Erfassungsbogen.t16field10 != "" && Erfassungsbogen.t16field10 != null)
                        {
                            if (Erfassungsbogen.t16field10 != "0")
                            {
                                WebRequest req = WebRequest.Create(DBManagement.DBConnection + "tbl_form_ebqe_t16_02_update.php");

                                req.Method = "POST"; //POST
                                req.Timeout = 15000;
                                req.ContentType = "application/x-www-form-urlencoded";

                                string postData = "mstr=" + App.user.selected_mstr_ebqe + "&bewonerid=" + App.user.selected_id_bewohner + "&t16field10=" + Erfassungsbogen.t16field10 + "&t16field11=" + Erfassungsbogen.t16field11;

                                byte[] byteArray = Encoding.UTF8.GetBytes(postData);

                                req.ContentLength = byteArray.Length;

                                Stream ds = await req.GetRequestStreamAsync();
                                await ds.WriteAsync(byteArray, 0, byteArray.Length);
                                ds.Close();

                                await Navigation.PushAsync(new Dokumentation_1());
                            }
                            else
                            {
                                if (Erfassungsbogen.t16field11 == "" || Erfassungsbogen.t16field11 == null)
                                {
                                    t16field04.TextColor = Color.Red;
                                    await DisplayAlert(AppResources.Warning, AppResources.FieldsUnfilled, "OK");
                                    BackButton.Source = "ic_arrow_back_ios.png";
                                }
                                else
                                {
                                    WebRequest req = WebRequest.Create(DBManagement.DBConnection + "tbl_form_ebqe_t16_02_update.php");

                                    req.Method = "POST"; //POST
                                    req.Timeout = 15000;
                                    req.ContentType = "application/x-www-form-urlencoded";

                                    string postData = "mstr=" + App.user.selected_mstr_ebqe + "&bewonerid=" + App.user.selected_id_bewohner + "&t16field10=" + Erfassungsbogen.t16field10 + "&t16field11=" + Erfassungsbogen.t16field11;

                                    byte[] byteArray = Encoding.UTF8.GetBytes(postData);

                                    req.ContentLength = byteArray.Length;

                                    Stream ds = await req.GetRequestStreamAsync();
                                    await ds.WriteAsync(byteArray, 0, byteArray.Length);
                                    ds.Close();

                                    await Navigation.PushAsync(new Dokumentation_1());
                                }
                            }
                        }
                        else
                        {
                            if (Erfassungsbogen.t16field10 == "" || Erfassungsbogen.t16field10 == null)
                            {
                                t16field03_01.TextColor = Color.Red;
                            }

                            await DisplayAlert(AppResources.Warning, AppResources.FieldsUnfilled, "OK");
                            BackButton.Source = "ic_arrow_back_ios.png";
                        }
                    }
                    else
                    {
                        Erfassungsbogen.t16field10 = Erfassungsbogen.t16field11 = "";

                        WebRequest req = WebRequest.Create(DBManagement.DBConnection + "tbl_form_ebqe_t16_02_update.php");

                        req.Method = "POST"; //POST
                        req.Timeout = 15000;
                        req.ContentType = "application/x-www-form-urlencoded";

                        string postData = "mstr=" + App.user.selected_mstr_ebqe + "&bewonerid=" + App.user.selected_id_bewohner + "&t16field10=" + Erfassungsbogen.t16field10 + "&t16field11=" + Erfassungsbogen.t16field11;

                        byte[] byteArray = Encoding.UTF8.GetBytes(postData);

                        req.ContentLength = byteArray.Length;

                        Stream ds = await req.GetRequestStreamAsync();
                        await ds.WriteAsync(byteArray, 0, byteArray.Length);
                        ds.Close();

                        await Navigation.PushAsync(new Dokumentation_1());
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
                    t16field03_01.TextColor = t16field04.TextColor = AppManager.QuestionColor;

                    if (Erfassungsbogen.t16field10 != "" && Erfassungsbogen.t16field10 != null)
                    {
                        if (Erfassungsbogen.t16field10 != "0")
                        {
                            WebRequest req = WebRequest.Create(DBManagement.DBConnection + "tbl_form_ebqe_t16_02_update.php");

                            req.Method = "POST"; //POST
                            req.Timeout = 15000;
                            req.ContentType = "application/x-www-form-urlencoded";

                            string postData = "mstr=" + App.user.selected_mstr_ebqe + "&bewonerid=" + App.user.selected_id_bewohner + "&t16field10=" + Erfassungsbogen.t16field10 + "&t16field11=" + Erfassungsbogen.t16field11;

                            byte[] byteArray = Encoding.UTF8.GetBytes(postData);

                            req.ContentLength = byteArray.Length;

                            Stream ds = await req.GetRequestStreamAsync();
                            await ds.WriteAsync(byteArray, 0, byteArray.Length);
                            ds.Close();

                            await Navigation.PushAsync(new SearchPage());
                        }
                        else
                        {
                            if (Erfassungsbogen.t16field11 == "" || Erfassungsbogen.t16field11 == null)
                            {
                                t16field04.TextColor = Color.Red;
                                await DisplayAlert(AppResources.Warning, AppResources.FieldsUnfilled, "OK");
                                SaveAllButton.Source = "ic_done_all.png";
                            }
                            else
                            {
                                WebRequest req = WebRequest.Create(DBManagement.DBConnection + "tbl_form_ebqe_t16_02_update.php");

                                req.Method = "POST"; //POST
                                req.Timeout = 15000;
                                req.ContentType = "application/x-www-form-urlencoded";

                                string postData = "mstr=" + App.user.selected_mstr_ebqe + "&bewonerid=" + App.user.selected_id_bewohner + "&t16field10=" + Erfassungsbogen.t16field10 + "&t16field11=" + Erfassungsbogen.t16field11;

                                byte[] byteArray = Encoding.UTF8.GetBytes(postData);

                                req.ContentLength = byteArray.Length;

                                Stream ds = await req.GetRequestStreamAsync();
                                await ds.WriteAsync(byteArray, 0, byteArray.Length);
                                ds.Close();

                                await Navigation.PushAsync(new SearchPage());
                            }
                        }
                    }
                    else
                    {
                        if (Erfassungsbogen.t16field10 == "" || Erfassungsbogen.t16field10 == null)
                        {
                            t16field03_01.TextColor = Color.Red;
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
                        WebRequest req = WebRequest.Create(DBManagement.DBConnection + "tbl_form_ebqe_t16_01-02_update_clear.php");

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

        private void T16Picker04_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (t16Picker04.SelectedIndex == 0)
            {
                Erfassungsbogen.t16field11 = "1";
            }
            else if (t16Picker04.SelectedIndex == 1)
            {
                Erfassungsbogen.t16field11 = "0";
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