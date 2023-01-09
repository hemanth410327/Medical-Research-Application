using System.IO;
using System;
using MyHelperClassRepo;
using System.Linq;


namespace Hackathon
{
    class UI
    {
       static DiseaseManager diseaseManager = null;
       static SymptomsManager symptomsManager = null;
        public static void Run(string menu)
        {
            bool Repeat = true;
            int choice = 0;
            string Menu = File.ReadAllText(menu);

            while (Repeat)
            {
                Console.WriteLine(Menu);
                try {
                    choice = Convert.ToInt32(Console.ReadLine());
                }catch(Exception)
                {
                    Console.WriteLine("\n**************************** Thank you *******************************");
                    return;
                }
                Repeat = Loop(choice);
            }
        }

        private static bool Loop(int choice)
        {
            switch (choice)
            {
                case 1: diseaseManager = ResearchFactory.GetInstance(choice) as DiseaseManager;
                    Diseases diseases = getDisease();
                    if (diseases != null)
                    {
                        diseaseManager.AddDisease(diseases);
                    }
                    return true;

                case 2: symptomsManager = ResearchFactory.GetInstance(choice) as SymptomsManager;
                    Symptoms symptoms = getSymptoms();
                    if (symptoms != null)
                    {
                        symptomsManager.AddSymptoms(symptoms);
                    }
                    return true;
                
                case 3:
                    if (diseaseManager != null && symptomsManager != null)
                    {
                        string Name = MyHelperClass.GetValue("\nEnter Patient Name");
                        string symptons = MyHelperClass.GetValue("\nEnter the Symptoms").ToLower();
                        DisplayDiseases(symptons);
                    }
                    else
                    {
                        Console.WriteLine("\nNo Diseases or symptoms are added yet!!\n");
                    }
                    return true;

                default:
                    Console.WriteLine("\n**************************** Thank you *******************************");
                    return false;
            }
        }

        private static void DisplayDiseases(string symptons)
        {
            Console.WriteLine("\nThe Diseases \n");
            string[] symptomsArray = symptons.Split(',');

            foreach (Symptoms item in symptomsManager.GetAllSymptoms())
            {
                if (symptomsArray.Any(item.Symptom.Contains))
                {
                    Console.WriteLine(item.DiseaseName);
                }
            }
        }

        private static Symptoms getSymptoms()
        {
            if (diseaseManager != null)
            {
                displayDisease();
                string DiseaseName = MyHelperClass.GetValue("\nChoose disease name from above").ToLower();
                string symptoms = MyHelperClass.GetValue("\nEnter Symptoms, if more then one then seperate each by a coma(fever,cold,...)").ToLower();
                string Description = MyHelperClass.GetValue("\nEnter Decription");

                if (ValidateSymptomsInput(DiseaseName, symptoms, Description))
                {
                    return new Symptoms { Description = Description, DiseaseName = DiseaseName, Symptom = symptoms };
                }

                Console.WriteLine("\nPlease Enter all the Fields and correct values");
                return null;
            }
            else
            {
                Console.WriteLine("No Diseases are added yet!!");
                return null;
            }
        }

        private static bool ValidateSymptomsInput(string diseaseName, string symptoms, string description)
        {
            if (diseaseName != "" && symptoms != "" && description != "")
            {
                foreach (Diseases item in diseaseManager.GetAllDiseases())
                {
                    if (item.DiseaseName == diseaseName)
                        return true;
                }
            }
            return false;
        }

        private static void displayDisease()
        {
           
            Console.WriteLine("\nDISEASES\n");
            foreach (Diseases item in diseaseManager.GetAllDiseases())
            {
                Console.WriteLine(item.DiseaseName);
            }
        }

        private static Diseases getDisease()
        {
            string DiseaseName = MyHelperClass.GetValue("\nEnter the Disease Name");
            DisplaySeverity();
            int Severty = MyHelperClass.GetNumber("\nChoose the severity From Above");
            DisplayCause();
            int Cause = MyHelperClass.GetNumber("\nChoose the Cause From Above");
            string Descritpion = MyHelperClass.GetValue("\nEnter Description (Must be more then 30 words)");

            if(VerifyInput(DiseaseName, Severty,Cause,Descritpion))
            {
                return new Diseases { Description = Descritpion, DiseaseCause = Enum.GetName(typeof(Factors), Cause), DiseaseName = DiseaseName.ToLower(), DiseaseSeverity = Enum.GetName(typeof(Severty), Severty) };
            }

            return null;
        }

        private static bool VerifyInput(string diseaseName, int severty,int cause,string descritpion)
        {
            if(diseaseName != "" && Enum.GetName(typeof(Factors), cause)!= null && Enum.GetName(typeof(Severty), severty) !=null && descritpion.Length >= 30)
            {
                return true;
            }

            Console.WriteLine("\nInvalid Input");
            return false;
        }

        private static void DisplayCause()
        {
            Console.WriteLine();
            foreach (var item in Enum.GetValues(typeof(Factors)))
            {
                Console.WriteLine($"{(int)item}. {item} ");
            }
        }

        private static void DisplaySeverity()
        {
            Console.WriteLine();
            foreach (var item in Enum.GetValues(typeof(Severty)))
            {
                Console.WriteLine($"{(int)item}. {item} ");
            }
        }
    }
}
