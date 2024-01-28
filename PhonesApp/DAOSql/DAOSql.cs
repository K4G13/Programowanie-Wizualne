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

        public void SaveProducer(IProducer producer)
        {
            db.Producers.Add( (Producer)producer );
            db.Entry(producer).State = EntityState.Added;
            db.SaveChanges();
        }

        public void SavePhone(IPhone phone)
        {
            db.Phones.Add( (Phone)phone );
            db.Entry(phone).State = EntityState.Added;
            db.SaveChanges();
        }

        public void DeleteProducer(IProducer producer) {
            db.Producers.Remove( (Producer)producer );
            db.Entry(producer).State = EntityState.Deleted;
            db.SaveChanges();
        }

        public void DeletePhone(IPhone phone) { 
            db.Phones.Remove( (Phone)phone );
            db.Entry(phone).State = EntityState.Deleted;
            db.SaveChanges();
        }
    }
}
