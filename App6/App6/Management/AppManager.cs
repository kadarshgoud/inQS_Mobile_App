using App6.Model;
using System.Drawing;

namespace App6.Management
{
    public static class AppManager
    {
        //Color, Opacity, FontStyle, Editable
        public static Color QuestionColor { get; set; }
        public static Color AnswerColor { get; set; }
        public static double QuestionOpacity { get; set; }
        public static double AnswerOpacity { get; set; }
        public static double ImageOpacity { get; set; }
        public static double QuestionDisabledOpacity { get; set; }
        public static double AnswerDisabledOpacity { get; set; }
        public static bool AnswerIsEditable { get; set; }
        public static string AnswerFontStyle { get; set; }


        //ListOfPatient Setting
        public static bool ListOfPatientSettingOpen { get; set; }
        public static bool ListOfPatientSettingFinished { get; set; }
        public static bool ListOfPatientSettingQE { get; set; }
        public static bool ListOfPatientSettingNoQE { get; set; }
    }
}
