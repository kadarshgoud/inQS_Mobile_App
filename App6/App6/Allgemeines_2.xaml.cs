using App6.Management;
using App6.Model;
using App6.Resources;
using System;
using System.IO;
using System.Net;
using System.Text;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App6
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Allgemeines_2 : ContentPage, INotifyPropertyChanged
    {
        public bool InitialDataIsEmpty;

        public Allgemeines_2()
        {
            InitializeComponent();
            BindingContext = this;

            BogenLabel.Text = AppResources.SurveyHeadline + " " + DBManagement.getYearCode(App.user.selected_mstr_ebqe) + " " + AppResources.SurveyHeadlineFor + " " + Erfassungsbogen.Bewohnerbezeichnung;
        }

        public async void BackButton_TappedAsync(object sender, EventArgs e)
        {
            BackButton.Source = "ic_arrow_back_ios_tapped.png";

            try
            {
                //ActivityIndicator = Loading...
                IsLoading = true;

                if (App.user.selected_mstr_ebqe != DBManagement.CurrentEvaluationID)
                {
                    await Navigation.PushAsync(new Allgemeines_1());
                }
                else
                {
                    var BackQuestion = await DisplayAlert(AppResources.Information, AppResources.InformationSaveQuery, AppResources.Yes, AppResources.No);
                    if (BackQuestion == true)
                    {
                        if (Erfassungsbogen.t00field07_05 == "1" && (t00field07_06.Text == "" | t00field07_06.Text == null))
                        {
                            t00label07_06.TextColor = Color.Red;
                            await DisplayAlert(AppResources.Warning, AppResources.FieldsUnfilled, "OK");
                            BackButton.Source = "ic_arrow_back_ios.png";
                        }
                        else
                        {
                            WebRequest req = WebRequest.Create(DBManagement.DBConnection + "tbl_form_ebqe_t00_02_update.php");

                            req.Method = "POST"; //POST
                            req.Timeout = 15000;
                            req.ContentType = "application/x-www-form-urlencoded";

                            string postData = "mstr=" + App.user.selected_mstr_ebqe + "&bewonerid=" + App.user.selected_id_bewohner + "&t00field07_01=" + Erfassungsbogen.t00field07_01 + "&t00field07_02=" + Erfassungsbogen.t00field07_02 + "&t00field07_03=" + Erfassungsbogen.t00field07_03 + "&t00field07_04=" + Erfassungsbogen.t00field07_04 + "&t00field07_05=" + Erfassungsbogen.t00field07_05 + "&t00field07_06=" + t00field07_06.Text;

                            byte[] byteArray = Encoding.UTF8.GetBytes(postData);

                            req.ContentLength = byteArray.Length;

                            Stream ds = await req.GetRequestStreamAsync();
                            await ds.WriteAsync(byteArray, 0, byteArray.Length);
                            ds.Close();

                            await Navigation.PushAsync(new Allgemeines_1());
                        }
                    }
                    else
                    {
                        Erfassungsbogen.t00field07_01 = Erfassungsbogen.t00field07_02 = Erfassungsbogen.t00field07_03 = Erfassungsbogen.t00field07_04 = Erfassungsbogen.t00field07_05 = Erfassungsbogen.t00field07_06 = "";
                        t00field07_06.Text = "";

                        WebRequest req = WebRequest.Create(DBManagement.DBConnection + "tbl_form_ebqe_t00_02_update.php");

                        req.Method = "POST"; //POST
                        req.Timeout = 15000;
                        req.ContentType = "application/x-www-form-urlencoded";

                        string postData = "mstr=" + App.user.selected_mstr_ebqe + "&bewonerid=" + App.user.selected_id_bewohner + "&t00field07_01=" + Erfassungsbogen.t00field07_01 + "&t00field07_02=" + Erfassungsbogen.t00field07_02 + "&t00field07_03=" + Erfassungsbogen.t00field07_03 + "&t00field07_04=" + Erfassungsbogen.t00field07_04 + "&t00field07_05=" + Erfassungsbogen.t00field07_05 + "&t00field07_06=" + t00field07_06.Text;

                        byte[] byteArray = Encoding.UTF8.GetBytes(postData);

                        req.ContentLength = byteArray.Length;

                        Stream ds = await req.GetRequestStreamAsync();
                        await ds.WriteAsync(byteArray, 0, byteArray.Length);
                        ds.Close();

                        await Navigation.PushAsync(new Allgemeines_1());
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
                    await Navigation.PushAsync(new Allgemeines_3());
                }
                else
                {
                    if (Erfassungsbogen.t00field07_05 == "1" && (t00field07_06.Text == "" | t00field07_06.Text == null))
                    {
                        t00label07_06.TextColor = Color.Red;
                        await DisplayAlert(AppResources.Warning, AppResources.FieldsUnfilled, "OK");
                        ForwardButton.Source = "ic_arrow_forward_ios.png";
                    }
                    else
                    {
                        WebRequest req = WebRequest.Create(DBManagement.DBConnection + "tbl_form_ebqe_t00_02_update.php");

                        req.Method = "POST"; //POST
                        req.Timeout = 15000;
                        req.ContentType = "application/x-www-form-urlencoded";

                        string postData = "mstr=" + App.user.selected_mstr_ebqe + "&bewonerid=" + App.user.selected_id_bewohner + "&t00field07_01=" + Erfassungsbogen.t00field07_01 + "&t00field07_02=" + Erfassungsbogen.t00field07_02 +
                            "&t00field07_03=" + Erfassungsbogen.t00field07_03 + "&t00field07_04=" + Erfassungsbogen.t00field07_04 + "&t00field07_05=" + Erfassungsbogen.t00field07_05 + "&t00field07_06=" + t00field07_06.Text;

                        byte[] byteArray = Encoding.UTF8.GetBytes(postData);

                        req.ContentLength = byteArray.Length;

                        Stream ds = await req.GetRequestStreamAsync();
                        await ds.WriteAsync(byteArray, 0, byteArray.Length);
                        ds.Close();

                        await Navigation.PushAsync(new Allgemeines_3());
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
            if (Erfassungsbogen.t00field07_05 == "0" | Erfassungsbogen.t00field07_05 == "" | Erfassungsbogen.t00field07_05 == null)
            {
                t00field07_05.Source = "ic_check_box.png";
                Erfassungsbogen.t00field07_05 = "1";

            }
            else
            {
                t00field07_05.Source = "ic_check_box_outline_blank.png";
                Erfassungsbogen.t00field07_05 = "0";
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

                //WebRequest req = WebRequest.Create(DBManagement.DBConnection + "tbl_form_ebqe_t00_02_read.php");

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

                //if (split[0] != "" && split[1] != "" && split[2] != "" && split[3] != "" && split[4] != "" && split[5] != "")
                //{
                //    InitialDataIsEmpty = false;
                //}

                //Erfassungsbogen.t00field07_01 = split[0];
                //Erfassungsbogen.t00field07_02 = split[1];
                //Erfassungsbogen.t00field07_03 = split[2];
                //Erfassungsbogen.t00field07_04 = split[3];
                //Erfassungsbogen.t00field07_05 = split[4];
                //Erfassungsbogen.t00field07_06 = split[5];

                // time picker
                if (Erfassungsbogen.t00field07_01 != "")
                {
                    DatePicker_t00field07_01.Date = DateTime.ParseExact(Erfassungsbogen.t00field07_01.Replace('.', '/'), "dd/MM/yyyy", null).Date;
                    Entry_t00field07_01.Text = Erfassungsbogen.t00field07_01;
                }

                // date picker 2
                if (Erfassungsbogen.t00field07_02 != "")
                {
                    DatePicker_t00field07_02.Date = DateTime.ParseExact(Erfassungsbogen.t00field07_02.Replace('.', '/'), "dd/MM/yyyy", null).Date;
                    Entry_t00field07_02.Text = Erfassungsbogen.t00field07_02;
                }

                // date picker 3
                if (Erfassungsbogen.t00field07_03 != "")
                {
                    DatePicker_t00field07_03.Date = DateTime.ParseExact(Erfassungsbogen.t00field07_03.Replace('.', '/'), "dd/MM/yyyy", null).Date;
                    Entry_t00field07_03.Text = Erfassungsbogen.t00field07_03;
                }

                // date picker 4
                if (Erfassungsbogen.t00field07_04 != "")
                {
                    DatePicker_t00field07_04.Date = DateTime.ParseExact(Erfassungsbogen.t00field07_04.Replace('.', '/'), "dd/MM/yyyy", null).Date;
                    Entry_t00field07_04.Text = Erfassungsbogen.t00field07_04;
                }

                // check box 00_07_05

                if (Erfassungsbogen.t00field07_05 == "1")
                {
                    t00field07_05.Source = "ic_check_box.png";                            // rb1 is the image file with checked box image
                    Erfassungsbogen.t00field07_05 = "1";
                }
                else
                {
                    t00field07_05.Source = "ic_check_box_outline_blank.png";
                    Erfassungsbogen.t00field07_05 = "0";
                }

                // text box 07_06

                t00field07_06.Text = Erfassungsbogen.t00field07_06;
                //ActivityIndicator = Idle
                IsLoading = false;

            }
            catch (Exception)
            {
                await DisplayAlert(AppResources.AppError, AppResources.AppErrorMsg, "OK");
            }
        }

        #region t00field07_01

        private void ResetLabel_t00field07_01_Tapped(object sender, EventArgs e)
        {
            Erfassungsbogen.t00field07_01 = "";
            Entry_t00field07_01.Text = "";
        }

        private void Entry_t00field07_01_Focused(object sender, FocusEventArgs e)
        {
            Entry_t00field07_01.Unfocus();
            DatePicker_t00field07_01.Focus();
        }

        private void DatePicker_t00field07_01_Unfocused(object sender, DateChangedEventArgs e)
        {
            Erfassungsbogen.t00field07_01 = DatePicker_t00field07_01.Date.ToString("dd.MM.yyyy");
            Entry_t00field07_01.Text = DatePicker_t00field07_01.Date.ToString("dd.MM.yyyy");
        }

        private void DatePicker_t00field07_01_DateSelected(object sender, DateChangedEventArgs e)
        {
            Erfassungsbogen.t00field07_01 = DatePicker_t00field07_01.Date.ToString("dd.MM.yyyy");
            Entry_t00field07_01.Text = DatePicker_t00field07_01.Date.ToString("dd.MM.yyyy");
        }

        #endregion

        #region t00field07_02

        private void ResetLabel_t00field07_02_Tapped(object sender, EventArgs e)
        {
            Erfassungsbogen.t00field07_02 = "";
            Entry_t00field07_02.Text = "";
        }

        private void Entry_t00field07_02_Focused(object sender, FocusEventArgs e)
        {
            Entry_t00field07_02.Unfocus();
            DatePicker_t00field07_02.Focus();
        }

        private void DatePicker_t00field07_02_Unfocused(object sender, DateChangedEventArgs e)
        {
            Erfassungsbogen.t00field07_02 = DatePicker_t00field07_02.Date.ToString("dd.MM.yyyy");
            Entry_t00field07_02.Text = DatePicker_t00field07_02.Date.ToString("dd.MM.yyyy");
        }

        private void DatePicker_t00field07_02_DateSelected(object sender, DateChangedEventArgs e)
        {
            Erfassungsbogen.t00field07_02 = DatePicker_t00field07_02.Date.ToString("dd.MM.yyyy");
            Entry_t00field07_02.Text = DatePicker_t00field07_02.Date.ToString("dd.MM.yyyy");
        }

        #endregion

        #region t00field07_03

        private void ResetLabel_t00field07_03_Tapped(object sender, EventArgs e)
        {
            Erfassungsbogen.t00field07_03 = "";
            Entry_t00field07_03.Text = "";
        }

        private void Entry_t00field07_03_Focused(object sender, FocusEventArgs e)
        {
            Entry_t00field07_03.Unfocus();
            DatePicker_t00field07_03.Focus();
        }

        private void DatePicker_t00field07_03_Unfocused(object sender, DateChangedEventArgs e)
        {
            Erfassungsbogen.t00field07_03 = DatePicker_t00field07_03.Date.ToString("dd.MM.yyyy");
            Entry_t00field07_03.Text = DatePicker_t00field07_03.Date.ToString("dd.MM.yyyy");
        }

        private void DatePicker_t00field07_03_DateSelected(object sender, DateChangedEventArgs e)
        {
            Erfassungsbogen.t00field07_03 = DatePicker_t00field07_03.Date.ToString("dd.MM.yyyy");
            Entry_t00field07_03.Text = DatePicker_t00field07_03.Date.ToString("dd.MM.yyyy");
        }

        #endregion

        #region t00field07_04

        private void ResetLabel_t00field07_04_Tapped(object sender, EventArgs e)
        {
            Erfassungsbogen.t00field07_04 = "";
            Entry_t00field07_04.Text = "";
        }

        private void Entry_t00field07_04_Focused(object sender, FocusEventArgs e)
        {
            Entry_t00field07_04.Unfocus();
            DatePicker_t00field07_04.Focus();
        }

        private void DatePicker_t00field07_04_Unfocused(object sender, DateChangedEventArgs e)
        {
            Erfassungsbogen.t00field07_04 = DatePicker_t00field07_04.Date.ToString("dd.MM.yyyy");
            Entry_t00field07_04.Text = DatePicker_t00field07_04.Date.ToString("dd.MM.yyyy");
        }

        private void DatePicker_t00field07_04_DateSelected(object sender, DateChangedEventArgs e)
        {
            Erfassungsbogen.t00field07_04 = DatePicker_t00field07_04.Date.ToString("dd.MM.yyyy");
            Entry_t00field07_04.Text = DatePicker_t00field07_04.Date.ToString("dd.MM.yyyy");
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
    }
}