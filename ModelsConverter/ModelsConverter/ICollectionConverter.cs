using System;
using System.Collections.Generic;
using System.Text;

namespace ModelsConverter
{
    interface ICollectionConverter
    {
        IEnumerable<TResult> Convert<TSource, TResult>(IEnumerable<TSource> items, Type itemType);
    }
}
