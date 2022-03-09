using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace App6.Management
{
    public static class DBManagement
    {
        //Local
        // public static string DBConnection = "http://192.168.0.110/phpmyadmin/";

        //Online
        public static string DBConnection = "https://app.inqs.online/mobile/";

        //App Version
        public static string AppVersion = "v1.3.2";

        //App Language Setting
        public static CultureInfo AppLanguage;

        //Current Evaluation ID
        public static int CurrentEvaluationID = 14;

        public static string getYearCode (int mstr_id)
        {
            string year = string.Empty;

            if (mstr_id == 9)
            {
                year = "2/2017";
            }
            if (mstr_id == 10)
            {
                year = "1/2017";
            }
            if (mstr_id == 11)
            {
                year = "1/2018";
            }
            if (mstr_id == 12)
            {
                year = "2/2018";
            }
            if (mstr_id == 13)
            {
                year = "1/2019";
            }
            if (mstr_id == 14)
            {
                year = "2/2019";
            }

            return year;
        }
    }
}
