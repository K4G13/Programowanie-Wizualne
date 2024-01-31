using Core;
using Interfaces;
using System.Reflection;

namespace BLC
{
    public class BLC : IBLC
    {
        private IDAO dao;

        public BLC(string libraryName)
        {
            Type? typeToCreate = null;

            Assembly assembly = Assembly.UnsafeLoadFrom(libraryName);

            foreach (Type type in assembly.GetTypes())
            {
                if (type.IsAssignableTo(typeof(IDAO)))
                {
                    typeToCreate = type;
                    break;
                }
            }
            dao = (IDAO)Activator.CreateInstance(typeToCreate, null);
        }

        public IEnumerable<IProducer> GetProducers()
        {
            return dao.GetAllProducers();
        }

        public IProducer? GetProducer(int id)
        {
            return dao.GetProducer(id);
        }

        public IPhone? GetPhone(int id)
        {
            return dao.GetPhone(id);
        }

        public IEnumerable<IPhone> GetPhones()
        {
            return dao.GetAllPhones();
        }
        public IProducer NewProducer()
        {
            return dao.CreateNewProducer();
        }
        public IPhone NewPhone()
        {
            return dao.CreateNewPhone();
        }

        public void SaveProducer(IProducer producer)
        {
            dao.SaveProducer(producer);
        }

        public void SavePhone(IPhone phone)
        {
            dao.SavePhone(phone);
        }

        public void DeleteProducer(IProducer producer)
        {
            dao.DeleteProducer(producer);
        }

        public void DeletePhone(IPhone phone)
        {   
            dao.DeletePhone(phone);
        }

        public bool UpdateProducer(int id, CreateProducerDto producer)
        {

            return dao.UpdateProducer(id, producer);
        }

        public int UpdatePhone(int phoneId, CreatePhoneDto phone)
        {
            return dao.UpdatePhone(phoneId, phone);
        }

        public bool checkDBConnection()
        {
            return dao.checkDBConnection();
        }

        public IEnumerable<IPhone> GetPhonesByProducerId(int id)
        {
            return dao.GetPhoneByProducerId(id);
        }


    }
}