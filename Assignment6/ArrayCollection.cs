using System;
using System.Collections;
using System.Collections.Generic;

namespace Assignment6
{
    /// <summary>
    /// Extra Credit: cast operator to a C# array or a `System.Collections.Generic.List<T>`
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// 
    public class ArrayCollection<T> : ICollection<T>
    {
        private List<T> Data { get; set; }
        public int Capacity { get; private set; }
        public int Count => Data.Count;
        public bool IsReadOnly { get; set; }
        

        public ArrayCollection(int capacity)
        {
            if (capacity <= 0 || capacity > Int32.MaxValue)
            {
                throw new ArgumentOutOfRangeException(nameof(capacity));
            }
            Data = new List<T>(capacity);
            Capacity = capacity;
            IsReadOnly = false;
        }

        public ArrayCollection(ICollection<T> collection)
        {
            if (collection is null)
            {
                throw new ArgumentNullException(nameof(collection));
            }

            Data = new List<T>(collection);
            Capacity = Data.Capacity;
            IsReadOnly = false;
        }

        public ArrayCollection(int capacity, bool isReadOnly)
        {
            if (capacity <= 0 || capacity > Int32.MaxValue)
            {
                throw new ArgumentOutOfRangeException(nameof(capacity));
            }
            Data = new List<T>(capacity);
            Capacity = capacity;
            IsReadOnly = isReadOnly;
        }

        public T this[int i]
        {
            get
            {
                if (i >= Capacity || i < 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(i));
                }
                return Data[i];
            }
            set {
                if (value is null)
                {
                    throw new ArgumentNullException(nameof(value));
                }
                if (i >= Count || i < 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(i));
                }
                if (!IsReadOnly)
                {
                    Data[i] = value;
                }
            }
        }

        public bool Contains(T value)
        {
            return Data.Contains(value);
        }

        public void Add(T item)
        {
            if (item is null)
            {
                throw new ArgumentNullException(nameof(item));
            }
            if (!IsReadOnly && Count <= Capacity)
            {
                Data.Add(item);
            }
            if (Count > Capacity)
            {
                throw new ArgumentException("Array is full");
            }
        }

        public void Clear()
        {
            if (!IsReadOnly)
            {
                Data.Clear();
            }
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
            if (!IsReadOnly)
            {
                return Data.Remove(item);
            } else
            {
                return false;
            }
            
        }

        public IEnumerator<T> GetEnumerator()
        {
            return Data.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return Data.GetEnumerator();
        }

        /// <summary>
        /// Extra Credit: cast operator to a C# array or a `System.Collections.Generic.List<T>`
        /// 
        /// </summary>
        /// <param name="arr"></param>
        public static explicit operator Array(ArrayCollection<T> arr)
        {
            if (arr is null)
            {
                throw new ArgumentNullException(nameof(arr));
            }
            T[] ret = new T[arr.Count];
            int i = 0;
            foreach (T t in arr)
            {
                ret[i++] = t;
            }

            return ret;
        }

        /// <summary>
        /// Extra Credit: cast operator to a C# array or a `System.Collections.Generic.List<T>`
        /// 
        /// </summary>
        /// <param name="arr"></param>
        public static explicit operator ArrayCollection<T>(Array arr)
        {
            if (arr is null)
            {
                throw new ArgumentNullException(nameof(arr));
            }
            ArrayCollection<T> ret = new ArrayCollection<T>(arr.Length);
            foreach (T t in arr)
            {
                ret.Add(t);
            }

            return ret;
        }
    }
}
