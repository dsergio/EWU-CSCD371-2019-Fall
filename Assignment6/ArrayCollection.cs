using System;
using System.Collections;
using System.Collections.Generic;

namespace Assignment6
{
    public class ArrayCollection<T> : System.Collections.Generic.ICollection<T> where T: class
    {
        private List<T> Data { get; set; }
        public int Capacity { get; private set; }

        public int Count { get; private set; }

        public bool IsReadOnly { get; set; }

        public ArrayCollection(int capacity)
        {
            Data = new List<T>();
            Capacity = capacity;
            IsReadOnly = false;
        }

        public ArrayCollection(int capacity, bool isReadOnly)
        {
            Data = new List<T>();
            Capacity = capacity;
            IsReadOnly = isReadOnly;
        }

        public T this[int i]
        {
            get
            {
                if (i >= Capacity || i < 0)
                {
                    throw new ArgumentException("Index out of range.", nameof(i));
                }
                return Data[i];
            }
            set {
                if (!IsReadOnly)
                {
                    Set(i, value);
                }
            }
        }

        public bool TryGetValue(int i, out T? value)
        {
            if (Data[i] is T)
            {
                value = Data[i];
                return true;
            } else
            {
                value = default;
                return false;
            }
            //bool ret = Data.TryGetValue(i, out T internalValue);
            //value = internalValue;
            //return ret;
        }

        public void Set(int i, T value)
        {
            if (i >= Capacity || i < 0)
            {
                throw new ArgumentException("Index out of range.", nameof(i));
            }
            Data[i] = value;
        }

        public bool Contains(T value)
        {
            return Data.Contains(value);
        }

        public void Add(T? item)
        {
            if (item is null)
            {
                throw new ArgumentNullException(nameof(item));
            }
            Data.Add(item);
        }

        public void Clear()
        {
            Data.Clear();
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            Data.CopyTo(array, arrayIndex);
        }

        public bool Remove(T item)
        {
            if (!Data.Contains(item))
            {
                throw new ArgumentException("Item does not exist", nameof(item));
            }
            return Data.Remove(item);
        }

        public IEnumerator<T> GetEnumerator()
        {
            return Data.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return Data.GetEnumerator();
        }
    }
}
