using App6.Model;
using System;
using System.IO;
using System.Net;
using System.Text;
using App6.Management;
using Xamarin.Forms;
using System.ComponentModel;
using Xamarin.Forms.Xaml;
using App6.Resources;

namespace App6
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Bewegungseinschraenkungen : ContentPage, INotifyPropertyChanged
    {
        public bool InitialDataIsEmpty;

        public Bewegungseinschraenkungen()
        {
            InitializeComponent();
            BindingContext = this;

            BogenLabel.Text = AppResources.SurveyHeadline + " " + DBManagement.getYearCode(App.user.selected_mstr_ebqe) + " " + AppResources.SurveyHeadlineFor + " " + Erfassungsbogen.Bewohnerbezeichnung;
        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            if (Erfassungsbogen.t15field01 != "1" | Erfassungsbogen.t15field01 == null)
            {
                t15Image01_1.Source = "ic_rb1.png";
                t15Image01_2.Source = "ic_rb2.png";
                Erfassungsbogen.t15field01 = "1";
            }
            else
            {
                t15Image01_1.Source = "ic_rb2.png";
                Erfassungsbogen.t15field01 = "";
            }

            t15field02.IsEnabled =
            t15Image02_1.IsEnabled =
            t15field02_1.IsEnabled =
            t15Image02_2.IsEnabled =
            t15field02_2.IsEnabled =
            t15Image02_3.IsEnabled =
            t15field02_3.IsEnabled =
            t15Image02_4.IsEnabled =
            t15field02_4.IsEnabled =
            t15Image02_5.IsEnabled =
            t15field02_5.IsEnabled =

            t15field03.IsEnabled =
            t15Image03_1.IsEnabled =
            t15field03_1.IsEnabled =
            t15Image03_2.IsEnabled =
            t15field03_2.IsEnabled =
            t15Image03_3.IsEnabled =
            t15field03_3.IsEnabled =
            true;

            t15field02.Opacity =
            t15Image02_1.Opacity =
            t15field02_1.Opacity =
            t15Image02_2.Opacity =
            t15field02_2.Opacity =
            t15Image02_3.Opacity =
            t15field02_3.Opacity =
            t15Image02_4.Opacity =
            t15field02_4.Opacity =
            t15Image02_5.Opacity =
            t15field02_5.Opacity =
            t15field03.Opacity =
            t15Image03_1.Opacity =
            t15field03_1.Opacity =
            t15Image03_2.Opacity =
            t15field03_2.Opacity =
            t15Image03_3.Opacity =
            t15field03_3.Opacity = AppManager.QuestionOpacity;

        }

        //Before page gets loaded this opertion is performed
        protected override async void OnAppearing()
        {
            base.OnAppearing();

            try
            {
                //ActivityIndicator = Loading...
                IsLoading = true;

                //WebRequest req = WebRequest.Create(DBManagement.DBConnection + "tbl_form_ebqe_t15_01_read.php");

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

                //if (split[0] != "" && split[1] != "" && split[2] != "" && split[3] != "" && split[4] != "" && split[5] != "" && split[6] != "")
                //{
                //    InitialDataIsEmpty = false;
                //}

                //Erfassungsbogen.t15field01 = split[0];
                //Erfassungsbogen.t15field02_01 = split[1];
                //Erfassungsbogen.t15field02_02 = split[2];
                //Erfassungsbogen.t15field02_03 = split[3];
                //Erfassungsbogen.t15field02_04 = split[4];
                //Erfassungsbogen.t15field02_05 = split[5];
                //Erfassungsbogen.t15field03 = split[6];

                if (Erfassungsbogen.t15field01 == "0")
                {
                    t15field02.IsEnabled =
            t15Image02_1.IsEnabled =
            t15field02_1.IsEnabled =
            t15Image02_2.IsEnabled =
            t15field02_2.IsEnabled =
            t15Image02_3.IsEnabled =
            t15field02_3.IsEnabled =
            t15Image02_4.IsEnabled =
            t15field02_4.IsEnabled =
            t15Image02_5.IsEnabled =
            t15field02_5.IsEnabled =

            t15field03.IsEnabled =
            t15Image03_1.IsEnabled =
            t15field03_1.IsEnabled =
            t15Image03_2.IsEnabled =
            t15field03_2.IsEnabled =
            t15Image03_3.IsEnabled =
            t15field03_3.IsEnabled = false;

                    t15field02.Opacity =
                    t15Image02_1.Opacity =
                    t15field02_1.Opacity =
                    t15Image02_2.Opacity =
                    t15field02_2.Opacity =
                    t15Image02_3.Opacity =
                    t15field02_3.Opacity =
                    t15Image02_4.Opacity =
                    t15field02_4.Opacity =
                    t15Image02_5.Opacity =
                    t15field02_5.Opacity =
                    t15field03.Opacity =
                    t15Image03_1.Opacity =
                    t15field03_1.Opacity =
                    t15Image03_2.Opacity =
                    t15field03_2.Opacity =
                    t15Image03_3.Opacity =
                    t15field03_3.Opacity = 0.3;
                }

                // radio buttons 

                if (Erfassungsbogen.t15field01 == "1")
                {
                    t15Image01_1.Source = "ic_rb1.png";                            // rb1 is the image file with checked box image
                }
                else if (Erfassungsbogen.t15field01 == "0")
                {
                    t15Image01_2.Source = "ic_rb1.png";
                }

                else
                {
                    t15Image01_1.Source = "ic_rb2.png";                             // rb2 is the image with unchecked box
                    t15Image01_2.Source = "ic_rb2.png";
                }

                //  5 check boxes

                if (Erfassungsbogen.t15field02_01 == "1")
                {
                    t15Image02_1.Source = "ic_check_box.png";                            // rb1 is the image file with checked box image
                }
                else if (Erfassungsbogen.t15field02_01 == "0")
                {
                    t15Image02_1.Source = "ic_check_box_outline_blank.png";
                }
                else
                {
                    t15Image02_1.Source = "ic_check_box_outline_blank.png";
                }

                if (Erfassungsbogen.t15field02_02 == "1")
                {
                    t15Image02_2.Source = "ic_check_box.png";
                }
                else if (Erfassungsbogen.t15field02_02 == "0")
                {
                    t15Image02_2.Source = "ic_check_box_outline_blank.png";
                }
                else
                {
                    t15Image02_2.Source = "ic_check_box_outline_blank.png";
                }


                if (Erfassungsbogen.t15field02_03 == "1")
                {
                    t15Image02_3.Source = "ic_check_box.png";
                }
                else if (Erfassungsbogen.t15field02_03 == "0")
                {
                    t15Image02_3.Source = "ic_check_box_outline_blank.png";
                }
                else
                {
                    t15Image02_3.Source = "ic_check_box_outline_blank.png";
                }

                if (Erfassungsbogen.t15field02_04 == "1")
                {
                    t15Image02_4.Source = "ic_check_box.png";
                }
                else if (Erfassungsbogen.t15field02_04 == "0")
                {
                    t15Image02_4.Source = "ic_check_box_outline_blank.png";
                }
                else
                {
                    t15Image02_4.Source = "ic_check_box_outline_blank.png";
                }

                if (Erfassungsbogen.t15field02_05 == "1")
                {
                    t15Image02_5.Source = "ic_check_box.png";
                }
                else if (Erfassungsbogen.t15field02_05 == "1")
                {
                    t15Image02_5.Source = "ic_check_box_outline_blank.png";
                }
                else
                {
                    t15Image02_5.Source = "ic_check_box_outline_blank.png";
                }

                // 3 radio buttons

                if (Erfassungsbogen.t15field03 == "1")
                {
                    t15Image03_1.Source = "ic_rb1.png";                            // rb1 is the image file with checked box image
                }
                else if (Erfassungsbogen.t15field03 == "2")
                {
                    t15Image03_2.Source = "ic_rb1.png";
                }
                else if (Erfassungsbogen.t15field03 == "0")
                {
                    t15Image03_3.Source = "ic_rb1.png";
                }

                else
                {
                    t15Image03_1.Source = "ic_rb2.png";                             // rb2 is the image with unchecked box
                    t15Image03_2.Source = "ic_rb2.png";
                    t15Image03_3.Source = "ic_rb2.png";
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
            if (Erfassungsbogen.t15field01 != "0" | Erfassungsbogen.t15field01 == null)
            {
                t15Image01_2.Source = "ic_rb1.png";
                t15Image01_1.Source = "ic_rb2.png";
                Erfassungsbogen.t15field01 = "0";
            }
            else
            {
                t15Image01_2.Source = "ic_rb2.png";
                Erfassungsbogen.t15field01 = "";
            }

            t15field02.IsEnabled =
            t15Image02_1.IsEnabled =
            t15field02_1.IsEnabled =
            t15Image02_2.IsEnabled =
            t15field02_2.IsEnabled =
            t15Image02_3.IsEnabled =
            t15field02_3.IsEnabled =
            t15Image02_4.IsEnabled =
            t15field02_4.IsEnabled =
            t15Image02_5.IsEnabled =
            t15field02_5.IsEnabled =

            t15field03.IsEnabled =
            t15Image03_1.IsEnabled =
            t15field03_1.IsEnabled =
            t15Image03_2.IsEnabled =
            t15field03_2.IsEnabled =
            t15Image03_3.IsEnabled =
            t15field03_3.IsEnabled = false;

            t15field02.Opacity =
            t15Image02_1.Opacity =
            t15field02_1.Opacity =
            t15Image02_2.Opacity =
            t15field02_2.Opacity =
            t15Image02_3.Opacity =
            t15field02_3.Opacity =
            t15Image02_4.Opacity =
            t15field02_4.Opacity =
            t15Image02_5.Opacity =
            t15field02_5.Opacity =
            t15field03.Opacity =
            t15Image03_1.Opacity =
            t15field03_1.Opacity =
            t15Image03_2.Opacity =
            t15field03_2.Opacity =
            t15Image03_3.Opacity =
            t15field03_3.Opacity = AppManager.QuestionDisabledOpacity;
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
                    t15field01.TextColor = t15field02.TextColor = t15field03.TextColor = AppManager.QuestionColor;

                    if ((Erfassungsbogen.t15field01 == "") || (Erfassungsbogen.t15field01 == null))
                    {
                        t15field01.TextColor = Color.Red;
                    }
                    else
                    {
                        if (Erfassungsbogen.t15field01 == "1" || (Erfassungsbogen.t15field01 == "" && Erfassungsbogen.t15field01 == null))
                        {
                            if ((Erfassungsbogen.t15field01 != "" && Erfassungsbogen.t15field01 != null) && ((Erfassungsbogen.t15field02_01 != "" && Erfassungsbogen.t15field02_01 != null && Erfassungsbogen.t15field02_01 != "0") || (Erfassungsbogen.t15field02_02 != "" && Erfassungsbogen.t15field02_02 != null && Erfassungsbogen.t15field02_02 != "0") || (Erfassungsbogen.t15field02_03 != "" && Erfassungsbogen.t15field02_03 != null && Erfassungsbogen.t15field02_03 != "0") || (Erfassungsbogen.t15field02_04 != "" && Erfassungsbogen.t15field02_04 != null && Erfassungsbogen.t15field02_04 != "0") || (Erfassungsbogen.t15field02_05 != "" && Erfassungsbogen.t15field02_05 != null && Erfassungsbogen.t15field02_05 != "0")) && (Erfassungsbogen.t15field03 != "" && Erfassungsbogen.t15field03 != null))
                            {
                                WebRequest req = WebRequest.Create(DBManagement.DBConnection + "tbl_form_ebqe_t15_01_update.php");

                                req.Method = "POST"; //POST
                                req.Timeout = 15000;
                                req.ContentType = "application/x-www-form-urlencoded";

                                string postData = "mstr=" + App.user.selected_mstr_ebqe + "&bewonerid=" + App.user.selected_id_bewohner + "&t15field01=" + Erfassungsbogen.t15field01 + "&t15field02_01=" + Erfassungsbogen.t15field02_01 +
                                    "&t15field02_02=" + Erfassungsbogen.t15field02_02 + "&t15field02_03=" + Erfassungsbogen.t15field02_03 + "&t15field02_04=" + Erfassungsbogen.t15field02_04 + "&t15field02_05=" +
                                    Erfassungsbogen.t15field02_05 + "&t15field03=" + Erfassungsbogen.t15field03;

                                byte[] byteArray = Encoding.UTF8.GetBytes(postData);

                                req.ContentLength = byteArray.Length;

                                Stream ds = await req.GetRequestStreamAsync();
                                await ds.WriteAsync(byteArray, 0, byteArray.Length);
                                ds.Close();

                                await Navigation.PushAsync(new SearchPage());
                            }
                            else
                            {
                                if (Erfassungsbogen.t15field01 == "" || Erfassungsbogen.t15field01 == null)
                                {
                                    t15field01.TextColor = Color.Red;
                                }

                                if ((Erfassungsbogen.t15field02_01 == "" || Erfassungsbogen.t15field02_01 == null || Erfassungsbogen.t15field02_01 == "0") && (Erfassungsbogen.t15field02_02 == "" || Erfassungsbogen.t15field02_02 == null || Erfassungsbogen.t15field02_02 == "0") && (Erfassungsbogen.t15field02_03 == "" || Erfassungsbogen.t15field02_03 == null || Erfassungsbogen.t15field02_03 == "0") && (Erfassungsbogen.t15field02_04 == "" || Erfassungsbogen.t15field02_04 == null || Erfassungsbogen.t15field02_04 == "0") && (Erfassungsbogen.t15field02_05 == "" || Erfassungsbogen.t15field02_05 == null || Erfassungsbogen.t15field02_05 == "0"))
                                {
                                    t15field02.TextColor = Color.Red;
                                }

                                if (Erfassungsbogen.t15field03 == "" || Erfassungsbogen.t15field03 == null)
                                {
                                    t15field03.TextColor = Color.Red;
                                }
                                await DisplayAlert(AppResources.Warning, AppResources.FieldsUnfilled, "OK");
                                SaveAllButton.Source = "ic_done_all.png";
                            }
                        }
                        else
                        {
                            // if field1 = 0 i.e nein
                            Erfassungsbogen.t15field02_01 = "";
                            Erfassungsbogen.t15field02_02 = "";
                            Erfassungsbogen.t15field02_03 = "";
                            Erfassungsbogen.t15field02_04 = "";
                            Erfassungsbogen.t15field02_05 = "";
                            Erfassungsbogen.t15field03 = "";

                            if (App.user.selected_mstr_ebqe == DBManagement.CurrentEvaluationID)
                            {

                                WebRequest req = WebRequest.Create(DBManagement.DBConnection + "tbl_form_ebqe_t15_01_update.php");

                                req.Method = "POST"; //POST
                                req.Timeout = 15000;
                                req.ContentType = "application/x-www-form-urlencoded";

                                string postData = "mstr=" + App.user.selected_mstr_ebqe + "&bewonerid=" + App.user.selected_id_bewohner + "&t15field01=" + Erfassungsbogen.t15field01 + "&t15field02_01=" + Erfassungsbogen.t15field02_01 +
                                    "&t15field02_02=" + Erfassungsbogen.t15field02_02 + "&t15field02_03=" + Erfassungsbogen.t15field02_03 + "&t15field02_04=" + Erfassungsbogen.t15field02_04 + "&t15field02_05=" +
                                    Erfassungsbogen.t15field02_05 + "&t15field03=" + Erfassungsbogen.t15field03;

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
                        WebRequest req = WebRequest.Create(DBManagement.DBConnection + "tbl_form_ebqe_t15_01_update_clear.php");

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
                    await Navigation.PushAsync(new SearchPage());
                }
                else
                {
                    var BackQuestion = await DisplayAlert(AppResources.Information, AppResources.InformationSaveQuery, AppResources.Yes, AppResources.No);
                    if (BackQuestion == true)
                    {
                        t15field01.TextColor = t15field02.TextColor = t15field03.TextColor = AppManager.QuestionColor;

                        if ((Erfassungsbogen.t15field01 == "") || (Erfassungsbogen.t15field01 == null))
                        {
                            t15field01.TextColor = Color.Red;
                        }
                        else
                        {
                            if (Erfassungsbogen.t15field01 == "1" || (Erfassungsbogen.t15field01 == "" && Erfassungsbogen.t15field01 == null))
                            {
                                if ((Erfassungsbogen.t15field01 != "" && Erfassungsbogen.t15field01 != null) && ((Erfassungsbogen.t15field02_01 != "" && Erfassungsbogen.t15field02_01 != null && Erfassungsbogen.t15field02_01 != "0") || (Erfassungsbogen.t15field02_02 != "" && Erfassungsbogen.t15field02_02 != null && Erfassungsbogen.t15field02_02 != "0") || (Erfassungsbogen.t15field02_03 != "" && Erfassungsbogen.t15field02_03 != null && Erfassungsbogen.t15field02_03 != "0") || (Erfassungsbogen.t15field02_04 != "" && Erfassungsbogen.t15field02_04 != null && Erfassungsbogen.t15field02_04 != "0") || (Erfassungsbogen.t15field02_05 != "" && Erfassungsbogen.t15field02_05 != null && Erfassungsbogen.t15field02_05 != "0")) && (Erfassungsbogen.t15field03 != "" && Erfassungsbogen.t15field03 != null))
                                {
                                    WebRequest req = WebRequest.Create(DBManagement.DBConnection + "tbl_form_ebqe_t15_01_update.php");

                                    req.Method = "POST"; //POST
                                    req.Timeout = 15000;
                                    req.ContentType = "application/x-www-form-urlencoded";

                                    string postData = "mstr=" + App.user.selected_mstr_ebqe + "&bewonerid=" + App.user.selected_id_bewohner + "&t15field01=" + Erfassungsbogen.t15field01 + "&t15field02_01=" + Erfassungsbogen.t15field02_01 + "&t15field02_02=" + Erfassungsbogen.t15field02_02 + "&t15field02_03=" + Erfassungsbogen.t15field02_03 + "&t15field02_04=" + Erfassungsbogen.t15field02_04 + "&t15field02_05=" + Erfassungsbogen.t15field02_05 + "&t15field03=" + Erfassungsbogen.t15field03;

                                    byte[] byteArray = Encoding.UTF8.GetBytes(postData);

                                    req.ContentLength = byteArray.Length;

                                    Stream ds = await req.GetRequestStreamAsync();
                                    await ds.WriteAsync(byteArray, 0, byteArray.Length);
                                    ds.Close();

                                    await Navigation.PushAsync(new SearchPage());
                                }
                                else
                                {
                                    if (Erfassungsbogen.t15field01 == "" || Erfassungsbogen.t15field01 == null)
                                    {
                                        t15field01.TextColor = Color.Red;
                                    }

                                    if ((Erfassungsbogen.t15field02_01 == "" || Erfassungsbogen.t15field02_01 == null || Erfassungsbogen.t15field02_01 == "0") && (Erfassungsbogen.t15field02_02 == "" || Erfassungsbogen.t15field02_02 == null || Erfassungsbogen.t15field02_02 == "0") && (Erfassungsbogen.t15field02_03 == "" || Erfassungsbogen.t15field02_03 == null || Erfassungsbogen.t15field02_03 == "0") && (Erfassungsbogen.t15field02_04 == "" || Erfassungsbogen.t15field02_04 == null || Erfassungsbogen.t15field02_04 == "0") && (Erfassungsbogen.t15field02_05 == "" || Erfassungsbogen.t15field02_05 == null || Erfassungsbogen.t15field02_05 == "0"))
                                    {
                                        t15field02.TextColor = Color.Red;
                                    }

                                    if (Erfassungsbogen.t15field03 == "" || Erfassungsbogen.t15field03 == null)
                                    {
                                        t15field03.TextColor = Color.Red;
                                    }
                                    await DisplayAlert(AppResources.Warning, AppResources.FieldsUnfilled, "OK");
                                    BackButton.Source = "ic_arrow_back_ios.png";
                                }
                            }
                            else
                            {
                                // if field1 = 0 i.e nein
                                Erfassungsbogen.t15field02_01 = "";
                                Erfassungsbogen.t15field02_02 = "";
                                Erfassungsbogen.t15field02_03 = "";
                                Erfassungsbogen.t15field02_04 = "";
                                Erfassungsbogen.t15field02_05 = "";
                                Erfassungsbogen.t15field03 = "";

                                WebRequest req = WebRequest.Create(DBManagement.DBConnection + "tbl_form_ebqe_t15_01_update.php");

                                req.Method = "POST"; //POST
                                req.Timeout = 15000;
                                req.ContentType = "application/x-www-form-urlencoded";

                                string postData = "mstr=" + App.user.selected_mstr_ebqe + "&bewonerid=" + App.user.selected_id_bewohner + "&t15field01=" + Erfassungsbogen.t15field01 + "&t15field02_01=" + Erfassungsbogen.t15field02_01 + "&t15field02_02=" + Erfassungsbogen.t15field02_02 + "&t15field02_03=" + Erfassungsbogen.t15field02_03 + "&t15field02_04=" + Erfassungsbogen.t15field02_04 + "&t15field02_05=" + Erfassungsbogen.t15field02_05 + "&t15field03=" + Erfassungsbogen.t15field03;

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
                        Erfassungsbogen.t15field01 = Erfassungsbogen.t15field02_01 = Erfassungsbogen.t15field02_02 = Erfassungsbogen.t15field02_03 = Erfassungsbogen.t15field02_04 = Erfassungsbogen.t15field02_05 = Erfassungsbogen.t15field03 = "";

                        WebRequest req = WebRequest.Create(DBManagement.DBConnection + "tbl_form_ebqe_t15_01_update.php");

                        req.Method = "POST"; //POST
                        req.Timeout = 15000;
                        req.ContentType = "application/x-www-form-urlencoded";

                        string postData = "mstr=" + App.user.selected_mstr_ebqe + "&bewonerid=" + App.user.selected_id_bewohner + "&t15field01=" + Erfassungsbogen.t15field01 + "&t15field02_01=" + Erfassungsbogen.t15field02_01 + "&t15field02_02=" + Erfassungsbogen.t15field02_02 + "&t15field02_03=" + Erfassungsbogen.t15field02_03 + "&t15field02_04=" + Erfassungsbogen.t15field02_04 + "&t15field02_05=" + Erfassungsbogen.t15field02_05 + "&t15field03=" + Erfassungsbogen.t15field03;

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

        private void TapGestureRecognizer_Tapped_2(object sender, EventArgs e)
        {
            if (Erfassungsbogen.t15field02_01 == "0" | Erfassungsbogen.t15field02_01 == "" | Erfassungsbogen.t15field02_01 == null)
            {
                t15Image02_1.Source = "ic_check_box.png";
                Erfassungsbogen.t15field02_01 = "1";
            }
            else
            {
                t15Image02_1.Source = "ic_check_box_outline_blank.png";
                Erfassungsbogen.t15field02_01 = "0";
            }
        }

        private void TapGestureRecognizer_Tapped_3(object sender, EventArgs e)
        {
            if (Erfassungsbogen.t15field02_02 == "0" | Erfassungsbogen.t15field02_02 == "" | Erfassungsbogen.t15field02_02 == null)
            {
                t15Image02_2.Source = "ic_check_box.png";
                Erfassungsbogen.t15field02_02 = "1";
            }
            else
            {
                t15Image02_2.Source = "ic_check_box_outline_blank.png";
                Erfassungsbogen.t15field02_02 = "0";
            }
        }

        private void TapGestureRecognizer_Tapped_4(object sender, EventArgs e)
        {

            if (Erfassungsbogen.t15field02_04 == "0" | Erfassungsbogen.t15field02_04 == "" | Erfassungsbogen.t15field02_04 == null)
            {
                t15Image02_4.Source = "ic_check_box.png";
                Erfassungsbogen.t15field02_04 = "1";
            }
            else
            {
                t15Image02_4.Source = "ic_check_box_outline_blank.png";
                Erfassungsbogen.t15field02_04 = "0";
            }
        }

        private void TapGestureRecognizer_Tapped_5(object sender, EventArgs e)
        {
            if (Erfassungsbogen.t15field02_05 == "0" | Erfassungsbogen.t15field02_05 == "" | Erfassungsbogen.t15field02_05 == null)
            {
                t15Image02_5.Source = "ic_check_box.png";
                Erfassungsbogen.t15field02_05 = "1";
            }
            else
            {
                t15Image02_5.Source = "ic_check_box_outline_blank.png";
                Erfassungsbogen.t15field02_05 = "0";
            }
        }

        private void TapGestureRecognizer_Tapped_6(object sender, EventArgs e)
        {
            if (Erfassungsbogen.t15field03 != "1" | Erfassungsbogen.t15field03 == null)
            {
                t15Image03_1.Source = "ic_rb1.png";
                t15Image03_2.Source = "ic_rb2.png";
                t15Image03_3.Source = "ic_rb2.png";
                Erfassungsbogen.t15field03 = "1";
            }
            else
            {
                t15Image03_1.Source = "ic_rb2.png";
                Erfassungsbogen.t15field03 = "";
            }
        }

        private void TapGestureRecognizer_Tapped_7(object sender, EventArgs e)
        {
            if (Erfassungsbogen.t15field03 != "2" | Erfassungsbogen.t15field03 == null)
            {
                t15Image03_2.Source = "ic_rb1.png";
                t15Image03_1.Source = "ic_rb2.png";
                t15Image03_3.Source = "ic_rb2.png";
                Erfassungsbogen.t15field03 = "2";
            }
            else
            {
                t15Image03_2.Source = "ic_rb2.png";
                Erfassungsbogen.t15field03 = "";
            }
        }

        private void TapGestureRecognizer_Tapped_8(object sender, EventArgs e)
        {
            if (Erfassungsbogen.t15field03 != "0" | Erfassungsbogen.t15field03 == null)
            {
                t15Image03_3.Source = "ic_rb1.png";
                t15Image03_1.Source = "ic_rb2.png";
                t15Image03_2.Source = "ic_rb2.png";
                Erfassungsbogen.t15field03 = "0";
            }
            else
            {
                t15Image03_3.Source = "ic_rb2.png";
                Erfassungsbogen.t15field03 = "";
            }
        }

        private void TapGestureRecognizer_Tapped_9(object sender, EventArgs e)
        {
            if (Erfassungsbogen.t15field02_03 == "0" | Erfassungsbogen.t15field02_03 == "" | Erfassungsbogen.t15field02_03 == null)
            {
                t15Image02_3.Source = "ic_check_box.png";
                Erfassungsbogen.t15field02_03 = "1";
            }
            else
            {
                t15Image02_3.Source = "ic_check_box_outline_blank.png";
                Erfassungsbogen.t15field02_03 = "0";
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