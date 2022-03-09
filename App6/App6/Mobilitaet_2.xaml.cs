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
    public partial class Mobilitaet_2 : ContentPage, INotifyPropertyChanged
    {
        public bool InitialDataIsEmpty;

        public Mobilitaet_2()
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
                    await Navigation.PushAsync(new Mobilitaet_1());
                }
                else
                {
                    var BackQuestion = await DisplayAlert(AppResources.Information, AppResources.InformationSaveQuery, AppResources.Yes, AppResources.No);
                    if (BackQuestion == true)
                    {
                        t01field03.TextColor = t01field04.TextColor = AppManager.QuestionColor;

                        if ((Erfassungsbogen.t01field03 != "" && Erfassungsbogen.t01field03 != null) && (Erfassungsbogen.t01field04 != "" && Erfassungsbogen.t01field04 != null))
                        {
                            WebRequest req = WebRequest.Create(DBManagement.DBConnection + "tbl_form_ebqe_t01_02_update.php");

                            req.Method = "POST"; //POST
                            req.Timeout = 15000;
                            req.ContentType = "application/x-www-form-urlencoded";

                            string postData = "mstr=" + App.user.selected_mstr_ebqe + "&bewonerid=" + App.user.selected_id_bewohner + "&t01field03=" + Erfassungsbogen.t01field03 + "&t01field04=" + Erfassungsbogen.t01field04;

                            byte[] byteArray = Encoding.UTF8.GetBytes(postData);

                            req.ContentLength = byteArray.Length;

                            Stream ds = await req.GetRequestStreamAsync();
                            await ds.WriteAsync(byteArray, 0, byteArray.Length);
                            ds.Close();

                            await Navigation.PushAsync(new Mobilitaet_1());
                        }
                        else
                        {
                            if (Erfassungsbogen.t01field03 == "" || Erfassungsbogen.t01field03 == null)
                            {
                                t01field03.TextColor = Color.Red;
                            }
                            if (Erfassungsbogen.t01field04 == "" || Erfassungsbogen.t01field04 == null)
                            {
                                t01field04.TextColor = Color.Red;
                            }
                            await DisplayAlert(AppResources.Warning, AppResources.FieldsUnfilled, "OK");
                            BackButton.Source = "ic_arrow_back_ios.png";
                        }
                    }
                    else
                    {
                        Erfassungsbogen.t01field03 = Erfassungsbogen.t01field04 = "";

                        WebRequest req = WebRequest.Create(DBManagement.DBConnection + "tbl_form_ebqe_t01_02_update.php");

                        req.Method = "POST"; //POST
                        req.Timeout = 15000;
                        req.ContentType = "application/x-www-form-urlencoded";

                        string postData = "mstr=" + App.user.selected_mstr_ebqe + "&bewonerid=" + App.user.selected_id_bewohner + "&t01field03=" + Erfassungsbogen.t01field03 + "&t01field04=" + Erfassungsbogen.t01field04;

                        byte[] byteArray = Encoding.UTF8.GetBytes(postData);

                        req.ContentLength = byteArray.Length;

                        Stream ds = await req.GetRequestStreamAsync();
                        await ds.WriteAsync(byteArray, 0, byteArray.Length);
                        ds.Close();

                        await Navigation.PushAsync(new Mobilitaet_1());
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
                    await Navigation.PushAsync(new Mobilitaet_3());
                }
                else
                {
                    t01field03.TextColor = t01field04.TextColor = AppManager.QuestionColor;

                    if ((Erfassungsbogen.t01field03 != "" && Erfassungsbogen.t01field03 != null) && (Erfassungsbogen.t01field04 != "" && Erfassungsbogen.t01field04 != null))
                    {
                        WebRequest req = WebRequest.Create(DBManagement.DBConnection + "tbl_form_ebqe_t01_02_update.php");

                        req.Method = "POST"; //POST
                        req.Timeout = 15000;
                        req.ContentType = "application/x-www-form-urlencoded";

                        string postData = "mstr=" + App.user.selected_mstr_ebqe + "&bewonerid=" + App.user.selected_id_bewohner + "&t01field03=" + Erfassungsbogen.t01field03 + "&t01field04=" + Erfassungsbogen.t01field04;

                        byte[] byteArray = Encoding.UTF8.GetBytes(postData);

                        req.ContentLength = byteArray.Length;

                        Stream ds = await req.GetRequestStreamAsync();
                        await ds.WriteAsync(byteArray, 0, byteArray.Length);
                        ds.Close();

                        await Navigation.PushAsync(new Mobilitaet_3());
                    }
                    else
                    {
                        if (Erfassungsbogen.t01field03 == "" || Erfassungsbogen.t01field03 == null)
                        {
                            t01field03.TextColor = Color.Red;
                        }
                        if (Erfassungsbogen.t01field04 == "" || Erfassungsbogen.t01field04 == null)
                        {
                            t01field04.TextColor = Color.Red;
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

        //Before page gets loaded this opertion is performed
        protected override async void OnAppearing()
        {
            base.OnAppearing();

            try
            {
                //ActivityIndicator = Loading...
                IsLoading = true;

                //WebRequest req = WebRequest.Create(DBManagement.DBConnection + "tbl_form_ebqe_t01_02_read.php");

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

                //if (split[0] != "" && split[1] != "")
                //{
                //    InitialDataIsEmpty = false;
                //}

                //Erfassungsbogen.t01field03 = split[0];
                //Erfassungsbogen.t01field04 = split[1];                              // data from Database tbl_02 is stored

                if (Erfassungsbogen.t01field03 == "0")
                {
                    t01Image03_1.Source = "ic_rb1.png";                            // rb1 is the image file with checked box image
                }
                else if (Erfassungsbogen.t01field03 == "1")
                {
                    t01Image03_2.Source = "ic_rb1.png";
                }
                else if (Erfassungsbogen.t01field03 == "2")
                {
                    t01Image03_3.Source = "ic_rb1.png";
                }
                else if (Erfassungsbogen.t01field03 == "3")
                {
                    t01Image03_4.Source = "ic_rb1.png";
                }
                else
                {
                    t01Image03_1.Source = "ic_rb2.png";
                    t01Image03_2.Source = "ic_rb2.png";
                    t01Image03_3.Source = "ic_rb2.png";
                    t01Image03_4.Source = "ic_rb2.png";
                }

                if (Erfassungsbogen.t01field04 == "0")
                {
                    t01Image04_1.Source = "ic_rb1.png";                            // rb1 is the image file with checked box image
                }
                else if (Erfassungsbogen.t01field04 == "1")
                {
                    t01Image04_2.Source = "ic_rb1.png";
                }
                else if (Erfassungsbogen.t01field04 == "2")
                {
                    t01Image04_3.Source = "ic_rb1.png";
                }
                else if (Erfassungsbogen.t01field04 == "3")
                {
                    t01Image04_4.Source = "ic_rb1.png";
                }
                else
                {
                    t01Image04_1.Source = "ic_rb2.png";
                    t01Image04_2.Source = "ic_rb2.png";
                    t01Image04_3.Source = "ic_rb2.png";
                    t01Image04_4.Source = "ic_rb2.png";
                }
                //ActivityIndicator = Idle
                IsLoading = false;

            }
            catch (Exception)
            {
                await DisplayAlert(AppResources.AppError, AppResources.AppErrorMsg, "OK");
            }
        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            if (Erfassungsbogen.t01field03 != "0" | Erfassungsbogen.t01field03 == null)
            {
                t01Image03_1.Source = "ic_rb1.png";
                t01Image03_2.Source = "ic_rb2.png";
                t01Image03_3.Source = "ic_rb2.png";
                t01Image03_4.Source = "ic_rb2.png";
                Erfassungsbogen.t01field03 = "0";
            }
            else
            {
                t01Image03_1.Source = "ic_rb2.png";
                Erfassungsbogen.t01field03 = "";
            }
        }

        private void TapGestureRecognizer_Tapped_1(object sender, EventArgs e)
        {

            if (Erfassungsbogen.t01field03 != "1" | Erfassungsbogen.t01field03 == null)
            {
                t01Image03_2.Source = "ic_rb1.png";
                t01Image03_1.Source = "ic_rb2.png";
                t01Image03_3.Source = "ic_rb2.png";
                t01Image03_4.Source = "ic_rb2.png";
                Erfassungsbogen.t01field03 = "1";
            }
            else
            {
                t01Image03_2.Source = "ic_rb2.png";
                Erfassungsbogen.t01field03 = "";
            }
        }

        private void TapGestureRecognizer_Tapped_2(object sender, EventArgs e)
        {
            if (Erfassungsbogen.t01field03 != "2" | Erfassungsbogen.t01field03 == null)
            {
                t01Image03_3.Source = "ic_rb1.png";
                t01Image03_4.Source = "ic_rb2.png";
                t01Image03_2.Source = "ic_rb2.png";
                t01Image03_1.Source = "ic_rb2.png";
                Erfassungsbogen.t01field03 = "2";
            }
            else
            {
                t01Image03_3.Source = "ic_rb2.png";
                Erfassungsbogen.t01field03 = "";
            }
        }

        private void TapGestureRecognizer_Tapped_3(object sender, EventArgs e)
        {
            if (Erfassungsbogen.t01field03 != "3" | Erfassungsbogen.t01field03 == null)
            {
                t01Image03_4.Source = "ic_rb1.png";
                t01Image03_1.Source = "ic_rb2.png";
                t01Image03_2.Source = "ic_rb2.png";
                t01Image03_3.Source = "ic_rb2.png";
                Erfassungsbogen.t01field03 = "3";
            }
            else
            {
                t01Image03_4.Source = "ic_rb2.png";
                Erfassungsbogen.t01field03 = "";
            }
        }

        private void TapGestureRecognizer_Tapped_4(object sender, EventArgs e)
        {
            if (Erfassungsbogen.t01field04 != "0" | Erfassungsbogen.t01field04 == null)
            {
                t01Image04_1.Source = "ic_rb1.png";
                t01Image04_2.Source = "ic_rb2.png";
                t01Image04_3.Source = "ic_rb2.png";
                t01Image04_4.Source = "ic_rb2.png";
                Erfassungsbogen.t01field04 = "0";
            }
            else
            {
                t01Image04_1.Source = "ic_rb2.png";
                Erfassungsbogen.t01field04 = "";
            }
        }

        private void TapGestureRecognizer_Tapped_5(object sender, EventArgs e)
        {
            if (Erfassungsbogen.t01field04 != "1" | Erfassungsbogen.t01field04 == null)
            {
                t01Image04_2.Source = "ic_rb1.png";
                t01Image04_1.Source = "ic_rb2.png";
                t01Image04_3.Source = "ic_rb2.png";
                t01Image04_4.Source = "ic_rb2.png";
                Erfassungsbogen.t01field04 = "1";
            }
            else
            {
                t01Image04_2.Source = "ic_rb2.png";
                Erfassungsbogen.t01field04 = "";
            }
        }

        private void TapGestureRecognizer_Tapped_6(object sender, EventArgs e)
        {
            if (Erfassungsbogen.t01field04 != "2" | Erfassungsbogen.t01field04 == null)
            {
                t01Image04_3.Source = "ic_rb1.png";
                t01Image04_2.Source = "ic_rb2.png";
                t01Image04_1.Source = "ic_rb2.png";
                t01Image04_4.Source = "ic_rb2.png";
                Erfassungsbogen.t01field04 = "2";
            }
            else
            {
                t01Image04_3.Source = "ic_rb2.png";
                Erfassungsbogen.t01field04 = "";
            }
        }

        private void TapGestureRecognizer_Tapped_7(object sender, EventArgs e)
        {
            if (Erfassungsbogen.t01field04 != "3" | Erfassungsbogen.t01field04 == null)
            {
                t01Image04_4.Source = "ic_rb1.png";
                t01Image04_2.Source = "ic_rb2.png";
                t01Image04_3.Source = "ic_rb2.png";
                t01Image04_1.Source = "ic_rb2.png";
                Erfassungsbogen.t01field04 = "3";
            }
            else
            {
                t01Image04_4.Source = "ic_rb2.png";
                Erfassungsbogen.t01field04 = "";
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