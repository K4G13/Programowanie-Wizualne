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
    public partial class PhonesCollectionViewModel : ObservableObject
    {
        [ObservableProperty]
        private ObservableCollection<PhoneViewModel> phones = new ObservableCollection<PhoneViewModel>();

        private BLC.BLC blc;


        [ObservableProperty]///???
        private IEnumerable<Core.DisplayType> displayTypesValues;

        public PhonesCollectionViewModel(BLC.BLC blc)
        {
            this.blc = blc;
            IEnumerable<IPhone> phonesDB = blc.GetPhones();
            foreach (var phone in phonesDB)
            {
                phones.Add(new PhoneViewModel(phone));
            }

            ///??
            DisplayTypesValues = Enum.GetValues(typeof(Core.DisplayType)).Cast<Core.DisplayType>();


            IsEditing = false;
            PhoneEdit = null;
            SelectedPhoneBuffer = null;
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

            if (SelectedPhone != null)
            {
                Phones.Remove(SelectedPhone);
                blc.DeletePhone(SelectedPhone);
            }

            Phones.Add(PhoneEdit);
            blc.SavePhone(PhoneEdit);

            PhoneEdit.PropertyChanged -= OnPhoneEditPropertyChanged;
            PhoneEdit = null;
            SelectedPhoneBuffer = null;
            IsEditing = false;
            RefreshCanExecute();
        }
        private bool CanEditBeSaved() => PhoneEdit != null && PhoneEdit.Name != null && PhoneEdit.ID >= 0;


        [RelayCommand(CanExecute = nameof(CanEditBeCanceled))]
        private void CancelEdit()
        {
            PhoneEdit.PropertyChanged -= OnPhoneEditPropertyChanged;
            PhoneEdit = null;
            SelectedPhoneBuffer = null;
            IsEditing = false;
            RefreshCanExecute();
        }
        private bool CanEditBeCanceled() => isEditing;


        private PhoneViewModel SelectedPhoneBuffer = null;
        public PhoneViewModel SelectedPhone
        {
            get => SelectedPhoneBuffer;
            set { if (value != null && !isEditing) selectPhone(value); }
        }
        private void selectPhone(PhoneViewModel refPhone)
        {
            SelectedPhoneBuffer = refPhone;

            PhoneEdit = new PhoneViewModel(blc);
            PhoneEdit.ID = refPhone.ID;
            PhoneEdit.Producer = refPhone.Producer;
            PhoneEdit.Name = refPhone.Name;
            PhoneEdit.DiagonalScreenSize = refPhone.DiagonalScreenSize;
            PhoneEdit.DisplayType = refPhone.DisplayType;

            PhoneEdit.PropertyChanged += OnPhoneEditPropertyChanged;
            IsEditing = true;
            RefreshCanExecute();
        }

        [RelayCommand(CanExecute = nameof(CanDeletePhone))]
        private void DeletePhone()
        {
            Phones.Remove(SelectedPhone);
            blc.DeletePhone(SelectedPhone);

            PhoneEdit.PropertyChanged -= OnPhoneEditPropertyChanged;
            PhoneEdit = null;
            SelectedPhoneBuffer = null;
            IsEditing = false;
            RefreshCanExecute();
        }
        private bool CanDeletePhone() => isEditing && SelectedPhoneBuffer!=null;


        private void OnPhoneEditPropertyChanged(object? sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            SavePhoneCommand.NotifyCanExecuteChanged();
        }

        private void RefreshCanExecute()
        {
            CreateNewPhoneCommand.NotifyCanExecuteChanged();
            SavePhoneCommand.NotifyCanExecuteChanged();
            CancelEditCommand.NotifyCanExecuteChanged();
            DeletePhoneCommand.NotifyCanExecuteChanged();
        }

    }
}
