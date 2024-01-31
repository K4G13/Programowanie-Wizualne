using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhonesAppMAUI.ViewModels
{
    public partial class ProducersCollectionViewModel : ObservableObject
    {
        [ObservableProperty]
        private ObservableCollection<ProducerViewModel> producers = new ObservableCollection<ProducerViewModel>();

        private BLC.BLC blc;


        public ProducersCollectionViewModel(BLC.BLC blc)
        {
            this.blc = blc;
            IEnumerable<IProducer> producersDB = blc.GetProducers();
            foreach (var producer in producersDB)
            {
                producers.Add(new ProducerViewModel(producer));
            }

            IsEditing = false;
            ProducerEdit = null;
            SelectedProducerBuffer = null;

        }


        [ObservableProperty]
        private ProducerViewModel producerEdit;

        [ObservableProperty]
        private bool isEditing;

        [RelayCommand(CanExecute = nameof(CanCreateNewProducer))]
        private void CreateNewProducer()
        {
            ProducerEdit = new ProducerViewModel(blc);
            ProducerEdit.PropertyChanged += OnProducerEditPropertyChanged;
            IsEditing = true;
            RefreshCanExecute();
        }
        private bool CanCreateNewProducer() => !IsEditing;


        [RelayCommand(CanExecute = nameof(CanEditBeSaved))]
        private void SaveProducer()
        {

            if (SelectedProducer != null)
            {
                Producers.Remove(SelectedProducer);
                blc.DeleteProducer(SelectedProducer);
            }

            Producers.Add(ProducerEdit);
            blc.SaveProducer(ProducerEdit);

            ProducerEdit.PropertyChanged -= OnProducerEditPropertyChanged;
            ProducerEdit = null;
            SelectedProducerBuffer = null;
            IsEditing = false;
            RefreshCanExecute();
        }
        private bool CanEditBeSaved() => ProducerEdit != null && ProducerEdit.Name != null && ProducerEdit.ID >= 0;


        [RelayCommand(CanExecute = nameof(CanEditBeCanceled))]
        private void CancelEdit()
        {
            ProducerEdit.PropertyChanged -= OnProducerEditPropertyChanged;
            ProducerEdit = null;
            SelectedProducerBuffer = null;
            IsEditing = false;
            RefreshCanExecute();
        }
        private bool CanEditBeCanceled() => isEditing;


        private ProducerViewModel SelectedProducerBuffer = null;
        public ProducerViewModel SelectedProducer
        {
            get => SelectedProducerBuffer;
            set { if (value != null && !isEditing) selectProducer(value); }
        }
        private void selectProducer(ProducerViewModel refProducer)
        {
            SelectedProducerBuffer = refProducer;

            ProducerEdit = new ProducerViewModel(blc);
            ProducerEdit.ID = refProducer.ID;
            ProducerEdit.Name = refProducer.Name;
            ProducerEdit.CountryOfOrigin = refProducer.CountryOfOrigin;

            ProducerEdit.PropertyChanged += OnProducerEditPropertyChanged;
            IsEditing = true;
            RefreshCanExecute();
        }


        [RelayCommand(CanExecute = nameof(CanDeleteProducer))]
        private void DeleteProducer()
        {
            Producers.Remove(SelectedProducer);
            blc.DeleteProducer(SelectedProducer);

            ProducerEdit.PropertyChanged -= OnProducerEditPropertyChanged;
            ProducerEdit = null;
            SelectedProducerBuffer = null;
            IsEditing = false;
            RefreshCanExecute();
        }
        private bool CanDeleteProducer() => isEditing && SelectedProducerBuffer != null;


        private void OnProducerEditPropertyChanged(object? sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            SaveProducerCommand.NotifyCanExecuteChanged();
        }

        private void RefreshCanExecute()
        {
            CreateNewProducerCommand.NotifyCanExecuteChanged();
            SaveProducerCommand.NotifyCanExecuteChanged();
            CancelEditCommand.NotifyCanExecuteChanged();
            DeleteProducerCommand.NotifyCanExecuteChanged();
        }

    }
}
