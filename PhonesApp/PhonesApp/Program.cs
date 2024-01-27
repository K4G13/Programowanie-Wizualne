using Interfaces;

namespace PhonesApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string libraryName = System.Configuration.ConfigurationManager.AppSettings["DAOLibraryName"]!;
            BLC.BLC blc = new BLC.BLC(libraryName);


            blc.SavePhone(blc.NewPhone());

            Console.WriteLine("-Producers-------------------");
            foreach (IProducer producer in blc.GetProducers())
            {
                Console.WriteLine($"{producer.ID}: {producer.Name} {producer.CountryOfOrigin}");
            }
            Console.WriteLine("-Phones----------------------");
            foreach (IPhone phone in blc.GetPhones())
            {
                Console.WriteLine($"{phone.ID}: {phone.Producer.Name} {phone.Name} {phone.DiagonalScreenSize} {phone.DisplayType}");
            }

            Console.WriteLine("-Czyszcze-bazę danych--------");
            foreach (IProducer producer in blc.GetProducers()) blc.DeleteProducer(producer);
            foreach (IPhone phone in blc.GetPhones()) blc.DeletePhone(phone);

        }
    }
}
