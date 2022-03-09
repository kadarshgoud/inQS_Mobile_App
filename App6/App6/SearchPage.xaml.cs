using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using App6.Management;
using App6.Model;
using App6.Resources;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.ComponentModel;

namespace App6
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SearchPage : ContentPage, INotifyPropertyChanged
    {
        //  public string endedatum = DateTime.Now.ToString("dd.MM.yyy");

        // Mathematical Part 
        public double Each_field_value_Allgemeine = (double)100 / 8;
        public double Each_field_value_mobilitat = (double)100 / 6;
        public double Each_field_value_kognitive = (double)100 / 11;
        public double Each_field_value_verhalt = (double)100 / 13;
        public double Each_field_value_selbst = (double)100 / 15;
        public double Each_field_value_bewalt = (double)100 / 16;
        public double Each_field_value_gestalt = (double)100 / 6;
        public double Each_field_value_dekubitus = (double)100 / 2;
        public double Each_field_value_kopergrosse = (double)100 / 3;
        public double Each_field_value_sturzflogen = (double)100 / 1;
        public double Each_field_value_freihalten = (double)100 / 2;
        public double Each_field_value_schmerzen = (double)100 / 1;
        public double Each_field_value_Heimzug = (double)100 / 1;
        public double Each_field_value_Einschaetzung = (double)100 / 1;
        public double Each_field_value_medikamente = (double)100 / 3;
        public double Each_field_value_bewegung = (double)100 / 1;
        public double Each_field_value_dokumention = (double)100 / 2;

        List<Data> categories = new List<Data>
           {
            new Data{Name = "0. Allgemeines", Tap = "Tapped_1" , Percent = "0%", Level =0},
            new Data{Name = "1. Mobilität", Tap = "Tapped_3",Percent = "0%", Level = 0},
            new Data{Name = "2. Kognitive und Kommunikative Fahigkeiten", Tap = "Tapped_2",Percent = "0%", Level =0},
            new Data{Name = "3. Verhaltensweisen und psychische...", Tap = "Tapped_4",Percent = "0%", Level =0},
            new Data{Name = "4. Selbstversorgung", Tap = "Tapped_5",Percent = "0%", Level =0},
            new Data{Name = "5. Bewältigung von und selbstständiger...", Tap = "Tapped_6",Percent = "0%", Level =0},
            new Data{Name = "6. Gestaltung des Alltagslebens...", Tap = "Tapped_7",Percent = "0%", Level =0},
            new Data{Name = "7. Dekubitus", Tap = "Tapped_8",Percent = "0%", Level =0},
            new Data{Name = "8. Körpergroße und Gewicht", Tap = "Tapped_9",Percent = "0%", Level =0},
            new Data{Name = "9. Sturzfolgen", Tap = "Tapped_10",Percent = "0%", Level =0},
            new Data{Name = "10. Freiheitzeihende Maßnahmen", Tap = "Tapped_11",Percent = "0%", Level =0},
            new Data{Name = "11. Schmerzen", Tap = "Tapped_12",Percent = "0%", Level =0},
            new Data{Name = "12. Heimeinzug", Tap = "Tapped_13",Percent = "0%", Level =0},
            new Data{Name = "13. Einschätzung von Verhaltensweisen", Tap = "Tapped_14",Percent = "0%", Level =0},
            new Data{Name = "14. Medikamente", Tap = "Tapped_15",Percent = "0%", Level =0},
            new Data{Name = "15. Bewegungseinschränkung", Tap = "Tapped_16",Percent = "0%", Level =0},
            new Data{Name = "16. Dokumentation", Tap = "Tapped_17",Percent = "0%", Level =0},
            new Data{Name = "Erhebungsbogen abschließen", Tap = "Tapped_17",Percent = "0%", Level =0},
        };

        public SearchPage()
        {
            InitializeComponent();
            BindingContext = this;
            MyList.ItemsSource = categories;

            ModulLabel.Text = AppResources.SurveyHeadline + " " + DBManagement.getYearCode(App.user.selected_mstr_ebqe) + " " + AppResources.SurveyHeadlineFor + " " + Erfassungsbogen.Bewohnerbezeichnung;
        }

        private void Sb_search_TextChanged(object sender, TextChangedEventArgs e)
        {
            var keyword = sb_search.Text;

            var result = categories.Where(x => x.Name.ToLower().Contains(keyword));

            MyList.ItemsSource = result;
        }

        private async void BackButton_TappedAsync(object sender, EventArgs e)
        {
            BackButton.Source = "ic_arrow_back_ios_tapped.png";

            await Navigation.PushAsync(new ListOfPatients());
        }

        private async Task MyList_ItemTappedAsync(object sender, ItemTappedEventArgs e)
        {
            var item = e.Item as Data;
            string led = item.Name.ToString();

            if (item.Name == "0. Allgemeines")
            {
                await Navigation.PushAsync(new Allgemeines_1());
            }
            else if (item.Name == "1. Mobilität")
            {
                await Navigation.PushAsync(new Mobilitaet_1());
            }
            else if (item.Name == "2. Kognitive und Kommunikative Fahigkeiten")
            {
                await Navigation.PushAsync(new Kognitive_1());
            }

            else if (item.Name == "3. Verhaltensweisen und psychische...")
            {
                await Navigation.PushAsync(new Verhaltensweisen_1());
            }

            else if (item.Name == "4. Selbstversorgung")
            {
                await Navigation.PushAsync(new Selbstversorgung_1());
            }

            else if (item.Name == "5. Bewältigung von und selbstständiger...")
            {
                await Navigation.PushAsync(new Bewaeltigung_1());
            }

            else if (item.Name == "6. Gestaltung des Alltagslebens...")
            {
                await Navigation.PushAsync(new Gestaltung_1());
            }
            else if (item.Name == "7. Dekubitus")
            {
                await Navigation.PushAsync(new Dekubitus_1());
            }
            else if (item.Name == "8. Körpergroße und Gewicht")
            {
                await Navigation.PushAsync(new Koerpergroesse_1());
            }
            else if (item.Name == "9. Sturzfolgen")
            {
                await Navigation.PushAsync(new Sturzfolgen());
            }
            else if (item.Name == "10. Freiheitzeihende Maßnahmen")
            {
                await Navigation.PushAsync(new FreiheitsentziehendeMassnahmen_1());
            }
            else if (item.Name == "11. Schmerzen")
            {
                await Navigation.PushAsync(new Schmerzen_1());
            }
            else if (item.Name == "12. Heimeinzug")
            {
                await Navigation.PushAsync(new Heimeinzug_1());
            }
            else if (item.Name == "13. Einschätzung von Verhaltensweisen")
            {
                await Navigation.PushAsync(new Einschaetzung());
            }
            else if (item.Name == "14. Medikamente")
            {
                await Navigation.PushAsync(new Medikamente_1());
            }
            else if (item.Name == "15. Bewegungseinschränkung")
            {
                await Navigation.PushAsync(new Bewegungseinschraenkungen());
            }
            else if (item.Name == "16. Dokumentation")
            {
                await Navigation.PushAsync(new Dokumentation_1());
            }
            else if (item.Name == "Erhebungsbogen abschließen")
            {
                try
                {
                    if (App.user.selected_mstr_ebqe == DBManagement.CurrentEvaluationID)
                    {
                        var FinishButton = await DisplayAlert("Bogenabschluss", "Möchten Sie diesen Bogen wirklich abschließen?", AppResources.Yes, AppResources.No);
                        if (FinishButton == true)
                        {
                            Erfassungsbogen.endedatum = DateTime.Now.ToString("dd.MM.yyy");

                            var total_sum = (Erfassungsbogen.alg_sum + Erfassungsbogen.mobilitat_sum + Erfassungsbogen.kognitive_sum + Erfassungsbogen.verhalt_sum + Erfassungsbogen.selbst_sum + Erfassungsbogen.bewalt_sum + Erfassungsbogen.gestalt_sum + Erfassungsbogen.dekubitus_sum + Erfassungsbogen.kopergrosse_sum + Erfassungsbogen.sturzfolgen_sum + Erfassungsbogen.freihalten_sum + Erfassungsbogen.schmerzen_sum + Erfassungsbogen.Heimzug_sum + Erfassungsbogen.Einschatzung_sum + Erfassungsbogen.medikamente_sum + Erfassungsbogen.bewgung_sum + Erfassungsbogen.dokumention_sum) / 17;

                            if (total_sum == 100)
                            {
                                WebRequest req = WebRequest.Create(DBManagement.DBConnection + "tbl_form_ebqe_update_ende_endedatum.php");

                                req.Method = "POST"; //POST
                                req.Timeout = 15000;
                                req.ContentType = "application/x-www-form-urlencoded";

                                string postData = "mstr=" + App.user.selected_mstr_ebqe + "&bewonerid=" + App.user.selected_id_bewohner + "&ende=" + Erfassungsbogen.ende + "&endedatum=" + Erfassungsbogen.endedatum;
                                byte[] byteArray = Encoding.UTF8.GetBytes(postData);

                                req.ContentLength = byteArray.Length;

                                Stream ds = await req.GetRequestStreamAsync();
                                await ds.WriteAsync(byteArray, 0, byteArray.Length);
                                ds.Close();

                                WebRequest req2 = WebRequest.Create(DBManagement.DBConnection + "tbl_form_ebqe_mobile_update_ende_endedatum.php");

                                req2.Method = "POST"; //POST
                                req2.Timeout = 15000;
                                req2.ContentType = "application/x-www-form-urlencoded";

                                string postData2 = "mstr=" + App.user.selected_mstr_ebqe + "&bewonerid=" + App.user.selected_id_bewohner + "&ende=" + Erfassungsbogen.ende + "&endedatum=" + Erfassungsbogen.endedatum;
                                byte[] byteArray2 = Encoding.UTF8.GetBytes(postData2);

                                req2.ContentLength = byteArray2.Length;

                                Stream ds2 = req2.GetRequestStream();
                                ds2.Write(byteArray2, 0, byteArray2.Length);

                                ds2.Close();

                                await DisplayAlert("Bogenabschluss", "Der Bogen wurde abgeschlossen.", "ok");
                                await Navigation.PushAsync(new ListOfPatients());
                            }
                            else
                            {
                                await DisplayAlert(AppResources.Warning, "Der Bogen konnte nicht abgeschlossen werden, da noch Pflichtfelder auszufüllen sind.", "OK");
                            }
                        }
                        else
                        {
                            //nicht abschließen
                        }
                    }
                    else
                    {
                        await DisplayAlert(AppResources.Warning, "Der Bogen kann nicht erneut abgeschlossen werden, da der Zeitraum bereits beendet ist.", "OK");
                    }
                }
                catch (Exception)
                {
                    await DisplayAlert(AppResources.AppError, AppResources.AppErrorMsg, "OK");
                }
            }
        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            Navigation.PushAsync(new FirstPage_2019_2());
        }

        private void TapGestureRecognizer_Tapped_1(object sender, EventArgs e)
        {
            //Already on SearchPage
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

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            try
            {
                //ActivityIndicator = Loading...
                IsLoading = true;

                if (Erfassungsbogen.loadedFromDB == false)
                {
                    #region T00

                    WebRequest req00 = WebRequest.Create(DBManagement.DBConnection + "tbl_form_ebqe_t00_01-05_read_all_fields.php");

                    req00.Method = "POST";
                    req00.ContentType = "application/x-www-form-urlencoded";

                    string postData00 = "id=" + App.user.selected_mstr_ebqe + "&einrichtung=" + App.user.id_org_einrichtung +
                                        "&wohnbereich=" + App.user.id_org_wohnbereich + "&bewonerid=" + App.user.selected_id_bewohner;
                    byte[] byteArray00 = Encoding.UTF8.GetBytes(postData00);

                    req00.ContentLength = byteArray00.Length;

                    Stream ds00 = req00.GetRequestStream();
                    ds00.Write(byteArray00, 0, byteArray00.Length);
                    ds00.Close();

                    WebResponse response00 = req00.GetResponse();

                    Stream dataStream00 = response00.GetResponseStream();

                    StreamReader reader00 = new StreamReader(dataStream00);


                    string s00 = reader00.ReadToEnd();

                    string[] split00 = s00.Split(new char[] { ':' });

                    Erfassungsbogen.t00field01 = split00[0];
                    Erfassungsbogen.t00field02_1 = split00[1];
                    Erfassungsbogen.t00field02_2 = split00[2];
                    Erfassungsbogen.t00field03 = split00[3];
                    Erfassungsbogen.t00field04 = split00[4];
                    Erfassungsbogen.t00field05 = split00[5];
                    Erfassungsbogen.t00field06 = split00[6];
                    Erfassungsbogen.t00field07_01 = split00[7];
                    Erfassungsbogen.t00field07_02 = split00[8];
                    Erfassungsbogen.t00field07_03 = split00[9];
                    Erfassungsbogen.t00field07_04 = split00[10];
                    Erfassungsbogen.t00field07_05 = split00[11];
                    Erfassungsbogen.t00field07_06 = split00[12];
                    Erfassungsbogen.t00field08 = split00[13];
                    Erfassungsbogen.t00field08_01 = split00[14];
                    Erfassungsbogen.t00field08_02 = split00[15];
                    Erfassungsbogen.t00field08_03 = split00[16];
                    Erfassungsbogen.t00field08_04 = split00[17];
                    Erfassungsbogen.t00field08_05 = split00[18];
                    Erfassungsbogen.t00field09 = split00[19];
                    Erfassungsbogen.t00field10 = split00[20];
                    Erfassungsbogen.t00field11 = split00[21];
                    Erfassungsbogen.t00field12 = split00[22];
                    Erfassungsbogen.t00field13_1 = split00[23];
                    Erfassungsbogen.t00field13_2 = split00[24];
                    Erfassungsbogen.t00field13_3 = split00[25];
                    Erfassungsbogen.t00field13_4 = split00[26];
                    Erfassungsbogen.t00field13_5 = split00[27];
                    Erfassungsbogen.t00field13_6 = split00[28];
                    Erfassungsbogen.t00field13_7 = split00[29];
                    Erfassungsbogen.t00field13_7_1 = split00[30];
                    Erfassungsbogen.t00field13_8 = split00[31];
                    Erfassungsbogen.t00field13_9 = split00[32];
                    Erfassungsbogen.t00field13_10 = split00[33];
                    Erfassungsbogen.t00field13_11 = split00[34];

                    #endregion

                    #region T01

                    WebRequest req01 = WebRequest.Create(DBManagement.DBConnection + "tbl_form_ebqe_t01_01-03_read_all_fields.php");

                    req01.Method = "POST";
                    req01.ContentType = "application/x-www-form-urlencoded";

                    string postData01 = "id=" + App.user.selected_mstr_ebqe + "&einrichtung=" + App.user.id_org_einrichtung +
                                        "&wohnbereich=" + App.user.id_org_wohnbereich + "&bewonerid=" + App.user.selected_id_bewohner;
                    byte[] byteArray01 = Encoding.UTF8.GetBytes(postData01);

                    req01.ContentLength = byteArray01.Length;

                    Stream ds01 = req01.GetRequestStream();
                    ds01.Write(byteArray01, 0, byteArray01.Length);
                    ds01.Close();

                    WebResponse response01 = req01.GetResponse();

                    Stream dataStream01 = response01.GetResponseStream();

                    StreamReader reader01 = new StreamReader(dataStream01);

                    string s01 = reader01.ReadToEnd();

                    string[] split01 = s01.Split(new char[] { ':' });

                    Erfassungsbogen.t01field01 = split01[0];
                    Erfassungsbogen.t01field02 = split01[1];
                    Erfassungsbogen.t01field03 = split01[2];
                    Erfassungsbogen.t01field04 = split01[3];
                    Erfassungsbogen.t01field05 = split01[4];
                    Erfassungsbogen.t01field06 = split01[5];

                    #endregion

                    #region T02

                    WebRequest req02 = WebRequest.Create(DBManagement.DBConnection + "tbl_form_ebqe_t02_01-03_read_all_fields.php");

                    req02.Method = "POST";
                    req02.ContentType = "application/x-www-form-urlencoded";

                    string postData02 = "id=" + App.user.selected_mstr_ebqe + "&einrichtung=" + App.user.id_org_einrichtung +
                                        "&wohnbereich=" + App.user.id_org_wohnbereich + "&bewonerid=" + App.user.selected_id_bewohner;
                    byte[] byteArray02 = Encoding.UTF8.GetBytes(postData02);

                    req02.ContentLength = byteArray02.Length;

                    Stream ds02 = req02.GetRequestStream();
                    ds02.Write(byteArray02, 0, byteArray02.Length);
                    ds02.Close();

                    WebResponse response02 = req02.GetResponse();

                    Stream dataStream02 = response02.GetResponseStream();

                    StreamReader reader02 = new StreamReader(dataStream02);


                    string s02 = reader02.ReadToEnd();

                    string[] split02 = s02.Split(new char[] { ':' });

                    Erfassungsbogen.t02field01 = split02[0];
                    Erfassungsbogen.t02field02 = split02[1];
                    Erfassungsbogen.t02field03 = split02[2];
                    Erfassungsbogen.t02field04 = split02[3];
                    Erfassungsbogen.t02field05 = split02[4];
                    Erfassungsbogen.t02field06 = split02[5];
                    Erfassungsbogen.t02field07 = split02[6];
                    Erfassungsbogen.t02field08 = split02[7];
                    Erfassungsbogen.t02field09 = split02[8];
                    Erfassungsbogen.t02field10 = split02[9];
                    Erfassungsbogen.t02field11 = split02[10];

                    #endregion

                    #region T03

                    WebRequest req03 = WebRequest.Create(DBManagement.DBConnection + "tbl_form_ebqe_t03_01-03_read_all_fields.php");

                    req03.Method = "POST";
                    req03.ContentType = "application/x-www-form-urlencoded";

                    string postData03 = "id=" + App.user.selected_mstr_ebqe + "&einrichtung=" + App.user.id_org_einrichtung +
                                        "&wohnbereich=" + App.user.id_org_wohnbereich + "&bewonerid=" + App.user.selected_id_bewohner;
                    byte[] byteArray03 = Encoding.UTF8.GetBytes(postData03);

                    req03.ContentLength = byteArray03.Length;

                    Stream ds03 = req03.GetRequestStream();
                    ds03.Write(byteArray03, 0, byteArray03.Length);
                    ds03.Close();

                    WebResponse response03 = req03.GetResponse();

                    Stream dataStream03 = response03.GetResponseStream();

                    StreamReader reader03 = new StreamReader(dataStream03);


                    string s03 = reader03.ReadToEnd();

                    string[] split03 = s03.Split(new char[] { ':' });

                    Erfassungsbogen.t03field01 = split03[0]; Erfassungsbogen.t03field02 = split03[1]; Erfassungsbogen.t03field03 = split03[2]; Erfassungsbogen.t03field04 = split03[3];
                    Erfassungsbogen.t03field05 = split03[4]; Erfassungsbogen.t03field06 = split03[5]; Erfassungsbogen.t03field07 = split03[6]; Erfassungsbogen.t03field08 = split03[7];
                    Erfassungsbogen.t03field09 = split03[8]; Erfassungsbogen.t03field10 = split03[9]; Erfassungsbogen.t03field11 = split03[10]; Erfassungsbogen.t03field12 = split03[11];
                    Erfassungsbogen.t03field13 = split03[12];

                    #endregion

                    #region T04

                    WebRequest req04 = WebRequest.Create(DBManagement.DBConnection + "tbl_form_ebqe_t04_01-05_read_all_fields.php");

                    req04.Method = "POST";
                    req04.ContentType = "application/x-www-form-urlencoded";

                    string postData04 = "id=" + App.user.selected_mstr_ebqe + "&einrichtung=" + App.user.id_org_einrichtung +
                                        "&wohnbereich=" + App.user.id_org_wohnbereich + "&bewonerid=" + App.user.selected_id_bewohner;
                    byte[] byteArray04 = Encoding.UTF8.GetBytes(postData04);

                    req04.ContentLength = byteArray04.Length;

                    Stream ds04 = req04.GetRequestStream();
                    ds04.Write(byteArray04, 0, byteArray04.Length);
                    ds04.Close();

                    WebResponse response04 = req04.GetResponse();

                    Stream dataStream04 = response04.GetResponseStream();

                    StreamReader reader04 = new StreamReader(dataStream04);

                    string s04 = reader04.ReadToEnd();

                    string[] split04 = s04.Split(new char[] { ':' });

                    Erfassungsbogen.t04fields2 = split04[0]; Erfassungsbogen.t04fields3 = split04[1]; Erfassungsbogen.t04field01 = split04[2]; Erfassungsbogen.t04field02 = split04[3];
                    Erfassungsbogen.t04field03 = split04[4]; Erfassungsbogen.t04field04 = split04[5]; Erfassungsbogen.t04field05 = split04[6]; Erfassungsbogen.t04field06 = split04[7];
                    Erfassungsbogen.t04field07 = split04[8]; Erfassungsbogen.t04field08 = split04[9]; Erfassungsbogen.t04field09 = split04[10]; Erfassungsbogen.t04field10 = split04[11];
                    Erfassungsbogen.t04field11 = split04[12]; Erfassungsbogen.t04field12 = split04[13]; Erfassungsbogen.t04field13 = split04[14];

                    #endregion

                    #region T05

                    WebRequest req05 = WebRequest.Create(DBManagement.DBConnection + "tbl_form_ebqe_t05_01-06_read_all_fields.php");

                    req05.Method = "POST";
                    req05.ContentType = "application/x-www-form-urlencoded";

                    string postData05 = "id=" + App.user.selected_mstr_ebqe + "&einrichtung=" + App.user.id_org_einrichtung +
                                        "&wohnbereich=" + App.user.id_org_wohnbereich + "&bewonerid=" + App.user.selected_id_bewohner;
                    byte[] byteArray05 = Encoding.UTF8.GetBytes(postData05);

                    req05.ContentLength = byteArray05.Length;

                    Stream ds05 = req05.GetRequestStream();
                    ds05.Write(byteArray05, 0, byteArray05.Length);
                    ds05.Close();

                    WebResponse response05 = req05.GetResponse();

                    Stream dataStream05 = response05.GetResponseStream();

                    StreamReader reader05 = new StreamReader(dataStream05);


                    string s05 = reader05.ReadToEnd();

                    string[] split05 = s05.Split(new char[] { ':' });

                    Erfassungsbogen.t05field01_03 = split05[0]; Erfassungsbogen.t05field01_02 = split05[1]; Erfassungsbogen.t05field02_03 = split05[2]; Erfassungsbogen.t05field02_02 = split05[3];
                    Erfassungsbogen.t05field03_03 = split05[4]; Erfassungsbogen.t05field03_02 = split05[5]; Erfassungsbogen.t05field04_03 = split05[6]; Erfassungsbogen.t05field04_02 = split05[7];
                    Erfassungsbogen.t05field05_03 = split05[8]; Erfassungsbogen.t05field05_02 = split05[9]; Erfassungsbogen.t05field06_03 = split05[10]; Erfassungsbogen.t05field06_02 = split05[11];
                    Erfassungsbogen.t05field07_03 = split05[12]; Erfassungsbogen.t05field07_02 = split05[13]; Erfassungsbogen.t05field08_03 = split05[14]; Erfassungsbogen.t05field08_02 = split05[15];
                    Erfassungsbogen.t05field09_03 = split05[16]; Erfassungsbogen.t05field09_02 = split05[17]; Erfassungsbogen.t05field10_03 = split05[18]; Erfassungsbogen.t05field10_02 = split05[19];
                    Erfassungsbogen.t05field11_03 = split05[20]; Erfassungsbogen.t05field11_02 = split05[21]; Erfassungsbogen.t05field12_03 = split05[22]; Erfassungsbogen.t05field12_02 = split05[23];
                    Erfassungsbogen.t05field13_03 = split05[24]; Erfassungsbogen.t05field13_02 = split05[25]; Erfassungsbogen.t05field14_03 = split05[26]; Erfassungsbogen.t05field14_02 = split05[27];
                    Erfassungsbogen.t05field15_03 = split05[28]; Erfassungsbogen.t05field15_02 = split05[29]; Erfassungsbogen.t05field16_01 = split05[30]; Erfassungsbogen.t05field16_02 = split05[31];

                    #endregion

                    #region T06

                    WebRequest req06 = WebRequest.Create(DBManagement.DBConnection + "tbl_form_ebqe_t06_01-03_read_all_fields.php");

                    req06.Method = "POST";
                    req06.ContentType = "application/x-www-form-urlencoded";

                    string postData06 = "id=" + App.user.selected_mstr_ebqe + "&einrichtung=" + App.user.id_org_einrichtung +
                                        "&wohnbereich=" + App.user.id_org_wohnbereich + "&bewonerid=" + App.user.selected_id_bewohner;
                    byte[] byteArray06 = Encoding.UTF8.GetBytes(postData06);

                    req06.ContentLength = byteArray06.Length;

                    Stream ds06 = req06.GetRequestStream();
                    ds06.Write(byteArray06, 0, byteArray06.Length);
                    ds06.Close();

                    WebResponse response06 = req06.GetResponse();

                    Stream dataStream06 = response06.GetResponseStream();

                    StreamReader reader06 = new StreamReader(dataStream06);

                    string s06 = reader06.ReadToEnd();

                    string[] split06 = s06.Split(new char[] { ':' });

                    Erfassungsbogen.t06field01 = split06[0]; Erfassungsbogen.t06field02 = split06[1]; Erfassungsbogen.t06field03 = split06[2]; Erfassungsbogen.t06field04 = split06[3];
                    Erfassungsbogen.t06field05 = split06[4]; Erfassungsbogen.t06field06 = split06[5];

                    #endregion

                    #region T07

                    WebRequest req07 = WebRequest.Create(DBManagement.DBConnection + "tbl_form_ebqe_t07_01_read_all_fields.php");

                    req07.Method = "POST";
                    req07.ContentType = "application/x-www-form-urlencoded";

                    string postData07 = "id=" + App.user.selected_mstr_ebqe + "&einrichtung=" + App.user.id_org_einrichtung +
                                        "&wohnbereich=" + App.user.id_org_wohnbereich + "&bewonerid=" + App.user.selected_id_bewohner;
                    byte[] byteArray07 = Encoding.UTF8.GetBytes(postData07);

                    req07.ContentLength = byteArray07.Length;

                    Stream ds07 = req07.GetRequestStream();
                    ds07.Write(byteArray07, 0, byteArray07.Length);
                    ds07.Close();

                    WebResponse response07 = req07.GetResponse();

                    Stream dataStream07 = response07.GetResponseStream();

                    StreamReader reader07 = new StreamReader(dataStream07);

                    string s07 = reader07.ReadToEnd();

                    string[] split07 = s07.Split(new char[] { ':' });

                    Erfassungsbogen.t07field00 = split07[0];
                    Erfassungsbogen.t07field01 = split07[1];
                    Erfassungsbogen.t07field02 = split07[2];
                    Erfassungsbogen.t07field03_01 = split07[3];
                    Erfassungsbogen.t07field03_02 = split07[4];
                    Erfassungsbogen.t07field03_03 = split07[5];
                    Erfassungsbogen.t07field03_04 = split07[6];
                    Erfassungsbogen.t07field04 = split07[7];
                    Erfassungsbogen.t07field04_02 = split07[8];

                    #endregion

                    #region T08

                    WebRequest req08 = WebRequest.Create(DBManagement.DBConnection + "tbl_form_ebqe_t08_01_read_all_fields.php");

                    req08.Method = "POST";
                    req08.ContentType = "application/x-www-form-urlencoded";

                    string postData08 = "id=" + App.user.selected_mstr_ebqe + "&einrichtung=" + App.user.id_org_einrichtung +
                                        "&wohnbereich=" + App.user.id_org_wohnbereich + "&bewonerid=" + App.user.selected_id_bewohner;
                    byte[] byteArray08 = Encoding.UTF8.GetBytes(postData08);

                    req08.ContentLength = byteArray08.Length;

                    Stream ds08 = req08.GetRequestStream();
                    ds08.Write(byteArray08, 0, byteArray08.Length);
                    ds08.Close();

                    WebResponse response08 = req08.GetResponse();

                    Stream dataStream08 = response08.GetResponseStream();

                    StreamReader reader08 = new StreamReader(dataStream08);

                    string s08 = reader08.ReadToEnd();

                    string[] split08 = s08.Split(new char[] { ':' });

                    Erfassungsbogen.t08field01 = split08[0];
                    Erfassungsbogen.t08field02_01 = split08[1];
                    Erfassungsbogen.t08field02_02 = split08[2];
                    Erfassungsbogen.t08field03_01 = split08[3];
                    Erfassungsbogen.t08field03_02 = split08[4];
                    Erfassungsbogen.t08field03_03 = split08[5];
                    Erfassungsbogen.t08field03_04 = split08[6];
                    Erfassungsbogen.t08field03_05 = split08[7];
                    Erfassungsbogen.t08field03_06 = split08[8];
                    Erfassungsbogen.t08field04 = split08[9];

                    #endregion

                    #region T09

                    WebRequest req09 = WebRequest.Create(DBManagement.DBConnection + "tbl_form_ebqe_t09_01_read_all_fields.php");

                    req09.Method = "POST";
                    req09.ContentType = "application/x-www-form-urlencoded";

                    string postData09 = "id=" + App.user.selected_mstr_ebqe + "&einrichtung=" + App.user.id_org_einrichtung +
                                        "&wohnbereich=" + App.user.id_org_wohnbereich + "&bewonerid=" + App.user.selected_id_bewohner;
                    byte[] byteArray09 = Encoding.UTF8.GetBytes(postData09);

                    req09.ContentLength = byteArray09.Length;

                    Stream ds09 = req09.GetRequestStream();
                    ds09.Write(byteArray09, 0, byteArray09.Length);
                    ds09.Close();

                    WebResponse response09 = req09.GetResponse();

                    Stream dataStream09 = response09.GetResponseStream();

                    StreamReader reader09 = new StreamReader(dataStream09);


                    string s09 = reader09.ReadToEnd();

                    string[] split09 = s09.Split(new char[] { ':' });

                    Erfassungsbogen.t09field01 = split09[0];
                    Erfassungsbogen.t09field02_01 = split09[1];
                    Erfassungsbogen.t09field02_02 = split09[2];
                    Erfassungsbogen.t09field02_03 = split09[3];
                    Erfassungsbogen.t09field02_04 = split09[4];
                    Erfassungsbogen.t09field02_05 = split09[5];
                    Erfassungsbogen.t09field02_06 = split09[6];

                    #endregion

                    #region T10

                    WebRequest req10 = WebRequest.Create(DBManagement.DBConnection + "tbl_form_ebqe_t10_01-02_read_all_fields.php");

                    req10.Method = "POST";
                    req10.ContentType = "application/x-www-form-urlencoded";

                    string postData10 = "id=" + App.user.selected_mstr_ebqe + "&einrichtung=" + App.user.id_org_einrichtung +
                                        "&wohnbereich=" + App.user.id_org_wohnbereich + "&bewonerid=" + App.user.selected_id_bewohner;
                    byte[] byteArray10 = Encoding.UTF8.GetBytes(postData10);

                    req10.ContentLength = byteArray10.Length;

                    Stream ds10 = req10.GetRequestStream();
                    ds10.Write(byteArray10, 0, byteArray10.Length);
                    ds10.Close();

                    WebResponse response10 = req10.GetResponse();

                    Stream dataStream10 = response10.GetResponseStream();

                    StreamReader reader10 = new StreamReader(dataStream10);

                    string s10 = reader10.ReadToEnd();

                    string[] split10 = s10.Split(new char[] { ':' });

                    Erfassungsbogen.t10field01 = split10[0]; Erfassungsbogen.t10field02_01 = split10[1]; Erfassungsbogen.t10field02_02 = split10[2]; Erfassungsbogen.t10field02_03 = split10[3];
                    Erfassungsbogen.t10field02_04 = split10[4]; Erfassungsbogen.t10field03 = split10[5]; Erfassungsbogen.t10field04 = split10[6]; Erfassungsbogen.t10field05 = split10[7];
                    Erfassungsbogen.t10field06 = split10[8]; Erfassungsbogen.t10field07 = split10[9];

                    #endregion

                    #region T11

                    WebRequest req11 = WebRequest.Create(DBManagement.DBConnection + "tbl_form_ebqe_t11_01-02_read_all_fields.php");

                    req11.Method = "POST";
                    req11.ContentType = "application/x-www-form-urlencoded";

                    string postData11 = "id=" + App.user.selected_mstr_ebqe + "&einrichtung=" + App.user.id_org_einrichtung +
                                        "&wohnbereich=" + App.user.id_org_wohnbereich + "&bewonerid=" + App.user.selected_id_bewohner;
                    byte[] byteArray11 = Encoding.UTF8.GetBytes(postData11);

                    req11.ContentLength = byteArray11.Length;

                    Stream ds11 = req11.GetRequestStream();
                    ds11.Write(byteArray11, 0, byteArray11.Length);
                    ds11.Close();

                    WebResponse response11 = req11.GetResponse();

                    Stream dataStream11 = response11.GetResponseStream();

                    StreamReader reader11 = new StreamReader(dataStream11);

                    string s11 = reader11.ReadToEnd();

                    string[] split11 = s11.Split(new char[] { ':' });

                    Erfassungsbogen.t11field01 = split11[0];
                    Erfassungsbogen.t11field01a = split11[1];
                    Erfassungsbogen.t11field02_01 = split11[2];
                    Erfassungsbogen.t11field02_02 = split11[3];
                    Erfassungsbogen.t11field02_03 = split11[4];
                    Erfassungsbogen.t11field02_04 = split11[5];
                    Erfassungsbogen.t11field02_05 = split11[6];
                    Erfassungsbogen.t11field02_06 = split11[7];
                    Erfassungsbogen.t11field03_01 = split11[8];
                    Erfassungsbogen.t11field03_02 = split11[9];
                    Erfassungsbogen.t11field04 = split11[10];

                    #endregion

                    #region T12

                    WebRequest req12 = WebRequest.Create(DBManagement.DBConnection + "tbl_form_ebqe_t12_01-02_read_all_fields.php");

                    req12.Method = "POST";
                    req12.ContentType = "application/x-www-form-urlencoded";

                    string postData12 = "id=" + App.user.selected_mstr_ebqe + "&einrichtung=" + App.user.id_org_einrichtung +
                                        "&wohnbereich=" + App.user.id_org_wohnbereich + "&bewonerid=" + App.user.selected_id_bewohner;
                    byte[] byteArray12 = Encoding.UTF8.GetBytes(postData12);

                    req12.ContentLength = byteArray12.Length;

                    Stream ds12 = req12.GetRequestStream();
                    ds12.Write(byteArray12, 0, byteArray12.Length);
                    ds12.Close();

                    WebResponse response12 = req12.GetResponse();

                    Stream dataStream12 = response12.GetResponseStream();

                    StreamReader reader12 = new StreamReader(dataStream12);


                    string s12 = reader12.ReadToEnd();

                    string[] split12 = s12.Split(new char[] { ':' });

                    Erfassungsbogen.t12field00 = split12[0]; Erfassungsbogen.t12field01_01 = split12[1]; Erfassungsbogen.t12field01_02 = split12[2]; Erfassungsbogen.t12field01_03 = split12[3];
                    Erfassungsbogen.t12field02_01 = split12[4]; Erfassungsbogen.t12field02_02 = split12[5]; Erfassungsbogen.t12field02_03_01 = split12[6];
                    Erfassungsbogen.t12field02_03_02 = split12[7]; Erfassungsbogen.t12field02_03_03 = split12[8]; Erfassungsbogen.t12field02_03_04 = split12[9]; Erfassungsbogen.t12field02_04 = split12[10];
                    Erfassungsbogen.t12field03 = split12[11];

                    #endregion

                    #region T13

                    WebRequest req13 = WebRequest.Create(DBManagement.DBConnection + "tbl_form_ebqe_t13_01_read_all_fields.php");

                    req13.Method = "POST";
                    req13.ContentType = "application/x-www-form-urlencoded";

                    string postData13 = "id=" + App.user.selected_mstr_ebqe + "&einrichtung=" + App.user.id_org_einrichtung +
                                        "&wohnbereich=" + App.user.id_org_wohnbereich + "&bewonerid=" + App.user.selected_id_bewohner;
                    byte[] byteArray13 = Encoding.UTF8.GetBytes(postData13);

                    req13.ContentLength = byteArray13.Length;

                    Stream ds13 = req13.GetRequestStream();
                    ds13.Write(byteArray13, 0, byteArray13.Length);
                    ds13.Close();

                    WebResponse response13 = req13.GetResponse();

                    Stream dataStream13 = response13.GetResponseStream();

                    StreamReader reader13 = new StreamReader(dataStream13);

                    string s13 = reader13.ReadToEnd();

                    string[] split13 = s13.Split(new char[] { ':' });

                    Erfassungsbogen.t13field01 = split13[0];

                    #endregion

                    #region T14

                    WebRequest req14 = WebRequest.Create(DBManagement.DBConnection + "tbl_form_ebqe_t14_01_read_all_fields.php");

                    req14.Method = "POST";
                    req14.ContentType = "application/x-www-form-urlencoded";

                    string postData14 = "id=" + App.user.selected_mstr_ebqe + "&einrichtung=" + App.user.id_org_einrichtung +
                                        "&wohnbereich=" + App.user.id_org_wohnbereich + "&bewonerid=" + App.user.selected_id_bewohner;
                    byte[] byteArray14 = Encoding.UTF8.GetBytes(postData14);

                    req14.ContentLength = byteArray14.Length;

                    Stream ds14 = req14.GetRequestStream();
                    ds14.Write(byteArray14, 0, byteArray14.Length);
                    ds14.Close();

                    WebResponse response14 = req14.GetResponse();

                    Stream dataStream14 = response14.GetResponseStream();

                    StreamReader reader14 = new StreamReader(dataStream14);

                    string s14 = reader14.ReadToEnd();

                    string[] split14 = s14.Split(new char[] { ':' });

                    Erfassungsbogen.t14field01 = split14[0];
                    Erfassungsbogen.t14field02 = split14[1];
                    Erfassungsbogen.t14field03 = split14[2];

                    #endregion

                    #region T15

                    WebRequest req15 = WebRequest.Create(DBManagement.DBConnection + "tbl_form_ebqe_t15_01_read_all_fields.php");

                    req15.Method = "POST";
                    req15.ContentType = "application/x-www-form-urlencoded";

                    string postData15 = "id=" + App.user.selected_mstr_ebqe + "&einrichtung=" + App.user.id_org_einrichtung +
                                        "&wohnbereich=" + App.user.id_org_wohnbereich + "&bewonerid=" + App.user.selected_id_bewohner;
                    byte[] byteArray15 = Encoding.UTF8.GetBytes(postData15);

                    req15.ContentLength = byteArray15.Length;

                    Stream ds15 = req15.GetRequestStream();
                    ds15.Write(byteArray15, 0, byteArray15.Length);
                    ds15.Close();

                    WebResponse response15 = req15.GetResponse();

                    Stream dataStream15 = response15.GetResponseStream();

                    StreamReader reader15 = new StreamReader(dataStream15);

                    string s15 = reader15.ReadToEnd();

                    string[] split15 = s15.Split(new char[] { ':' });

                    Erfassungsbogen.t15field01 = split15[0];
                    Erfassungsbogen.t15field02_01 = split15[1];
                    Erfassungsbogen.t15field02_02 = split15[2];
                    Erfassungsbogen.t15field02_03 = split15[3];
                    Erfassungsbogen.t15field02_04 = split15[4];
                    Erfassungsbogen.t15field02_05 = split15[5];
                    Erfassungsbogen.t15field03 = split15[6];

                    #endregion

                    #region T16

                    WebRequest req16 = WebRequest.Create(DBManagement.DBConnection + "tbl_form_ebqe_t16_01-02_read_all_fields.php");

                    req16.Method = "POST";
                    req16.ContentType = "application/x-www-form-urlencoded";

                    string postData16 = "id=" + App.user.selected_mstr_ebqe + "&einrichtung=" + App.user.id_org_einrichtung + "&wohnbereich=" + App.user.id_org_wohnbereich + "&bewonerid=" + App.user.selected_id_bewohner;
                    byte[] byteArray16 = Encoding.UTF8.GetBytes(postData16);

                    req16.ContentLength = byteArray16.Length;

                    Stream ds16 = req16.GetRequestStream();
                    ds16.Write(byteArray16, 0, byteArray16.Length);
                    ds16.Close();

                    WebResponse response16 = req16.GetResponse();

                    Stream dataStream16 = response16.GetResponseStream();

                    StreamReader reader16 = new StreamReader(dataStream16);

                    string s16 = reader16.ReadToEnd();

                    string[] split16 = s16.Split(new char[] { ':' });

                    Erfassungsbogen.t16field01 = split16[0];
                    Erfassungsbogen.t16field02 = split16[1];
                    Erfassungsbogen.t16field03 = split16[2];
                    Erfassungsbogen.t16field04 = split16[3];
                    Erfassungsbogen.t16field05 = split16[4];
                    Erfassungsbogen.t16field06 = split16[5];
                    Erfassungsbogen.t16field07 = split16[6];
                    Erfassungsbogen.t16field08 = split16[7];
                    Erfassungsbogen.t16field09 = split16[8];
                    Erfassungsbogen.t16field10 = split16[9];
                    Erfassungsbogen.t16field11 = split16[10];

                    #endregion

                    Erfassungsbogen.loadedFromDB = true;
                }

                #region Sum Calculations

                #region T00

                Erfassungsbogen.alg_sum = 0;

                if (Erfassungsbogen.t00field04 != "" && Erfassungsbogen.t00field04 != null)
                {
                    Erfassungsbogen.alg_sum = Erfassungsbogen.alg_sum + Each_field_value_Allgemeine;
                }

                if (Erfassungsbogen.t00field05 != "" && Erfassungsbogen.t00field05 != null)
                {
                    Erfassungsbogen.alg_sum = Erfassungsbogen.alg_sum + Each_field_value_Allgemeine;
                }

                if (Erfassungsbogen.t00field06 != "" && Erfassungsbogen.t00field06 != null)
                {
                    Erfassungsbogen.alg_sum = Erfassungsbogen.alg_sum + Each_field_value_Allgemeine;
                }

                if (Erfassungsbogen.t00field08 != "" && Erfassungsbogen.t00field08 != null)
                {
                    Erfassungsbogen.alg_sum = Erfassungsbogen.alg_sum + Each_field_value_Allgemeine;
                }

                if (Erfassungsbogen.t00field09 != "" && Erfassungsbogen.t00field09 != null)
                {
                    Erfassungsbogen.alg_sum = Erfassungsbogen.alg_sum + Each_field_value_Allgemeine;
                }

                if (Erfassungsbogen.t00field10 != "" && Erfassungsbogen.t00field10 != null)
                {
                    Erfassungsbogen.alg_sum = Erfassungsbogen.alg_sum + Each_field_value_Allgemeine;
                }

                if (Erfassungsbogen.t00field11 != "" && Erfassungsbogen.t00field11 != null)
                {
                    Erfassungsbogen.alg_sum = Erfassungsbogen.alg_sum + Each_field_value_Allgemeine;
                }

                if ((Erfassungsbogen.t00field13_1 != "" && Erfassungsbogen.t00field13_1 != null) || (Erfassungsbogen.t00field13_2 != "" && Erfassungsbogen.t00field13_2 != null) || (Erfassungsbogen.t00field13_3 != "" && Erfassungsbogen.t00field13_3 != null) || (Erfassungsbogen.t00field13_4 != "" && Erfassungsbogen.t00field13_4 != null) || (Erfassungsbogen.t00field13_5 != "" && Erfassungsbogen.t00field13_5 != null) || (Erfassungsbogen.t00field13_6 != "" && Erfassungsbogen.t00field13_6 != null) || (Erfassungsbogen.t00field13_7 != "" && Erfassungsbogen.t00field13_7 != null) || (Erfassungsbogen.t00field13_7_1 != "" && Erfassungsbogen.t00field13_7_1 != null) || (Erfassungsbogen.t00field13_8 != "" && Erfassungsbogen.t00field13_8 != null) || (Erfassungsbogen.t00field13_9 != "" && Erfassungsbogen.t00field13_9 != null) || (Erfassungsbogen.t00field13_10 != "" && Erfassungsbogen.t00field13_10 != null) || (Erfassungsbogen.t00field13_11 != "" && Erfassungsbogen.t00field13_11 != null))
                {
                    Erfassungsbogen.alg_sum = Erfassungsbogen.alg_sum + Each_field_value_Allgemeine;
                }

                // if it is 99.99 
                if (Erfassungsbogen.alg_sum >= 99 && Erfassungsbogen.alg_sum <= 100)
                {
                    Erfassungsbogen.alg_sum = 100;
                    categories.Where(a => a.Name == "0. Allgemeines").FirstOrDefault().Percent = Erfassungsbogen.alg_sum + "%";
                    categories.Where(a => a.Name == "0. Allgemeines").FirstOrDefault().Level = Erfassungsbogen.alg_sum / 100;
                }
                else
                {
                    categories.Where(a => a.Name == "0. Allgemeines").FirstOrDefault().Level = Erfassungsbogen.alg_sum / 100;
                    categories.Where(a => a.Name == "0. Allgemeines").FirstOrDefault().Percent = Math.Round(Erfassungsbogen.alg_sum) + "%";
                }

                #endregion

                #region T01
                Erfassungsbogen.mobilitat_sum = 0;

                if (Erfassungsbogen.t01field01 != "" && Erfassungsbogen.t01field01 != null)
                {
                    Erfassungsbogen.mobilitat_sum = Each_field_value_mobilitat;
                }
                if (Erfassungsbogen.t01field02 != "" && Erfassungsbogen.t01field02 != null)
                {
                    Erfassungsbogen.mobilitat_sum = Erfassungsbogen.mobilitat_sum + Each_field_value_mobilitat;
                }
                if (Erfassungsbogen.t01field03 != "" && Erfassungsbogen.t01field03 != null)
                {
                    Erfassungsbogen.mobilitat_sum = Erfassungsbogen.mobilitat_sum + Each_field_value_mobilitat;
                }
                if (Erfassungsbogen.t01field04 != "" && Erfassungsbogen.t01field04 != null)
                {
                    Erfassungsbogen.mobilitat_sum = Erfassungsbogen.mobilitat_sum + Each_field_value_mobilitat;
                }
                if (Erfassungsbogen.t01field05 != "" && Erfassungsbogen.t01field05 != null)
                {
                    Erfassungsbogen.mobilitat_sum = Erfassungsbogen.mobilitat_sum + Each_field_value_mobilitat;
                }
                if (Erfassungsbogen.t01field06 != "" && Erfassungsbogen.t01field06 != null)
                {
                    Erfassungsbogen.mobilitat_sum = Erfassungsbogen.mobilitat_sum + Each_field_value_mobilitat;
                }

                if (Erfassungsbogen.mobilitat_sum >= 99 && Erfassungsbogen.mobilitat_sum <= 100)
                {
                    Erfassungsbogen.mobilitat_sum = 100;
                    categories.Where(m => m.Name == "1. Mobilität").FirstOrDefault().Percent = Erfassungsbogen.mobilitat_sum + "%";
                    categories.Where(m => m.Name == "1. Mobilität").FirstOrDefault().Level = Erfassungsbogen.mobilitat_sum / 100;
                }
                else
                {
                    categories.Where(m => m.Name == "1. Mobilität").FirstOrDefault().Level = Erfassungsbogen.mobilitat_sum / 100;
                    categories.Where(m => m.Name == "1. Mobilität").FirstOrDefault().Percent = Math.Round(Erfassungsbogen.mobilitat_sum) + "%";
                }

                #endregion

                #region T02
                Erfassungsbogen.kognitive_sum = 0;

                if (Erfassungsbogen.t02field01 != "" && Erfassungsbogen.t02field01 != null)
                {
                    Erfassungsbogen.kognitive_sum = Each_field_value_kognitive;
                }
                if (Erfassungsbogen.t02field02 != "" && Erfassungsbogen.t02field02 != null)
                {
                    Erfassungsbogen.kognitive_sum = Erfassungsbogen.kognitive_sum + Each_field_value_kognitive;
                }
                if (Erfassungsbogen.t02field03 != "" && Erfassungsbogen.t02field03 != null)
                {
                    Erfassungsbogen.kognitive_sum = Erfassungsbogen.kognitive_sum + Each_field_value_kognitive;
                }
                if (Erfassungsbogen.t02field04 != "" && Erfassungsbogen.t02field04 != null)
                {
                    Erfassungsbogen.kognitive_sum = Erfassungsbogen.kognitive_sum + Each_field_value_kognitive;
                }
                if (Erfassungsbogen.t02field05 != "" && Erfassungsbogen.t02field05 != null)
                {
                    Erfassungsbogen.kognitive_sum = Erfassungsbogen.kognitive_sum + Each_field_value_kognitive;
                }
                if (Erfassungsbogen.t02field06 != "" && Erfassungsbogen.t02field06 != null)
                {
                    Erfassungsbogen.kognitive_sum = Erfassungsbogen.kognitive_sum + Each_field_value_kognitive;
                }
                if (Erfassungsbogen.t02field07 != "" && Erfassungsbogen.t02field07 != null)
                {
                    Erfassungsbogen.kognitive_sum = Erfassungsbogen.kognitive_sum + Each_field_value_kognitive;
                }
                if (Erfassungsbogen.t02field08 != "" && Erfassungsbogen.t02field08 != null)
                {
                    Erfassungsbogen.kognitive_sum = Erfassungsbogen.kognitive_sum + Each_field_value_kognitive;
                }
                if (Erfassungsbogen.t02field09 != "" && Erfassungsbogen.t02field09 != null)
                {
                    Erfassungsbogen.kognitive_sum = Erfassungsbogen.kognitive_sum + Each_field_value_kognitive;
                }
                if (Erfassungsbogen.t02field10 != "" && Erfassungsbogen.t02field10 != null)
                {
                    Erfassungsbogen.kognitive_sum = Erfassungsbogen.kognitive_sum + Each_field_value_kognitive;
                }
                if (Erfassungsbogen.t02field11 != "" && Erfassungsbogen.t02field11 != null)
                {
                    Erfassungsbogen.kognitive_sum = Erfassungsbogen.kognitive_sum + Each_field_value_kognitive;
                }

                if (Erfassungsbogen.kognitive_sum >= 99 && Erfassungsbogen.kognitive_sum <= 100)
                {
                    Erfassungsbogen.kognitive_sum = 100;
                    categories.Where(k => k.Name == "2. Kognitive und Kommunikative Fahigkeiten").FirstOrDefault().Percent = Erfassungsbogen.kognitive_sum + "%";
                    categories.Where(k => k.Name == "2. Kognitive und Kommunikative Fahigkeiten").FirstOrDefault().Level = Erfassungsbogen.kognitive_sum / 100;
                }
                else
                {
                    categories.Where(k => k.Name == "2. Kognitive und Kommunikative Fahigkeiten").FirstOrDefault().Level = Erfassungsbogen.kognitive_sum / 100;
                    categories.Where(k => k.Name == "2. Kognitive und Kommunikative Fahigkeiten").FirstOrDefault().Percent = Math.Round(Erfassungsbogen.kognitive_sum) + "%";
                }

                #endregion

                #region T03
                Erfassungsbogen.verhalt_sum = 0;

                if (Erfassungsbogen.t03field01 != "" && Erfassungsbogen.t03field01 != null)
                {
                    Erfassungsbogen.verhalt_sum = Each_field_value_verhalt;
                }
                if (Erfassungsbogen.t03field02 != "" && Erfassungsbogen.t03field02 != null)
                {
                    Erfassungsbogen.verhalt_sum = Erfassungsbogen.verhalt_sum + Each_field_value_verhalt;
                }
                if (Erfassungsbogen.t03field03 != "" && Erfassungsbogen.t03field03 != null)
                {
                    Erfassungsbogen.verhalt_sum = Erfassungsbogen.verhalt_sum + Each_field_value_verhalt;
                }
                if (Erfassungsbogen.t03field04 != "" && Erfassungsbogen.t03field04 != null)
                {
                    Erfassungsbogen.verhalt_sum = Erfassungsbogen.verhalt_sum + Each_field_value_verhalt;
                }
                if (Erfassungsbogen.t03field05 != "" && Erfassungsbogen.t03field05 != null)
                {
                    Erfassungsbogen.verhalt_sum = Erfassungsbogen.verhalt_sum + Each_field_value_verhalt;
                }
                if (Erfassungsbogen.t03field06 != "" && Erfassungsbogen.t03field06 != null)
                {
                    Erfassungsbogen.verhalt_sum = Erfassungsbogen.verhalt_sum + Each_field_value_verhalt;
                }
                if (Erfassungsbogen.t03field07 != "" && Erfassungsbogen.t03field07 != null)
                {
                    Erfassungsbogen.verhalt_sum = Erfassungsbogen.verhalt_sum + Each_field_value_verhalt;
                }
                if (Erfassungsbogen.t03field08 != "" && Erfassungsbogen.t03field08 != null)
                {
                    Erfassungsbogen.verhalt_sum = Erfassungsbogen.verhalt_sum + Each_field_value_verhalt;
                }
                if (Erfassungsbogen.t03field09 != "" && Erfassungsbogen.t03field09 != null)
                {
                    Erfassungsbogen.verhalt_sum = Erfassungsbogen.verhalt_sum + Each_field_value_verhalt;
                }
                if (Erfassungsbogen.t03field10 != "" && Erfassungsbogen.t03field10 != null)
                {
                    Erfassungsbogen.verhalt_sum = Erfassungsbogen.verhalt_sum + Each_field_value_verhalt;
                }
                if (Erfassungsbogen.t03field11 != "" && Erfassungsbogen.t03field11 != null)
                {
                    Erfassungsbogen.verhalt_sum = Erfassungsbogen.verhalt_sum + Each_field_value_verhalt;
                }
                if (Erfassungsbogen.t03field12 != "" && Erfassungsbogen.t03field12 != null)
                {
                    Erfassungsbogen.verhalt_sum = Erfassungsbogen.verhalt_sum + Each_field_value_verhalt;
                }
                if (Erfassungsbogen.t03field13 != "" && Erfassungsbogen.t03field13 != null)
                {
                    Erfassungsbogen.verhalt_sum = Erfassungsbogen.verhalt_sum + Each_field_value_verhalt;
                }

                if (Erfassungsbogen.verhalt_sum >= 99 && Erfassungsbogen.verhalt_sum <= 100)
                {
                    Erfassungsbogen.verhalt_sum = 100;
                    categories.Where(v => v.Name == "3. Verhaltensweisen und psychische...").FirstOrDefault().Percent = Erfassungsbogen.verhalt_sum + "%";
                    categories.Where(v => v.Name == "3. Verhaltensweisen und psychische...").FirstOrDefault().Level = Erfassungsbogen.verhalt_sum / 100;
                }
                else
                {
                    categories.Where(v => v.Name == "3. Verhaltensweisen und psychische...").FirstOrDefault().Level = Erfassungsbogen.verhalt_sum / 100;
                    categories.Where(v => v.Name == "3. Verhaltensweisen und psychische...").FirstOrDefault().Percent = Math.Round(Erfassungsbogen.verhalt_sum) + "%";
                }

                #endregion

                #region T04
                Erfassungsbogen.selbst_sum = 0;

                if (Erfassungsbogen.t04fields2 != "" && Erfassungsbogen.t04fields2 != null)
                {
                    Erfassungsbogen.selbst_sum = Each_field_value_selbst;
                }
                if (Erfassungsbogen.t04fields3 != "" && Erfassungsbogen.t04fields3 != null)
                {
                    Erfassungsbogen.selbst_sum = Erfassungsbogen.selbst_sum + Each_field_value_selbst;
                }
                if (Erfassungsbogen.t04field01 != "" && Erfassungsbogen.t04field01 != null)
                {
                    Erfassungsbogen.selbst_sum = Erfassungsbogen.selbst_sum + Each_field_value_selbst;
                }
                if (Erfassungsbogen.t04field02 != "" && Erfassungsbogen.t04field02 != null)
                {
                    Erfassungsbogen.selbst_sum = Erfassungsbogen.selbst_sum + Each_field_value_selbst;
                }
                if (Erfassungsbogen.t04field03 != "" && Erfassungsbogen.t04field03 != null)
                {
                    Erfassungsbogen.selbst_sum = Erfassungsbogen.selbst_sum + Each_field_value_selbst;
                }
                if (Erfassungsbogen.t04field04 != "" && Erfassungsbogen.t04field04 != null)
                {
                    Erfassungsbogen.selbst_sum = Erfassungsbogen.selbst_sum + Each_field_value_selbst;
                }
                if (Erfassungsbogen.t04field05 != "" && Erfassungsbogen.t04field05 != null)
                {
                    Erfassungsbogen.selbst_sum = Erfassungsbogen.selbst_sum + Each_field_value_selbst;
                }
                if (Erfassungsbogen.t04field06 != "" && Erfassungsbogen.t04field06 != null)
                {
                    Erfassungsbogen.selbst_sum = Erfassungsbogen.selbst_sum + Each_field_value_selbst;
                }
                if (Erfassungsbogen.t04field07 != "" && Erfassungsbogen.t04field07 != null)
                {
                    Erfassungsbogen.selbst_sum = Erfassungsbogen.selbst_sum + Each_field_value_selbst;
                }
                if (Erfassungsbogen.t04field08 != "" && Erfassungsbogen.t04field08 != null)
                {
                    Erfassungsbogen.selbst_sum = Erfassungsbogen.selbst_sum + Each_field_value_selbst;
                }
                if (Erfassungsbogen.t04field09 != "" && Erfassungsbogen.t04field09 != null)
                {
                    Erfassungsbogen.selbst_sum = Erfassungsbogen.selbst_sum + Each_field_value_selbst;
                }
                if (Erfassungsbogen.t04field10 != "" && Erfassungsbogen.t04field10 != null)
                {
                    Erfassungsbogen.selbst_sum = Erfassungsbogen.selbst_sum + Each_field_value_selbst;
                }
                if (Erfassungsbogen.t04field11 != "" && Erfassungsbogen.t04field11 != null)
                {
                    Erfassungsbogen.selbst_sum = Erfassungsbogen.selbst_sum + Each_field_value_selbst;
                }
                if (Erfassungsbogen.t04field12 != "" && Erfassungsbogen.t04field12 != null)
                {
                    Erfassungsbogen.selbst_sum = Erfassungsbogen.selbst_sum + Each_field_value_selbst;
                }
                if (Erfassungsbogen.t04field13 != "" && Erfassungsbogen.t04field13 != null)
                {
                    Erfassungsbogen.selbst_sum = Erfassungsbogen.selbst_sum + Each_field_value_selbst;
                }

                if (Erfassungsbogen.selbst_sum >= 99 && Erfassungsbogen.selbst_sum <= 100)
                {
                    Erfassungsbogen.selbst_sum = 100;
                    categories.Where(se => se.Name == "4. Selbstversorgung").FirstOrDefault().Percent = Erfassungsbogen.selbst_sum + "%";
                    categories.Where(se => se.Name == "4. Selbstversorgung").FirstOrDefault().Level = Erfassungsbogen.selbst_sum / 100;
                }
                else
                {
                    categories.Where(se => se.Name == "4. Selbstversorgung").FirstOrDefault().Level = Erfassungsbogen.selbst_sum / 100;
                    categories.Where(se => se.Name == "4. Selbstversorgung").FirstOrDefault().Percent = Math.Round(Erfassungsbogen.selbst_sum) + "%";
                }

                #endregion

                #region T05

                Erfassungsbogen.bewalt_sum = 0;

                if (Erfassungsbogen.t05field01_03 != "" && Erfassungsbogen.t05field01_03 != null)
                {
                    Erfassungsbogen.bewalt_sum = Erfassungsbogen.bewalt_sum + Each_field_value_bewalt;
                }

                if (Erfassungsbogen.t05field02_03 != "" && Erfassungsbogen.t05field02_03 != null)
                {
                    Erfassungsbogen.bewalt_sum = Erfassungsbogen.bewalt_sum + Each_field_value_bewalt;
                }

                if (Erfassungsbogen.t05field03_03 != "" && Erfassungsbogen.t05field03_03 != null)
                {
                    Erfassungsbogen.bewalt_sum = Erfassungsbogen.bewalt_sum + Each_field_value_bewalt;
                }

                if (Erfassungsbogen.t05field04_03 != "" && Erfassungsbogen.t05field04_03 != null)
                {
                    Erfassungsbogen.bewalt_sum = Erfassungsbogen.bewalt_sum + Each_field_value_bewalt;
                }

                if (Erfassungsbogen.t05field05_03 != "" && Erfassungsbogen.t05field05_03 != null)
                {
                    Erfassungsbogen.bewalt_sum = Erfassungsbogen.bewalt_sum + Each_field_value_bewalt;
                }

                if (Erfassungsbogen.t05field06_03 != "" && Erfassungsbogen.t05field06_03 != null)
                {
                    Erfassungsbogen.bewalt_sum = Erfassungsbogen.bewalt_sum + Each_field_value_bewalt;
                }

                if (Erfassungsbogen.t05field07_03 != "" && Erfassungsbogen.t05field07_03 != null)
                {
                    Erfassungsbogen.bewalt_sum = Erfassungsbogen.bewalt_sum + Each_field_value_bewalt;
                }

                if (Erfassungsbogen.t05field08_03 != "" && Erfassungsbogen.t05field08_03 != null)
                {
                    Erfassungsbogen.bewalt_sum = Erfassungsbogen.bewalt_sum + Each_field_value_bewalt;
                }

                if (Erfassungsbogen.t05field09_03 != "" && Erfassungsbogen.t05field09_03 != null)
                {
                    Erfassungsbogen.bewalt_sum = Erfassungsbogen.bewalt_sum + Each_field_value_bewalt;
                }

                if (Erfassungsbogen.t05field10_03 != "" && Erfassungsbogen.t05field10_03 != null)
                {
                    Erfassungsbogen.bewalt_sum = Erfassungsbogen.bewalt_sum + Each_field_value_bewalt;
                }

                if (Erfassungsbogen.t05field11_03 != "" && Erfassungsbogen.t05field11_03 != null)
                {
                    Erfassungsbogen.bewalt_sum = Erfassungsbogen.bewalt_sum + Each_field_value_bewalt;
                }

                if (Erfassungsbogen.t05field12_03 != "" && Erfassungsbogen.t05field12_03 != null)
                {
                    Erfassungsbogen.bewalt_sum = Erfassungsbogen.bewalt_sum + Each_field_value_bewalt;
                }

                if (Erfassungsbogen.t05field13_03 != "" && Erfassungsbogen.t05field13_03 != null)
                {
                    Erfassungsbogen.bewalt_sum = Erfassungsbogen.bewalt_sum + Each_field_value_bewalt;
                }

                if (Erfassungsbogen.t05field14_03 != "" && Erfassungsbogen.t05field14_03 != null)
                {
                    Erfassungsbogen.bewalt_sum = Erfassungsbogen.bewalt_sum + Each_field_value_bewalt;
                }

                if (Erfassungsbogen.t05field15_03 != "" && Erfassungsbogen.t05field15_03 != null)
                {
                    Erfassungsbogen.bewalt_sum = Erfassungsbogen.bewalt_sum + Each_field_value_bewalt;
                }

                if (Erfassungsbogen.t05field16_02 != "" && Erfassungsbogen.t05field16_02 != null)
                {
                    Erfassungsbogen.bewalt_sum = Erfassungsbogen.bewalt_sum + Each_field_value_bewalt;
                }


                if (Erfassungsbogen.bewalt_sum >= 99 && Erfassungsbogen.bewalt_sum <= 100)
                {
                    Erfassungsbogen.bewalt_sum = 100;
                    categories.Where(se => se.Name == "5. Bewältigung von und selbstständiger...").FirstOrDefault().Percent = Erfassungsbogen.bewalt_sum + "%";
                    categories.Where(se => se.Name == "5. Bewältigung von und selbstständiger...").FirstOrDefault().Level = Erfassungsbogen.bewalt_sum / 100;
                }
                else
                {
                    categories.Where(se => se.Name == "5. Bewältigung von und selbstständiger...").FirstOrDefault().Level = Erfassungsbogen.bewalt_sum / 100;
                    categories.Where(se => se.Name == "5. Bewältigung von und selbstständiger...").FirstOrDefault().Percent = Math.Round(Erfassungsbogen.bewalt_sum) + "%";
                }

                #endregion

                #region T06

                Erfassungsbogen.gestalt_sum = 0;

                if (Erfassungsbogen.t06field01 != "" && Erfassungsbogen.t06field01 != null)
                {
                    Erfassungsbogen.gestalt_sum = Each_field_value_gestalt;
                }
                if (Erfassungsbogen.t06field02 != "" && Erfassungsbogen.t06field02 != null)
                {
                    Erfassungsbogen.gestalt_sum = Erfassungsbogen.gestalt_sum + Each_field_value_gestalt;
                }
                if (Erfassungsbogen.t06field03 != "" && Erfassungsbogen.t06field03 != null)
                {
                    Erfassungsbogen.gestalt_sum = Erfassungsbogen.gestalt_sum + Each_field_value_gestalt;
                }
                if (Erfassungsbogen.t06field04 != "" && Erfassungsbogen.t06field04 != null)
                {
                    Erfassungsbogen.gestalt_sum = Erfassungsbogen.gestalt_sum + Each_field_value_gestalt;
                }
                if (Erfassungsbogen.t06field05 != "" && Erfassungsbogen.t06field05 != null)
                {
                    Erfassungsbogen.gestalt_sum = Erfassungsbogen.gestalt_sum + Each_field_value_gestalt;
                }
                if (Erfassungsbogen.t06field06 != "" && Erfassungsbogen.t06field06 != null)
                {
                    Erfassungsbogen.gestalt_sum = Erfassungsbogen.gestalt_sum + Each_field_value_gestalt;
                }

                if (Erfassungsbogen.gestalt_sum >= 99 && Erfassungsbogen.gestalt_sum <= 100)
                {
                    Erfassungsbogen.gestalt_sum = 100;
                    categories.Where(m => m.Name == "6. Gestaltung des Alltagslebens...").FirstOrDefault().Percent = Erfassungsbogen.gestalt_sum + "%";
                    categories.Where(m => m.Name == "6. Gestaltung des Alltagslebens...").FirstOrDefault().Level = Erfassungsbogen.gestalt_sum / 100;
                }
                else
                {
                    categories.Where(m => m.Name == "6. Gestaltung des Alltagslebens...").FirstOrDefault().Level = Erfassungsbogen.gestalt_sum / 100;
                    categories.Where(m => m.Name == "6. Gestaltung des Alltagslebens...").FirstOrDefault().Percent = Math.Round(Erfassungsbogen.gestalt_sum) + "%";
                }

                #endregion

                #region T07

                Erfassungsbogen.dekubitus_sum = 0;

                if (Erfassungsbogen.t07field00 != "" && Erfassungsbogen.t07field00 != null)
                {
                    Erfassungsbogen.dekubitus_sum = Erfassungsbogen.dekubitus_sum + Each_field_value_dekubitus;
                }

                if (Erfassungsbogen.t07field01 != "" && Erfassungsbogen.t07field01 != null)
                {
                    Erfassungsbogen.dekubitus_sum = Erfassungsbogen.dekubitus_sum + Each_field_value_dekubitus;
                }

                if (Erfassungsbogen.dekubitus_sum >= 99 && Erfassungsbogen.dekubitus_sum <= 100)
                {
                    Erfassungsbogen.dekubitus_sum = 100;
                    categories.Where(m => m.Name == "7. Dekubitus").FirstOrDefault().Percent = Erfassungsbogen.dekubitus_sum + "%";
                    categories.Where(m => m.Name == "7. Dekubitus").FirstOrDefault().Level = Erfassungsbogen.dekubitus_sum / 100;
                }
                else
                {
                    categories.Where(m => m.Name == "7. Dekubitus").FirstOrDefault().Level = Erfassungsbogen.dekubitus_sum / 100;
                    categories.Where(m => m.Name == "7. Dekubitus").FirstOrDefault().Percent = Math.Round(Erfassungsbogen.dekubitus_sum) + "%";
                }

                #endregion

                #region T08

                Erfassungsbogen.kopergrosse_sum = 0;

                if (Erfassungsbogen.t08field01 != "" && Erfassungsbogen.t08field01 != null)
                {
                    Erfassungsbogen.kopergrosse_sum = Erfassungsbogen.kopergrosse_sum + Each_field_value_kopergrosse;
                }
                if (Erfassungsbogen.t08field02_01 != "" && Erfassungsbogen.t08field02_01 != null)
                {
                    Erfassungsbogen.kopergrosse_sum = Erfassungsbogen.kopergrosse_sum + Each_field_value_kopergrosse;
                }
                if (Erfassungsbogen.t08field02_02 != "" && Erfassungsbogen.t08field02_02 != null)
                {
                    Erfassungsbogen.kopergrosse_sum = Erfassungsbogen.kopergrosse_sum + Each_field_value_kopergrosse;
                }

                if (Erfassungsbogen.kopergrosse_sum >= 99 && Erfassungsbogen.kopergrosse_sum <= 100)
                {
                    Erfassungsbogen.kopergrosse_sum = 100;
                    categories.Where(m => m.Name == "8. Körpergroße und Gewicht").FirstOrDefault().Percent = Erfassungsbogen.kopergrosse_sum + "%";
                    categories.Where(m => m.Name == "8. Körpergroße und Gewicht").FirstOrDefault().Level = Erfassungsbogen.kopergrosse_sum / 100;
                }
                else
                {
                    categories.Where(m => m.Name == "8. Körpergroße und Gewicht").FirstOrDefault().Level = Erfassungsbogen.kopergrosse_sum / 100;
                    categories.Where(m => m.Name == "8. Körpergroße und Gewicht").FirstOrDefault().Percent = Math.Round(Erfassungsbogen.kopergrosse_sum) + "%";
                }

                #endregion

                #region T09

                Erfassungsbogen.sturzfolgen_sum = 0;

                if (Erfassungsbogen.t09field01 != "" && Erfassungsbogen.t09field01 != null)
                {
                    Erfassungsbogen.sturzfolgen_sum = Erfassungsbogen.sturzfolgen_sum + Each_field_value_sturzflogen;
                }

                if (Erfassungsbogen.sturzfolgen_sum >= 99 && Erfassungsbogen.sturzfolgen_sum <= 100)
                {
                    Erfassungsbogen.sturzfolgen_sum = 100;
                    categories.Where(m => m.Name == "9. Sturzfolgen").FirstOrDefault().Percent = Erfassungsbogen.sturzfolgen_sum + "%";
                    categories.Where(m => m.Name == "9. Sturzfolgen").FirstOrDefault().Level = Erfassungsbogen.sturzfolgen_sum / 100;
                }
                else
                {
                    categories.Where(m => m.Name == "9. Sturzfolgen").FirstOrDefault().Level = Erfassungsbogen.sturzfolgen_sum / 100;
                    categories.Where(m => m.Name == "9. Sturzfolgen").FirstOrDefault().Percent = Math.Round(Erfassungsbogen.sturzfolgen_sum) + "%";
                }

                #endregion

                #region T10

                Erfassungsbogen.freihalten_sum = 0;

                if (Erfassungsbogen.t10field01 != "" && Erfassungsbogen.t10field01 != null)
                {
                    Erfassungsbogen.freihalten_sum = Erfassungsbogen.freihalten_sum + Each_field_value_freihalten;
                }

                if (Erfassungsbogen.t10field05 != "" && Erfassungsbogen.t10field05 != null)
                {
                    Erfassungsbogen.freihalten_sum = Erfassungsbogen.freihalten_sum + Each_field_value_freihalten;
                }

                if (Erfassungsbogen.freihalten_sum >= 99 && Erfassungsbogen.freihalten_sum <= 100)
                {
                    Erfassungsbogen.freihalten_sum = 100;
                    categories.Where(frei => frei.Name == "10. Freiheitzeihende Maßnahmen").FirstOrDefault().Percent = Erfassungsbogen.freihalten_sum + "%";
                    categories.Where(frei => frei.Name == "10. Freiheitzeihende Maßnahmen").FirstOrDefault().Level = Erfassungsbogen.freihalten_sum / 100;
                }
                else
                {
                    categories.Where(frei => frei.Name == "10. Freiheitzeihende Maßnahmen").FirstOrDefault().Level = Erfassungsbogen.freihalten_sum / 100;
                    categories.Where(frei => frei.Name == "10. Freiheitzeihende Maßnahmen").FirstOrDefault().Percent = Math.Round(Erfassungsbogen.freihalten_sum) + "%";
                }

                #endregion

                #region T11

                Erfassungsbogen.schmerzen_sum = 0;

                if (Erfassungsbogen.t11field01 != "" && Erfassungsbogen.t11field01 != null)
                {
                    Erfassungsbogen.schmerzen_sum = Erfassungsbogen.schmerzen_sum + Each_field_value_schmerzen;
                }

                //if (Erfassungsbogen.t11field01a != "" && Erfassungsbogen.t11field01a != null)
                //{
                //    Erfassungsbogen.schmerzen_sum = Erfassungsbogen.schmerzen_sum + Each_field_value_schmerzen;
                //}

                if (Erfassungsbogen.schmerzen_sum >= 99 && Erfassungsbogen.schmerzen_sum <= 100)
                {
                    Erfassungsbogen.schmerzen_sum = 100;
                    categories.Where(m => m.Name == "11. Schmerzen").FirstOrDefault().Percent = Erfassungsbogen.schmerzen_sum + "%";
                    categories.Where(m => m.Name == "11. Schmerzen").FirstOrDefault().Level = Erfassungsbogen.schmerzen_sum / 100;
                }
                else
                {
                    categories.Where(m => m.Name == "11. Schmerzen").FirstOrDefault().Level = Erfassungsbogen.schmerzen_sum / 100;
                    categories.Where(m => m.Name == "11. Schmerzen").FirstOrDefault().Percent = Math.Round(Erfassungsbogen.schmerzen_sum) + "%";
                }

                #endregion

                #region T12

                Erfassungsbogen.Heimzug_sum = 0;

                if (Erfassungsbogen.t12field00 != "" && Erfassungsbogen.t12field00 != null)
                {
                    Erfassungsbogen.Heimzug_sum = Erfassungsbogen.Heimzug_sum + Each_field_value_Heimzug;
                }

                if (Erfassungsbogen.Heimzug_sum >= 99 && Erfassungsbogen.Heimzug_sum <= 100)
                {
                    Erfassungsbogen.Heimzug_sum = 100;
                    categories.Where(m => m.Name == "12. Heimeinzug").FirstOrDefault().Percent = Erfassungsbogen.Heimzug_sum + "%";
                    categories.Where(m => m.Name == "12. Heimeinzug").FirstOrDefault().Level = Erfassungsbogen.Heimzug_sum / 100;
                }
                else
                {
                    categories.Where(m => m.Name == "12. Heimeinzug").FirstOrDefault().Percent = Math.Round(Erfassungsbogen.Heimzug_sum) + "%";
                    categories.Where(m => m.Name == "12. Heimeinzug").FirstOrDefault().Level = Erfassungsbogen.Heimzug_sum / 100;
                }

                #endregion

                #region T13

                Erfassungsbogen.Einschatzung_sum = 0;

                if (Erfassungsbogen.t13field01 != "" && Erfassungsbogen.t13field01 != null)
                {
                    Erfassungsbogen.Einschatzung_sum = Erfassungsbogen.Einschatzung_sum + Each_field_value_Einschaetzung;
                }

                if (Erfassungsbogen.Einschatzung_sum >= 99 && Erfassungsbogen.Einschatzung_sum <= 100)
                {
                    categories.Where(m => m.Name == "13. Einschätzung von Verhaltensweisen").FirstOrDefault().Percent = Erfassungsbogen.Einschatzung_sum + "%";
                    categories.Where(m => m.Name == "13. Einschätzung von Verhaltensweisen").FirstOrDefault().Level = Erfassungsbogen.Einschatzung_sum / 100;
                }
                else
                {
                    categories.Where(m => m.Name == "13. Einschätzung von Verhaltensweisen").FirstOrDefault().Percent = Erfassungsbogen.Einschatzung_sum + "%";
                    categories.Where(m => m.Name == "13. Einschätzung von Verhaltensweisen").FirstOrDefault().Level = Erfassungsbogen.Einschatzung_sum / 100;
                }

                #endregion

                #region T14

                Erfassungsbogen.medikamente_sum = 0;

                if (Erfassungsbogen.t14field01 != "" && Erfassungsbogen.t14field01 != null)
                {
                    Erfassungsbogen.medikamente_sum = Erfassungsbogen.medikamente_sum + Each_field_value_medikamente;
                }
                if (Erfassungsbogen.t14field02 != "" && Erfassungsbogen.t14field02 != null)
                {
                    Erfassungsbogen.medikamente_sum = Erfassungsbogen.medikamente_sum + Each_field_value_medikamente;
                }
                if (Erfassungsbogen.t14field03 != "" && Erfassungsbogen.t14field03 != null)
                {
                    Erfassungsbogen.medikamente_sum = Erfassungsbogen.medikamente_sum + Each_field_value_medikamente;
                }

                if (Erfassungsbogen.medikamente_sum >= 99 && Erfassungsbogen.medikamente_sum <= 100)
                {
                    Erfassungsbogen.medikamente_sum = 100;
                    categories.Where(m => m.Name == "14. Medikamente").FirstOrDefault().Percent = Erfassungsbogen.medikamente_sum + "%";
                    categories.Where(m => m.Name == "14. Medikamente").FirstOrDefault().Level = Erfassungsbogen.medikamente_sum / 100;
                }
                else
                {
                    categories.Where(m => m.Name == "14. Medikamente").FirstOrDefault().Level = Erfassungsbogen.medikamente_sum / 100;
                    categories.Where(m => m.Name == "14. Medikamente").FirstOrDefault().Percent = Math.Round(Erfassungsbogen.medikamente_sum) + "%";
                }

                #endregion

                #region T15

                Erfassungsbogen.bewgung_sum = 0;

                if (Erfassungsbogen.t15field01 != "" && Erfassungsbogen.t15field01 != null)
                {

                    Erfassungsbogen.bewgung_sum = Erfassungsbogen.bewgung_sum + Each_field_value_bewegung;
                }

                if (Erfassungsbogen.bewgung_sum >= 99 && Erfassungsbogen.bewgung_sum <= 100)
                {
                    Erfassungsbogen.bewgung_sum = 100;
                    categories.Where(m => m.Name == "15. Bewegungseinschränkung").FirstOrDefault().Percent = Erfassungsbogen.bewgung_sum + "%";
                    categories.Where(m => m.Name == "15. Bewegungseinschränkung").FirstOrDefault().Level = Erfassungsbogen.bewgung_sum / 100;
                }
                else
                {
                    categories.Where(m => m.Name == "15. Bewegungseinschränkung").FirstOrDefault().Level = Erfassungsbogen.bewgung_sum / 100;
                    categories.Where(m => m.Name == "15. Bewegungseinschränkung").FirstOrDefault().Percent = Math.Round(Erfassungsbogen.bewgung_sum) + "%";
                }

                #endregion

                #region T16

                Erfassungsbogen.dokumention_sum = 0;

                if (Erfassungsbogen.t16field01 != "" && Erfassungsbogen.t16field01 != null)
                {
                    Erfassungsbogen.dokumention_sum = Erfassungsbogen.dokumention_sum + Each_field_value_dokumention;
                }

                if (Erfassungsbogen.t16field10 != "" && Erfassungsbogen.t16field10 != null)
                {
                    Erfassungsbogen.dokumention_sum = Erfassungsbogen.dokumention_sum + Each_field_value_dokumention;
                }

                if (Erfassungsbogen.dokumention_sum >= 99 && Erfassungsbogen.dokumention_sum <= 100)
                {
                    Erfassungsbogen.dokumention_sum = 100;
                    categories.Where(doc => doc.Name == "16. Dokumentation").FirstOrDefault().Percent = Erfassungsbogen.dokumention_sum + "%";
                    categories.Where(doc => doc.Name == "16. Dokumentation").FirstOrDefault().Level = Erfassungsbogen.dokumention_sum / 100;
                }
                else
                {
                    categories.Where(doc => doc.Name == "16. Dokumentation").FirstOrDefault().Level = Erfassungsbogen.dokumention_sum / 100;
                    categories.Where(doc => doc.Name == "16. Dokumentation").FirstOrDefault().Percent = Math.Round(Erfassungsbogen.dokumention_sum) + "%";
                }

                #endregion

                #region Erhebungsbogen abschließen

                var total_sum = (Erfassungsbogen.alg_sum + Erfassungsbogen.mobilitat_sum + Erfassungsbogen.kognitive_sum + Erfassungsbogen.verhalt_sum + Erfassungsbogen.selbst_sum + Erfassungsbogen.bewalt_sum + Erfassungsbogen.gestalt_sum + Erfassungsbogen.dekubitus_sum + Erfassungsbogen.kopergrosse_sum + Erfassungsbogen.sturzfolgen_sum + Erfassungsbogen.freihalten_sum + Erfassungsbogen.schmerzen_sum + Erfassungsbogen.Heimzug_sum + Erfassungsbogen.Einschatzung_sum + Erfassungsbogen.medikamente_sum + Erfassungsbogen.bewgung_sum + Erfassungsbogen.dokumention_sum) / (100 * 17);

                categories.Where(doc => doc.Name == "Erhebungsbogen abschließen").FirstOrDefault().Percent = Convert.ToInt32(total_sum * 100) + "%";
                categories.Where(doc => doc.Name == "Erhebungsbogen abschließen").FirstOrDefault().Level = total_sum;

                #endregion

                #endregion

                IsLoading = false;
            }
            catch (Exception)
            {
                await DisplayAlert(AppResources.AppError, AppResources.AppErrorMsg, "OK");
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