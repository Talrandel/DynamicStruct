using Lab2_Lists.Infrastructure;
using Lab2_Lists.Model;
using Lab2_Lists.Services;
using Microsoft.Win32;
using System.IO;
using System.Windows.Input;

namespace Lab2_Lists.ViewModel
{
    public class DynamicStructViewModel : ObservableObject
    {
        private DynamicStruct _dynamicStruct;
        private INamedItem _selectedItem;
        private IDynamicStructSerializerService _dynamicStructSerializerService;
        private IDynamicStructService _dynamicStructService;

        private OpenFileDialog _openFileDialog;
        private SaveFileDialog _saveFileDialog;

        public DynamicStructViewModel(IDynamicStructSerializerService dynamicStructSerializerService,
                                      IDynamicStructService dynamicStructService)
        {
            _dynamicStructSerializerService = dynamicStructSerializerService;
            _dynamicStructService = dynamicStructService;

            _openFileDialog = new OpenFileDialog();
            _openFileDialog.Title = "Выберите файл структуры для загрузки";
            // TODO: фильтр для диалогового окна
            _saveFileDialog = new SaveFileDialog();
            _saveFileDialog.Title = "Выберите файл для загрузки структуры";

            AddNodeBeforeCommand = new RelayCommand((param) => AddNodeBefore((NodeBase)param));
        }

        public DynamicStructViewModel()
        {

        }

        public DynamicStruct DynamicStruct
        {
            get { return _dynamicStruct; }
            set
            {
                _dynamicStruct = value;
                OnPropertyChanged(nameof(DynamicStruct));
            }
        }

        public INamedItem SelectedItem
        {
            get { return _selectedItem; }
            set
            {
                _selectedItem = value;
                OnPropertyChanged(nameof(SelectedItem));
            }
        }

        private void Load()
        {
            DynamicStruct = _dynamicStructService.GetDynamicStruct();
        }

        private void AddNodeBefore(NodeBase parent)
        {

        }

        private void AddNodeAfter(NodeBase parent)
        {

        }

        private void DeleteNode(NodeBase node)
        {

        }

        private void UpdateNode(NodeBase node)
        {

        }

        private void SaveDynamicStruct()
        {
            var result = _saveFileDialog.ShowDialog();
            if (result == false || string.IsNullOrEmpty(_saveFileDialog.FileName))
                return;
            _dynamicStructSerializerService.Serialize(DynamicStruct, new FileStream(_saveFileDialog.FileName, FileMode.Create, FileAccess.Write));
        }

        private void LoadDynamicStruct()
        {
            var result = _openFileDialog.ShowDialog();
            if (result == false || string.IsNullOrEmpty(_openFileDialog.FileName))
                return;
            DynamicStruct = _dynamicStructSerializerService.Deserialize(new FileStream(_openFileDialog.FileName, FileMode.Open, FileAccess.Read));
        }

        public ICommand AddNodeBeforeCommand { get; }
        public ICommand AddNodeAfterCommand { get; }
        public ICommand DeleteNodeCommand { get; }
        public ICommand UpdateNodeCommand { get; }
        public ICommand SaveDynamicStructCommand { get; }
        public ICommand LoadDynamicStructCommand { get; }
    }
}