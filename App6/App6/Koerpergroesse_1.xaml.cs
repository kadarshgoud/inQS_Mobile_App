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
using System.Globalization;
using System.Text.RegularExpressions;

namespace App6
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Koerpergroesse_1 : ContentPage, INotifyPropertyChanged
    {
        public bool InitialDataIsEmpty;

        public Koerpergroesse_1()
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

                //WebRequest req = WebRequest.Create(DBManagement.DBConnection + "tbl_form_ebqe_t08_01_read.php");

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

                //if (split[0] != "" && split[1] != "" && split[2] != "" && split[3] != "" && split[4] != "" && split[5] != "" && split[6] != "" && split[7] != "" && split[8] != "" && split[9] != "")
                //{
                //    InitialDataIsEmpty = false;
                //}

                //Erfassungsbogen.t08field01 = split[0];
                //Erfassungsbogen.t08field02_01 = split[1];
                //Erfassungsbogen.t08field02_02 = split[2];
                //Erfassungsbogen.t08field03_01 = split[3];
                //Erfassungsbogen.t08field03_02 = split[4];
                //Erfassungsbogen.t08field03_03 = split[5];
                //Erfassungsbogen.t08field03_04 = split[6];
                //Erfassungsbogen.t08field03_05 = split[7];
                //Erfassungsbogen.t08field03_06 = split[8];
                //Erfassungsbogen.t08field04 = split[9];

                // text box 8.1

                t08Entry01.Text = Erfassungsbogen.t08field01;

                // text box 8.2
                t08Entry02.Text = Erfassungsbogen.t08field02_01;

                // date 8.2
                if (Erfassungsbogen.t08field02_02 != "")
                {
                    DatePicker_t08field02_02.Date = DateTime.ParseExact(Erfassungsbogen.t08field02_02.Replace('.', '/'), "dd/MM/yyyy", null).Date;
                    Entry_t08field02_02.Text = Erfassungsbogen.t08field02_02;
                }

                // 6 check boxes 08_03_01 - 06

                if (Erfassungsbogen.t08field03_01 == "1")
                {
                    t08Image03_1.Source = "ic_check_box.png";                            // rb1 is the image file with checked box image
                }
                else
                {
                    t08Image03_1.Source = "ic_check_box_outline_blank.png";
                }

                if (Erfassungsbogen.t08field03_02 == "1")
                {
                    t08Image03_2.Source = "ic_check_box.png";
                }
                else
                {
                    t08Image03_2.Source = "ic_check_box_outline_blank.png";
                }

                if (Erfassungsbogen.t08field03_03 == "1")
                {
                    t08Image03_3.Source = "ic_check_box.png";
                }
                else
                {
                    t08Image03_3.Source = "ic_check_box_outline_blank.png";
                }

                if (Erfassungsbogen.t08field03_04 == "1")
                {
                    t08Image03_4.Source = "ic_check_box.png";
                }
                else
                {
                    t08Image03_4.Source = "ic_check_box_outline_blank.png";
                }

                if (Erfassungsbogen.t08field03_05 == "1")
                {
                    t08Image03_5.Source = "ic_check_box.png";
                }
                else
                {
                    t08Image03_5.Source = "ic_check_box_outline_blank.png";
                }

                if (Erfassungsbogen.t08field03_06 == "1")
                {

                    t08Image03_6.Source = "ic_check_box.png";
                }
                else
                {
                    t08Image03_6.Source = "ic_check_box_outline_blank.png";
                }

                // text box 08_04

                t08field04.Text = Erfassungsbogen.t08field04;
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
            if (Erfassungsbogen.t08field03_01 != "1" | Erfassungsbogen.t08field03_01 == null)
            {
                t08Image03_1.Source = "ic_check_box.png";
                Erfassungsbogen.t08field03_01 = "1";
            }
            else
            {
                t08Image03_1.Source = "ic_check_box_outline_blank.png";
                Erfassungsbogen.t08field03_01 = "0";
            }
        }

        private void TapGestureRecognizer_Tapped_2(object sender, EventArgs e)
        {
            if (Erfassungsbogen.t08field03_02 != "1" | Erfassungsbogen.t08field03_02 == null)
            {
                t08Image03_2.Source = "ic_check_box.png";
                Erfassungsbogen.t08field03_02 = "1";
            }
            else
            {
                t08Image03_2.Source = "ic_check_box_outline_blank.png";
                Erfassungsbogen.t08field03_02 = "0";
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
                    //check height cm 
                    // Regex Value "Max3digits before . and 2 digits after .  ^\d{0,3}(\.\d{1,2})?$
                    if (Regex.IsMatch(t08Entry01.Text, @"^\d{0,3}(\.\d{1})?$"))
                    {
                        double cmValue = Convert.ToDouble(t08Entry01.Text, CultureInfo.InvariantCulture);
                        if (t08Entry01.Text != "")
                        {
                            if (cmValue < 100 | cmValue > 250)
                            {
                                await DisplayAlert(AppResources.AppError, "Wertebereich ist zwischen 100 und 250cm. Bitte überprüfen Sie Ihre Eingabe.", "OK");
                                SaveAllButton.Source = "ic_done_all.png";

                                //ActivityIndicator = Idle
                                IsLoading = false;
                                return;
                            }
                        }
                    }
                    else
                    {
                        await DisplayAlert(AppResources.AppError, "Das eingebene Format entspricht nicht dem erwarteten Format. Bitte verwenden Sie für die cm-Angabe nur eine Nachkommastelle und einen Punkt (z.B. 176.3) als Trennzeichen. Bitte überprüfen Sie Ihre Eingaben.", "OK");
                        SaveAllButton.Source = "ic_done_all.png";

                        //ActivityIndicator = Idle
                        IsLoading = false;
                        return;
                    }

                    //check weight kg
                    // Regex Value "Max3digits before . and 2 digits after .  ^\d{0,3}(\.\d{1,2})?$
                    if (Regex.IsMatch(t08Entry02.Text, @"^\d{0,3}(\.\d{1})?$"))
                    {
                        double kgValue = Convert.ToDouble(t08Entry02.Text, CultureInfo.InvariantCulture);
                        if (t08Entry02.Text != "")
                        {
                            if (kgValue < 0 | kgValue > 300)
                            {
                                await DisplayAlert(AppResources.AppError, "Wertebereich ist zwischen 0 und 300kg. Bitte überprüfen Sie Ihre Eingabe.", "OK");
                                SaveAllButton.Source = "ic_done_all.png";

                                //ActivityIndicator = Idle
                                IsLoading = false;
                                return;
                            }
                        }
                    }
                    else
                    {
                        await DisplayAlert(AppResources.AppError, "Das eingebene Format entspricht nicht dem erwarteten Format. Bitte verwenden Sie für die kg-Angabe nur eine Nachkommastelle und einen Punkt (z.B. 80.3) als Trennzeichen. Bitte überprüfen Sie Ihre Eingaben.", "OK");
                        SaveAllButton.Source = "ic_done_all.png";

                        //ActivityIndicator = Idle
                        IsLoading = false;
                        return;
                    }

                    //Set Text Entry Values in Erfassungsbogen
                    Erfassungsbogen.t08field01 = t08Entry01.Text;
                    Erfassungsbogen.t08field02_01 = t08Entry02.Text;

                    t08field01.TextColor = t08field02.TextColor = Label_t08field02_02.TextColor = t08field03.TextColor = t08field03_7.TextColor = AppManager.QuestionColor;

                    if (t08Entry01.Text != "" && t08Entry01.Text != null && t08Entry02.Text != "" && t08Entry02.Text != null && Erfassungsbogen.t08field02_02 != "" && Erfassungsbogen.t08field02_02 != null) 
                    {
                        if (Erfassungsbogen.t08field03_06 == "1")
                        {
                            if (t08field04.Text == "" | t08field04.Text == null)
                            {
                                t08field03_7.TextColor = Color.Red;

                                await DisplayAlert(AppResources.Warning, AppResources.FieldsUnfilled, "OK");
                                SaveAllButton.Source = "ic_done_all.png";
                            }
                            else
                            {
                                WebRequest req = WebRequest.Create(DBManagement.DBConnection + "tbl_form_ebqe_t08_01_update.php");

                                req.Method = "POST"; //POST
                                req.Timeout = 15000;
                                req.ContentType = "application/x-www-form-urlencoded";

                                string postData = "mstr=" + App.user.selected_mstr_ebqe + "&bewonerid=" + App.user.selected_id_bewohner + "&t08field01=" + Erfassungsbogen.t08field01 + "&t08field02_01=" + Erfassungsbogen.t08field02_01 + "&t08field02_02=" + Erfassungsbogen.t08field02_02 + "&t08field03_01=" + Erfassungsbogen.t08field03_01 + "&t08field03_02=" + Erfassungsbogen.t08field03_02 + "&t08field03_03=" + Erfassungsbogen.t08field03_03 + "&t08field03_04=" + Erfassungsbogen.t08field03_04 + "&t08field03_05=" + Erfassungsbogen.t08field03_05 + "&t08field03_06=" + Erfassungsbogen.t08field03_06 + "&t08field04=" + t08field04.Text;
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
                            t08field04.Text = "";

                            WebRequest req = WebRequest.Create(DBManagement.DBConnection + "tbl_form_ebqe_t08_01_update.php");

                            req.Method = "POST"; //POST
                            req.Timeout = 15000;
                            req.ContentType = "application/x-www-form-urlencoded";

                            string postData = "mstr=" + App.user.selected_mstr_ebqe + "&bewonerid=" + App.user.selected_id_bewohner + "&t08field01=" + Erfassungsbogen.t08field01 + "&t08field02_01=" + Erfassungsbogen.t08field02_01 + "&t08field02_02=" + Erfassungsbogen.t08field02_02 + "&t08field03_01=" + Erfassungsbogen.t08field03_01 + "&t08field03_02=" + Erfassungsbogen.t08field03_02 + "&t08field03_03=" + Erfassungsbogen.t08field03_03 + "&t08field03_04=" + Erfassungsbogen.t08field03_04 + "&t08field03_05=" + Erfassungsbogen.t08field03_05 + "&t08field03_06=" + Erfassungsbogen.t08field03_06 + "&t08field04=" + t08field04.Text;
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
                        if (t08Entry01.Text == "" || t08Entry01.Text == null)
                        {
                            t08field01.TextColor = Color.Red;
                        }
                        if (t08Entry02.Text == "" || t08Entry02.Text == null)
                        {
                            t08field02.TextColor = Color.Red;
                        }
                        if (Erfassungsbogen.t08field02_02 == "" || Erfassungsbogen.t08field02_02 == null)
                        {
                            Label_t08field02_02.TextColor = Color.Red;
                        }
                        if (Erfassungsbogen.t08field03_06 == "1")
                        {
                            if (t08field04.Text == "" | t08field04.Text == null)
                            {
                                t08field03_7.TextColor = Color.Red;
                            }
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
                        WebRequest req = WebRequest.Create(DBManagement.DBConnection + "tbl_form_ebqe_t08_01_update_clear.php");

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

        private void TapGestureRecognizer_Tapped_3(object sender, EventArgs e)
        {
            if (Erfassungsbogen.t08field03_03 != "1" | Erfassungsbogen.t08field03_03 == null)
            {
                t08Image03_3.Source = "ic_check_box.png";
                Erfassungsbogen.t08field03_03 = "1";
            }
            else
            {
                t08Image03_3.Source = "ic_check_box_outline_blank.png";
                Erfassungsbogen.t08field03_03 = "0";
            }
        }

        private void TapGestureRecognizer_Tapped_4(object sender, EventArgs e)
        {
            if (Erfassungsbogen.t08field03_04 != "1" | Erfassungsbogen.t08field03_04 == null)
            {
                t08Image03_4.Source = "ic_check_box.png";
                Erfassungsbogen.t08field03_04 = "1";
            }
            else
            {
                t08Image03_4.Source = "ic_check_box_outline_blank.png";
                Erfassungsbogen.t08field03_04 = "0";
            }
        }

        private void TapGestureRecognizer_Tapped_5(object sender, EventArgs e)
        {
            if (Erfassungsbogen.t08field03_05 != "1" | Erfassungsbogen.t08field03_05 == null)
            {
                t08Image03_5.Source = "ic_check_box.png";
                Erfassungsbogen.t08field03_05 = "1";
            }
            else
            {
                t08Image03_5.Source = "ic_check_box_outline_blank.png";
                Erfassungsbogen.t08field03_05 = "0";
            }
        }

        private void TapGestureRecognizer_Tapped_6(object sender, EventArgs e)
        {
            if (Erfassungsbogen.t08field03_06 != "1" | Erfassungsbogen.t08field03_06 == null)
            {
                t08Image03_6.Source = "ic_check_box.png";
                Erfassungsbogen.t08field03_06 = "1";
            }
            else
            {
                t08Image03_6.Source = "ic_check_box_outline_blank.png";
                Erfassungsbogen.t08field03_06 = "0";
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
                        //check height cm 
                        // Regex Value "Max3digits before . and 2 digits after .  ^\d{0,3}(\.\d{1,2})?$
                        if (Regex.IsMatch(t08Entry01.Text, @"^\d{0,3}(\.\d{1})?$"))
                        {
                            double cmValue = Convert.ToDouble(t08Entry01.Text, CultureInfo.InvariantCulture);
                            if (t08Entry01.Text != "")
                            {
                                if (cmValue < 100 | cmValue > 250)
                                {
                                    await DisplayAlert(AppResources.AppError, "Wertebereich ist zwischen 100 und 250cm. Bitte überprüfen Sie Ihre Eingabe.", "OK");
                                    SaveAllButton.Source = "ic_done_all.png";

                                    //ActivityIndicator = Idle
                                    IsLoading = false;
                                    return;
                                }
                            }
                        }
                        else
                        {
                            await DisplayAlert(AppResources.AppError, "Das eingebene Format entspricht nicht dem erwarteten Format. Bitte verwenden Sie für die cm-Angabe nur eine Nachkommastelle und einen Punkt (z.B. 176.3) als Trennzeichen. Bitte überprüfen Sie Ihre Eingaben.", "OK");
                            SaveAllButton.Source = "ic_done_all.png";

                            //ActivityIndicator = Idle
                            IsLoading = false;
                            return;
                        }

                        //check weight kg
                        // Regex Value "Max3digits before . and 2 digits after .  ^\d{0,3}(\.\d{1,2})?$
                        if (Regex.IsMatch(t08Entry02.Text, @"^\d{0,3}(\.\d{1})?$"))
                        {
                            double kgValue = Convert.ToDouble(t08Entry02.Text, CultureInfo.InvariantCulture);
                            if (t08Entry02.Text != "")
                            {
                                if (kgValue < 0 | kgValue > 300)
                                {
                                    await DisplayAlert(AppResources.AppError, "Wertebereich ist zwischen 0 und 300kg. Bitte überprüfen Sie Ihre Eingabe.", "OK");
                                    SaveAllButton.Source = "ic_done_all.png";

                                    //ActivityIndicator = Idle
                                    IsLoading = false;
                                    return;
                                }
                            }
                        }
                        else
                        {
                            await DisplayAlert(AppResources.AppError, "Das eingebene Format entspricht nicht dem erwarteten Format. Bitte verwenden Sie für die kg-Angabe nur eine Nachkommastelle und einen Punkt (z.B. 80.3) als Trennzeichen. Bitte überprüfen Sie Ihre Eingaben.", "OK");
                            SaveAllButton.Source = "ic_done_all.png";

                            //ActivityIndicator = Idle
                            IsLoading = false;
                            return;
                        }

                        //Set Text Entry Values in Erfassungsbogen
                        Erfassungsbogen.t08field01 = t08Entry01.Text;
                        Erfassungsbogen.t08field02_01 = t08Entry02.Text;

                        t08field01.TextColor = t08field02.TextColor = Label_t08field02_02.TextColor = t08field03.TextColor = t08field03_7.TextColor = AppManager.QuestionColor;

                        if (t08Entry01.Text != "" && t08Entry01.Text != null && t08Entry02.Text != "" && t08Entry02.Text != null && Erfassungsbogen.t08field02_02 != "" && Erfassungsbogen.t08field02_02 != null)
                        {
                            if (Erfassungsbogen.t08field03_06 == "1")
                            {
                                if (t08field04.Text == "" | t08field04.Text == null)
                                {
                                    t08field03_7.TextColor = Color.Red;

                                    await DisplayAlert(AppResources.Warning, AppResources.FieldsUnfilled, "OK");
                                    BackButton.Source = "ic_arrow_back_ios.png";
                                }
                                else
                                {
                                    WebRequest req = WebRequest.Create(DBManagement.DBConnection + "tbl_form_ebqe_t08_01_update.php");

                                    req.Method = "POST"; //POST
                                    req.Timeout = 15000;
                                    req.ContentType = "application/x-www-form-urlencoded";

                                    string postData = "mstr=" + App.user.selected_mstr_ebqe + "&bewonerid=" + App.user.selected_id_bewohner + "&t08field01=" + Erfassungsbogen.t08field01 + "&t08field02_01=" + Erfassungsbogen.t08field02_01 + "&t08field02_02=" + Erfassungsbogen.t08field02_02 + "&t08field03_01=" + Erfassungsbogen.t08field03_01 + "&t08field03_02=" + Erfassungsbogen.t08field03_02 + "&t08field03_03=" + Erfassungsbogen.t08field03_03 + "&t08field03_04=" + Erfassungsbogen.t08field03_04 + "&t08field03_05=" + Erfassungsbogen.t08field03_05 + "&t08field03_06=" + Erfassungsbogen.t08field03_06 + "&t08field04=" + t08field04.Text;
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
                                t08field04.Text = "";

                                WebRequest req = WebRequest.Create(DBManagement.DBConnection + "tbl_form_ebqe_t08_01_update.php");

                                req.Method = "POST"; //POST
                                req.Timeout = 15000;
                                req.ContentType = "application/x-www-form-urlencoded";

                                string postData = "mstr=" + App.user.selected_mstr_ebqe + "&bewonerid=" + App.user.selected_id_bewohner + "&t08field01=" + Erfassungsbogen.t08field01 + "&t08field02_01=" + Erfassungsbogen.t08field02_01 + "&t08field02_02=" + Erfassungsbogen.t08field02_02 + "&t08field03_01=" + Erfassungsbogen.t08field03_01 + "&t08field03_02=" + Erfassungsbogen.t08field03_02 + "&t08field03_03=" + Erfassungsbogen.t08field03_03 + "&t08field03_04=" + Erfassungsbogen.t08field03_04 + "&t08field03_05=" + Erfassungsbogen.t08field03_05 + "&t08field03_06=" + Erfassungsbogen.t08field03_06 + "&t08field04=" + t08field04.Text;
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
                            if (t08Entry01.Text == "" || t08Entry01.Text == null)
                            {
                                t08field01.TextColor = Color.Red;
                            }
                            if (t08Entry02.Text == "" || t08Entry02.Text == null)
                            {
                                t08field02.TextColor = Color.Red;
                            }
                            if (Erfassungsbogen.t08field02_02 == "" || Erfassungsbogen.t08field02_02 == null)
                            {
                                Label_t08field02_02.TextColor = Color.Red;
                            }
                            if (Erfassungsbogen.t08field03_06 == "1")
                            {
                                if (t08field04.Text == "" | t08field04.Text == null)
                                {
                                    t08field03_7.TextColor = Color.Red;
                                }
                            }

                            await DisplayAlert(AppResources.Warning, AppResources.FieldsUnfilled, "OK");
                            BackButton.Source = "ic_arrow_back_ios.png";
                        }
                    }
                    else
                    {
                        Erfassungsbogen.t08field01 = Erfassungsbogen.t08field02_01 = Erfassungsbogen.t08field02_02 = Erfassungsbogen.t08field03_01 = Erfassungsbogen.t08field03_02 = Erfassungsbogen.t08field03_03 = Erfassungsbogen.t08field03_04 = Erfassungsbogen.t08field03_05 = Erfassungsbogen.t08field03_06 = Erfassungsbogen.t08field04 = "";

                        t08Entry01.Text = t08Entry02.Text = t08field04.Text = "";

                        WebRequest req = WebRequest.Create(DBManagement.DBConnection + "tbl_form_ebqe_t08_01_update.php");

                        req.Method = "POST"; //POST
                        req.Timeout = 15000;
                        req.ContentType = "application/x-www-form-urlencoded";

                        string postData = "mstr=" + App.user.selected_mstr_ebqe + "&bewonerid=" + App.user.selected_id_bewohner + "&t08field01=" + Erfassungsbogen.t08field01 + "&t08field02_01=" + Erfassungsbogen.t08field02_01 + "&t08field02_02=" + Erfassungsbogen.t08field02_02 + "&t08field03_01=" + Erfassungsbogen.t08field03_01 + "&t08field03_02=" + Erfassungsbogen.t08field03_02 + "&t08field03_03=" + Erfassungsbogen.t08field03_03 + "&t08field03_04=" + Erfassungsbogen.t08field03_04 + "&t08field03_05=" + Erfassungsbogen.t08field03_05 + "&t08field03_06=" + Erfassungsbogen.t08field03_06 + "&t08field04=" + t08field04.Text;
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

        #region t08field01 cm Test / t08field02_01 kg Test

        //private void Entryt08field01_Unfocused(object sender, DateChangedEventArgs e)
        //{
        //    double cmValue;
        //    double.TryParse(t08Entry01.Text, out cmValue);

        //    if (t08Entry01.Text != "")
        //    {
        //        if (cmValue < 100 | cmValue > 250)
        //        {
        //            DisplayAlert(AppResources.AppError, "Wertebereich ist zwischen 100 und 250. Bitte überprüfen Sie Ihre Eingabe.", "OK");
        //            t08Entry01.Focus();
        //        }
        //    }
        //}

        private void Entryt08field01_Unfocused(object sender, TextChangedEventArgs e)
        {
            // Regex Value "Max3digits before . and 2 digits after .  ^\d{0,3}(\.\d{1,2})?$
            if (Regex.IsMatch(t08Entry01.Text, @"^\d{0,3}(\.\d{1})?$"))
            {
                double cmValue = Convert.ToDouble(t08Entry01.Text, CultureInfo.InvariantCulture);
                if (t08Entry01.Text != "")
                {
                    if (cmValue < 100 | cmValue > 250)
                    {
                        DisplayAlert(AppResources.AppError, "Wertebereich ist zwischen 100 und 250cm. Bitte überprüfen Sie Ihre Eingabe.", "OK");
                        t08Entry01.Focus();
                    }
                }
            }
            else
            {
                DisplayAlert(AppResources.AppError, "Das eingebene Format entspricht nicht dem erwarteten Format. Bitte verwenden Sie für die cm-Angabe nur eine Nachkommastelle und einen Punkt (z.B. 176.3) als Trennzeichen. Bitte überprüfen Sie Ihre Eingaben.", "OK");
                t08Entry01.Focus();
            }
        }


        private void Entryt08field02_01_Unfocused(object sender, TextChangedEventArgs e)
        {
            // Regex Value "Max3digits before . and 2 digits after .  ^\d{0,3}(\.\d{1,2})?$
            if (Regex.IsMatch(t08Entry02.Text, @"^\d{0,3}(\.\d{1})?$"))
            {
                double kgValue = Convert.ToDouble(t08Entry02.Text, CultureInfo.InvariantCulture);
                if (t08Entry02.Text != "")
                {
                    if (kgValue < 0 | kgValue > 300)
                    {
                        DisplayAlert(AppResources.AppError, "Wertebereich ist zwischen 0 und 300kg. Bitte überprüfen Sie Ihre Eingabe.", "OK");
                        t08Entry02.Focus();
                    }
                }
            }
            else
            {
                DisplayAlert(AppResources.AppError, "Das eingebene Format entspricht nicht dem erwarteten Format. Bitte verwenden Sie für die kg-Angabe nur eine Nachkommastelle und einen Punkt (z.B. 80.3) als Trennzeichen. Bitte überprüfen Sie Ihre Eingaben.", "OK");
                t08Entry02.Focus();
            }
        }

        #endregion

        #region t08field02_02

        private void ResetLabel_t08field02_02_Tapped(object sender, EventArgs e)
        {
            Erfassungsbogen.t08field02_02 = "";
            Entry_t08field02_02.Text = "";
        }

        private void Entry_t08field02_02_Focused(object sender, FocusEventArgs e)
        {
            Entry_t08field02_02.Unfocus();
            DatePicker_t08field02_02.Focus();
        }

        private void DatePicker_t08field02_02_Unfocused(object sender, DateChangedEventArgs e)
        {
            Erfassungsbogen.t08field02_02 = DatePicker_t08field02_02.Date.ToString("dd.MM.yyyy");
            Entry_t08field02_02.Text = DatePicker_t08field02_02.Date.ToString("dd.MM.yyyy");
        }

        private void DatePicker_t08field02_02_DateSelected(object sender, DateChangedEventArgs e)
        {
            Erfassungsbogen.t08field02_02 = DatePicker_t08field02_02.Date.ToString("dd.MM.yyyy");
            Entry_t08field02_02.Text = DatePicker_t08field02_02.Date.ToString("dd.MM.yyyy");
        }

        #endregion

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

        //private void Entryt08field02_01_Unfocused(object sender, FocusEventArgs e)
        //{
        //    double kgValue;
        //    double.TryParse(t08Entry02.Text, out kgValue);

        //    if (t08Entry02.Text != "")
        //    {
        //        if (kgValue < 0 | kgValue > 300)
        //        {
        //            DisplayAlert(AppResources.AppError, "Wertebereich ist zwischen 0 und 300. Bitte überprüfen Sie Ihre Eingabe.", "OK");
        //            t08Entry02.Focus();
        //        }
        //    }
        //}
    }
}