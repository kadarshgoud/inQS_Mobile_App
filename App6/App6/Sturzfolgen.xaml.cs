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
    public partial class Sturzfolgen : ContentPage, INotifyPropertyChanged
    {
        public bool InitialDataIsEmpty;

        public Sturzfolgen()
        {
            InitializeComponent();
            BindingContext = this;

            BogenLabel.Text = AppResources.SurveyHeadline + " " + DBManagement.getYearCode(App.user.selected_mstr_ebqe) + " " + AppResources.SurveyHeadlineFor + " " + Erfassungsbogen.Bewohnerbezeichnung;

            t09Picker01.Items.Add("ja, einmal"); // should i keep the index values or not but in database we have 0,1,2
            t09Picker01.Items.Add("ja, mehrmals");
            t09Picker01.Items.Add("nein");
        }

        private void T09Picker01_SelectedIndexChanged(object sender, EventArgs e)
        {
            //hide wenn ja block
            t09field02.IsEnabled = t09field02_1.IsEnabled = t09Image02_1.IsEnabled =
                 t09Image02_2.IsEnabled = t09field02_2.IsEnabled =
                 t09Image02_3.IsEnabled = t09field02_3.IsEnabled =
                 t09Image02_4.IsEnabled = t09field02_4.IsEnabled =
                 t09Image02_5.IsEnabled = t09field02_5.IsEnabled =
                 t09Image02_6.IsEnabled = t09field02_6.IsEnabled = true;

            t09field02.Opacity = t09field02_1.Opacity = t09Image02_1.Opacity =
                 t09Image02_2.Opacity = t09field02_2.Opacity =
                 t09Image02_3.Opacity = t09field02_3.Opacity =
                 t09Image02_4.Opacity = t09field02_4.Opacity =
                 t09Image02_5.Opacity = t09field02_5.Opacity =
                 t09Image02_6.Opacity = t09field02_6.Opacity = AppManager.QuestionOpacity;

            // T09 01
            if (t09Picker01.SelectedIndex == 0)
            {
                Erfassungsbogen.t09field01 = "1";
            }
            else if (t09Picker01.SelectedIndex == 1)
            {
                Erfassungsbogen.t09field01 = "2";
            }
            else if (t09Picker01.SelectedIndex == 2)
            {
                Erfassungsbogen.t09field01 = "0";

                //hide wenn ja block
                t09field02.IsEnabled = t09field02_1.IsEnabled = t09Image02_1.IsEnabled =
                     t09Image02_2.IsEnabled = t09field02_2.IsEnabled =
                     t09Image02_3.IsEnabled = t09field02_3.IsEnabled =
                     t09Image02_4.IsEnabled = t09field02_4.IsEnabled =
                     t09Image02_5.IsEnabled = t09field02_5.IsEnabled =
                     t09Image02_6.IsEnabled = t09field02_6.IsEnabled = false;

                t09field02.Opacity = t09field02_1.Opacity = t09Image02_1.Opacity =
                     t09Image02_2.Opacity = t09field02_2.Opacity =
                     t09Image02_3.Opacity = t09field02_3.Opacity =
                     t09Image02_4.Opacity = t09field02_4.Opacity =
                     t09Image02_5.Opacity = t09field02_5.Opacity =
                     t09Image02_6.Opacity = t09field02_6.Opacity = AppManager.QuestionDisabledOpacity;
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
                    await Navigation.PushAsync(new SearchPage());
                }
                else
                {
                    var BackQuestion = await DisplayAlert(AppResources.Information, AppResources.InformationSaveQuery, AppResources.Yes, AppResources.No);
                    if (BackQuestion == true)
                    {
                        t09field01.TextColor = t09field02.TextColor = AppManager.QuestionColor;

                        if (Erfassungsbogen.t09field01 == "" || Erfassungsbogen.t09field01 == null)
                        {
                            t09field01.TextColor = Color.Red;

                            await DisplayAlert(AppResources.Warning, AppResources.FieldsUnfilled, "OK");
                            BackButton.Source = "ic_arrow_back_ios.png";
                        }
                        else
                        {
                            if (Erfassungsbogen.t09field01 == "0")
                            {
                                WebRequest req = WebRequest.Create(DBManagement.DBConnection + "tbl_form_ebqe_t09_01_update.php");

                                req.Method = "POST"; //POST
                                req.Timeout = 15000;
                                req.ContentType = "application/x-www-form-urlencoded";

                                string postData = "mstr=" + App.user.selected_mstr_ebqe + "&bewonerid=" + App.user.selected_id_bewohner + "&t09field01=" + Erfassungsbogen.t09field01 + "&t09field02_01=" + Erfassungsbogen.t09field02_01 + "&t09field02_02=" + Erfassungsbogen.t09field02_02 + "&t09field02_03=" + Erfassungsbogen.t09field02_03 + "&t09field02_04=" + Erfassungsbogen.t09field02_04 + "&t09field02_05=" + Erfassungsbogen.t09field02_05 + "&t09field02_06=" + Erfassungsbogen.t09field02_06;
                                byte[] byteArray = Encoding.UTF8.GetBytes(postData);

                                req.ContentLength = byteArray.Length;

                                Stream ds = await req.GetRequestStreamAsync();
                                await ds.WriteAsync(byteArray, 0, byteArray.Length);
                                ds.Close();

                                await Navigation.PushAsync(new SearchPage());
                            }
                            else
                            {
                                if ((Erfassungsbogen.t09field02_01 != "" && Erfassungsbogen.t09field02_01 != null && Erfassungsbogen.t09field02_01 != "0") || (Erfassungsbogen.t09field02_02 != "" && Erfassungsbogen.t09field02_02 != null && Erfassungsbogen.t09field02_02 != "0") || (Erfassungsbogen.t09field02_03 != "" && Erfassungsbogen.t09field02_03 != null && Erfassungsbogen.t09field02_03 != "0") || (Erfassungsbogen.t09field02_04 != "" && Erfassungsbogen.t09field02_04 != null && Erfassungsbogen.t09field02_04 != "0") || (Erfassungsbogen.t09field02_05 != "" && Erfassungsbogen.t09field02_05 != null && Erfassungsbogen.t09field02_05 != "0") || (Erfassungsbogen.t09field02_06 != "" && Erfassungsbogen.t09field02_06 != null && Erfassungsbogen.t09field02_06 != "0"))
                                {
                                    WebRequest req = WebRequest.Create(DBManagement.DBConnection + "tbl_form_ebqe_t09_01_update.php");

                                    req.Method = "POST"; //POST
                                    req.Timeout = 15000;
                                    req.ContentType = "application/x-www-form-urlencoded";

                                    string postData = "mstr=" + App.user.selected_mstr_ebqe + "&bewonerid=" + App.user.selected_id_bewohner + "&t09field01=" + Erfassungsbogen.t09field01 + "&t09field02_01=" + Erfassungsbogen.t09field02_01 + "&t09field02_02=" + Erfassungsbogen.t09field02_02 + "&t09field02_03=" + Erfassungsbogen.t09field02_03 + "&t09field02_04=" + Erfassungsbogen.t09field02_04 + "&t09field02_05=" + Erfassungsbogen.t09field02_05 + "&t09field02_06=" + Erfassungsbogen.t09field02_06;
                                    byte[] byteArray = Encoding.UTF8.GetBytes(postData);

                                    req.ContentLength = byteArray.Length;

                                    Stream ds = await req.GetRequestStreamAsync();
                                    await ds.WriteAsync(byteArray, 0, byteArray.Length);
                                    ds.Close();

                                    await Navigation.PushAsync(new SearchPage());
                                }
                                else
                                {
                                    t09field02.TextColor = Color.Red;

                                    await DisplayAlert(AppResources.Warning, AppResources.FieldsUnfilled, "OK");
                                    BackButton.Source = "ic_arrow_back_ios.png";
                                }
                            }
                        }
                    }
                    else
                    {
                        Erfassungsbogen.t09field01 = Erfassungsbogen.t09field02_01 = Erfassungsbogen.t09field02_02 = Erfassungsbogen.t09field02_03 = Erfassungsbogen.t09field02_04 = Erfassungsbogen.t09field02_05 = Erfassungsbogen.t09field02_06 = "";

                        WebRequest req = WebRequest.Create(DBManagement.DBConnection + "tbl_form_ebqe_t09_01_update.php");

                        req.Method = "POST"; //POST
                        req.Timeout = 15000;
                        req.ContentType = "application/x-www-form-urlencoded";

                        string postData = "mstr=" + App.user.selected_mstr_ebqe + "&bewonerid=" + App.user.selected_id_bewohner + "&t09field01=" + Erfassungsbogen.t09field01 + "&t09field02_01=" + Erfassungsbogen.t09field02_01 + "&t09field02_02=" + Erfassungsbogen.t09field02_02 + "&t09field02_03=" + Erfassungsbogen.t09field02_03 + "&t09field02_04=" + Erfassungsbogen.t09field02_04 + "&t09field02_05=" + Erfassungsbogen.t09field02_05 + "&t09field02_06=" + Erfassungsbogen.t09field02_06;
                        byte[] byteArray = Encoding.UTF8.GetBytes(postData);

                        req.ContentLength = byteArray.Length;

                        Stream ds = await req.GetRequestStreamAsync();
                        await ds.WriteAsync(byteArray, 0, byteArray.Length);
                        ds.Close();

                        await Navigation.PushAsync(new SearchPage());
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

                //WebRequest req = WebRequest.Create(DBManagement.DBConnection + "tbl_form_ebqe_t09_01_read.php");

                //req.Method = "POST";
                //   req.Timeout = 15000;
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

                //if (split[0] != "" && split[1] != "" && split[2] != "" && split[3] != "" && split[4] != "" && split[5] != "" && split[6] != "")
                //{
                //    InitialDataIsEmpty = false;
                //}

                //Erfassungsbogen.t09field01 = split[0];
                //Erfassungsbogen.t09field02_01 = split[1];
                //Erfassungsbogen.t09field02_02 = split[2];
                //Erfassungsbogen.t09field02_03 = split[3];
                //Erfassungsbogen.t09field02_04 = split[4];
                //Erfassungsbogen.t09field02_05 = split[5];
                //Erfassungsbogen.t09field02_06 = split[6];

                //hide wenn ja block
                t09field02.IsEnabled = t09field02_1.IsEnabled = t09Image02_1.IsEnabled =
                     t09Image02_2.IsEnabled = t09field02_2.IsEnabled =
                     t09Image02_3.IsEnabled = t09field02_3.IsEnabled =
                     t09Image02_4.IsEnabled = t09field02_4.IsEnabled =
                     t09Image02_5.IsEnabled = t09field02_5.IsEnabled =
                     t09Image02_6.IsEnabled = t09field02_6.IsEnabled = true;

                t09field02.Opacity = t09field02_1.Opacity = t09Image02_1.Opacity =
                     t09Image02_2.Opacity = t09field02_2.Opacity =
                     t09Image02_3.Opacity = t09field02_3.Opacity =
                     t09Image02_4.Opacity = t09field02_4.Opacity =
                     t09Image02_5.Opacity = t09field02_5.Opacity =
                     t09Image02_6.Opacity = t09field02_6.Opacity = AppManager.QuestionOpacity;

                // picker 09_01

                if (Erfassungsbogen.t09field01 == "1")
                {
                    t09Picker01.SelectedIndex = 0;                         // rb1 is the image file with checked box image
                }
                else if (Erfassungsbogen.t09field01 == "2")
                {
                    t09Picker01.SelectedIndex = 1;
                }
                else if (Erfassungsbogen.t09field01 == "0")
                {
                    t09Picker01.SelectedIndex = 2;

                    //hide wenn ja block
                    t09field02.IsEnabled = t09field02_1.IsEnabled = t09Image02_1.IsEnabled =
                         t09Image02_2.IsEnabled = t09field02_2.IsEnabled =
                         t09Image02_3.IsEnabled = t09field02_3.IsEnabled =
                         t09Image02_4.IsEnabled = t09field02_4.IsEnabled =
                         t09Image02_5.IsEnabled = t09field02_5.IsEnabled =
                         t09Image02_6.IsEnabled = t09field02_6.IsEnabled = false;

                    t09field02.Opacity = t09field02_1.Opacity = t09Image02_1.Opacity =
                         t09Image02_2.Opacity = t09field02_2.Opacity =
                         t09Image02_3.Opacity = t09field02_3.Opacity =
                         t09Image02_4.Opacity = t09field02_4.Opacity =
                         t09Image02_5.Opacity = t09field02_5.Opacity =
                         t09Image02_6.Opacity = t09field02_6.Opacity = AppManager.QuestionDisabledOpacity;
                }
                else
                {
                    t09Picker01.SelectedIndex = -1;
                }

                // check boxes 9_02_01 -- 9_02_06

                if (Erfassungsbogen.t09field02_01 == "0")
                {
                    t09Image02_1.Source = "ic_check_box_outline_blank.png";
                }
                else if (Erfassungsbogen.t09field02_01 == "1")
                {
                    t09Image02_1.Source = "ic_check_box.png";
                }
                else
                {
                    t09Image02_1.Source = "ic_check_box_outline_blank.png";
                }

                if (Erfassungsbogen.t09field02_02 == "0")
                {
                    t09Image02_2.Source = "ic_check_box_outline_blank.png";
                }
                else if (Erfassungsbogen.t09field02_02 == "1")
                {
                    t09Image02_2.Source = "ic_check_box.png";
                }
                else
                {
                    t09Image02_2.Source = "ic_check_box_outline_blank.png";
                }
                if (Erfassungsbogen.t09field02_03 == "0")
                {
                    t09Image02_3.Source = "ic_check_box_outline_blank.png";
                }
                else if (Erfassungsbogen.t09field02_03 == "1")
                {
                    t09Image02_3.Source = "ic_check_box.png";
                }
                else
                {
                    t09Image02_3.Source = "ic_check_box_outline_blank.png";
                }
                if (Erfassungsbogen.t09field02_04 == "0")
                {
                    t09Image02_4.Source = "ic_check_box_outline_blank.png";
                }
                else if (Erfassungsbogen.t09field02_04 == "1")
                {
                    t09Image02_4.Source = "ic_check_box.png";
                }
                else
                {
                    t09Image02_4.Source = "ic_check_box_outline_blank.png";
                }
                if (Erfassungsbogen.t09field02_05 == "0")
                {
                    t09Image02_5.Source = "ic_check_box_outline_blank.png";
                }
                else if (Erfassungsbogen.t09field02_05 == "1")
                {
                    t09Image02_5.Source = "ic_check_box.png";
                }
                else
                {
                    t09Image02_5.Source = "ic_check_box_outline_blank.png";
                }
                if (Erfassungsbogen.t09field02_06 == "0")
                {
                    t09Image02_6.Source = "ic_check_box_outline_blank.png";
                }
                else if (Erfassungsbogen.t09field02_06 == "1")
                {
                    t09Image02_6.Source = "ic_check_box.png";
                }
                else
                {
                    t09Image02_6.Source = "ic_check_box_outline_blank.png";
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
                    t09field01.TextColor = t09field02.TextColor = AppManager.QuestionColor;

                    if (Erfassungsbogen.t09field01 == "" || Erfassungsbogen.t09field01 == null)
                    {
                        t09field01.TextColor = Color.Red;

                        await DisplayAlert(AppResources.Warning, AppResources.FieldsUnfilled, "OK");
                        SaveAllButton.Source = "ic_done_all.png";
                    }
                    else
                    {
                        if (Erfassungsbogen.t09field01 == "0")
                        {
                            WebRequest req = WebRequest.Create(DBManagement.DBConnection + "tbl_form_ebqe_t09_01_update.php");

                            req.Method = "POST"; //POST
                            req.Timeout = 15000;
                            req.ContentType = "application/x-www-form-urlencoded";

                            string postData = "mstr=" + App.user.selected_mstr_ebqe + "&bewonerid=" + App.user.selected_id_bewohner + "&t09field01=" + Erfassungsbogen.t09field01 + "&t09field02_01=" + Erfassungsbogen.t09field02_01 + "&t09field02_02=" + Erfassungsbogen.t09field02_02 + "&t09field02_03=" + Erfassungsbogen.t09field02_03 + "&t09field02_04=" + Erfassungsbogen.t09field02_04 + "&t09field02_05=" + Erfassungsbogen.t09field02_05 + "&t09field02_06=" + Erfassungsbogen.t09field02_06;
                            byte[] byteArray = Encoding.UTF8.GetBytes(postData);

                            req.ContentLength = byteArray.Length;

                            Stream ds = await req.GetRequestStreamAsync();
                            await ds.WriteAsync(byteArray, 0, byteArray.Length);
                            ds.Close();

                            await Navigation.PushAsync(new SearchPage());
                        }
                        else
                        {
                            if ((Erfassungsbogen.t09field02_01 != "" && Erfassungsbogen.t09field02_01 != null && Erfassungsbogen.t09field02_01 != "0") || (Erfassungsbogen.t09field02_02 != "" && Erfassungsbogen.t09field02_02 != null && Erfassungsbogen.t09field02_02 != "0") || (Erfassungsbogen.t09field02_03 != "" && Erfassungsbogen.t09field02_03 != null && Erfassungsbogen.t09field02_03 != "0") || (Erfassungsbogen.t09field02_04 != "" && Erfassungsbogen.t09field02_04 != null && Erfassungsbogen.t09field02_04 != "0") || (Erfassungsbogen.t09field02_05 != "" && Erfassungsbogen.t09field02_05 != null && Erfassungsbogen.t09field02_05 != "0") || (Erfassungsbogen.t09field02_06 != "" && Erfassungsbogen.t09field02_06 != null && Erfassungsbogen.t09field02_06 != "0"))
                            {
                                WebRequest req = WebRequest.Create(DBManagement.DBConnection + "tbl_form_ebqe_t09_01_update.php");

                                req.Method = "POST"; //POST
                                req.Timeout = 15000;
                                req.ContentType = "application/x-www-form-urlencoded";

                                string postData = "mstr=" + App.user.selected_mstr_ebqe + "&bewonerid=" + App.user.selected_id_bewohner + "&t09field01=" + Erfassungsbogen.t09field01 + "&t09field02_01=" + Erfassungsbogen.t09field02_01 + "&t09field02_02=" + Erfassungsbogen.t09field02_02 + "&t09field02_03=" + Erfassungsbogen.t09field02_03 + "&t09field02_04=" + Erfassungsbogen.t09field02_04 + "&t09field02_05=" + Erfassungsbogen.t09field02_05 + "&t09field02_06=" + Erfassungsbogen.t09field02_06;
                                byte[] byteArray = Encoding.UTF8.GetBytes(postData);

                                req.ContentLength = byteArray.Length;

                                Stream ds = await req.GetRequestStreamAsync();
                                await ds.WriteAsync(byteArray, 0, byteArray.Length);
                                ds.Close();

                                await Navigation.PushAsync(new SearchPage());
                            }
                            else
                            {
                                t09field02.TextColor = Color.Red;

                                await DisplayAlert(AppResources.Warning, AppResources.FieldsUnfilled, "OK");
                                SaveAllButton.Source = "ic_done_all.png";
                            }
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
                        WebRequest req = WebRequest.Create(DBManagement.DBConnection + "tbl_form_ebqe_t09_01_update_clear.php");

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

        private void TapGestureRecognizer_Tapped_1(object sender, EventArgs e)
        {
            if (Erfassungsbogen.t09field02_01 != "1" | Erfassungsbogen.t09field02_01 == null)
            {
                t09Image02_1.Source = "ic_check_box.png";
                Erfassungsbogen.t09field02_01 = "1";
            }
            else
            {
                t09Image02_1.Source = "ic_check_box_outline_blank.png";
                Erfassungsbogen.t09field02_01 = "0";
            }
        }

        private void TapGestureRecognizer_Tapped_2(object sender, EventArgs e)
        {
            if (Erfassungsbogen.t09field02_02 != "1" | Erfassungsbogen.t09field02_02 == null)
            {
                t09Image02_2.Source = "ic_check_box.png";
                Erfassungsbogen.t09field02_02 = "1";
            }
            else
            {
                t09Image02_2.Source = "ic_check_box_outline_blank.png";
                Erfassungsbogen.t09field02_02 = "0";
            }
        }

        private void TapGestureRecognizer_Tapped_3(object sender, EventArgs e)
        {
            if (Erfassungsbogen.t09field02_03 != "1" | Erfassungsbogen.t09field02_03 == null)
            {
                t09Image02_3.Source = "ic_check_box.png";
                Erfassungsbogen.t09field02_03 = "1";
            }
            else
            {
                t09Image02_3.Source = "ic_check_box_outline_blank.png";
                Erfassungsbogen.t09field02_03 = "0";
            }
        }

        private void TapGestureRecognizer_Tapped_4(object sender, EventArgs e)
        {
            if (Erfassungsbogen.t09field02_04 != "1" | Erfassungsbogen.t09field02_04 == null)
            {
                t09Image02_4.Source = "ic_check_box.png";
                Erfassungsbogen.t09field02_04 = "1";
            }
            else
            {
                t09Image02_4.Source = "ic_check_box_outline_blank.png";
                Erfassungsbogen.t09field02_04 = "0";
            }
        }

        private void TapGestureRecognizer_Tapped_5(object sender, EventArgs e)
        {
            if (Erfassungsbogen.t09field02_05 != "1" | Erfassungsbogen.t09field02_05 == null)
            {
                t09Image02_5.Source = "ic_check_box.png";
                Erfassungsbogen.t09field02_05 = "1";
            }
            else
            {
                t09Image02_5.Source = "ic_check_box_outline_blank.png";
                Erfassungsbogen.t09field02_05 = "0";
            }
        }

        private void TapGestureRecognizer_Tapped_6(object sender, EventArgs e)
        {
            if (Erfassungsbogen.t09field02_06 != "1" | Erfassungsbogen.t09field02_06 == null)
            {
                t09Image02_6.Source = "ic_check_box.png";
                Erfassungsbogen.t09field02_06 = "1";
            }
            else
            {
                t09Image02_6.Source = "ic_check_box_outline_blank.png";
                Erfassungsbogen.t09field02_06 = "0";
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