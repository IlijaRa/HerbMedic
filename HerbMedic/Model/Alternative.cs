using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes.Model
{
    public class Alternative
    {
        public string medicineName { get; set; }
        public int alternativeId { get; set; }
        public string alternativeName { get; set; }

        public Alternative(string medicineName, int alternativeId, string alternativeName)
        {
            this.medicineName = medicineName;
            this.alternativeId = alternativeId;
            this.alternativeName = alternativeName;
        }
    }
}
