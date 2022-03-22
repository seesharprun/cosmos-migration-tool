using Microsoft.DataTransfer.Cosmos.Interface.Services;
using Prism.Commands;
using Prism.Mvvm;
using System.Collections.ObjectModel;

namespace Microsoft.DataTransfer.Cosmos.Interface.ViewModels
{
    public class ShellViewModel : BindableBase
    {
        private IAlphabetStore _alphabetStore;

        public ShellViewModel(IAlphabetStore alphabetStore)
        {
            _alphabetStore = alphabetStore;
        }

        public ObservableCollection<string> Alphabet { get; private set;} = new ();

        private string _selectedLetter = String.Empty;
        public string SelectedLetter
        {
            get => _selectedLetter;
            set
            {
                if (value is not null) 
                {
                    SetProperty<string>(ref _selectedLetter, value);
                }
            }
        }

        public DelegateCommand LoadCommand => new DelegateCommand(LoadExecute);

        private void LoadExecute()
        {
            Alphabet.Clear();
            Alphabet.AddRange(_alphabetStore.GetAllLetters());
        }
    }
}