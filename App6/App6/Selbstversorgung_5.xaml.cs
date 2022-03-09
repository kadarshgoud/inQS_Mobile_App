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
    public partial class Selbstversorgung_5 : ContentPage, INotifyPropertyChanged
    {
        public bool InitialDataIsEmpty;

        public Selbstversorgung_5()
        {
            InitializeComponent();
            BindingContext = this;

            BogenLabel.Text = AppResources.SurveyHeadline + " " + DBManagement.getYearCode(App.user.selected_mstr_ebqe) + " " + AppResources.SurveyHeadlineFor + " " + Erfassungsbogen.Bewohnerbezeichnung;

            t04Picker11.Items.Add("0 = selbständig");
            t04Picker11.Items.Add("1 = überwiegend selbständig");
            t04Picker11.Items.Add("2 = überwiegend unselbständig");
            t04Picker11.Items.Add("3 = unselbständig");

            t04Picker12.Items.Add("0 = selbständig");
            t04Picker12.Items.Add("1 = überwiegend selbständig");
            t04Picker12.Items.Add("2 = überwiegend unselbständig");
            t04Picker12.Items.Add("3 = unselbständig");

            t04Picker13.Items.Add("0 = Keine, nicht täglich oder nicht auf Dauer");
            t04Picker13.Items.Add("3 = ausschließlich oder nahezu ausschließlich");
            t04Picker13.Items.Add("6 = Täglich, zusätzlich zu oraler Nahrung");
        }

        //Before page gets loaded this opertion is performed
        protected override async void OnAppearing()
        {
            base.OnAppearing();

            try
            {
                //ActivityIndicator = Loading...
                IsLoading = true;

               /* WebRequest req = WebRequest.Create(DBManagement.DBConnection + "tbl_form_ebqe_t04_05_read.php");

                req.Method = "POST";
                req.Timeout = 15000;
                req.ContentType = "application/x-www-form-urlencoded";

                string postData = "id=" + App.user.selected_mstr_ebqe + "&einrichtung=" + App.user.id_org_einrichtung +
                                    "&wohnbereich=" + App.user.id_org_wohnbereich + "&bewonerid=" + App.user.selected_id_bewohner;
                byte[] byteArray = Encoding.UTF8.GetBytes(postData);

                req.ContentLength = byteArray.Length;

                Stream ds = await req.GetRequestStreamAsync();
                await ds.WriteAsync(byteArray, 0, byteArray.Length);
                ds.Close();

                WebResponse response = await req.GetResponseAsync();

                Stream dataStream = response.GetResponseStream();

                StreamReader reader = new StreamReader(dataStream);

                string s = reader.ReadToEnd();

                string[] split = s.Split(new char[] { ':' });

                if (split[0] != "" && split[1] != "" && split[2] != "")
                {
                    InitialDataIsEmpty = false;
                }

                Erfassungsbogen.t04field11 = split[0];
                Erfassungsbogen.t04field12 = split[1];
                Erfassungsbogen.t04field13 = split[2];*/

                if (Erfassungsbogen.t04field11 == "0")
                {
                    t04Picker11.SelectedIndex = 0; // rb1 is the image file with checked box image
                }
                else if (Erfassungsbogen.t04field11 == "1")
                {
                    t04Picker11.SelectedIndex = 1;
                }
                else if (Erfassungsbogen.t04field11 == "2")
                {
                    t04Picker11.SelectedIndex = 2;
                }
                else if (Erfassungsbogen.t04field11 == "3")
                {
                    t04Picker11.SelectedIndex = 3;
                }
                else
                {
                    t04Picker11.SelectedIndex = -1;
                }
                if (Erfassungsbogen.t04field12 == "0")
                {
                    t04Picker12.SelectedIndex = 0; // rb1 is the image file with checked box image
                }
                else if (Erfassungsbogen.t04field12 == "1")
                {
                    t04Picker12.SelectedIndex = 1;
                }
                else if (Erfassungsbogen.t04field12 == "2")
                {
                    t04Picker12.SelectedIndex = 2;
                }
                else if (Erfassungsbogen.t04field12 == "3")
                {
                    t04Picker12.SelectedIndex = 3;
                }
                else
                {
                    t04Picker12.SelectedIndex = -1;
                }

                if (Erfassungsbogen.t04field13 == "0")
                {
                    t04Picker13.SelectedIndex = 0; // rb1 is the image file with checked box image
                }
                else if (Erfassungsbogen.t04field13 == "3")
                {
                    t04Picker13.SelectedIndex = 1;
                }
                else if (Erfassungsbogen.t04field13 == "6")
                {
                    t04Picker13.SelectedIndex = 2;
                }
                else
                {
                    t04Picker13.SelectedIndex = -1;
                }
                //ActivityIndicator = Idle
                IsLoading = false;

            }
            catch (Exception)
            {
                await DisplayAlert(AppResources.AppError, AppResources.AppErrorMsg, "OK");
            }
        }

        private void T04Picker11_SelectedIndexChanged(object sender, EventArgs e)
        {
            // T05 11
            if (t04Picker11.SelectedIndex == 0)
            {
                Erfassungsbogen.t04field11 = "0";
            }
            else if (t04Picker11.SelectedIndex == 1)
            {
                Erfassungsbogen.t04field11 = "1";
            }
            else if (t04Picker11.SelectedIndex == 2)
            {
                Erfassungsbogen.t04field11 = "2";
            }
            else if (t04Picker11.SelectedIndex == 3)
            {
                Erfassungsbogen.t04field11 = "3";
            }
        }

        private void T04Picker12_SelectedIndexChanged(object sender, EventArgs e)
        {
            // T05 12
            if (t04Picker12.SelectedIndex == 0)
            {
                Erfassungsbogen.t04field12 = "0";
            }
            else if (t04Picker12.SelectedIndex == 1)
            {
                Erfassungsbogen.t04field12 = "1";
            }
            else if (t04Picker12.SelectedIndex == 2)
            {
                Erfassungsbogen.t04field12 = "2";
            }
            else if (t04Picker12.SelectedIndex == 3)
            {
                Erfassungsbogen.t04field12 = "3";
            }
        }

        private void T04Picker13_SelectedIndexChanged(object sender, EventArgs e)
        {
            // T05 13
            if (t04Picker13.SelectedIndex == 0)
            {
                Erfassungsbogen.t04field13 = "0";
            }
            else if (t04Picker13.SelectedIndex == 1)
            {
                Erfassungsbogen.t04field13 = "3";
            }
            else if (t04Picker13.SelectedIndex == 2)
            {
                Erfassungsbogen.t04field13 = "6";
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
                    await Navigation.PushAsync(new Selbstversorgung_4());
                }
                else
                {
                    var BackQuestion = await DisplayAlert(AppResources.Information, AppResources.InformationSaveQuery, AppResources.Yes, AppResources.No);
                    if (BackQuestion == true)
                    {
                        t04field11.TextColor = t04field12.TextColor = t04field13.TextColor = AppManager.QuestionColor;

                        if ((Erfassungsbogen.t04field11 != "" && Erfassungsbogen.t04field11 != null) && (Erfassungsbogen.t04field12 != "" && Erfassungsbogen.t04field12 != null) && (Erfassungsbogen.t04field13 != "" && Erfassungsbogen.t04field13 != null))
                        {
                            WebRequest req = WebRequest.Create(DBManagement.DBConnection + "tbl_form_ebqe_t04_05_update.php");

                            req.Method = "POST"; //POST
                            req.Timeout = 15000;
                            req.ContentType = "application/x-www-form-urlencoded";

                            string postData = "mstr=" + App.user.selected_mstr_ebqe + "&bewonerid=" + App.user.selected_id_bewohner + "&t04field11=" + Erfassungsbogen.t04field11 + "&t04field12=" + Erfassungsbogen.t04field12 + "&t04field13=" + Erfassungsbogen.t04field13;

                            byte[] byteArray = Encoding.UTF8.GetBytes(postData);

                            req.ContentLength = byteArray.Length;

                            Stream ds = await req.GetRequestStreamAsync();
                            await ds.WriteAsync(byteArray, 0, byteArray.Length);
                            ds.Close();

                            await Navigation.PushAsync(new Selbstversorgung_4());
                        }
                        else
                        {
                            if (Erfassungsbogen.t04field11 == "" || Erfassungsbogen.t04field11 == null)
                            {
                                t04field11.TextColor = Color.Red;
                            }
                            if (Erfassungsbogen.t04field12 == "" || Erfassungsbogen.t04field12 == null)
                            {
                                t04field12.TextColor = Color.Red;
                            }
                            if (Erfassungsbogen.t04field13 == "" || Erfassungsbogen.t04field13 == null)
                            {
                                t04field13.TextColor = Color.Red;
                            }

                            await DisplayAlert(AppResources.Warning, AppResources.FieldsUnfilled, "OK");
                            BackButton.Source = "ic_arrow_back_ios.png";
                        }
                    }
                    else
                    {
                        Erfassungsbogen.t04field11 = Erfassungsbogen.t04field12 = Erfassungsbogen.t04field13 = "";

                        WebRequest req = WebRequest.Create(DBManagement.DBConnection + "tbl_form_ebqe_t04_05_update.php");

                        req.Method = "POST"; //POST
                        req.Timeout = 15000;
                        req.ContentType = "application/x-www-form-urlencoded";

                        string postData = "mstr=" + App.user.selected_mstr_ebqe + "&bewonerid=" + App.user.selected_id_bewohner + "&t04field11=" + Erfassungsbogen.t04field11 + "&t04field12=" + Erfassungsbogen.t04field12 + "&t04field13=" + Erfassungsbogen.t04field13;

                        byte[] byteArray = Encoding.UTF8.GetBytes(postData);

                        req.ContentLength = byteArray.Length;

                        Stream ds = await req.GetRequestStreamAsync();
                        await ds.WriteAsync(byteArray, 0, byteArray.Length);
                        ds.Close();

                        await Navigation.PushAsync(new Selbstversorgung_4());
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
                    t04field11.TextColor = t04field12.TextColor = t04field13.TextColor = AppManager.QuestionColor;

                    if ((Erfassungsbogen.t04field11 != "" && Erfassungsbogen.t04field11 != null) && (Erfassungsbogen.t04field12 != "" && Erfassungsbogen.t04field12 != null) && (Erfassungsbogen.t04field13 != "" && Erfassungsbogen.t04field13 != null))
                    {
                        WebRequest req = WebRequest.Create(DBManagement.DBConnection + "tbl_form_ebqe_t04_05_update.php");

                        req.Method = "POST"; //POST
                        req.Timeout = 15000;
                        req.ContentType = "application/x-www-form-urlencoded";

                        string postData = "mstr=" + App.user.selected_mstr_ebqe + "&bewonerid=" + App.user.selected_id_bewohner + "&t04field11=" + Erfassungsbogen.t04field11 + "&t04field12=" + Erfassungsbogen.t04field12 + "&t04field13=" + Erfassungsbogen.t04field13;

                        byte[] byteArray = Encoding.UTF8.GetBytes(postData);

                        req.ContentLength = byteArray.Length;

                        Stream ds = await req.GetRequestStreamAsync();
                        await ds.WriteAsync(byteArray, 0, byteArray.Length);
                        ds.Close();

                        await Navigation.PushAsync(new SearchPage());
                    }
                    else
                    {
                        if (Erfassungsbogen.t04field11 == "" || Erfassungsbogen.t04field11 == null)
                        {
                            t04field11.TextColor = Color.Red;
                        }
                        if (Erfassungsbogen.t04field12 == "" || Erfassungsbogen.t04field12 == null)
                        {
                            t04field12.TextColor = Color.Red;
                        }
                        if (Erfassungsbogen.t04field13 == "" || Erfassungsbogen.t04field13 == null)
                        {
                            t04field13.TextColor = Color.Red;
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
                        WebRequest req = WebRequest.Create(DBManagement.DBConnection + "tbl_form_ebqe_t04_01-05_update_clear.php");

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