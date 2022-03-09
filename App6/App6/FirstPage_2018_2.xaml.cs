using System;
using System.IO;
using System.Net;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using App6.Management;
using System.ComponentModel;
using App6.Resources;
using App6.Model;
using System.Linq;

namespace App6
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FirstPage_2018_2 : ContentPage, INotifyPropertyChanged
    {
        public FirstPage_2018_2()
        {
            InitializeComponent();
        }

        //Before page gets loaded this opertion is performed
        protected override async void OnAppearing()
        {
            base.OnAppearing();

            try
            {
                //ActivityIndicator = Loading...
                IsLoading = true;

                App.user.selected_mstr_ebqe = 12;

                //Get Open Survey Count
                WebRequest req = WebRequest.Create(DBManagement.DBConnection + "inqs_db_getBewohnerCountOpen.php");

                req.Method = "POST";
                req.Timeout = 15000;
                req.ContentType = "application/x-www-form-urlencoded";

                string postData = "id_mstr_ebqe=" + App.user.selected_mstr_ebqe + "&ein=" + App.user.id_org_einrichtung + "&wohn=" + App.user.id_org_wohnbereich;
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

                for (int i = 0; i < split.Length - 1; i++)
                {
                    OpenSurveyCount.Text = split[0];
                }

                //Get Finished Survey Patient ID List
                PatientManager.PatientListCompleted.Clear();

                WebRequest reqFinished = WebRequest.Create(DBManagement.DBConnection + "inqs_db_getBewohnerFinished.php");

                reqFinished.Method = "POST";
                reqFinished.ContentType = "application/x-www-form-urlencoded";

                string postDataFinished = "id_mstr_ebqe=" + App.user.selected_mstr_ebqe + "&ein=" + App.user.id_org_einrichtung + "&wohn=" + App.user.id_org_wohnbereich;
                byte[] byteArrayFinished = Encoding.UTF8.GetBytes(postDataFinished);

                reqFinished.ContentLength = byteArrayFinished.Length;

                Stream dsFinished = reqFinished.GetRequestStream();
                await dsFinished.WriteAsync(byteArrayFinished, 0, byteArrayFinished.Length);
                dsFinished.Close();

                WebResponse responseFinished = await reqFinished.GetResponseAsync();

                Stream dataStreamFinished = responseFinished.GetResponseStream();

                StreamReader readerFinished = new StreamReader(dataStreamFinished);

                string sFinished = await readerFinished.ReadToEndAsync();

                string[] splitFinished = sFinished.Split(new char[] { '|' });

                for (int j = 0; j < splitFinished.Length; j++)
                {
                    if (splitFinished[j] == "")
                    {
                        break;
                    }

                    string[] splitIn = splitFinished[j].Split(new char[] { ':' });

                    if (!PatientManager.PatientListCompleted.Any(a => a.id == Convert.ToInt32(splitIn[2])))
                    {
                        PatientManager.PatientListCompleted.Add(new Patient { id = Convert.ToInt32(splitIn[2]) });
                    }
                }

                FinishedSurveyCount.Text = PatientManager.PatientListCompleted.Count.ToString();

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
            Navigation.PushAsync(new FirstPage_2018_1());
        }

        private void TapGestureRecognizer_Tapped_6(object sender, EventArgs e)
        {
            Navigation.PushAsync(new FirstPage_2019_1());
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ListOfPatients());
        }

        private void TapGestureRecognizer_Tapped_1(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ListOfPatients());
        }

        private void TapGestureRecognizer_Tapped_2(object sender, EventArgs e)
        {
            DisplayAlert("Abmeldung", "Sie sind erfolgreich abgemeldet", "ok");
            Navigation.PushAsync(new MainPage());
        }

        private void TapGestureRecognizer_Tapped_3(object sender, EventArgs e)
        {
            Navigation.PushAsync(new HomePage());
        }

        private void TapGestureRecognizer_Tapped_4(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Indikatoren1());
        }

        private void TapGestureRecognizer_Tapped_5(object sender, EventArgs e)
        {
            Navigation.PushAsync(new FirstPage_2019_2());
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