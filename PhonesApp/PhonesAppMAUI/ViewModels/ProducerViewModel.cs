using CommunityToolkit.Mvvm.ComponentModel;
using Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhonesAppMAUI.ViewModels
{
    public partial class ProducerViewModel : ObservableObject, IProducer
    {
        [ObservableProperty]
        private int iD;

        [ObservableProperty]
        private string name;

        [ObservableProperty]
        private string countryOfOrigin;

        public ProducerViewModel(IProducer producer)
        {
            ID = producer.ID;
            Name = producer.Name;
            CountryOfOrigin = producer.CountryOfOrigin; 
        }

        public ProducerViewModel(BLC.BLC blc)
        {
            blc.NewProducer();
        }
    }
}
