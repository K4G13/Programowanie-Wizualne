namespace Interfaces
{
    public interface IDAO
    {
        IEnumerable<IProducer> GetAllProducers();
        IEnumerable<IPhone> GetAllPhones();
        IProducer CreateNewProducer();
        IPhone CreateNewPhone();
        void SaveProducer(IProducer producer);
        void SavePhone(IPhone phone);
        void DeleteProducer(IProducer producer);
        void DeletePhone(IPhone phone);

    }
}
