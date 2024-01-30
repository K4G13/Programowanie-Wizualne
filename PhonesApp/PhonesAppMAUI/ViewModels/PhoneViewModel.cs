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
        }

        public PhoneViewModel( BLC.BLC blc )
        {
            blc.NewPhone();
        }

    }
}
