using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using WpfBase.Framework;

namespace WpfBase.Common
{
    public static class ListExtensions
    {
        public static void AddNewRow<T>(this List<T> source) where T : new()
        {
            source.Add(new T());
        }

        public static void RemoveRow<T>(this List<T> source,T entity) where T : new()
        {
            var deleteEntity = source.Where(e => e.Json() == entity.Json()).First();
            source.Remove(deleteEntity);
        }
    }
}
