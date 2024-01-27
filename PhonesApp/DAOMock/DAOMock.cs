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
    }
}
