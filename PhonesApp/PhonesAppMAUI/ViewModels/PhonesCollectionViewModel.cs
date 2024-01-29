using CommunityToolkit.Mvvm.ComponentModel;
using Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.Maui.ApplicationModel.Permissions;

namespace PhonesAppMAUI.ViewModels
{
    public partial class PhonesCollectionViewModel: ObservableObject
    {
        [ObservableProperty]
        private ObservableCollection<PhoneViewModel> phones = new ObservableCollection<PhoneViewModel>();

        private BLC.BLC blc;

        public PhonesCollectionViewModel(BLC.BLC blc) 
        {
            this.blc = blc;
            IEnumerable<IPhone> phonesDB = blc.GetPhones();
            foreach (var phone in phonesDB)
            {
                phones.Add(new PhoneViewModel(phone));
            }
        }

    }
}
