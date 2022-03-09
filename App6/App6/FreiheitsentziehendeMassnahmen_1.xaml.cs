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
    public partial class FreiheitsentziehendeMassnahmen_1 : ContentPage, INotifyPropertyChanged
    {
        public bool InitialDataIsEmpty;

        public FreiheitsentziehendeMassnahmen_1()
        {
            InitializeComponent();
            BindingContext = this;

            BogenLabel.Text = AppResources.SurveyHeadline + " " + DBManagement.getYearCode(App.user.selected_mstr_ebqe) + " " + AppResources.SurveyHeadlineFor + " " + Erfassungsbogen.Bewohnerbezeichnung;

            // picker 1
            t10Picker01.Items.Add("ja");
            t10Picker01.Items.Add("nein (bei nein weiter mit Frage 10.b)");

            // picker 2
            t10Picker03.Items.Add("täglich");
            t10Picker03.Items.Add("mehrmals wöchentlich");
            t10Picker03.Items.Add("1x wöchentlich");
            t10Picker03.Items.Add("seltener als 1x wöchentlich");

            // picker 3
            t10Picker04.Items.Add("ja");
            t10Picker04.Items.Add("nein");
        }

        private void T10Picker01_SelectedIndexChanged(object sender, EventArgs e)
        {
            // T09 01
            if (t10Picker01.SelectedIndex == 0)
            {
                Erfassungsbogen.t10field01 = "1";

                t10field02.IsEnabled =
                t10Image02_1.IsEnabled =
                t10field02_1.IsEnabled =
                t10Image02_2.IsEnabled =
                t10field02_2.IsEnabled =
                t10Image02_3.IsEnabled =
                t10field02_3.IsEnabled =
                t10Image02_4.IsEnabled =
                t10field02_4.IsEnabled =
                t10field03.IsEnabled =
                t10Picker03.IsEnabled =
                t10field04.IsEnabled =
                t10Picker04.IsEnabled = true;

                t10field02.Opacity =
                t10Image02_1.Opacity =
                t10field02_1.Opacity =
                t10Image02_2.Opacity =
                t10field02_2.Opacity =
                t10Image02_3.Opacity =
                t10field02_3.Opacity =
                t10Image02_4.Opacity =
                t10field02_4.Opacity =
                t10field03.Opacity =
                t10Picker03.Opacity =
                t10field04.Opacity =
                t10Picker04.Opacity = AppManager.AnswerOpacity;

            }
            else if (t10Picker01.SelectedIndex == 1)
            {
                Erfassungsbogen.t10field01 = "0";

                t10field02.IsEnabled =
                  t10Image02_1.IsEnabled =
                  t10field02_1.IsEnabled =
                  t10Image02_2.IsEnabled =
                  t10field02_2.IsEnabled =
                  t10Image02_3.IsEnabled =
                  t10field02_3.IsEnabled =
                  t10Image02_4.IsEnabled =
                  t10field02_4.IsEnabled =
                  t10field03.IsEnabled =
                  t10Picker03.IsEnabled =
                  t10field04.IsEnabled =
                  t10Picker04.IsEnabled = false;

                t10field02.Opacity =
                t10Image02_1.Opacity =
                t10field02_1.Opacity =
                t10Image02_2.Opacity =
                t10field02_2.Opacity =
                t10Image02_3.Opacity =
                t10field02_3.Opacity =
                t10Image02_4.Opacity =
                t10field02_4.Opacity =
                t10field03.Opacity =
                t10Picker03.Opacity =
                t10field04.Opacity =
                t10Picker04.Opacity = AppManager.AnswerDisabledOpacity;
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

                //WebRequest req = WebRequest.Create(DBManagement.DBConnection + "tbl_form_ebqe_t10_01_read.php");

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

                //Erfassungsbogen.t10field01 = split[0];

                //Erfassungsbogen.t10field02_01 = split[1];
                //Erfassungsbogen.t10field02_02 = split[2];
                //Erfassungsbogen.t10field02_03 = split[3];
                //Erfassungsbogen.t10field02_04 = split[4];

                //Erfassungsbogen.t10field03 = split[5];

                //Erfassungsbogen.t10field04 = split[6];

                if (Erfassungsbogen.t10field01 == "0")
                {
                    t10field02.IsEnabled =
                  t10Image02_1.IsEnabled =
                  t10field02_1.IsEnabled =
                  t10Image02_2.IsEnabled =
                  t10field02_2.IsEnabled =
                  t10Image02_3.IsEnabled =
                  t10field02_3.IsEnabled =
                  t10Image02_4.IsEnabled =
                  t10field02_4.IsEnabled =
                  t10field03.IsEnabled =
                  t10Picker03.IsEnabled =
                  t10field04.IsEnabled =
                  t10Picker04.IsEnabled = false;

                    t10field02.Opacity =
                    t10Image02_1.Opacity =
                    t10field02_1.Opacity =
                    t10Image02_2.Opacity =
                    t10field02_2.Opacity =
                    t10Image02_3.Opacity =
                    t10field02_3.Opacity =
                    t10Image02_4.Opacity =
                    t10field02_4.Opacity =
                    t10field03.Opacity =
                    t10Picker03.Opacity =
                    t10field04.Opacity =
                    t10Picker04.Opacity = AppManager.AnswerDisabledOpacity;
                }

                // picker 10_01

                if (Erfassungsbogen.t10field01 == "1")
                {
                    t10Picker01.SelectedIndex = 0;                         // whether ja==0 by default or not ??
                }
                else if (Erfassungsbogen.t10field01 == "0")
                {
                    t10Picker01.SelectedIndex = 1;
                }
                else
                {
                    t10Picker01.SelectedIndex = -1;
                }

                // picker 10_03

                if (Erfassungsbogen.t10field03 == "1")
                {
                    t10Picker03.SelectedIndex = 0;      // rb1 is the image file with checked box image
                }
                else if (Erfassungsbogen.t10field03 == "2")
                {
                    t10Picker03.SelectedIndex = 1;
                }
                else if (Erfassungsbogen.t10field03 == "3")
                {
                    t10Picker03.SelectedIndex = 2;
                }
                else if (Erfassungsbogen.t10field03 == "4")
                {
                    t10Picker03.SelectedIndex = 3;
                }
                else
                {
                    t10Picker03.SelectedIndex = -1;
                }

                // picker 10_04

                if (Erfassungsbogen.t10field04 == "1")
                {
                    t10Picker04.SelectedIndex = 0;                         // whether ja==0 by default or not ??
                }
                else if (Erfassungsbogen.t10field04 == "0")
                {
                    t10Picker04.SelectedIndex = 1;
                }
                else
                {
                    t10Picker04.SelectedIndex = -1;
                }

                // check boxes 10_021_01----02_04

                if (Erfassungsbogen.t10field02_01 == "1")
                {
                    t10Image02_1.Source = "ic_check_box.png";                            // rb1 is the image file with checked box image
                }
                else
                {
                    t10Image02_1.Source = "ic_check_box_outline_blank.png";
                }

                if (Erfassungsbogen.t10field02_02 == "1")
                {
                    t10Image02_2.Source = "ic_check_box.png";
                }
                else
                {
                    t10Image02_2.Source = "ic_check_box_outline_blank.png";
                }


                if (Erfassungsbogen.t10field02_03 == "1")
                {
                    t10Image02_3.Source = "ic_check_box.png";
                }
                else
                {
                    t10Image02_3.Source = "ic_check_box_outline_blank.png";
                }

                if (Erfassungsbogen.t10field02_04 == "1")
                {
                    t10Image02_4.Source = "ic_check_box.png";
                }
                else
                {
                    t10Image02_4.Source = "ic_check_box_outline_blank.png";
                }
                //ActivityIndicator = Idle
                IsLoading = false;

            }
            catch (Exception)
            {
                await DisplayAlert(AppResources.AppError, AppResources.AppErrorMsg, "OK");
            }
        }

        private void T10Picker03_SelectedIndexChanged(object sender, EventArgs e)
        {
            // T10 03

            if (t10Picker03.SelectedIndex == 0)
            {
                Erfassungsbogen.t10field03 = "1";
            }
            else if (t10Picker03.SelectedIndex == 1)
            {
                Erfassungsbogen.t10field03 = "2";
            }
            else if (t10Picker03.SelectedIndex == 2)
            {
                Erfassungsbogen.t10field03 = "3";
            }
            else if (t10Picker03.SelectedIndex == 3)
            {
                Erfassungsbogen.t10field03 = "4";
            }
        }

        private void T10Picker04_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (t10Picker04.SelectedIndex == 0)
            {
                Erfassungsbogen.t10field04 = "1";
            }
            else if (t10Picker04.SelectedIndex == 1)
            {
                Erfassungsbogen.t10field04 = "0";
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
                        t10field01.TextColor = t10field02.TextColor = t10field03.TextColor = t10field04.TextColor = AppManager.QuestionColor;

                        if ((Erfassungsbogen.t10field01 == "") || (Erfassungsbogen.t10field01 == null))
                        {
                            t10field01.TextColor = Color.Red;
                        }
                        else
                        {
                            if (Erfassungsbogen.t10field01 == "1" || (Erfassungsbogen.t10field01 == "" && Erfassungsbogen.t10field01 == null))
                            {
                                if ((Erfassungsbogen.t10field01 != "" && Erfassungsbogen.t10field01 != null) && ((Erfassungsbogen.t10field02_01 != "" && Erfassungsbogen.t10field02_01 != null && Erfassungsbogen.t10field02_01 != "0") || (Erfassungsbogen.t10field02_02 != "" && Erfassungsbogen.t10field02_02 != null && Erfassungsbogen.t10field02_02 != "0") || (Erfassungsbogen.t10field02_03 != "" && Erfassungsbogen.t10field02_03 != null && Erfassungsbogen.t10field02_03 != "0") || (Erfassungsbogen.t10field02_04 != "" && Erfassungsbogen.t10field02_04 != null && Erfassungsbogen.t10field02_04 != "0")) && (Erfassungsbogen.t10field03 != "" && Erfassungsbogen.t10field03 != null) && (Erfassungsbogen.t10field04 != "" && Erfassungsbogen.t10field04 != null))
                                {
                                    WebRequest req = WebRequest.Create(DBManagement.DBConnection + "tbl_form_ebqe_t10_01_update.php");

                                    req.Method = "POST"; //POST
                                    req.Timeout = 15000;
                                    req.ContentType = "application/x-www-form-urlencoded";

                                    string postData = "mstr=" + App.user.selected_mstr_ebqe + "&bewonerid=" + App.user.selected_id_bewohner + "&t10field01=" + Erfassungsbogen.t10field01 + "&t10field02_01=" + Erfassungsbogen.t10field02_01 + "&t10field02_02=" + Erfassungsbogen.t10field02_02 + "&t10field02_03=" + Erfassungsbogen.t10field02_03 + "&t10field02_04=" + Erfassungsbogen.t10field02_04 + "&t10field03=" + Erfassungsbogen.t10field03 + "&t10field04=" + Erfassungsbogen.t10field04;
                                    byte[] byteArray = Encoding.UTF8.GetBytes(postData);

                                    req.ContentLength = byteArray.Length;

                                    Stream ds = await req.GetRequestStreamAsync();
                                    await ds.WriteAsync(byteArray, 0, byteArray.Length);
                                    ds.Close();

                                    await Navigation.PushAsync(new SearchPage());
                                }
                                else
                                {
                                    if (Erfassungsbogen.t10field01 == "" || Erfassungsbogen.t10field01 == null)
                                    {
                                        t10field01.TextColor = Color.Red;
                                    }

                                    if ((Erfassungsbogen.t10field02_01 == "" || Erfassungsbogen.t10field02_01 == null || Erfassungsbogen.t10field02_01 == "0") && (Erfassungsbogen.t10field02_02 == "" || Erfassungsbogen.t10field02_02 == null || Erfassungsbogen.t10field02_02 == "0") && (Erfassungsbogen.t10field02_03 == "" || Erfassungsbogen.t10field02_03 == null || Erfassungsbogen.t10field02_03 == "0") && (Erfassungsbogen.t10field02_04 == "" || Erfassungsbogen.t10field02_04 == null || Erfassungsbogen.t10field02_04 == "0"))
                                    {
                                        t10field02.TextColor = Color.Red;
                                    }

                                    if (Erfassungsbogen.t10field03 == "" || Erfassungsbogen.t10field03 == null)
                                    {
                                        t10field03.TextColor = Color.Red;
                                    }
                                    if (Erfassungsbogen.t10field04 == "" || Erfassungsbogen.t10field04 == null)
                                    {
                                        t10field04.TextColor = Color.Red;
                                    }
                                    await DisplayAlert(AppResources.Warning, AppResources.FieldsUnfilled, "OK");
                                    BackButton.Source = "ic_arrow_back_ios.png";
                                }
                            }
                            else
                            {
                                Erfassungsbogen.t10field02_01 = "";
                                Erfassungsbogen.t10field02_02 = "";
                                Erfassungsbogen.t10field02_03 = "";
                                Erfassungsbogen.t10field02_04 = "";
                                Erfassungsbogen.t10field03 = "";
                                Erfassungsbogen.t10field04 = "";

                                WebRequest req = WebRequest.Create(DBManagement.DBConnection + "tbl_form_ebqe_t10_01_update.php");

                                req.Method = "POST"; //POST
                                req.Timeout = 15000;
                                req.ContentType = "application/x-www-form-urlencoded";

                                string postData = "mstr=" + App.user.selected_mstr_ebqe + "&bewonerid=" + App.user.selected_id_bewohner + "&t10field01=" + Erfassungsbogen.t10field01 + "&t10field02_01=" + Erfassungsbogen.t10field02_01 + "&t10field02_02=" + Erfassungsbogen.t10field02_02 + "&t10field02_03=" + Erfassungsbogen.t10field02_03 + "&t10field02_04=" + Erfassungsbogen.t10field02_04 + "&t10field03=" + Erfassungsbogen.t10field03 + "&t10field04=" + Erfassungsbogen.t10field04;
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
                        Erfassungsbogen.t10field01 = Erfassungsbogen.t10field02_01 = Erfassungsbogen.t10field02_02 = Erfassungsbogen.t10field02_03 = Erfassungsbogen.t10field02_04 = Erfassungsbogen.t10field03 = Erfassungsbogen.t10field04 = "";

                        WebRequest req = WebRequest.Create(DBManagement.DBConnection + "tbl_form_ebqe_t10_01_update.php");

                        req.Method = "POST"; //POST
                        req.Timeout = 15000;
                        req.ContentType = "application/x-www-form-urlencoded";

                        string postData = "mstr=" + App.user.selected_mstr_ebqe + "&bewonerid=" + App.user.selected_id_bewohner + "&t10field01=" + Erfassungsbogen.t10field01 + "&t10field02_01=" + Erfassungsbogen.t10field02_01 + "&t10field02_02=" + Erfassungsbogen.t10field02_02 + "&t10field02_03=" + Erfassungsbogen.t10field02_03 + "&t10field02_04=" + Erfassungsbogen.t10field02_04 + "&t10field03=" + Erfassungsbogen.t10field03 + "&t10field04=" + Erfassungsbogen.t10field04;
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
                    await Navigation.PushAsync(new FreiheitsentziehendeMassnahmen_2());
                }
                else
                {
                    t10field01.TextColor = t10field02.TextColor = t10field03.TextColor = t10field04.TextColor = AppManager.QuestionColor;

                    if ((Erfassungsbogen.t10field01 == "") || (Erfassungsbogen.t10field01 == null))
                    {
                        t10field01.TextColor = Color.Red;
                    }
                    else
                    {
                        if (Erfassungsbogen.t10field01 == "1" || (Erfassungsbogen.t10field01 == "" && Erfassungsbogen.t10field01 == null))
                        {
                            if ((Erfassungsbogen.t10field01 != "" && Erfassungsbogen.t10field01 != null) && ((Erfassungsbogen.t10field02_01 != "" && Erfassungsbogen.t10field02_01 != null && Erfassungsbogen.t10field02_01 != "0") || (Erfassungsbogen.t10field02_02 != "" && Erfassungsbogen.t10field02_02 != null && Erfassungsbogen.t10field02_02 != "0") || (Erfassungsbogen.t10field02_03 != "" && Erfassungsbogen.t10field02_03 != null && Erfassungsbogen.t10field02_03 != "0") || (Erfassungsbogen.t10field02_04 != "" && Erfassungsbogen.t10field02_04 != null && Erfassungsbogen.t10field02_04 != "0")) && (Erfassungsbogen.t10field03 != "" && Erfassungsbogen.t10field03 != null) && (Erfassungsbogen.t10field04 != "" && Erfassungsbogen.t10field04 != null))
                            {
                                WebRequest req = WebRequest.Create(DBManagement.DBConnection + "tbl_form_ebqe_t10_01_update.php");

                                req.Method = "POST"; //POST
                                req.Timeout = 15000;
                                req.ContentType = "application/x-www-form-urlencoded";

                                string postData = "mstr=" + App.user.selected_mstr_ebqe + "&bewonerid=" + App.user.selected_id_bewohner + "&t10field01=" + Erfassungsbogen.t10field01 + "&t10field02_01=" + Erfassungsbogen.t10field02_01 + "&t10field02_02=" + Erfassungsbogen.t10field02_02 + "&t10field02_03=" + Erfassungsbogen.t10field02_03 + "&t10field02_04=" + Erfassungsbogen.t10field02_04 + "&t10field03=" + Erfassungsbogen.t10field03 + "&t10field04=" + Erfassungsbogen.t10field04;
                                byte[] byteArray = Encoding.UTF8.GetBytes(postData);

                                req.ContentLength = byteArray.Length;

                                Stream ds = await req.GetRequestStreamAsync();
                                await ds.WriteAsync(byteArray, 0, byteArray.Length);
                                ds.Close();

                                await Navigation.PushAsync(new FreiheitsentziehendeMassnahmen_2());
                            }
                            else
                            {
                                if (Erfassungsbogen.t10field01 == "" || Erfassungsbogen.t10field01 == null)
                                {
                                    t10field01.TextColor = Color.Red;
                                }

                                if ((Erfassungsbogen.t10field02_01 == "" || Erfassungsbogen.t10field02_01 == null || Erfassungsbogen.t10field02_01 == "0") && (Erfassungsbogen.t10field02_02 == "" || Erfassungsbogen.t10field02_02 == null || Erfassungsbogen.t10field02_02 == "0") && (Erfassungsbogen.t10field02_03 == "" || Erfassungsbogen.t10field02_03 == null || Erfassungsbogen.t10field02_03 == "0") && (Erfassungsbogen.t10field02_04 == "" || Erfassungsbogen.t10field02_04 == null || Erfassungsbogen.t10field02_04 == "0"))
                                {
                                    t10field02.TextColor = Color.Red;
                                }

                                if (Erfassungsbogen.t10field03 == "" || Erfassungsbogen.t10field03 == null)
                                {
                                    t10field03.TextColor = Color.Red;
                                }
                                if (Erfassungsbogen.t10field04 == "" || Erfassungsbogen.t10field04 == null)
                                {
                                    t10field04.TextColor = Color.Red;
                                }
                                await DisplayAlert(AppResources.Warning, AppResources.FieldsUnfilled, "OK");
                                ForwardButton.Source = "ic_arrow_forward_ios.png";
                            }
                        }
                        else
                        {
                            Erfassungsbogen.t10field02_01 = "";
                            Erfassungsbogen.t10field02_02 = "";
                            Erfassungsbogen.t10field02_03 = "";
                            Erfassungsbogen.t10field02_04 = "";
                            Erfassungsbogen.t10field03 = "";
                            Erfassungsbogen.t10field04 = "";

                            WebRequest req = WebRequest.Create(DBManagement.DBConnection + "tbl_form_ebqe_t10_01_update.php");

                            req.Method = "POST"; //POST
                            req.Timeout = 15000;
                            req.ContentType = "application/x-www-form-urlencoded";

                            string postData = "mstr=" + App.user.selected_mstr_ebqe + "&bewonerid=" + App.user.selected_id_bewohner + "&t10field01=" + Erfassungsbogen.t10field01 + "&t10field02_01=" + Erfassungsbogen.t10field02_01 + "&t10field02_02=" + Erfassungsbogen.t10field02_02 + "&t10field02_03=" + Erfassungsbogen.t10field02_03 + "&t10field02_04=" + Erfassungsbogen.t10field02_04 + "&t10field03=" + Erfassungsbogen.t10field03 + "&t10field04=" + Erfassungsbogen.t10field04;
                            byte[] byteArray = Encoding.UTF8.GetBytes(postData);

                            req.ContentLength = byteArray.Length;

                            Stream ds = await req.GetRequestStreamAsync();
                            await ds.WriteAsync(byteArray, 0, byteArray.Length);
                            ds.Close();

                            await Navigation.PushAsync(new FreiheitsentziehendeMassnahmen_2());
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

        private void TapGestureRecognizer_Tapped_2(object sender, EventArgs e)
        {
            if (Erfassungsbogen.t10field02_01 != "1" | Erfassungsbogen.t10field02_01 == null)
            {
                t10Image02_1.Source = "ic_check_box.png";
                Erfassungsbogen.t10field02_01 = "1";
            }
            else
            {
                t10Image02_1.Source = "ic_check_box_outline_blank.png";
                Erfassungsbogen.t10field02_01 = "0";
            }
        }

        private void TapGestureRecognizer_Tapped_3(object sender, EventArgs e)
        {
            if (Erfassungsbogen.t10field02_02 != "1" | Erfassungsbogen.t10field02_02 == null)
            {
                t10Image02_2.Source = "ic_check_box.png";
                Erfassungsbogen.t10field02_02 = "1";
            }
            else
            {
                t10Image02_2.Source = "ic_check_box_outline_blank.png";
                Erfassungsbogen.t10field02_02 = "0";
            }
        }

        private void TapGestureRecognizer_Tapped_4(object sender, EventArgs e)
        {
            if (Erfassungsbogen.t10field02_03 != "1" | Erfassungsbogen.t10field02_03 == null)
            {
                t10Image02_3.Source = "ic_check_box.png";
                Erfassungsbogen.t10field02_03 = "1";
            }
            else
            {
                t10Image02_3.Source = "ic_check_box_outline_blank.png";
                Erfassungsbogen.t10field02_03 = "0";
            }
        }

        private void TapGestureRecognizer_Tapped_5(object sender, EventArgs e)
        {
            if (Erfassungsbogen.t10field02_04 != "1" | Erfassungsbogen.t10field02_04 == null)
            {
                t10Image02_4.Source = "ic_check_box.png";
                Erfassungsbogen.t10field02_04 = "1";
            }
            else
            {
                t10Image02_4.Source = "ic_check_box_outline_blank.png";
                Erfassungsbogen.t10field02_04 = "0";
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