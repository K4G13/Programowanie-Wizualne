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
    }
}
