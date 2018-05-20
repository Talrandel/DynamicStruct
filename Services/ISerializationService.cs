using System.IO;

namespace LabaApp.Services
{
    /// <summary>
    /// Интерфейс сервиса сериализации.
    /// </summary>
    public interface ISerializationService<T>
    {
        /// <summary>
        /// Сериализация объекта в поток.
        /// </summary>
        /// <param name="value">Объект для сериализации.</param>
        /// <param name="stream">Поток для сериализации.</param>
        void Serialize(T value, Stream stream);

        /// <summary>
        /// Десериализация объекта из потока.
        /// </summary>
        /// <param name="stream">Поток для десериализации.</param>
        /// <returns>Десериализованный объект.</returns>
        T Deserialize(Stream stream);
    }
}