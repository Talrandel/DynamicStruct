using LabaApp.Model;

namespace LabaApp.Services
{
    /// <summary>
    /// Интерфейс получения данных приложения.
    /// </summary>
    public interface IDataService
    {
        /// <summary>
        /// Получить корневой элемент динамической структуры.
        /// </summary>
        /// <returns>Корневой элемент структуры.</returns>
        Node GetData();
    }
}