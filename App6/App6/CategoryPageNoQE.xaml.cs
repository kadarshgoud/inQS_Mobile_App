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
    public partial class CategoryPageNoQE : ContentPage, INotifyPropertyChanged
    {
        //  public string endedatum = DateTime.Now.ToString("dd.MM.yyy");

        // Mathematical Part 
        public double Each_field_value_Allgemeine = (double)100 / 2;

        List<Data> categories = new List<Data>
           {
            new Data{Name = "0. Allgemeines", Tap = "Tapped_1" , Percent = "0%", Level =0},
            new Data{Name = "Erhebungsbogen (ohne QE) abschließen", Tap = "Tapped_17",Percent = "0%", Level =0},
        };

        public CategoryPageNoQE()
        {
            InitializeComponent();
            BindingContext = this;
            MyList.ItemsSource = categories;

            ModulLabel.Text = AppResources.SurveyHeadlineWithoutQE + " " + DBManagement.getYearCode(App.user.selected_mstr_ebqe) + " " + AppResources.SurveyHeadlineFor + " " + ErfassungsbogenNoQE.Bewohnerbezeichnung;
        }

        private void Sb_search_TextChanged(object sender, TextChangedEventArgs e)
        {
            var keyword = sb_search.Text;

            var result = categories.Where(x => x.Name.ToLower().Contains(keyword));

            MyList.ItemsSource = result;
        }

        private async Task MyList_ItemTappedAsync(object sender, ItemTappedEventArgs e)
        {
            var item = e.Item as Data;
            string led = item.Name.ToString();

            if (item.Name == "0. Allgemeines")
            {
                await Navigation.PushAsync(new Allgemeines_NoQE());
            }

            else if (item.Name == "Erhebungsbogen (ohne QE) abschließen")
            {
                try
                {
                    if (App.user.selected_mstr_ebqe == DBManagement.CurrentEvaluationID)
                    {
                        var FinishButton = await DisplayAlert("Bogenabschluss", "Möchten Sie diesen Bogen wirklich abschließen?", AppResources.Yes, AppResources.No);
                        if (FinishButton == true)
                        {
                            ErfassungsbogenNoQE.endedatum = DateTime.Now.ToString("dd.MM.yyy");

                            var total_sum = (ErfassungsbogenNoQE.alg_sum) / 1;

                            if (total_sum == 100)
                            {
                                WebRequest req = WebRequest.Create(DBManagement.DBConnection + "tbl_form_ebqe_update_ende_endedatum.php");

                                req.Method = "POST"; //POST
                                req.Timeout = 15000;
                                req.ContentType = "application/x-www-form-urlencoded";

                                string postData = "mstr=" + App.user.selected_mstr_ebqe + "&bewonerid=" + App.user.selected_id_bewohner + "&ende=" + ErfassungsbogenNoQE.ende + "&endedatum=" + ErfassungsbogenNoQE.endedatum;
                                byte[] byteArray = Encoding.UTF8.GetBytes(postData);

                                req.ContentLength = byteArray.Length;

                                Stream ds = await req.GetRequestStreamAsync();
                                await ds.WriteAsync(byteArray, 0, byteArray.Length);
                                ds.Close();

                                WebRequest req2 = WebRequest.Create(DBManagement.DBConnection + "tbl_form_ebqe_mobile_update_ende_endedatum.php");

                                req2.Method = "POST"; //POST
                                req2.Timeout = 15000;
                                req2.ContentType = "application/x-www-form-urlencoded";

                                string postData2 = "mstr=" + App.user.selected_mstr_ebqe + "&bewonerid=" + App.user.selected_id_bewohner + "&ende=" + ErfassungsbogenNoQE.ende + "&endedatum=" + ErfassungsbogenNoQE.endedatum;
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

        private async void BackButton_TappedAsync(object sender, EventArgs e)
        {
            BackButton.Source = "ic_arrow_back_ios_tapped.png";

            await Navigation.PushAsync(new ListOfPatients());
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

        protected override void OnAppearing()
        {
            base.OnAppearing();

            try
            {
                //ActivityIndicator = Loading...
                IsLoading = true;

                if (ErfassungsbogenNoQE.loadedFromDB == false)
                {
                    #region T00

                    //// Getting additional data from bewohner ( date of birth, year, sex, date of care institution entry)

                    //WebRequest req1 = WebRequest.Create(DBManagement.DBConnection + "tbl_form_ebqe_t00_01_read_4fields.php");

                    //req1.Method = "POST";
                    //req1.ContentType = "application/x-www-form-urlencoded";

                    //string postData1 = "einrichtung=" + App.user.id_org_einrichtung + "&wohnbereich=" + App.user.id_org_wohnbereich + "&bewonerid=" + App.user.selected_id_bewohner;
                    //byte[] byteArray1 = Encoding.UTF8.GetBytes(postData1);

                    //req1.ContentLength = byteArray1.Length;

                    //Stream ds1 = req1.GetRequestStream();
                    //await ds1.WriteAsync(byteArray1, 0, byteArray1.Length);
                    //ds1.Close();

                    //WebResponse response1 = await req1.GetResponseAsync();

                    //Stream dataStream1 = response1.GetResponseStream();

                    //StreamReader reader1 = new StreamReader(dataStream1);

                    //string s1 = await reader1.ReadToEndAsync();

                    //string[] split1 = s1.Split(new char[] { ':' });

                    //ErfassungsbogenNoQE.tkurzfield01 = split1[0];
                    //ErfassungsbogenNoQE.tkurzfield02 = split1[1];
                    //ErfassungsbogenNoQE.tkurzfield03 = split1[2];
                    //ErfassungsbogenNoQE.tkurzfield04 = split1[3];

                    WebRequest req00 = WebRequest.Create(DBManagement.DBConnection + "tbl_form_ebqe_no_qe_read_all_fields.php"); //tbl_form_ebqe_kurz

                    req00.Method = "POST";
                    req00.ContentType = "application/x-www-form-urlencoded";

                    string postData00 = "id=" + App.user.selected_mstr_ebqe + "&einrichtung=" + App.user.id_org_einrichtung + "&wohnbereich=" + App.user.id_org_wohnbereich + "&bewonerid=" + App.user.selected_id_bewohner;
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

                    ErfassungsbogenNoQE.tkurzfield05 = split00[4];
                    ErfassungsbogenNoQE.tkurzfield06 = split00[5];
                    ErfassungsbogenNoQE.tkurzfield07 = split00[6];
                    ErfassungsbogenNoQE.tkurzfield08 = split00[7];
                    ErfassungsbogenNoQE.tkurzfield09 = split00[8];

                    #endregion

                    ErfassungsbogenNoQE.loadedFromDB = true;
                }

                #region Sum Calculations

                #region T00

                ErfassungsbogenNoQE.alg_sum = 0;

                if (ErfassungsbogenNoQE.tkurzfield05 != "" && ErfassungsbogenNoQE.tkurzfield05 != null)
                {
                    ErfassungsbogenNoQE.alg_sum = ErfassungsbogenNoQE.alg_sum + Each_field_value_Allgemeine;
                }

                if (ErfassungsbogenNoQE.tkurzfield06 != "" && ErfassungsbogenNoQE.tkurzfield06 != null)
                {
                    ErfassungsbogenNoQE.alg_sum = ErfassungsbogenNoQE.alg_sum + Each_field_value_Allgemeine;
                }

                // if it is 99.99 
                if (ErfassungsbogenNoQE.alg_sum >= 99 && ErfassungsbogenNoQE.alg_sum <= 100)
                {
                    ErfassungsbogenNoQE.alg_sum = 100;
                    categories.Where(a => a.Name == "0. Allgemeines").FirstOrDefault().Percent = ErfassungsbogenNoQE.alg_sum + "%";
                    categories.Where(a => a.Name == "0. Allgemeines").FirstOrDefault().Level = ErfassungsbogenNoQE.alg_sum / 100;
                }
                else
                {
                    categories.Where(a => a.Name == "0. Allgemeines").FirstOrDefault().Level = ErfassungsbogenNoQE.alg_sum / 100;
                    categories.Where(a => a.Name == "0. Allgemeines").FirstOrDefault().Percent = Math.Round(ErfassungsbogenNoQE.alg_sum) + "%";
                }

                #endregion

                #region Erhebungsbogen abschließen

                var total_sum = (ErfassungsbogenNoQE.alg_sum) / (100 * 1);

                categories.Where(doc => doc.Name == "Erhebungsbogen (ohne QE) abschließen").FirstOrDefault().Percent = Convert.ToInt32(total_sum * 100) + "%";
                categories.Where(doc => doc.Name == "Erhebungsbogen (ohne QE) abschließen").FirstOrDefault().Level = total_sum;

                #endregion

                #endregion

                IsLoading = false;
            }
            catch (Exception)
            {
                DisplayAlert(AppResources.AppError, AppResources.AppErrorMsg, "OK");
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