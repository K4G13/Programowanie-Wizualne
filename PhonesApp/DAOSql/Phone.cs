using Core;
using Interfaces;
using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography;

namespace DAOSql
{
    public class Phone : IPhone
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }
        public Producer Producer { get; set; }
        public double DiagonalScreenSize { get; set; }
        public DisplayType DisplayType { get; set; }
        IProducer IPhone.Producer
        {
            get => Producer;
            set => Producer = (Producer)value;
        }

        public Phone() 
        {
            ID = 0;
            Name = "";
            Producer = new Producer();
            DiagonalScreenSize = 0;
            DisplayType = (DisplayType)0;
        }
        public Phone(int _ID)
        {
            ID = _ID;
            Name = "";
            Producer = new Producer();
            DiagonalScreenSize = 0;
            DisplayType = (DisplayType)0;
        }
        public Phone(int _ID, string _Name, Producer _Producer, double _Size, DisplayType _Display)
        {
            ID = _ID;
            Name = _Name;
            Producer = _Producer;
            DiagonalScreenSize = _Size;
            DisplayType = _Display;
        }

    }
}
