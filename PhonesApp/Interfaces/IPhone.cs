using Core;

namespace Interfaces
{
    public interface IPhone
    {
        int ID { get; set; }
        string Name { get; set; }
        IProducer Producer { get; set; }
        double DiagonalScreenSize { get; set; }
        DisplayType DisplayType { get; set; }
    }
}
