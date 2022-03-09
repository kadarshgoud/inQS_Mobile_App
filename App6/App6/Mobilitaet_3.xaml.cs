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
    public partial class Mobilitaet_3 : ContentPage, INotifyPropertyChanged
    {
        public bool InitialDataIsEmpty;

        public Mobilitaet_3()
        {
            InitializeComponent();
            BindingContext = this;

            BogenLabel.Text = AppResources.SurveyHeadline + " " + DBManagement.getYearCode(App.user.selected_mstr_ebqe) + " " + AppResources.SurveyHeadlineFor + " " + Erfassungsbogen.Bewohnerbezeichnung;
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
                    await Navigation.PushAsync(new Mobilitaet_2());
                }
                else
                {
                    var BackQuestion = await DisplayAlert(AppResources.Information, AppResources.InformationSaveQuery, AppResources.Yes, AppResources.No);
                    if (BackQuestion == true)
                    {
                        t01field05.TextColor = t01field06.TextColor = AppManager.QuestionColor;

                        if ((Erfassungsbogen.t01field05 != "" && Erfassungsbogen.t01field05 != null) && (Erfassungsbogen.t01field06 != "" && Erfassungsbogen.t01field06 != null))
                        {
                            WebRequest req = WebRequest.Create(DBManagement.DBConnection + "tbl_form_ebqe_t01_03_update.php");

                            req.Method = "POST"; //POST
                            req.Timeout = 15000;
                            req.ContentType = "application/x-www-form-urlencoded";

                            string postData = "mstr=" + App.user.selected_mstr_ebqe + "&bewonerid=" + App.user.selected_id_bewohner + "&t01field05=" + Erfassungsbogen.t01field05 + "&t01field06=" + Erfassungsbogen.t01field06;

                            byte[] byteArray = Encoding.UTF8.GetBytes(postData);

                            req.ContentLength = byteArray.Length;

                            Stream ds = await req.GetRequestStreamAsync();
                            await ds.WriteAsync(byteArray, 0, byteArray.Length);
                            ds.Close();

                            await Navigation.PushAsync(new Mobilitaet_2());
                        }
                        else
                        {
                            if (Erfassungsbogen.t01field05 == "" || Erfassungsbogen.t01field05 == null)
                            {
                                t01field05.TextColor = Color.Red;
                            }
                            if (Erfassungsbogen.t01field06 == "" || Erfassungsbogen.t01field06 == null)
                            {
                                t01field06.TextColor = Color.Red;
                            }
                            await DisplayAlert(AppResources.Warning, AppResources.FieldsUnfilled, "OK");
                            BackButton.Source = "ic_arrow_back_ios.png";
                        }
                    }
                    else
                    {
                        Erfassungsbogen.t01field05 = Erfassungsbogen.t01field06 = "";

                        WebRequest req = WebRequest.Create(DBManagement.DBConnection + "tbl_form_ebqe_t01_03_update.php");

                        req.Method = "POST"; //POST
                        req.Timeout = 15000;
                        req.ContentType = "application/x-www-form-urlencoded";

                        string postData = "mstr=" + App.user.selected_mstr_ebqe + "&bewonerid=" + App.user.selected_id_bewohner + "&t01field05=" + Erfassungsbogen.t01field05 + "&t01field06=" + Erfassungsbogen.t01field06;

                        byte[] byteArray = Encoding.UTF8.GetBytes(postData);

                        req.ContentLength = byteArray.Length;

                        Stream ds = await req.GetRequestStreamAsync();
                        await ds.WriteAsync(byteArray, 0, byteArray.Length);
                        ds.Close();

                        await Navigation.PushAsync(new Mobilitaet_2());
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

        //Before page gets loaded this opertion is performed
        protected override async void OnAppearing()
        {
            base.OnAppearing();

            try
            {
                //ActivityIndicator = Loading...
                IsLoading = true;

                //WebRequest req = WebRequest.Create(DBManagement.DBConnection + "tbl_form_ebqe_t01_03_read.php");

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

                //Erfassungsbogen.t01field05 = split[0];
                //Erfassungsbogen.t01field06 = split[1];

                if (Erfassungsbogen.t01field05 == "0")
                {
                    t01Image05_1.Source = "ic_rb1.png";                            // rb1 is the image file with checked box image
                }
                else if (Erfassungsbogen.t01field05 == "1")
                {
                    t01Image05_2.Source = "ic_rb1.png";
                }
                else if (Erfassungsbogen.t01field05 == "2")
                {
                    t01Image05_3.Source = "ic_rb1.png";
                }
                else if (Erfassungsbogen.t01field05 == "3")
                {
                    t01Image05_4.Source = "ic_rb1.png";
                }
                else
                {
                    t01Image05_1.Source = "ic_rb2.png";
                    t01Image05_2.Source = "ic_rb2.png";
                    t01Image05_3.Source = "ic_rb2.png";
                    t01Image05_4.Source = "ic_rb2.png";
                }

                if (Erfassungsbogen.t01field06 == "1")
                {
                    t01Image06_1.Source = "ic_rb1.png";                            // rb1 is the image file with checked box image
                }
                else if (Erfassungsbogen.t01field06 == "0")
                {
                    t01Image06_2.Source = "ic_rb1.png";
                }
                else
                {
                    t01Image06_1.Source = "ic_rb2.png";
                    t01Image06_2.Source = "ic_rb2.png";
                }
                //ActivityIndicator = Idle
                IsLoading = false;

            }
            catch (Exception)
            {
                await DisplayAlert(AppResources.AppError, AppResources.AppErrorMsg, "OK");
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
                    t01field05.TextColor = t01field06.TextColor = AppManager.QuestionColor;

                    if ((Erfassungsbogen.t01field05 != "" && Erfassungsbogen.t01field05 != null) && (Erfassungsbogen.t01field06 != "" && Erfassungsbogen.t01field06 != null))
                    {
                        WebRequest req = WebRequest.Create(DBManagement.DBConnection + "tbl_form_ebqe_t01_03_update.php");

                        req.Method = "POST"; //POST
                        req.Timeout = 15000;
                        req.ContentType = "application/x-www-form-urlencoded";

                        string postData = "mstr=" + App.user.selected_mstr_ebqe + "&bewonerid=" + App.user.selected_id_bewohner + "&t01field05=" + Erfassungsbogen.t01field05 + "&t01field06=" + Erfassungsbogen.t01field06;

                        byte[] byteArray = Encoding.UTF8.GetBytes(postData);

                        req.ContentLength = byteArray.Length;

                        Stream ds = await req.GetRequestStreamAsync();
                        await ds.WriteAsync(byteArray, 0, byteArray.Length);
                        ds.Close();

                        await Navigation.PushAsync(new SearchPage());
                    }
                    else
                    {
                        if (Erfassungsbogen.t01field05 == "" || Erfassungsbogen.t01field05 == null)
                        {
                            t01field05.TextColor = Color.Red;
                        }
                        if (Erfassungsbogen.t01field06 == "" || Erfassungsbogen.t01field06 == null)
                        {
                            t01field06.TextColor = Color.Red;
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
                        WebRequest req = WebRequest.Create(DBManagement.DBConnection + "tbl_form_ebqe_t01_01-03_update_clr.php");

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

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            if (Erfassungsbogen.t01field05 != "0" | Erfassungsbogen.t01field05 == null)
            {
                t01Image05_1.Source = "ic_rb1.png";
                t01Image05_2.Source = "ic_rb2.png";
                t01Image05_3.Source = "ic_rb2.png";
                t01Image05_4.Source = "ic_rb2.png";
                Erfassungsbogen.t01field05 = "0";
            }
            else
            {
                t01Image05_1.Source = "ic_rb2.png";
                Erfassungsbogen.t01field05 = "";
            }
        }

        private void TapGestureRecognizer_Tapped_1(object sender, EventArgs e)
        {
            if (Erfassungsbogen.t01field05 != "1" | Erfassungsbogen.t01field05 == null)
            {
                t01Image05_2.Source = "ic_rb1.png";
                t01Image05_1.Source = "ic_rb2.png";
                t01Image05_3.Source = "ic_rb2.png";
                t01Image05_4.Source = "ic_rb2.png";
                Erfassungsbogen.t01field05 = "1";
            }
            else
            {
                t01Image05_2.Source = "ic_rb2.png";
                Erfassungsbogen.t01field05 = "";
            }
        }

        private void TapGestureRecognizer_Tapped_2(object sender, EventArgs e)
        {
            if (Erfassungsbogen.t01field05 != "2" | Erfassungsbogen.t01field05 == null)
            {
                t01Image05_3.Source = "ic_rb1.png";
                t01Image05_4.Source = "ic_rb2.png";
                t01Image05_2.Source = "ic_rb2.png";
                t01Image05_1.Source = "ic_rb2.png";
                Erfassungsbogen.t01field05 = "2";
            }
            else
            {
                t01Image05_3.Source = "ic_rb2.png";
                Erfassungsbogen.t01field05 = "";
            }
        }

        private void TapGestureRecognizer_Tapped_3(object sender, EventArgs e)
        {
            if (Erfassungsbogen.t01field05 != "3" | Erfassungsbogen.t01field05 == null)
            {
                t01Image05_4.Source = "ic_rb1.png";
                t01Image05_1.Source = "ic_rb2.png";
                t01Image05_2.Source = "ic_rb2.png";
                t01Image05_3.Source = "ic_rb2.png";
                Erfassungsbogen.t01field05 = "3";
            }
            else
            {
                t01Image05_4.Source = "ic_rb2.png";
                Erfassungsbogen.t01field05 = "";
            }
        }

        private void TapGestureRecognizer_Tapped_4(object sender, EventArgs e)
        {
            if (Erfassungsbogen.t01field06 != "1" | Erfassungsbogen.t01field06 == null)
            {
                t01Image06_1.Source = "ic_rb1.png";
                t01Image06_2.Source = "ic_rb2.png";
                Erfassungsbogen.t01field06 = "1";
            }
            else
            {
                t01Image06_1.Source = "ic_rb2.png";
                Erfassungsbogen.t01field06 = "";
            }
        }

        private void TapGestureRecognizer_Tapped_5(object sender, EventArgs e)
        {
            if (Erfassungsbogen.t01field06 != "0" | Erfassungsbogen.t01field06 == null)
            {
                t01Image06_2.Source = "ic_rb1.png";
                t01Image06_1.Source = "ic_rb2.png";
                Erfassungsbogen.t01field06 = "0";
            }
            else
            {
                t01Image06_2.Source = "ic_rb2.png";
                Erfassungsbogen.t01field06 = "";
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