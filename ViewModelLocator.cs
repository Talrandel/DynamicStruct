using CommonServiceLocator;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using LabaApp.Main;
using LabaApp.Model;
using LabaApp.Services;

namespace LabaApp
{
    /// <summary>
    /// Локатор (контейнер) в котором выполняется регистрация сервисов и декларируемых типов для дальнейшего использованиях их экземпляров.
    /// </summary>
    public class ViewModelLocator
    {
        /// <summary>
        /// Конструктор <see cref="ViewModelLocator"/>.
        /// </summary>
        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            if (ViewModelBase.IsInDesignModeStatic)
                SimpleIoc.Default.Register<IDataService, DesignDataService>();
            else
                SimpleIoc.Default.Register<IDataService, DataService>();

            SimpleIoc.Default.Register<ISerializationService<Node>, XmlSerializationService>();

            SimpleIoc.Default.Register<MainViewModel>();
        }
        
        /// <summary>
        /// Ссылка на ViewModel <see cref="MainViewModel"/> для использования в дизайнере форм.
        /// </summary>
        public MainViewModel Main
        {
            get { return SimpleIoc.Default.GetInstance<MainViewModel>(); }
        }
    }
}