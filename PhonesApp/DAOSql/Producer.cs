using Interfaces;
using System.ComponentModel.DataAnnotations;

namespace DAOSql
{
    public class Producer : IProducer
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }
        public string CountryOfOrigin { get; set; }

        public Producer()
        {
            ID = 0;
            Name = "";
            CountryOfOrigin = "";
        }
        public Producer(int _ID)
        {
            ID = _ID;
            Name = "";
            CountryOfOrigin = "";
        }
        public Producer(int _ID, string _Name, string _Country) 
        { 
            ID = _ID;
            Name = _Name;
            CountryOfOrigin = _Country;
        }
    }
}
