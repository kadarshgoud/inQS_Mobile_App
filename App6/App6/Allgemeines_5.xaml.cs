using System;
using System.IO;
using System.Net;
using System.Text;
using System.ComponentModel;
using App6.Model;
using Xamarin.Forms;
using App6.Management;
using Xamarin.Forms.Xaml;
using App6.Resources;

namespace App6
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Allgemeines_5 : ContentPage, INotifyPropertyChanged
    {
        public bool InitialDataIsEmpty;

        public Allgemeines_5()
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

                //WebRequest req = WebRequest.Create(DBManagement.DBConnection + "tbl_form_ebqe_t00_05_read.php");

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

                //if (split[0] != "" && split[1] != "" && split[2] != "" && split[3] != "" && split[4] != "" && split[5] != "" && split[6] != "" && split[7] != "" && split[8] != "" && split[9] != "" && split[10] != "" && split[11] != "" && split[12] != "" && split[13] != "")
                //{
                //    InitialDataIsEmpty = false;
                //}

                //Erfassungsbogen.t00field13_1 = split[0];
                //Erfassungsbogen.t00field13_2 = split[1];
                //Erfassungsbogen.t00field13_3 = split[2];
                //Erfassungsbogen.t00field13_4 = split[3];
                //Erfassungsbogen.t00field13_5 = split[4];
                //Erfassungsbogen.t00field13_6 = split[5];
                //Erfassungsbogen.t00field13_7 = split[6];
                //Erfassungsbogen.t00field13_7_1 = split[7];
                //Erfassungsbogen.t00field13_8 = split[8];
                //Erfassungsbogen.t00field13_9 = split[9];
                //Erfassungsbogen.t00field13_10 = split[10];
                //Erfassungsbogen.t00field13_11 = split[11];
                //Erfassungsbogen.t00field13_11_1 = split[12];
                //Erfassungsbogen.t00field13_11_2 = split[13];

                // ckeck boxes 13_01 -- 13_11

                if (Erfassungsbogen.t00field13_1 == "1")
                {
                    t00Image13_01.Source = "ic_check_box.png";                            // rb1 is the image file with checked box image
                }
                else
                {
                    t00Image13_01.Source = "ic_check_box_outline_blank.png";
                }

                if (Erfassungsbogen.t00field13_2 == "1")
                {
                    t00Image13_02.Source = "ic_check_box.png";
                }
                else
                {
                    t00Image13_02.Source = "ic_check_box_outline_blank.png";
                }

                if (Erfassungsbogen.t00field13_3 == "1")
                {
                    t00Image13_03.Source = "ic_check_box.png";
                }
                else
                {
                    t00Image13_03.Source = "ic_check_box_outline_blank.png";
                }

                if (Erfassungsbogen.t00field13_4 == "1")
                {
                    t00Image13_04.Source = "ic_check_box.png";
                }
                else
                {
                    t00Image13_04.Source = "ic_check_box_outline_blank.png";
                }

                if (Erfassungsbogen.t00field13_5 == "1")
                {
                    t00Image13_05.Source = "ic_check_box.png";
                }
                else
                {
                    t00Image13_05.Source = "ic_check_box_outline_blank.png";
                }

                if (Erfassungsbogen.t00field13_6 == "1")
                {
                    t00Image13_06.Source = "ic_check_box.png";                            // rb1 is the image file with checked box image
                }
                else
                {
                    t00Image13_06.Source = "ic_check_box_outline_blank.png";
                }

                if (Erfassungsbogen.t00field13_7 == "1")
                {
                    t00Image13_07.Source = "ic_check_box.png";
                }
                else
                {
                    t00Image13_07.Source = "ic_check_box_outline_blank.png";
                }

                if (Erfassungsbogen.t00field13_7_1 == "1")
                {
                    t00Image13_08.Source = "ic_check_box.png";
                }
                else
                {
                    t00Image13_08.Source = "ic_check_box_outline_blank.png";
                }

                if (Erfassungsbogen.t00field13_8 == "1")
                {
                    t00Image13_09.Source = "ic_check_box.png";
                }
                else
                {
                    t00Image13_09.Source = "ic_check_box_outline_blank.png";
                }

                if (Erfassungsbogen.t00field13_9 == "1")
                {
                    t00Image13_10.Source = "ic_check_box.png";
                }
                else
                {
                    t00Image13_10.Source = "ic_check_box_outline_blank.png";
                }
                if (Erfassungsbogen.t00field13_10 == "1")
                {
                    t00Image13_11.Source = "ic_check_box.png";
                }
                else
                {
                    t00Image13_11.Source = "ic_check_box_outline_blank.png";
                }

                if (Erfassungsbogen.t00field13_11 == "1")
                {
                    t00Image13_12.Source = "ic_check_box.png";
                }
                else
                {
                    t00Image13_12.Source = "ic_check_box_outline_blank.png";
                }

                if (Erfassungsbogen.t00field13_11_1 != "")
                {
                    t00field13_13.Text = Erfassungsbogen.t00field13_11_1;
                }

                if (Erfassungsbogen.t00field13_11_2 != "")
                {
                    t00field13_14.Text = Erfassungsbogen.t00field13_11_2;
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
                    await Navigation.PushAsync(new Allgemeines_4());
                }
                else
                {
                    var BackQuestion = await DisplayAlert(AppResources.Information, AppResources.InformationSaveQuery, AppResources.Yes, AppResources.No);
                    if (BackQuestion == true)
                    {
                        //Set Text Entry Values in Erfassungsbogen
                        Erfassungsbogen.t00field13_11_1 = t00field13_13.Text;
                        Erfassungsbogen.t00field13_11_2 = t00field13_14.Text;

                        t00field13.TextColor = t00label13_13.TextColor = AppManager.QuestionColor;

                        if ((Erfassungsbogen.t00field13_1 != "" && Erfassungsbogen.t00field13_1 != "0") | (Erfassungsbogen.t00field13_2 != "" && Erfassungsbogen.t00field13_2 != "0") | (Erfassungsbogen.t00field13_3 != "" && Erfassungsbogen.t00field13_3 != "0") | (Erfassungsbogen.t00field13_4 != "" && Erfassungsbogen.t00field13_4 != "0") | (Erfassungsbogen.t00field13_5 != "" && Erfassungsbogen.t00field13_5 != "0") | (Erfassungsbogen.t00field13_6 != "" && Erfassungsbogen.t00field13_6 != "0") | (Erfassungsbogen.t00field13_7 != "" && Erfassungsbogen.t00field13_7 != "0") | (Erfassungsbogen.t00field13_8 != "" && Erfassungsbogen.t00field13_8 != "0") | (Erfassungsbogen.t00field13_9 != "" && Erfassungsbogen.t00field13_9 != "0") | (Erfassungsbogen.t00field13_10 != "" && Erfassungsbogen.t00field13_10 != "0") | (Erfassungsbogen.t00field13_11 != "" && Erfassungsbogen.t00field13_11 != "0"))
                        {
                            if (Erfassungsbogen.t00field13_11 == "1")
                            {
                                if ((t00field13_13.Text != null && t00field13_13.Text != "") | (t00field13_14.Text != null && t00field13_14.Text != ""))
                                {
                                    WebRequest req = WebRequest.Create(DBManagement.DBConnection + "tbl_form_ebqe_t00_05_update.php");

                                    req.Method = "POST"; //POST
                                    req.Timeout = 15000;
                                    req.ContentType = "application/x-www-form-urlencoded";

                                    string postData = "mstr=" + App.user.selected_mstr_ebqe + "&bewonerid=" + App.user.selected_id_bewohner + "&t00field13_1=" + Erfassungsbogen.t00field13_1 + "&t00field13_2=" + Erfassungsbogen.t00field13_2 + "&t00field13_3=" + Erfassungsbogen.t00field13_3 + "&t00field13_4=" + Erfassungsbogen.t00field13_4 + "&t00field13_5=" + Erfassungsbogen.t00field13_5 + "&t00field13_6=" + Erfassungsbogen.t00field13_6 + "&t00field13_7=" + Erfassungsbogen.t00field13_7 + "&t00field13_7_1=" + Erfassungsbogen.t00field13_7_1 + "&t00field13_8=" + Erfassungsbogen.t00field13_8 + "&t00field13_9=" + Erfassungsbogen.t00field13_9 + "&t00field13_10=" + Erfassungsbogen.t00field13_10 + "&t00field13_11=" + Erfassungsbogen.t00field13_11 + "&t00field13_11_1=" + t00field13_13.Text + "&t00field13_11_2=" + t00field13_14.Text;

                                    byte[] byteArray = Encoding.UTF8.GetBytes(postData);

                                    req.ContentLength = byteArray.Length;

                                    Stream ds = await req.GetRequestStreamAsync();
                                    await ds.WriteAsync(byteArray, 0, byteArray.Length);
                                    ds.Close();

                                    await Navigation.PushAsync(new Allgemeines_4());
                                }
                                else
                                {
                                    t00label13_13.TextColor = Color.Red;
                                    await DisplayAlert(AppResources.Warning, AppResources.FieldsUnfilled, "OK");
                                    BackButton.Source = "ic_arrow_back_ios.png";
                                }
                            }
                            else
                            {
                                WebRequest req = WebRequest.Create(DBManagement.DBConnection + "tbl_form_ebqe_t00_05_update.php");

                                req.Method = "POST"; //POST
                                req.Timeout = 15000;
                                req.ContentType = "application/x-www-form-urlencoded";

                                string postData = "mstr=" + App.user.selected_mstr_ebqe + "&bewonerid=" + App.user.selected_id_bewohner + "&t00field13_1=" + Erfassungsbogen.t00field13_1 + "&t00field13_2=" + Erfassungsbogen.t00field13_2 + "&t00field13_3=" + Erfassungsbogen.t00field13_3 + "&t00field13_4=" + Erfassungsbogen.t00field13_4 + "&t00field13_5=" + Erfassungsbogen.t00field13_5 + "&t00field13_6=" + Erfassungsbogen.t00field13_6 + "&t00field13_7=" + Erfassungsbogen.t00field13_7 + "&t00field13_7_1=" + Erfassungsbogen.t00field13_7_1 + "&t00field13_8=" + Erfassungsbogen.t00field13_8 + "&t00field13_9=" + Erfassungsbogen.t00field13_9 + "&t00field13_10=" + Erfassungsbogen.t00field13_10 + "&t00field13_11=" + Erfassungsbogen.t00field13_11 + "&t00field13_11_1=" + Erfassungsbogen.t00field13_11_1 + "&t00field13_11_2=" + Erfassungsbogen.t00field13_11_2;

                                byte[] byteArray = Encoding.UTF8.GetBytes(postData);

                                req.ContentLength = byteArray.Length;

                                Stream ds = await req.GetRequestStreamAsync();
                                await ds.WriteAsync(byteArray, 0, byteArray.Length);
                                ds.Close();

                                await Navigation.PushAsync(new Allgemeines_4());
                            }
                        }
                        else
                        {
                            if ((Erfassungsbogen.t00field13_1 == "" || Erfassungsbogen.t00field13_1 == null || Erfassungsbogen.t00field13_1 == "0") && (Erfassungsbogen.t00field13_2 == "" || Erfassungsbogen.t00field13_2 == null || Erfassungsbogen.t00field13_2 == "0") && (Erfassungsbogen.t00field13_3 == "" || Erfassungsbogen.t00field13_3 == null || Erfassungsbogen.t00field13_3 == "0") && (Erfassungsbogen.t00field13_4 == "" || Erfassungsbogen.t00field13_4 == null || Erfassungsbogen.t00field13_4 == "0") && (Erfassungsbogen.t00field13_5 == "" || Erfassungsbogen.t00field13_5 == null || Erfassungsbogen.t00field13_5 == "0") && (Erfassungsbogen.t00field13_6 == "" || Erfassungsbogen.t00field13_6 == null || Erfassungsbogen.t00field13_6 == "0") && (Erfassungsbogen.t00field13_7 == "" || Erfassungsbogen.t00field13_7 == null || Erfassungsbogen.t00field13_7 == "0") && (Erfassungsbogen.t00field13_8 == "" || Erfassungsbogen.t00field13_8 == null || Erfassungsbogen.t00field13_8 == "0") && (Erfassungsbogen.t00field13_9 == "" || Erfassungsbogen.t00field13_9 == null || Erfassungsbogen.t00field13_9 == "0") && (Erfassungsbogen.t00field13_10 == "" || Erfassungsbogen.t00field13_10 == null || Erfassungsbogen.t00field13_10 == "0") && (Erfassungsbogen.t00field13_11 == "" || Erfassungsbogen.t00field13_11 == null || Erfassungsbogen.t00field13_11 == "0"))
                            {
                                t00field13.TextColor = Color.Red;
                            }
                            await DisplayAlert(AppResources.Warning, AppResources.FieldsUnfilled, "OK");
                            BackButton.Source = "ic_arrow_back_ios.png";
                        }
                    }
                    else
                    {
                        Erfassungsbogen.t00field13_1 = Erfassungsbogen.t00field13_2 = Erfassungsbogen.t00field13_3 = Erfassungsbogen.t00field13_4 = Erfassungsbogen.t00field13_5 = Erfassungsbogen.t00field13_6 = Erfassungsbogen.t00field13_7 = Erfassungsbogen.t00field13_7_1 = Erfassungsbogen.t00field13_8 = Erfassungsbogen.t00field13_9 = Erfassungsbogen.t00field13_10 = Erfassungsbogen.t00field13_11 = Erfassungsbogen.t00field13_11_1 = Erfassungsbogen.t00field13_11_2 = "";

                        WebRequest req = WebRequest.Create(DBManagement.DBConnection + "tbl_form_ebqe_t00_05_update.php");

                        req.Method = "POST"; //POST
                        req.Timeout = 15000;
                        req.ContentType = "application/x-www-form-urlencoded";

                        string postData = "mstr=" + App.user.selected_mstr_ebqe + "&bewonerid=" + App.user.selected_id_bewohner + "&t00field13_1=" + Erfassungsbogen.t00field13_1 + "&t00field13_2=" + Erfassungsbogen.t00field13_2 + "&t00field13_3=" + Erfassungsbogen.t00field13_3 + "&t00field13_4=" + Erfassungsbogen.t00field13_4 + "&t00field13_5=" + Erfassungsbogen.t00field13_5 + "&t00field13_6=" + Erfassungsbogen.t00field13_6 + "&t00field13_7=" + Erfassungsbogen.t00field13_7 + "&t00field13_7_1=" + Erfassungsbogen.t00field13_7_1 + "&t00field13_8=" + Erfassungsbogen.t00field13_8 + "&t00field13_9=" + Erfassungsbogen.t00field13_9 + "&t00field13_10=" + Erfassungsbogen.t00field13_10 + "&t00field13_11=" + Erfassungsbogen.t00field13_11 + "&t00field13_11_1=" + Erfassungsbogen.t00field13_11_1 + "&t00field13_11_2=" + Erfassungsbogen.t00field13_11_2;

                        byte[] byteArray = Encoding.UTF8.GetBytes(postData);

                        req.ContentLength = byteArray.Length;

                        Stream ds = await req.GetRequestStreamAsync();
                        await ds.WriteAsync(byteArray, 0, byteArray.Length);
                        ds.Close();

                        await Navigation.PushAsync(new Allgemeines_4());
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
                    //Set Text Entry Values in Erfassungsbogen
                    Erfassungsbogen.t00field13_11_1 = t00field13_13.Text;
                    Erfassungsbogen.t00field13_11_2 = t00field13_14.Text;

                    t00field13.TextColor = t00label13_13.TextColor = AppManager.QuestionColor;

                    if ((Erfassungsbogen.t00field13_1 != "" && Erfassungsbogen.t00field13_1 != "0") | (Erfassungsbogen.t00field13_2 != "" && Erfassungsbogen.t00field13_2 != "0") | (Erfassungsbogen.t00field13_3 != "" && Erfassungsbogen.t00field13_3 != "0") | (Erfassungsbogen.t00field13_4 != "" && Erfassungsbogen.t00field13_4 != "0") | (Erfassungsbogen.t00field13_5 != "" && Erfassungsbogen.t00field13_5 != "0") | (Erfassungsbogen.t00field13_6 != "" && Erfassungsbogen.t00field13_6 != "0") | (Erfassungsbogen.t00field13_7 != "" && Erfassungsbogen.t00field13_7 != "0") | (Erfassungsbogen.t00field13_8 != "" && Erfassungsbogen.t00field13_8 != "0") | (Erfassungsbogen.t00field13_9 != "" && Erfassungsbogen.t00field13_9 != "0") | (Erfassungsbogen.t00field13_10 != "" && Erfassungsbogen.t00field13_10 != "0") | (Erfassungsbogen.t00field13_11 != "" && Erfassungsbogen.t00field13_11 != "0"))
                    {
                        if (Erfassungsbogen.t00field13_11 == "1")
                        {
                            if ((t00field13_13.Text != null && t00field13_13.Text != "") | (t00field13_14.Text != null && t00field13_14.Text != ""))
                            {
                                WebRequest req = WebRequest.Create(DBManagement.DBConnection + "tbl_form_ebqe_t00_05_update.php");

                                req.Method = "POST"; //POST
                                req.Timeout = 15000;
                                req.ContentType = "application/x-www-form-urlencoded";

                                string postData = "mstr=" + App.user.selected_mstr_ebqe + "&bewonerid=" + App.user.selected_id_bewohner + "&t00field13_1=" + Erfassungsbogen.t00field13_1 + "&t00field13_2=" + Erfassungsbogen.t00field13_2 +
                                   "&t00field13_3=" + Erfassungsbogen.t00field13_3 + "&t00field13_4=" + Erfassungsbogen.t00field13_4 + "&t00field13_5=" + Erfassungsbogen.t00field13_5 + "&t00field13_6=" + Erfassungsbogen.t00field13_6 +
                                   "&t00field13_7=" + Erfassungsbogen.t00field13_7 + "&t00field13_7_1=" + Erfassungsbogen.t00field13_7_1 + "&t00field13_8=" + Erfassungsbogen.t00field13_8 +
                                   "&t00field13_9=" + Erfassungsbogen.t00field13_9 + "&t00field13_10=" + Erfassungsbogen.t00field13_10 + "&t00field13_11=" + Erfassungsbogen.t00field13_11 + "&t00field13_11_1=" + t00field13_13.Text + "&t00field13_11_2=" + t00field13_14.Text;

                                byte[] byteArray = Encoding.UTF8.GetBytes(postData);

                                req.ContentLength = byteArray.Length;

                                Stream ds = await req.GetRequestStreamAsync();
                                await ds.WriteAsync(byteArray, 0, byteArray.Length);
                                ds.Close();

                                await Navigation.PushAsync(new SearchPage());
                            }
                            else
                            {
                                t00label13_13.TextColor = Color.Red;
                                await DisplayAlert(AppResources.Warning, AppResources.FieldsUnfilled, "OK");
                                SaveAllButton.Source = "ic_done_all.png";
                            }
                        }
                        else
                        {
                            WebRequest req = WebRequest.Create(DBManagement.DBConnection + "tbl_form_ebqe_t00_05_update.php");

                            req.Method = "POST"; //POST
                            req.Timeout = 15000;
                            req.ContentType = "application/x-www-form-urlencoded";

                            string postData = "mstr=" + App.user.selected_mstr_ebqe + "&bewonerid=" + App.user.selected_id_bewohner + "&t00field13_1=" + Erfassungsbogen.t00field13_1 + "&t00field13_2=" + Erfassungsbogen.t00field13_2 +
                               "&t00field13_3=" + Erfassungsbogen.t00field13_3 + "&t00field13_4=" + Erfassungsbogen.t00field13_4 + "&t00field13_5=" + Erfassungsbogen.t00field13_5 + "&t00field13_6=" + Erfassungsbogen.t00field13_6 +
                               "&t00field13_7=" + Erfassungsbogen.t00field13_7 + "&t00field13_7_1=" + Erfassungsbogen.t00field13_7_1 + "&t00field13_8=" + Erfassungsbogen.t00field13_8 +
                               "&t00field13_9=" + Erfassungsbogen.t00field13_9 + "&t00field13_10=" + Erfassungsbogen.t00field13_10 + "&t00field13_11=" + Erfassungsbogen.t00field13_11 + "&t00field13_11_1=" + Erfassungsbogen.t00field13_11_1 + "&t00field13_11_2=" + Erfassungsbogen.t00field13_11_2;

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
                        if ((Erfassungsbogen.t00field13_1 == "" || Erfassungsbogen.t00field13_1 == null || Erfassungsbogen.t00field13_1 == "0") && (Erfassungsbogen.t00field13_2 == "" || Erfassungsbogen.t00field13_2 == null || Erfassungsbogen.t00field13_2 == "0") && (Erfassungsbogen.t00field13_3 == "" || Erfassungsbogen.t00field13_3 == null || Erfassungsbogen.t00field13_3 == "0") && (Erfassungsbogen.t00field13_4 == "" || Erfassungsbogen.t00field13_4 == null || Erfassungsbogen.t00field13_4 == "0") && (Erfassungsbogen.t00field13_5 == "" || Erfassungsbogen.t00field13_5 == null || Erfassungsbogen.t00field13_5 == "0") && (Erfassungsbogen.t00field13_6 == "" || Erfassungsbogen.t00field13_6 == null || Erfassungsbogen.t00field13_6 == "0") && (Erfassungsbogen.t00field13_7 == "" || Erfassungsbogen.t00field13_7 == null || Erfassungsbogen.t00field13_7 == "0") && (Erfassungsbogen.t00field13_8 == "" || Erfassungsbogen.t00field13_8 == null || Erfassungsbogen.t00field13_8 == "0") && (Erfassungsbogen.t00field13_9 == "" || Erfassungsbogen.t00field13_9 == null || Erfassungsbogen.t00field13_9 == "0") && (Erfassungsbogen.t00field13_10 == "" || Erfassungsbogen.t00field13_10 == null || Erfassungsbogen.t00field13_10 == "0") && (Erfassungsbogen.t00field13_11 == "" || Erfassungsbogen.t00field13_11 == null || Erfassungsbogen.t00field13_11 == "0"))
                        {
                            t00field13.TextColor = Color.Red;
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
                        WebRequest req = WebRequest.Create(DBManagement.DBConnection + "tbl_form_ebqe_t00_01-05_update_clr.php");

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
            if (Erfassungsbogen.t00field13_1 != "0" | Erfassungsbogen.t00field13_1 == "" | Erfassungsbogen.t00field13_1 == null)
            {
                t00Image13_01.Source = "ic_check_box.png";
                Erfassungsbogen.t00field13_1 = "1";
            }
            else
            {
                t00Image13_01.Source = "ic_check_box_outline_blank.png";
                Erfassungsbogen.t00field13_1 = "0";
            }
        }

        private void TapGestureRecognizer_Tapped_1(object sender, EventArgs e)
        {
            if (Erfassungsbogen.t00field13_2 == "0" | Erfassungsbogen.t00field13_2 == "" | Erfassungsbogen.t00field13_2 == null)
            {
                t00Image13_02.Source = "ic_check_box.png";
                Erfassungsbogen.t00field13_2 = "1";
            }
            else
            {
                t00Image13_02.Source = "ic_check_box_outline_blank.png";
                Erfassungsbogen.t00field13_2 = "0";
            }
        }

        private void TapGestureRecognizer_Tapped_2(object sender, EventArgs e)
        {
            if (Erfassungsbogen.t00field13_3 == "0" | Erfassungsbogen.t00field13_3 == "" | Erfassungsbogen.t00field13_3 == null)
            {
                t00Image13_03.Source = "ic_check_box.png";
                Erfassungsbogen.t00field13_3 = "1";
            }
            else
            {
                t00Image13_03.Source = "ic_check_box_outline_blank.png";
                Erfassungsbogen.t00field13_3 = "0";
            }
        }

        private void TapGestureRecognizer_Tapped_3(object sender, EventArgs e)
        {
            if (Erfassungsbogen.t00field13_4 == "0" | Erfassungsbogen.t00field13_4 == "" | Erfassungsbogen.t00field13_4 == null)
            {
                t00Image13_04.Source = "ic_check_box.png";
                Erfassungsbogen.t00field13_4 = "1";
            }
            else
            {
                t00Image13_04.Source = "ic_check_box_outline_blank.png";
                Erfassungsbogen.t00field13_4 = "0";
            }
        }

        private void TapGestureRecognizer_Tapped_4(object sender, EventArgs e)
        {
            if (Erfassungsbogen.t00field13_5 == "0" | Erfassungsbogen.t00field13_5 == "" | Erfassungsbogen.t00field13_5 == null)
            {
                t00Image13_05.Source = "ic_check_box.png";
                Erfassungsbogen.t00field13_5 = "1";
            }
            else
            {
                t00Image13_05.Source = "ic_check_box_outline_blank.png";
                Erfassungsbogen.t00field13_5 = "0";
            }
        }

        private void TapGestureRecognizer_Tapped_5(object sender, EventArgs e)
        {

            if (Erfassungsbogen.t00field13_6 == "0" | Erfassungsbogen.t00field13_6 == "" | Erfassungsbogen.t00field13_6 == null)
            {
                t00Image13_06.Source = "ic_check_box.png";
                Erfassungsbogen.t00field13_6 = "1";
            }
            else
            {
                t00Image13_06.Source = "ic_check_box_outline_blank.png";
                Erfassungsbogen.t00field13_6 = "0";
            }
        }

        private void TapGestureRecognizer_Tapped_6(object sender, EventArgs e)
        {

            if (Erfassungsbogen.t00field13_7 == "0" | Erfassungsbogen.t00field13_7 == "" | Erfassungsbogen.t00field13_7 == null)
            {
                t00Image13_07.Source = "ic_check_box.png";
                Erfassungsbogen.t00field13_7 = "1";
            }
            else
            {
                t00Image13_07.Source = "ic_check_box_outline_blank.png";
                Erfassungsbogen.t00field13_7 = "0";
            }
        }

        private void TapGestureRecognizer_Tapped_7(object sender, EventArgs e)
        {
            if (Erfassungsbogen.t00field13_7_1 == "0" | Erfassungsbogen.t00field13_7_1 == "" | Erfassungsbogen.t00field13_7_1 == null)
            {
                t00Image13_08.Source = "ic_check_box.png";
                Erfassungsbogen.t00field13_7_1 = "1";
            }
            else
            {
                t00Image13_08.Source = "ic_check_box_outline_blank.png";
                Erfassungsbogen.t00field13_7_1 = "0";
            }
        }

        private void TapGestureRecognizer_Tapped_8(object sender, EventArgs e)
        {
            if (Erfassungsbogen.t00field13_8 == "0" | Erfassungsbogen.t00field13_8 == "" | Erfassungsbogen.t00field13_8 == null)
            {
                t00Image13_09.Source = "ic_check_box.png";
                Erfassungsbogen.t00field13_8 = "1";
            }
            else
            {
                t00Image13_09.Source = "ic_check_box_outline_blank.png";
                Erfassungsbogen.t00field13_8 = "0";
            }
        }

        private void TapGestureRecognizer_Tapped_9(object sender, EventArgs e)
        {
            if (Erfassungsbogen.t00field13_9 == "0" | Erfassungsbogen.t00field13_9 == "" | Erfassungsbogen.t00field13_9 == null)
            {
                t00Image13_10.Source = "ic_check_box.png";
                Erfassungsbogen.t00field13_9 = "1";
            }
            else
            {
                t00Image13_10.Source = "ic_check_box_outline_blank.png";
                Erfassungsbogen.t00field13_9 = "0";
            }
        }

        private void TapGestureRecognizer_Tapped_10(object sender, EventArgs e)
        {
            if (Erfassungsbogen.t00field13_10 == "0" | Erfassungsbogen.t00field13_10 == "" | Erfassungsbogen.t00field13_10 == null)
            {
                t00Image13_11.Source = "ic_check_box.png";
                Erfassungsbogen.t00field13_10 = "1";
            }
            else
            {
                t00Image13_11.Source = "ic_check_box_outline_blank.png";
                Erfassungsbogen.t00field13_10 = "0";
            }
        }

        private void TapGestureRecognizer_Tapped_11(object sender, EventArgs e)
        {
            if (Erfassungsbogen.t00field13_11 == "0" | Erfassungsbogen.t00field13_11 == "" | Erfassungsbogen.t00field13_11 == null)
            {
                t00Image13_12.Source = "ic_check_box.png";
                Erfassungsbogen.t00field13_11 = "1";
            }
            else
            {
                t00Image13_12.Source = "ic_check_box_outline_blank.png";
                Erfassungsbogen.t00field13_11 = "0";
                Erfassungsbogen.t00field13_11_1 = "";
                Erfassungsbogen.t00field13_11_2 = "";
                t00field13_13.Text = "";
                t00field13_14.Text = "";
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