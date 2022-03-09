using App6.Management;
using App6.Resources;
using System;
using System.IO;
using System.Net;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.ComponentModel;

namespace App6
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage, INotifyPropertyChanged
    {
        public LoginPage()
        {
            InitializeComponent();
            BindingContext = this;

        }

        private async void Button_Login_Clicked(object sender, EventArgs e)
        {
            try
            {
                //ActivityIndicator = Loading...
                IsLoading = true;

                string username = user.Text;
                string password = pass.Text;

                //if (username == "")
                //{
                //    username = "sabinesellner";
                //    password = "Sabinesellner@12";
                //}

                if (username == "")
                {
                    username = "musterwohnheim1";
                    password = "1musterwohnheim12@";
                }

                var passwordEncrypted = Cipher.Encrypt(password, "yIIIfmxqHDdWXxmr13Na");

                WebRequest req = WebRequest.Create(DBManagement.DBConnection + "inqs_db_login.php");

                req.Method = "POST";
                req.Timeout = 15000;
                req.ContentType = "application/x-www-form-urlencoded";

                string postData = "username=" + username + "&password=" + passwordEncrypted;
                byte[] byteArray = Encoding.UTF8.GetBytes(postData);

                req.ContentLength = byteArray.Length;

                Stream ds = await req.GetRequestStreamAsync();
                await ds.WriteAsync(byteArray, 0, byteArray.Length);
                ds.Close();

                WebResponse response = await req.GetResponseAsync();

                Stream dataStream = response.GetResponseStream();

                StreamReader reader = new StreamReader(dataStream);

                string s = await reader.ReadToEndAsync();

                if (s != "")
                {
                    string[] split = s.Split(new char[] { ':' });

                    App.user.id_org_einrichtung = Convert.ToInt32(split[0]);
                    App.user.id_org_wohnbereich = Convert.ToInt32(split[1]);
                    App.user.benutzer_gruppe = Convert.ToInt32(split[2]);
                    App.user.id_benutzer = Convert.ToInt32(split[3]);

                    //Check AppVersion
                    WebRequest reqAppVersionCheck = WebRequest.Create(DBManagement.DBConnection + "inqs_db_appVersionCheck.php");

                    reqAppVersionCheck.Method = "POST";
                    reqAppVersionCheck.ContentType = "application/x-www-form-urlencoded";

                    string postDataAppVersionCheck = "";
                    byte[] byteArrayAppVersionCheck = Encoding.UTF8.GetBytes(postDataAppVersionCheck);

                    reqAppVersionCheck.ContentLength = byteArrayAppVersionCheck.Length;

                    Stream dsAppVersionCheck = await reqAppVersionCheck.GetRequestStreamAsync();
                    await dsAppVersionCheck.WriteAsync(byteArrayAppVersionCheck, 0, byteArrayAppVersionCheck.Length);
                    dsAppVersionCheck.Close();

                    WebResponse responseAppVersionCheck = await reqAppVersionCheck.GetResponseAsync();

                    Stream dataStreamAppVersionCheck = responseAppVersionCheck.GetResponseStream();

                    StreamReader readerAppVersionCheck = new StreamReader(dataStreamAppVersionCheck);

                    string sAppVersionCheck = await readerAppVersionCheck.ReadToEndAsync();

                    if (sAppVersionCheck == DBManagement.AppVersion)
                    {
                        //Login Successful PopUp
                        //await DisplayAlert(AppResources.LoginPageHeadline, AppResources.LoginSuccess, "OK");

                        await Navigation.PushAsync(new FirstPage_2019_2());
                    }
                    else
                    {
                        //Login Failed Wrong Version PopUp
                        await DisplayAlert(AppResources.LoginPageHeadline, AppResources.LoginWrongAppVersion, "OK");
                    }
                }
                else
                {
                    //Login Failed PopUp
                    await DisplayAlert(AppResources.LoginPageHeadline, AppResources.LoginFailed, "OK");
                }

                //Login Not Yet Available PopUp
                //await DisplayAlert(AppResources.LoginPageHeadline, AppResources.LoginNotYetAvailable, "OK");
                
                //ActivityIndicator = Idle
                IsLoading = false;

            }
            catch (Exception)
            {
                await DisplayAlert(AppResources.AppError, AppResources.AppErrorMsg, "OK");
            }
        }

        private async void Button_Register_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new RegisterPage());
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
    
