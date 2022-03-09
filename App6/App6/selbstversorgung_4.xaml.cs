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
    public partial class Selbstversorgung_4 : ContentPage, INotifyPropertyChanged
    {
        public bool InitialDataIsEmpty;

        public Selbstversorgung_4()
        {
            InitializeComponent();
            BindingContext = this;

            BogenLabel.Text = AppResources.SurveyHeadline + " " + DBManagement.getYearCode(App.user.selected_mstr_ebqe) + " " + AppResources.SurveyHeadlineFor + " " + Erfassungsbogen.Bewohnerbezeichnung;

            t04Picker06.Items.Add("0 = selbständig");
            t04Picker06.Items.Add("1 = überwiegend selbständig");
            t04Picker06.Items.Add("2 = überwiegend unselbständig");
            t04Picker06.Items.Add("3 = unselbständig");

            t04Picker07.Items.Add("0 = selbständig");
            t04Picker07.Items.Add("1 = überwiegend selbständig");
            t04Picker07.Items.Add("2 = überwiegend unselbständig");
            t04Picker07.Items.Add("3 = unselbständig");

            t04Picker08.Items.Add("0 = selbständig");
            t04Picker08.Items.Add("3 = überwiegend selbständig");
            t04Picker08.Items.Add("6 = überwiegend unselbständig");
            t04Picker08.Items.Add("9 = unselbständig");

            t04Picker09.Items.Add("0 = selbständig");
            t04Picker09.Items.Add("2 = überwiegend selbständig");
            t04Picker09.Items.Add("4 = überwiegend unselbständig");
            t04Picker09.Items.Add("6 = unselbständig");

            t04Picker10.Items.Add("0 = selbständig");
            t04Picker10.Items.Add("2 = überwiegend selbständig");
            t04Picker10.Items.Add("4 = überwiegend unselbständig");
            t04Picker10.Items.Add("6 = unselbständig");
        }

        //Before page gets loaded this opertion is performed
        protected override async void OnAppearing()
        {
            base.OnAppearing();

            try
            {
                //ActivityIndicator = Loading...
                IsLoading = true;

               /* WebRequest req = WebRequest.Create(DBManagement.DBConnection + "tbl_form_ebqe_t04_04_read.php");

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

                Erfassungsbogen.t04field06 = split[0];
                Erfassungsbogen.t04field07 = split[1];
                Erfassungsbogen.t04field08 = split[2];
                Erfassungsbogen.t04field09 = split[3];
                Erfassungsbogen.t04field10 = split[4];*/

                if (Erfassungsbogen.t04field06 == "0")
                {
                    t04Picker06.SelectedIndex = 0;                         // rb1 is the image file with checked box image
                }
                else if (Erfassungsbogen.t04field06 == "1")
                {
                    t04Picker06.SelectedIndex = 1;
                }
                else if (Erfassungsbogen.t04field06 == "2")
                {
                    t04Picker06.SelectedIndex = 2;
                }
                else if (Erfassungsbogen.t04field06 == "3")
                {
                    t04Picker06.SelectedIndex = 3;
                }
                else
                {
                    t04Picker06.SelectedIndex = -1;
                }

                if (Erfassungsbogen.t04field07 == "0")
                {
                    t04Picker07.SelectedIndex = 0; // rb1 is the image file with checked box image
                }
                else if (Erfassungsbogen.t04field07 == "1")
                {
                    t04Picker07.SelectedIndex = 1;
                }
                else if (Erfassungsbogen.t04field07 == "2")
                {
                    t04Picker07.SelectedIndex = 2;
                }
                else if (Erfassungsbogen.t04field07 == "3")
                {
                    t04Picker07.SelectedIndex = 3;
                }
                else
                {
                    t04Picker07.SelectedIndex = -1;
                }

                if (Erfassungsbogen.t04field08 == "0")
                {
                    t04Picker08.SelectedIndex = 0; // rb1 is the image file with checked box image
                }
                else if (Erfassungsbogen.t04field08 == "3")
                {
                    t04Picker08.SelectedIndex = 1;
                }
                else if (Erfassungsbogen.t04field08 == "6")
                {
                    t04Picker08.SelectedIndex = 2;
                }
                else if (Erfassungsbogen.t04field08 == "9")
                {
                    t04Picker08.SelectedIndex = 3;
                }
                else
                {
                    t04Picker08.SelectedIndex = -1;
                }
                if (Erfassungsbogen.t04field09 == "0")
                {
                    t04Picker09.SelectedIndex = 0; // rb1 is the image file with checked box image
                }
                else if (Erfassungsbogen.t04field09 == "2")
                {
                    t04Picker09.SelectedIndex = 1;
                }
                else if (Erfassungsbogen.t04field09 == "4")
                {
                    t04Picker09.SelectedIndex = 2;
                }
                else if (Erfassungsbogen.t04field09 == "6")
                {
                    t04Picker09.SelectedIndex = 3;
                }
                else
                {
                    t04Picker09.SelectedIndex = -1;
                }

                if (Erfassungsbogen.t04field10 == "0")
                {
                    t04Picker10.SelectedIndex = 0; // rb1 is the image file with checked box image
                }
                else if (Erfassungsbogen.t04field10 == "2")
                {
                    t04Picker10.SelectedIndex = 1;
                }
                else if (Erfassungsbogen.t04field10 == "4")
                {
                    t04Picker10.SelectedIndex = 2;
                }
                else if (Erfassungsbogen.t04field10 == "6")
                {
                    t04Picker10.SelectedIndex = 3;
                }
                else
                {
                    t04Picker10.SelectedIndex = -1;
                }
                //ActivityIndicator = Idle
                IsLoading = false;

            }
            catch (Exception)
            {
                await DisplayAlert(AppResources.AppError, AppResources.AppErrorMsg, "OK");
            }
        }

        private void T04Picker06_SelectedIndexChanged(object sender, EventArgs e)
        {
            // picker T04 06
            if (t04Picker06.SelectedIndex == 0)
            {
                Erfassungsbogen.t04field06 = "0";
            }
            else if (t04Picker06.SelectedIndex == 1)
            {
                Erfassungsbogen.t04field06 = "1";
            }
            else if (t04Picker06.SelectedIndex == 2)
            {
                Erfassungsbogen.t04field06 = "2";
            }
            else if (t04Picker06.SelectedIndex == 3)
            {
                Erfassungsbogen.t04field06 = "3";
            }
        }

        private void T04Picker07_SelectedIndexChanged(object sender, EventArgs e)
        {
            // T04 07
            if (t04Picker07.SelectedIndex == 0)
            {
                Erfassungsbogen.t04field07 = "0";
            }
            else if (t04Picker07.SelectedIndex == 1)
            {
                Erfassungsbogen.t04field07 = "1";
            }
            else if (t04Picker07.SelectedIndex == 2)
            {
                Erfassungsbogen.t04field07 = "2";
            }
            else if (t04Picker07.SelectedIndex == 3)
            {
                Erfassungsbogen.t04field07 = "3";
            }
        }

        private void T04Picker09_SelectedIndexChanged(object sender, EventArgs e)
        {
            // T04 09

            if (t04Picker09.SelectedIndex == 0)
            {
                Erfassungsbogen.t04field09 = "0";
            }
            else if (t04Picker09.SelectedIndex == 1)
            {
                Erfassungsbogen.t04field09 = "2";
            }
            else if (t04Picker09.SelectedIndex == 2)
            {
                Erfassungsbogen.t04field09 = "4";
            }
            else if (t04Picker09.SelectedIndex == 3)
            {
                Erfassungsbogen.t04field09 = "6";
            }
        }

        private void T04Picker10_SelectedIndexChanged(object sender, EventArgs e)
        {
            // T05 05
            if (t04Picker10.SelectedIndex == 0)
            {
                Erfassungsbogen.t04field10 = "0";
            }
            else if (t04Picker10.SelectedIndex == 1)
            {
                Erfassungsbogen.t04field10 = "2";
            }
            else if (t04Picker10.SelectedIndex == 2)
            {
                Erfassungsbogen.t04field10 = "4";
            }
            else if (t04Picker10.SelectedIndex == 3)
            {
                Erfassungsbogen.t04field10 = "6";
            }
        }

        private void T04Picker08_SelectedIndexChanged(object sender, EventArgs e)
        {
            //T04 08

            if (t04Picker08.SelectedIndex == 0)
            {
                Erfassungsbogen.t04field08 = "0";
            }
            else if (t04Picker08.SelectedIndex == 1)
            {
                Erfassungsbogen.t04field08 = "3";
            }
            else if (t04Picker08.SelectedIndex == 2)
            {
                Erfassungsbogen.t04field08 = "6";
            }
            else if (t04Picker08.SelectedIndex == 3)
            {
                Erfassungsbogen.t04field08 = "9";
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
                    await Navigation.PushAsync(new Selbstversorgung_3());
                }
                else
                {
                    var BackQuestion = await DisplayAlert(AppResources.Information, AppResources.InformationSaveQuery, AppResources.Yes, AppResources.No);
                    if (BackQuestion == true)
                    {
                        t04field06.TextColor = t04field07.TextColor = t04field08.TextColor = t04field09.TextColor = t04field10.TextColor = AppManager.QuestionColor;

                        if ((Erfassungsbogen.t04field06 != "" && Erfassungsbogen.t04field06 != null) && (Erfassungsbogen.t04field07 != "" && Erfassungsbogen.t04field07 != null) && (Erfassungsbogen.t04field08 != "" && Erfassungsbogen.t04field08 != null) && (Erfassungsbogen.t04field09 != "" && Erfassungsbogen.t04field09 != null) && (Erfassungsbogen.t04field10 != "" && Erfassungsbogen.t04field10 != null))
                        {
                            WebRequest req = WebRequest.Create(DBManagement.DBConnection + "tbl_form_ebqe_t04_04_update.php");

                            req.Method = "POST"; //POST
                            req.Timeout = 15000;
                            req.ContentType = "application/x-www-form-urlencoded";

                            string postData = "mstr=" + App.user.selected_mstr_ebqe + "&bewonerid=" + App.user.selected_id_bewohner + "&t04field06=" + Erfassungsbogen.t04field06 + "&t04field07=" + Erfassungsbogen.t04field07 + "&t04field08=" + Erfassungsbogen.t04field08 + "&t04field09=" + Erfassungsbogen.t04field09 + "&t04field10=" + Erfassungsbogen.t04field10;

                            byte[] byteArray = Encoding.UTF8.GetBytes(postData);

                            req.ContentLength = byteArray.Length;

                            Stream ds = await req.GetRequestStreamAsync();
                            await ds.WriteAsync(byteArray, 0, byteArray.Length);
                            ds.Close();

                            await Navigation.PushAsync(new Selbstversorgung_3());
                        }
                        else
                        {
                            if (Erfassungsbogen.t04field06 == "" || Erfassungsbogen.t04field06 == null)
                            {
                                t04field06.TextColor = Color.Red;
                            }
                            if (Erfassungsbogen.t04field07 == "" || Erfassungsbogen.t04field07 == null)
                            {
                                t04field07.TextColor = Color.Red;
                            }
                            if (Erfassungsbogen.t04field08 == "" || Erfassungsbogen.t04field08 == null)
                            {
                                t04field08.TextColor = Color.Red;
                            }
                            if (Erfassungsbogen.t04field09 == "" || Erfassungsbogen.t04field09 == null)
                            {
                                t04field09.TextColor = Color.Red;
                            }
                            if (Erfassungsbogen.t04field10 == "" || Erfassungsbogen.t04field10 == null)
                            {
                                t04field10.TextColor = Color.Red;
                            }

                            await DisplayAlert(AppResources.Warning, AppResources.FieldsUnfilled, "OK");
                            BackButton.Source = "ic_arrow_back_ios.png";
                        }
                    }
                    else
                    {
                        Erfassungsbogen.t04field06 = Erfassungsbogen.t04field07 = Erfassungsbogen.t04field08 = Erfassungsbogen.t04field09 = Erfassungsbogen.t04field10 = "";

                        WebRequest req = WebRequest.Create(DBManagement.DBConnection + "tbl_form_ebqe_t04_04_update.php");

                        req.Method = "POST"; //POST
                        req.Timeout = 15000;
                        req.ContentType = "application/x-www-form-urlencoded";

                        string postData = "mstr=" + App.user.selected_mstr_ebqe + "&bewonerid=" + App.user.selected_id_bewohner + "&t04field06=" + Erfassungsbogen.t04field06 + "&t04field07=" + Erfassungsbogen.t04field07 + "&t04field08=" + Erfassungsbogen.t04field08 + "&t04field09=" + Erfassungsbogen.t04field09 + "&t04field10=" + Erfassungsbogen.t04field10;

                        byte[] byteArray = Encoding.UTF8.GetBytes(postData);

                        req.ContentLength = byteArray.Length;

                        Stream ds = await req.GetRequestStreamAsync();
                        await ds.WriteAsync(byteArray, 0, byteArray.Length);
                        ds.Close();

                        await Navigation.PushAsync(new Selbstversorgung_3());
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
                    await Navigation.PushAsync(new Selbstversorgung_5());
                }
                else
                {
                    t04field06.TextColor = t04field07.TextColor = t04field08.TextColor = t04field09.TextColor = t04field10.TextColor = AppManager.QuestionColor;

                    if ((Erfassungsbogen.t04field06 != "" && Erfassungsbogen.t04field06 != null) && (Erfassungsbogen.t04field07 != "" && Erfassungsbogen.t04field07 != null) && (Erfassungsbogen.t04field08 != "" && Erfassungsbogen.t04field08 != null) && (Erfassungsbogen.t04field09 != "" && Erfassungsbogen.t04field09 != null) && (Erfassungsbogen.t04field10 != "" && Erfassungsbogen.t04field10 != null))
                    {
                        WebRequest req = WebRequest.Create(DBManagement.DBConnection + "tbl_form_ebqe_t04_04_update.php");

                        req.Method = "POST"; //POST
                        req.Timeout = 15000;
                        req.ContentType = "application/x-www-form-urlencoded";

                        string postData = "mstr=" + App.user.selected_mstr_ebqe + "&bewonerid=" + App.user.selected_id_bewohner + "&t04field06=" + Erfassungsbogen.t04field06 + "&t04field07=" + Erfassungsbogen.t04field07 + "&t04field08=" + Erfassungsbogen.t04field08 + "&t04field09=" + Erfassungsbogen.t04field09 + "&t04field10=" + Erfassungsbogen.t04field10;

                        byte[] byteArray = Encoding.UTF8.GetBytes(postData);

                        req.ContentLength = byteArray.Length;

                        Stream ds = await req.GetRequestStreamAsync();
                        await ds.WriteAsync(byteArray, 0, byteArray.Length);
                        ds.Close();

                        await Navigation.PushAsync(new Selbstversorgung_5());
                    }
                    else
                    {
                        if (Erfassungsbogen.t04field06 == "" || Erfassungsbogen.t04field06 == null)
                        {
                            t04field06.TextColor = Color.Red;
                        }
                        if (Erfassungsbogen.t04field07 == "" || Erfassungsbogen.t04field07 == null)
                        {
                            t04field07.TextColor = Color.Red;
                        }
                        if (Erfassungsbogen.t04field08 == "" || Erfassungsbogen.t04field08 == null)
                        {
                            t04field08.TextColor = Color.Red;
                        }
                        if (Erfassungsbogen.t04field09 == "" || Erfassungsbogen.t04field09 == null)
                        {
                            t04field09.TextColor = Color.Red;
                        }
                        if (Erfassungsbogen.t04field10 == "" || Erfassungsbogen.t04field10 == null)
                        {
                            t04field10.TextColor = Color.Red;
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