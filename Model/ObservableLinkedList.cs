using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;

namespace LabaApp.Model
{
    /// <summary>
    /// This class is a LinkedList that can be used in a WPF MVVM scenario. Composition was used instead of inheritance,
    /// because inheriting from LinkedList does not allow overriding its methods.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    //see: https://stackoverflow.com/questions/6996425/observable-linkedlist
    public class ObservableLinkedList<T> : INotifyCollectionChanged, IEnumerable, IEnumerable<T>
    {
        private LinkedList<T> underLyingLinkedList;

        /// <summary>
        /// Количество элементов двусвязного списка.
        /// </summary>
        public int Count
        {
            get { return underLyingLinkedList.Count; }
        }

        /// <summary>
        /// Первый элемент двусвязного списка.
        /// </summary>
        public LinkedListNode<T> First
        {
            get { return underLyingLinkedList.First; }
        }

        /// <summary>
        /// Последний элемент двусвязного списка.
        /// </summary>
        public LinkedListNode<T> Last
        {
            get { return underLyingLinkedList.Last; }
        }

        /// <summary>
        /// Конструктор <see cref="ObservableLinkedList"/>.
        /// </summary>
        public ObservableLinkedList()
        {
            underLyingLinkedList = new LinkedList<T>();
        }

        /// <summary>
        /// Конструктор <see cref="ObservableLinkedList"/>.
        /// </summary>
        public ObservableLinkedList(IEnumerable<T> collection)
        {
            underLyingLinkedList = new LinkedList<T>(collection);
        }

        /// <summary>
        /// Добавить в список новый элемент перед заданным.
        /// </summary>
        /// <param name="prevNode">Элемент списка, перед котороым нужно добавить новый.</param>
        /// <param name="value">Добавляемое значение.</param>
        /// <returns>Ссылка на добавленный в список элемент.</returns>
        public LinkedListNode<T> AddAfter(LinkedListNode<T> prevNode, T value)
        {
            LinkedListNode<T> ret = underLyingLinkedList.AddAfter(prevNode, value);
            OnNotifyCollectionChanged();
            return ret;
        }

        /// <summary>
        /// Добавить в список новый элемент перед заданным.
        /// </summary>
        /// <param name="prevNode">Элемент списка, перед котороым нужно добавить новый.</param>
        /// <param name="value">Добавляемое значение.</param>
        public void AddAfter(LinkedListNode<T> node, LinkedListNode<T> newNode)
        {
            underLyingLinkedList.AddAfter(node, newNode);
            OnNotifyCollectionChanged();
        }

        /// <summary>
        /// Добавить в список новый элемент после заданного.
        /// </summary>
        /// <param name="prevNode">Элемент списка, после которого нужно добавить новый.</param>
        /// <param name="value">Добавляемое значение.</param>
        /// <returns>Ссылка на добавленный в список элемент.</returns>
        public LinkedListNode<T> AddBefore(LinkedListNode<T> node, T value)
        {
            LinkedListNode<T> ret = underLyingLinkedList.AddBefore(node, value);
            OnNotifyCollectionChanged();
            return ret;
        }

        /// <summary>
        /// Добавить в список новый элемент после заданного.
        /// </summary>
        /// <param name="prevNode">Элемент списка, после которого нужно добавить новый.</param>
        /// <param name="value">Добавляемое значение.</param>
        public void AddBefore(LinkedListNode<T> node, LinkedListNode<T> newNode)
        {
            underLyingLinkedList.AddBefore(node, newNode);
            OnNotifyCollectionChanged();
        }

        /// <summary>
        /// Добавить в начало списка новый элемент.
        /// </summary>
        /// <param name="value">Добавляемый элемент.</param>
        /// <returns>Ссылка на добавленный в список элемент.</returns>
        public LinkedListNode<T> AddFirst(T value)
        {
            LinkedListNode<T> ret = underLyingLinkedList.AddFirst(value);
            OnNotifyCollectionChanged();
            return ret;
        }

        /// <summary>
        /// Добавить в начало списка новый элемент.
        /// </summary>
        /// <param name="value">Добавляемый элемент.</param>
        public void AddFirst(LinkedListNode<T> node)
        {
            underLyingLinkedList.AddFirst(node);
            OnNotifyCollectionChanged();
        }

        /// <summary>
        /// Добавить в конец списка новый элемент.
        /// </summary>
        /// <param name="value">Добавляемый элемент.</param>
        /// <returns>Ссылка на добавленный в список элемент.</returns>
        public LinkedListNode<T> AddLast(T value)
        {
            LinkedListNode<T> ret = underLyingLinkedList.AddLast(value);
            OnNotifyCollectionChanged();
            return ret;
        }

