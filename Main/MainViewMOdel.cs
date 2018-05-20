using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using LabaApp.Model;
using LabaApp.Services;
using Microsoft.Win32;
using System.IO;
using System.Windows.Input;

namespace LabaApp.Main
{
    /// <summary>
    /// Основная ViewModel приложения для работы с динамической структурой.
    /// </summary>
    public class MainViewModel : ViewModelBase
    {
        private Node _root;
        private Node _selectedNode;
        private OpenFileDialog _openFileDialog;
        private SaveFileDialog _saveFileDialog;
        private readonly IDataService _dataService;
        private readonly ISerializationService<Node> _serializationService;

        /// <summary>
        /// Конструктор <see cref="MainViewModel"/>.
        /// </summary>
        /// <param name="dataService">Сервис получения данных динамической структуры.</param>
        /// <param name="serializationService">Сервис сериализации.</param>
        public MainViewModel(IDataService dataService, ISerializationService<Node> serializationService)
        {
            _dataService = dataService;
            _serializationService = serializationService;

            Root = _dataService.GetData(null);

            _openFileDialog = new OpenFileDialog();
            _openFileDialog.Filter = "Файл данных динамических структур|*.xml";

            _saveFileDialog = new SaveFileDialog();
            _saveFileDialog.Filter = "Файл данных динамических структур|*.xml";

            SaveStructCommand = new RelayCommand(SaveStruct);
            LoadStructCommand = new RelayCommand(LoadStruct);
        }

        /// <summary>
        /// Корневой элемент динамической структуры.
        /// </summary>
        public Node Root
        {
            get { return _root; }
            set { Set(ref _root, value); }
        }

        /// <summary>
        /// Выбранный элемент структуры.
        /// </summary>
        public Node SelectedNode
        {
            get { return _selectedNode; }
            set { Set(ref _selectedNode, value); }
        }

        /// <summary>
        /// Сохранение структуры в файл.
        /// </summary>
        private void SaveStruct()
        {
            if (_saveFileDialog.ShowDialog() != true)
                return;
            using (var stream = new FileStream(_saveFileDialog.FileName, FileMode.Create, FileAccess.Write))
            {
                _serializationService.Serialize(Root, stream);
            }
        }

        /// <summary>
        /// Загрузка структуры из файла.
        /// </summary>
        private void LoadStruct()
        {
            if (_openFileDialog.ShowDialog() != true)
                return;
            using (var stream = new FileStream(_openFileDialog.FileName, FileMode.Open, FileAccess.Read))
            {
                Root = _serializationService.Deserialize(stream);
            }
        }

        /// <summary>
        /// Команда сохранения структуры.
        /// </summary>
        public ICommand SaveStructCommand { get; }

        /// <summary>
        /// Команда загрузки структуры.
        /// </summary>
        public ICommand LoadStructCommand { get; }
    }
}