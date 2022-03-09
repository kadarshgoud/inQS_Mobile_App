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
    public partial class Kognitive_1 : ContentPage, INotifyPropertyChanged
    {
        public bool InitialDataIsEmpty;

        public Kognitive_1()
        {
            InitializeComponent();
            BindingContext = this;

            BogenLabel.Text = AppResources.SurveyHeadline + " " + DBManagement.getYearCode(App.user.selected_mstr_ebqe) + " " + AppResources.SurveyHeadlineFor + " " + Erfassungsbogen.Bewohnerbezeichnung;

            t02Picker01.Items.Add("0 = vorhanden/unbeeinträchtigt");
            t02Picker01.Items.Add("1 = größtenteils vorhanden");
            t02Picker01.Items.Add("2 = in geringem Maße vorhanden");
            t02Picker01.Items.Add("3 = nicht vorhanden");

            t02Picker02.Items.Add("0 = vorhanden/unbeeinträchtigt");
            t02Picker02.Items.Add("1 = größtenteils vorhanden");
            t02Picker02.Items.Add("2 = in geringem Maße vorhanden");
            t02Picker02.Items.Add("3 = nicht vorhanden");

            t02Picker03.Items.Add("0 = vorhanden/unbeeinträchtigt");
            t02Picker03.Items.Add("1 = größtenteils vorhanden");
            t02Picker03.Items.Add("2 = in geringem Maße vorhanden");
            t02Picker03.Items.Add("3 = nicht vorhanden");

            t02Picker04.Items.Add("0 = vorhanden/unbeeinträchtigt");
            t02Picker04.Items.Add("1 = größtenteils vorhanden");
            t02Picker04.Items.Add("2 = in geringem Maße vorhanden");
            t02Picker04.Items.Add("3 = nicht vorhanden");

            t02Picker05.Items.Add("0 = vorhanden/unbeeinträchtigt");
            t02Picker05.Items.Add("1 = größtenteils vorhanden");
            t02Picker05.Items.Add("2 = in geringem Maße vorhanden");
            t02Picker05.Items.Add("3 = nicht vorhanden");
        }

        //Before page gets loaded this opertion is performed
        protected override async void OnAppearing()
        {
            base.OnAppearing();

            try
            {
                //ActivityIndicator = Loading...
                IsLoading = true;

                //WebRequest req = WebRequest.Create(DBManagement.DBConnection + "tbl_form_ebqe_t02_01_read.php");

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

                //if (split[0] != "" && split[1] != "" && split[2] != "" && split[3] != "" && split[4] != "")
                //{
                //    InitialDataIsEmpty = false;
                //}

                //Erfassungsbogen.t02field01 = split[0];
                //Erfassungsbogen.t02field02 = split[1];
                //Erfassungsbogen.t02field03 = split[2];
                //Erfassungsbogen.t02field04 = split[3];
                //Erfassungsbogen.t02field05 = split[4];

                if (Erfassungsbogen.t02field01 == "0")
                {
                    t02Picker01.SelectedIndex = 0;                         // rb1 is the image file with checked box image
                }
                else if (Erfassungsbogen.t02field01 == "1")
                {
                    t02Picker01.SelectedIndex = 1;
                }
                else if (Erfassungsbogen.t02field01 == "2")
                {
                    t02Picker01.SelectedIndex = 2;
                }
                else if (Erfassungsbogen.t02field01 == "3")
                {
                    t02Picker01.SelectedIndex = 3;
                }
                else
                {
                    t02Picker01.SelectedIndex = -1;
                }

                if (Erfassungsbogen.t02field02 == "0")
                {
                    t02Picker02.SelectedIndex = 0; // rb1 is the image file with checked box image
                }
                else if (Erfassungsbogen.t02field02 == "1")
                {
                    t02Picker02.SelectedIndex = 1;
                }
                else if (Erfassungsbogen.t02field02 == "2")
                {
                    t02Picker02.SelectedIndex = 2;
                }
                else if (Erfassungsbogen.t02field02 == "3")
                {
                    t02Picker02.SelectedIndex = 3;
                }
                else
                {
                    t02Picker02.SelectedIndex = -1;
                }

                if (Erfassungsbogen.t02field03 == "0")
                {
                    t02Picker03.SelectedIndex = 0; // rb1 is the image file with checked box image
                }
                else if (Erfassungsbogen.t02field03 == "1")
                {
                    t02Picker03.SelectedIndex = 1;
                }
                else if (Erfassungsbogen.t02field03 == "2")
                {
                    t02Picker03.SelectedIndex = 2;
                }
                else if (Erfassungsbogen.t02field03 == "3")
                {
                    t02Picker03.SelectedIndex = 3;
                }
                else
                {
                    t02Picker03.SelectedIndex = -1;
                }
                if (Erfassungsbogen.t02field04 == "0")
                {
                    t02Picker04.SelectedIndex = 0; // rb1 is the image file with checked box image
                }
                else if (Erfassungsbogen.t02field04 == "1")
                {
                    t02Picker04.SelectedIndex = 1;
                }
                else if (Erfassungsbogen.t02field04 == "2")
                {
                    t02Picker04.SelectedIndex = 2;
                }
                else if (Erfassungsbogen.t02field04 == "3")
                {
                    t02Picker04.SelectedIndex = 3;
                }
                else
                {
                    t02Picker04.SelectedIndex = -1;
                }

                if (Erfassungsbogen.t02field05 == "0")
                {
                    t02Picker05.SelectedIndex = 0; // rb1 is the image file with checked box image
                }
                else if (Erfassungsbogen.t02field05 == "1")
                {
                    t02Picker05.SelectedIndex = 1;
                }
                else if (Erfassungsbogen.t02field05 == "2")
                {
                    t02Picker05.SelectedIndex = 2;
                }
                else if (Erfassungsbogen.t02field05 == "3")
                {
                    t02Picker05.SelectedIndex = 3;
                }
                else
                {
                    t02Picker05.SelectedIndex = -1;
                }
                //ActivityIndicator = Idle
                IsLoading = false;

            }
            catch (Exception)
            {
                await DisplayAlert(AppResources.AppError, AppResources.AppErrorMsg, "OK");
            }
        }

        private void T02Picker01_SelectedIndexChanged(object sender, EventArgs e)
        {
            // picker T02 01
            if (t02Picker01.SelectedIndex == 0)
            {

                Erfassungsbogen.t02field01 = "0";
            }

            else if (t02Picker01.SelectedIndex == 1)
            {

                Erfassungsbogen.t02field01 = "1";
            }
            else if (t02Picker01.SelectedIndex == 2)
            {

                Erfassungsbogen.t02field01 = "2";
            }
            else if (t02Picker01.SelectedIndex == 3)
            {

                Erfassungsbogen.t02field01 = "3";
            }
        }

        private void T02Picker02_SelectedIndexChanged(object sender, EventArgs e)
        {
            // T02 02

            if (t02Picker02.SelectedIndex == 0)
            {
                Erfassungsbogen.t02field02 = "0";
            }
            else if (t02Picker02.SelectedIndex == 1)
            {
                Erfassungsbogen.t02field02 = "1";
            }
            else if (t02Picker02.SelectedIndex == 2)
            {
                Erfassungsbogen.t02field02 = "2";
            }
            else if (t02Picker02.SelectedIndex == 3)
            {
                Erfassungsbogen.t02field02 = "3";
            }
        }

        private void T02Picker03_SelectedIndexChanged(object sender, EventArgs e)
        {
            //T02 03

            if (t02Picker03.SelectedIndex == 0)
            {
                Erfassungsbogen.t02field03 = "0";
            }
            else if (t02Picker03.SelectedIndex == 1)
            {
                Erfassungsbogen.t02field03 = "1";
            }
            else if (t02Picker03.SelectedIndex == 2)
            {
                Erfassungsbogen.t02field03 = "2";
            }
            else if (t02Picker03.SelectedIndex == 3)
            {
                Erfassungsbogen.t02field03 = "3";
            }
        }

        private void T02Picker04_SelectedIndexChanged(object sender, EventArgs e)
        {
            // T02 04

            if (t02Picker04.SelectedIndex == 0)
            {
                Erfassungsbogen.t02field04 = "0";
            }
            else if (t02Picker04.SelectedIndex == 1)
            {
                Erfassungsbogen.t02field04 = "1";
            }
            else if (t02Picker04.SelectedIndex == 2)
            {
                Erfassungsbogen.t02field04 = "2";
            }
            else if (t02Picker04.SelectedIndex == 3)
            {
                Erfassungsbogen.t02field04 = "3";
            }
        }

        private void T02Picker05_SelectedIndexChanged(object sender, EventArgs e)
        {
            // T02 05
            if (t02Picker05.SelectedIndex == 0)
            {
                Erfassungsbogen.t02field05 = "0";
            }
            else if (t02Picker05.SelectedIndex == 1)
            {
                Erfassungsbogen.t02field05 = "1";
            }
            else if (t02Picker05.SelectedIndex == 2)
            {
                Erfassungsbogen.t02field05 = "2";
            }
            else if (t02Picker05.SelectedIndex == 3)
            {
                Erfassungsbogen.t02field05 = "3";
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
                        t02field01.TextColor = t02field02.TextColor = t02field03.TextColor = t02field04.TextColor = t02field05.TextColor = AppManager.QuestionColor;

                        if ((Erfassungsbogen.t02field01 != "" && Erfassungsbogen.t02field01 != null) && (Erfassungsbogen.t02field02 != "" && Erfassungsbogen.t02field02 != null) && (Erfassungsbogen.t02field03 != "" && Erfassungsbogen.t02field03 != null) && (Erfassungsbogen.t02field04 != "" && Erfassungsbogen.t02field04 != null) && (Erfassungsbogen.t02field05 != "" && Erfassungsbogen.t02field05 != null))
                        {
                            WebRequest req = WebRequest.Create(DBManagement.DBConnection + "tbl_form_ebqe_t02_01_update.php");

                            req.Method = "POST"; //POST
                            req.Timeout = 15000;
                            req.ContentType = "application/x-www-form-urlencoded";

                            string postData = "mstr=" + App.user.selected_mstr_ebqe + "&bewonerid=" + App.user.selected_id_bewohner + "&t02field01=" + Erfassungsbogen.t02field01 + "&t02field02=" + Erfassungsbogen.t02field02 + "&t02field03=" + Erfassungsbogen.t02field03 + "&t02field04=" + Erfassungsbogen.t02field04 + "&t02field05=" + Erfassungsbogen.t02field05;

                            byte[] byteArray = Encoding.UTF8.GetBytes(postData);

                            req.ContentLength = byteArray.Length;

                            Stream ds = await req.GetRequestStreamAsync();
                            await ds.WriteAsync(byteArray, 0, byteArray.Length);
                            ds.Close();

                            await Navigation.PushAsync(new SearchPage());
                        }
                        else
                        {
                            if (Erfassungsbogen.t02field01 == "" || Erfassungsbogen.t02field01 == null)
                            {
                                t02field01.TextColor = Color.Red;
                            }
                            if (Erfassungsbogen.t02field02 == "" || Erfassungsbogen.t02field02 == null)
                            {
                                t02field02.TextColor = Color.Red;
                            }
                            if (Erfassungsbogen.t02field03 == "" || Erfassungsbogen.t02field03 == null)
                            {
                                t02field03.TextColor = Color.Red;
                            }
                            if (Erfassungsbogen.t02field04 == "" || Erfassungsbogen.t02field04 == null)
                            {
                                t02field04.TextColor = Color.Red;
                            }
                            if (Erfassungsbogen.t02field05 == "" || Erfassungsbogen.t02field05 == null)
                            {
                                t02field05.TextColor = Color.Red;

                            }
                            await DisplayAlert(AppResources.Warning, AppResources.FieldsUnfilled, "OK");
                            BackButton.Source = "ic_arrow_back_ios.png";
                        }
                    }
                    else
                    {
                        Erfassungsbogen.t02field01 = Erfassungsbogen.t02field02 = Erfassungsbogen.t02field03 = Erfassungsbogen.t02field04 = Erfassungsbogen.t02field05 = "";

                        WebRequest req = WebRequest.Create(DBManagement.DBConnection + "tbl_form_ebqe_t02_01_update.php");

                        req.Method = "POST"; //POST
                        req.Timeout = 15000;
                        req.ContentType = "application/x-www-form-urlencoded";

                        string postData = "mstr=" + App.user.selected_mstr_ebqe + "&bewonerid=" + App.user.selected_id_bewohner + "&t02field01=" + Erfassungsbogen.t02field01 + "&t02field02=" + Erfassungsbogen.t02field02 + "&t02field03=" + Erfassungsbogen.t02field03 + "&t02field04=" + Erfassungsbogen.t02field04 + "&t02field05=" + Erfassungsbogen.t02field05;

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
                    await Navigation.PushAsync(new Kognitive_2());
                }
                else
                {
                    t02field01.TextColor = t02field02.TextColor = t02field03.TextColor = t02field04.TextColor = t02field05.TextColor = AppManager.QuestionColor;

                    if ((Erfassungsbogen.t02field01 != "" && Erfassungsbogen.t02field01 != null) && (Erfassungsbogen.t02field02 != "" && Erfassungsbogen.t02field02 != null) && (Erfassungsbogen.t02field03 != "" && Erfassungsbogen.t02field03 != null) && (Erfassungsbogen.t02field04 != "" && Erfassungsbogen.t02field04 != null) && (Erfassungsbogen.t02field05 != "" && Erfassungsbogen.t02field05 != null))
                    {
                        if (App.user.selected_mstr_ebqe == DBManagement.CurrentEvaluationID)
                        {
                            WebRequest req = WebRequest.Create(DBManagement.DBConnection + "tbl_form_ebqe_t02_01_update.php");

                            req.Method = "POST"; //POST
                            req.Timeout = 15000;
                            req.ContentType = "application/x-www-form-urlencoded";

                            string postData = "mstr=" + App.user.selected_mstr_ebqe + "&bewonerid=" + App.user.selected_id_bewohner + "&t02field01=" + Erfassungsbogen.t02field01 + "&t02field02=" + Erfassungsbogen.t02field02 +
                                "&t02field03=" + Erfassungsbogen.t02field03 + "&t02field04=" + Erfassungsbogen.t02field04 + "&t02field05=" + Erfassungsbogen.t02field05;

                            byte[] byteArray = Encoding.UTF8.GetBytes(postData);

                            req.ContentLength = byteArray.Length;

                            Stream ds = await req.GetRequestStreamAsync();
                            await ds.WriteAsync(byteArray, 0, byteArray.Length);
                            ds.Close();
                        }

                        await Navigation.PushAsync(new Kognitive_2());
                    }
                    else
                    {
                        if (Erfassungsbogen.t02field01 == "" || Erfassungsbogen.t02field01 == null)
                        {
                            t02field01.TextColor = Color.Red;
                        }
                        if (Erfassungsbogen.t02field02 == "" || Erfassungsbogen.t02field02 == null)
                        {
                            t02field02.TextColor = Color.Red;
                        }
                        if (Erfassungsbogen.t02field03 == "" || Erfassungsbogen.t02field03 == null)
                        {
                            t02field03.TextColor = Color.Red;
                        }
                        if (Erfassungsbogen.t02field04 == "" || Erfassungsbogen.t02field04 == null)
                        {
                            t02field04.TextColor = Color.Red;
                        }
                        if (Erfassungsbogen.t02field05 == "" || Erfassungsbogen.t02field05 == null)
                        {
                            t02field05.TextColor = Color.Red;

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