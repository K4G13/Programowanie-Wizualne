using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
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

            IsEditing = false;
            PhoneEdit = null;
        }

        [ObservableProperty]
        private PhoneViewModel phoneEdit;

        [ObservableProperty]
        private bool isEditing;

        [RelayCommand(CanExecute = nameof(CanCreateNewPhone))]
        private void CreateNewPhone()
        {
            PhoneEdit = new PhoneViewModel(blc);
            PhoneEdit.PropertyChanged += OnPhoneEditPropertyChanged;
            IsEditing = true;
            RefreshCanExecute();
        }

        private bool CanCreateNewPhone() => !IsEditing;

        [RelayCommand(CanExecute = nameof(CanEditBeSaved))]
        private void SavePhone()
        {
            Phones.Add(phoneEdit);
            PhoneEdit.PropertyChanged -= OnPhoneEditPropertyChanged;
            PhoneEdit = null;
            IsEditing = false;
            RefreshCanExecute();
        }
        private bool CanEditBeSaved() => PhoneEdit != null &&
                                            PhoneEdit.Name != null &&
                                            PhoneEdit.ID >= 0;

        [RelayCommand(CanExecute = nameof(CanEditBeCanceled))]
        private void CancelEdit()
        {
            PhoneEdit.PropertyChanged -= OnPhoneEditPropertyChanged;
            PhoneEdit = null;
            IsEditing = false;
            RefreshCanExecute();
        }
        private bool CanEditBeCanceled() => isEditing;

        private void OnPhoneEditPropertyChanged(object? sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            SavePhoneCommand.NotifyCanExecuteChanged();
        }

        private void RefreshCanExecute()
        {
            CreateNewPhoneCommand.NotifyCanExecuteChanged();
            SavePhoneCommand.NotifyCanExecuteChanged();
            CancelEditCommand.NotifyCanExecuteChanged();
        }

    }
}
