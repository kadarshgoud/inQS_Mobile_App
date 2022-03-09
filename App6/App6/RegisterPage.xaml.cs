using App6.Management;
using App6.Resources;
using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.ComponentModel;

namespace App6
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class RegisterPage : ContentPage, INotifyPropertyChanged
	{
        bool role_button_1, role_button_2, role_button_3, role_button_4;

        public RegisterPage ()
		{
			InitializeComponent ();

            role_button_1 = false;
            role_button_2 = false;
            role_button_3 = false;
            role_button_4 = false;

        }

        private async void Button_Register_Clicked(object sender, EventArgs e)
        {
            try
{
//ActivityIndicator = Loading...
IsLoading = true;

                string username = user.Text;
                string password = pass.Text;
                string passwordConfirm = passConfirm.Text;

                if (username == null | password == null | passwordConfirm == null)
                {
                    await DisplayAlert(AppResources.RegisterFailed, AppResources.RegisterEmptyFields, "OK");
                    return;
                }

                //Password Length?
                if (password.Length < 6)
                {
                    await DisplayAlert(AppResources.Error, AppResources.PasswordShort, "OK");
                }
                else
                {
                    bool result = IsValidPassword(password);
                    if (!result)
                    {
                        await DisplayAlert(AppResources.Error, AppResources.PasswordLowComplexity, "OK");
                    }
                    else
                    {
                        //Password match?
                        if (password != passwordConfirm)
                        {
                            await DisplayAlert(AppResources.Error, AppResources.PasswordNoMatch, "OK");
                        }
                        else
                        {
                            //Username not in use confirmation
                            WebRequest req = WebRequest.Create(DBManagement.DBConnection + "inqs_db_usernameFreeCheck.php");

                            req.Method = "POST";
                            req.ContentType = "application/x-www-form-urlencoded";

                            string postData = "username=" + username;
                            byte[] byteArray = Encoding.UTF8.GetBytes(postData);

                            req.ContentLength = byteArray.Length;

                            Stream ds = await req.GetRequestStreamAsync();
                            await ds.WriteAsync(byteArray, 0, byteArray.Length);
                            ds.Close();

                            WebResponse response = await req.GetResponseAsync();

                            Stream dataStream = response.GetResponseStream();

                            StreamReader reader = new StreamReader(dataStream);

                            string s = reader.ReadToEnd();

                            //Username is free
                            if (s == "")
                            {
                                int RoleValue = 0;

                                if (role_button_1 == false && role_button_2 == false && role_button_3 == false && role_button_4 == false)
                                {
                                    await DisplayAlert(AppResources.RegisterFailed, AppResources.RegisterSelectRole, "OK");
                                    return;
                                }

                                if (role_button_1 == true && role_button_2 == false && role_button_3 == false && role_button_4 == false)
                                {
                                    RoleValue = 1;
                                }
                                if (role_button_1 == false && role_button_2 == true && role_button_3 == false && role_button_4 == false)
                                {
                                    RoleValue = 2;
                                }
                                if (role_button_1 == false && role_button_2 == false && role_button_3 == true && role_button_4 == false)
                                {
                                    RoleValue = 3;
                                }

                                //Admin Registration
                                //if (role_button_1 == false && role_button_2 == false && role_button_3 == false && role_button_4 == true)
                                //{
                                //    RoleValue = 4;
                                //}

                                if (RoleValue != 0)
                                {
                                    WebRequest reqValidinQSUser = WebRequest.Create(DBManagement.DBConnection + "inqs_db_usernameValidUserCheck.php");

                                    reqValidinQSUser.Method = "POST";
                                    reqValidinQSUser.ContentType = "application/x-www-form-urlencoded";

                                    string postDataValidinQSUser = "username=" + username;
                                    byte[] byteArrayValidinQSUser = Encoding.UTF8.GetBytes(postData);

                                    reqValidinQSUser.ContentLength = byteArrayValidinQSUser.Length;

                                    Stream dsValidinQSUser = reqValidinQSUser.GetRequestStream();
                                    dsValidinQSUser.Write(byteArrayValidinQSUser, 0, byteArrayValidinQSUser.Length);
                                    dsValidinQSUser.Close();

                                    WebResponse responseValidinQSUser = reqValidinQSUser.GetResponse();

                                    Stream dataStreamValidinQSUser = responseValidinQSUser.GetResponseStream();

                                    StreamReader readerValidinQSUser = new StreamReader(dataStreamValidinQSUser);

                                    string sValidinQSUser = readerValidinQSUser.ReadToEnd();

                                    int einrichtungID = 0;
                                    int wohnbereichID = 0;
                                    int orgaBenutzerID = 0;
                                    int benutzerID = 0;

                                    if (sValidinQSUser != "")
                                    {
                                        string[] split = sValidinQSUser.Split(new char[] { ':' });

                                        einrichtungID = Convert.ToInt32(split[0]);
                                        wohnbereichID = Convert.ToInt32(split[1]);
                                        orgaBenutzerID = Convert.ToInt32(split[2]);
                                        benutzerID = Convert.ToInt32(split[3]);

                                        if (einrichtungID != 0 && wohnbereichID != 0 && orgaBenutzerID != 0 && benutzerID != 0 && RoleValue == orgaBenutzerID)
                                        {
                                            //Insert Credentials
                                            var passwordEncrypted = Cipher.Encrypt(password, "yIIIfmxqHDdWXxmr13Na");
                                            //var strDecrypted = Cipher.Decrypt(passwordEncrypted, "yIIIfmxqHDdWXxmr13Na");

                                            WebRequest reqInsertUserCredentials = WebRequest.Create(DBManagement.DBConnection + "inqs_db_insertUserCredentials.php");

                                            reqInsertUserCredentials.Method = "POST"; //POST 
                                            reqInsertUserCredentials.ContentType = "application/x-www-form-urlencoded";

                                            string postDataInsertUserCredentials = "id_orga_Einrichtung=" + einrichtungID + "&id_orga_wohnbereich=" + wohnbereichID + "&username=" + username + "&password=" + passwordEncrypted + "&id_orga_benutzer_gruppe=" + RoleValue + "&id_benutzer=" + benutzerID;

                                            byte[] byteArrayInsertUserCredentials = Encoding.UTF8.GetBytes(postDataInsertUserCredentials);

                                            reqInsertUserCredentials.ContentLength = byteArrayInsertUserCredentials.Length;

                                            Stream dsInsertUserCredentials = reqInsertUserCredentials.GetRequestStream();
                                            dsInsertUserCredentials.Write(byteArrayInsertUserCredentials, 0, byteArrayInsertUserCredentials.Length);
                                            dsInsertUserCredentials.Close();

                                            if (RoleValue == 1)
                                            {
                                                await DisplayAlert(AppResources.RegisterSuccess, AppResources.RegisterSuccessTextRoleOne, "OK");
                                                await Navigation.PushAsync(new LoginPage());
                                            }
                                            if (RoleValue == 2)
                                            {
                                                await DisplayAlert(AppResources.RegisterSuccess, AppResources.RegisterSuccessTextRoleTwo, "OK");
                                                await Navigation.PushAsync(new LoginPage());
                                            }
                                            if (RoleValue == 3)
                                            {
                                                await DisplayAlert(AppResources.RegisterSuccess, AppResources.RegisterSuccessTextRoleThree, "OK");
                                                await Navigation.PushAsync(new LoginPage());
                                            }

                                            //Admin Registration
                                            //if (RoleValue == 4)
                                            //{
                                            //    await DisplayAlert(AppResources.RegisterSuccess, AppResources.RegisterSuccessTextRoleFour, "OK");
                                            //    await Navigation.PushAsync(new LoginPage());
                                            //}
                                        }
                                        else
                                        {
                                            //Role Number is not 
                                            if (RoleValue != orgaBenutzerID)
                                            {
                                                //Registration Failed PopUp Wrong Role
                                                await DisplayAlert(AppResources.Error, AppResources.RegisterWrongRole, "OK");
                                                return;
                                            }
                                            //Registration Failed Ids do not match
                                            await DisplayAlert(AppResources.Error, AppResources.RegisterContactDBFailure, "OK");

                                        }
                                    }
                                    else
                                    {
                                        //Registration Failed PopUp Unknown inQS User
                                        await DisplayAlert(AppResources.Error, AppResources.RegisterUnknownInQSUser, "OK");
                                        return;
                                    }
                                }
                            }
                            else
                            {
                                //Registration Failed PopUp
                                await DisplayAlert(AppResources.Error, AppResources.UsernameTaken, "OK");
                                return;
                            }
                        }
                    }
                }
                //ActivityIndicator = Idle
IsLoading = false;
            
}
            catch (Exception)
            {
                await DisplayAlert(AppResources.AppError, AppResources.AppErrorMsg, "OK");
            }   
        }

        //rb1 = selected radio button
        //rb2 = unselected radio button

        private void TapGestureRecognizer_Role_1_Tapped(object sender, EventArgs e)
        {
            RoleButton_1.Source = "ic_rb1.png";
            RoleButton_2.Source = "ic_rb2.png";
            RoleButton_3.Source = "ic_rb2.png";
            //RoleButton_4.Source = "ic_rb2.png";
            role_button_1 = true;
            role_button_2 = false;
            role_button_3 = false;
            role_button_4 = false;
        }

        private void TapGestureRecognizer_Role_2_Tapped(object sender, EventArgs e)
        {
            RoleButton_1.Source = "ic_rb2.png";
            RoleButton_2.Source = "ic_rb1.png";
            RoleButton_3.Source = "ic_rb2.png";
            //RoleButton_4.Source = "ic_rb2.png";
            role_button_1 = false;
            role_button_2 = true;
            role_button_3 = false;
            role_button_4 = false;
        }

        private void TapGestureRecognizer_Role_3_Tapped(object sender, EventArgs e)
        {
            RoleButton_1.Source = "ic_rb2.png";
            RoleButton_2.Source = "ic_rb2.png";
            RoleButton_3.Source = "ic_rb1.png";
            //RoleButton_4.Source = "ic_rb2.png";
            role_button_1 = false;
            role_button_2 = false;
            role_button_3 = true;
            role_button_4 = false;
        }

        //Admin Registration

        //private void TapGestureRecognizer_Role_4_Tapped(object sender, EventArgs e)
        //{
        //    RoleButton_1.Source = "ic_rb2.png";
        //    RoleButton_2.Source = "ic_rb2.png";
        //    RoleButton_3.Source = "ic_rb2.png";
        //    RoleButton_4.Source = "ic_rb1.png";
        //    role_button_1 = false;
        //    role_button_2 = false;
        //    role_button_3 = false;
        //    role_button_4 = true;
        //}

        static bool IsLetter(char c)
        {
            return (c >= 'a' && c <= 'z') || (c >= 'A' && c <= 'Z');
        }

        static bool IsDigit(char c)
        {
            return c >= '0' && c <= '9';
        }

        static bool IsSymbol(char c)
        {
            return c > 32 && c < 127 && !IsDigit(c) && !IsLetter(c);
        }

        static bool IsValidPassword(string password)
        {
            return
               password.Any(c => IsLetter(c)) &&
               password.Any(c => IsDigit(c)) &&
               password.Any(c => IsSymbol(c));
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