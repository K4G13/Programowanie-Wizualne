using CommunityToolkit.Mvvm.ComponentModel;
using Core;
using Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhonesAppMAUI.ViewModels
{
    public partial class PhoneViewModel: ObservableObject, IPhone
    {
        [ObservableProperty]
        private int iD;

        [ObservableProperty]
        private string name;

        [ObservableProperty]
        private IProducer producer;

        [ObservableProperty]
        private double diagonalScreenSize;

        [ObservableProperty]
        private DisplayType displayType;

        public PhoneViewModel( IPhone phone )
        {
            ID = phone.ID;
            Name = phone.Name; 
            Producer = phone.Producer;
            DiagonalScreenSize = phone.DiagonalScreenSize;
            DisplayType = phone.DisplayType;

            DisplayTypeValues = Enum.GetValues(typeof(Core.DisplayType)).Cast<Core.DisplayType>().ToList();
        }

        public PhoneViewModel( BLC.BLC blc )
        {
            blc.NewPhone();
            DisplayTypeValues = Enum.GetValues(typeof(Core.DisplayType)).Cast<Core.DisplayType>().ToList();
            ProducerValues = (List<IProducer>?)blc.GetProducers();
        }



        public DisplayType SelectedDisplayType
        {
            get { return displayType; }
            set
            {
                if (displayType != value)
                {
                    displayType = value;
                    OnPropertyChanged(nameof(SelectedDisplayType));
                }
            }
        }
        public List<DisplayType> DisplayTypeValues { get; set; }




        public IProducer SelectedProducer
        {
            get { return producer; }
            set
            {
                if(producer != value)
                {
                    producer = value;
                    OnPropertyChanged(nameof(SelectedProducer));
                }
            }
        }
        public List<IProducer> ProducerValues { get; set; }


    }
}
