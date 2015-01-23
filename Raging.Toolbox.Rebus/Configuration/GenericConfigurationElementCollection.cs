using System.Collections.Generic;
using System.Configuration;

namespace Tru.Common.Rebus.Configuration
{
    public class GenericConfigurationElementCollection<T>
        : ConfigurationElementCollection, IEnumerable<T> where T : ConfigurationElement, new()
    {
        public T this[int index]
        {
            get
            {
                return (T)this.BaseGet(index);
            }
            set
            {
                if (this.BaseGet(index) != null)
                    this.BaseRemoveAt(index);

                this.BaseAdd(index, value);
            }
        }

        public void Add(T element)
        {
            this.BaseAdd(element);
        }

        public void Clear()
        {
            this.BaseClear();
        }

        protected override ConfigurationElement CreateNewElement()
        {
            return new T();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return element;
        }

        public void Remove(T element)
        {
            this.BaseRemove(element);
        }

        public void RemoveAt(int index)
        {
            this.BaseRemoveAt(index);
        }

        public new IEnumerator<T> GetEnumerator()
        {
            for (var index = 0; index < this.Count; ++index)
            {
                yield return (T)this.BaseGet(index);
            }
        }

        public override bool IsReadOnly()
        {
            return false;
        }
    }
}