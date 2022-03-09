using System;
using System.IO;
using System.Net;
using System.Text;
using System.ComponentModel;
using App6.Model;
using Xamarin.Forms;
using App6.Management;
using Xamarin.Forms.Xaml;
using App6.Resources;

namespace App6
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Allgemeines_NoQE : ContentPage, INotifyPropertyChanged
    {
        public bool InitialDataIsEmpty;

        public Allgemeines_NoQE()
        {
            InitializeComponent();
            BindingContext = this;

            BogenLabel.Text = AppResources.SurveyHeadlineWithoutQE + " " + DBManagement.getYearCode(App.user.selected_mstr_ebqe) + " " + AppResources.SurveyHeadlineFor + " " + ErfassungsbogenNoQE.Bewohnerbezeichnung;

            Picker_tkurzfield05.Items.Add("1");
            Picker_tkurzfield05.Items.Add("2");
            Picker_tkurzfield05.Items.Add("3");
            Picker_tkurzfield05.Items.Add("4");
            Picker_tkurzfield05.Items.Add("5");

            Picker_tkurzfield06.Items.Add("Möchte nicht erfasst werden");
            Picker_tkurzfield06.Items.Add("Bewohner ist vor weniger als 14 Tagen in der Einrichtung eingezogen");
            Picker_tkurzfield06.Items.Add("Ist aus der Einrichtung ausgezogen");
            Picker_tkurzfield06.Items.Add("Befindet sich in der Sterbephase");
            Picker_tkurzfield06.Items.Add("Ist verstorben");
            Picker_tkurzfield06.Items.Add("Kurzzeitpflege");
            Picker_tkurzfield06.Items.Add("Sonstige Gründe");

            Picker_tkurzfield09.Items.Add("In der Einrichtung");
            Picker_tkurzfield09.Items.Add("In einem Krankenhaus");
            Picker_tkurzfield09.Items.Add("In einem Hospiz");
            Picker_tkurzfield09.Items.Add("An einem anderen Ort");
        }

        //Before page gets loaded this opertion is performed
        protected override async void OnAppearing()
        {
            base.OnAppearing();

            try
            {
                //ActivityIndicator = Loading...
                IsLoading = true;

                //Pflegegrad
                if (ErfassungsbogenNoQE.tkurzfield05 == "1")
                {
                    Picker_tkurzfield05.SelectedIndex = 0;
                }

                else if (ErfassungsbogenNoQE.tkurzfield05 == "2")
                {
                    Picker_tkurzfield05.SelectedIndex = 1;
                }

                else if (ErfassungsbogenNoQE.tkurzfield05 == "3")
                {
                    Picker_tkurzfield05.SelectedIndex = 2;
                }

                else if (ErfassungsbogenNoQE.tkurzfield05 == "4")
                {
                    Picker_tkurzfield05.SelectedIndex = 3;
                }

                else if (ErfassungsbogenNoQE.tkurzfield05 == "5")
                {
                    Picker_tkurzfield05.SelectedIndex = 4;
                }

                //Nicht-Erfassungsgründe
                if (ErfassungsbogenNoQE.tkurzfield06 == "1")
                {
                    Picker_tkurzfield06.SelectedIndex = 0;
                }
                else if (ErfassungsbogenNoQE.tkurzfield06 == "2")
                {
                    Picker_tkurzfield06.SelectedIndex = 1;
                }
                else if (ErfassungsbogenNoQE.tkurzfield06 == "3")
                {
                    Picker_tkurzfield06.SelectedIndex = 2;
                }
                else if (ErfassungsbogenNoQE.tkurzfield06 == "4")
                {
                    Picker_tkurzfield06.SelectedIndex = 3;
                }
                else if (ErfassungsbogenNoQE.tkurzfield06 == "0")
                {
                    Picker_tkurzfield06.SelectedIndex = 4;
                }
                else if (ErfassungsbogenNoQE.tkurzfield06 == "6")
                {
                    Picker_tkurzfield06.SelectedIndex = 5;
                }
                else if (ErfassungsbogenNoQE.tkurzfield06 == "7")
                {
                    Picker_tkurzfield06.SelectedIndex = 6;
                }

                //Pflegegrad Picker
                if (ErfassungsbogenNoQE.tkurzfield09 == "1")
                {
                    Picker_tkurzfield09.SelectedIndex = 0;
                }
                else if (ErfassungsbogenNoQE.tkurzfield09 == "2")
                {
                    Picker_tkurzfield09.SelectedIndex = 1;
                }
                else if (ErfassungsbogenNoQE.tkurzfield09 == "3")
                {
                    Picker_tkurzfield09.SelectedIndex = 2;
                }
                else if (ErfassungsbogenNoQE.tkurzfield09 == "4")
                {
                    Picker_tkurzfield09.SelectedIndex = 3;
                }

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
                    await Navigation.PushAsync(new CategoryPageNoQE());
                }
                else
                {
                    var BackQuestion = await DisplayAlert(AppResources.Information, AppResources.InformationSaveQuery, AppResources.Yes, AppResources.No);
                    if (BackQuestion == true)
                    {
                        //Set Text Entry Values in Erfassungsbogen
                        ErfassungsbogenNoQE.tkurzfield07 = Entry_tkurzfield07.Text;

                        Label_tkurzfield05.TextColor = Label_tkurzfield06.TextColor = Label_tkurzfield07.TextColor = Label_tkurzfield08.TextColor = Label_tkurzfield09.TextColor = AppManager.QuestionColor;

                        if (ErfassungsbogenNoQE.tkurzfield05 == "" | ErfassungsbogenNoQE.tkurzfield05 == null)
                        {
                            Label_tkurzfield05.TextColor = Color.Red;
                            await DisplayAlert(AppResources.Warning, AppResources.FieldsUnfilled, "OK");
                            BackButton.Source = "ic_arrow_back_ios.png";
                        }
                        else
                        {
                            if (ErfassungsbogenNoQE.tkurzfield06 == "" | ErfassungsbogenNoQE.tkurzfield06 == null)
                            {
                                Label_tkurzfield06.TextColor = Color.Red;
                                await DisplayAlert(AppResources.Warning, AppResources.FieldsUnfilled, "OK");
                                BackButton.Source = "ic_arrow_back_ios.png";
                            }
                            else
                            {
                                //Wenn Sonstige Gründe
                                if (ErfassungsbogenNoQE.tkurzfield06 == "7")
                                {
                                    //Sonstige Gründe Beschreibung filled?
                                    if (Entry_tkurzfield07.Text == "" | Entry_tkurzfield07.Text == null)
                                    {
                                        Label_tkurzfield07.TextColor = Color.Red;
                                        await DisplayAlert(AppResources.Warning, AppResources.FieldsUnfilled, "OK");
                                        BackButton.Source = "ic_arrow_back_ios.png";
                                    }
                                    else
                                    {
                                        //Bewohner verstorben - Wann?
                                        if (ErfassungsbogenNoQE.tkurzfield08 != "" && ErfassungsbogenNoQE.tkurzfield08 != null)
                                        {
                                            //Bewohner verstorben - Wo?
                                            if (ErfassungsbogenNoQE.tkurzfield09 == "" | ErfassungsbogenNoQE.tkurzfield09 == null)
                                            {
                                                Label_tkurzfield09.TextColor = Color.Red;
                                                await DisplayAlert(AppResources.Warning, AppResources.FieldsUnfilled, "OK");
                                                BackButton.Source = "ic_arrow_back_ios.png";
                                            }
                                            else
                                            {
                                                WebRequest req = WebRequest.Create(DBManagement.DBConnection + "tbl_form_ebqe_no_qe_update.php"); //tbl_form_ebqe_kurz

                                                req.Method = "POST"; //POST
                                                req.Timeout = 15000;
                                                req.ContentType = "application/x-www-form-urlencoded";

                                                string postData = "mstr=" + App.user.selected_mstr_ebqe + "&bewonerid=" + App.user.selected_id_bewohner + "&tkurzfield01=" + ErfassungsbogenNoQE.tkurzfield01 + "&tkurzfield02=" + ErfassungsbogenNoQE.tkurzfield02 + "&tkurzfield03=" + ErfassungsbogenNoQE.tkurzfield03 + "&tkurzfield04=" + ErfassungsbogenNoQE.tkurzfield04 + "&tkurzfield05=" + ErfassungsbogenNoQE.tkurzfield05 + "&tkurzfield06=" + ErfassungsbogenNoQE.tkurzfield06 + "&tkurzfield07=" + ErfassungsbogenNoQE.tkurzfield07 + "&tkurzfield08=" + ErfassungsbogenNoQE.tkurzfield08 + "&tkurzfield09=" + ErfassungsbogenNoQE.tkurzfield09;

                                                byte[] byteArray = Encoding.UTF8.GetBytes(postData);

                                                req.ContentLength = byteArray.Length;

                                                Stream ds = await req.GetRequestStreamAsync();
                                                await ds.WriteAsync(byteArray, 0, byteArray.Length);
                                                ds.Close();

                                                await Navigation.PushAsync(new CategoryPageNoQE());
                                            }
                                        }
                                        else
                                        {
                                            WebRequest req = WebRequest.Create(DBManagement.DBConnection + "tbl_form_ebqe_no_qe_update.php"); //tbl_form_ebqe_kurz

                                            req.Method = "POST"; //POST
                                            req.Timeout = 15000;
                                            req.ContentType = "application/x-www-form-urlencoded";

                                            string postData = "mstr=" + App.user.selected_mstr_ebqe + "&bewonerid=" + App.user.selected_id_bewohner + "&tkurzfield01=" + ErfassungsbogenNoQE.tkurzfield01 + "&tkurzfield02=" + ErfassungsbogenNoQE.tkurzfield02 + "&tkurzfield03=" + ErfassungsbogenNoQE.tkurzfield03 + "&tkurzfield04=" + ErfassungsbogenNoQE.tkurzfield04 + "&tkurzfield05=" + ErfassungsbogenNoQE.tkurzfield05 + "&tkurzfield06=" + ErfassungsbogenNoQE.tkurzfield06 + "&tkurzfield07=" + ErfassungsbogenNoQE.tkurzfield07 + "&tkurzfield08=" + ErfassungsbogenNoQE.tkurzfield08 + "&tkurzfield09=" + ErfassungsbogenNoQE.tkurzfield09;

                                            byte[] byteArray = Encoding.UTF8.GetBytes(postData);

                                            req.ContentLength = byteArray.Length;

                                            Stream ds = await req.GetRequestStreamAsync();
                                            await ds.WriteAsync(byteArray, 0, byteArray.Length);
                                            ds.Close();

                                            await Navigation.PushAsync(new CategoryPageNoQE());
                                        }
                                    }
                                }
                                else
                                {
                                    //Bewohner verstorben - Wann?
                                    if (ErfassungsbogenNoQE.tkurzfield08 != "" && ErfassungsbogenNoQE.tkurzfield08 != null)
                                    {
                                        //Bewohner verstorben - Wo?
                                        if (ErfassungsbogenNoQE.tkurzfield09 == "" | ErfassungsbogenNoQE.tkurzfield09 == null)
                                        {
                                            Label_tkurzfield09.TextColor = Color.Red;
                                            await DisplayAlert(AppResources.Warning, AppResources.FieldsUnfilled, "OK");
                                            BackButton.Source = "ic_arrow_back_ios.png";
                                        }
                                        else
                                        {
                                            WebRequest req = WebRequest.Create(DBManagement.DBConnection + "tbl_form_ebqe_no_qe_update.php"); //tbl_form_ebqe_kurz

                                            req.Method = "POST"; //POST
                                            req.Timeout = 15000;
                                            req.ContentType = "application/x-www-form-urlencoded";

                                            string postData = "mstr=" + App.user.selected_mstr_ebqe + "&bewonerid=" + App.user.selected_id_bewohner + "&tkurzfield01=" + ErfassungsbogenNoQE.tkurzfield01 + "&tkurzfield02=" + ErfassungsbogenNoQE.tkurzfield02 + "&tkurzfield03=" + ErfassungsbogenNoQE.tkurzfield03 + "&tkurzfield04=" + ErfassungsbogenNoQE.tkurzfield04 + "&tkurzfield05=" + ErfassungsbogenNoQE.tkurzfield05 + "&tkurzfield06=" + ErfassungsbogenNoQE.tkurzfield06 + "&tkurzfield07=" + ErfassungsbogenNoQE.tkurzfield07 + "&tkurzfield08=" + ErfassungsbogenNoQE.tkurzfield08 + "&tkurzfield09=" + ErfassungsbogenNoQE.tkurzfield09;

                                            byte[] byteArray = Encoding.UTF8.GetBytes(postData);

                                            req.ContentLength = byteArray.Length;

                                            Stream ds = await req.GetRequestStreamAsync();
                                            await ds.WriteAsync(byteArray, 0, byteArray.Length);
                                            ds.Close();

                                            await Navigation.PushAsync(new CategoryPageNoQE());
                                        }
                                    }
                                    else
                                    {
                                        WebRequest req = WebRequest.Create(DBManagement.DBConnection + "tbl_form_ebqe_no_qe_update.php"); //tbl_form_ebqe_kurz

                                        req.Method = "POST"; //POST
                                        req.Timeout = 15000;
                                        req.ContentType = "application/x-www-form-urlencoded";

                                        string postData = "mstr=" + App.user.selected_mstr_ebqe + "&bewonerid=" + App.user.selected_id_bewohner + "&tkurzfield01=" + ErfassungsbogenNoQE.tkurzfield01 + "&tkurzfield02=" + ErfassungsbogenNoQE.tkurzfield02 + "&tkurzfield03=" + ErfassungsbogenNoQE.tkurzfield03 + "&tkurzfield04=" + ErfassungsbogenNoQE.tkurzfield04 + "&tkurzfield05=" + ErfassungsbogenNoQE.tkurzfield05 + "&tkurzfield06=" + ErfassungsbogenNoQE.tkurzfield06 + "&tkurzfield07=" + ErfassungsbogenNoQE.tkurzfield07 + "&tkurzfield08=" + ErfassungsbogenNoQE.tkurzfield08 + "&tkurzfield09=" + ErfassungsbogenNoQE.tkurzfield09;

                                        byte[] byteArray = Encoding.UTF8.GetBytes(postData);

                                        req.ContentLength = byteArray.Length;

                                        Stream ds = await req.GetRequestStreamAsync();
                                        await ds.WriteAsync(byteArray, 0, byteArray.Length);
                                        ds.Close();

                                        await Navigation.PushAsync(new CategoryPageNoQE());
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        ErfassungsbogenNoQE.tkurzfield05 = ErfassungsbogenNoQE.tkurzfield06 = ErfassungsbogenNoQE.tkurzfield07 = ErfassungsbogenNoQE.tkurzfield08 = ErfassungsbogenNoQE.tkurzfield09 = "";

                        WebRequest req = WebRequest.Create(DBManagement.DBConnection + "tbl_form_ebqe_no_qe_update.php"); //tbl_form_ebqe_kurz

                        req.Method = "POST"; //POST
                        req.Timeout = 15000;
                        req.ContentType = "application/x-www-form-urlencoded";

                        string postData = "mstr=" + App.user.selected_mstr_ebqe + "&bewonerid=" + App.user.selected_id_bewohner + "&tkurzfield01=" + ErfassungsbogenNoQE.tkurzfield01 + "&tkurzfield02=" + ErfassungsbogenNoQE.tkurzfield02 + "&tkurzfield03=" + ErfassungsbogenNoQE.tkurzfield03 + "&tkurzfield04=" + ErfassungsbogenNoQE.tkurzfield04 + "&tkurzfield05=" + ErfassungsbogenNoQE.tkurzfield05 + "&tkurzfield06=" + ErfassungsbogenNoQE.tkurzfield06 + "&tkurzfield07=" + ErfassungsbogenNoQE.tkurzfield07 + "&tkurzfield08=" + ErfassungsbogenNoQE.tkurzfield08 + "&tkurzfield09=" + ErfassungsbogenNoQE.tkurzfield09;

                        byte[] byteArray = Encoding.UTF8.GetBytes(postData);

                        req.ContentLength = byteArray.Length;

                        Stream ds = await req.GetRequestStreamAsync();
                        await ds.WriteAsync(byteArray, 0, byteArray.Length);
                        ds.Close();

                        await Navigation.PushAsync(new CategoryPageNoQE());
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

        private async void SaveDataAndGoToMenuButton_TappedAsync(object sender, EventArgs e)
        {
            SaveAllButton.Source = "ic_done_all_tapped.png";

            try
            {
                //ActivityIndicator = Loading...
                IsLoading = true;

                if (App.user.selected_mstr_ebqe != DBManagement.CurrentEvaluationID)
                {
                    await Navigation.PushAsync(new CategoryPageNoQE());
                }
                else
                {
                    //Set Text Entry Values in Erfassungsbogen
                    ErfassungsbogenNoQE.tkurzfield07 = Entry_tkurzfield07.Text;

                    Label_tkurzfield05.TextColor = Label_tkurzfield06.TextColor = Label_tkurzfield07.TextColor = Label_tkurzfield08.TextColor = Label_tkurzfield09.TextColor = AppManager.QuestionColor;

                    if (ErfassungsbogenNoQE.tkurzfield05 == "" | ErfassungsbogenNoQE.tkurzfield05 == null)
                    {
                        Label_tkurzfield05.TextColor = Color.Red;
                        await DisplayAlert(AppResources.Warning, AppResources.FieldsUnfilled, "OK");
                        SaveAllButton.Source = "ic_done_all.png";
                    }
                    else
                    {
                        if (ErfassungsbogenNoQE.tkurzfield06 == "" | ErfassungsbogenNoQE.tkurzfield06 == null)
                        {
                            Label_tkurzfield06.TextColor = Color.Red;
                            await DisplayAlert(AppResources.Warning, AppResources.FieldsUnfilled, "OK");
                            SaveAllButton.Source = "ic_done_all.png";
                        }
                        else
                        {
                            //Wenn Sonstige Gründe
                            if (ErfassungsbogenNoQE.tkurzfield06 == "7")
                            {
                                //Sonstige Gründe Beschreibung filled?
                                if (Entry_tkurzfield07.Text == "" | Entry_tkurzfield07.Text == null)
                                {
                                    Label_tkurzfield07.TextColor = Color.Red;
                                    await DisplayAlert(AppResources.Warning, AppResources.FieldsUnfilled, "OK");
                                    SaveAllButton.Source = "ic_done_all.png";
                                }
                                else
                                {
                                    //Bewohner verstorben - Wann?
                                    if (ErfassungsbogenNoQE.tkurzfield08 != "" && ErfassungsbogenNoQE.tkurzfield08 != null)
                                    {
                                        //Bewohner verstorben - Wo?
                                        if (ErfassungsbogenNoQE.tkurzfield09 == "" | ErfassungsbogenNoQE.tkurzfield09 == null)
                                        {
                                            Label_tkurzfield09.TextColor = Color.Red;
                                            await DisplayAlert(AppResources.Warning, AppResources.FieldsUnfilled, "OK");
                                            SaveAllButton.Source = "ic_done_all.png";
                                        }
                                        else
                                        {
                                            WebRequest req = WebRequest.Create(DBManagement.DBConnection + "tbl_form_ebqe_no_qe_update.php"); //tbl_form_ebqe_kurz

                                            req.Method = "POST"; //POST
                                            req.Timeout = 15000;
                                            req.ContentType = "application/x-www-form-urlencoded";

                                            string postData = "mstr=" + App.user.selected_mstr_ebqe + "&bewonerid=" + App.user.selected_id_bewohner + "&tkurzfield01=" + ErfassungsbogenNoQE.tkurzfield01 + "&tkurzfield02=" + ErfassungsbogenNoQE.tkurzfield02 + "&tkurzfield03=" + ErfassungsbogenNoQE.tkurzfield03 + "&tkurzfield04=" + ErfassungsbogenNoQE.tkurzfield04 + "&tkurzfield05=" + ErfassungsbogenNoQE.tkurzfield05 + "&tkurzfield06=" + ErfassungsbogenNoQE.tkurzfield06 + "&tkurzfield07=" + ErfassungsbogenNoQE.tkurzfield07 + "&tkurzfield08=" + ErfassungsbogenNoQE.tkurzfield08 + "&tkurzfield09=" + ErfassungsbogenNoQE.tkurzfield09;

                                            byte[] byteArray = Encoding.UTF8.GetBytes(postData);

                                            req.ContentLength = byteArray.Length;

                                            Stream ds = await req.GetRequestStreamAsync();
                                            await ds.WriteAsync(byteArray, 0, byteArray.Length);
                                            ds.Close();

                                            await Navigation.PushAsync(new CategoryPageNoQE());
                                        }
                                    }
                                    else
                                    {
                                        WebRequest req = WebRequest.Create(DBManagement.DBConnection + "tbl_form_ebqe_no_qe_update.php"); //tbl_form_ebqe_kurz

                                        req.Method = "POST"; //POST
                                        req.Timeout = 15000;
                                        req.ContentType = "application/x-www-form-urlencoded";

                                        string postData = "mstr=" + App.user.selected_mstr_ebqe + "&bewonerid=" + App.user.selected_id_bewohner + "&tkurzfield01=" + ErfassungsbogenNoQE.tkurzfield01 + "&tkurzfield02=" + ErfassungsbogenNoQE.tkurzfield02 + "&tkurzfield03=" + ErfassungsbogenNoQE.tkurzfield03 + "&tkurzfield04=" + ErfassungsbogenNoQE.tkurzfield04 + "&tkurzfield05=" + ErfassungsbogenNoQE.tkurzfield05 + "&tkurzfield06=" + ErfassungsbogenNoQE.tkurzfield06 + "&tkurzfield07=" + ErfassungsbogenNoQE.tkurzfield07 + "&tkurzfield08=" + ErfassungsbogenNoQE.tkurzfield08 + "&tkurzfield09=" + ErfassungsbogenNoQE.tkurzfield09;

                                        byte[] byteArray = Encoding.UTF8.GetBytes(postData);

                                        req.ContentLength = byteArray.Length;

                                        Stream ds = await req.GetRequestStreamAsync();
                                        await ds.WriteAsync(byteArray, 0, byteArray.Length);
                                        ds.Close();

                                        await Navigation.PushAsync(new CategoryPageNoQE());
                                    }
                                }
                            }
                            else
                            {
                                //Bewohner verstorben - Wann?
                                if (ErfassungsbogenNoQE.tkurzfield08 != "" && ErfassungsbogenNoQE.tkurzfield08 != null)
                                {
                                    //Bewohner verstorben - Wo?
                                    if (ErfassungsbogenNoQE.tkurzfield09 == "" | ErfassungsbogenNoQE.tkurzfield09 == null)
                                    {
                                        Label_tkurzfield09.TextColor = Color.Red;
                                        await DisplayAlert(AppResources.Warning, AppResources.FieldsUnfilled, "OK");
                                        SaveAllButton.Source = "ic_done_all.png";
                                    }
                                    else
                                    {
                                        WebRequest req = WebRequest.Create(DBManagement.DBConnection + "tbl_form_ebqe_no_qe_update.php"); //tbl_form_ebqe_kurz

                                        req.Method = "POST"; //POST
                                        req.Timeout = 15000;
                                        req.ContentType = "application/x-www-form-urlencoded";

                                        string postData = "mstr=" + App.user.selected_mstr_ebqe + "&bewonerid=" + App.user.selected_id_bewohner + "&tkurzfield01=" + ErfassungsbogenNoQE.tkurzfield01 + "&tkurzfield02=" + ErfassungsbogenNoQE.tkurzfield02 + "&tkurzfield03=" + ErfassungsbogenNoQE.tkurzfield03 + "&tkurzfield04=" + ErfassungsbogenNoQE.tkurzfield04 + "&tkurzfield05=" + ErfassungsbogenNoQE.tkurzfield05 + "&tkurzfield06=" + ErfassungsbogenNoQE.tkurzfield06 + "&tkurzfield07=" + ErfassungsbogenNoQE.tkurzfield07 + "&tkurzfield08=" + ErfassungsbogenNoQE.tkurzfield08 + "&tkurzfield09=" + ErfassungsbogenNoQE.tkurzfield09;

                                        byte[] byteArray = Encoding.UTF8.GetBytes(postData);

                                        req.ContentLength = byteArray.Length;

                                        Stream ds = await req.GetRequestStreamAsync();
                                        await ds.WriteAsync(byteArray, 0, byteArray.Length);
                                        ds.Close();

                                        await Navigation.PushAsync(new CategoryPageNoQE());
                                    }
                                }
                                else
                                {
                                    WebRequest req = WebRequest.Create(DBManagement.DBConnection + "tbl_form_ebqe_no_qe_update.php"); //tbl_form_ebqe_kurz

                                    req.Method = "POST"; //POST
                                    req.Timeout = 15000;
                                    req.ContentType = "application/x-www-form-urlencoded";

                                    string postData = "mstr=" + App.user.selected_mstr_ebqe + "&bewonerid=" + App.user.selected_id_bewohner + "&tkurzfield01=" + ErfassungsbogenNoQE.tkurzfield01 + "&tkurzfield02=" + ErfassungsbogenNoQE.tkurzfield02 + "&tkurzfield03=" + ErfassungsbogenNoQE.tkurzfield03 + "&tkurzfield04=" + ErfassungsbogenNoQE.tkurzfield04 + "&tkurzfield05=" + ErfassungsbogenNoQE.tkurzfield05 + "&tkurzfield06=" + ErfassungsbogenNoQE.tkurzfield06 + "&tkurzfield07=" + ErfassungsbogenNoQE.tkurzfield07 + "&tkurzfield08=" + ErfassungsbogenNoQE.tkurzfield08 + "&tkurzfield09=" + ErfassungsbogenNoQE.tkurzfield09;

                                    byte[] byteArray = Encoding.UTF8.GetBytes(postData);

                                    req.ContentLength = byteArray.Length;

                                    Stream ds = await req.GetRequestStreamAsync();
                                    await ds.WriteAsync(byteArray, 0, byteArray.Length);
                                    ds.Close();

                                    await Navigation.PushAsync(new CategoryPageNoQE());
                                }
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
                SaveAllButton.Source = "ic_done_all.png";
            }
        }

        private async void ResetAllDataFromCategoryButton_TappedAsync(object sender, EventArgs e)
        {
            try
            {
                //ActivityIndicator = Loading...
                IsLoading = true;

                if (App.user.selected_mstr_ebqe != DBManagement.CurrentEvaluationID)
                {
                    await DisplayAlert(AppResources.Warning, AppResources.ResetCategoryImpossibleWarning, "OK");
                }
                else
                {
                    var ResetButton = await DisplayAlert(AppResources.Warning, AppResources.ResetCategoryWarning, AppResources.Yes, AppResources.No);
                    if (ResetButton == true)
                    {
                        WebRequest req = WebRequest.Create(DBManagement.DBConnection + "tbl_form_ebqe_no_qe_update_clr.php"); //tbl_form_ebqe_kurz

                        req.Method = "POST"; //POST
                        req.Timeout = 15000;
                        req.ContentType = "application/x-www-form-urlencoded";

                        string postData = "mstr=" + App.user.selected_mstr_ebqe + "&bewonerid=" + App.user.selected_id_bewohner;
                        byte[] byteArray = Encoding.UTF8.GetBytes(postData);

                        req.ContentLength = byteArray.Length;

                        Stream ds = await req.GetRequestStreamAsync();
                        await ds.WriteAsync(byteArray, 0, byteArray.Length);
                        ds.Close();

                        ErfassungsbogenNoQE.loadedFromDB = false;

                        await Navigation.PushAsync(new CategoryPageNoQE());
                    }
                    else
                    {
                        await Navigation.PushAsync(new SearchPage());
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

        //Pflegegrad Picker
        private void Picker_tkurzfield05_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Picker_tkurzfield05.SelectedIndex == 0)
            {
                ErfassungsbogenNoQE.tkurzfield05 = "1";
            }
            else if (Picker_tkurzfield05.SelectedIndex == 1)
            {
                ErfassungsbogenNoQE.tkurzfield05 = "2";
            }
            else if (Picker_tkurzfield05.SelectedIndex == 2)
            {
                ErfassungsbogenNoQE.tkurzfield05 = "3";
            }
            else if (Picker_tkurzfield05.SelectedIndex == 3)
            {
                ErfassungsbogenNoQE.tkurzfield05 = "4";
            }
            else if (Picker_tkurzfield05.SelectedIndex == 4)
            {
                ErfassungsbogenNoQE.tkurzfield05 = "5";
            }
        }

        //Nicht-Erfassungsgründe
        private void Picker_tkurzfield06_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Möchte nicht erfasst werden
            if (Picker_tkurzfield06.SelectedIndex == 0)
            {
                ErfassungsbogenNoQE.tkurzfield06 = "1";
            }
            //Bewohner ist vor weniger als 14 Tagen in der Einrichtung eingezogen
            else if (Picker_tkurzfield06.SelectedIndex == 1)
            {
                ErfassungsbogenNoQE.tkurzfield06 = "2";
            }
            //Ist aus der Einrichtung ausgezogen
            else if (Picker_tkurzfield06.SelectedIndex == 2)
            {
                ErfassungsbogenNoQE.tkurzfield06 = "3";
            }
            //Befindet sich in der Sterbephase
            else if (Picker_tkurzfield06.SelectedIndex == 3)
            {
                ErfassungsbogenNoQE.tkurzfield06 = "4";
            }
            //Ist verstorben
            else if (Picker_tkurzfield06.SelectedIndex == 4)
            {
                ErfassungsbogenNoQE.tkurzfield06 = "0";
            }
            //Kurzzeitpflege
            else if (Picker_tkurzfield06.SelectedIndex == 5)
            {
                ErfassungsbogenNoQE.tkurzfield06 = "6";
            }
            //Sonstige Gründe
            else if (Picker_tkurzfield06.SelectedIndex == 6)
            {
                ErfassungsbogenNoQE.tkurzfield06 = "7";
            }
        }

        //Pflegegrad Picker
        private void Picker_tkurzfield09_SelectedIndexChanged(object sender, EventArgs e)
        {
            //In der Einrichtung
            if (Picker_tkurzfield09.SelectedIndex == 0)
            {
                ErfassungsbogenNoQE.tkurzfield09 = "1";
            }
            //In einem Krankenhaus
            else if (Picker_tkurzfield09.SelectedIndex == 1)
            {
                ErfassungsbogenNoQE.tkurzfield09 = "2";
            }
            //In einem Hospiz
            else if (Picker_tkurzfield09.SelectedIndex == 2)
            {
                ErfassungsbogenNoQE.tkurzfield09 = "3";
            }
            //An einem anderen Ort
            else if (Picker_tkurzfield09.SelectedIndex == 3)
            {
                ErfassungsbogenNoQE.tkurzfield09 = "4";
            }
        }

        #region tkurzfield08

        private void ResetLabel_tkurzfield08_Tapped(object sender, EventArgs e)
        {
            ErfassungsbogenNoQE.tkurzfield08 = "";
            Entry_tkurzfield08.Text = "";
        }

        private void Entry_tkurzfield08_Focused(object sender, FocusEventArgs e)
        {
            Entry_tkurzfield08.Unfocus();
            DatePicker_tkurzfield08.Focus();
        }

        private void DatePicker_tkurzfield08_Unfocused(object sender, DateChangedEventArgs e)
        {
            ErfassungsbogenNoQE.tkurzfield08 = DatePicker_tkurzfield08.Date.ToString("dd.MM.yyyy");
            Entry_tkurzfield08.Text = DatePicker_tkurzfield08.Date.ToString("dd.MM.yyyy");
        }

        private void DatePicker_tkurzfield08_DateSelected(object sender, DateChangedEventArgs e)
        {
            ErfassungsbogenNoQE.tkurzfield08 = DatePicker_tkurzfield08.Date.ToString("dd.MM.yyyy");
            Entry_tkurzfield08.Text = DatePicker_tkurzfield08.Date.ToString("dd.MM.yyyy");
        }

        #endregion

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