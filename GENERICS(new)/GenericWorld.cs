using System;
using System.Collections;
using System.Collections.Generic;

namespace GENERICS_
{

    [Serializable]
    internal class GenericWorld<T> : IEnumerable<T>
        // where T: class

    {
        T[] data = new T[0];

        public void Add(T item)
        {
            Array.Resize(ref data, data.Length + 1);
            data[data.Length - 1] = item;
        }

        //index
        public T this[int index] 
        {
            get
            {
                if (index >= data.Length)
                    return default(T);
                if (index < 0)
                {
                    throw new IndexOutOfRangeException();
                }
                   
                
                return data[index];
            }
        }

        public void RemoveAt(int index)
        {
            if (index >= data.Length || index < 0)
                return;

            for(int i = index; i < data.Length; i++)
            {
                data[i] = data[i + 1];
            }

            Array.Resize(ref data, data.Length - 1);

        }

        public int Lenght {
            get 
            {
              return data.Length;
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            foreach (var item in data)
            {
                yield return item;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
          return GetEnumerator();
        }
    }
}
