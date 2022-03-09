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
    public partial class Selbstversorgung_3 : ContentPage, INotifyPropertyChanged
    {
        public bool InitialDataIsEmpty;

        public Selbstversorgung_3()
        {
            InitializeComponent();
            BindingContext = this;

            BogenLabel.Text = AppResources.SurveyHeadline + " " + DBManagement.getYearCode(App.user.selected_mstr_ebqe) + " " + AppResources.SurveyHeadlineFor + " " + Erfassungsbogen.Bewohnerbezeichnung;

            t04Picker01.Items.Add("0 = selbständig");
            t04Picker01.Items.Add("1 = überwiegend selbständig");
            t04Picker01.Items.Add("2 = überwiegend unselbständig");
            t04Picker01.Items.Add("3 = unselbständig");

            t04Picker02.Items.Add("0 = selbständig");
            t04Picker02.Items.Add("1 = überwiegend selbständig");
            t04Picker02.Items.Add("2 = überwiegend unselbständig");
            t04Picker02.Items.Add("3 = unselbständig");

            t04Picker03.Items.Add("0 = selbständig");
            t04Picker03.Items.Add("1 = überwiegend selbständig");
            t04Picker03.Items.Add("2 = überwiegend unselbständig");
            t04Picker03.Items.Add("3 = unselbständig");

            t04Picker04.Items.Add("0 = selbständig");
            t04Picker04.Items.Add("1 = überwiegend selbständig");
            t04Picker04.Items.Add("2 = überwiegend unselbständig");
            t04Picker04.Items.Add("3 = unselbständig");

            t04Picker05.Items.Add("0 = selbständig");
            t04Picker05.Items.Add("1 = überwiegend selbständig");
            t04Picker05.Items.Add("2 = überwiegend unselbständig");
            t04Picker05.Items.Add("3 = unselbständig");
        }

        //Before page gets loaded this opertion is performed
        protected override async void OnAppearing()
        {
            base.OnAppearing();

            try
            {
                //ActivityIndicator = Loading...
                IsLoading = true;

               /* WebRequest req = WebRequest.Create(DBManagement.DBConnection + "tbl_form_ebqe_t04_03_read.php");

                req.Method = "POST";
                req.Timeout = 15000;
                req.ContentType = "application/x-www-form-urlencoded";

                string postData = "id=" + App.user.selected_mstr_ebqe + "&einrichtung=" + App.user.id_org_einrichtung +
                                    "&wohnbereich=" + App.user.id_org_wohnbereich + "&bewonerid=" + App.user.selected_id_bewohner;
                byte[] byteArray = Encoding.UTF8.GetBytes(postData);

                req.ContentLength = byteArray.Length;

                Stream ds = await req.GetRequestStreamAsync();
                await ds.WriteAsync(byteArray, 0, byteArray.Length);
                ds.Close();

                WebResponse response = await req.GetResponseAsync();

                Stream dataStream = response.GetResponseStream();

                StreamReader reader = new StreamReader(dataStream);

                string s = reader.ReadToEnd();

                string[] split = s.Split(new char[] { ':' });

                if (split[0] != "" && split[1] != "" && split[2] != "" && split[3] != "" && split[4] != "")
                {
                    InitialDataIsEmpty = false;
                }

                Erfassungsbogen.t04field01 = split[0];
                Erfassungsbogen.t04field02 = split[1];
                Erfassungsbogen.t04field03 = split[2];
                Erfassungsbogen.t04field04 = split[3];
                Erfassungsbogen.t04field05 = split[4];*/

                if (Erfassungsbogen.t04field01 == "0")
                {
                    t04Picker01.SelectedIndex = 0;                         // rb1 is the image file with checked box image
                }
                else if (Erfassungsbogen.t04field01 == "1")
                {
                    t04Picker01.SelectedIndex = 1;
                }
                else if (Erfassungsbogen.t04field01 == "2")
                {
                    t04Picker01.SelectedIndex = 2;
                }
                else if (Erfassungsbogen.t04field01 == "3")
                {
                    t04Picker01.SelectedIndex = 3;
                }
                else
                {
                    t04Picker01.SelectedIndex = -1;
                }

                if (Erfassungsbogen.t04field02 == "0")
                {
                    t04Picker02.SelectedIndex = 0; // rb1 is the image file with checked box image
                }
                else if (Erfassungsbogen.t04field02 == "1")
                {
                    t04Picker02.SelectedIndex = 1;
                }
                else if (Erfassungsbogen.t04field02 == "2")
                {
                    t04Picker02.SelectedIndex = 2;
                }
                else if (Erfassungsbogen.t04field02 == "3")
                {
                    t04Picker02.SelectedIndex = 3;
                }
                else
                {
                    t04Picker02.SelectedIndex = -1;
                }

                if (Erfassungsbogen.t04field03 == "0")
                {
                    t04Picker03.SelectedIndex = 0; // rb1 is the image file with checked box image
                }
                else if (Erfassungsbogen.t04field03 == "1")
                {
                    t04Picker03.SelectedIndex = 1;
                }
                else if (Erfassungsbogen.t04field03 == "2")
                {
                    t04Picker03.SelectedIndex = 2;
                }
                else if (Erfassungsbogen.t04field03 == "3")
                {
                    t04Picker03.SelectedIndex = 3;
                }
                else
                {
                    t04Picker03.SelectedIndex = -1;
                }
                if (Erfassungsbogen.t04field04 == "0")
                {
                    t04Picker04.SelectedIndex = 0; // rb1 is the image file with checked box image
                }
                else if (Erfassungsbogen.t04field04 == "1")
                {
                    t04Picker04.SelectedIndex = 1;
                }
                else if (Erfassungsbogen.t04field04 == "2")
                {
                    t04Picker04.SelectedIndex = 2;
                }
                else if (Erfassungsbogen.t04field04 == "3")
                {
                    t04Picker04.SelectedIndex = 3;
                }
                else
                {
                    t04Picker04.SelectedIndex = -1;
                }

                if (Erfassungsbogen.t04field05 == "0")
                {
                    t04Picker05.SelectedIndex = 0; // rb1 is the image file with checked box image
                }
                else if (Erfassungsbogen.t04field05 == "1")
                {
                    t04Picker05.SelectedIndex = 1;
                }
                else if (Erfassungsbogen.t04field05 == "2")
                {
                    t04Picker05.SelectedIndex = 2;
                }
                else if (Erfassungsbogen.t04field05 == "3")
                {
                    t04Picker05.SelectedIndex = 3;
                }
                else
                {
                    t04Picker05.SelectedIndex = -1;
                }
                //ActivityIndicator = Idle
                IsLoading = false;

            }
            catch (Exception)
            {
                await DisplayAlert(AppResources.AppError, AppResources.AppErrorMsg, "OK");
            }
        }

        private void T04Picker01_SelectedIndexChanged(object sender, EventArgs e)
        {
            // picker T04 01
            if (t04Picker01.SelectedIndex == 0)
            {
                Erfassungsbogen.t04field01 = "0";
            }
            else if (t04Picker01.SelectedIndex == 1)
            {
                Erfassungsbogen.t04field01 = "1";
            }
            else if (t04Picker01.SelectedIndex == 2)
            {
                Erfassungsbogen.t04field01 = "2";
            }
            else if (t04Picker01.SelectedIndex == 3)
            {
                Erfassungsbogen.t04field01 = "3";
            }
        }

        private void T04Picker02_SelectedIndexChanged(object sender, EventArgs e)
        {
            // T04 02
            if (t04Picker02.SelectedIndex == 0)
            {
                Erfassungsbogen.t04field02 = "0";
            }
            else if (t04Picker02.SelectedIndex == 1)
            {
                Erfassungsbogen.t04field02 = "1";
            }
            else if (t04Picker02.SelectedIndex == 2)
            {
                Erfassungsbogen.t04field02 = "2";
            }
            else if (t04Picker02.SelectedIndex == 3)
            {
                Erfassungsbogen.t04field02 = "3";
            }
        }

        private void T04Picker03_SelectedIndexChanged(object sender, EventArgs e)
        {
            //T04 03

            if (t04Picker03.SelectedIndex == 0)
            {
                Erfassungsbogen.t04field03 = "0";
            }
            else if (t04Picker03.SelectedIndex == 1)
            {
                Erfassungsbogen.t04field03 = "1";
            }
            else if (t04Picker03.SelectedIndex == 2)
            {
                Erfassungsbogen.t04field03 = "2";
            }
            else if (t04Picker03.SelectedIndex == 3)
            {
                Erfassungsbogen.t04field03 = "3";
            }
        }

        private void T04Picker04_SelectedIndexChanged(object sender, EventArgs e)
        {
            // T04 04

            if (t04Picker04.SelectedIndex == 0)
            {
                Erfassungsbogen.t04field04 = "0";
            }
            else if (t04Picker04.SelectedIndex == 1)
            {
                Erfassungsbogen.t04field04 = "1";
            }
            else if (t04Picker04.SelectedIndex == 2)
            {
                Erfassungsbogen.t04field04 = "2";
            }
            else if (t04Picker04.SelectedIndex == 3)
            {
                Erfassungsbogen.t04field04 = "3";
            }
        }

        private void T04Picker05_SelectedIndexChanged(object sender, EventArgs e)
        {
            // T05 05
            if (t04Picker05.SelectedIndex == 0)
            {
                Erfassungsbogen.t04field05 = "0";
            }
            else if (t04Picker05.SelectedIndex == 1)
            {
                Erfassungsbogen.t04field05 = "1";
            }
            else if (t04Picker05.SelectedIndex == 2)
            {
                Erfassungsbogen.t04field05 = "2";
            }
            else if (t04Picker05.SelectedIndex == 3)
            {
                Erfassungsbogen.t04field05 = "3";
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
                    await Navigation.PushAsync(new Selbstversorgung_2());
                }
                else
                {
                    var BackQuestion = await DisplayAlert(AppResources.Information, AppResources.InformationSaveQuery, AppResources.Yes, AppResources.No);
                    if (BackQuestion == true)
                    {
                        t04field01.TextColor = t04field02.TextColor = t04field03.TextColor = t04field04.TextColor = t04field05.TextColor = AppManager.QuestionColor;

                        if ((Erfassungsbogen.t04field01 != "" && Erfassungsbogen.t04field01 != null) && (Erfassungsbogen.t04field02 != "" && Erfassungsbogen.t04field02 != null) && (Erfassungsbogen.t04field03 != "" && Erfassungsbogen.t04field03 != null) && (Erfassungsbogen.t04field04 != "" && Erfassungsbogen.t04field04 != null) && (Erfassungsbogen.t04field05 != "" && Erfassungsbogen.t04field05 != null))
                        {
                            WebRequest req = WebRequest.Create(DBManagement.DBConnection + "tbl_form_ebqe_t04_03_update.php");

                            req.Method = "POST"; //POST
                            req.Timeout = 15000;
                            req.ContentType = "application/x-www-form-urlencoded";

                            string postData = "mstr=" + App.user.selected_mstr_ebqe + "&bewonerid=" + App.user.selected_id_bewohner + "&t04field01=" + Erfassungsbogen.t04field01 + "&t04field02=" + Erfassungsbogen.t04field02 + "&t04field03=" + Erfassungsbogen.t04field03 + "&t04field04=" + Erfassungsbogen.t04field04 + "&t04field05=" + Erfassungsbogen.t04field05;

                            byte[] byteArray = Encoding.UTF8.GetBytes(postData);

                            req.ContentLength = byteArray.Length;

                            Stream ds = await req.GetRequestStreamAsync();
                            await ds.WriteAsync(byteArray, 0, byteArray.Length);
                            ds.Close();

                            await Navigation.PushAsync(new Selbstversorgung_2());
                        }
                        else
                        {
                            if (Erfassungsbogen.t04field01 == "" || Erfassungsbogen.t04field01 == null)
                            {
                                t04field01.TextColor = Color.Red;
                            }
                            if (Erfassungsbogen.t04field02 == "" || Erfassungsbogen.t04field02 == null)
                            {
                                t04field02.TextColor = Color.Red;
                            }
                            if (Erfassungsbogen.t04field03 == "" || Erfassungsbogen.t04field03 == null)
                            {
                                t04field03.TextColor = Color.Red;
                            }
                            if (Erfassungsbogen.t04field04 == "" || Erfassungsbogen.t04field04 == null)
                            {
                                t04field04.TextColor = Color.Red;
                            }
                            if (Erfassungsbogen.t04field05 == "" || Erfassungsbogen.t04field05 == null)
                            {
                                t04field05.TextColor = Color.Red;

                            }
                            await DisplayAlert(AppResources.Warning, AppResources.FieldsUnfilled, "OK");
                            BackButton.Source = "ic_arrow_back_ios.png";
                        }
                    }
                    else
                    {
                        Erfassungsbogen.t04field01 = Erfassungsbogen.t04field02 = Erfassungsbogen.t04field03 = Erfassungsbogen.t04field04 = Erfassungsbogen.t04field05 = "";

                        WebRequest req = WebRequest.Create(DBManagement.DBConnection + "tbl_form_ebqe_t04_03_update.php");

                        req.Method = "POST"; //POST
                        req.Timeout = 15000;
                        req.ContentType = "application/x-www-form-urlencoded";

                        string postData = "mstr=" + App.user.selected_mstr_ebqe + "&bewonerid=" + App.user.selected_id_bewohner + "&t04field01=" + Erfassungsbogen.t04field01 + "&t04field02=" + Erfassungsbogen.t04field02 + "&t04field03=" + Erfassungsbogen.t04field03 + "&t04field04=" + Erfassungsbogen.t04field04 + "&t04field05=" + Erfassungsbogen.t04field05;

                        byte[] byteArray = Encoding.UTF8.GetBytes(postData);

                        req.ContentLength = byteArray.Length;

                        Stream ds = await req.GetRequestStreamAsync();
                        await ds.WriteAsync(byteArray, 0, byteArray.Length);
                        ds.Close();

                        await Navigation.PushAsync(new Selbstversorgung_2());
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
                    await Navigation.PushAsync(new Selbstversorgung_4());
                }
                else
                {
                    t04field01.TextColor = t04field02.TextColor = t04field03.TextColor = t04field04.TextColor = t04field05.TextColor = AppManager.QuestionColor;

                    if ((Erfassungsbogen.t04field01 != "" && Erfassungsbogen.t04field01 != null) && (Erfassungsbogen.t04field02 != "" && Erfassungsbogen.t04field02 != null) && (Erfassungsbogen.t04field03 != "" && Erfassungsbogen.t04field03 != null) && (Erfassungsbogen.t04field04 != "" && Erfassungsbogen.t04field04 != null) && (Erfassungsbogen.t04field05 != "" && Erfassungsbogen.t04field05 != null))
                    {
                        WebRequest req = WebRequest.Create(DBManagement.DBConnection + "tbl_form_ebqe_t04_03_update.php");

                        req.Method = "POST"; //POST
                        req.Timeout = 15000;
                        req.ContentType = "application/x-www-form-urlencoded";

                        string postData = "mstr=" + App.user.selected_mstr_ebqe + "&bewonerid=" + App.user.selected_id_bewohner + "&t04field01=" + Erfassungsbogen.t04field01 + "&t04field02=" + Erfassungsbogen.t04field02 + "&t04field03=" + Erfassungsbogen.t04field03 + "&t04field04=" + Erfassungsbogen.t04field04 + "&t04field05=" + Erfassungsbogen.t04field05;

                        byte[] byteArray = Encoding.UTF8.GetBytes(postData);

                        req.ContentLength = byteArray.Length;

                        Stream ds = await req.GetRequestStreamAsync();
                        await ds.WriteAsync(byteArray, 0, byteArray.Length);
                        ds.Close();

                        await Navigation.PushAsync(new Selbstversorgung_4());
                    }
                    else
                    {
                        if (Erfassungsbogen.t04field01 == "" || Erfassungsbogen.t04field01 == null)
                        {
                            t04field01.TextColor = Color.Red;
                        }
                        if (Erfassungsbogen.t04field02 == "" || Erfassungsbogen.t04field02 == null)
                        {
                            t04field02.TextColor = Color.Red;
                        }
                        if (Erfassungsbogen.t04field03 == "" || Erfassungsbogen.t04field03 == null)
                        {
                            t04field03.TextColor = Color.Red;
                        }
                        if (Erfassungsbogen.t04field04 == "" || Erfassungsbogen.t04field04 == null)
                        {
                            t04field04.TextColor = Color.Red;
                        }
                        if (Erfassungsbogen.t04field05 == "" || Erfassungsbogen.t04field05 == null)
                        {
                            t04field05.TextColor = Color.Red;

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