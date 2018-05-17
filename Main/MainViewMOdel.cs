using GalaSoft.MvvmLight;
using LabaApp.Model;
using LabaApp.Services;
using System.Windows.Input;

namespace LabaApp.Main
{
    public class MainViewModel : ViewModelBase
    {
        private Node _root;
        private readonly IDataService _dataService;

        public MainViewModel(IDataService dataService)
        {
            _dataService = dataService;

            //if (IsInDesignModeStatic)
                Root = _dataService.GetData(null);
        }

        public Node Root
        {
            get { return _root; }
            set { Set(ref _root, value); }
        }

        public ICommand AddRowCommand { get; }
    }
}
