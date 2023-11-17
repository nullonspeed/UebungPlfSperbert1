using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    internal class Patient
    {
        public string Vorname { get; set; }
        public string Nachname { get; set; }
        public DateTime ZeitInKammer { get; set; }
        public double AktuellerKammerdruck { get; set; }
        public double MinimalerDruck { get; set; }
        public double MaximalerKammerdruck { get; set; }

        public override string ToString()
        {
            return $"{Vorname} {Nachname} ChamberTime: {ZeitInKammer.Hour}h Preassure: {AktuellerKammerdruck}bar MinPreassure: {MinimalerDruck}bar MaxPreassure {MaximalerKammerdruck}bar";
        }

        public string ToCSVString()
        {
            return $"{Vorname};{Nachname};{ZeitInKammer.Hour};{AktuellerKammerdruck};{MinimalerDruck};{MaximalerKammerdruck}";

        }

        public static bool TryParse(string lineCSV, out Patient patient)
        {
            string[] patientStringLines = lineCSV.Split(';') ;
            try
            {


                if (patientStringLines.Length == 6)
                {
                    patient = new Patient
                    {
                        Vorname = patientStringLines[0],
                        Nachname = patientStringLines[1],
                        ZeitInKammer = DateTime.Parse(patientStringLines[2]),
                        AktuellerKammerdruck = double.Parse(patientStringLines[3]),
                        MinimalerDruck = double.Parse(patientStringLines[4]),
                        MaximalerKammerdruck = double.Parse(patientStringLines[5])


                    };
                    
                    return true;
                }
                else {
                    patient = null ;
                    return false ; }
            }
            catch 
            {
                patient = null;
                return false;
            }
            

        }
    }
}
