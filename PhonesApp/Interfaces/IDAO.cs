namespace Interfaces
{
    public interface IDAO
    {
        IEnumerable<IProducer> GetAllProducers();
        IEnumerable<IPhone> GetAllPhones();
        IProducer CreateNewProducer();
        IPhone CreateNewPhone();
    }
}
