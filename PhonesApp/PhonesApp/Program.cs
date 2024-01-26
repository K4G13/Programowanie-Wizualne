using Interfaces;

namespace PhonesApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Yoo!");

            string libraryName = System.Configuration.ConfigurationManager.AppSettings["DAOLibraryName"]!;
            BLC.BLC blc = new BLC.BLC(libraryName);


            //blc.checkDBConnection();


            // DODAWANIE NOWEGO TELEFONU DO BAZY
            var p = blc.NewPhone();
            Console.WriteLine($"{p.ID} {p.Name} {p.DisplayType}");
            blc.SavePhone(p);

            Console.WriteLine("-Producers-------------------");
            foreach (IProducer producer in blc.GetProducers())
            {
                Console.WriteLine($"{producer.ID}: {producer.Name}");
            }
            Console.WriteLine("-Phones----------------------");
            foreach (IPhone phone in blc.GetPhones())
            {
                Console.WriteLine($"{phone.ID}: {phone.Producer.Name} {phone.Name} {phone.DiagonalScreenSize} {phone.DisplayType}");
            }

            blc.DeletePhone(p);

            Console.WriteLine("-Phones----------------------");
            foreach (IPhone phone in blc.GetPhones())
            {
                Console.WriteLine($"{phone.ID}: {phone.Producer.Name} {phone.Name} {phone.DiagonalScreenSize} {phone.DisplayType}");
            }

        }
    }
}
