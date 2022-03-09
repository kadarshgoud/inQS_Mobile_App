﻿using App6.Model;
using System;
using System.IO;
using System.Net;
using System.Text;
using App6.Management;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using App6.Resources;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;

namespace App6
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Gestaltung_2 : ContentPage, INotifyPropertyChanged
    {
        public bool InitialDataIsEmpty;

        public Gestaltung_2()
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
                    await Navigation.PushAsync(new Gestaltung_1());
                }
                else
                {
                    var BackQuestion = await DisplayAlert(AppResources.Information, AppResources.InformationSaveQuery, AppResources.Yes, AppResources.No);
                    if (BackQuestion == true)
                    {
                        t06field03.TextColor = t06field04.TextColor = AppManager.QuestionColor;

                        if ((Erfassungsbogen.t06field03 != "" && Erfassungsbogen.t06field03 != null) && (Erfassungsbogen.t06field04 != "" && Erfassungsbogen.t06field04 != null))
                        {
                            WebRequest req = WebRequest.Create(DBManagement.DBConnection + "tbl_form_ebqe_t06_02_update.php");

                            req.Method = "POST"; //POST
                            req.Timeout = 15000;
                            req.ContentType = "application/x-www-form-urlencoded";

                            string postData = "mstr=" + App.user.selected_mstr_ebqe + "&bewonerid=" + App.user.selected_id_bewohner + "&t06field03=" + Erfassungsbogen.t06field03 + "&t06field04=" + Erfassungsbogen.t06field04;
                            byte[] byteArray = Encoding.UTF8.GetBytes(postData);

                            req.ContentLength = byteArray.Length;

                            Stream ds = await req.GetRequestStreamAsync();
                            await ds.WriteAsync(byteArray, 0, byteArray.Length);
                            ds.Close();

                            await Navigation.PushAsync(new Gestaltung_1());
                        }
                        else
                        {
                            if (Erfassungsbogen.t06field03 == "" || Erfassungsbogen.t06field03 == null)
                            {
                                t06field03.TextColor = Color.Red;
                            }
                            if (Erfassungsbogen.t06field04 == "" || Erfassungsbogen.t06field04 == null)
                            {
                                t06field04.TextColor = Color.Red;
                            }
                            await DisplayAlert(AppResources.Warning, AppResources.FieldsUnfilled, "OK");
                            BackButton.Source = "ic_arrow_back_ios.png";
                        }
                    }
                    else
                    {
                        Erfassungsbogen.t06field03 = Erfassungsbogen.t06field04 = "";

                        WebRequest req = WebRequest.Create(DBManagement.DBConnection + "tbl_form_ebqe_t06_02_update.php");

                        req.Method = "POST"; //POST
                        req.Timeout = 15000;
                        req.ContentType = "application/x-www-form-urlencoded";

                        string postData = "mstr=" + App.user.selected_mstr_ebqe + "&bewonerid=" + App.user.selected_id_bewohner + "&t06field03=" + Erfassungsbogen.t06field03 + "&t06field04=" + Erfassungsbogen.t06field04;
                        byte[] byteArray = Encoding.UTF8.GetBytes(postData);

                        req.ContentLength = byteArray.Length;

                        Stream ds = await req.GetRequestStreamAsync();
                        await ds.WriteAsync(byteArray, 0, byteArray.Length);
                        ds.Close();

                        await Navigation.PushAsync(new Gestaltung_1());
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

                //WebRequest req = WebRequest.Create(DBManagement.DBConnection + "tbl_form_ebqe_t06_02_read.php");

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

                //if (split[0] != "" && split[1] != "")
                //{
                //    InitialDataIsEmpty = false;
                //}

                //Erfassungsbogen.t06field03 = split[0];
                //Erfassungsbogen.t06field04 = split[1];                              // data from Database tbl_02 is stored

                if (Erfassungsbogen.t06field03 == "0")
                {
                    t06Image03_1.Source = "ic_rb1.png";                            // rb1 is the image file with checked box image
                }
                else if (Erfassungsbogen.t06field03 == "1")
                {
                    t06Image03_2.Source = "ic_rb1.png";
                }
                else if (Erfassungsbogen.t06field03 == "2")
                {
                    t06Image03_3.Source = "ic_rb1.png";
                }
                else if (Erfassungsbogen.t06field03 == "3")
                {
                    t06Image03_4.Source = "ic_rb1.png";
                }
                else
                {
                    t06Image03_1.Source = "ic_rb2.png";                             // rb2 is the image with unchecked box
                    t06Image03_2.Source = "ic_rb2.png";
                    t06Image03_3.Source = "ic_rb2.png";
                    t06Image03_4.Source = "ic_rb2.png";
                }

                if (Erfassungsbogen.t06field04 == "0")
                {
                    t06Image04_1.Source = "ic_rb1.png";                            // rb1 is the image file with checked box image
                }
                else if (Erfassungsbogen.t06field04 == "1")
                {
                    t06Image04_2.Source = "ic_rb1.png";
                }
                else if (Erfassungsbogen.t06field04 == "2")
                {
                    t06Image04_3.Source = "ic_rb1.png";
                }
                else if (Erfassungsbogen.t06field04 == "3")
                {
                    t06Image04_4.Source = "ic_rb1.png";
                }
                else
                {
                    t06Image04_1.Source = "ic_rb2.png";                             // rb2 is the image with unchecked box
                    t06Image04_2.Source = "ic_rb2.png";
                    t06Image04_3.Source = "ic_rb2.png";
                    t06Image04_4.Source = "ic_rb2.png";
                }

                //ActivityIndicator = Idle
                IsLoading = false;
            }
            catch (Exception)
            {
                await DisplayAlert(AppResources.AppError, AppResources.AppErrorMsg, "OK");
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
                    await Navigation.PushAsync(new Gestaltung_3());
                }
                else
                {
                    t06field03.TextColor = t06field04.TextColor = AppManager.QuestionColor;

                    if ((Erfassungsbogen.t06field03 != "" && Erfassungsbogen.t06field03 != null) && (Erfassungsbogen.t06field04 != "" && Erfassungsbogen.t06field04 != null))
                    {

                        WebRequest req = WebRequest.Create(DBManagement.DBConnection + "tbl_form_ebqe_t06_02_update.php");

                        req.Method = "POST"; //POST
                        req.Timeout = 15000;
                        req.ContentType = "application/x-www-form-urlencoded";

                        string postData = "mstr=" + App.user.selected_mstr_ebqe + "&bewonerid=" + App.user.selected_id_bewohner + "&t06field03=" + Erfassungsbogen.t06field03 + "&t06field04=" + Erfassungsbogen.t06field04;
                        byte[] byteArray = Encoding.UTF8.GetBytes(postData);

                        req.ContentLength = byteArray.Length;

                        Stream ds = await req.GetRequestStreamAsync();
                        await ds.WriteAsync(byteArray, 0, byteArray.Length);
                        ds.Close();

                        await Navigation.PushAsync(new Gestaltung_3());
                    }
                    else
                    {
                        if (Erfassungsbogen.t06field03 == "" || Erfassungsbogen.t06field03 == null)
                        {
                            t06field03.TextColor = Color.Red;
                        }
                        if (Erfassungsbogen.t06field04 == "" || Erfassungsbogen.t06field04 == null)
                        {
                            t06field04.TextColor = Color.Red;
                        }
                        await DisplayAlert(AppResources.Warning, AppResources.FieldsUnfilled, "OK");
                        ForwardButton.Source = "ic_arrow_forward_ios.png";
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

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            if (Erfassungsbogen.t06field03 != "0" | Erfassungsbogen.t06field03 == null)
            {
                t06Image03_1.Source = "ic_rb1.png";
                t06Image03_2.Source = "ic_rb2.png";
                t06Image03_3.Source = "ic_rb2.png";
                t06Image03_4.Source = "ic_rb2.png";
                Erfassungsbogen.t06field03 = "0";
            }
            else
            {
                t06Image03_1.Source = "ic_rb2.png";
                Erfassungsbogen.t06field03 = "";
            }
        }

        private void TapGestureRecognizer_Tapped_1(object sender, EventArgs e)
        {
            if (Erfassungsbogen.t06field03 != "1" | Erfassungsbogen.t06field03 == null)
            {
                t06Image03_2.Source = "ic_rb1.png";
                t06Image03_1.Source = "ic_rb2.png";
                t06Image03_3.Source = "ic_rb2.png";
                t06Image03_4.Source = "ic_rb2.png";
                Erfassungsbogen.t06field03 = "1";
            }
            else
            {
                t06Image03_2.Source = "ic_rb2.png";
                Erfassungsbogen.t06field03 = "";
            }
        }

        private void TapGestureRecognizer_Tapped_2(object sender, EventArgs e)
        {
            if (Erfassungsbogen.t06field03 != "2" | Erfassungsbogen.t06field03 == null)
            {
                t06Image03_3.Source = "ic_rb1.png";
                t06Image03_4.Source = "ic_rb2.png";
                t06Image03_2.Source = "ic_rb2.png";
                t06Image03_1.Source = "ic_rb2.png";
                Erfassungsbogen.t06field03 = "2";
            }
            else
            {
                t06Image03_3.Source = "ic_rb2.png";
                Erfassungsbogen.t06field03 = "";
            }
        }

        private void TapGestureRecognizer_Tapped_3(object sender, EventArgs e)
        {
            if (Erfassungsbogen.t06field03 != "3" | Erfassungsbogen.t06field03 == null)
            {
                t06Image03_4.Source = "ic_rb1.png";
                t06Image03_1.Source = "ic_rb2.png";
                t06Image03_2.Source = "ic_rb2.png";
                t06Image03_3.Source = "ic_rb2.png";
                Erfassungsbogen.t06field03 = "3";
            }
            else
            {
                t06Image03_4.Source = "ic_rb2.png";
                Erfassungsbogen.t06field03 = "";
            }
        }

        private void TapGestureRecognizer_Tapped_4(object sender, EventArgs e)
        {
            if (Erfassungsbogen.t06field04 != "0" | Erfassungsbogen.t06field04 == null)
            {
                t06Image04_1.Source = "ic_rb1.png";
                t06Image04_2.Source = "ic_rb2.png";
                t06Image04_3.Source = "ic_rb2.png";
                t06Image04_4.Source = "ic_rb2.png";
                Erfassungsbogen.t06field04 = "0";
            }
            else
            {
                t06Image04_1.Source = "ic_rb2.png";
                Erfassungsbogen.t06field04 = "";
            }
        }

        private void TapGestureRecognizer_Tapped_5(object sender, EventArgs e)
        {
            if (Erfassungsbogen.t06field04 != "1" | Erfassungsbogen.t06field04 == null)
            {
                t06Image04_2.Source = "ic_rb1.png";
                t06Image04_1.Source = "ic_rb2.png";
                t06Image04_3.Source = "ic_rb2.png";
                t06Image04_4.Source = "ic_rb2.png";
                Erfassungsbogen.t06field04 = "1";
            }
            else
            {
                t06Image04_2.Source = "ic_rb2.png";
                Erfassungsbogen.t06field04 = "";
            }
        }

        private void TapGestureRecognizer_Tapped_6(object sender, EventArgs e)
        {

            if (Erfassungsbogen.t06field04 != "2" | Erfassungsbogen.t06field04 == null)
            {
                t06Image04_3.Source = "ic_rb1.png";
                t06Image04_2.Source = "ic_rb2.png";
                t06Image04_1.Source = "ic_rb2.png";
                t06Image04_4.Source = "ic_rb2.png";
                Erfassungsbogen.t06field04 = "2";
            }
            else
            {
                t06Image04_3.Source = "ic_rb2.png";
                Erfassungsbogen.t06field04 = "";
            }
        }

        private void TapGestureRecognizer_Tapped_7(object sender, EventArgs e)
        {
            if (Erfassungsbogen.t06field04 != "3" | Erfassungsbogen.t06field04 == null)
            {
                t06Image04_4.Source = "ic_rb1.png";
                t06Image04_2.Source = "ic_rb2.png";
                t06Image04_3.Source = "ic_rb2.png";
                t06Image04_1.Source = "ic_rb2.png";
                Erfassungsbogen.t06field04 = "3";
            }
            else
            {
                t06Image04_4.Source = "ic_rb2.png";
                Erfassungsbogen.t06field04 = "";
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