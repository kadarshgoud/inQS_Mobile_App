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
    public partial class Verhaltensweisen_3 : ContentPage, INotifyPropertyChanged
    {
        public bool InitialDataIsEmpty;

        public Verhaltensweisen_3()
        {
            InitializeComponent();
            BindingContext = this;

            BogenLabel.Text = AppResources.SurveyHeadline + " " + DBManagement.getYearCode(App.user.selected_mstr_ebqe) + " " + AppResources.SurveyHeadlineFor + " " + Erfassungsbogen.Bewohnerbezeichnung;

            t03Picker11.Items.Add("0 = nie");
            t03Picker11.Items.Add("1 = maximal 1x wöchentlich");
            t03Picker11.Items.Add("3 = mehrmals wöchentlich");
            t03Picker11.Items.Add("5 = täglich");

            t03Picker12.Items.Add("0 = nie");
            t03Picker12.Items.Add("1 = maximal 1x wöchentlich");
            t03Picker12.Items.Add("3 = mehrmals wöchentlich");
            t03Picker12.Items.Add("5 = täglich");

            t03Picker13.Items.Add("0 = nie");
            t03Picker13.Items.Add("1 = maximal 1x wöchentlich");
            t03Picker13.Items.Add("3 = mehrmals wöchentlich");
            t03Picker13.Items.Add("5 = täglich");
        }

        //Before page gets loaded this opertion is performed
        protected override async void OnAppearing()
        {
            base.OnAppearing();

            try
            {
                //ActivityIndicator = Loading...
                IsLoading = true;

                //WebRequest req = WebRequest.Create(DBManagement.DBConnection + "tbl_form_ebqe_t03_03_read.php");

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

                //string s = await reader.ReadToEndAsync();

                //string[] split = s.Split(new char[] { ':' });

                //if (split[0] != "" && split[1] != "" && split[2] != "")
                //{
                //    InitialDataIsEmpty = false;
                //}

                //Erfassungsbogen.t03field11 = split[0];
                //Erfassungsbogen.t03field12 = split[1];
                //Erfassungsbogen.t03field13 = split[2];

                if (Erfassungsbogen.t03field11 == "0")
                {
                    t03Picker11.SelectedIndex = 0;                         // rb1 is the image file with checked box image
                }
                else if (Erfassungsbogen.t03field11 == "1")
                {
                    t03Picker11.SelectedIndex = 1;
                }
                else if (Erfassungsbogen.t03field11 == "5")
                {
                    t03Picker11.SelectedIndex = 3;
                }
                else if (Erfassungsbogen.t03field11 == "3")
                {
                    t03Picker11.SelectedIndex = 2;
                }
                else
                {
                    t03Picker11.SelectedIndex = -1;
                }

                if (Erfassungsbogen.t03field12 == "0")
                {
                    t03Picker12.SelectedIndex = 0; // rb1 is the image file with checked box image
                }
                else if (Erfassungsbogen.t03field12 == "1")
                {
                    t03Picker12.SelectedIndex = 1;
                }
                else if (Erfassungsbogen.t03field12 == "5")
                {
                    t03Picker12.SelectedIndex = 3;
                }
                else if (Erfassungsbogen.t03field12 == "3")
                {
                    t03Picker12.SelectedIndex = 2;
                }
                else
                {
                    t03Picker12.SelectedIndex = -1;
                }

                if (Erfassungsbogen.t03field13 == "0")
                {
                    t03Picker13.SelectedIndex = 0; // rb1 is the image file with checked box image
                }
                else if (Erfassungsbogen.t03field13 == "1")
                {
                    t03Picker13.SelectedIndex = 1;
                }
                else if (Erfassungsbogen.t03field13 == "5")
                {
                    t03Picker13.SelectedIndex = 3;
                }
                else if (Erfassungsbogen.t03field13 == "3")
                {
                    t03Picker13.SelectedIndex = 2;
                }
                else
                {
                    t03Picker13.SelectedIndex = -1;
                }
                //ActivityIndicator = Idle
                IsLoading = false;

            }
            catch (Exception)
            {
                await DisplayAlert(AppResources.AppError, AppResources.AppErrorMsg, "OK");
            }
        }

        private void T03Picker11_SelectedIndexChanged(object sender, EventArgs e)
        {
            // T03 11

            if (t03Picker11.SelectedIndex == 0)
            {
                Erfassungsbogen.t03field11 = "0";
            }
            else if (t03Picker11.SelectedIndex == 1)
            {
                Erfassungsbogen.t03field11 = "1";
            }
            else if (t03Picker11.SelectedIndex == 2)
            {
                Erfassungsbogen.t03field11 = "3";
            }
            else if (t03Picker11.SelectedIndex == 3)
            {
                Erfassungsbogen.t03field11 = "5";
            }
        }

        private void T03Picker12_SelectedIndexChanged(object sender, EventArgs e)
        {
            // T03 12
            if (t03Picker12.SelectedIndex == 0)
            {
                Erfassungsbogen.t03field12 = "0";
            }
            else if (t03Picker12.SelectedIndex == 1)
            {
                Erfassungsbogen.t03field12 = "1";
            }
            else if (t03Picker12.SelectedIndex == 2)
            {
                Erfassungsbogen.t03field12 = "3";
            }
            else if (t03Picker12.SelectedIndex == 3)
            {
                Erfassungsbogen.t03field12 = "5";
            }
        }

        private void T03Picker13_SelectedIndexChanged(object sender, EventArgs e)
        {
            // T03 13
            if (t03Picker13.SelectedIndex == 0)
            {
                Erfassungsbogen.t03field13 = "0";
            }
            else if (t03Picker13.SelectedIndex == 1)
            {
                Erfassungsbogen.t03field13 = "1";
            }
            else if (t03Picker13.SelectedIndex == 2)
            {
                Erfassungsbogen.t03field13 = "3";
            }
            else if (t03Picker13.SelectedIndex == 3)
            {
                Erfassungsbogen.t03field13 = "5";
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
                    await Navigation.PushAsync(new Verhaltensweisen_2());
                }
                else
                {
                    var BackQuestion = await DisplayAlert(AppResources.Information, AppResources.InformationSaveQuery, AppResources.Yes, AppResources.No);
                    if (BackQuestion == true)
                    {
                        t03field11.TextColor = t03field12.TextColor = t03field13.TextColor = AppManager.QuestionColor;

                        if ((Erfassungsbogen.t03field11 != "" && Erfassungsbogen.t03field11 != null) && (Erfassungsbogen.t03field12 != "" && Erfassungsbogen.t03field12 != null) && (Erfassungsbogen.t03field13 != "" && Erfassungsbogen.t03field13 != null))
                        {
                            WebRequest req = WebRequest.Create(DBManagement.DBConnection + "tbl_form_ebqe_t03_03_update.php");

                            req.Method = "POST"; //POST
                            req.Timeout = 15000;
                            req.ContentType = "application/x-www-form-urlencoded";

                            string postData = "mstr=" + App.user.selected_mstr_ebqe + "&bewonerid=" + App.user.selected_id_bewohner + "&t03field11=" + Erfassungsbogen.t03field11 + "&t03field12=" + Erfassungsbogen.t03field12 + "&t03field13=" + Erfassungsbogen.t03field13;

                            byte[] byteArray = Encoding.UTF8.GetBytes(postData);

                            req.ContentLength = byteArray.Length;

                            Stream ds = await req.GetRequestStreamAsync();
                            await ds.WriteAsync(byteArray, 0, byteArray.Length);
                            ds.Close();

                            await Navigation.PushAsync(new Verhaltensweisen_2());
                        }
                        else
                        {
                            if (Erfassungsbogen.t03field11 == "" || Erfassungsbogen.t03field11 == null)
                            {
                                t03field11.TextColor = Color.Red;
                            }
                            if (Erfassungsbogen.t03field12 == "" || Erfassungsbogen.t03field12 == null)
                            {
                                t03field12.TextColor = Color.Red;
                            }
                            if (Erfassungsbogen.t03field13 == "" || Erfassungsbogen.t03field13 == null)
                            {
                                t03field13.TextColor = Color.Red;
                            }

                            await DisplayAlert(AppResources.Warning, AppResources.FieldsUnfilled, "OK");
                            BackButton.Source = "ic_arrow_back_ios.png";
                        }
                    }
                    else
                    {
                        Erfassungsbogen.t03field11 = Erfassungsbogen.t03field12 = Erfassungsbogen.t03field13 = "";

                        WebRequest req = WebRequest.Create(DBManagement.DBConnection + "tbl_form_ebqe_t03_03_update.php");

                        req.Method = "POST"; //POST
                        req.Timeout = 15000;
                        req.ContentType = "application/x-www-form-urlencoded";

                        string postData = "mstr=" + App.user.selected_mstr_ebqe + "&bewonerid=" + App.user.selected_id_bewohner + "&t03field11=" + Erfassungsbogen.t03field11 + "&t03field12=" + Erfassungsbogen.t03field12 + "&t03field13=" + Erfassungsbogen.t03field13;

                        byte[] byteArray = Encoding.UTF8.GetBytes(postData);

                        req.ContentLength = byteArray.Length;

                        Stream ds = await req.GetRequestStreamAsync();
                        await ds.WriteAsync(byteArray, 0, byteArray.Length);
                        ds.Close();

                        await Navigation.PushAsync(new Verhaltensweisen_2());
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
                    t03field11.TextColor = t03field12.TextColor = t03field13.TextColor = AppManager.QuestionColor;

                    if ((Erfassungsbogen.t03field11 != "" && Erfassungsbogen.t03field11 != null) && (Erfassungsbogen.t03field12 != "" && Erfassungsbogen.t03field12 != null) && (Erfassungsbogen.t03field13 != "" && Erfassungsbogen.t03field13 != null))
                    {
                        WebRequest req = WebRequest.Create(DBManagement.DBConnection + "tbl_form_ebqe_t03_03_update.php");

                        req.Method = "POST"; //POST
                        req.Timeout = 15000;
                        req.ContentType = "application/x-www-form-urlencoded";

                        string postData = "mstr=" + App.user.selected_mstr_ebqe + "&bewonerid=" + App.user.selected_id_bewohner + "&t03field11=" + Erfassungsbogen.t03field11 + "&t03field12=" + Erfassungsbogen.t03field12 + "&t03field13=" + Erfassungsbogen.t03field13;

                        byte[] byteArray = Encoding.UTF8.GetBytes(postData);

                        req.ContentLength = byteArray.Length;

                        Stream ds = await req.GetRequestStreamAsync();
                        await ds.WriteAsync(byteArray, 0, byteArray.Length);
                        ds.Close();

                        await Navigation.PushAsync(new SearchPage());
                    }
                    else
                    {
                        if (Erfassungsbogen.t03field11 == "" || Erfassungsbogen.t03field11 == null)
                        {
                            t03field11.TextColor = Color.Red;
                        }
                        if (Erfassungsbogen.t03field12 == "" || Erfassungsbogen.t03field12 == null)
                        {
                            t03field12.TextColor = Color.Red;
                        }
                        if (Erfassungsbogen.t03field13 == "" || Erfassungsbogen.t03field13 == null)
                        {
                            t03field13.TextColor = Color.Red;
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
                        WebRequest req = WebRequest.Create(DBManagement.DBConnection + "tbl_form_ebqe_t03_01-03_update_clear.php");

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