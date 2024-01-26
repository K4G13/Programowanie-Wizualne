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

            /*foreach (IProducer producer in blc.GetProducers())
            {
                Console.WriteLine($"{producer.ID}: {producer.Name}");
            }
            Console.WriteLine("-----------------------");
            foreach (IPhone phone in blc.GetPhones())
            {
                Console.WriteLine($"{phone.ID}: {phone.Producer.Name} {phone.Name} {phone.DiagonalScreenSize} {phone.DisplayType}");
            }*/

        }
    }
}
