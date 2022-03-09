namespace App6.Model
{
    public class User
    {
        public int id_org_einrichtung { get; set; }

        public int id_org_wohnbereich { get; set; }

        public int id_benutzer { get; set; }

        public int selected_mstr_ebqe { get; set; }

        public int Nr_patients { get; set; }

        public int selected_id_bewohner { get; set;  }

        public string field { get; set; }

        public int benutzer_gruppe { get; set; }

        public string username { get; set; }

        public string einrichtung_address { get; set; }

        public string wohnbereich_address { get; set; }
    }
}
