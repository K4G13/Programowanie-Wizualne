using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core;

namespace Interfaces
{
    public interface IBLC
    {
        IEnumerable<IProducer> GetProducers();
        IProducer? GetProducer(int id);
        IPhone? GetPhone(int id);
        bool UpdateProducer(int  id, CreateProducerDto producer);
        int UpdatePhone(int phoneId, CreatePhoneDto phone);
        IEnumerable<IPhone> GetPhones();
        IProducer NewProducer();
        IPhone NewPhone();
        void SaveProducer(IProducer producer);
        void SavePhone(IPhone phone);
        void DeleteProducer(IProducer producer);
        void DeletePhone(IPhone phone);
        bool checkDBConnection();
        IEnumerable<IPhone> GetPhonesByProducerId(int id);
    }
}
