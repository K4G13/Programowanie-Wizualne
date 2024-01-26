using Interfaces;

namespace DAOMock.BO
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
