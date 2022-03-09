using System;
using System.ComponentModel;
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using App6.Management;
using App6.Model;
using App6.Resources;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App6
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Allgemeines_1 : ContentPage, INotifyPropertyChanged
    {
        public bool InitialDataIsEmpty;

        public Allgemeines_1()
        {
            InitializeComponent();
            BindingContext = this;

            BogenLabel.Text = AppResources.SurveyHeadline + " " + DBManagement.getYearCode(App.user.selected_mstr_ebqe) + " " + AppResources.SurveyHeadlineFor + " " + Erfassungsbogen.Bewohnerbezeichnung;

            InitialDataIsEmpty = true;

            t00field04Picker.Items.Add("1");
            t00field04Picker.Items.Add("2");
            t00field04Picker.Items.Add("3");
            t00field04Picker.Items.Add("4");
            t00field04Picker.Items.Add("5");

            t00Picker05.Items.Add("ja");
            t00Picker05.Items.Add("nein");

            t00Picker06.Items.Add("ja");
            t00Picker06.Items.Add("nein");
        }

        //Before page gets loaded this opertion is performed
        protected override async void OnAppearing()
        {
            base.OnAppearing();

            try
            {
                //ActivityIndicator = Loading...
                IsLoading = true;

                //WebRequest req = WebRequest.Create(DBManagement.DBConnection + "tbl_form_ebqe_t00_01_read.php");

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

                //if (split[0] != "" && split[1] != "" && split[2] != "" && split[3] != "" && split[4] != "" && split[5] != "" && split[6] != "")
                //{
                //    InitialDataIsEmpty = false;
                //}

                //Erfassungsbogen.t00field01 = split[0];
                //Erfassungsbogen.t00field02_1 = split[1];
                //Erfassungsbogen.t00field02_2 = split[2];
                //Erfassungsbogen.t00field03 = split[3];
                //Erfassungsbogen.t00field04 = split[4];
                //Erfassungsbogen.t00field05 = split[5];
                //Erfassungsbogen.t00field06 = split[6];

                if (Erfassungsbogen.t00field05 == "1")
                {
                    t00Picker05.SelectedIndex = 0;
                }
                else if (Erfassungsbogen.t00field05 == "0")
                {
                    t00Picker05.SelectedIndex = 1;
                }

                if (Erfassungsbogen.t00field06 == "1")
                {
                    t00Picker06.SelectedIndex = 0;
                }

                else if (Erfassungsbogen.t00field06 == "0")
                {
                    t00Picker06.SelectedIndex = 1;
                }

                if (Erfassungsbogen.t00field04 == "1")
                {
                    t00field04Picker.SelectedIndex = 0;
                }

                else if (Erfassungsbogen.t00field04 == "2")
                {
                    t00field04Picker.SelectedIndex = 1;
                }

                else if (Erfassungsbogen.t00field04 == "3")
                {
                    t00field04Picker.SelectedIndex = 2;
                }

                else if (Erfassungsbogen.t00field04 == "4")
                {
                    t00field04Picker.SelectedIndex = 3;
                }

                else if (Erfassungsbogen.t00field04 == "5")
                {
                    t00field04Picker.SelectedIndex = 4;
                }

                // Getting additional data from bewohner ( date of birth, year, sex, date of care institution entry)

                WebRequest req1 = WebRequest.Create(DBManagement.DBConnection + "tbl_form_ebqe_t00_01_read_4fields.php");

                req1.Method = "POST";
                req1.ContentType = "application/x-www-form-urlencoded";

                string postData1 = "einrichtung=" + App.user.id_org_einrichtung + "&wohnbereich=" + App.user.id_org_wohnbereich + "&bewonerid=" + App.user.selected_id_bewohner;
                byte[] byteArray1 = Encoding.UTF8.GetBytes(postData1);

                req1.ContentLength = byteArray1.Length;

                Stream ds1 = req1.GetRequestStream();
                await ds1.WriteAsync(byteArray1, 0, byteArray1.Length);
                ds1.Close();

                WebResponse response1 = await req1.GetResponseAsync();

                Stream dataStream1 = response1.GetResponseStream();

                StreamReader reader1 = new StreamReader(dataStream1);

                string s1 = await reader1.ReadToEndAsync();

                string[] split1 = s1.Split(new char[] { ':' });

                if (split1[0] != "" && split1[1] != "" && split1[2] != "" && split1[3] != "")
                {
                    InitialDataIsEmpty = false;
                }

                Erfassungsbogen.t00field01 = split1[0];
                Erfassungsbogen.t00field02_1 = split1[1];
                Erfassungsbogen.t00field02_2 = split1[2];
                Erfassungsbogen.t00field03 = split1[3];
                
                //ActivityIndicator = Idle
                IsLoading = false;

            }
            catch (Exception)
            {
                await DisplayAlert(AppResources.AppError, AppResources.AppErrorMsg, "OK");
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
                        t00field04.TextColor = t00field05.TextColor = t00field06.TextColor = AppManager.QuestionColor;

                        if ((Erfassungsbogen.t00field01 != "" && Erfassungsbogen.t00field01 != null) && (Erfassungsbogen.t00field02_1 != "" && Erfassungsbogen.t00field02_1 != null) && (Erfassungsbogen.t00field02_2 != "" && Erfassungsbogen.t00field02_2 != null) && (Erfassungsbogen.t00field03 != "" && Erfassungsbogen.t00field03 != null) && (Erfassungsbogen.t00field04 != "" && Erfassungsbogen.t00field04 != null) && (Erfassungsbogen.t00field05 != "" && Erfassungsbogen.t00field05 != null) && (Erfassungsbogen.t00field06 != "" && Erfassungsbogen.t00field06 != null))
                        {
                            if (App.user.selected_mstr_ebqe == DBManagement.CurrentEvaluationID)
                            {
                                WebRequest req = WebRequest.Create(DBManagement.DBConnection + "tbl_form_ebqe_t00_01_update.php");

                                req.Method = "POST"; //POST
                                req.Timeout = 15000;
                                req.ContentType = "application/x-www-form-urlencoded";

                                string postData = "mstr=" + App.user.selected_mstr_ebqe + "&bewonerid=" + App.user.selected_id_bewohner + "&t00field01=" + Erfassungsbogen.t00field01 + "&t00field02_1=" + Erfassungsbogen.t00field02_1 + "&t00field02_2=" + Erfassungsbogen.t00field02_2 + "&t00field03=" + Erfassungsbogen.t00field03 + "&t00field04=" + Erfassungsbogen.t00field04 + "&t00field05=" + Erfassungsbogen.t00field05 + "&t00field06=" + Erfassungsbogen.t00field06;

                                byte[] byteArray = Encoding.UTF8.GetBytes(postData);

                                req.ContentLength = byteArray.Length;

                                Stream ds = await req.GetRequestStreamAsync();
                                await ds.WriteAsync(byteArray, 0, byteArray.Length);
                                ds.Close();
                            }

                            await Navigation.PushAsync(new SearchPage());
                        }
                        else
                        {
                            if (Erfassungsbogen.t00field04 == "" || Erfassungsbogen.t00field04 == null)
                            {
                                t00field04.TextColor = Color.Red;
                            }
                            if (Erfassungsbogen.t00field05 == "" || Erfassungsbogen.t00field05 == null)
                            {
                                t00field05.TextColor = Color.Red;
                            }
                            if (Erfassungsbogen.t00field06 == "" || Erfassungsbogen.t00field06 == null)
                            {
                                t00field06.TextColor = Color.Red;
                            }

                            await DisplayAlert(AppResources.Warning, AppResources.FieldsUnfilled, "OK");
                            BackButton.Source = "ic_arrow_back_ios.png";
                        }
                    }
                    else
                    {
                        Erfassungsbogen.t00field01 = Erfassungsbogen.t00field02_1 = Erfassungsbogen.t00field02_2 = Erfassungsbogen.t00field03 = Erfassungsbogen.t00field04 = Erfassungsbogen.t00field05 = Erfassungsbogen.t00field06 = "";

                        WebRequest req = WebRequest.Create(DBManagement.DBConnection + "tbl_form_ebqe_t00_01_update.php");

                        req.Method = "POST"; //POST
                        req.Timeout = 15000;
                        req.ContentType = "application/x-www-form-urlencoded";

                        string postData = "mstr=" + App.user.selected_mstr_ebqe + "&bewonerid=" + App.user.selected_id_bewohner + "&t00field01=" + Erfassungsbogen.t00field01 + "&t00field02_1=" + Erfassungsbogen.t00field02_1 + "&t00field02_2=" + Erfassungsbogen.t00field02_2 + "&t00field03=" + Erfassungsbogen.t00field03 + "&t00field04=" + Erfassungsbogen.t00field04 + "&t00field05=" + Erfassungsbogen.t00field05 + "&t00field06=" + Erfassungsbogen.t00field06;

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
                    await Navigation.PushAsync(new Allgemeines_2());
                }
                else
                {
                    t00field04.TextColor = t00field05.TextColor = t00field06.TextColor = AppManager.QuestionColor;

                    if ((Erfassungsbogen.t00field01 != "" && Erfassungsbogen.t00field01 != null) && (Erfassungsbogen.t00field02_1 != "" && Erfassungsbogen.t00field02_1 != null) && (Erfassungsbogen.t00field02_2 != "" && Erfassungsbogen.t00field02_2 != null) && (Erfassungsbogen.t00field03 != "" && Erfassungsbogen.t00field03 != null) && (Erfassungsbogen.t00field04 != "" && Erfassungsbogen.t00field04 != null) && (Erfassungsbogen.t00field05 != "" && Erfassungsbogen.t00field05 != null) && (Erfassungsbogen.t00field06 != "" && Erfassungsbogen.t00field06 != null))
                    {
                        if (App.user.selected_mstr_ebqe == DBManagement.CurrentEvaluationID)
                        {
                            WebRequest req = WebRequest.Create(DBManagement.DBConnection + "tbl_form_ebqe_t00_01_update.php");

                            req.Method = "POST"; //POST
                            req.Timeout = 15000;
                            req.ContentType = "application/x-www-form-urlencoded";

                            string postData = "mstr=" + App.user.selected_mstr_ebqe + "&bewonerid=" + App.user.selected_id_bewohner + "&t00field01=" + Erfassungsbogen.t00field01 + "&t00field02_1=" + Erfassungsbogen.t00field02_1 + "&t00field02_2=" + Erfassungsbogen.t00field02_2 + "&t00field03=" + Erfassungsbogen.t00field03 + "&t00field04=" + Erfassungsbogen.t00field04 + "&t00field05=" + Erfassungsbogen.t00field05 + "&t00field06=" + Erfassungsbogen.t00field06;

                            byte[] byteArray = Encoding.UTF8.GetBytes(postData);

                            req.ContentLength = byteArray.Length;

                            Stream ds = await req.GetRequestStreamAsync();
                            await ds.WriteAsync(byteArray, 0, byteArray.Length);
                            ds.Close();
                        }

                        await Navigation.PushAsync(new Allgemeines_2());
                    }
                    else
                    {
                        if (Erfassungsbogen.t00field04 == "" || Erfassungsbogen.t00field04 == null)
                        {
                            t00field04.TextColor = Color.Red;
                        }
                        if (Erfassungsbogen.t00field05 == "" || Erfassungsbogen.t00field05 == null)
                        {
                            t00field05.TextColor = Color.Red;
                        }
                        if (Erfassungsbogen.t00field06 == "" || Erfassungsbogen.t00field06 == null)
                        {
                            t00field06.TextColor = Color.Red;
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

        private void T00Picker04_SelectedIndexChanged(object sender, EventArgs e)
        {
            // picker T00 04
            if (t00field04Picker.SelectedIndex == 0)
            {
                Erfassungsbogen.t00field04 = "1";
            }
            else if (t00field04Picker.SelectedIndex == 1)
            {
                Erfassungsbogen.t00field04 = "2";
            }
            else if (t00field04Picker.SelectedIndex == 2)
            {
                Erfassungsbogen.t00field04 = "3";
            }
            else if (t00field04Picker.SelectedIndex == 3)
            {
                Erfassungsbogen.t00field04 = "4";
            }
            else if (t00field04Picker.SelectedIndex == 4)
            {
                Erfassungsbogen.t00field04 = "5";
            }
        }

        private void T00Picker05_SelectedIndexChanged(object sender, EventArgs e)
        {
            // T00 05
            if (t00Picker05.SelectedIndex == 0)
            {
                Erfassungsbogen.t00field05 = "1";
            }
            else if (t00Picker05.SelectedIndex == 1)
            {
                Erfassungsbogen.t00field05 = "0";
            }
        }

        private void T00Picker06_SelectedIndexChanged(object sender, EventArgs e)
        {
            //T00 06

            if (t00Picker06.SelectedIndex == 0)
            {
                Erfassungsbogen.t00field06 = "1";
            }
            else if (t00Picker06.SelectedIndex == 1)
            {
                Erfassungsbogen.t00field06 = "0";
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