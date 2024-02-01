using Core;
using Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DAOSql
{
    public class DAOSql : IDAO
    {
        private DatabaseContext db = new DatabaseContext();

        public bool checkDBConnection()
        {
            try
            {
                var connection = (Microsoft.Data.Sqlite.SqliteConnection)db.Database.GetDbConnection();
                if (connection.State != System.Data.ConnectionState.Open)
                {
                    connection.Open();
                }
                Console.WriteLine($"Ścieżka do bd: {connection.DataSource}");

                Console.WriteLine($"Table w {db.Database.GetDbConnection().Database}:");
                foreach (var table in db.Model.GetEntityTypes())
                {
                    Console.WriteLine($"Tabela: {table.GetTableName()}");
                }

                var firstPhone = db.Phones.FirstOrDefault();
                if (firstPhone != null)
                {
                    Console.WriteLine($"FirstPhone: id:{firstPhone.ID} name:{firstPhone.Name}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }

            return true;
        }


        public DAOSql()
        {
            try {
                Console.WriteLine($"Table w {db.Database.GetDbConnection().Database}:");
                foreach (var table in db.Model.GetEntityTypes())
                {
                    Console.WriteLine($"Tabela: {table.GetTableName()}");
                }
                var firstPhone = db.Phones.FirstOrDefault();
                Console.WriteLine("Baza danych załadowana poprawnie");
                //if (firstPhone != null)
                //{
                //    Console.WriteLine($"FirstPhone: id:{firstPhone.ID} name:{firstPhone.Name}");
                //}
            }
            catch (Exception ex) 
            {
                //Console.WriteLine(ex.ToString());
                Console.WriteLine("Tworze migracje");
                db.Database.Migrate();
                db.SaveChanges();
            }
        }

        public IEnumerable<IProducer> GetAllProducers()
        {
            return db.Producers;
        }

        public IProducer? GetProducer(int id)
        {
            return db.Producers.FirstOrDefault(c => c.ID == id);
        }

        public IEnumerable<IPhone> GetAllPhones()
        {
            return db.Phones.Include(a => a.Producer);
        }

        public IPhone? GetPhone(int id)
        {
            return db.Phones.FirstOrDefault(c => c.ID == id);
        }

        public IProducer CreateNewProducer()
        {
            return new Producer();
        }

        public IPhone CreateNewPhone()
        {
            return new Phone(); 
        }

        public void SaveProducer(IProducer producer)
        {
            producer = new Producer(producer.ID, producer.Name, producer.CountryOfOrigin);
            db.Producers.Add( (Producer)producer );
            db.Entry(producer).State = EntityState.Added;
            db.SaveChanges();
        }

        public void SavePhone(IPhone phone)
        {
            phone = new Phone(phone.ID, phone.Name, (Producer)phone.Producer, phone.DiagonalScreenSize, phone.DisplayType);
            db.Phones.Add( (Phone)phone );
            db.Entry(phone).State = EntityState.Added;
            db.SaveChanges();
        }

        public void DeleteProducer(IProducer producer) {
            producer = db.Producers.FirstOrDefault(c => c.ID == producer.ID);
            db.Producers.Remove( (Producer)producer );
            db.Entry(producer).State = EntityState.Deleted;
            db.SaveChanges();
        }

        public void DeletePhone(IPhone phone) {
            phone = db.Phones.FirstOrDefault(c => c.ID == phone.ID);
            db.Phones.Remove( (Phone)phone );
            db.Entry(phone).State = EntityState.Deleted;
            db.SaveChanges();
        }

        public bool UpdateProducer(int id, CreateProducerDto producer)
        {
            IProducer? oldProducer = db.Producers.FirstOrDefault(c => c.ID == id);
            if (oldProducer == null)
            {
                return false;
            }

            oldProducer.Name = producer.Name;
            oldProducer.CountryOfOrigin = producer.CountryOfOrigin;
            db.SaveChanges();
            return true;
        }

        public int UpdatePhone(int phoneId, CreatePhoneDto phone)
        {
            IPhone? oldPhone = db.Phones.FirstOrDefault(c =>c.ID == phoneId);
            if (oldPhone == null)
            {
                return 1;
            }
            oldPhone.Name = phone.Name;
            oldPhone.DiagonalScreenSize = phone.DiagonalScreenSize;
            oldPhone.DisplayType = phone.DisplayType;
            IProducer? producer = db.Producers.FirstOrDefault(c=>c.ID == phone.ProducerId);
            if (producer == null)
            {
                return 2;
            }
            oldPhone.Producer = producer;
            db.SaveChanges();
            return 0;
        }

        public IEnumerable<IPhone> GetPhoneByProducerId(int id)
        { 
            List<IPhone> _phones = new List<IPhone>();
            foreach(IPhone __phone in db.Phones)
            {
                if (__phone.Producer.ID == id)
                {
                    _phones.Add(__phone);
                }
            }
            return _phones;
        }

    }
}
