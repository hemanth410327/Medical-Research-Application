using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hackathon
{
    class Symptoms
    {
        public string DiseaseName { get; set; }
        public string Symptom { get; set; }
        public string Description { get; set; }
    }

    class SymptomsManager
    {
        static ArrayList _Symptoms = new ArrayList();

        public ArrayList GetAllSymptoms()
        {
            return _Symptoms;
        }

        public void AddSymptoms(Symptoms symptoms)
        {
            _Symptoms.Add(symptoms);
        }
    }
}
