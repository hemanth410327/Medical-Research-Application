using System.Collections;


namespace Hackathon
{
    enum Severty
    {
        Low=1, Medium, High
    }

    enum Factors
    {
        ExternalFactors=1, InternalFactors
    }
    class Diseases
    {
        static int diseaseId = 0;

        public int DiseaseID { get; private set; } = ++diseaseId;
        public string DiseaseName { get; set; }
        public string DiseaseSeverity { get; set; }
        public string DiseaseCause { get; set; }
        public string Description { get; set; }
    }

    class DiseaseManager
    {
        static ArrayList _Diseases = new ArrayList();

        public ArrayList GetAllDiseases()
        {
            return _Diseases;
        }

        public void AddDisease(Diseases diseases)
        {
            _Diseases.Add(diseases);
        }
    }
}
