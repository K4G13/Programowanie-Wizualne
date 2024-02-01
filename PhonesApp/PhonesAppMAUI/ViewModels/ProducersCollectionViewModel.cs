using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Interfaces;
using PhonesAppMAUI.Models;
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
            Producer producer = new Producer();
            if (SelectedProducer != null)
            {
                producer.ID = SelectedProducer.ID;
                producer.Name = SelectedProducer.Name;
                producer.CountryOfOrigin = SelectedProducer.CountryOfOrigin;
                Producers.Remove(SelectedProducer);
                blc.DeleteProducer(producer);
            }
            producer.ID = ProducerEdit.ID;
            producer.Name = ProducerEdit.Name;
            producer.CountryOfOrigin = ProducerEdit.CountryOfOrigin;
            blc.SaveProducer(producer);
            IEnumerable<IProducer> producersDB = blc.GetProducers();
            producers.Clear();
            foreach (var _producer in producersDB)
            {
                producers.Add(new ProducerViewModel(_producer));
            }

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
            Producer producer = new Producer();
            producer.ID = SelectedProducer.ID;
            producer.Name = SelectedProducer.Name;
            producer.CountryOfOrigin = SelectedProducer.CountryOfOrigin;


            Producers.Remove(SelectedProducer);
            blc.DeleteProducer(producer);

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
