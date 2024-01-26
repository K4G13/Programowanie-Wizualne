using Core;
using Interfaces;

namespace DAOMock.BO
{
    public class Phone : IPhone
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public IProducer Producer { get; set; }
        public double DiagonalScreenSize { get; set; }
        public DisplayType DisplayType { get; set; }
        public Phone()
        {
            ID = 0;
            Name = "N/A";
            Producer = new Producer();
            DiagonalScreenSize = 0;
            DisplayType = (DisplayType)0;
        }
        public Phone(int _ID)
        {
            ID = _ID;
            Name = "N/A";
            Producer = new Producer();
            DiagonalScreenSize = 0;
            DisplayType = (DisplayType)0;
        }
        public Phone(int _ID, string _Name, Producer _Producer, double _Size, DisplayType _Display)
        {
            ID = _ID;
            Name = _Name;
            Producer = _Producer;
            DiagonalScreenSize = _Size;
            DisplayType = _Display;
        }
    }
}
