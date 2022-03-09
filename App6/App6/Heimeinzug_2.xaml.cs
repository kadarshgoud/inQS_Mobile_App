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
    public partial class Heimeinzug_2 : ContentPage, INotifyPropertyChanged
    {
        public bool InitialDataIsEmpty;

        public Heimeinzug_2()
        {
            InitializeComponent();
            BindingContext = this;

            BogenLabel.Text = AppResources.SurveyHeadline + " " + DBManagement.getYearCode(App.user.selected_mstr_ebqe) + " " + AppResources.SurveyHeadlineFor + " " + Erfassungsbogen.Bewohnerbezeichnung;

            t12Picker06_1.Items.Add("ja");
            t12Picker06_1.Items.Add("nein");

            /* t12Picker04_5.Items.Add("Bewohner");
             t12Picker04_5.Items.Add("Angehörige");
             t12Picker04_5.Items.Add("Betreuer");
             t12Picker04_5.Items.Add("andere Vertrauenspersonen, die nicht in der Einrichtung beschäftigt sind");*/

            t12Picker04_5_01.Items.Add("Ehrenamtlicher");
            t12Picker04_5_01.Items.Add("Freund");
            t12Picker04_5_01.Items.Add("Sonstige Person");
        }

        //Before page gets loaded this opertion is performed
        protected override async void OnAppearing()
        {
            base.OnAppearing();

            try
            {
                //ActivityIndicator = Loading...
                IsLoading = true;

                //WebRequest req = WebRequest.Create(DBManagement.DBConnection + "tbl_form_ebqe_t12_02_read.php");

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

                //if (split[0] != "" && split[1] != "" && split[2] != "" && split[3] != "" && split[4] != "" && split[5] != "")
                //{
                //    InitialDataIsEmpty = false;
                //}

                //Erfassungsbogen.t12field02_03_01 = split[0];
                //Erfassungsbogen.t12field02_03_02 = split[1];
                //Erfassungsbogen.t12field02_03_03 = split[2];
                //Erfassungsbogen.t12field02_03_04 = split[3];

                //Erfassungsbogen.t12field02_04 = split[4];

                //Erfassungsbogen.t12field03 = split[5];


                if (Erfassungsbogen.t12field00 == "0")
                {
                    t12field04_5.IsEnabled =
                    Textline.IsEnabled =
                    t12Image02_03_01.IsEnabled =
                    t12field02_03_01.IsEnabled =
                    t12Image02_03_02.IsEnabled =
                    t12field02_03_02.IsEnabled =
                    t12Image02_03_03.IsEnabled =
                    t12field02_03_03.IsEnabled =
                    t12Image02_03_04.IsEnabled =
                    t12field02_03_04.IsEnabled =
                    t12field04_5_01.IsEnabled =
                    t12Picker04_5_01.IsEnabled =
                    t12field06_1.IsEnabled =
                    t12Picker06_1.IsEnabled = false;

                    t12field04_5.Opacity =
                    Textline.Opacity =
                    t12Image02_03_01.Opacity =
                    t12field02_03_01.Opacity =
                    t12Image02_03_02.Opacity =
                    t12field02_03_02.Opacity =
                    t12Image02_03_03.Opacity =
                    t12field02_03_03.Opacity =
                    t12Image02_03_04.Opacity =
                    t12field02_03_04.Opacity =
                    t12field04_5_01.Opacity =
                    t12Picker04_5_01.Opacity =
                    t12field06_1.Opacity =
                    t12Picker06_1.Opacity = AppManager.AnswerDisabledOpacity;
                }

                // check boxes t12field_02_01 -- _04

                if (Erfassungsbogen.t12field02_03_01 == "1")
                {
                    t12Image02_03_01.Source = "ic_check_box.png";                            // rb1 is the image file with checked box image
                }
                else
                {
                    t12Image02_03_01.Source = "ic_check_box_outline_blank.png";
                }

                if (Erfassungsbogen.t12field02_03_02 == "1")
                {
                    t12Image02_03_02.Source = "ic_check_box.png";
                }
                else
                {
                    t12Image02_03_02.Source = "ic_check_box_outline_blank.png";
                }

                if (Erfassungsbogen.t12field02_03_03 == "1")
                {
                    t12Image02_03_03.Source = "ic_check_box.png";
                }
                else
                {
                    t12Image02_03_03.Source = "ic_check_box_outline_blank.png";
                }

                if (Erfassungsbogen.t12field02_03_04 == "1")
                {
                    t12Image02_03_04.Source = "ic_check_box.png";
                }
                else
                {
                    t12Image02_03_04.Source = "ic_check_box_outline_blank.png";
                }

                // picker 02_04
                if (Erfassungsbogen.t12field02_04 == "1")
                {
                    t12Picker04_5_01.SelectedIndex = 0;                         // rb1 is the image file with checked box image
                }
                else if (Erfassungsbogen.t12field02_04 == "2")
                {
                    t12Picker04_5_01.SelectedIndex = 1;
                }
                else if (Erfassungsbogen.t12field02_04 == "0")
                {
                    t12Picker04_5_01.SelectedIndex = 2;
                }
                else
                {
                    t12Picker04_5_01.SelectedIndex = -1;
                }

                // picker t12field03
                if (Erfassungsbogen.t12field03 == "1")
                {
                    t12Picker06_1.SelectedIndex = 0;
                }
                else if (Erfassungsbogen.t12field03 == "0")
                {
                    t12Picker06_1.SelectedIndex = 1;
                }
                else
                {
                    t12Picker06_1.SelectedIndex = -1;
                }
                //ActivityIndicator = Idle
                IsLoading = false;

            }
            catch (Exception)
            {
                await DisplayAlert(AppResources.AppError, AppResources.AppErrorMsg, "OK");
            }
        }

        private void T12Picker06_1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (t12Picker06_1.SelectedIndex == 0)
            {
                Erfassungsbogen.t12field03 = "1";
            }
            else if (t12Picker06_1.SelectedIndex == 1)
            {
                Erfassungsbogen.t12field03 = "0";
            }
        }

        private void TapGestureRecognizer_Tapped_02_03_01(object sender, EventArgs e)
        {
            if (Erfassungsbogen.t12field02_03_01 != "1" | Erfassungsbogen.t12field02_03_01 == null)
            {
                t12Image02_03_01.Source = "ic_check_box.png";
                Erfassungsbogen.t12field02_03_01 = "1";
            }
            else
            {
                t12Image02_03_01.Source = "ic_check_box_outline_blank.png";
                Erfassungsbogen.t12field02_03_01 = "0";
            }
        }

        private void TapGestureRecognizer_Tapped_02_03_02(object sender, EventArgs e)
        {
            if (Erfassungsbogen.t12field02_03_02 != "1" | Erfassungsbogen.t12field02_03_02 == null)
            {
                t12Image02_03_02.Source = "ic_check_box.png";
                Erfassungsbogen.t12field02_03_02 = "1";
            }
            else
            {
                t12Image02_03_02.Source = "ic_check_box_outline_blank.png";
                Erfassungsbogen.t12field02_03_02 = "0";
            }
        }

        private void TapGestureRecognizer_Tapped_02_03_03(object sender, EventArgs e)
        {
            if (Erfassungsbogen.t12field02_03_03 != "1" | Erfassungsbogen.t12field02_03_03 == null)
            {
                t12Image02_03_03.Source = "ic_check_box.png";
                Erfassungsbogen.t12field02_03_03 = "1";
            }
            else
            {
                t12Image02_03_03.Source = "ic_check_box_outline_blank.png";
                Erfassungsbogen.t12field02_03_03 = "0";
            }
        }

        private void TapGestureRecognizer_Tapped_02_03_04(object sender, EventArgs e)
        {
            if (Erfassungsbogen.t12field02_03_04 != "1" | Erfassungsbogen.t12field02_03_04 == null)
            {
                t12Image02_03_04.Source = "ic_check_box.png";
                Erfassungsbogen.t12field02_03_04 = "1";
            }
            else
            {
                t12Image02_03_04.Source = "ic_check_box_outline_blank.png";
                Erfassungsbogen.t12field02_03_04 = "0";
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
                    await Navigation.PushAsync(new Heimeinzug_1());
                }
                else
                {
                    var BackQuestion = await DisplayAlert(AppResources.Information, AppResources.InformationSaveQuery, AppResources.Yes, AppResources.No);
                    if (BackQuestion == true)
                    {
                        t12field04_5.TextColor = t12field04_5_01.TextColor = t12field06_1.TextColor = AppManager.QuestionColor;

                        if (Erfassungsbogen.t12field00 == "1" || (Erfassungsbogen.t12field00 == "" && Erfassungsbogen.t12field00 == null))
                        {
                            if (((Erfassungsbogen.t12field02_03_01 != "" && Erfassungsbogen.t12field02_03_01 != null && Erfassungsbogen.t12field02_03_01 != "0") || (Erfassungsbogen.t12field02_03_02 != "" && Erfassungsbogen.t12field02_03_02 != null && Erfassungsbogen.t12field02_03_02 != "0") || (Erfassungsbogen.t12field02_03_03 != "" && Erfassungsbogen.t12field02_03_03 != null && Erfassungsbogen.t12field02_03_03 != "0") || (Erfassungsbogen.t12field02_03_04 != "" && Erfassungsbogen.t12field02_03_04 != null && Erfassungsbogen.t12field02_03_04 != "0")) && (Erfassungsbogen.t12field03 != "" && Erfassungsbogen.t12field03 != null))
                            {
                                if (Erfassungsbogen.t12field02_03_04 == "1")
                                {
                                    if (Erfassungsbogen.t12field02_04 == "" | Erfassungsbogen.t12field02_04 == null)
                                    {
                                        t12field04_5_01.TextColor = Color.Red;

                                        await DisplayAlert(AppResources.Warning, AppResources.FieldsUnfilled, "OK");
                                        BackButton.Source = "ic_arrow_back_ios.png";
                                    }
                                    else
                                    {
                                        WebRequest req = WebRequest.Create(DBManagement.DBConnection + "tbl_form_ebqe_t12_02_update.php");

                                        req.Method = "POST"; //POST
                                        req.Timeout = 15000;
                                        req.ContentType = "application/x-www-form-urlencoded";

                                        string postData = "mstr=" + App.user.selected_mstr_ebqe + "&bewonerid=" + App.user.selected_id_bewohner + "&t12field02_03_01=" + Erfassungsbogen.t12field02_03_01 + "&t12field02_03_02=" + Erfassungsbogen.t12field02_03_02 +
                                            "&t12field02_03_03=" + Erfassungsbogen.t12field02_03_03 + "&t12field02_03_04=" + Erfassungsbogen.t12field02_03_04 + "&t12field02_04=" + Erfassungsbogen.t12field02_04 + "&t12field03=" + Erfassungsbogen.t12field03;
                                        byte[] byteArray = Encoding.UTF8.GetBytes(postData);

                                        req.ContentLength = byteArray.Length;

                                        Stream ds = await req.GetRequestStreamAsync();
                                        await ds.WriteAsync(byteArray, 0, byteArray.Length);
                                        ds.Close();

                                        await Navigation.PushAsync(new Heimeinzug_1());
                                    }
                                }
                                else
                                {
                                    WebRequest req = WebRequest.Create(DBManagement.DBConnection + "tbl_form_ebqe_t12_02_update.php");

                                    req.Method = "POST"; //POST
                                    req.Timeout = 15000;
                                    req.ContentType = "application/x-www-form-urlencoded";

                                    string postData = "mstr=" + App.user.selected_mstr_ebqe + "&bewonerid=" + App.user.selected_id_bewohner + "&t12field02_03_01=" + Erfassungsbogen.t12field02_03_01 + "&t12field02_03_02=" + Erfassungsbogen.t12field02_03_02 +
                                        "&t12field02_03_03=" + Erfassungsbogen.t12field02_03_03 + "&t12field02_03_04=" + Erfassungsbogen.t12field02_03_04 + "&t12field02_04=" + Erfassungsbogen.t12field02_04 + "&t12field03=" + Erfassungsbogen.t12field03;
                                    byte[] byteArray = Encoding.UTF8.GetBytes(postData);

                                    req.ContentLength = byteArray.Length;

                                    Stream ds = await req.GetRequestStreamAsync();
                                    await ds.WriteAsync(byteArray, 0, byteArray.Length);
                                    ds.Close();

                                    await Navigation.PushAsync(new Heimeinzug_1());
                                }
                            }
                            else
                            {
                                if ((Erfassungsbogen.t12field02_03_01 == "" || Erfassungsbogen.t12field02_03_01 == null || Erfassungsbogen.t12field02_03_01 == "0") && (Erfassungsbogen.t12field02_03_02 == "" || Erfassungsbogen.t12field02_03_02 == null || Erfassungsbogen.t12field02_03_02 == "0") && (Erfassungsbogen.t12field02_03_03 == "" || Erfassungsbogen.t12field02_03_03 == null || Erfassungsbogen.t12field02_03_03 == "0") && (Erfassungsbogen.t12field02_03_04 == "" || Erfassungsbogen.t12field02_03_04 == null || Erfassungsbogen.t12field02_03_04 == "0"))
                                {
                                    t12field04_5.TextColor = Color.Red;
                                }
                                if (Erfassungsbogen.t12field03 == "" || Erfassungsbogen.t12field03 == null)
                                {
                                    t12field06_1.TextColor = Color.Red;
                                }
                                await DisplayAlert(AppResources.Warning, AppResources.FieldsUnfilled, "OK");
                                BackButton.Source = "ic_arrow_back_ios.png";
                            }
                        }
                        else
                        {
                            Erfassungsbogen.t12field02_03_01 = "";
                            Erfassungsbogen.t12field02_03_02 = "";
                            Erfassungsbogen.t12field02_03_03 = "";
                            Erfassungsbogen.t12field02_03_04 = "";
                            Erfassungsbogen.t12field02_04 = "";
                            Erfassungsbogen.t12field03 = "";

                            if (App.user.selected_mstr_ebqe == DBManagement.CurrentEvaluationID)
                            {
                                WebRequest req = WebRequest.Create(DBManagement.DBConnection + "tbl_form_ebqe_t12_02_update.php");

                                req.Method = "POST"; //POST
                                req.Timeout = 15000;
                                req.ContentType = "application/x-www-form-urlencoded";

                                string postData = "mstr=" + App.user.selected_mstr_ebqe + "&bewonerid=" + App.user.selected_id_bewohner + "&t12field02_03_01=" + Erfassungsbogen.t12field02_03_01 + "&t12field02_03_02=" + Erfassungsbogen.t12field02_03_02 +
                                    "&t12field02_03_03=" + Erfassungsbogen.t12field02_03_03 + "&t12field02_03_04=" + Erfassungsbogen.t12field02_03_04 + "&t12field02_04=" + Erfassungsbogen.t12field02_04 + "&t12field03=" + Erfassungsbogen.t12field03;
                                byte[] byteArray = Encoding.UTF8.GetBytes(postData);

                                req.ContentLength = byteArray.Length;

                                Stream ds = await req.GetRequestStreamAsync();
                                await ds.WriteAsync(byteArray, 0, byteArray.Length);
                                ds.Close();
                            }

                            await Navigation.PushAsync(new Heimeinzug_1());
                        }
                    }
                    else
                    {
                        Erfassungsbogen.t12field02_03_01 = Erfassungsbogen.t12field02_03_02 = Erfassungsbogen.t12field02_03_03 = Erfassungsbogen.t12field02_03_04 = Erfassungsbogen.t12field02_04 = Erfassungsbogen.t12field03 = "";

                        WebRequest req = WebRequest.Create(DBManagement.DBConnection + "tbl_form_ebqe_t12_02_update.php");

                        req.Method = "POST"; //POST
                        req.Timeout = 15000;
                        req.ContentType = "application/x-www-form-urlencoded";

                        string postData = "mstr=" + App.user.selected_mstr_ebqe + "&bewonerid=" + App.user.selected_id_bewohner + "&t12field02_03_01=" + Erfassungsbogen.t12field02_03_01 + "&t12field02_03_02=" + Erfassungsbogen.t12field02_03_02 + "&t12field02_03_03=" + Erfassungsbogen.t12field02_03_03 + "&t12field02_03_04=" + Erfassungsbogen.t12field02_03_04 + "&t12field02_04=" + Erfassungsbogen.t12field02_04 + "&t12field03=" + Erfassungsbogen.t12field03;

                        byte[] byteArray = Encoding.UTF8.GetBytes(postData);

                        req.ContentLength = byteArray.Length;

                        Stream ds = await req.GetRequestStreamAsync();
                        await ds.WriteAsync(byteArray, 0, byteArray.Length);
                        ds.Close();

                        await Navigation.PushAsync(new Heimeinzug_1());
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
                    t12field04_5.TextColor = t12field04_5_01.TextColor = t12field06_1.TextColor = AppManager.QuestionColor;

                    if (Erfassungsbogen.t12field00 == "1" || (Erfassungsbogen.t12field00 == "" && Erfassungsbogen.t12field00 == null))
                    {
                        if (((Erfassungsbogen.t12field02_03_01 != "" && Erfassungsbogen.t12field02_03_01 != null && Erfassungsbogen.t12field02_03_01 != "0") || (Erfassungsbogen.t12field02_03_02 != "" && Erfassungsbogen.t12field02_03_02 != null && Erfassungsbogen.t12field02_03_02 != "0") || (Erfassungsbogen.t12field02_03_03 != "" && Erfassungsbogen.t12field02_03_03 != null && Erfassungsbogen.t12field02_03_03 != "0") || (Erfassungsbogen.t12field02_03_04 != "" && Erfassungsbogen.t12field02_03_04 != null && Erfassungsbogen.t12field02_03_04 != "0")) && (Erfassungsbogen.t12field03 != "" && Erfassungsbogen.t12field03 != null))
                        {
                            if (Erfassungsbogen.t12field02_03_04 == "1")
                            {
                                if (Erfassungsbogen.t12field02_04 == "" | Erfassungsbogen.t12field02_04 == null)
                                {
                                    t12field04_5_01.TextColor = Color.Red;

                                    await DisplayAlert(AppResources.Warning, AppResources.FieldsUnfilled, "OK");
                                    SaveAllButton.Source = "ic_done_all.png";
                                }
                                else
                                {
                                    WebRequest req = WebRequest.Create(DBManagement.DBConnection + "tbl_form_ebqe_t12_02_update.php");

                                    req.Method = "POST"; //POST
                                    req.Timeout = 15000;
                                    req.ContentType = "application/x-www-form-urlencoded";

                                    string postData = "mstr=" + App.user.selected_mstr_ebqe + "&bewonerid=" + App.user.selected_id_bewohner + "&t12field02_03_01=" + Erfassungsbogen.t12field02_03_01 + "&t12field02_03_02=" + Erfassungsbogen.t12field02_03_02 +
                                        "&t12field02_03_03=" + Erfassungsbogen.t12field02_03_03 + "&t12field02_03_04=" + Erfassungsbogen.t12field02_03_04 + "&t12field02_04=" + Erfassungsbogen.t12field02_04 + "&t12field03=" + Erfassungsbogen.t12field03;
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
                                WebRequest req = WebRequest.Create(DBManagement.DBConnection + "tbl_form_ebqe_t12_02_update.php");

                                req.Method = "POST"; //POST
                                req.Timeout = 15000;
                                req.ContentType = "application/x-www-form-urlencoded";

                                string postData = "mstr=" + App.user.selected_mstr_ebqe + "&bewonerid=" + App.user.selected_id_bewohner + "&t12field02_03_01=" + Erfassungsbogen.t12field02_03_01 + "&t12field02_03_02=" + Erfassungsbogen.t12field02_03_02 +
                                    "&t12field02_03_03=" + Erfassungsbogen.t12field02_03_03 + "&t12field02_03_04=" + Erfassungsbogen.t12field02_03_04 + "&t12field02_04=" + Erfassungsbogen.t12field02_04 + "&t12field03=" + Erfassungsbogen.t12field03;
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
                            if ((Erfassungsbogen.t12field02_03_01 == "" || Erfassungsbogen.t12field02_03_01 == null || Erfassungsbogen.t12field02_03_01 == "0") && (Erfassungsbogen.t12field02_03_02 == "" || Erfassungsbogen.t12field02_03_02 == null || Erfassungsbogen.t12field02_03_02 == "0") && (Erfassungsbogen.t12field02_03_03 == "" || Erfassungsbogen.t12field02_03_03 == null || Erfassungsbogen.t12field02_03_03 == "0") && (Erfassungsbogen.t12field02_03_04 == "" || Erfassungsbogen.t12field02_03_04 == null || Erfassungsbogen.t12field02_03_04 == "0"))
                            {
                                t12field04_5.TextColor = Color.Red;
                            }
                            if (Erfassungsbogen.t12field03 == "" || Erfassungsbogen.t12field03 == null)
                            {
                                t12field06_1.TextColor = Color.Red;
                            }
                            await DisplayAlert(AppResources.Warning, AppResources.FieldsUnfilled, "OK");
                            SaveAllButton.Source = "ic_done_all.png";
                        }
                    }
                    else
                    {
                        Erfassungsbogen.t12field02_03_01 = "";
                        Erfassungsbogen.t12field02_03_02 = "";
                        Erfassungsbogen.t12field02_03_03 = "";
                        Erfassungsbogen.t12field02_03_04 = "";
                        Erfassungsbogen.t12field02_04 = "";
                        Erfassungsbogen.t12field03 = "";

                        if (App.user.selected_mstr_ebqe == DBManagement.CurrentEvaluationID)
                        {
                            WebRequest req = WebRequest.Create(DBManagement.DBConnection + "tbl_form_ebqe_t12_02_update.php");

                            req.Method = "POST"; //POST
                            req.Timeout = 15000;
                            req.ContentType = "application/x-www-form-urlencoded";

                            string postData = "mstr=" + App.user.selected_mstr_ebqe + "&bewonerid=" + App.user.selected_id_bewohner + "&t12field02_03_01=" + Erfassungsbogen.t12field02_03_01 + "&t12field02_03_02=" + Erfassungsbogen.t12field02_03_02 +
                                "&t12field02_03_03=" + Erfassungsbogen.t12field02_03_03 + "&t12field02_03_04=" + Erfassungsbogen.t12field02_03_04 + "&t12field02_04=" + Erfassungsbogen.t12field02_04 + "&t12field03=" + Erfassungsbogen.t12field03;
                            byte[] byteArray = Encoding.UTF8.GetBytes(postData);

                            req.ContentLength = byteArray.Length;

                            Stream ds = await req.GetRequestStreamAsync();
                            await ds.WriteAsync(byteArray, 0, byteArray.Length);
                            ds.Close();
                        }

                        await Navigation.PushAsync(new SearchPage());
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
                        WebRequest req = WebRequest.Create(DBManagement.DBConnection + "tbl_form_ebqe_t12_01-02_update_clear.php");

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

        private void T12Picker04_5_01_SelectedIndexChanged(object sender, EventArgs e)
        {
            // T09 01
            if (t12Picker04_5_01.SelectedIndex == 0)
            {
                Erfassungsbogen.t12field02_04 = "1";
            }
            else if (t12Picker04_5_01.SelectedIndex == 1)
            {
                Erfassungsbogen.t12field02_04 = "2";
            }
            else if (t12Picker04_5_01.SelectedIndex == 2)
            {
                Erfassungsbogen.t12field02_04 = "0";
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