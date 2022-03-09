using App6.Model;
using System.Collections.Generic;

namespace App6.Management
{
    public static class PatientManager
    {
        public static List<Patient> PatientListCompleted { get; set; }
        public static List<Patient> PatientListOpen { get; set; }

        static PatientManager()
        {
            PatientListCompleted = new List<Patient>();
            PatientListOpen = new List<Patient>();
        }
    }
}
