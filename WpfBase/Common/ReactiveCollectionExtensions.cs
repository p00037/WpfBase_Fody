using Reactive.Bindings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfBase.Common
{
    public static class ReactiveCollectionExtensions
    {
        public static void AddRange<T>(this ReactiveCollection<T> source, IEnumerable<T> addList)
        {
            var aaa =Task.Run(() =>
            {
                source.AddRangeOnScheduler(addList);
            });

            aaa.Wait();
        }
    }
}
