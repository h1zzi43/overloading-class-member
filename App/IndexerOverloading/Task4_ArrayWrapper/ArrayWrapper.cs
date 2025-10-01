using System;

namespace App.IndexerOverloading.Task4_ArrayWrapper
{
    public class ArrayWrapper<T>
    {
        private readonly T[] _array;

        // Конструктор принимает массив. При null — ArgumentNullException.
        public ArrayWrapper(T[] array)
        {
            _array = array ?? throw new ArgumentNullException(nameof(array), "Array cannot be null");
        }

        // Свойство Length для получения длины
        public int Length => _array.Length;

        // Индексатор [int index] для чтения/записи с проверкой границ (IndexOutOfRangeException)
        public T this[int index]
        {
            get
            {
                ValidateIndex(index);
                return _array[index];
            }
            set
            {
                ValidateIndex(index);
                _array[index] = value;
            }
        }

        // Проверка границ индекса
        private void ValidateIndex(int index)
        {
            if (index < 0 || index >= _array.Length)
            {
                throw new IndexOutOfRangeException($"Index {index} is out of range. Array length is {_array.Length}");
            }
        }

        // Дополнительные полезные методы (опционально)
        public T[] ToArray()
        {
            return (T[])_array.Clone();
        }

        public bool Contains(T item)
        {
            return Array.IndexOf(_array, item) >= 0;
        }
    }
}