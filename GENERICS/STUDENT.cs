using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GENERICS_
{
    [Serializable]
    internal class STUDENT
    {
       
        public string Name { get; set; }

        public string Surname { get; set; }

        public double Age { get; set; }

        public string School { get; set; }

        public double Class { get; set; }


        public override string ToString()
        {
            return $" {Name} / {Surname} / {Age} years / {School} school";
        }

    


    }
}
