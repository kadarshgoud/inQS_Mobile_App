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
    public partial class Selbstversorgung_2 : ContentPage, INotifyPropertyChanged
    {
        public bool InitialDataIsEmpty;

        public Selbstversorgung_2()
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
                    await Navigation.PushAsync(new Selbstversorgung_1());
                }
                else
                {
                    var BackQuestion = await DisplayAlert(AppResources.Information, AppResources.InformationSaveQuery, AppResources.Yes, AppResources.No);
                    if (BackQuestion == true)
                    {
                        t04fields3.TextColor = AppManager.QuestionColor;

                        if (Erfassungsbogen.t04fields3 != "" && Erfassungsbogen.t04fields3 != null)
                        {
                            WebRequest req = WebRequest.Create(DBManagement.DBConnection + "tbl_form_ebqe_t04_02_update.php");

                            req.Method = "POST"; //POST
                            req.Timeout = 15000;
                            req.ContentType = "application/x-www-form-urlencoded";

                            string postData = "mstr=" + App.user.selected_mstr_ebqe + "&bewonerid=" + App.user.selected_id_bewohner + "&t04fields3=" + Erfassungsbogen.t04fields3;

                            byte[] byteArray = Encoding.UTF8.GetBytes(postData);

                            req.ContentLength = byteArray.Length;

                            Stream ds = await req.GetRequestStreamAsync();
                            await ds.WriteAsync(byteArray, 0, byteArray.Length);
                            ds.Close();

                            await Navigation.PushAsync(new Selbstversorgung_1());
                        }
                        else
                        {
                            if (Erfassungsbogen.t04fields3 == "" || Erfassungsbogen.t04fields3 == null)
                            {
                                t04fields3.TextColor = Color.Red;
                            }
                            await DisplayAlert(AppResources.Warning, AppResources.FieldsUnfilled, "OK");
                            BackButton.Source = "ic_arrow_back_ios.png";
                        }
                    }
                    else
                    {
                        Erfassungsbogen.t04fields3 = "";

                        WebRequest req = WebRequest.Create(DBManagement.DBConnection + "tbl_form_ebqe_t04_02_update.php");

                        req.Method = "POST"; //POST
                        req.Timeout = 15000;
                        req.ContentType = "application/x-www-form-urlencoded";

                        string postData = "mstr=" + App.user.selected_mstr_ebqe + "&bewonerid=" + App.user.selected_id_bewohner + "&t04fields3=" + Erfassungsbogen.t04fields3;

                        byte[] byteArray = Encoding.UTF8.GetBytes(postData);

                        req.ContentLength = byteArray.Length;

                        Stream ds = await req.GetRequestStreamAsync();
                        await ds.WriteAsync(byteArray, 0, byteArray.Length);
                        ds.Close();

                        await Navigation.PushAsync(new Selbstversorgung_1());
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

                //WebRequest req = WebRequest.Create(DBManagement.DBConnection + "tbl_form_ebqe_t04_02_read.php");

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

                //Erfassungsbogen.t04fields3 = split[0];

                if (Erfassungsbogen.t04fields3 == "1")
                {
                    t04Images3_1.Source = "ic_rb1.png";                            // rb1 is the image file with checked box image
                }
                else if (Erfassungsbogen.t04fields3 == "2")
                {
                    t04Images3_2.Source = "ic_rb1.png";
                }
                else if (Erfassungsbogen.t04fields3 == "3")
                {
                    t04Images3_3.Source = "ic_rb1.png";
                }
                else if (Erfassungsbogen.t04fields3 == "4")
                {
                    t04Images3_4.Source = "ic_rb1.png";
                }
                else if (Erfassungsbogen.t04fields3 == "5")
                {
                    t04Images3_5.Source = "ic_rb1.png";
                }
                else
                {
                    t04Images3_1.Source = "ic_rb2.png";                             // rb2 is the image with unchecked box
                    t04Images3_2.Source = "ic_rb2.png";
                    t04Images3_3.Source = "ic_rb2.png";
                    t04Images3_4.Source = "ic_rb2.png";
                    t04Images3_5.Source = "ic_rb2.png";
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
                    await Navigation.PushAsync(new Selbstversorgung_3());
                }
                else
                {
                    t04fields3.TextColor = AppManager.QuestionColor;

                    if (Erfassungsbogen.t04fields3 != "" && Erfassungsbogen.t04fields3 != null)
                    {
                        WebRequest req = WebRequest.Create(DBManagement.DBConnection + "tbl_form_ebqe_t04_02_update.php");

                        req.Method = "POST"; //POST
                        req.Timeout = 15000;
                        req.ContentType = "application/x-www-form-urlencoded";

                        string postData = "mstr=" + App.user.selected_mstr_ebqe + "&bewonerid=" + App.user.selected_id_bewohner + "&t04fields3=" + Erfassungsbogen.t04fields3;

                        byte[] byteArray = Encoding.UTF8.GetBytes(postData);

                        req.ContentLength = byteArray.Length;

                        Stream ds = await req.GetRequestStreamAsync();
                        await ds.WriteAsync(byteArray, 0, byteArray.Length);
                        ds.Close();

                        await Navigation.PushAsync(new Selbstversorgung_3());
                    }
                    else
                    {
                        if (Erfassungsbogen.t04fields3 == "" || Erfassungsbogen.t04fields3 == null)
                        {
                            t04fields3.TextColor = Color.Red;
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
            if (Erfassungsbogen.t04fields3 != "1" | Erfassungsbogen.t04fields3 == null)
            {
                t04Images3_1.Source = "ic_rb1.png";
                t04Images3_2.Source = "ic_rb2.png";
                t04Images3_3.Source = "ic_rb2.png";
                t04Images3_4.Source = "ic_rb2.png";
                t04Images3_5.Source = "ic_rb2.png";
                Erfassungsbogen.t04fields3 = "1";
            }
            else
            {
                t04Images3_1.Source = "ic_rb2.png";
                Erfassungsbogen.t04fields3 = "";
            }
        }

        private void TapGestureRecognizer_Tapped_1(object sender, EventArgs e)
        {
            if (Erfassungsbogen.t04fields3 != "2" | Erfassungsbogen.t04fields3 == null)
            {
                t04Images3_2.Source = "ic_rb1.png";
                t04Images3_1.Source = "ic_rb2.png";
                t04Images3_3.Source = "ic_rb2.png";
                t04Images3_4.Source = "ic_rb2.png";
                t04Images3_5.Source = "ic_rb2.png";
                Erfassungsbogen.t04fields3 = "2";
            }
            else
            {
                t04Images3_2.Source = "ic_rb2.png";
                Erfassungsbogen.t04fields3 = "";
            }
        }

        private void TapGestureRecognizer_Tapped_2(object sender, EventArgs e)
        {
            if (Erfassungsbogen.t04fields3 != "3" | Erfassungsbogen.t04fields3 == null)
            {
                t04Images3_3.Source = "ic_rb1.png";
                t04Images3_2.Source = "ic_rb2.png";
                t04Images3_1.Source = "ic_rb2.png";
                t04Images3_4.Source = "ic_rb2.png";
                t04Images3_5.Source = "ic_rb2.png";
                Erfassungsbogen.t04fields3 = "3";
            }
            else
            {
                t04Images3_3.Source = "ic_rb2.png";
                Erfassungsbogen.t04fields3 = "";
            }
        }

        private void TapGestureRecognizer_Tapped_3(object sender, EventArgs e)
        {
            if (Erfassungsbogen.t04fields3 != "4" | Erfassungsbogen.t04fields3 == null)
            {
                t04Images3_4.Source = "ic_rb1.png";
                t04Images3_2.Source = "ic_rb2.png";
                t04Images3_3.Source = "ic_rb2.png";
                t04Images3_1.Source = "ic_rb2.png";
                t04Images3_5.Source = "ic_rb2.png";
                Erfassungsbogen.t04fields3 = "4";
            }
            else
            {
                t04Images3_4.Source = "ic_rb2.png";
                Erfassungsbogen.t04fields3 = "";
            }
        }

        private void TapGestureRecognizer_Tapped_4(object sender, EventArgs e)
        {
            if (Erfassungsbogen.t04fields3 != "5" | Erfassungsbogen.t04fields3 == null)
            {
                t04Images3_5.Source = "ic_rb1.png";
                t04Images3_2.Source = "ic_rb2.png";
                t04Images3_3.Source = "ic_rb2.png";
                t04Images3_4.Source = "ic_rb2.png";
                t04Images3_1.Source = "ic_rb2.png";
                Erfassungsbogen.t04fields3 = "5";
            }
            else
            {
                t04Images3_5.Source = "ic_rb2.png";
                Erfassungsbogen.t04fields3 = "";
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