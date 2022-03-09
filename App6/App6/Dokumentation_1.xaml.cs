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
    public partial class Dokumentation_1 : ContentPage, INotifyPropertyChanged
    {
        public bool InitialDataIsEmpty;

        public Dokumentation_1()
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

                //WebRequest req = WebRequest.Create(DBManagement.DBConnection + "tbl_form_ebqe_t16_01_read.php");

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

                //if (split[0] != "" && split[1] != "" && split[2] != "" && split[3] != "" && split[4] != "" && split[5] != "" && split[6] != "" && split[7] != "" && split[8] != "")
                //{
                //    InitialDataIsEmpty = false;
                //}

                //Erfassungsbogen.t16field01 = split[0];

                //Erfassungsbogen.t16field02 = split[1];
                //Erfassungsbogen.t16field03 = split[2];
                //Erfassungsbogen.t16field04 = split[3];
                //Erfassungsbogen.t16field05 = split[4];
                //Erfassungsbogen.t16field06 = split[5];
                //Erfassungsbogen.t16field07 = split[6];
                //Erfassungsbogen.t16field08 = split[7];
                //Erfassungsbogen.t16field09 = split[8];

                // 3radio buttons

                if (Erfassungsbogen.t16field01 == "1")
                {
                    t16Image01_1.Source = "ic_rb1.png";                            // rb1 is the image file with checked box image
                }
                else if (Erfassungsbogen.t16field01 == "2")
                {
                    t16Image01_2.Source = "ic_rb1.png";
                }
                else if (Erfassungsbogen.t16field01 == "0" | Erfassungsbogen.t16field01 == null)
                {
                    t16Image01_3.Source = "ic_rb1.png";

                    t16field02.IsEnabled = false;
                    t16Image02_1.IsEnabled = false;
                    t16Image02_2.IsEnabled = false;
                    t16Image02_3.IsEnabled = false;
                    t16Image02_4.IsEnabled = false;
                    t16Image02_5.IsEnabled = false;
                    t16Image02_6.IsEnabled = false;
                    t16Image02_7.IsEnabled = false;
                    t16Image02_8.IsEnabled = false;

                    t16field02.Opacity = 0.3;
                    t16Image02_1.Opacity = 0.3;
                    t16Image02_2.Opacity = 0.3;
                    t16Image02_3.Opacity = 0.3;
                    t16Image02_4.Opacity = 0.3;
                    t16Image02_5.Opacity = 0.3;
                    t16Image02_6.Opacity = 0.3;
                    t16Image02_7.Opacity = 0.3;
                    t16Image02_8.Opacity = 0.3;
                }
                else
                {
                    t16Image01_1.Source = "ic_rb2.png";                             // rb2 is the image with unchecked box
                    t16Image01_2.Source = "ic_rb2.png";
                    t16Image01_3.Source = "ic_rb2.png";
                }

                // 8 check boxes

                if (Erfassungsbogen.t16field02 == "1")
                {
                    t16Image02_1.Source = "ic_check_box.png";                            // rb1 is the image file with checked box image
                }
                else
                {
                    t16Image02_1.Source = "ic_check_box_outline_blank.png";
                }

                if (Erfassungsbogen.t16field03 == "1")
                {
                    t16Image02_2.Source = "ic_check_box.png";
                }
                else
                {
                    t16Image02_2.Source = "ic_check_box_outline_blank.png";
                }


                if (Erfassungsbogen.t16field04 == "1")
                {
                    t16Image02_3.Source = "ic_check_box.png";
                }
                else
                {
                    t16Image02_3.Source = "ic_check_box_outline_blank.png";
                }

                if (Erfassungsbogen.t16field05 == "1")
                {
                    t16Image02_4.Source = "ic_check_box.png";
                }
                else
                {
                    t16Image02_4.Source = "ic_check_box_outline_blank.png";
                }

                if (Erfassungsbogen.t16field06 == "1")
                {
                    t16Image02_5.Source = "ic_check_box.png";
                }
                else
                {
                    t16Image02_5.Source = "ic_check_box_outline_blank.png";
                }
                if (Erfassungsbogen.t16field07 == "1")
                {
                    t16Image02_6.Source = "ic_check_box.png";
                }
                else
                {
                    t16Image02_6.Source = "ic_check_box_outline_blank.png";
                }
                if (Erfassungsbogen.t16field08 == "1")
                {
                    t16Image02_7.Source = "ic_check_box.png";
                }
                else
                {
                    t16Image02_7.Source = "ic_check_box_outline_blank.png";
                }
                if (Erfassungsbogen.t16field09 == "1")
                {
                    t16Image02_8.Source = "ic_check_box.png";
                }
                else
                {
                    t16Image02_8.Source = "ic_check_box_outline_blank.png";
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
                        t16field01.TextColor = t16field02.TextColor = AppManager.QuestionColor;

                        if (Erfassungsbogen.t16field01 == "" || Erfassungsbogen.t16field01 == null)
                        {
                            t16field01.TextColor = Color.Red;
                            await DisplayAlert(AppResources.Warning, AppResources.FieldsUnfilled, "OK");
                            BackButton.Source = "ic_arrow_back_ios.png";
                        }
                        else
                        {
                            if (Erfassungsbogen.t16field01 != "0")
                            {
                                if ((Erfassungsbogen.t16field02 == "" || Erfassungsbogen.t16field02 == null || Erfassungsbogen.t16field02 == "0") && (Erfassungsbogen.t16field03 == "" || Erfassungsbogen.t16field03 == null || Erfassungsbogen.t16field03 == "0") && (Erfassungsbogen.t16field04 == "" || Erfassungsbogen.t16field04 == null || Erfassungsbogen.t16field04 == "0") && (Erfassungsbogen.t16field05 == "" || Erfassungsbogen.t16field05 == null || Erfassungsbogen.t16field05 == "0") && (Erfassungsbogen.t16field06 == "" || Erfassungsbogen.t16field06 == null || Erfassungsbogen.t16field06 == "0") && (Erfassungsbogen.t16field07 == "" || Erfassungsbogen.t16field07 == null || Erfassungsbogen.t16field07 == "0") && (Erfassungsbogen.t16field08 == "" || Erfassungsbogen.t16field08 == null || Erfassungsbogen.t16field08 == "0") && (Erfassungsbogen.t16field09 == "" || Erfassungsbogen.t16field09 == null || Erfassungsbogen.t16field09 == "0"))
                                {
                                    t16field02.TextColor = Color.Red;
                                    await DisplayAlert(AppResources.Warning, AppResources.FieldsUnfilled, "OK");
                                    BackButton.Source = "ic_arrow_back_ios.png";
                                }
                                else
                                {
                                    WebRequest req = WebRequest.Create(DBManagement.DBConnection + "tbl_form_ebqe_t16_01_update.php");

                                    req.Method = "POST"; //POST
                                    req.Timeout = 15000;
                                    req.ContentType = "application/x-www-form-urlencoded";

                                    string postData = "mstr=" + App.user.selected_mstr_ebqe + "&bewonerid=" + App.user.selected_id_bewohner + "&t16field01=" + Erfassungsbogen.t16field01 + "&t16field02=" + Erfassungsbogen.t16field02 + "&t16field03=" + Erfassungsbogen.t16field03 + "&t16field04=" + Erfassungsbogen.t16field04 + "&t16field05=" + Erfassungsbogen.t16field05 + "&t16field06=" + Erfassungsbogen.t16field06 + "&t16field07=" + Erfassungsbogen.t16field07 + "&t16field08=" + Erfassungsbogen.t16field08 + "&t16field09=" + Erfassungsbogen.t16field09;

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
                                WebRequest req = WebRequest.Create(DBManagement.DBConnection + "tbl_form_ebqe_t16_01_update.php");

                                req.Method = "POST"; //POST
                                req.Timeout = 15000;
                                req.ContentType = "application/x-www-form-urlencoded";

                                string postData = "mstr=" + App.user.selected_mstr_ebqe + "&bewonerid=" + App.user.selected_id_bewohner + "&t16field01=" + Erfassungsbogen.t16field01 + "&t16field02=" + Erfassungsbogen.t16field02 + "&t16field03=" + Erfassungsbogen.t16field03 + "&t16field04=" + Erfassungsbogen.t16field04 + "&t16field05=" + Erfassungsbogen.t16field05 + "&t16field06=" + Erfassungsbogen.t16field06 + "&t16field07=" + Erfassungsbogen.t16field07 + "&t16field08=" + Erfassungsbogen.t16field08 + "&t16field09=" + Erfassungsbogen.t16field09;

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
                        Erfassungsbogen.t16field01 = Erfassungsbogen.t16field02 = Erfassungsbogen.t16field03 = Erfassungsbogen.t16field04 = Erfassungsbogen.t16field05 = Erfassungsbogen.t16field06 = Erfassungsbogen.t16field07 = Erfassungsbogen.t16field08 = Erfassungsbogen.t16field09 = "";

                        WebRequest req = WebRequest.Create(DBManagement.DBConnection + "tbl_form_ebqe_t16_01_update.php");

                        req.Method = "POST"; //POST
                        req.Timeout = 15000;
                        req.ContentType = "application/x-www-form-urlencoded";

                        string postData = "mstr=" + App.user.selected_mstr_ebqe + "&bewonerid=" + App.user.selected_id_bewohner + "&t16field01=" + Erfassungsbogen.t16field01 + "&t16field02=" + Erfassungsbogen.t16field02 + "&t16field03=" + Erfassungsbogen.t16field03 + "&t16field04=" + Erfassungsbogen.t16field04 + "&t16field05=" + Erfassungsbogen.t16field05 + "&t16field06=" + Erfassungsbogen.t16field06 + "&t16field07=" + Erfassungsbogen.t16field07 + "&t16field08=" + Erfassungsbogen.t16field08 + "&t16field09=" + Erfassungsbogen.t16field09;

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

        private async void ForwardButton_TappedAsync(object sender, EventArgs e)
        {
            ForwardButton.Source = "ic_arrow_forward_ios_tapped.png";

            try
            {
                //ActivityIndicator = Loading...
                IsLoading = true;

                if (App.user.selected_mstr_ebqe != DBManagement.CurrentEvaluationID)
                {
                    await Navigation.PushAsync(new Dokumentation_2());
                }
                else
                {
                    t16field01.TextColor = t16field02.TextColor = AppManager.QuestionColor;

                    if (Erfassungsbogen.t16field01 == "" || Erfassungsbogen.t16field01 == null)
                    {
                        t16field01.TextColor = Color.Red;
                        await DisplayAlert(AppResources.Warning, AppResources.FieldsUnfilled, "OK");
                        ForwardButton.Source = "ic_arrow_forward_ios.png";
                    }
                    else
                    {
                        if (Erfassungsbogen.t16field01 != "0")
                        {
                            if ((Erfassungsbogen.t16field02 == "" || Erfassungsbogen.t16field02 == null || Erfassungsbogen.t16field02 == "0") && (Erfassungsbogen.t16field03 == "" || Erfassungsbogen.t16field03 == null || Erfassungsbogen.t16field03 == "0") && (Erfassungsbogen.t16field04 == "" || Erfassungsbogen.t16field04 == null || Erfassungsbogen.t16field04 == "0") && (Erfassungsbogen.t16field05 == "" || Erfassungsbogen.t16field05 == null || Erfassungsbogen.t16field05 == "0") && (Erfassungsbogen.t16field06 == "" || Erfassungsbogen.t16field06 == null || Erfassungsbogen.t16field06 == "0") && (Erfassungsbogen.t16field07 == "" || Erfassungsbogen.t16field07 == null || Erfassungsbogen.t16field07 == "0") && (Erfassungsbogen.t16field08 == "" || Erfassungsbogen.t16field08 == null || Erfassungsbogen.t16field08 == "0") && (Erfassungsbogen.t16field09 == "" || Erfassungsbogen.t16field09 == null || Erfassungsbogen.t16field09 == "0"))
                            {
                                t16field02.TextColor = Color.Red;
                                await DisplayAlert(AppResources.Warning, AppResources.FieldsUnfilled, "OK");
                                ForwardButton.Source = "ic_arrow_forward_ios.png";
                            }
                            else
                            {
                                WebRequest req = WebRequest.Create(DBManagement.DBConnection + "tbl_form_ebqe_t16_01_update.php");

                                req.Method = "POST"; //POST
                                req.Timeout = 15000;
                                req.ContentType = "application/x-www-form-urlencoded";

                                string postData = "mstr=" + App.user.selected_mstr_ebqe + "&bewonerid=" + App.user.selected_id_bewohner + "&t16field01=" + Erfassungsbogen.t16field01 + "&t16field02=" + Erfassungsbogen.t16field02 +
                                    "&t16field03=" + Erfassungsbogen.t16field03 + "&t16field04=" + Erfassungsbogen.t16field04 + "&t16field05=" + Erfassungsbogen.t16field05 + "&t16field06=" +
                                    Erfassungsbogen.t16field06 + "&t16field07=" + Erfassungsbogen.t16field07 + "&t16field08=" + Erfassungsbogen.t16field08 + "&t16field09=" + Erfassungsbogen.t16field09;

                                byte[] byteArray = Encoding.UTF8.GetBytes(postData);

                                req.ContentLength = byteArray.Length;

                                Stream ds = await req.GetRequestStreamAsync();
                                await ds.WriteAsync(byteArray, 0, byteArray.Length);
                                ds.Close();

                                await Navigation.PushAsync(new Dokumentation_2());
                            }
                        }
                        else
                        {
                            WebRequest req = WebRequest.Create(DBManagement.DBConnection + "tbl_form_ebqe_t16_01_update.php");

                            req.Method = "POST"; //POST
                            req.Timeout = 15000;
                            req.ContentType = "application/x-www-form-urlencoded";

                            string postData = "mstr=" + App.user.selected_mstr_ebqe + "&bewonerid=" + App.user.selected_id_bewohner + "&t16field01=" + Erfassungsbogen.t16field01 + "&t16field02=" + Erfassungsbogen.t16field02 +
                                "&t16field03=" + Erfassungsbogen.t16field03 + "&t16field04=" + Erfassungsbogen.t16field04 + "&t16field05=" + Erfassungsbogen.t16field05 + "&t16field06=" +
                                Erfassungsbogen.t16field06 + "&t16field07=" + Erfassungsbogen.t16field07 + "&t16field08=" + Erfassungsbogen.t16field08 + "&t16field09=" + Erfassungsbogen.t16field09;

                            byte[] byteArray = Encoding.UTF8.GetBytes(postData);

                            req.ContentLength = byteArray.Length;

                            Stream ds = await req.GetRequestStreamAsync();
                            await ds.WriteAsync(byteArray, 0, byteArray.Length);
                            ds.Close();

                            await Navigation.PushAsync(new Dokumentation_2());

                        }
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

        private void TapGestureRecognizer_Tapped_13(object sender, EventArgs e)
        {
            if (Erfassungsbogen.t16field01 != "1" | Erfassungsbogen.t16field01 == null)
            {
                t16Image01_1.Source = "ic_rb1.png";
                t16Image01_2.Source = "ic_rb2.png";
                t16Image01_3.Source = "ic_rb2.png";
                Erfassungsbogen.t16field01 = "1";

                t16field02.IsEnabled =
                t16Image02_1.IsEnabled =
                t16Image02_2.IsEnabled =
                t16Image02_3.IsEnabled =
                t16Image02_4.IsEnabled =
                t16Image02_5.IsEnabled =
                t16Image02_6.IsEnabled =
                t16Image02_7.IsEnabled =
                t16Image02_8.IsEnabled = true;

                t16field02_1.IsEnabled =
                t16field02_2.IsEnabled =
                t16field02_3.IsEnabled =
                t16field02_4.IsEnabled =
                t16field02_5.IsEnabled =
                t16field02_6.IsEnabled =
                t16field02_7.IsEnabled =
                t16field02_8.IsEnabled = true;

                t16field02.Opacity =
                t16Image02_1.Opacity =
                t16Image02_2.Opacity =
                t16Image02_3.Opacity =
                t16Image02_4.Opacity =
                t16Image02_5.Opacity =
                t16Image02_6.Opacity =
                t16Image02_7.Opacity =
                t16Image02_8.Opacity = AppManager.QuestionOpacity;

                t16field02_1.Opacity =
                t16field02_2.Opacity =
                t16field02_3.Opacity =
                t16field02_4.Opacity =
                t16field02_5.Opacity =
                t16field02_6.Opacity =
                t16field02_7.Opacity =
                t16field02_8.Opacity = AppManager.QuestionOpacity;
            }
            else
            {
                t16Image01_1.Source = "ic_rb2.png";
                Erfassungsbogen.t16field01 = "";
            }
        }

        private void TapGestureRecognizer_Tapped_9(object sender, EventArgs e)
        {
            if (Erfassungsbogen.t16field01 != "2" | Erfassungsbogen.t16field01 == null)
            {
                t16Image01_2.Source = "ic_rb1.png";
                t16Image01_1.Source = "ic_rb2.png";
                t16Image01_3.Source = "ic_rb2.png";
                Erfassungsbogen.t16field01 = "2";

                t16field02.IsEnabled =
                t16Image02_1.IsEnabled =
                t16Image02_2.IsEnabled =
                t16Image02_3.IsEnabled =
                t16Image02_4.IsEnabled =
                t16Image02_5.IsEnabled =
                t16Image02_6.IsEnabled =
                t16Image02_7.IsEnabled =
                t16Image02_8.IsEnabled = true;

                t16field02_1.IsEnabled =
                t16field02_2.IsEnabled =
                t16field02_3.IsEnabled =
                t16field02_4.IsEnabled =
                t16field02_5.IsEnabled =
                t16field02_6.IsEnabled =
                t16field02_7.IsEnabled =
                t16field02_8.IsEnabled = true;

                t16field02.Opacity =
                t16Image02_1.Opacity =
                t16Image02_2.Opacity =
                t16Image02_3.Opacity =
                t16Image02_4.Opacity =
                t16Image02_5.Opacity =
                t16Image02_6.Opacity =
                t16Image02_7.Opacity =
                t16Image02_8.Opacity = AppManager.QuestionOpacity;

                t16field02_1.Opacity =
                t16field02_2.Opacity =
                t16field02_3.Opacity =
                t16field02_4.Opacity =
                t16field02_5.Opacity =
                t16field02_6.Opacity =
                t16field02_7.Opacity =
                t16field02_8.Opacity = AppManager.QuestionOpacity;
            }
            else
            {
                t16Image01_2.Source = "ic_rb2.png";
                Erfassungsbogen.t16field01 = "";
            }
        }

        private void TapGestureRecognizer_Tapped_10(object sender, EventArgs e)
        {
            if (Erfassungsbogen.t16field01 != "0" | Erfassungsbogen.t16field01 == null)
            {
                t16Image01_3.Source = "ic_rb1.png";
                t16Image01_1.Source = "ic_rb2.png";
                t16Image01_2.Source = "ic_rb2.png";
                Erfassungsbogen.t16field01 = "0";

                t16field02.IsEnabled =
                t16Image02_1.IsEnabled =
                t16Image02_2.IsEnabled =
                t16Image02_3.IsEnabled =
                t16Image02_4.IsEnabled =
                t16Image02_5.IsEnabled =
                t16Image02_6.IsEnabled =
                t16Image02_7.IsEnabled =
                t16Image02_8.IsEnabled = false;

                t16field02_1.IsEnabled =
                t16field02_2.IsEnabled =
                t16field02_3.IsEnabled =
                t16field02_4.IsEnabled =
                t16field02_5.IsEnabled =
                t16field02_6.IsEnabled =
                t16field02_7.IsEnabled =
                t16field02_8.IsEnabled = false;

                t16field02.Opacity =
                t16Image02_1.Opacity =
                t16Image02_2.Opacity =
                t16Image02_3.Opacity =
                t16Image02_4.Opacity =
                t16Image02_5.Opacity =
                t16Image02_6.Opacity =
                t16Image02_7.Opacity =
                t16Image02_8.Opacity = AppManager.QuestionDisabledOpacity;

                t16field02_1.Opacity =
                t16field02_2.Opacity =
                t16field02_3.Opacity =
                t16field02_4.Opacity =
                t16field02_5.Opacity =
                t16field02_6.Opacity =
                t16field02_7.Opacity =
                t16field02_8.Opacity = AppManager.QuestionDisabledOpacity;
            }
            else
            {
                t16Image01_3.Source = "ic_rb2.png";
                Erfassungsbogen.t16field01 = "";
            }
        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {

            if (Erfassungsbogen.t16field02 != "1" | Erfassungsbogen.t16field02 == null)
            {
                t16Image02_1.Source = "ic_check_box.png";
                Erfassungsbogen.t16field02 = "1";
            }
            else
            {
                t16Image02_1.Source = "ic_check_box_outline_blank.png";
                Erfassungsbogen.t16field02 = "0";
            }

        }

        private void TapGestureRecognizer_Tapped_1(object sender, EventArgs e)
        {
            if (Erfassungsbogen.t16field03 != "1" | Erfassungsbogen.t16field03 == null)
            {
                t16Image02_2.Source = "ic_check_box.png";
                Erfassungsbogen.t16field03 = "1";
            }
            else
            {
                t16Image02_2.Source = "ic_check_box_outline_blank.png";
                Erfassungsbogen.t16field03 = "0";
            }
        }

        private void TapGestureRecognizer_Tapped_2(object sender, EventArgs e)
        {
            if (Erfassungsbogen.t16field04 != "1" | Erfassungsbogen.t16field04 == null)
            {
                t16Image02_3.Source = "ic_check_box.png";
                Erfassungsbogen.t16field04 = "1";
            }
            else
            {
                t16Image02_3.Source = "ic_check_box_outline_blank.png";
                Erfassungsbogen.t16field04 = "0";
            }
        }

        private void TapGestureRecognizer_Tapped_3(object sender, EventArgs e)
        {

            if (Erfassungsbogen.t16field05 != "1" | Erfassungsbogen.t16field05 == null)
            {
                t16Image02_4.Source = "ic_check_box.png";
                Erfassungsbogen.t16field05 = "1";
            }
            else
            {
                t16Image02_4.Source = "ic_check_box_outline_blank.png";
                Erfassungsbogen.t16field05 = "0";
            }
        }

        private void TapGestureRecognizer_Tapped_4(object sender, EventArgs e)
        {
            if (Erfassungsbogen.t16field06 != "1" | Erfassungsbogen.t16field06 == null)
            {
                t16Image02_5.Source = "ic_check_box.png";
                Erfassungsbogen.t16field06 = "1";
            }
            else
            {
                t16Image02_5.Source = "ic_check_box_outline_blank.png";
                Erfassungsbogen.t16field06 = "0";
            }
        }

        private void TapGestureRecognizer_Tapped_5(object sender, EventArgs e)
        {
            if (Erfassungsbogen.t16field07 != "1" | Erfassungsbogen.t16field07 == null)
            {
                t16Image02_6.Source = "ic_check_box.png";
                Erfassungsbogen.t16field07 = "1";
            }
            else
            {
                t16Image02_6.Source = "ic_check_box_outline_blank.png";
                Erfassungsbogen.t16field07 = "0";
            }
        }

        private void TapGestureRecognizer_Tapped_6(object sender, EventArgs e)
        {
            if (Erfassungsbogen.t16field08 != "1" | Erfassungsbogen.t16field08 == null)
            {
                t16Image02_7.Source = "ic_check_box.png";
                Erfassungsbogen.t16field08 = "1";
            }
            else
            {
                t16Image02_7.Source = "ic_check_box_outline_blank.png";
                Erfassungsbogen.t16field08 = "0";
            }
        }

        private void TapGestureRecognizer_Tapped_7(object sender, EventArgs e)
        {
            if (Erfassungsbogen.t16field09 != "1" | Erfassungsbogen.t16field09 == null)
            {
                t16Image02_8.Source = "ic_check_box.png";
                Erfassungsbogen.t16field09 = "1";
            }
            else
            {
                t16Image02_8.Source = "ic_check_box_outline_blank.png";
                Erfassungsbogen.t16field09 = "0";
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