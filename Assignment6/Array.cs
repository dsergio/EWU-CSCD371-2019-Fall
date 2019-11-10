using System;
using System.Collections;
using System.Collections.Generic;

namespace Assignment6
{
    public class Array<T> : System.Collections.Generic.ICollection<T>
    {
        private Dictionary<int, T> Data { get; set; }
        public int Size { get; private set; }

        public int Count => throw new NotImplementedException();

        public bool IsReadOnly => throw new NotImplementedException();

        public Array(int size)
        {
            Data = new Dictionary<int, T>();
            Size = size;
        }

        public T this[int i]
        {
            get
            {
                Data.TryGetValue(i, out T value);
                return value;
            }
            set {
                Set(i, value);
            }
        }

        public bool TryGetValue(int i, out T value)
        {
            bool ret = Data.TryGetValue(i, out T internalValue);
            value = internalValue;
            return ret;
        }

        public void Set(int i, T value)
        {
            if (i < Size && i >= 0)
            {
                Data.Add(i, value);
            }
        }

        public bool Contains(T value)
        {
            return Data.ContainsValue(value);
        }

        public void Add(T item)
        {
            throw new NotImplementedException();
        }

        public void Clear()
        {
            throw new NotImplementedException();
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public bool Remove(T item)
        {
            throw new NotImplementedException();
        }

        public IEnumerator<T> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
