using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using App6.Model;
using App6.Management;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using App6.Resources;
using System.ComponentModel;
using System.Threading.Tasks;

namespace App6
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListOfPatients : ContentPage, INotifyPropertyChanged
    {
        public List<Patient> people1 = new List<Patient>();

        public ListOfPatients()
        {
            InitializeComponent();

            AppManager.ListOfPatientSettingOpen = true;
            AppManager.ListOfPatientSettingFinished = true;
            AppManager.ListOfPatientSettingQE = true;
            AppManager.ListOfPatientSettingNoQE = true;

            BindingContext = this;           
        }

        protected override async void OnAppearing()
        {
            try
            {
                //ActivityIndicator = Loading...
                IsLoading = true;

                if (App.user.selected_mstr_ebqe == DBManagement.CurrentEvaluationID)
                {
                    WebRequest req = WebRequest.Create(DBManagement.DBConnection + "inqs_db_getCurrentTimeCycleSurveyBewohner.php");

                    req.Method = "POST";
                    req.ContentType = "application/x-www-form-urlencoded";

                    string postData = "einrichtung=" + App.user.id_org_einrichtung + "&wohnbereich=" + App.user.id_org_wohnbereich + "&id=" + App.user.selected_mstr_ebqe;
                    byte[] byteArray = Encoding.UTF8.GetBytes(postData);

                    req.ContentLength = byteArray.Length;

                    Stream ds = await req.GetRequestStreamAsync();
                    await ds.WriteAsync(byteArray, 0, byteArray.Length);
                    ds.Close();

                    WebResponse response = await req.GetResponseAsync();

                    Stream dataStream = response.GetResponseStream();

                    StreamReader reader = new StreamReader(dataStream);

                    string s = await reader.ReadToEndAsync();

                    string[] splitOut = s.Split(new char[] { '|' });

                    for (int j = 0; j < splitOut.Length; j++)
                    {
                        if (splitOut[j] == "")
                        {
                            break;
                        }

                        string[] splitIn = splitOut[j].Split(new char[] { ':' });

                        people1.Add(new Patient { id = Convert.ToInt32(splitIn[0]), Bewohnercode = splitIn[1], id_orga_Einrichtung = Convert.ToInt32(splitIn[2]), id_orga_Wohnbereich = Convert.ToInt32(splitIn[3]), Bogenart = Convert.ToInt32(splitIn[4]), Geburtsmonat = splitIn[5], Geburtsjahr = splitIn[6], DatumHeimeinzug = splitIn[7], Geschlecht = splitIn[8] });
                    }
                }
                else
                {
                    WebRequest req = WebRequest.Create(DBManagement.DBConnection + "inqs_db_getPastTimeCycleSurveyBewohner.php");

                    req.Method = "POST";
                    req.ContentType = "application/x-www-form-urlencoded";

                    string postData = "einrichtung=" + App.user.id_org_einrichtung + "&wohnbereich=" + App.user.id_org_wohnbereich + "&id=" + App.user.selected_mstr_ebqe;
                    byte[] byteArray = Encoding.UTF8.GetBytes(postData);

                    req.ContentLength = byteArray.Length;

                    Stream ds = await req.GetRequestStreamAsync();
                    await ds.WriteAsync(byteArray, 0, byteArray.Length);
                    ds.Close();

                    WebResponse response = await req.GetResponseAsync();

                    Stream dataStream = response.GetResponseStream();

                    StreamReader reader = new StreamReader(dataStream);

                    string s = await reader.ReadToEndAsync();

                    string[] splitOut = s.Split(new char[] { '|' });

                    for (int j = 0; j < splitOut.Length; j++)
                    {
                        if (splitOut[j] == "")
                        {
                            break;
                        }

                        string[] splitIn = splitOut[j].Split(new char[] { ':' });

                        people1.Add(new Patient { id = Convert.ToInt32(splitIn[0]), Bewohnercode = splitIn[1], id_orga_Einrichtung = Convert.ToInt32(splitIn[2]), id_orga_Wohnbereich = Convert.ToInt32(splitIn[3]), Bogenart = Convert.ToInt32(splitIn[4]), Geburtsmonat = splitIn[5], Geburtsjahr = splitIn[6], DatumHeimeinzug = splitIn[7], Geschlecht = splitIn[8] });
                    }
                }

                //ActivityIndicator = Idle
                IsLoading = false;
            }
            catch (Exception)
            {
                await DisplayAlert(AppResources.AppError, AppResources.AppErrorMsg, "OK");
            }
            try
            {
                //ActivityIndicator = Loading...
                IsLoading = true;

                //Get decrypted Fullnames
                WebRequest req2 = WebRequest.Create(DBManagement.DBConnection + "tbl_orga_einrichtung_getSolutionCode.php");

                req2.Method = "POST";
                req2.ContentType = "application/x-www-form-urlencoded";

                string postData2 = "einrichtung=" + App.user.id_org_einrichtung;

                byte[] byteArray2 = Encoding.UTF8.GetBytes(postData2);

                req2.ContentLength = byteArray2.Length;

                Stream ds2 = await req2.GetRequestStreamAsync();
                await ds2.WriteAsync(byteArray2, 0, byteArray2.Length);
                ds2.Close();

                WebResponse response2 = await req2.GetResponseAsync();

                Stream dataStream2 = response2.GetResponseStream();

                StreamReader reader2 = new StreamReader(dataStream2);

                string solutionCode = await reader2.ReadToEndAsync();

                WebRequest req3 = WebRequest.Create(DBManagement.DBConnection + "tbl_pers_bewohner_getFullNames.php");

                req3.Method = "POST";
                req3.ContentType = "application/x-www-form-urlencoded";

                string postData3 = "einrichtung=" + App.user.id_org_einrichtung + "&wohnbereich=" + App.user.id_org_wohnbereich + "&solution=" + solutionCode;
                byte[] byteArray3 = Encoding.UTF8.GetBytes(postData3);

                req3.ContentLength = byteArray3.Length;

                Stream ds3 = await req3.GetRequestStreamAsync();
                await ds3.WriteAsync(byteArray3, 0, byteArray3.Length);
                ds3.Close();

                WebResponse response3 = await req3.GetResponseAsync();

                Stream dataStream3 = response3.GetResponseStream();

                StreamReader reader3 = new StreamReader(dataStream3);

                string s3 = reader3.ReadToEnd();

                string[] personFullnames = s3.Split(new char[] { '|' });

                for (int j = 0; j < personFullnames.Length; j++)
                {
                    if (personFullnames[j] == "")
                    {
                        break;
                    }

                    string[] person = personFullnames[j].Split(new char[] { ':' });

                    if (people1.Where(a => a.id == Convert.ToInt32(person[0])).FirstOrDefault() != null)
                    {
                        people1.Where(a => a.id == Convert.ToInt32(person[0])).FirstOrDefault().Vorname = person[1];
                        people1.Where(a => a.id == Convert.ToInt32(person[0])).FirstOrDefault().Nachname = person[2];
                        people1.Where(a => a.id == Convert.ToInt32(person[0])).FirstOrDefault().Bewohnerbezeichnung = person[2] + ", " + person[1] + " (" + people1.Where(a => a.id == Convert.ToInt32(person[0])).FirstOrDefault().Bewohnercode + ")";
                    }

                    //people1.Add(new Patient { id = Convert.ToInt32(splitIn[0]), Bewohnercode = splitIn[1], id_orga_Einrichtung = Convert.ToInt32(splitIn[2]), id_orga_Wohnbereich = Convert.ToInt32(splitIn[3]), Bogenart = Convert.ToBoolean(Convert.ToInt32(splitIn[4])), Geburtsmonat = splitIn[5], Geburtsjahr = splitIn[6], DatumHeimeinzug = splitIn[7], Geschlecht = splitIn[8] });
                }


                foreach (var bewohner in people1)
                {
                    if (PatientManager.PatientListCompleted.Any(a => a.id == bewohner.id))
                    {
                        bewohner.isSurveyCompleted = 1;
                    }
                    else
                    {
                        bewohner.isSurveyCompleted = 0;
                    }
                }

                MyList.ItemsSource = people1.OrderBy(a => a.Bewohnerbezeichnung);

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

            await Navigation.PushAsync(new FirstPage_2019_2());
        }

        private async void MyList_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            try
            {
                //ActivityIndicator = Loading...
                IsLoading = true;

                //Default Color & isEnabled
                AppManager.QuestionColor = Color.FromRgb(0, 0, 0);
                AppManager.AnswerColor = Color.FromRgb(125, 125, 125);
                AppManager.QuestionOpacity = 1.0;
                AppManager.AnswerOpacity = 1.0;
                AppManager.ImageOpacity = 1.0;
                AppManager.QuestionDisabledOpacity = 0.1;
                AppManager.AnswerDisabledOpacity = 0.1;
                AppManager.AnswerFontStyle = "Bold";
                Erfassungsbogen.Is_enabled = true;

                //Set Color to Gray and IsEnabled = false
                if (App.user.selected_mstr_ebqe != DBManagement.CurrentEvaluationID) // Data cannot be edited for previous years
                {
                    AppManager.QuestionColor = Color.FromRgb(0, 0, 0);
                    AppManager.AnswerColor = Color.FromRgb(175, 175, 175);
                    AppManager.QuestionOpacity = 1.0;
                    AppManager.AnswerOpacity = 1.0;
                    AppManager.ImageOpacity = 0.3;
                    AppManager.QuestionDisabledOpacity = 0.1;
                    AppManager.AnswerDisabledOpacity = 0.1;
                    AppManager.AnswerFontStyle = "Bold";
                    Erfassungsbogen.Is_enabled = false;
                }

                var item = e.Item as Patient;

                App.user.selected_id_bewohner = item.id;

                //DECIDE BETWEEN QE AND NO_QE
                if (item.Bogenart == 0)
                {
                    //Make new Survey Form
                    Erfassungsbogen.id_mstr_ebqe = App.user.selected_mstr_ebqe;
                    Erfassungsbogen.id_orga_Einrichtung = App.user.id_org_einrichtung;
                    Erfassungsbogen.id_orga_Wohnbereich = App.user.id_org_wohnbereich;
                    Erfassungsbogen.id_pers_Bewohner = item.id;
                    Erfassungsbogen.Bewohnerbezeichnung = item.Bewohnerbezeichnung;
                    Erfassungsbogen.Bewohnercode = item.Bewohnercode;
                    Erfassungsbogen.Vorname = item.Vorname;
                    Erfassungsbogen.Nachname = item.Nachname;
                    Erfassungsbogen.bogenart = 0;
                    Erfassungsbogen.t00field01 = item.DatumHeimeinzug;
                    Erfassungsbogen.t00field02_1 = item.Geburtsmonat;
                    Erfassungsbogen.t00field02_2 = item.Geburtsjahr;
                    Erfassungsbogen.t00field03 = item.Geschlecht;
                    Erfassungsbogen.loadedFromDB = false;

                    // reading the form_ebqe_value  (we get only form_ebqe value with mstr_id)

                    WebRequest req = WebRequest.Create(DBManagement.DBConnection + "tbl_form_ebqe_read.php");

                    req.Method = "POST";
                    req.Timeout = 15000;
                    req.ContentType = "application/x-www-form-urlencoded";

                    string postData = "id=" + App.user.selected_mstr_ebqe + "&einrichtung=" + App.user.id_org_einrichtung + "&wohnbereich=" + App.user.id_org_wohnbereich + "&bewonerid=" + App.user.selected_id_bewohner;
                    byte[] byteArray = Encoding.UTF8.GetBytes(postData);

                    req.ContentLength = byteArray.Length;

                    Stream ds = await req.GetRequestStreamAsync();
                    await ds.WriteAsync(byteArray, 0, byteArray.Length);
                    ds.Close();

                    WebResponse response = await req.GetResponseAsync();

                    Stream dataStream = response.GetResponseStream();

                    StreamReader reader = new StreamReader(dataStream);

                    string s = reader.ReadToEnd();
                    //  Erfassungsbogen.form_id_read = Convert.ToInt32(s);
                    Erfassungsbogen.id_form_ebqe_string = s;

                    if (Erfassungsbogen.id_form_ebqe_string != "" && Erfassungsbogen.id_form_ebqe_string != null)
                    {
                        //formID is already created and will be updated.

                        //check if formID is added to tbl_form_ebqe_mobile
                        WebRequest reqFormMobileCheck = WebRequest.Create(DBManagement.DBConnection + "tbl_form_ebqe_mobile_read.php");

                        reqFormMobileCheck.Method = "POST";
                        reqFormMobileCheck.ContentType = "application/x-www-form-urlencoded";

                        string postDataFormMobileCheck = "id=" + App.user.selected_mstr_ebqe + "&einrichtung=" + App.user.id_org_einrichtung + "&wohnbereich=" + App.user.id_org_wohnbereich + "&bewonerid=" + App.user.selected_id_bewohner;
                        byte[] byteArrayFormMobileCheck = Encoding.UTF8.GetBytes(postDataFormMobileCheck);

                        reqFormMobileCheck.ContentLength = byteArrayFormMobileCheck.Length;

                        Stream dsFormMobileCheck = await reqFormMobileCheck.GetRequestStreamAsync();
                        await dsFormMobileCheck.WriteAsync(byteArrayFormMobileCheck, 0, byteArrayFormMobileCheck.Length);
                        dsFormMobileCheck.Close();

                        WebResponse responseFormMobileCheck = await reqFormMobileCheck.GetResponseAsync();

                        Stream dataStreamFormMobileCheck = responseFormMobileCheck.GetResponseStream();

                        StreamReader readerFormMobileCheck = new StreamReader(dataStreamFormMobileCheck);

                        string sFormMobileCheck = await readerFormMobileCheck.ReadToEndAsync();

                        if (sFormMobileCheck == Erfassungsbogen.id_form_ebqe_string)
                        {
                            await Navigation.PushAsync(new SearchPage());
                        }
                        else
                        {
                            //make entry in form_ebqe_mobile
                            WebRequest req3 = WebRequest.Create(DBManagement.DBConnection + "tbl_form_ebqe_mobile_insert.php");

                            req3.Method = "POST";
                            req3.ContentType = "application/x-www-form-urlencoded";

                            string postData3 = "id=" + App.user.selected_mstr_ebqe + "&einrichtung=" + App.user.id_org_einrichtung + "&wohnbereich=" + App.user.id_org_wohnbereich + "&bewonerid=" + App.user.selected_id_bewohner + "&bogenart=" + item.Bogenart + "&maxId=" + Erfassungsbogen.id_form_ebqe_string;
                            byte[] byteArray3 = Encoding.UTF8.GetBytes(postData3);

                            req3.ContentLength = byteArray3.Length;

                            Stream ds3 = await req3.GetRequestStreamAsync();
                            await ds3.WriteAsync(byteArray3, 0, byteArray3.Length);
                            ds3.Close();

                            WebResponse response3 = await req3.GetResponseAsync();

                            Stream dataStream3 = response3.GetResponseStream();

                            StreamReader reader3 = new StreamReader(dataStream3);

                            string s3 = await reader3.ReadToEndAsync();

                            await Navigation.PushAsync(new SearchPage());
                        }
                    }
                    else
                    {
                        //form is not yet created, so we need to get the the max id = new form id for new patient 
                        if (App.user.selected_mstr_ebqe == DBManagement.CurrentEvaluationID)
                        {
                            WebRequest req1 = WebRequest.Create(DBManagement.DBConnection + "tbl_form_ebqe_max_id_read.php");

                            req1.Method = "POST";
                            req1.ContentType = "application/x-www-form-urlencoded";

                            string postData1 = "";
                            byte[] byteArray1 = Encoding.UTF8.GetBytes(postData1);

                            req1.ContentLength = byteArray1.Length;

                            Stream ds1 = await req1.GetRequestStreamAsync();
                            await ds1.WriteAsync(byteArray1, 0, byteArray1.Length);
                            ds1.Close();

                            WebResponse response1 = await req1.GetResponseAsync();

                            Stream dataStream1 = response1.GetResponseStream();

                            StreamReader reader1 = new StreamReader(dataStream1);

                            string s1 = await reader1.ReadToEndAsync();

                            //increment max_id
                            Erfassungsbogen.id_form_ebqe = Convert.ToInt32(s1) + 1;

                            // insert of new form_ebqe

                            WebRequest req2 = WebRequest.Create(DBManagement.DBConnection + "tbl_form_ebqe_insert.php");

                            req2.Method = "POST";
                            req2.ContentType = "application/x-www-form-urlencoded";

                            string postData2 = "id=" + App.user.selected_mstr_ebqe + "&einrichtung=" + App.user.id_org_einrichtung + "&wohnbereich=" + App.user.id_org_wohnbereich + "&bewonerid=" + App.user.selected_id_bewohner + "&bogenart=" + item.Bogenart + "&maxId=" + Erfassungsbogen.id_form_ebqe;
                            byte[] byteArray2 = Encoding.UTF8.GetBytes(postData2);

                            req2.ContentLength = byteArray2.Length;

                            Stream ds2 = await req2.GetRequestStreamAsync();
                            await ds2.WriteAsync(byteArray2, 0, byteArray2.Length);
                            ds2.Close();

                            WebResponse response2 = await req2.GetResponseAsync();

                            Stream dataStream2 = response2.GetResponseStream();

                            StreamReader reader2 = new StreamReader(dataStream2);

                            string s2 = await reader2.ReadToEndAsync();

                            //make entry in form_ebqe_mobile
                            WebRequest req3 = WebRequest.Create(DBManagement.DBConnection + "tbl_form_ebqe_mobile_insert.php");

                            req3.Method = "POST";
                            req3.ContentType = "application/x-www-form-urlencoded";

                            string postData3 = "id=" + App.user.selected_mstr_ebqe + "&einrichtung=" + App.user.id_org_einrichtung + "&wohnbereich=" + App.user.id_org_wohnbereich + "&bewonerid=" + App.user.selected_id_bewohner + "&bogenart=" + item.Bogenart + "&maxId=" + Erfassungsbogen.id_form_ebqe;
                            byte[] byteArray3 = Encoding.UTF8.GetBytes(postData3);

                            req3.ContentLength = byteArray3.Length;

                            Stream ds3 = await req3.GetRequestStreamAsync();
                            await ds3.WriteAsync(byteArray3, 0, byteArray3.Length);
                            ds3.Close();

                            WebResponse response3 = await req3.GetResponseAsync();

                            Stream dataStream3 = response3.GetResponseStream();

                            StreamReader reader3 = new StreamReader(dataStream3);

                            string s3 = await reader3.ReadToEndAsync();
                        }

                        await Navigation.PushAsync(new SearchPage());
                    }
                }
                //Bogenart == 1 -> ohne QE
                else
                {
                    //Make new Survey Form
                    ErfassungsbogenNoQE.id_mstr_ebqe = App.user.selected_mstr_ebqe;
                    ErfassungsbogenNoQE.id_orga_Einrichtung = App.user.id_org_einrichtung;
                    ErfassungsbogenNoQE.id_orga_Wohnbereich = App.user.id_org_wohnbereich;
                    ErfassungsbogenNoQE.id_pers_Bewohner = item.id;
                    ErfassungsbogenNoQE.Bewohnerbezeichnung = item.Bewohnerbezeichnung;
                    ErfassungsbogenNoQE.Bewohnercode = item.Bewohnercode;
                    ErfassungsbogenNoQE.Vorname = item.Vorname;
                    ErfassungsbogenNoQE.Nachname = item.Nachname;
                    ErfassungsbogenNoQE.bogenart = 1;
                    ErfassungsbogenNoQE.tkurzfield01 = item.DatumHeimeinzug;
                    ErfassungsbogenNoQE.tkurzfield02 = item.Geburtsmonat;
                    ErfassungsbogenNoQE.tkurzfield03 = item.Geburtsjahr;
                    ErfassungsbogenNoQE.tkurzfield04 = item.Geschlecht;
                    ErfassungsbogenNoQE.loadedFromDB = false;

                    // reading the form_ebqe_value  (we get only form_ebqe value with mstr_id)

                    WebRequest req = WebRequest.Create(DBManagement.DBConnection + "tbl_form_ebqe_read.php");

                    req.Method = "POST";
                    req.Timeout = 15000;
                    req.ContentType = "application/x-www-form-urlencoded";

                    string postData = "id=" + App.user.selected_mstr_ebqe + "&einrichtung=" + App.user.id_org_einrichtung + "&wohnbereich=" + App.user.id_org_wohnbereich + "&bewonerid=" + App.user.selected_id_bewohner;
                    byte[] byteArray = Encoding.UTF8.GetBytes(postData);

                    req.ContentLength = byteArray.Length;

                    Stream ds = await req.GetRequestStreamAsync();
                    await ds.WriteAsync(byteArray, 0, byteArray.Length);
                    ds.Close();

                    WebResponse response = await req.GetResponseAsync();

                    Stream dataStream = response.GetResponseStream();

                    StreamReader reader = new StreamReader(dataStream);

                    string s = reader.ReadToEnd();
                    //  ErfassungsbogenNoQE.form_id_read = Convert.ToInt32(s);
                    ErfassungsbogenNoQE.id_form_ebqe_string = s;

                    if (ErfassungsbogenNoQE.id_form_ebqe_string != "" && ErfassungsbogenNoQE.id_form_ebqe_string != null)
                    {
                        //formID is already created and will be updated.

                        //check if formID is added to tbl_form_ebqe_mobile
                        WebRequest reqFormMobileCheck = WebRequest.Create(DBManagement.DBConnection + "tbl_form_ebqe_mobile_read.php");

                        reqFormMobileCheck.Method = "POST";
                        reqFormMobileCheck.ContentType = "application/x-www-form-urlencoded";

                        string postDataFormMobileCheck = "id=" + App.user.selected_mstr_ebqe + "&einrichtung=" + App.user.id_org_einrichtung +
                                        "&wohnbereich=" + App.user.id_org_wohnbereich + "&bewonerid=" + App.user.selected_id_bewohner;
                        byte[] byteArrayFormMobileCheck = Encoding.UTF8.GetBytes(postDataFormMobileCheck);

                        reqFormMobileCheck.ContentLength = byteArrayFormMobileCheck.Length;

                        Stream dsFormMobileCheck = await reqFormMobileCheck.GetRequestStreamAsync();
                        await dsFormMobileCheck.WriteAsync(byteArrayFormMobileCheck, 0, byteArrayFormMobileCheck.Length);
                        dsFormMobileCheck.Close();

                        WebResponse responseFormMobileCheck = await reqFormMobileCheck.GetResponseAsync();

                        Stream dataStreamFormMobileCheck = responseFormMobileCheck.GetResponseStream();

                        StreamReader readerFormMobileCheck = new StreamReader(dataStreamFormMobileCheck);

                        string sFormMobileCheck = await readerFormMobileCheck.ReadToEndAsync();

                        if (sFormMobileCheck == ErfassungsbogenNoQE.id_form_ebqe_string)
                        {
                            await Navigation.PushAsync(new CategoryPageNoQE());
                        }
                        else
                        {
                            //make entry in form_ebqe_mobile
                            WebRequest req3 = WebRequest.Create(DBManagement.DBConnection + "tbl_form_ebqe_mobile_insert.php");

                            req3.Method = "POST";
                            req3.ContentType = "application/x-www-form-urlencoded";

                            string postData3 = "id=" + App.user.selected_mstr_ebqe + "&einrichtung=" + App.user.id_org_einrichtung + "&wohnbereich=" + App.user.id_org_wohnbereich + "&bewonerid=" + App.user.selected_id_bewohner + "&bogenart=" + item.Bogenart + "&maxId=" + ErfassungsbogenNoQE.id_form_ebqe_string;
                            byte[] byteArray3 = Encoding.UTF8.GetBytes(postData3);

                            req3.ContentLength = byteArray3.Length;

                            Stream ds3 = await req3.GetRequestStreamAsync();
                            await ds3.WriteAsync(byteArray3, 0, byteArray3.Length);
                            ds3.Close();

                            WebResponse response3 = await req3.GetResponseAsync();

                            Stream dataStream3 = response3.GetResponseStream();

                            StreamReader reader3 = new StreamReader(dataStream3);

                            string s3 = await reader3.ReadToEndAsync();

                            await Navigation.PushAsync(new CategoryPageNoQE());
                        }
                    }
                    else
                    {
                        //form is not yet created, so we need to get the the max id = new form id for new patient 
                        if (App.user.selected_mstr_ebqe == DBManagement.CurrentEvaluationID)
                        {
                            WebRequest req1 = WebRequest.Create(DBManagement.DBConnection + "tbl_form_ebqe_max_id_read.php");

                            req1.Method = "POST";
                            req1.ContentType = "application/x-www-form-urlencoded";

                            string postData1 = "";
                            byte[] byteArray1 = Encoding.UTF8.GetBytes(postData1);

                            req1.ContentLength = byteArray1.Length;

                            Stream ds1 = await req1.GetRequestStreamAsync();
                            await ds1.WriteAsync(byteArray1, 0, byteArray1.Length);
                            ds1.Close();

                            WebResponse response1 = await req1.GetResponseAsync();

                            Stream dataStream1 = response1.GetResponseStream();

                            StreamReader reader1 = new StreamReader(dataStream1);

                            string s1 = await reader1.ReadToEndAsync();

                            //increment max_id
                            ErfassungsbogenNoQE.id_form_ebqe = Convert.ToInt32(s1) + 1;

                            // insert of new form_ebqe

                            WebRequest req2 = WebRequest.Create(DBManagement.DBConnection + "tbl_form_ebqe_insert.php");

                            req2.Method = "POST";
                            req2.ContentType = "application/x-www-form-urlencoded";

                            string postData2 = "id=" + App.user.selected_mstr_ebqe + "&einrichtung=" + App.user.id_org_einrichtung + "&wohnbereich=" + App.user.id_org_wohnbereich + "&bewonerid=" + App.user.selected_id_bewohner + "&bogenart=" + item.Bogenart + "&maxId=" + ErfassungsbogenNoQE.id_form_ebqe;
                            byte[] byteArray2 = Encoding.UTF8.GetBytes(postData2);

                            req2.ContentLength = byteArray2.Length;

                            Stream ds2 = await req2.GetRequestStreamAsync();
                            await ds2.WriteAsync(byteArray2, 0, byteArray2.Length);
                            ds2.Close();

                            WebResponse response2 = await req2.GetResponseAsync();

                            Stream dataStream2 = response2.GetResponseStream();

                            StreamReader reader2 = new StreamReader(dataStream2);

                            string s2 = await reader2.ReadToEndAsync();

                            //make entry in form_ebqe_mobile
                            WebRequest req3 = WebRequest.Create(DBManagement.DBConnection + "tbl_form_ebqe_mobile_insert.php");

                            req3.Method = "POST";
                            req3.ContentType = "application/x-www-form-urlencoded";

                            string postData3 = "id=" + App.user.selected_mstr_ebqe + "&einrichtung=" + App.user.id_org_einrichtung + "&wohnbereich=" + App.user.id_org_wohnbereich + "&bewonerid=" + App.user.selected_id_bewohner + "&bogenart=" + item.Bogenart + "&maxId=" + ErfassungsbogenNoQE.id_form_ebqe;
                            byte[] byteArray3 = Encoding.UTF8.GetBytes(postData3);

                            req3.ContentLength = byteArray3.Length;

                            Stream ds3 = await req3.GetRequestStreamAsync();
                            await ds3.WriteAsync(byteArray3, 0, byteArray3.Length);
                            ds3.Close();

                            WebResponse response3 = await req3.GetResponseAsync();

                            Stream dataStream3 = response3.GetResponseStream();

                            StreamReader reader3 = new StreamReader(dataStream3);

                            string s3 = await reader3.ReadToEndAsync();
                        }

                        await Navigation.PushAsync(new CategoryPageNoQE());
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

        private void Sb_search_TextChanged(object sender, TextChangedEventArgs e)
        {
            List<Patient> filteredPatients = new List<Patient>();

            if (AppManager.ListOfPatientSettingQE == true)
            {
                if (AppManager.ListOfPatientSettingNoQE == true)
                {
                    if (AppManager.ListOfPatientSettingOpen == true)
                    {
                        if (AppManager.ListOfPatientSettingFinished == true)
                        {
                            filteredPatients = people1.Where(a => a.isSurveyCompleted == 0 | a.isSurveyCompleted == 1).ToList();
                        }
                        else
                        {
                            filteredPatients = people1.Where(a => a.isSurveyCompleted == 0 && a.isSurveyCompleted != 1).ToList();
                        }
                    }
                    else
                    {
                        if (AppManager.ListOfPatientSettingFinished == false)
                        {
                            filteredPatients = people1.Where(a => a.isSurveyCompleted != 0 && a.isSurveyCompleted != 1).ToList();
                        }
                        else
                        {
                            filteredPatients = people1.Where(a => a.isSurveyCompleted != 0 && a.isSurveyCompleted == 1).ToList();
                        }
                    }
                }
                else
                {
                    if (AppManager.ListOfPatientSettingOpen == true)
                    {
                        if (AppManager.ListOfPatientSettingFinished == true)
                        {
                            filteredPatients = people1.Where(a => a.isSurveyCompleted == 0 | a.isSurveyCompleted == 1).Where(a => a.Bogenart != 1).ToList();
                        }
                        else
                        {
                            filteredPatients = people1.Where(a => a.isSurveyCompleted == 0 && a.isSurveyCompleted != 1).Where(a => a.Bogenart != 1).ToList();
                        }
                    }
                    else
                    {
                        if (AppManager.ListOfPatientSettingFinished == false)
                        {
                            filteredPatients = people1.Where(a => a.isSurveyCompleted != 0 && a.isSurveyCompleted != 1).Where(a => a.Bogenart != 1).ToList();
                        }
                        else
                        {
                            filteredPatients = people1.Where(a => a.isSurveyCompleted != 0 && a.isSurveyCompleted == 1).Where(a => a.Bogenart != 1).ToList();
                        }
                    }
                }
            }
            else
            {
                if (AppManager.ListOfPatientSettingNoQE == true)
                {
                    if (AppManager.ListOfPatientSettingOpen == true)
                    {
                        if (AppManager.ListOfPatientSettingFinished == true)
                        {
                            filteredPatients = people1.Where(a => a.isSurveyCompleted == 0 | a.isSurveyCompleted == 1).Where(a => a.Bogenart != 0).ToList();
                        }
                        else
                        {
                            filteredPatients = people1.Where(a => a.isSurveyCompleted == 0 && a.isSurveyCompleted != 1).Where(a => a.Bogenart != 0).ToList();
                        }
                    }
                    else
                    {
                        if (AppManager.ListOfPatientSettingFinished == false)
                        {
                            filteredPatients = people1.Where(a => a.isSurveyCompleted != 0 && a.isSurveyCompleted != 1).Where(a => a.Bogenart != 0).ToList();
                        }
                        else
                        {
                            filteredPatients = people1.Where(a => a.isSurveyCompleted != 0 && a.isSurveyCompleted == 1).Where(a => a.Bogenart != 0).ToList();
                        }
                    }
                }
                else
                {
                    if (AppManager.ListOfPatientSettingOpen == true)
                    {
                        if (AppManager.ListOfPatientSettingFinished == true)
                        {
                            filteredPatients = people1.Where(a => a.isSurveyCompleted == 0 | a.isSurveyCompleted == 1).Where(a => a.Bogenart != 0 && a.Bogenart != 1).ToList();
                        }
                        else
                        {
                            filteredPatients = people1.Where(a => a.isSurveyCompleted == 0 && a.isSurveyCompleted != 1).Where(a => a.Bogenart != 0 && a.Bogenart != 1).ToList();
                        }
                    }
                    else
                    {
                        if (AppManager.ListOfPatientSettingFinished == false)
                        {
                            filteredPatients = people1.Where(a => a.isSurveyCompleted != 0 && a.isSurveyCompleted != 1).Where(a => a.Bogenart != 0 && a.Bogenart != 1).ToList();
                        }
                        else
                        {
                            filteredPatients = people1.Where(a => a.isSurveyCompleted != 0 && a.isSurveyCompleted == 1).Where(a => a.Bogenart != 0 && a.Bogenart != 1).ToList();
                        }
                    }
                }
            }

            if (sb_search.Text != "" && sb_search.Text != null)
            {
                var result = filteredPatients.Where(x => x.Bewohnerbezeichnung.ToLower().Contains(sb_search.Text));
                MyList.ItemsSource = result;
            }
            else
            {
                var result = filteredPatients;
                MyList.ItemsSource = result;
            }
        }

        private void OpenButtonImage_Tapped(object sender, EventArgs e)
        {
            if (AppManager.ListOfPatientSettingOpen == false)
            {
                AppManager.ListOfPatientSettingOpen = true;
                OpenButtonImage.Source = "ic_check_box.png";           
            }
            else
            {
                AppManager.ListOfPatientSettingOpen = false;
                OpenButtonImage.Source = "ic_check_box_outline_blank.png";
            }

            List<Patient> filteredPatients = new List<Patient>();

            if (AppManager.ListOfPatientSettingQE == true)
            {
                if (AppManager.ListOfPatientSettingNoQE == true)
                {
                    if (AppManager.ListOfPatientSettingOpen == true)
                    {
                        if (AppManager.ListOfPatientSettingFinished == true)
                        {
                            filteredPatients = people1.Where(a => a.isSurveyCompleted == 0 | a.isSurveyCompleted == 1).ToList();
                        }
                        else
                        {
                            filteredPatients = people1.Where(a => a.isSurveyCompleted == 0 && a.isSurveyCompleted != 1).ToList();
                        }
                    }
                    else
                    {
                        if (AppManager.ListOfPatientSettingFinished == false)
                        {
                            filteredPatients = people1.Where(a => a.isSurveyCompleted != 0 && a.isSurveyCompleted != 1).ToList();
                        }
                        else
                        {
                            filteredPatients = people1.Where(a => a.isSurveyCompleted != 0 && a.isSurveyCompleted == 1).ToList();
                        }
                    }
                }
                else
                {
                    if (AppManager.ListOfPatientSettingOpen == true)
                    {
                        if (AppManager.ListOfPatientSettingFinished == true)
                        {
                            filteredPatients = people1.Where(a => a.isSurveyCompleted == 0 | a.isSurveyCompleted == 1).Where(a => a.Bogenart != 1).ToList();
                        }
                        else
                        {
                            filteredPatients = people1.Where(a => a.isSurveyCompleted == 0 && a.isSurveyCompleted != 1).Where(a => a.Bogenart != 1).ToList();
                        }
                    }
                    else
                    {
                        if (AppManager.ListOfPatientSettingFinished == false)
                        {
                            filteredPatients = people1.Where(a => a.isSurveyCompleted != 0 && a.isSurveyCompleted != 1).Where(a => a.Bogenart != 1).ToList();
                        }
                        else
                        {
                            filteredPatients = people1.Where(a => a.isSurveyCompleted != 0 && a.isSurveyCompleted == 1).Where(a => a.Bogenart != 1).ToList();
                        }
                    }
                }
            }
            else
            {
                if (AppManager.ListOfPatientSettingNoQE == true)
                {
                    if (AppManager.ListOfPatientSettingOpen == true)
                    {
                        if (AppManager.ListOfPatientSettingFinished == true)
                        {
                            filteredPatients = people1.Where(a => a.isSurveyCompleted == 0 | a.isSurveyCompleted == 1).Where(a => a.Bogenart != 0).ToList();
                        }
                        else
                        {
                            filteredPatients = people1.Where(a => a.isSurveyCompleted == 0 && a.isSurveyCompleted != 1).Where(a => a.Bogenart != 0).ToList();
                        }
                    }
                    else
                    {
                        if (AppManager.ListOfPatientSettingFinished == false)
                        {
                            filteredPatients = people1.Where(a => a.isSurveyCompleted != 0 && a.isSurveyCompleted != 1).Where(a => a.Bogenart != 0).ToList();
                        }
                        else
                        {
                            filteredPatients = people1.Where(a => a.isSurveyCompleted != 0 && a.isSurveyCompleted == 1).Where(a => a.Bogenart != 0).ToList();
                        }
                    }
                }
                else
                {
                    if (AppManager.ListOfPatientSettingOpen == true)
                    {
                        if (AppManager.ListOfPatientSettingFinished == true)
                        {
                            filteredPatients = people1.Where(a => a.isSurveyCompleted == 0 | a.isSurveyCompleted == 1).Where(a => a.Bogenart != 0 && a.Bogenart != 1).ToList();
                        }
                        else
                        {
                            filteredPatients = people1.Where(a => a.isSurveyCompleted == 0 && a.isSurveyCompleted != 1).Where(a => a.Bogenart != 0 && a.Bogenart != 1).ToList();
                        }
                    }
                    else
                    {
                        if (AppManager.ListOfPatientSettingFinished == false)
                        {
                            filteredPatients = people1.Where(a => a.isSurveyCompleted != 0 && a.isSurveyCompleted != 1).Where(a => a.Bogenart != 0 && a.Bogenart != 1).ToList();
                        }
                        else
                        {
                            filteredPatients = people1.Where(a => a.isSurveyCompleted != 0 && a.isSurveyCompleted == 1).Where(a => a.Bogenart != 0 && a.Bogenart != 1).ToList();
                        }
                    }
                }
            }

            if (sb_search.Text != "" && sb_search.Text != null)
            {
                var result = filteredPatients.Where(x => x.Bewohnerbezeichnung.ToLower().Contains(sb_search.Text));
                MyList.ItemsSource = result;
            }
            else
            {
                var result = filteredPatients;
                MyList.ItemsSource = result;
            }
        }

        private void FinishedButtonImage_Tapped(object sender, EventArgs e)
        {
            if (AppManager.ListOfPatientSettingFinished == false)
            {
                AppManager.ListOfPatientSettingFinished = true;
                FinishedButtonImage.Source = "ic_check_box.png";
            }
            else
            {
                AppManager.ListOfPatientSettingFinished = false;
                FinishedButtonImage.Source = "ic_check_box_outline_blank.png";
            }

            List<Patient> filteredPatients = new List<Patient>();

            if (AppManager.ListOfPatientSettingQE == true)
            {
                if (AppManager.ListOfPatientSettingNoQE == true)
                {
                    if (AppManager.ListOfPatientSettingOpen == true)
                    {
                        if (AppManager.ListOfPatientSettingFinished == true)
                        {
                            filteredPatients = people1.Where(a => a.isSurveyCompleted == 0 | a.isSurveyCompleted == 1).ToList();
                        }
                        else
                        {
                            filteredPatients = people1.Where(a => a.isSurveyCompleted == 0 && a.isSurveyCompleted != 1).ToList();
                        }
                    }
                    else
                    {
                        if (AppManager.ListOfPatientSettingFinished == false)
                        {
                            filteredPatients = people1.Where(a => a.isSurveyCompleted != 0 && a.isSurveyCompleted != 1).ToList();
                        }
                        else
                        {
                            filteredPatients = people1.Where(a => a.isSurveyCompleted != 0 && a.isSurveyCompleted == 1).ToList();
                        }
                    }
                }
                else
                {
                    if (AppManager.ListOfPatientSettingOpen == true)
                    {
                        if (AppManager.ListOfPatientSettingFinished == true)
                        {
                            filteredPatients = people1.Where(a => a.isSurveyCompleted == 0 | a.isSurveyCompleted == 1).Where(a => a.Bogenart != 1).ToList();
                        }
                        else
                        {
                            filteredPatients = people1.Where(a => a.isSurveyCompleted == 0 && a.isSurveyCompleted != 1).Where(a => a.Bogenart != 1).ToList();
                        }
                    }
                    else
                    {
                        if (AppManager.ListOfPatientSettingFinished == false)
                        {
                            filteredPatients = people1.Where(a => a.isSurveyCompleted != 0 && a.isSurveyCompleted != 1).Where(a => a.Bogenart != 1).ToList();
                        }
                        else
                        {
                            filteredPatients = people1.Where(a => a.isSurveyCompleted != 0 && a.isSurveyCompleted == 1).Where(a => a.Bogenart != 1).ToList();
                        }
                    }
                }
            }
            else
            {
                if (AppManager.ListOfPatientSettingNoQE == true)
                {
                    if (AppManager.ListOfPatientSettingOpen == true)
                    {
                        if (AppManager.ListOfPatientSettingFinished == true)
                        {
                            filteredPatients = people1.Where(a => a.isSurveyCompleted == 0 | a.isSurveyCompleted == 1).Where(a => a.Bogenart != 0).ToList();
                        }
                        else
                        {
                            filteredPatients = people1.Where(a => a.isSurveyCompleted == 0 && a.isSurveyCompleted != 1).Where(a => a.Bogenart != 0).ToList();
                        }
                    }
                    else
                    {
                        if (AppManager.ListOfPatientSettingFinished == false)
                        {
                            filteredPatients = people1.Where(a => a.isSurveyCompleted != 0 && a.isSurveyCompleted != 1).Where(a => a.Bogenart != 0).ToList();
                        }
                        else
                        {
                            filteredPatients = people1.Where(a => a.isSurveyCompleted != 0 && a.isSurveyCompleted == 1).Where(a => a.Bogenart != 0).ToList();
                        }
                    }
                }
                else
                {
                    if (AppManager.ListOfPatientSettingOpen == true)
                    {
                        if (AppManager.ListOfPatientSettingFinished == true)
                        {
                            filteredPatients = people1.Where(a => a.isSurveyCompleted == 0 | a.isSurveyCompleted == 1).Where(a => a.Bogenart != 0 && a.Bogenart != 1).ToList();
                        }
                        else
                        {
                            filteredPatients = people1.Where(a => a.isSurveyCompleted == 0 && a.isSurveyCompleted != 1).Where(a => a.Bogenart != 0 && a.Bogenart != 1).ToList();
                        }
                    }
                    else
                    {
                        if (AppManager.ListOfPatientSettingFinished == false)
                        {
                            filteredPatients = people1.Where(a => a.isSurveyCompleted != 0 && a.isSurveyCompleted != 1).Where(a => a.Bogenart != 0 && a.Bogenart != 1).ToList();
                        }
                        else
                        {
                            filteredPatients = people1.Where(a => a.isSurveyCompleted != 0 && a.isSurveyCompleted == 1).Where(a => a.Bogenart != 0 && a.Bogenart != 1).ToList();
                        }
                    }
                }
            }

            if (sb_search.Text != "" && sb_search.Text != null)
            {
                var result = filteredPatients.Where(x => x.Bewohnerbezeichnung.ToLower().Contains(sb_search.Text));
                MyList.ItemsSource = result;
            }
            else
            {
                var result = filteredPatients;
                MyList.ItemsSource = result;
            }
        }

        private void QEButtonImage_Tapped(object sender, EventArgs e)
        {
            if (AppManager.ListOfPatientSettingQE == false)
            {
                AppManager.ListOfPatientSettingQE = true;
                QEButtonImage.Source = "ic_check_box.png";
            }
            else
            {
                AppManager.ListOfPatientSettingQE = false;
                QEButtonImage.Source = "ic_check_box_outline_blank.png";
            }

            List<Patient> filteredPatients = new List<Patient>();

            if (AppManager.ListOfPatientSettingQE == true)
            {
                if (AppManager.ListOfPatientSettingNoQE == true)
                {
                    if (AppManager.ListOfPatientSettingOpen == true)
                    {
                        if (AppManager.ListOfPatientSettingFinished == true)
                        {
                            filteredPatients = people1.Where(a => a.isSurveyCompleted == 0 | a.isSurveyCompleted == 1).ToList();
                        }
                        else
                        {
                            filteredPatients = people1.Where(a => a.isSurveyCompleted == 0 && a.isSurveyCompleted != 1).ToList();
                        }
                    }
                    else
                    {
                        if (AppManager.ListOfPatientSettingFinished == false)
                        {
                            filteredPatients = people1.Where(a => a.isSurveyCompleted != 0 && a.isSurveyCompleted != 1).ToList();
                        }
                        else
                        {
                            filteredPatients = people1.Where(a => a.isSurveyCompleted != 0 && a.isSurveyCompleted == 1).ToList();
                        }
                    }
                }
                else
                {
                    if (AppManager.ListOfPatientSettingOpen == true)
                    {
                        if (AppManager.ListOfPatientSettingFinished == true)
                        {
                            filteredPatients = people1.Where(a => a.isSurveyCompleted == 0 | a.isSurveyCompleted == 1).Where(a => a.Bogenart != 1).ToList();
                        }
                        else
                        {
                            filteredPatients = people1.Where(a => a.isSurveyCompleted == 0 && a.isSurveyCompleted != 1).Where(a => a.Bogenart != 1).ToList();
                        }
                    }
                    else
                    {
                        if (AppManager.ListOfPatientSettingFinished == false)
                        {
                            filteredPatients = people1.Where(a => a.isSurveyCompleted != 0 && a.isSurveyCompleted != 1).Where(a => a.Bogenart != 1).ToList();
                        }
                        else
                        {
                            filteredPatients = people1.Where(a => a.isSurveyCompleted != 0 && a.isSurveyCompleted == 1).Where(a => a.Bogenart != 1).ToList();
                        }
                    }
                }
            }
            else
            {
                if (AppManager.ListOfPatientSettingNoQE == true)
                {
                    if (AppManager.ListOfPatientSettingOpen == true)
                    {
                        if (AppManager.ListOfPatientSettingFinished == true)
                        {
                            filteredPatients = people1.Where(a => a.isSurveyCompleted == 0 | a.isSurveyCompleted == 1).Where(a => a.Bogenart != 0).ToList();
                        }
                        else
                        {
                            filteredPatients = people1.Where(a => a.isSurveyCompleted == 0 && a.isSurveyCompleted != 1).Where(a => a.Bogenart != 0).ToList();
                        }
                    }
                    else
                    {
                        if (AppManager.ListOfPatientSettingFinished == false)
                        {
                            filteredPatients = people1.Where(a => a.isSurveyCompleted != 0 && a.isSurveyCompleted != 1).Where(a => a.Bogenart != 0).ToList();
                        }
                        else
                        {
                            filteredPatients = people1.Where(a => a.isSurveyCompleted != 0 && a.isSurveyCompleted == 1).Where(a => a.Bogenart != 0).ToList();
                        }
                    }
                }
                else
                {
                    if (AppManager.ListOfPatientSettingOpen == true)
                    {
                        if (AppManager.ListOfPatientSettingFinished == true)
                        {
                            filteredPatients = people1.Where(a => a.isSurveyCompleted == 0 | a.isSurveyCompleted == 1).Where(a => a.Bogenart != 0 && a.Bogenart != 1).ToList();
                        }
                        else
                        {
                            filteredPatients = people1.Where(a => a.isSurveyCompleted == 0 && a.isSurveyCompleted != 1).Where(a => a.Bogenart != 0 && a.Bogenart != 1).ToList();
                        }
                    }
                    else
                    {
                        if (AppManager.ListOfPatientSettingFinished == false)
                        {
                            filteredPatients = people1.Where(a => a.isSurveyCompleted != 0 && a.isSurveyCompleted != 1).Where(a => a.Bogenart != 0 && a.Bogenart != 1).ToList();
                        }
                        else
                        {
                            filteredPatients = people1.Where(a => a.isSurveyCompleted != 0 && a.isSurveyCompleted == 1).Where(a => a.Bogenart != 0 && a.Bogenart != 1).ToList();
                        }
                    }
                }
            }

            if (sb_search.Text != "" && sb_search.Text != null)
            {
                var result = filteredPatients.Where(x => x.Bewohnerbezeichnung.ToLower().Contains(sb_search.Text));
                MyList.ItemsSource = result;
            }
            else
            {
                var result = filteredPatients;
                MyList.ItemsSource = result;
            }
        }

        private void NoQEButtonImage_Tapped(object sender, EventArgs e)
        {
            if (AppManager.ListOfPatientSettingNoQE == false)
            {
                AppManager.ListOfPatientSettingNoQE = true;
                NoQEButtonImage.Source = "ic_check_box.png";
            }
            else
            {
                AppManager.ListOfPatientSettingNoQE = false;
                NoQEButtonImage.Source = "ic_check_box_outline_blank.png";
            }

            List<Patient> filteredPatients = new List<Patient>();

            if (AppManager.ListOfPatientSettingQE == true)
            {
                if (AppManager.ListOfPatientSettingNoQE == true)
                {
                    if (AppManager.ListOfPatientSettingOpen == true)
                    {
                        if (AppManager.ListOfPatientSettingFinished == true)
                        {
                            filteredPatients = people1.Where(a => a.isSurveyCompleted == 0 | a.isSurveyCompleted == 1).ToList();
                        }
                        else
                        {
                            filteredPatients = people1.Where(a => a.isSurveyCompleted == 0 && a.isSurveyCompleted != 1).ToList();
                        }
                    }
                    else
                    {
                        if (AppManager.ListOfPatientSettingFinished == false)
                        {
                            filteredPatients = people1.Where(a => a.isSurveyCompleted != 0 && a.isSurveyCompleted != 1).ToList();
                        }
                        else
                        {
                            filteredPatients = people1.Where(a => a.isSurveyCompleted != 0 && a.isSurveyCompleted == 1).ToList();
                        }
                    }
                }
                else
                {
                    if (AppManager.ListOfPatientSettingOpen == true)
                    {
                        if (AppManager.ListOfPatientSettingFinished == true)
                        {
                            filteredPatients = people1.Where(a => a.isSurveyCompleted == 0 | a.isSurveyCompleted == 1).Where(a => a.Bogenart != 1).ToList();
                        }
                        else
                        {
                            filteredPatients = people1.Where(a => a.isSurveyCompleted == 0 && a.isSurveyCompleted != 1).Where(a => a.Bogenart != 1).ToList();
                        }
                    }
                    else
                    {
                        if (AppManager.ListOfPatientSettingFinished == false)
                        {
                            filteredPatients = people1.Where(a => a.isSurveyCompleted != 0 && a.isSurveyCompleted != 1).Where(a => a.Bogenart != 1).ToList();
                        }
                        else
                        {
                            filteredPatients = people1.Where(a => a.isSurveyCompleted != 0 && a.isSurveyCompleted == 1).Where(a => a.Bogenart != 1).ToList();
                        }
                    }
                }
            }
            else
            {
                if (AppManager.ListOfPatientSettingNoQE == true)
                {
                    if (AppManager.ListOfPatientSettingOpen == true)
                    {
                        if (AppManager.ListOfPatientSettingFinished == true)
                        {
                            filteredPatients = people1.Where(a => a.isSurveyCompleted == 0 | a.isSurveyCompleted == 1).Where(a => a.Bogenart != 0).ToList();
                        }
                        else
                        {
                            filteredPatients = people1.Where(a => a.isSurveyCompleted == 0 && a.isSurveyCompleted != 1).Where(a => a.Bogenart != 0).ToList();
                        }
                    }
                    else
                    {
                        if (AppManager.ListOfPatientSettingFinished == false)
                        {
                            filteredPatients = people1.Where(a => a.isSurveyCompleted != 0 && a.isSurveyCompleted != 1).Where(a => a.Bogenart != 0).ToList();
                        }
                        else
                        {
                            filteredPatients = people1.Where(a => a.isSurveyCompleted != 0 && a.isSurveyCompleted == 1).Where(a => a.Bogenart != 0).ToList();
                        }
                    }
                }
                else
                {
                    if (AppManager.ListOfPatientSettingOpen == true)
                    {
                        if (AppManager.ListOfPatientSettingFinished == true)
                        {
                            filteredPatients = people1.Where(a => a.isSurveyCompleted == 0 | a.isSurveyCompleted == 1).Where(a => a.Bogenart != 0 && a.Bogenart != 1).ToList();
                        }
                        else
                        {
                            filteredPatients = people1.Where(a => a.isSurveyCompleted == 0 && a.isSurveyCompleted != 1).Where(a => a.Bogenart != 0 && a.Bogenart != 1).ToList();
                        }
                    }
                    else
                    {
                        if (AppManager.ListOfPatientSettingFinished == false)
                        {
                            filteredPatients = people1.Where(a => a.isSurveyCompleted != 0 && a.isSurveyCompleted != 1).Where(a => a.Bogenart != 0 && a.Bogenart != 1).ToList();
                        }
                        else
                        {
                            filteredPatients = people1.Where(a => a.isSurveyCompleted != 0 && a.isSurveyCompleted == 1).Where(a => a.Bogenart != 0 && a.Bogenart != 1).ToList();
                        }
                    }
                }
            }            

            if (sb_search.Text != "" && sb_search.Text != null)
            {
                var result = filteredPatients.Where(x => x.Bewohnerbezeichnung.ToLower().Contains(sb_search.Text));
                MyList.ItemsSource = result;
            }
            else
            {
                var result = filteredPatients;
                MyList.ItemsSource = result;
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
