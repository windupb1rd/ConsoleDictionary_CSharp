using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleDictionary.DI
{
    public class DIContainer
    {
        public readonly static DIContainer instance = new DIContainer();

        private readonly Dictionary<Type, object> _container = new Dictionary<Type, object>();

        public void Register(Type type, object value)
        {
            _container.Add(type, value);
        }

        public T Release<T>()
        {
            return (T)_container[typeof(T)];
        }
    }
}
