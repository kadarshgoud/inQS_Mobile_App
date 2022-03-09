namespace App6.Model
{
    public class Patient
    {

        public int id { get; set; }
        public int id_orga_Wohnbereich { get; set; }
        public int id_orga_Einrichtung { get; set; }
        public string Bewohnercode { get; set; }
        public string Vorname { get; set; }
        public string Nachname { get; set; }
        public string Bewohnerbezeichnung { get; set; }
        public string Geburtsmonat { get; set; }
        public string Geburtsjahr { get; set; }
        public string DatumHeimeinzug { get; set; }
        public string Geschlecht { get; set; }
        public int Bogenart { get; set; }

        //Filtering
        public int isSurveyCompleted { get; set; }
    }
}
