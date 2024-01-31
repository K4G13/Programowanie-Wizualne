using Core;
using Interfaces;

namespace DAOMock
{
    internal class DAOMock : IDAO
    {

        private List<IProducer> producers;
        private List<IPhone> phones;
        

        public DAOMock()
        {
            producers = new List<IProducer>()
            {
                new BO.Producer() { ID = 1, CountryOfOrigin="The United States of America", Name="Apple"},
                new BO.Producer() { ID = 2, CountryOfOrigin="South Korea", Name="Samsung"}
            };
            phones = new List<IPhone>()
            {
                new BO.Phone() { ID = 1, Producer = producers[0], Name="Iphone 15 Plus", DiagonalScreenSize=6.7, DisplayType=Core.DisplayType.OLED},
                new BO.Phone() { ID = 2, Producer = producers[0], Name="Iphone 15", DiagonalScreenSize=6.1, DisplayType=Core.DisplayType.OLED},
                new BO.Phone() { ID = 3, Producer = producers[1], Name="SAMSUNG Galaxy S22", DiagonalScreenSize=6.1, DisplayType=Core.DisplayType.AMOLED}
            };
        }

        public IPhone CreateNewPhone()
        {
            return new BO.Phone();
        }

        public IProducer CreateNewProducer()
        {
            return new BO.Producer();
        }

        public IEnumerable<IPhone> GetAllPhones()
        {
            return phones;
        }

        public IEnumerable<IProducer> GetAllProducers()
        {
            return producers;
        }

        public IProducer? GetProducer(int id)
        {
            IProducer? producer = null;
            foreach(IProducer _producer in producers)
            {
                if (_producer.ID == id)
                {
                    producer = _producer;
                }
            }
            return producer;
        }

        public void SaveProducer(IProducer producer)
        {
            producers.Add(producer);
        }

        public void SavePhone(IPhone phone)
        {
            phones.Add(phone);
        }

        public void DeleteProducer(IProducer producer)
        {
            producers.Remove(producer);
        }

        public void DeletePhone(IPhone phone)
        {
            phones.Remove(phone);
        }

        public bool checkDBConnection()
        {
            return true;
        }

        public bool UpdateProducer(int id, CreateProducerDto producer)
        {
            IProducer? oldProducer = null;
            foreach (IProducer _producer in producers)
            {
                if (_producer.ID == id)
                {
                    oldProducer = _producer;
                }
            }
            if (oldProducer == null)
            {
                return false;
            }
            oldProducer.Name = producer.Name;
            oldProducer.CountryOfOrigin = producer.CountryOfOrigin;
            return true;
        }

        public int UpdatePhone(int phoneId, CreatePhoneDto phone)
        {
            IPhone? oldPhone = null;
            foreach (IPhone _phone in  phones)
            {
                if (_phone.ID == phoneId)
                {
                    oldPhone = _phone;
                }
            }
            if (oldPhone == null)
            {
                return 1;
            }
            oldPhone.Name = phone.Name;
            oldPhone.DiagonalScreenSize = phone.DiagonalScreenSize;
            oldPhone.DisplayType = phone.DisplayType;
            IProducer? oldProducer = null;
            foreach (IProducer _producer in producers)
            {
                if (_producer.ID == phone.ProducerId)
                {
                    oldProducer = _producer;
                }
            }
            if (oldProducer == null)
            {
                return 2;
            }
            return 0;
        }

        public IPhone? GetPhone(int phoneId)
        {
            IPhone? phone = null;
            foreach(IPhone _phone in phones)
            {
                if (_phone.ID == phoneId)
                {
                    phone = _phone;
                }
            }
            return phone;
        }

        public IEnumerable<IPhone> GetPhoneByProducerId(int id)
        {
            throw new NotImplementedException();
        }
    }
}
