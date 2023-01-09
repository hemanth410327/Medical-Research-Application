using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hackathon
{
    class ResearchFactory
    {
        public static object GetInstance(int option)
        {
            switch (option)
            {
                case 1: return new DiseaseManager();

                case 2: return new SymptomsManager();

                default:
                    Console.WriteLine("Object you are requesting is not available");
                    break;
            }
            return null;
        }
    }
}
