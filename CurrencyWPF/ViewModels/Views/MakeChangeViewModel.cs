using CurrencyLibrary;
using CurrencyLibrary.Serialization;
using CurrencyLibrary.USCurrency;
using CurrencyMidterm.Views.Coins;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CurrencyMidterm.ViewModels
{
    public class MakeChangeViewModel : BaseViewModel
    {
        private USCurrencyRepo usRepo;
        public RepoViewModel RepoViewModel { get; private set; }

        public ICommand MakeChangeCommand { get; set; }
        public ICommand SaveCommand { get; set; }

        private double repoAmount;
        public double RepoAmount
        {
            get { return repoAmount; }
            set
            {
                repoAmount = value;
                this.RaisePropertyChangedEvent(nameof(RepoAmount));
            }
        }

        public MakeChangeViewModel(USCurrencyRepo repo, RepoViewModel repoView)
        {
            usRepo = repo;
            RepoViewModel = repoView;
            MakeChangeCommand = new BaseCommand(MakeChange);
            SaveCommand = new BaseCommand(Save);
        }

        public void MakeChange()
        {
            RepoViewModel.SetRepo((USCurrencyRepo)usRepo.MakeChange(RepoAmount));
        }

        private void Save()
        {
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Filter = $"{StaticInformation.FileExtensionName} Files (*{StaticInformation.FileExtension})|*{StaticInformation.FileExtension}";
            if (dialog.ShowDialog() == true)
            {
                SaveFile(dialog.FileName);
            }
        }

        public void SaveFile(string path)
        {
            SerializableCurrencyRepo currencyRepo = new SerializableCurrencyRepo(RepoViewModel.CurrentRepo.Coins);
            SaveAndLoadUtility.Save<SerializableCurrencyRepo>(currencyRepo, path);
        }
    }
}