        /// <summary>
        /// Добавить в конец списка новый элемент.
        /// </summary>
        /// <param name="value">Добавляемый элемент.</param>
        public void AddLast(LinkedListNode<T> node)
        {
            underLyingLinkedList.AddLast(node);
            OnNotifyCollectionChanged();
        }

        /// <summary>
        /// Очистить список.
        /// </summary>
        public void Clear()
        {
            underLyingLinkedList.Clear();
            OnNotifyCollectionChanged();
        }

        /// <summary>
        /// Содержит ли список элемент с заданным значением.
        /// </summary>
        /// <param name="value">Значение элемента для поиска.</param>
        /// <returns>Признак наличия в списке элемента с заданным значением.</returns>
        public bool Contains(T value)
        {
            return underLyingLinkedList.Contains(value);
        }

        /// <summary>
        /// Копировать элементы списка с заданной позиции в массив.
        /// </summary>
        /// <param name="array">Целевой массив для копирования.</param>
        /// <param name="index">Позиция списка, начиная с которой элементы будут скопированы в целевой массив.</param>
        public void CopyTo(T[] array, int index)
        {
            underLyingLinkedList.CopyTo(array, index);
        }

        /// <summary>
        /// Проверка списка на равенство с другим объектом.
        /// </summary>
        /// <param name="obj">Объект для сравнения.</param>
        /// <returns>Равен ли список заданному элементу.</returns>
        public bool LinkedListEquals(object obj)
        {
            return underLyingLinkedList.Equals(obj);
        }

        /// <summary>
        /// Находит первый элемент списка с заданным значением.
        /// </summary>
        /// <param name="value">Значение элемента для поиска.</param>
        /// <returns>Элемент списка с заданным значением.</returns>
        public LinkedListNode<T> Find(T value)
        {
            return underLyingLinkedList.Find(value);
        }

        /// <summary>
        /// Находит последний элемент списка с заданным значением.
        /// </summary>
        /// <param name="value">Значение элемента для поиска.</param>
        /// <returns>Элемент списка с заданным значением.</returns>
        public LinkedListNode<T> FindLast(T value)
        {
            return underLyingLinkedList.FindLast(value);
        }

        /// <summary>
        /// Получить тип списка.
        /// </summary>
        /// <returns>Тип списка.</returns>
        public Type GetLinkedListType()
        {
            return underLyingLinkedList.GetType();
        }

        /// <summary>
        /// Удалить элемент с заданным значением.
        /// </summary>
        /// <param name="value">Значение элемента для удаления.</param>
        /// <returns>Удален ли элемент.</returns>
        public bool Remove(T value)
        {
            bool ret = underLyingLinkedList.Remove(value);
            OnNotifyCollectionChanged();
            return ret;
        }

        /// <summary>
        /// Удалить выбранный элемент списка.
        /// </summary>
        public void Remove(LinkedListNode<T> node)
        {
            underLyingLinkedList.Remove(node);
            OnNotifyCollectionChanged();
        }

        /// <summary>
        /// Удалить первый элемент списка.
        /// </summary>
        public void RemoveFirst()
        {
            underLyingLinkedList.RemoveFirst();
            OnNotifyCollectionChanged();
        }

        /// <summary>
        /// Удалить последний элемент списка.
        /// </summary>
        public void RemoveLast()
        {
            underLyingLinkedList.RemoveLast();
            OnNotifyCollectionChanged();
        }

        /// <summary>
        /// Событие изменение коллекции. Реализация интерфейса <see cref="INotifyCollectionChanged"/>.
        /// </summary>
        public event NotifyCollectionChangedEventHandler CollectionChanged;
        public void OnNotifyCollectionChanged()
        {
            CollectionChanged?.Invoke(this, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
        }

        /// <summary>
        /// Реализация интерфейса <see cref="IEnumerable"/>.
        /// </summary>
        /// <returns>Перечислитель перечисления коллекции.</returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return (underLyingLinkedList as IEnumerable).GetEnumerator();
        }

        /// <summary>
        /// Реализация интерфейса <see cref="IEnumerable{T}"/>.
        /// </summary>
        /// <returns>Перечислитель типизированного перечисления коллекции.</returns>
        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            return (underLyingLinkedList as IEnumerable<T>).GetEnumerator();
        }
    }
}