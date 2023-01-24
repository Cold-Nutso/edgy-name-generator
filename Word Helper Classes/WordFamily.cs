using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Edgy_Name_Generator
{
    public class WordFamily<T> : IComparable
    {
        // Fields
    
        private string name;
        private List<T> items;
    
    
    
        // Properties
    
        public string Name { get { return name; } set { name = value; } }
        public List<T> Items { get { return items; } }
        public int Count { get { return items.Count; } }
        public T this[int i] { 
            get 
            {
                if (i < 0)
                    return items[0];
                else if (i >= items.Count)
                    return items[items.Count - 1];
                else
                    return items[i]; 
            } 
            set { items[i] = value; } 
        }
    
    
    
        // Constructor
    
        public WordFamily(string name = "Family Name")
        {
            this.name = name;
            items = new List<T>();
        }
    
    
    
        // Methods
    
        public int CompareTo(object obj)
        {
            WordFamily<T> other = (WordFamily<T>)obj;
            return string.Compare(name, other.name);
        }
 
        public bool Add(T input)
            {
                // Check if input is already there
                foreach (T item in items)
                    if (input.Equals(item))
                        return false;

                items.Add(input);
                items.Sort();
                return true;
            }
        public bool Remove(T input)
            {
                // Search for the input
                foreach (T item in items)
                    if (input.Equals(item))
                    {
                        items.Remove(item);
                        return true;
                    }

                return false;
            }
        public bool RemoveAt(int index)
            {
                if (index < 0 || index >= items.Count)
                    return false;

                items.RemoveAt(index);
                return true;
            }
        public int IndexOf(T input)
        {
            // Search for the input
            for (int i = 0; i < Count; i++)
                if (input.Equals(items[i]))
                    return i;

            return -1;
        }
    }
}
