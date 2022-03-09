using App6.Model;
using System;
using System.IO;
using System.Net;
using System.Text;
using App6.Management;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.ComponentModel;
using App6.Resources;

namespace App6
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Bewaeltigung_6 : ContentPage, INotifyPropertyChanged
    {
        public bool InitialDataIsEmpty;

        public Bewaeltigung_6()
        {
            InitializeComponent();
            BindingContext = this;

            BogenLabel.Text = AppResources.SurveyHeadline + " " + DBManagement.getYearCode(App.user.selected_mstr_ebqe) + " " + AppResources.SurveyHeadlineFor + " " + Erfassungsbogen.Bewohnerbezeichnung;
        }

        //Before page gets loaded this opertion is performed
        protected override async void OnAppearing()
        {
            base.OnAppearing();

            try
            {
                //ActivityIndicator = Loading...
                IsLoading = true;

                //WebRequest req = WebRequest.Create(DBManagement.DBConnection + "tbl_form_ebqe_t05_06_read.php");

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

                //Erfassungsbogen.t05field16_01 = split[0];
                //Erfassungsbogen.t05field16_02 = split[1];

                // text box
                t05Entry16.Text = Erfassungsbogen.t05field16_01;

                // 5 radio butons

                if (Erfassungsbogen.t05field16_02 == "e")
                {
                    t05Image16_1.Source = "ic_rb1.png";
                    t05Entry16.IsEnabled = false;
                    t05Entry16.Text = "";
                }
                else if (Erfassungsbogen.t05field16_02 == "0")
                {
                    t05Image16_2.Source = "ic_rb1.png";
                    t05Entry16.IsEnabled = false;
                    t05Entry16.Text = "";
                }
                else if (Erfassungsbogen.t05field16_02 == "1")
                {
                    t05Image16_3.Source = "ic_rb1.png";
                    t05Entry16.IsEnabled = true;
                    t05Entry16.Text = "";
                }
                else if (Erfassungsbogen.t05field16_02 == "2")
                {
                    t05Image16_4.Source = "ic_rb1.png";
                    t05Entry16.IsEnabled = true;
                    t05Entry16.Text = "";
                }
                else if (Erfassungsbogen.t05field16_02 == "3")
                {
                    t05Image16_5.Source = "ic_rb1.png";
                    t05Entry16.IsEnabled = true;
                    t05Entry16.Text = "";
                }
                else
                {
                    t05Entry16.IsEnabled = true;
                    t05Entry16.Text = "";
                    t05Image16_1.Source = "ic_rb2.png";                             // rb2 is the image with unchecked box
                    t05Image16_2.Source = "ic_rb2.png";
                    t05Image16_3.Source = "ic_rb2.png";
                    t05Image16_4.Source = "ic_rb2.png";
                    t05Image16_5.Source = "ic_rb2.png";
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
            if (Erfassungsbogen.t05field16_02 != "e" | Erfassungsbogen.t05field16_02 == null)
            {
                t05Image16_1.Source = "ic_rb1.png";
                t05Image16_2.Source = "ic_rb2.png";
                t05Image16_3.Source = "ic_rb2.png";
                t05Image16_4.Source = "ic_rb2.png";
                t05Image16_5.Source = "ic_rb2.png";
                Erfassungsbogen.t05field16_02 = "e";
                t05Entry16.IsEnabled = false;
                t05Entry16.Text = "";
            }
            else
            {
                t05Entry16.IsEnabled = true;
                t05Image16_1.Source = "ic_rb2.png";
                Erfassungsbogen.t05field16_02 = "";
            }
        }

        private void TapGestureRecognizer_Tapped_1(object sender, EventArgs e)
        {
            if (Erfassungsbogen.t05field16_02 != "0" | Erfassungsbogen.t05field16_02 == null)
            {
                t05Image16_2.Source = "ic_rb1.png";
                t05Image16_1.Source = "ic_rb2.png";
                t05Image16_3.Source = "ic_rb2.png";
                t05Image16_4.Source = "ic_rb2.png";
                t05Image16_5.Source = "ic_rb2.png";
                Erfassungsbogen.t05field16_02 = "0";
                t05Entry16.IsEnabled = false;
                t05Entry16.Text = "";
            }
            else
            {
                t05Entry16.IsEnabled = true;
                t05Image16_2.Source = "ic_rb2.png";
                Erfassungsbogen.t05field16_02 = "";
            }
        }

        private void TapGestureRecognizer_Tapped_2(object sender, EventArgs e)
        {
            if (Erfassungsbogen.t05field16_02 != "1" | Erfassungsbogen.t05field16_02 == null)
            {
                t05Image16_3.Source = "ic_rb1.png";
                t05Image16_2.Source = "ic_rb2.png";
                t05Image16_1.Source = "ic_rb2.png";
                t05Image16_4.Source = "ic_rb2.png";
                t05Image16_5.Source = "ic_rb2.png";
                Erfassungsbogen.t05field16_02 = "1";
                t05Entry16.IsEnabled = true;
               
            }
            else
            {
                t05Entry16.IsEnabled = true;
                t05Image16_3.Source = "ic_rb2.png";
                Erfassungsbogen.t05field16_02 = "";
            }
        }

        private void TapGestureRecognizer_Tapped_3(object sender, EventArgs e)
        {
            if (Erfassungsbogen.t05field16_02 != "2" | Erfassungsbogen.t05field16_02 == null)
            {
                t05Image16_4.Source = "ic_rb1.png";
                t05Image16_2.Source = "ic_rb2.png";
                t05Image16_3.Source = "ic_rb2.png";
                t05Image16_1.Source = "ic_rb2.png";
                t05Image16_5.Source = "ic_rb2.png";
                Erfassungsbogen.t05field16_02 = "2";
                t05Entry16.IsEnabled = true;
              

            }
            else
            {
                t05Entry16.IsEnabled = true;
                t05Image16_4.Source = "ic_rb2.png";
                Erfassungsbogen.t05field16_02 = "";
            }
        }

        private void TapGestureRecognizer_Tapped_4(object sender, EventArgs e)
        {
            if (Erfassungsbogen.t05field16_02 != "3" | Erfassungsbogen.t05field16_02 == null)
            {
                t05Image16_5.Source = "ic_rb1.png";
                t05Image16_2.Source = "ic_rb2.png";
                t05Image16_3.Source = "ic_rb2.png";
                t05Image16_1.Source = "ic_rb2.png";
                t05Image16_4.Source = "ic_rb2.png";
                Erfassungsbogen.t05field16_02 = "3";
                t05Entry16.IsEnabled = true;
                
            }
            else
            {
                t05Entry16.IsEnabled = true;
                t05Image16_5.Source = "ic_rb2.png";
                Erfassungsbogen.t05field16_02 = "";
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
                    //Set Text Entry Values in Erfassungsbogen
                    Erfassungsbogen.t05field16_01 = t05Entry16.Text;

                    t05field16.TextColor = t05field16.TextColor = AppManager.QuestionColor;

                    if (Erfassungsbogen.t05field16_02 != "" && Erfassungsbogen.t05field16_02 != null)
                    {
                        if (Erfassungsbogen.t05field16_02 != "e" && Erfassungsbogen.t05field16_02 != "0")
                        {
                            if (t05Entry16.Text != "" && t05Entry16.Text != null)
                            {
                                t05Entry16.IsEnabled = true;
                                

                                WebRequest req = WebRequest.Create(DBManagement.DBConnection + "tbl_form_ebqe_t05_06_update.php");

                                req.Method = "POST"; //POST
                                req.Timeout = 15000;
                                req.ContentType = "application/x-www-form-urlencoded";

                                string postData = "mstr=" + App.user.selected_mstr_ebqe + "&bewonerid=" + App.user.selected_id_bewohner + "&t05field16_01=" + t05Entry16.Text + "&t05field16_02=" + Erfassungsbogen.t05field16_02;
                                byte[] byteArray = Encoding.UTF8.GetBytes(postData);

                                req.ContentLength = byteArray.Length;

                                Stream ds = await req.GetRequestStreamAsync();
                                await ds.WriteAsync(byteArray, 0, byteArray.Length);
                                ds.Close();

                                await Navigation.PushAsync(new SearchPage());
                            }
                            else
                            {
                                t05field16.TextColor = Color.Red;

                                await DisplayAlert(AppResources.Warning, AppResources.FieldsUnfilled, "OK");
                                SaveAllButton.Source = "ic_done_all.png";
                            }
                        }
                        else if (Erfassungsbogen.t05field16_02 == "e" || Erfassungsbogen.t05field16_02 == "0")
                            {
                            t05Entry16.IsEnabled = false;
                            t05Entry16.Text = "";
                            WebRequest req = WebRequest.Create(DBManagement.DBConnection + "tbl_form_ebqe_t05_06_update.php");

                            req.Method = "POST"; //POST
                            req.ContentType = "application/x-www-form-urlencoded";

                            string postData = "mstr=" + App.user.selected_mstr_ebqe + "&bewonerid=" + App.user.selected_id_bewohner + "&t05field16_01=" + t05Entry16.Text + "&t05field16_02=" + Erfassungsbogen.t05field16_02;
                            byte[] byteArray = Encoding.UTF8.GetBytes(postData);

                            req.ContentLength = byteArray.Length;

                            Stream ds = req.GetRequestStream();
                            ds.Write(byteArray, 0, byteArray.Length);
                            ds.Close();

                            await Navigation.PushAsync(new SearchPage());
                        }
                        else
                        {
                            t05Entry16.IsEnabled = true;
                            
                            WebRequest req = WebRequest.Create(DBManagement.DBConnection + "tbl_form_ebqe_t05_06_update.php");

                            req.Method = "POST"; //POST
                            req.Timeout = 15000;
                            req.ContentType = "application/x-www-form-urlencoded";

                            string postData = "mstr=" + App.user.selected_mstr_ebqe + "&bewonerid=" + App.user.selected_id_bewohner + "&t05field16_01=" + t05Entry16.Text + "&t05field16_02=" + Erfassungsbogen.t05field16_02;
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
                        if (Erfassungsbogen.t05field16_02 == "" || Erfassungsbogen.t05field16_02 == null)
                        {
                            t05field16.TextColor = Color.Red;
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
                        WebRequest req = WebRequest.Create(DBManagement.DBConnection + "tbl_form_ebqe_t05_01-06_update_clear.php");

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

        private async void BackButton_TappedAsync(object sender, EventArgs e)
        {
            BackButton.Source = "ic_arrow_back_ios_tapped.png";

            try
            {
                //ActivityIndicator = Loading...
                IsLoading = true;

                if (App.user.selected_mstr_ebqe != DBManagement.CurrentEvaluationID)
                {
                    await Navigation.PushAsync(new Bewaeltigung_5());
                }
                else
                {
                    var BackQuestion = await DisplayAlert(AppResources.Information, AppResources.InformationSaveQuery, AppResources.Yes, AppResources.No);
                    if (BackQuestion == true)
                    {
                        //Set Text Entry Values in Erfassungsbogen
                        Erfassungsbogen.t05field16_01 = t05Entry16.Text;

                        t05field16.TextColor = t05field16.TextColor = AppManager.QuestionColor;

                        if (Erfassungsbogen.t05field16_02 != "" && Erfassungsbogen.t05field16_02 != null)
                        {
                            if (Erfassungsbogen.t05field16_02 != "e")
                            {
                                if (t05Entry16.Text != "" && t05Entry16.Text != null)
                                {
                                    t05Entry16.IsEnabled = true;
                                    

                                    WebRequest req = WebRequest.Create(DBManagement.DBConnection + "tbl_form_ebqe_t05_06_update.php");

                                    req.Method = "POST"; //POST
                                    req.Timeout = 15000;
                                    req.ContentType = "application/x-www-form-urlencoded";

                                    string postData = "mstr=" + App.user.selected_mstr_ebqe + "&bewonerid=" + App.user.selected_id_bewohner + "&t05field16_01=" + t05Entry16.Text + "&t05field16_02=" + Erfassungsbogen.t05field16_02;
                                    byte[] byteArray = Encoding.UTF8.GetBytes(postData);

                                    req.ContentLength = byteArray.Length;

                                    Stream ds = await req.GetRequestStreamAsync();
                                    await ds.WriteAsync(byteArray, 0, byteArray.Length);
                                    ds.Close();

                                    await Navigation.PushAsync(new Bewaeltigung_5());
                                }
                                else
                                {
                                    t05field16.TextColor = Color.Red;

                                    await DisplayAlert(AppResources.Warning, AppResources.FieldsUnfilled, "OK");
                                    BackButton.Source = "ic_arrow_back_ios.png";
                                }
                            }
                            else if (Erfassungsbogen.t05field16_02 == "e" || Erfassungsbogen.t05field16_02 == "0")
                                {
                                   t05Entry16.IsEnabled = false;
                                    t05Entry16.Text = "";
                            }
                            else
                            {
                                t05Entry16.IsEnabled = true;                                

                                WebRequest req = WebRequest.Create(DBManagement.DBConnection + "tbl_form_ebqe_t05_06_update.php");

                                req.Method = "POST"; //POST
                                req.Timeout = 15000;
                                req.ContentType = "application/x-www-form-urlencoded";

                                string postData = "mstr=" + App.user.selected_mstr_ebqe + "&bewonerid=" + App.user.selected_id_bewohner + "&t05field16_01=" + t05Entry16.Text + "&t05field16_02=" + Erfassungsbogen.t05field16_02;
                                byte[] byteArray = Encoding.UTF8.GetBytes(postData);

                                req.ContentLength = byteArray.Length;

                                Stream ds = await req.GetRequestStreamAsync();
                                await ds.WriteAsync(byteArray, 0, byteArray.Length);
                                ds.Close();

                                await Navigation.PushAsync(new Bewaeltigung_5());
                            }
                        }
                        else
                        {
                            if (Erfassungsbogen.t05field16_02 == "" || Erfassungsbogen.t05field16_02 == null)
                            {
                                t05field16.TextColor = Color.Red;
                            }
                            await DisplayAlert(AppResources.Warning, AppResources.FieldsUnfilled, "OK");
                            BackButton.Source = "ic_arrow_back_ios.png";
                        }
                    }
                    else
                    {
                        Erfassungsbogen.t05field16_01 = Erfassungsbogen.t05field16_02 = "";
                        t05Entry16.Text = "";

                        WebRequest req = WebRequest.Create(DBManagement.DBConnection + "tbl_form_ebqe_t05_06_update.php");

                        req.Method = "POST"; //POST
                        req.Timeout = 15000;
                        req.ContentType = "application/x-www-form-urlencoded";

                        string postData = "mstr=" + App.user.selected_mstr_ebqe + "&bewonerid=" + App.user.selected_id_bewohner + "&t05field16_01=" + t05Entry16.Text + "&t05field16_02=" + Erfassungsbogen.t05field16_02;
                        byte[] byteArray = Encoding.UTF8.GetBytes(postData);

                        req.ContentLength = byteArray.Length;

                        Stream ds = await req.GetRequestStreamAsync();
                        await ds.WriteAsync(byteArray, 0, byteArray.Length);
                        ds.Close();

                        await Navigation.PushAsync(new Bewaeltigung_5());
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