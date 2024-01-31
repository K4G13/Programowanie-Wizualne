using Core;

namespace Interfaces
{
    public interface IDAO
    {
        IEnumerable<IProducer> GetAllProducers();
        IProducer? GetProducer(int id);
        bool UpdateProducer(int id, CreateProducerDto producer);
        int UpdatePhone(int phoneId, CreatePhoneDto phone);
        IEnumerable<IPhone> GetAllPhones();
        IPhone? GetPhone(int phoneId);
        IProducer CreateNewProducer();
        IPhone CreateNewPhone();
        void SaveProducer(IProducer producer);
        void SavePhone(IPhone phone);
        void DeleteProducer(IProducer producer);
        void DeletePhone(IPhone phone);
        public bool checkDBConnection();
        IEnumerable<IPhone> GetPhoneByProducerId(int id);

    }
}
