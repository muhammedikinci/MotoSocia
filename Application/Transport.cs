using System.Collections.Generic;

namespace Application
{
    public class Transport<T>
    {
        public Dependencies Dependencies { get; set; }
        public T Data;
        public IList<T> DataList;
        public object[] MultipleObjects;
    }
}
