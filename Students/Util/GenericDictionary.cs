using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Students.Util
{
    public class GenericDictionary<TKey, TValue> : Dictionary<TKey, TValue>
    {
        public void AddToGenericDictionary(TKey key, TValue value)
        {
            this.Add(key, value);
        }

        public String getValue(TKey key)
        {
            return this[key].ToString();
        }
    }
}