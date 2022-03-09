namespace App6.Model
{
    //The survey class
    public static class ErfassungsbogenNoQE
    {
        //Survey Propteries
        public static int id { get; set; }
        public static int id_form_ebqe { get; set; }
        public static int id_orga_Einrichtung { get; set; }
        public static int id_orga_Wohnbereich { get; set; }
        public static int id_pers_Bewohner { get; set; }
        public static int id_mstr_ebqe { get; set; }
        public static int bogenart { get; set; }
        public static string id_form_ebqe_string { get; set; }
        public static string ende { get; set; }
        public static string endedatum { get; set; }

        //Load Optimization
        public static bool loadedFromDB { get; set; }

        //Layout Properties
        public static bool Is_enabled { get; set; }
        public static string Bewohnerbezeichnung { get; set; }
        public static string Bewohnercode { get; set; }
        public static string Vorname { get; set; }
        public static string Nachname { get; set; }

        // Calculating %
        public static double alg_sum { get; set; }

        //0. Allgemeines

        public static string tkurzfield01 { get; set; } //Heimeinzug
        public static string tkurzfield02 { get; set; } //Geburtsmonat
        public static string tkurzfield03 { get; set; } //Geburtsjahr
        public static string tkurzfield04 { get; set; } //Geschlecht
        public static string tkurzfield05 { get; set; } //Pflegegrad
        public static string tkurzfield06 { get; set; } //Bitte geben Sie den Grund an, warum der Bewohner nicht erfasst wurde:
        public static string tkurzfield07 { get; set; } //Sonstige Gründe
        public static string tkurzfield08 { get; set; } //Falls verstorben, wann:
        public static string tkurzfield09 { get; set; } //Wo ist er verstorben?
    }
}
