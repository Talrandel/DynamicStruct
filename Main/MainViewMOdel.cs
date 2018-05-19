using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using LabaApp.Model;
using LabaApp.Services;
using System.Windows.Input;

namespace LabaApp.Main
{
    public class MainViewModel : ViewModelBase
    {
        private Node _root;
        private Node _selectedNode;
        private readonly IDataService _dataService;

        public MainViewModel(IDataService dataService)
        {
            _dataService = dataService;

            Root = _dataService.GetData(null);
            
            SaveStructCommand = new RelayCommand(SaveStruct);
            LoadStructCommand = new RelayCommand(LoadStruct);
        }

        public Node Root
        {
            get { return _root; }
            set { Set(ref _root, value); }
        }

        public Node SelectedNode
        {
            get { return _selectedNode; }
            set { Set(ref _selectedNode, value); }
        }

        private void SaveStruct()
        {

        }

        private void LoadStruct()
        {

        }

        public ICommand SaveStructCommand { get; }

        public ICommand LoadStructCommand { get; }
    }
}