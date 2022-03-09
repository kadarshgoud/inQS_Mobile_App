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
    public partial class FreiheitsentziehendeMassnahmen_2 : ContentPage, INotifyPropertyChanged
    {
        public bool InitialDataIsEmpty;

        public FreiheitsentziehendeMassnahmen_2()
        {
            InitializeComponent();
            BindingContext = this;

            BogenLabel.Text = AppResources.SurveyHeadline + " " + DBManagement.getYearCode(App.user.selected_mstr_ebqe) + " " + AppResources.SurveyHeadlineFor + " " + Erfassungsbogen.Bewohnerbezeichnung;

            t10Picker05.Items.Add("ja");
            t10Picker05.Items.Add("nein (bei nein weiter mit Frage 11)");

            t10Picker06.Items.Add("täglich");
            t10Picker06.Items.Add("mehrmals wöchentlich");
            t10Picker06.Items.Add("1x wöchentlich");
            t10Picker06.Items.Add("seltener als 1x wöchentlich");

            t10Picker07.Items.Add("ja");
            t10Picker07.Items.Add("nein");
        }

        private void T10Picker06_SelectedIndexChanged(object sender, EventArgs e)
        {
            // T10 06

            if (t10Picker06.SelectedIndex == 0)
            {
                Erfassungsbogen.t10field06 = "1";
            }
            else if (t10Picker06.SelectedIndex == 1)
            {
                Erfassungsbogen.t10field06 = "2";
            }
            else if (t10Picker06.SelectedIndex == 2)
            {
                Erfassungsbogen.t10field06 = "3";
            }
            else if (t10Picker06.SelectedIndex == 3)
            {
                Erfassungsbogen.t10field06 = "4";
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

                //WebRequest req = WebRequest.Create(DBManagement.DBConnection + "tbl_form_ebqe_t10_02_read.php");

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

                //if (split[0] != "" && split[1] != "" && split[2] != "")
                //{
                //    InitialDataIsEmpty = false;
                //}

                //Erfassungsbogen.t10field05 = split[0];

                //Erfassungsbogen.t10field06 = split[1];

                //Erfassungsbogen.t10field07 = split[2];

                if (Erfassungsbogen.t10field05 == "0")
                {
                    t10field06.IsEnabled =
                t10Picker06.IsEnabled =
                t10field07.IsEnabled =
                t10Picker07.IsEnabled = false;

                    t10field06.Opacity =
                    t10Picker06.Opacity =
                    t10field07.Opacity =
                    t10Picker07.Opacity = AppManager.AnswerDisabledOpacity;
                }

                // picker 10_05

                if (Erfassungsbogen.t10field05 == "1")
                {
                    t10Picker05.SelectedIndex = 0;                         // whether ja==0 by default or not ??
                }
                else if (Erfassungsbogen.t10field05 == "0")
                {
                    t10Picker05.SelectedIndex = 1;
                }
                else
                {
                    t10Picker05.SelectedIndex = -1;
                }

                // picker 10_06

                if (Erfassungsbogen.t10field06 == "1")
                {
                    t10Picker06.SelectedIndex = 0;      // rb1 is the image file with checked box image
                }
                else if (Erfassungsbogen.t10field06 == "2")
                {
                    t10Picker06.SelectedIndex = 1;
                }
                else if (Erfassungsbogen.t10field06 == "3")
                {
                    t10Picker06.SelectedIndex = 2;
                }
                else if (Erfassungsbogen.t10field06 == "4")
                {
                    t10Picker06.SelectedIndex = 3;
                }
                else
                {
                    t10Picker06.SelectedIndex = -1;
                }

                // 10_07

                if (Erfassungsbogen.t10field07 == "1")
                {
                    t10Picker07.SelectedIndex = 0;                         // whether ja==0 by default or not ??
                }
                else if (Erfassungsbogen.t10field07 == "0")
                {
                    t10Picker07.SelectedIndex = 1;
                }
                else
                {
                    t10Picker07.SelectedIndex = -1;
                }
                //ActivityIndicator = Idle
                IsLoading = false;

            }
            catch (Exception)
            {
                await DisplayAlert(AppResources.AppError, AppResources.AppErrorMsg, "OK");
            }
        }

        private void T10Picker07_SelectedIndexChanged(object sender, EventArgs e)
        {
            // T10 07
            if (t10Picker07.SelectedIndex == 0)
            {
                Erfassungsbogen.t10field07 = "1";
            }
            else if (t10Picker07.SelectedIndex == 1)
            {
                Erfassungsbogen.t10field07 = "0";
            }
        }

        private void T10Picker05_SelectedIndexChanged(object sender, EventArgs e)
        {
            // T09 05
            if (t10Picker05.SelectedIndex == 0)
            {
                Erfassungsbogen.t10field05 = "1";

                t10field06.IsEnabled =
                t10Picker06.IsEnabled =
                t10field07.IsEnabled =
                t10Picker07.IsEnabled = true;

                t10field06.Opacity =
                t10Picker06.Opacity =
                t10field07.Opacity =
                t10Picker07.Opacity = AppManager.AnswerOpacity;

            }
            else if (t10Picker05.SelectedIndex == 1)
            {
                Erfassungsbogen.t10field05 = "0";

                t10field06.IsEnabled =
                t10Picker06.IsEnabled =
                t10field07.IsEnabled =
                t10Picker07.IsEnabled = false;

                t10field06.Opacity =
                t10Picker06.Opacity =
                t10field07.Opacity =
                t10Picker07.Opacity = AppManager.AnswerDisabledOpacity;
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
                    await Navigation.PushAsync(new FreiheitsentziehendeMassnahmen_1());
                }
                else
                {
                    var BackQuestion = await DisplayAlert(AppResources.Information, AppResources.InformationSaveQuery, AppResources.Yes, AppResources.No);
                    if (BackQuestion == true)
                    {
                        t10field05.TextColor = t10field06.TextColor = t10field07.TextColor = AppManager.QuestionColor;

                        if ((Erfassungsbogen.t10field05 == "") || (Erfassungsbogen.t10field05 == null))
                        {
                            t10field05.TextColor = Color.Red;
                        }
                        else
                        {
                            if (Erfassungsbogen.t10field05 == "1" || (Erfassungsbogen.t10field05 == "" && Erfassungsbogen.t10field05 == null))
                            {
                                if ((Erfassungsbogen.t10field05 != "" && Erfassungsbogen.t10field05 != null) && (Erfassungsbogen.t10field06 != "" && Erfassungsbogen.t10field06 != null) && (Erfassungsbogen.t10field07 != "" && Erfassungsbogen.t10field07 != null))
                                {
                                    if (App.user.selected_mstr_ebqe == DBManagement.CurrentEvaluationID)
                                    {
                                        WebRequest req = WebRequest.Create(DBManagement.DBConnection + "tbl_form_ebqe_t10_02_update.php");

                                        req.Method = "POST"; //POST
                                        req.Timeout = 15000;
                                        req.ContentType = "application/x-www-form-urlencoded";

                                        string postData = "mstr=" + App.user.selected_mstr_ebqe + "&bewonerid=" + App.user.selected_id_bewohner + "&t10field05=" + Erfassungsbogen.t10field05 + "&t10field06=" + Erfassungsbogen.t10field06 + "&t10field07=" + Erfassungsbogen.t10field07;

                                        byte[] byteArray = Encoding.UTF8.GetBytes(postData);

                                        req.ContentLength = byteArray.Length;

                                        Stream ds = await req.GetRequestStreamAsync();
                                        await ds.WriteAsync(byteArray, 0, byteArray.Length);
                                        ds.Close();
                                    }

                                    await Navigation.PushAsync(new FreiheitsentziehendeMassnahmen_1());
                                }
                                else
                                {
                                    if (Erfassungsbogen.t10field05 == "" || Erfassungsbogen.t10field05 == null)
                                    {
                                        t10field05.TextColor = Color.Red;
                                    }
                                    if (Erfassungsbogen.t10field06 == "" || Erfassungsbogen.t10field06 == null)
                                    {
                                        t10field06.TextColor = Color.Red;
                                    }
                                    if (Erfassungsbogen.t10field07 == "" || Erfassungsbogen.t10field07 == null)
                                    {
                                        t10field07.TextColor = Color.Red;
                                    }
                                    await DisplayAlert(AppResources.Warning, AppResources.FieldsUnfilled, "OK");
                                    BackButton.Source = "ic_arrow_back_ios.png";
                                }
                            }
                            else
                            {
                                Erfassungsbogen.t10field06 = "";
                                Erfassungsbogen.t10field07 = "";

                                if (App.user.selected_mstr_ebqe == DBManagement.CurrentEvaluationID)
                                {
                                    WebRequest req = WebRequest.Create(DBManagement.DBConnection + "tbl_form_ebqe_t10_02_update.php");

                                    req.Method = "POST"; //POST
                                    req.Timeout = 15000;
                                    req.ContentType = "application/x-www-form-urlencoded";

                                    string postData = "mstr=" + App.user.selected_mstr_ebqe + "&bewonerid=" + App.user.selected_id_bewohner + "&t10field05=" + Erfassungsbogen.t10field05 + "&t10field06=" + Erfassungsbogen.t10field06 + "&t10field07=" + Erfassungsbogen.t10field07;

                                    byte[] byteArray = Encoding.UTF8.GetBytes(postData);

                                    req.ContentLength = byteArray.Length;

                                    Stream ds = await req.GetRequestStreamAsync();
                                    await ds.WriteAsync(byteArray, 0, byteArray.Length);
                                    ds.Close();
                                }

                                await Navigation.PushAsync(new FreiheitsentziehendeMassnahmen_1());
                            }
                        }
                    }
                    else
                    {
                        Erfassungsbogen.t10field05 = Erfassungsbogen.t10field06 = Erfassungsbogen.t10field07 = "";

                        WebRequest req = WebRequest.Create(DBManagement.DBConnection + "tbl_form_ebqe_t10_02_update.php");

                        req.Method = "POST"; //POST
                        req.Timeout = 15000;
                        req.ContentType = "application/x-www-form-urlencoded";

                        string postData = "mstr=" + App.user.selected_mstr_ebqe + "&bewonerid=" + App.user.selected_id_bewohner + "&t10field05=" + Erfassungsbogen.t10field05 + "&t10field06=" + Erfassungsbogen.t10field06 + "&t10field07=" + Erfassungsbogen.t10field07;

                        byte[] byteArray = Encoding.UTF8.GetBytes(postData);

                        req.ContentLength = byteArray.Length;

                        Stream ds = await req.GetRequestStreamAsync();
                        await ds.WriteAsync(byteArray, 0, byteArray.Length);
                        ds.Close();

                        await Navigation.PushAsync(new FreiheitsentziehendeMassnahmen_1());
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
                    t10field05.TextColor = t10field06.TextColor = t10field07.TextColor = AppManager.QuestionColor;

                    if ((Erfassungsbogen.t10field05 == "") || (Erfassungsbogen.t10field05 == null))
                    {
                        t10field05.TextColor = Color.Red;
                    }
                    else
                    {
                        if (Erfassungsbogen.t10field05 == "1" || (Erfassungsbogen.t10field05 == "" && Erfassungsbogen.t10field05 == null))
                        {
                            if ((Erfassungsbogen.t10field05 != "" && Erfassungsbogen.t10field05 != null) && (Erfassungsbogen.t10field06 != "" && Erfassungsbogen.t10field06 != null) && (Erfassungsbogen.t10field07 != "" && Erfassungsbogen.t10field07 != null))
                            {
                                if (App.user.selected_mstr_ebqe == DBManagement.CurrentEvaluationID)
                                {
                                    WebRequest req = WebRequest.Create(DBManagement.DBConnection + "tbl_form_ebqe_t10_02_update.php");

                                    req.Method = "POST"; //POST
                                    req.Timeout = 15000;
                                    req.ContentType = "application/x-www-form-urlencoded";

                                    string postData = "mstr=" + App.user.selected_mstr_ebqe + "&bewonerid=" + App.user.selected_id_bewohner + "&t10field05=" + Erfassungsbogen.t10field05 + "&t10field06=" + Erfassungsbogen.t10field06 + "&t10field07=" + Erfassungsbogen.t10field07;

                                    byte[] byteArray = Encoding.UTF8.GetBytes(postData);

                                    req.ContentLength = byteArray.Length;

                                    Stream ds = await req.GetRequestStreamAsync();
                                    await ds.WriteAsync(byteArray, 0, byteArray.Length);
                                    ds.Close();
                                }

                                await Navigation.PushAsync(new SearchPage());
                            }
                            else
                            {
                                if (Erfassungsbogen.t10field05 == "" || Erfassungsbogen.t10field05 == null)
                                {
                                    t10field05.TextColor = Color.Red;
                                }
                                if (Erfassungsbogen.t10field06 == "" || Erfassungsbogen.t10field06 == null)
                                {
                                    t10field06.TextColor = Color.Red;
                                }
                                if (Erfassungsbogen.t10field07 == "" || Erfassungsbogen.t10field07 == null)
                                {
                                    t10field07.TextColor = Color.Red;
                                }
                                await DisplayAlert(AppResources.Warning, AppResources.FieldsUnfilled, "OK");
                                SaveAllButton.Source = "ic_done_all.png";
                            }
                        }
                        else
                        {
                            Erfassungsbogen.t10field06 = "";
                            Erfassungsbogen.t10field07 = "";

                            if (App.user.selected_mstr_ebqe == DBManagement.CurrentEvaluationID)
                            {
                                WebRequest req = WebRequest.Create(DBManagement.DBConnection + "tbl_form_ebqe_t10_02_update.php");

                                req.Method = "POST"; //POST
                                req.Timeout = 15000;
                                req.ContentType = "application/x-www-form-urlencoded";

                                string postData = "mstr=" + App.user.selected_mstr_ebqe + "&bewonerid=" + App.user.selected_id_bewohner + "&t10field05=" + Erfassungsbogen.t10field05 + "&t10field06=" + Erfassungsbogen.t10field06 + "&t10field07=" + Erfassungsbogen.t10field07;

                                byte[] byteArray = Encoding.UTF8.GetBytes(postData);

                                req.ContentLength = byteArray.Length;

                                Stream ds = await req.GetRequestStreamAsync();
                                await ds.WriteAsync(byteArray, 0, byteArray.Length);
                                ds.Close();
                            }

                            await Navigation.PushAsync(new SearchPage());
                        }
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
                        WebRequest req = WebRequest.Create(DBManagement.DBConnection + "tbl_form_ebqe_t10_01-02_update_clear.php");

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