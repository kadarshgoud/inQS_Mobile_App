using App6.Model;
using System;
using System.IO;
using System.Net;
using System.Text;
using App6.Management;
using Xamarin.Forms;
using System.ComponentModel;
using Xamarin.Forms.Xaml;
using App6.Resources;

namespace App6
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Dekubitus_1 : ContentPage, INotifyPropertyChanged
    {
        public bool InitialDataIsEmpty;

        public Dekubitus_1()
        {
            InitializeComponent();
            BindingContext = this;

            BogenLabel.Text = AppResources.SurveyHeadline + " " + DBManagement.getYearCode(App.user.selected_mstr_ebqe) + " " + AppResources.SurveyHeadlineFor + " " + Erfassungsbogen.Bewohnerbezeichnung;

            //picker 1
            t07Picker00.Items.Add("ja");
            t07Picker00.Items.Add("nein");

            //picker2
            t07Picker01.Items.Add("ja, einmal");
            t07Picker01.Items.Add("ja, mehrmals");
            t07Picker01.Items.Add("nein (bei nein weiter mit Frage 8)");

            //picker3
            t07Picker02.Items.Add("Stadium 1");
            t07Picker02.Items.Add("Stadium 2");
            t07Picker02.Items.Add("Stadium 3");
            t07Picker02.Items.Add("Stadium 4");
            t07Picker02.Items.Add("unbekannt");

            // picker 4_1
            t07Picker04_1.Items.Add("in der Pflegeeinrichtung vor");
            t07Picker04_1.Items.Add("im Krankenhaus");
            t07Picker04_1.Items.Add("vor dem Heimeinzug");
            t07Picker04_1.Items.Add("woanders");

            // picker 4_2
            t07Picker04_2.Items.Add("in der Pflegeeinrichtung vor");
            t07Picker04_2.Items.Add("im Krankenhaus");
            t07Picker04_2.Items.Add("vor dem Heimeinzug");
            t07Picker04_2.Items.Add("woanders");
        }

        //Before page gets loaded this opertion is performed
        protected override async void OnAppearing()
        {
            base.OnAppearing();

            try
                    {
                //ActivityIndicator = Loading...
                IsLoading = true;
                
                //   WebRequest req = WebRequest.Create(DBManagement.DBConnection + "tbl_form_ebqe_t07_01_read.php");
                
                //                req.Method = "POST";
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

                //if (split[0] != "" && split[1] != "" && split[2] != "" && split[3] != "" && split[4] != "" && split[5] != "" && split[6] != "" && split[7] != "" && split[8] != "")
                //{
                //    InitialDataIsEmpty = false;
                //}

                //Erfassungsbogen.t07field00 = split[0];
                //Erfassungsbogen.t07field01 = split[1];
                //Erfassungsbogen.t07field02 = split[2];
                //Erfassungsbogen.t07field03_01 = split[3];
                //Erfassungsbogen.t07field03_02 = split[4];
                //Erfassungsbogen.t07field03_03 = split[5];
                //Erfassungsbogen.t07field03_04 = split[6];
                //Erfassungsbogen.t07field04 = split[7];
                //Erfassungsbogen.t07field04_02 = split[8];

                if (Erfassungsbogen.t07field01 == "0")
                {
                    t07field02.IsEnabled =
                    t07Picker02.IsEnabled =
                    t07Field03.IsEnabled =

                    Label_t07field03_01.IsEnabled =
                    DatePicker_t07field03_01.IsEnabled =
                    Entry_t07field03_01.IsEnabled =
                    ResetLabel_t07field03_01.IsEnabled =

                    Label_t07field03_02.IsEnabled =
                    DatePicker_t07field03_02.IsEnabled =
                    Entry_t07field03_02.IsEnabled =
                    ResetLabel_t07field03_02.IsEnabled =

                    Label_t07field03_03.IsEnabled =
                    DatePicker_t07field03_03.IsEnabled =
                    Entry_t07field03_03.IsEnabled =
                    ResetLabel_t07field03_03.IsEnabled =

                    Label_t07field03_04.IsEnabled =
                    DatePicker_t07field03_04.IsEnabled =
                    Entry_t07field03_04.IsEnabled =
                    ResetLabel_t07field03_04.IsEnabled =

                    t07field04_1.IsEnabled =
                    t07Picker04_1.IsEnabled =
                     t07field04_2.IsEnabled =
                    t07Picker04_2.IsEnabled =
                    false;

                    t07field02.Opacity =
                   t07Picker02.Opacity =
                   t07Field03.Opacity =

                   Label_t07field03_01.Opacity =
                   DatePicker_t07field03_01.Opacity =
                   Entry_t07field03_01.Opacity =
                   ResetLabel_t07field03_01.Opacity =

                    Label_t07field03_02.Opacity =
                   DatePicker_t07field03_02.Opacity =
                   Entry_t07field03_02.Opacity =
                   ResetLabel_t07field03_02.Opacity =

                    Label_t07field03_03.Opacity =
                   DatePicker_t07field03_03.Opacity =
                   Entry_t07field03_03.Opacity =
                   ResetLabel_t07field03_03.Opacity =

                    Label_t07field03_04.Opacity =
                   DatePicker_t07field03_04.Opacity =
                   Entry_t07field03_04.Opacity =
                   ResetLabel_t07field03_04.Opacity =

                   t07field04_1.Opacity =
                   t07Picker04_1.Opacity =
                   t07field04_2.Opacity =
                   t07Picker04_2.Opacity = 0.3;
                }

                // picker 1

                if (Erfassungsbogen.t07field00 == "1")
                {
                    t07Picker00.SelectedIndex = 0;                         // whether ja==0 by default or not ??
                }
                else if (Erfassungsbogen.t07field00 == "0")
                {
                    t07Picker00.SelectedIndex = 1;
                }
                else
                {
                    t07Picker00.SelectedIndex = -1;
                }

                // picker 2

                if (Erfassungsbogen.t07field01 == "1")
                {
                    t07Picker01.SelectedIndex = 0;      // rb1 is the image file with checked box image

                    //Dekubitus 1 enable - Dekubitus 2 disable
                    t07field02.IsEnabled = t07Picker02.IsEnabled = t07Field03.IsEnabled = Label_t07field03_01.IsEnabled = DatePicker_t07field03_01.IsEnabled = Entry_t07field03_01.IsEnabled = ResetLabel_t07field03_01.IsEnabled = Label_t07field03_02.IsEnabled = DatePicker_t07field03_02.IsEnabled = Entry_t07field03_02.IsEnabled = ResetLabel_t07field03_02.IsEnabled = t07field04_1.IsEnabled = t07Picker04_1.IsEnabled = true;

                    Label_t07field03_03.IsEnabled = DatePicker_t07field03_03.IsEnabled = Entry_t07field03_03.IsEnabled = ResetLabel_t07field03_03.IsEnabled = Label_t07field03_04.IsEnabled = DatePicker_t07field03_04.IsEnabled = Entry_t07field03_04.IsEnabled = ResetLabel_t07field03_04.IsEnabled = t07field04_2.IsEnabled = t07Picker04_2.IsEnabled = false;

                    t07field02.Opacity = t07Picker02.Opacity = t07Field03.Opacity = Label_t07field03_01.Opacity = DatePicker_t07field03_01.Opacity = Entry_t07field03_01.Opacity = ResetLabel_t07field03_01.Opacity = Label_t07field03_02.Opacity = DatePicker_t07field03_02.Opacity = Entry_t07field03_02.Opacity = ResetLabel_t07field03_02.Opacity = t07field04_1.Opacity = t07Picker04_1.Opacity = 1.0;

                    Label_t07field03_03.Opacity = DatePicker_t07field03_03.Opacity = Entry_t07field03_03.Opacity = ResetLabel_t07field03_03.Opacity = Label_t07field03_04.Opacity = DatePicker_t07field03_04.Opacity = Entry_t07field03_04.Opacity = ResetLabel_t07field03_04.Opacity = t07field04_2.Opacity = t07Picker04_2.Opacity = 0.3;

                }
                else if (Erfassungsbogen.t07field01 == "2")
                {
                    t07Picker01.SelectedIndex = 1;

                    //Dekubitus 1 enable - Dekubitus 2 enable
                    t07field02.IsEnabled = t07Picker02.IsEnabled = t07Field03.IsEnabled = Label_t07field03_01.IsEnabled = DatePicker_t07field03_01.IsEnabled = Entry_t07field03_01.IsEnabled = ResetLabel_t07field03_01.IsEnabled = Label_t07field03_02.IsEnabled = DatePicker_t07field03_02.IsEnabled = Entry_t07field03_02.IsEnabled = ResetLabel_t07field03_02.IsEnabled = Label_t07field03_03.IsEnabled = DatePicker_t07field03_03.IsEnabled = Entry_t07field03_03.IsEnabled = ResetLabel_t07field03_03.IsEnabled = Label_t07field03_04.IsEnabled = DatePicker_t07field03_04.IsEnabled = Entry_t07field03_04.IsEnabled = ResetLabel_t07field03_04.IsEnabled = t07field04_1.IsEnabled = t07Picker04_1.IsEnabled = t07field04_2.IsEnabled = t07Picker04_2.IsEnabled = true;

                    t07field02.Opacity = t07Picker02.Opacity = t07Field03.Opacity = Label_t07field03_01.Opacity = DatePicker_t07field03_01.Opacity = Entry_t07field03_01.Opacity = ResetLabel_t07field03_01.Opacity = Label_t07field03_02.Opacity = DatePicker_t07field03_02.Opacity = Entry_t07field03_02.Opacity = ResetLabel_t07field03_02.Opacity = Label_t07field03_03.Opacity = DatePicker_t07field03_03.Opacity = Entry_t07field03_03.Opacity = ResetLabel_t07field03_03.Opacity = Label_t07field03_04.Opacity = DatePicker_t07field03_04.Opacity = Entry_t07field03_04.Opacity = ResetLabel_t07field03_04.Opacity = t07field04_1.Opacity = t07Picker04_1.Opacity = t07field04_2.Opacity = t07Picker04_2.Opacity = 1.0;
                }
                else if (Erfassungsbogen.t07field01 == "0")
                {
                    t07Picker01.SelectedIndex = 2;

                    //Dekubitus 1 disable - Dekubitus 2 disable
                    t07field02.IsEnabled = t07Picker02.IsEnabled = t07Field03.IsEnabled = Label_t07field03_01.IsEnabled = DatePicker_t07field03_01.IsEnabled = Entry_t07field03_01.IsEnabled = ResetLabel_t07field03_01.IsEnabled = Label_t07field03_02.IsEnabled = DatePicker_t07field03_02.IsEnabled = Entry_t07field03_02.IsEnabled = ResetLabel_t07field03_02.IsEnabled = Label_t07field03_03.IsEnabled = DatePicker_t07field03_03.IsEnabled = Entry_t07field03_03.IsEnabled = ResetLabel_t07field03_03.IsEnabled = Label_t07field03_04.IsEnabled = DatePicker_t07field03_04.IsEnabled = Entry_t07field03_04.IsEnabled = ResetLabel_t07field03_04.IsEnabled = t07field04_1.IsEnabled = t07Picker04_1.IsEnabled = t07field04_2.IsEnabled = t07Picker04_2.IsEnabled = false;

                    t07field02.Opacity = t07Picker02.Opacity = t07Field03.Opacity = Label_t07field03_01.Opacity = DatePicker_t07field03_01.Opacity = Entry_t07field03_01.Opacity = ResetLabel_t07field03_01.Opacity = Label_t07field03_02.Opacity = DatePicker_t07field03_02.Opacity = Entry_t07field03_02.Opacity = ResetLabel_t07field03_02.Opacity = Label_t07field03_03.Opacity = DatePicker_t07field03_03.Opacity = Entry_t07field03_03.Opacity = ResetLabel_t07field03_03.Opacity = Label_t07field03_04.Opacity = DatePicker_t07field03_04.Opacity = Entry_t07field03_04.Opacity = ResetLabel_t07field03_04.Opacity = t07field04_1.Opacity = t07Picker04_1.Opacity = t07field04_2.Opacity = t07Picker04_2.Opacity = 0.3;
                }
                else
                {
                    t07Picker01.SelectedIndex = -1;
                }

                // picker 3

                if (Erfassungsbogen.t07field02 == "1")
                {
                    t07Picker02.SelectedIndex = 0; // rb1 is the image file with checked box image
                }
                else if (Erfassungsbogen.t07field02 == "2")
                {
                    t07Picker02.SelectedIndex = 1;
                }
                else if (Erfassungsbogen.t07field02 == "3")
                {
                    t07Picker02.SelectedIndex = 2;
                }
                else if (Erfassungsbogen.t07field02 == "4")
                {
                    t07Picker02.SelectedIndex = 3;
                }
                else if (Erfassungsbogen.t07field02 == "0")
                {
                    t07Picker02.SelectedIndex = 4;
                }
                else
                {
                    t07Picker02.SelectedIndex = -1;
                }

                // picker 4_1

                if (Erfassungsbogen.t07field04 == "1")
                {
                    t07Picker04_1.SelectedIndex = 0; // rb1 is the image file with checked box image
                }
                else if (Erfassungsbogen.t07field04 == "2")
                {
                    t07Picker04_1.SelectedIndex = 1;
                }
                else if (Erfassungsbogen.t07field04 == "3")
                {
                    t07Picker04_1.SelectedIndex = 2;
                }
                else if (Erfassungsbogen.t07field04 == "0")
                {
                    t07Picker04_1.SelectedIndex = 3;
                }
                else
                {
                    t07Picker04_1.SelectedIndex = -1;
                }

                // picker 4_2 TODO

                if (Erfassungsbogen.t07field04_02 == "1")
                {
                    t07Picker04_2.SelectedIndex = 0; // rb1 is the image file with checked box image
                }
                else if (Erfassungsbogen.t07field04_02 == "2")
                {
                    t07Picker04_2.SelectedIndex = 1;
                }
                else if (Erfassungsbogen.t07field04_02 == "3")
                {
                    t07Picker04_2.SelectedIndex = 2;
                }
                else if (Erfassungsbogen.t07field04_02 == "0")
                {
                    t07Picker04_2.SelectedIndex = 3;
                }
                else
                {
                    t07Picker04_2.SelectedIndex = -1;
                }

                // date 7.3.1
                if (Erfassungsbogen.t07field03_01 != "")
                {
                    DatePicker_t07field03_01.Date = DateTime.ParseExact(Erfassungsbogen.t07field03_01.Replace('.', '/'), "dd/MM/yyyy", null).Date;
                    Entry_t07field03_01.Text = Erfassungsbogen.t07field03_01;
                }

                // date 7.3.2
                if (Erfassungsbogen.t07field03_02 != "")
                {
                    DatePicker_t07field03_02.Date = DateTime.ParseExact(Erfassungsbogen.t07field03_02.Replace('.', '/'), "dd/MM/yyyy", null).Date;
                    Entry_t07field03_02.Text = Erfassungsbogen.t07field03_02;
                }

                // date 7.3.3
                if (Erfassungsbogen.t07field03_03 != "")
                {
                    DatePicker_t07field03_03.Date = DateTime.ParseExact(Erfassungsbogen.t07field03_03.Replace('.', '/'), "dd/MM/yyyy", null).Date;
                    Entry_t07field03_03.Text = Erfassungsbogen.t07field03_03;
                }

                // date 7.3.4
                if (Erfassungsbogen.t07field03_04 != "")
                {
                    DatePicker_t07field03_04.Date = DateTime.ParseExact(Erfassungsbogen.t07field03_04.Replace('.', '/'), "dd/MM/yyyy", null).Date;
                    Entry_t07field03_04.Text = Erfassungsbogen.t07field03_04;
                }
                //ActivityIndicator = Idle
                IsLoading = false;

            }
            catch (Exception)
            {
                await DisplayAlert(AppResources.AppError, AppResources.AppErrorMsg, "OK");
            }
        }

        private void T07Picker00_SelectedIndexChanged(object sender, EventArgs e)
        {
            // t07 00
            if (t07Picker00.SelectedIndex == 0)
            {
                Erfassungsbogen.t07field00 = "1";
            }
            else if (t07Picker00.SelectedIndex == 1)
            {
                Erfassungsbogen.t07field00 = "0";
            }
        }

        private void T07Picker01_SelectedIndexChanged(object sender, EventArgs e)
        {
            // t07 01
            if (t07Picker01.SelectedIndex == 0)
            {
                Erfassungsbogen.t07field01 = "1";

                t07field02.IsEnabled =
                t07Picker02.IsEnabled =
                t07Field03.IsEnabled =

                Label_t07field03_01.IsEnabled =
                DatePicker_t07field03_01.IsEnabled =
                Entry_t07field03_01.IsEnabled =
                ResetLabel_t07field03_01.IsEnabled =

                Label_t07field03_02.IsEnabled =
                DatePicker_t07field03_02.IsEnabled =
                Entry_t07field03_02.IsEnabled =
                ResetLabel_t07field03_02.IsEnabled =

                t07field04_1.IsEnabled =
                t07Picker04_1.IsEnabled =
                t07field04_2.IsEnabled =
                t07Picker04_2.IsEnabled =
                t07field04_1.IsEnabled =
                t07Picker04_1.IsEnabled = true;

                //disable 2. dekubitus
                Label_t07field03_03.IsEnabled =
                DatePicker_t07field03_03.IsEnabled =
                Entry_t07field03_03.IsEnabled =
                ResetLabel_t07field03_03.IsEnabled =

                Label_t07field03_04.IsEnabled =
                DatePicker_t07field03_04.IsEnabled =
                Entry_t07field03_04.IsEnabled =
                ResetLabel_t07field03_04.IsEnabled =

                t07field04_2.IsEnabled =
                t07Picker04_2.IsEnabled = false;

                t07field02.Opacity =
               t07Picker02.Opacity =
                Label_t07field03_01.Opacity =
               DatePicker_t07field03_01.Opacity =
               Entry_t07field03_01.Opacity =
               ResetLabel_t07field03_01.Opacity =

                Label_t07field03_02.Opacity =
               DatePicker_t07field03_02.Opacity =
               Entry_t07field03_02.Opacity =
               ResetLabel_t07field03_02.Opacity =


               t07field04_1.Opacity =
               t07Picker04_1.Opacity = AppManager.QuestionOpacity;

                //disable 2. dekubitus
                Label_t07field03_03.Opacity =
              DatePicker_t07field03_03.Opacity =
              Entry_t07field03_03.Opacity =
              ResetLabel_t07field03_03.Opacity =

               Label_t07field03_04.Opacity =
              DatePicker_t07field03_04.Opacity =
              Entry_t07field03_04.Opacity =
              ResetLabel_t07field03_04.Opacity =
              t07field04_2.Opacity =
               t07Picker04_2.Opacity = AppManager.QuestionDisabledOpacity;
            }
            else if (t07Picker01.SelectedIndex == 1)
            {
                //mehrfach dekubitus
                Erfassungsbogen.t07field01 = "2";

                t07field02.IsEnabled =
               t07Picker02.IsEnabled =
               t07Field03.IsEnabled =
                               Label_t07field03_01.IsEnabled =
                    DatePicker_t07field03_01.IsEnabled =
                    Entry_t07field03_01.IsEnabled =
                    ResetLabel_t07field03_01.IsEnabled =

                    Label_t07field03_02.IsEnabled =
                    DatePicker_t07field03_02.IsEnabled =
                    Entry_t07field03_02.IsEnabled =
                    ResetLabel_t07field03_02.IsEnabled =

                    Label_t07field03_03.IsEnabled =
                    DatePicker_t07field03_03.IsEnabled =
                    Entry_t07field03_03.IsEnabled =
                    ResetLabel_t07field03_03.IsEnabled =

                    Label_t07field03_04.IsEnabled =
                    DatePicker_t07field03_04.IsEnabled =
                    Entry_t07field03_04.IsEnabled =
                    ResetLabel_t07field03_04.IsEnabled =
               t07field04_1.IsEnabled =
               t07Picker04_1.IsEnabled =
               t07field04_2.IsEnabled =
               t07Picker04_2.IsEnabled = true;

                t07field02.Opacity =
               t07Picker02.Opacity =
               t07Field03.Opacity =
               Label_t07field03_01.Opacity =
                DatePicker_t07field03_01.Opacity =
                   Entry_t07field03_01.Opacity =
                   ResetLabel_t07field03_01.Opacity =

                    Label_t07field03_02.Opacity =
                   DatePicker_t07field03_02.Opacity =
                   Entry_t07field03_02.Opacity =
                   ResetLabel_t07field03_02.Opacity =

                    Label_t07field03_03.Opacity =
                   DatePicker_t07field03_03.Opacity =
                   Entry_t07field03_03.Opacity =
                   ResetLabel_t07field03_03.Opacity =

                    Label_t07field03_04.Opacity =
                   DatePicker_t07field03_04.Opacity =
                   Entry_t07field03_04.Opacity =
                   ResetLabel_t07field03_04.Opacity =
               t07field04_1.Opacity =
               t07Picker04_1.Opacity =
               t07field04_2.Opacity =
               t07Picker04_2.Opacity = AppManager.QuestionOpacity;
            }
            else if (t07Picker01.SelectedIndex == 2)
            {
                //Kein dekubitus

                Erfassungsbogen.t07field01 = "0";

                t07field02.IsEnabled =
                t07Picker02.IsEnabled =
                t07Field03.IsEnabled =
                Label_t07field03_01.IsEnabled =
                DatePicker_t07field03_01.IsEnabled =
                Entry_t07field03_01.IsEnabled =
                ResetLabel_t07field03_01.IsEnabled =

                Label_t07field03_02.IsEnabled =
                DatePicker_t07field03_02.IsEnabled =
                Entry_t07field03_02.IsEnabled =
                ResetLabel_t07field03_02.IsEnabled =

                Label_t07field03_03.IsEnabled =
                DatePicker_t07field03_03.IsEnabled =
                Entry_t07field03_03.IsEnabled =
                ResetLabel_t07field03_03.IsEnabled =

                Label_t07field03_04.IsEnabled =
                DatePicker_t07field03_04.IsEnabled =
                Entry_t07field03_04.IsEnabled =
                ResetLabel_t07field03_04.IsEnabled =
                t07field04_1.IsEnabled =
                t07Picker04_1.IsEnabled =
                t07field04_2.IsEnabled =
                t07Picker04_2.IsEnabled = false;

                t07field02.Opacity =
                t07Picker02.Opacity =
                t07Field03.Opacity =
                Label_t07field03_01.Opacity =
                DatePicker_t07field03_01.Opacity =
                Entry_t07field03_01.Opacity =
                ResetLabel_t07field03_01.Opacity =

                Label_t07field03_02.Opacity =
                DatePicker_t07field03_02.Opacity =
                Entry_t07field03_02.Opacity =
                ResetLabel_t07field03_02.Opacity =

                Label_t07field03_03.Opacity =
                DatePicker_t07field03_03.Opacity =
                Entry_t07field03_03.Opacity =
                ResetLabel_t07field03_03.Opacity =

                Label_t07field03_04.Opacity =
                DatePicker_t07field03_04.Opacity =
                Entry_t07field03_04.Opacity =
                ResetLabel_t07field03_04.Opacity =
                t07field04_1.Opacity =
                t07Picker04_1.Opacity =
                t07field04_2.Opacity =
                t07Picker04_2.Opacity = AppManager.QuestionDisabledOpacity;
            }
        }

        private void T07Picker02_SelectedIndexChanged_2(object sender, EventArgs e)
        {
            if (t07Picker02.SelectedIndex == 0)
            {
                Erfassungsbogen.t07field02 = "1";
            }
            else if (t07Picker02.SelectedIndex == 1)
            {
                Erfassungsbogen.t07field02 = "2";
            }
            else if (t07Picker02.SelectedIndex == 2)
            {
                Erfassungsbogen.t07field02 = "3";
            }
            else if (t07Picker02.SelectedIndex == 3)
            {
                Erfassungsbogen.t07field02 = "4";
            }
            else if (t07Picker02.SelectedIndex == 4)
            {
                Erfassungsbogen.t07field02 = "0";
            }
        }

        private void T07Picker04_1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (t07Picker04_1.SelectedIndex == 0)
            {
                Erfassungsbogen.t07field04 = "1";
            }
            else if (t07Picker04_1.SelectedIndex == 1)
            {
                Erfassungsbogen.t07field04 = "2";
            }
            else if (t07Picker04_1.SelectedIndex == 2)
            {
                Erfassungsbogen.t07field04 = "3";
            }
            else if (t07Picker04_1.SelectedIndex == 3)
            {
                Erfassungsbogen.t07field04 = "0";
            }
        }

        private void T07Picker04_2_SelectedIndexChanged(object sender, EventArgs e)
        { //TODO
            if (t07Picker04_2.SelectedIndex == 0)
            {
                Erfassungsbogen.t07field04_02 = "1";
            }
            else if (t07Picker04_2.SelectedIndex == 1)
            {
                Erfassungsbogen.t07field04_02 = "2";
            }
            else if (t07Picker04_2.SelectedIndex == 2)
            {
                Erfassungsbogen.t07field04_02 = "3";
            }
            else if (t07Picker04_2.SelectedIndex == 3)
            {
                Erfassungsbogen.t07field04_02 = "0";
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
                        t07field00.TextColor = t07field01.TextColor = t07field02.TextColor = Entry_t07field03_01.TextColor = Label_t07field03_01.TextColor = DatePicker_t07field03_01.TextColor = Entry_t07field03_02.TextColor = Label_t07field03_02.TextColor = DatePicker_t07field03_02.TextColor = Entry_t07field03_03.TextColor = Label_t07field03_03.TextColor = DatePicker_t07field03_03.TextColor = t07field04_1.TextColor = t07field04_2.TextColor = AppManager.QuestionColor;

                        if (Erfassungsbogen.t07field00 == "" || Erfassungsbogen.t07field00 == null)
                        {
                            t07field00.TextColor = Color.Red;

                            if (Erfassungsbogen.t07field01 == "" || Erfassungsbogen.t07field01 == null)
                            {
                                t07field01.TextColor = Color.Red;
                            }
                        }
                        else
                        {
                            if (Erfassungsbogen.t07field01 == "" || Erfassungsbogen.t07field01 == null)
                            {
                                t07field01.TextColor = Color.Red;
                            }
                            else
                            {
                                //Kein Dekubitus
                                if (Erfassungsbogen.t07field01 == "0")
                                {
                                    Erfassungsbogen.t07field02 =
                                Erfassungsbogen.t07field03_01 =
                                Erfassungsbogen.t07field03_02 =
                                Erfassungsbogen.t07field03_03 =
                                Erfassungsbogen.t07field03_04 =
                                Erfassungsbogen.t07field04 =
                                Erfassungsbogen.t07field04_02 = "";

                                    WebRequest req = WebRequest.Create(DBManagement.DBConnection + "tbl_form_ebqe_t07_01_update.php");

                                    req.Method = "POST"; //POST
                                    req.Timeout = 15000;
                                    req.ContentType = "application/x-www-form-urlencoded";

                                    string postData = "mstr=" + App.user.selected_mstr_ebqe + "&bewonerid=" + App.user.selected_id_bewohner + "&t07field00=" + Erfassungsbogen.t07field00 + "&t07field01=" + Erfassungsbogen.t07field01 + "&t07field02=" + Erfassungsbogen.t07field02 + "&t07field03_01=" + Erfassungsbogen.t07field03_01 + "&t07field03_02=" + Erfassungsbogen.t07field03_02 + "&t07field03_03=" + Erfassungsbogen.t07field03_03 + "&t07field03_04=" + Erfassungsbogen.t07field03_04 + "&t07field04=" + Erfassungsbogen.t07field04 + "&t07field04_02=" + Erfassungsbogen.t07field04_02;

                                    byte[] byteArray = Encoding.UTF8.GetBytes(postData);

                                    req.ContentLength = byteArray.Length;

                                    Stream ds = await req.GetRequestStreamAsync();
                                    await ds.WriteAsync(byteArray, 0, byteArray.Length);
                                    ds.Close();

                                    await Navigation.PushAsync(new SearchPage());
                                }
                                //1x Dekubitus
                                if (Erfassungsbogen.t07field01 == "1")
                                {
                                    Erfassungsbogen.t07field03_03 =
                                    Erfassungsbogen.t07field03_04 =
                                    Erfassungsbogen.t07field04_02 = "";

                                    if (Erfassungsbogen.t07field02 != "" && Erfassungsbogen.t07field02 != null && Erfassungsbogen.t07field03_01 != "" && Erfassungsbogen.t07field03_01 != null && Erfassungsbogen.t07field03_02 != "" && Erfassungsbogen.t07field03_02 != null && Erfassungsbogen.t07field04 != "" && Erfassungsbogen.t07field04 != null)
                                    {
                                        WebRequest req = WebRequest.Create(DBManagement.DBConnection + "tbl_form_ebqe_t07_01_update.php");

                                        req.Method = "POST"; //POST
                                        req.Timeout = 15000;
                                        req.ContentType = "application/x-www-form-urlencoded";

                                        string postData = "mstr=" + App.user.selected_mstr_ebqe + "&bewonerid=" + App.user.selected_id_bewohner + "&t07field00=" + Erfassungsbogen.t07field00 + "&t07field01=" + Erfassungsbogen.t07field01 + "&t07field02=" + Erfassungsbogen.t07field02 + "&t07field03_01=" + Erfassungsbogen.t07field03_01 + "&t07field03_02=" + Erfassungsbogen.t07field03_02 + "&t07field03_03=" + Erfassungsbogen.t07field03_03 + "&t07field03_04=" + Erfassungsbogen.t07field03_04 + "&t07field04=" + Erfassungsbogen.t07field04 + "&t07field04_02=" + Erfassungsbogen.t07field04_02;

                                        byte[] byteArray = Encoding.UTF8.GetBytes(postData);

                                        req.ContentLength = byteArray.Length;

                                        Stream ds = await req.GetRequestStreamAsync();
                                        await ds.WriteAsync(byteArray, 0, byteArray.Length);
                                        ds.Close();

                                        await Navigation.PushAsync(new SearchPage());
                                    }
                                    else
                                    {
                                        if (Erfassungsbogen.t07field00 == "" || Erfassungsbogen.t07field00 == null)
                                        {
                                            t07field00.TextColor = Color.Red;
                                        }
                                        if (Erfassungsbogen.t07field01 == "" || Erfassungsbogen.t07field01 == null)
                                        {
                                            t07field01.TextColor = Color.Red;
                                        }
                                        if (Erfassungsbogen.t07field02 == "" || Erfassungsbogen.t07field02 == null)
                                        {
                                            t07field02.TextColor = Color.Red;
                                        }
                                        if (Erfassungsbogen.t07field03_01 == "" || Erfassungsbogen.t07field03_01 == null)
                                        {
                                            Entry_t07field03_01.TextColor = Color.Red;
                                            Label_t07field03_01.TextColor = Color.Red;
                                        }
                                        if (Erfassungsbogen.t07field03_02 == "" || Erfassungsbogen.t07field03_02 == null)
                                        {
                                            Entry_t07field03_02.TextColor = Color.Red;
                                            Label_t07field03_02.TextColor = Color.Red;
                                        }
                                        if (Erfassungsbogen.t07field04 == "" || Erfassungsbogen.t07field04 == null)
                                        {
                                            t07field04_1.TextColor = Color.Red;
                                        }

                                        await DisplayAlert(AppResources.Warning, AppResources.FieldsUnfilled, "OK");
                                        BackButton.Source = "ic_arrow_back_ios.png";
                                    }
                                }
                                //2x Dekubitus
                                if (Erfassungsbogen.t07field01 == "2")
                                {
                                    if (Erfassungsbogen.t07field02 != "" && Erfassungsbogen.t07field02 != null && Erfassungsbogen.t07field03_01 != "" && Erfassungsbogen.t07field03_01 != null && Erfassungsbogen.t07field03_02 != "" && Erfassungsbogen.t07field03_02 != null && Erfassungsbogen.t07field03_03 != "" && Erfassungsbogen.t07field03_03 != null && Erfassungsbogen.t07field03_04 != "" && Erfassungsbogen.t07field03_04 != null && Erfassungsbogen.t07field04 != "" && Erfassungsbogen.t07field04 != null && Erfassungsbogen.t07field04_02 != "" && Erfassungsbogen.t07field04_02 != null)
                                    {
                                        WebRequest req = WebRequest.Create(DBManagement.DBConnection + "tbl_form_ebqe_t07_01_update.php");

                                        req.Method = "POST"; //POST
                                        req.Timeout = 15000;
                                        req.ContentType = "application/x-www-form-urlencoded";

                                        string postData = "mstr=" + App.user.selected_mstr_ebqe + "&bewonerid=" + App.user.selected_id_bewohner + "&t07field00=" + Erfassungsbogen.t07field00 + "&t07field01=" + Erfassungsbogen.t07field01 + "&t07field02=" + Erfassungsbogen.t07field02 + "&t07field03_01=" + Erfassungsbogen.t07field03_01 + "&t07field03_02=" + Erfassungsbogen.t07field03_02 + "&t07field03_03=" + Erfassungsbogen.t07field03_03 + "&t07field03_04=" + Erfassungsbogen.t07field03_04 + "&t07field04=" + Erfassungsbogen.t07field04 + "&t07field04_02=" + Erfassungsbogen.t07field04_02;

                                        byte[] byteArray = Encoding.UTF8.GetBytes(postData);

                                        req.ContentLength = byteArray.Length;

                                        Stream ds = await req.GetRequestStreamAsync();
                                        await ds.WriteAsync(byteArray, 0, byteArray.Length);
                                        ds.Close();

                                        await Navigation.PushAsync(new SearchPage());
                                    }
                                    else
                                    {
                                        if (Erfassungsbogen.t07field00 == "" || Erfassungsbogen.t07field00 == null)
                                        {
                                            t07field00.TextColor = Color.Red;
                                        }
                                        if (Erfassungsbogen.t07field01 == "" || Erfassungsbogen.t07field01 == null)
                                        {
                                            t07field01.TextColor = Color.Red;
                                        }
                                        if (Erfassungsbogen.t07field02 == "" || Erfassungsbogen.t07field02 == null)
                                        {
                                            t07field02.TextColor = Color.Red;
                                        }
                                        if (Erfassungsbogen.t07field03_01 == "" || Erfassungsbogen.t07field03_01 == null)
                                        {
                                            Entry_t07field03_01.TextColor = Color.Red;
                                            Label_t07field03_01.TextColor = Color.Red;
                                        }
                                        if (Erfassungsbogen.t07field03_02 == "" || Erfassungsbogen.t07field03_02 == null)
                                        {
                                            Entry_t07field03_02.TextColor = Color.Red;
                                            Label_t07field03_02.TextColor = Color.Red;
                                        }
                                        if (Erfassungsbogen.t07field03_03 == "" || Erfassungsbogen.t07field03_03 == null)
                                        {
                                            Entry_t07field03_03.TextColor = Color.Red;
                                            Label_t07field03_03.TextColor = Color.Red;
                                        }
                                        if (Erfassungsbogen.t07field03_04 == "" || Erfassungsbogen.t07field03_04 == null)
                                        {
                                            Entry_t07field03_04.TextColor = Color.Red;
                                            Label_t07field03_04.TextColor = Color.Red;
                                        }
                                        if (Erfassungsbogen.t07field04 == "" || Erfassungsbogen.t07field04 == null)
                                        {
                                            t07field04_1.TextColor = Color.Red;
                                        }
                                        if (Erfassungsbogen.t07field04_02 == "" || Erfassungsbogen.t07field04_02 == null)
                                        {
                                            t07field04_2.TextColor = Color.Red;
                                        }
                                        await DisplayAlert(AppResources.Warning, AppResources.FieldsUnfilled, "OK");
                                        BackButton.Source = "ic_arrow_back_ios.png";
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        Erfassungsbogen.t07field00 = Erfassungsbogen.t07field01 = Erfassungsbogen.t07field02 = Erfassungsbogen.t07field03_01 = Erfassungsbogen.t07field03_02 = Erfassungsbogen.t07field03_03 = Erfassungsbogen.t07field03_04 = Erfassungsbogen.t07field04 = Erfassungsbogen.t07field04_02 = "";

                        WebRequest req = WebRequest.Create(DBManagement.DBConnection + "tbl_form_ebqe_t07_01_update.php");

                        req.Method = "POST"; //POST
                        req.Timeout = 15000;
                        req.ContentType = "application/x-www-form-urlencoded";

                        string postData = "mstr=" + App.user.selected_mstr_ebqe + "&bewonerid=" + App.user.selected_id_bewohner + "&t07field00=" + Erfassungsbogen.t07field00 + "&t07field01=" + Erfassungsbogen.t07field01 + "&t07field02=" + Erfassungsbogen.t07field02 + "&t07field03_01=" + Erfassungsbogen.t07field03_01 + "&t07field03_02=" + Erfassungsbogen.t07field03_02 + "&t07field03_03=" + Erfassungsbogen.t07field03_03 + "&t07field03_04=" + Erfassungsbogen.t07field03_04 + "&t07field04=" + Erfassungsbogen.t07field04 + "&t07field04_02=" + Erfassungsbogen.t07field04_02;

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

        private async void SaveDataAndGoToMenuButton_TappedAsync(object sender, EventArgs e)
        {
            SaveAllButton.Source = "ic_done_all_tapped.png";

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
                    t07field00.TextColor = t07field01.TextColor = t07field02.TextColor = Entry_t07field03_01.TextColor = Label_t07field03_01.TextColor = DatePicker_t07field03_01.TextColor = Entry_t07field03_02.TextColor = Label_t07field03_02.TextColor = DatePicker_t07field03_02.TextColor = Entry_t07field03_03.TextColor = Label_t07field03_03.TextColor = DatePicker_t07field03_03.TextColor = t07field04_1.TextColor = t07field04_2.TextColor = AppManager.QuestionColor;

                    if (Erfassungsbogen.t07field00 == "" || Erfassungsbogen.t07field00 == null)
                    {
                        t07field00.TextColor = Color.Red;

                        if (Erfassungsbogen.t07field01 == "" || Erfassungsbogen.t07field01 == null)
                        {
                            t07field01.TextColor = Color.Red;
                        }
                    }
                    else
                    {
                        if (Erfassungsbogen.t07field01 == "" || Erfassungsbogen.t07field01 == null)
                        {
                            t07field01.TextColor = Color.Red;
                        }
                        else
                        {
                            //Kein Dekubitus
                            if (Erfassungsbogen.t07field01 == "0")
                            {
                                Erfassungsbogen.t07field02 =
                                Erfassungsbogen.t07field03_01 =
                                Erfassungsbogen.t07field03_02 =
                                Erfassungsbogen.t07field03_03 =
                                Erfassungsbogen.t07field03_04 =
                                Erfassungsbogen.t07field04 =
                                Erfassungsbogen.t07field04_02 = "";

                                WebRequest req = WebRequest.Create(DBManagement.DBConnection + "tbl_form_ebqe_t07_01_update.php");

                                req.Method = "POST"; //POST
                                req.Timeout = 15000;
                                req.ContentType = "application/x-www-form-urlencoded";

                                string postData = "mstr=" + App.user.selected_mstr_ebqe + "&bewonerid=" + App.user.selected_id_bewohner + "&t07field00=" + Erfassungsbogen.t07field00 + "&t07field01=" + Erfassungsbogen.t07field01 + "&t07field02=" + Erfassungsbogen.t07field02
                                + "&t07field03_01=" + Erfassungsbogen.t07field03_01 + "&t07field03_02=" + Erfassungsbogen.t07field03_02 + "&t07field03_03=" + Erfassungsbogen.t07field03_03 + "&t07field03_04=" + Erfassungsbogen.t07field03_04 + "&t07field04=" + Erfassungsbogen.t07field04 + "&t07field04_02=" + Erfassungsbogen.t07field04_02;

                                byte[] byteArray = Encoding.UTF8.GetBytes(postData);

                                req.ContentLength = byteArray.Length;

                                Stream ds = await req.GetRequestStreamAsync();
                                await ds.WriteAsync(byteArray, 0, byteArray.Length);
                                ds.Close();

                                await Navigation.PushAsync(new SearchPage());
                            }
                            //1x Dekubitus
                            if (Erfassungsbogen.t07field01 == "1")
                            {

                                Erfassungsbogen.t07field03_03 =
                                Erfassungsbogen.t07field03_04 =
                                Erfassungsbogen.t07field04_02 = "";

                                if (Erfassungsbogen.t07field02 != "" && Erfassungsbogen.t07field02 != null && Erfassungsbogen.t07field03_01 != "" && Erfassungsbogen.t07field03_01 != null && Erfassungsbogen.t07field03_02 != "" && Erfassungsbogen.t07field03_02 != null && Erfassungsbogen.t07field04 != "" && Erfassungsbogen.t07field04 != null)
                                {

                                    WebRequest req = WebRequest.Create(DBManagement.DBConnection + "tbl_form_ebqe_t07_01_update.php");

                                    req.Method = "POST"; //POST
                                    req.Timeout = 15000;
                                    req.ContentType = "application/x-www-form-urlencoded";

                                    string postData = "mstr=" + App.user.selected_mstr_ebqe + "&bewonerid=" + App.user.selected_id_bewohner + "&t07field00=" + Erfassungsbogen.t07field00 + "&t07field01=" + Erfassungsbogen.t07field01 + "&t07field02=" + Erfassungsbogen.t07field02
                                    + "&t07field03_01=" + Erfassungsbogen.t07field03_01 + "&t07field03_02=" + Erfassungsbogen.t07field03_02 + "&t07field03_03=" + Erfassungsbogen.t07field03_03 + "&t07field03_04=" + Erfassungsbogen.t07field03_04 + "&t07field04=" + Erfassungsbogen.t07field04 + "&t07field04_02=" + Erfassungsbogen.t07field04_02;

                                    byte[] byteArray = Encoding.UTF8.GetBytes(postData);

                                    req.ContentLength = byteArray.Length;

                                    Stream ds = await req.GetRequestStreamAsync();
                                    await ds.WriteAsync(byteArray, 0, byteArray.Length);
                                    ds.Close();

                                    await Navigation.PushAsync(new SearchPage());
                                }
                                else
                                {
                                    if (Erfassungsbogen.t07field00 == "" || Erfassungsbogen.t07field00 == null)
                                    {
                                        t07field00.TextColor = Color.Red;
                                    }
                                    if (Erfassungsbogen.t07field01 == "" || Erfassungsbogen.t07field01 == null)
                                    {
                                        t07field01.TextColor = Color.Red;
                                    }
                                    if (Erfassungsbogen.t07field02 == "" || Erfassungsbogen.t07field02 == null)
                                    {
                                        t07field02.TextColor = Color.Red;
                                    }
                                    if (Erfassungsbogen.t07field03_01 == "" || Erfassungsbogen.t07field03_01 == null)
                                    {
                                        Entry_t07field03_01.TextColor = Color.Red;
                                        Label_t07field03_01.TextColor = Color.Red;
                                    }
                                    if (Erfassungsbogen.t07field03_02 == "" || Erfassungsbogen.t07field03_02 == null)
                                    {
                                        Entry_t07field03_02.TextColor = Color.Red;
                                        Label_t07field03_02.TextColor = Color.Red;
                                    }
                                    if (Erfassungsbogen.t07field04 == "" || Erfassungsbogen.t07field04 == null)
                                    {
                                        t07field04_1.TextColor = Color.Red;
                                    }

                                    await DisplayAlert(AppResources.Warning, AppResources.FieldsUnfilled, "OK");
                                    SaveAllButton.Source = "ic_done_all.png";
                                }
                            }
                            //2x Dekubitus
                            if (Erfassungsbogen.t07field01 == "2")
                            {
                                if (Erfassungsbogen.t07field02 != "" && Erfassungsbogen.t07field02 != null && Erfassungsbogen.t07field03_01 != "" && Erfassungsbogen.t07field03_01 != null && Erfassungsbogen.t07field03_02 != "" && Erfassungsbogen.t07field03_02 != null && Erfassungsbogen.t07field03_03 != "" && Erfassungsbogen.t07field03_03 != null && Erfassungsbogen.t07field03_04 != "" && Erfassungsbogen.t07field03_04 != null && Erfassungsbogen.t07field04 != "" && Erfassungsbogen.t07field04 != null && Erfassungsbogen.t07field04_02 != "" && Erfassungsbogen.t07field04_02 != null)
                                {
                                    WebRequest req = WebRequest.Create(DBManagement.DBConnection + "tbl_form_ebqe_t07_01_update.php");

                                    req.Method = "POST"; //POST
                                    req.Timeout = 15000;
                                    req.ContentType = "application/x-www-form-urlencoded";

                                    string postData = "mstr=" + App.user.selected_mstr_ebqe + "&bewonerid=" + App.user.selected_id_bewohner + "&t07field00=" + Erfassungsbogen.t07field00 + "&t07field01=" + Erfassungsbogen.t07field01 + "&t07field02=" + Erfassungsbogen.t07field02
                                    + "&t07field03_01=" + Erfassungsbogen.t07field03_01 + "&t07field03_02=" + Erfassungsbogen.t07field03_02 + "&t07field03_03=" + Erfassungsbogen.t07field03_03 + "&t07field03_04=" + Erfassungsbogen.t07field03_04 + "&t07field04=" + Erfassungsbogen.t07field04 + "&t07field04_02=" + Erfassungsbogen.t07field04_02;

                                    byte[] byteArray = Encoding.UTF8.GetBytes(postData);

                                    req.ContentLength = byteArray.Length;

                                    Stream ds = await req.GetRequestStreamAsync();
                                    await ds.WriteAsync(byteArray, 0, byteArray.Length);
                                    ds.Close();

                                    await Navigation.PushAsync(new SearchPage());
                                }
                                else
                                {
                                    if (Erfassungsbogen.t07field00 == "" || Erfassungsbogen.t07field00 == null)
                                    {
                                        t07field00.TextColor = Color.Red;
                                    }
                                    if (Erfassungsbogen.t07field01 == "" || Erfassungsbogen.t07field01 == null)
                                    {
                                        t07field01.TextColor = Color.Red;
                                    }
                                    if (Erfassungsbogen.t07field02 == "" || Erfassungsbogen.t07field02 == null)
                                    {
                                        t07field02.TextColor = Color.Red;
                                    }
                                    if (Erfassungsbogen.t07field03_01 == "" || Erfassungsbogen.t07field03_01 == null)
                                    {
                                        Entry_t07field03_01.TextColor = Color.Red;
                                        Label_t07field03_01.TextColor = Color.Red;
                                    }
                                    if (Erfassungsbogen.t07field03_02 == "" || Erfassungsbogen.t07field03_02 == null)
                                    {
                                        Entry_t07field03_02.TextColor = Color.Red;
                                        Label_t07field03_02.TextColor = Color.Red;
                                    }
                                    if (Erfassungsbogen.t07field03_03 == "" || Erfassungsbogen.t07field03_03 == null)
                                    {
                                        Entry_t07field03_03.TextColor = Color.Red;
                                        Label_t07field03_03.TextColor = Color.Red;
                                    }
                                    if (Erfassungsbogen.t07field03_04 == "" || Erfassungsbogen.t07field03_04 == null)
                                    {
                                        Entry_t07field03_04.TextColor = Color.Red;
                                        Label_t07field03_04.TextColor = Color.Red;
                                    }
                                    if (Erfassungsbogen.t07field04 == "" || Erfassungsbogen.t07field04 == null)
                                    {
                                        t07field04_1.TextColor = Color.Red;
                                    }
                                    if (Erfassungsbogen.t07field04_02 == "" || Erfassungsbogen.t07field04_02 == null)
                                    {
                                        t07field04_2.TextColor = Color.Red;
                                    }
                                    await DisplayAlert(AppResources.Warning, AppResources.FieldsUnfilled, "OK");
                                    SaveAllButton.Source = "ic_done_all.png";
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
                        WebRequest req = WebRequest.Create(DBManagement.DBConnection + "tbl_form_ebqe_t07_01_update_clear.php");

                        req.Method = "POST"; //POST
                        req.Timeout = 15000;
                        req.ContentType = "application/x-www-form-urlencoded";

                        string postData = "mstr=" + App.user.selected_mstr_ebqe + "&bewonerid=" + App.user.selected_id_bewohner;

                        byte[] byteArray = Encoding.UTF8.GetBytes(postData);

                        req.ContentLength = byteArray.Length;

                        Stream ds = await req.GetRequestStreamAsync();
                        await ds.WriteAsync(byteArray, 0, byteArray.Length);
                        ds.Close();

                        Erfassungsbogen.loadedFromDB = false;

                        await Navigation.PushAsync(new SearchPage());
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

        #region t07field03_01

        private void ResetLabel_t07field03_01_Tapped(object sender, EventArgs e)
        {
            Erfassungsbogen.t07field03_01 = "";
            Entry_t07field03_01.Text = "";
        }

        private void Entry_t07field03_01_Focused(object sender, FocusEventArgs e)
        {
            Entry_t07field03_01.Unfocus();
            DatePicker_t07field03_01.Focus();
        }

        private void DatePicker_t07field03_01_Unfocused(object sender, DateChangedEventArgs e)
        {
            Erfassungsbogen.t07field03_01 = DatePicker_t07field03_01.Date.ToString("dd.MM.yyyy");
            Entry_t07field03_01.Text = DatePicker_t07field03_01.Date.ToString("dd.MM.yyyy");
        }

        private void DatePicker_t07field03_01_DateSelected(object sender, DateChangedEventArgs e)
        {
            Erfassungsbogen.t07field03_01 = DatePicker_t07field03_01.Date.ToString("dd.MM.yyyy");
            Entry_t07field03_01.Text = DatePicker_t07field03_01.Date.ToString("dd.MM.yyyy");
        }

        #endregion

        #region t07field03_02

        private void ResetLabel_t07field03_02_Tapped(object sender, EventArgs e)
        {
            Erfassungsbogen.t07field03_02 = "";
            Entry_t07field03_02.Text = "";
        }

        private void Entry_t07field03_02_Focused(object sender, FocusEventArgs e)
        {
            Entry_t07field03_02.Unfocus();
            DatePicker_t07field03_02.Focus();
        }

        private void DatePicker_t07field03_02_Unfocused(object sender, DateChangedEventArgs e)
        {
            Erfassungsbogen.t07field03_02 = DatePicker_t07field03_02.Date.ToString("dd.MM.yyyy");
            Entry_t07field03_02.Text = DatePicker_t07field03_02.Date.ToString("dd.MM.yyyy");
        }

        private void DatePicker_t07field03_02_DateSelected(object sender, DateChangedEventArgs e)
        {
            Erfassungsbogen.t07field03_02 = DatePicker_t07field03_02.Date.ToString("dd.MM.yyyy");
            Entry_t07field03_02.Text = DatePicker_t07field03_02.Date.ToString("dd.MM.yyyy");
        }

        #endregion

        #region t07field03_03

        private void ResetLabel_t07field03_03_Tapped(object sender, EventArgs e)
        {
            Erfassungsbogen.t07field03_03 = "";
            Entry_t07field03_03.Text = "";
        }

        private void Entry_t07field03_03_Focused(object sender, FocusEventArgs e)
        {
            Entry_t07field03_03.Unfocus();
            DatePicker_t07field03_03.Focus();
        }

        private void DatePicker_t07field03_03_Unfocused(object sender, DateChangedEventArgs e)
        {
            Erfassungsbogen.t07field03_03 = DatePicker_t07field03_03.Date.ToString("dd.MM.yyyy");
            Entry_t07field03_03.Text = DatePicker_t07field03_03.Date.ToString("dd.MM.yyyy");
        }

        private void DatePicker_t07field03_03_DateSelected(object sender, DateChangedEventArgs e)
        {
            Erfassungsbogen.t07field03_03 = DatePicker_t07field03_03.Date.ToString("dd.MM.yyyy");
            Entry_t07field03_03.Text = DatePicker_t07field03_03.Date.ToString("dd.MM.yyyy");
        }

        #endregion

        #region t07field03_04

        private void ResetLabel_t07field03_04_Tapped(object sender, EventArgs e)
        {
            Erfassungsbogen.t07field03_04 = "";
            Entry_t07field03_04.Text = "";
        }

        private void Entry_t07field03_04_Focused(object sender, FocusEventArgs e)
        {
            Entry_t07field03_04.Unfocus();
            DatePicker_t07field03_04.Focus();
        }

        private void DatePicker_t07field03_04_Unfocused(object sender, DateChangedEventArgs e)
        {
            Erfassungsbogen.t07field03_04 = DatePicker_t07field03_04.Date.ToString("dd.MM.yyyy");
            Entry_t07field03_04.Text = DatePicker_t07field03_04.Date.ToString("dd.MM.yyyy");
        }

        private void DatePicker_t07field03_04_DateSelected(object sender, DateChangedEventArgs e)
        {
            Erfassungsbogen.t07field03_04 = DatePicker_t07field03_04.Date.ToString("dd.MM.yyyy");
            Entry_t07field03_04.Text = DatePicker_t07field03_04.Date.ToString("dd.MM.yyyy");
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