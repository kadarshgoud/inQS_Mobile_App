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
    public partial class Verhaltensweisen_2 : ContentPage, INotifyPropertyChanged
    {
        public bool InitialDataIsEmpty;

        public Verhaltensweisen_2()
        {
            InitializeComponent();
            BindingContext = this;

            BogenLabel.Text = AppResources.SurveyHeadline + " " + DBManagement.getYearCode(App.user.selected_mstr_ebqe) + " " + AppResources.SurveyHeadlineFor + " " + Erfassungsbogen.Bewohnerbezeichnung;

            t03Picker06.Items.Add("0 = nie");
            t03Picker06.Items.Add("1 = maximal 1x wöchentlich");
            t03Picker06.Items.Add("3 = mehrmals wöchentlich");
            t03Picker06.Items.Add("5 = täglich");

            t03Picker07.Items.Add("0 = nie");
            t03Picker07.Items.Add("1 = maximal 1x wöchentlich");
            t03Picker07.Items.Add("3 = mehrmals wöchentlich");
            t03Picker07.Items.Add("5 = täglich");

            t03Picker08.Items.Add("0 = nie");
            t03Picker08.Items.Add("1 = maximal 1x wöchentlich");
            t03Picker08.Items.Add("3 = mehrmals wöchentlich");
            t03Picker08.Items.Add("5 = täglich");

            t03Picker09.Items.Add("0 = nie");
            t03Picker09.Items.Add("1 = maximal 1x wöchentlich");
            t03Picker09.Items.Add("3 = mehrmals wöchentlich");
            t03Picker09.Items.Add("5 = täglich");

            t03Picker10.Items.Add("0 = nie");
            t03Picker10.Items.Add("1 = maximal 1x wöchentlich");
            t03Picker10.Items.Add("3 = mehrmals wöchentlich");
            t03Picker10.Items.Add("5 = täglich");
        }

        //Before page gets loaded this opertion is performed
        protected override async void OnAppearing()
        {
            base.OnAppearing();

            try
            {
                //ActivityIndicator = Loading...
                IsLoading = true;

                //WebRequest req = WebRequest.Create(DBManagement.DBConnection + "tbl_form_ebqe_t03_02_read.php");

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

                //if (split[0] != "" && split[1] != "" && split[2] != "" && split[3] != "" && split[4] != "")
                //{
                //    InitialDataIsEmpty = false;
                //}
                //Erfassungsbogen.t03field06 = split[0];
                //Erfassungsbogen.t03field07 = split[1];
                //Erfassungsbogen.t03field08 = split[2];
                //Erfassungsbogen.t03field09 = split[3];
                //Erfassungsbogen.t03field10 = split[4];

                if (Erfassungsbogen.t03field06 == "0")
                {
                    t03Picker06.SelectedIndex = 0;                         // rb1 is the image file with checked box image
                }
                else if (Erfassungsbogen.t03field06 == "1")
                {
                    t03Picker06.SelectedIndex = 1;
                }
                else if (Erfassungsbogen.t03field06 == "5")
                {
                    t03Picker06.SelectedIndex = 3;
                }
                else if (Erfassungsbogen.t03field06 == "3")
                {
                    t03Picker06.SelectedIndex = 2;
                }
                else
                {
                    t03Picker06.SelectedIndex = -1;
                }

                if (Erfassungsbogen.t03field07 == "0")
                {
                    t03Picker07.SelectedIndex = 0; // rb1 is the image file with checked box image
                }
                else if (Erfassungsbogen.t03field07 == "1")
                {
                    t03Picker07.SelectedIndex = 1;
                }
                else if (Erfassungsbogen.t03field07 == "5")
                {
                    t03Picker07.SelectedIndex = 3;
                }
                else if (Erfassungsbogen.t03field07 == "3")
                {
                    t03Picker07.SelectedIndex = 2;
                }
                else
                {
                    t03Picker07.SelectedIndex = -1;
                }

                if (Erfassungsbogen.t03field08 == "0")
                {
                    t03Picker08.SelectedIndex = 0; // rb1 is the image file with checked box image
                }
                else if (Erfassungsbogen.t03field08 == "1")
                {
                    t03Picker08.SelectedIndex = 1;
                }
                else if (Erfassungsbogen.t03field08 == "5")
                {
                    t03Picker08.SelectedIndex = 3;
                }
                else if (Erfassungsbogen.t03field08 == "3")
                {
                    t03Picker08.SelectedIndex = 2;
                }
                else
                {
                    t03Picker08.SelectedIndex = -1;
                }
                if (Erfassungsbogen.t03field09 == "0")
                {
                    t03Picker09.SelectedIndex = 0; // rb1 is the image file with checked box image
                }
                else if (Erfassungsbogen.t03field09 == "1")
                {
                    t03Picker09.SelectedIndex = 1;
                }
                else if (Erfassungsbogen.t03field09 == "5")
                {
                    t03Picker09.SelectedIndex = 3;
                }
                else if (Erfassungsbogen.t03field09 == "3")
                {
                    t03Picker09.SelectedIndex = 2;
                }
                else
                {
                    t03Picker09.SelectedIndex = -1;
                }
                if (Erfassungsbogen.t03field10 == "0")
                {
                    t03Picker10.SelectedIndex = 0; // rb1 is the image file with checked box image
                }
                else if (Erfassungsbogen.t03field10 == "1")
                {
                    t03Picker10.SelectedIndex = 1;
                }
                else if (Erfassungsbogen.t03field10 == "5")
                {
                    t03Picker10.SelectedIndex = 3;
                }
                else if (Erfassungsbogen.t03field10 == "3")
                {
                    t03Picker10.SelectedIndex = 2;
                }
                else
                {
                    t03Picker10.SelectedIndex = -1;
                }

                //ActivityIndicator = Idle
                IsLoading = false;
            }
            catch (Exception)
            {
                await DisplayAlert(AppResources.AppError, AppResources.AppErrorMsg, "OK");
            }
        }

        private void T03Picker06_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (t03Picker06.SelectedIndex == 0)
            {
                Erfassungsbogen.t03field06 = "0";
            }
            else if (t03Picker06.SelectedIndex == 1)
            {
                Erfassungsbogen.t03field06 = "1";
            }
            else if (t03Picker06.SelectedIndex == 2)
            {
                Erfassungsbogen.t03field06 = "3";
            }
            else if (t03Picker06.SelectedIndex == 3)
            {
                Erfassungsbogen.t03field06 = "5";
            }
        }

        private void T03Picker07_SelectedIndexChanged(object sender, EventArgs e)
        {
            // T02 07

            if (t03Picker07.SelectedIndex == 0)
            {
                Erfassungsbogen.t03field07 = "0";
            }
            else if (t03Picker07.SelectedIndex == 1)
            {
                Erfassungsbogen.t03field07 = "1";
            }
            else if (t03Picker07.SelectedIndex == 2)
            {
                Erfassungsbogen.t03field07 = "3";
            }
            else if (t03Picker07.SelectedIndex == 3)
            {
                Erfassungsbogen.t03field07 = "5";
            }
        }

        private void T03Picker08_SelectedIndexChanged(object sender, EventArgs e)
        {
            //T03 08

            if (t03Picker08.SelectedIndex == 0)
            {
                Erfassungsbogen.t03field08 = "0";
            }
            else if (t03Picker08.SelectedIndex == 1)
            {
                Erfassungsbogen.t03field08 = "1";
            }
            else if (t03Picker08.SelectedIndex == 2)
            {
                Erfassungsbogen.t03field08 = "3";
            }
            else if (t03Picker08.SelectedIndex == 3)
            {
                Erfassungsbogen.t03field08 = "5";
            }
        }

        private void T03Picker09_SelectedIndexChanged(object sender, EventArgs e)
        {
            // T03 09

            if (t03Picker09.SelectedIndex == 0)
            {
                Erfassungsbogen.t03field09 = "0";
            }
            else if (t03Picker09.SelectedIndex == 1)
            {
                Erfassungsbogen.t03field09 = "1";
            }
            else if (t03Picker09.SelectedIndex == 2)
            {
                Erfassungsbogen.t03field09 = "3";
            }
            else if (t03Picker09.SelectedIndex == 3)
            {
                Erfassungsbogen.t03field09 = "5";
            }
        }

        private void T03Picker10_SelectedIndexChanged(object sender, EventArgs e)
        {
            // T03 05
            if (t03Picker10.SelectedIndex == 0)
            {
                Erfassungsbogen.t03field10 = "0";
            }
            else if (t03Picker10.SelectedIndex == 1)
            {
                Erfassungsbogen.t03field10 = "1";
            }
            else if (t03Picker10.SelectedIndex == 2)
            {
                Erfassungsbogen.t03field10 = "3";
            }
            else if (t03Picker10.SelectedIndex == 3)
            {
                Erfassungsbogen.t03field10 = "5";
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
                    await Navigation.PushAsync(new Verhaltensweisen_1());
                }
                else
                {
                    var BackQuestion = await DisplayAlert(AppResources.Information, AppResources.InformationSaveQuery, AppResources.Yes, AppResources.No);
                    if (BackQuestion == true)
                    {
                        t03field06.TextColor = t03field07.TextColor = t03field08.TextColor = t03field09.TextColor = t03field10.TextColor = AppManager.QuestionColor;

                        if ((Erfassungsbogen.t03field06 != "" && Erfassungsbogen.t03field06 != null) && (Erfassungsbogen.t03field07 != "" && Erfassungsbogen.t03field07 != null) && (Erfassungsbogen.t03field08 != "" && Erfassungsbogen.t03field08 != null) && (Erfassungsbogen.t03field09 != "" && Erfassungsbogen.t03field09 != null) && (Erfassungsbogen.t03field10 != "" && Erfassungsbogen.t03field10 != null))
                        {
                            WebRequest req = WebRequest.Create(DBManagement.DBConnection + "tbl_form_ebqe_t03_02_update.php");

                            req.Method = "POST"; //POST
                            req.Timeout = 15000;
                            req.ContentType = "application/x-www-form-urlencoded";

                            string postData = "mstr=" + App.user.selected_mstr_ebqe + "&bewonerid=" + App.user.selected_id_bewohner + "&t03field06=" + Erfassungsbogen.t03field06 + "&t03field07=" + Erfassungsbogen.t03field07 +
                                "&t03field08=" + Erfassungsbogen.t03field08 + "&t03field09=" + Erfassungsbogen.t03field09 + "&t03field10=" + Erfassungsbogen.t03field10;

                            byte[] byteArray = Encoding.UTF8.GetBytes(postData);

                            req.ContentLength = byteArray.Length;

                            Stream ds = await req.GetRequestStreamAsync();
                            await ds.WriteAsync(byteArray, 0, byteArray.Length);
                            ds.Close();

                            await Navigation.PushAsync(new Verhaltensweisen_1());
                        }
                        else
                        {
                            if (Erfassungsbogen.t03field06 == "" || Erfassungsbogen.t03field06 == null)
                            {
                                t03field06.TextColor = Color.Red;
                            }
                            if (Erfassungsbogen.t03field07 == "" || Erfassungsbogen.t03field07 == null)
                            {
                                t03field07.TextColor = Color.Red;
                            }
                            if (Erfassungsbogen.t03field08 == "" || Erfassungsbogen.t03field08 == null)
                            {
                                t03field08.TextColor = Color.Red;
                            }
                            if (Erfassungsbogen.t03field09 == "" || Erfassungsbogen.t03field09 == null)
                            {
                                t03field09.TextColor = Color.Red;
                            }
                            if (Erfassungsbogen.t03field10 == "" || Erfassungsbogen.t03field10 == null)
                            {
                                t03field10.TextColor = Color.Red;
                            }
                            await DisplayAlert(AppResources.Warning, AppResources.FieldsUnfilled, "OK");
                            BackButton.Source = "ic_arrow_back_ios.png";
                        }
                    }
                    else
                    {
                        Erfassungsbogen.t03field06 = Erfassungsbogen.t03field07 = Erfassungsbogen.t03field08 = Erfassungsbogen.t03field09 = Erfassungsbogen.t03field10 = "";

                        WebRequest req = WebRequest.Create(DBManagement.DBConnection + "tbl_form_ebqe_t03_02_update.php");

                        req.Method = "POST"; //POST
                        req.Timeout = 15000;
                        req.ContentType = "application/x-www-form-urlencoded";

                        string postData = "mstr=" + App.user.selected_mstr_ebqe + "&bewonerid=" + App.user.selected_id_bewohner + "&t03field06=" + Erfassungsbogen.t03field06 + "&t03field07=" + Erfassungsbogen.t03field07 + "&t03field08=" + Erfassungsbogen.t03field08 + "&t03field09=" + Erfassungsbogen.t03field09 + "&t03field10=" + Erfassungsbogen.t03field10;

                        byte[] byteArray = Encoding.UTF8.GetBytes(postData);

                        req.ContentLength = byteArray.Length;

                        Stream ds = await req.GetRequestStreamAsync();
                        await ds.WriteAsync(byteArray, 0, byteArray.Length);
                        ds.Close();

                        await Navigation.PushAsync(new Verhaltensweisen_1());
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
                    await Navigation.PushAsync(new Verhaltensweisen_3());
                }
                else
                {
                    t03field06.TextColor = t03field07.TextColor = t03field08.TextColor = t03field09.TextColor = t03field10.TextColor = AppManager.QuestionColor;

                    if ((Erfassungsbogen.t03field06 != "" && Erfassungsbogen.t03field06 != null) && (Erfassungsbogen.t03field07 != "" && Erfassungsbogen.t03field07 != null) && (Erfassungsbogen.t03field08 != "" && Erfassungsbogen.t03field08 != null) && (Erfassungsbogen.t03field09 != "" && Erfassungsbogen.t03field09 != null) && (Erfassungsbogen.t03field10 != "" && Erfassungsbogen.t03field10 != null))
                    {
                        WebRequest req = WebRequest.Create(DBManagement.DBConnection + "tbl_form_ebqe_t03_02_update.php");

                        req.Method = "POST"; //POST
                        req.Timeout = 15000;
                        req.ContentType = "application/x-www-form-urlencoded";

                        string postData = "mstr=" + App.user.selected_mstr_ebqe + "&bewonerid=" + App.user.selected_id_bewohner + "&t03field06=" + Erfassungsbogen.t03field06 + "&t03field07=" + Erfassungsbogen.t03field07 + "&t03field08=" + Erfassungsbogen.t03field08 + "&t03field09=" + Erfassungsbogen.t03field09 + "&t03field10=" + Erfassungsbogen.t03field10;

                        byte[] byteArray = Encoding.UTF8.GetBytes(postData);

                        req.ContentLength = byteArray.Length;

                        Stream ds = await req.GetRequestStreamAsync();
                        await ds.WriteAsync(byteArray, 0, byteArray.Length);
                        ds.Close();

                        await Navigation.PushAsync(new Verhaltensweisen_3());
                    }
                    else
                    {
                        if (Erfassungsbogen.t03field06 == "" || Erfassungsbogen.t03field06 == null)
                        {
                            t03field06.TextColor = Color.Red;
                        }
                        if (Erfassungsbogen.t03field07 == "" || Erfassungsbogen.t03field07 == null)
                        {
                            t03field07.TextColor = Color.Red;
                        }
                        if (Erfassungsbogen.t03field08 == "" || Erfassungsbogen.t03field08 == null)
                        {
                            t03field08.TextColor = Color.Red;
                        }
                        if (Erfassungsbogen.t03field09 == "" || Erfassungsbogen.t03field09 == null)
                        {
                            t03field09.TextColor = Color.Red;
                        }
                        if (Erfassungsbogen.t03field10 == "" || Erfassungsbogen.t03field10 == null)
                        {
                            t03field10.TextColor = Color.Red;
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