using Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DAOSql
{
    public class DAOSql : IDAO
    {
        private DatabaseContext db = new DatabaseContext();

        public IEnumerable<IProducer> GetAllProducers()
        {
            return db.Producers;
        }
        public IEnumerable<IPhone> GetAllPhones()
        {
            return db.Phones;
        }
        public IProducer CreateNewProducer()
        {
            return new Producer();
        }
        public IPhone CreateNewPhone()
        {
            return new Phone(); 
        }
    }
}
