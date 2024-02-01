using Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhonesAppMAUI.Models
{
    public class Producer : IProducer
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string CountryOfOrigin { get; set; }


        public Producer()
        {
            ID = 0;
            Name = "N/A";
            CountryOfOrigin = "N/A";
        }
        public Producer(int _ID)
        {
            ID = _ID;
            Name = "N/A";
            CountryOfOrigin = "N/A";
        }
        public Producer(int _ID, string _Name, string _Country)
        {
            ID = _ID;
            Name = _Name;
            CountryOfOrigin = _Country;
        }
    }
}
