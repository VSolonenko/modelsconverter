using System.Collections.Generic;

namespace ModelsConverter
{
    public interface IModelsConverter
    {
        bool TryConvert<TSource, TResult>(TSource source, out TResult result);
        TResult Convert<TSource, TResult>(TSource source);
        bool TryConvert<TSource, TResult>(IEnumerable<TSource> sourse, out IEnumerable<TResult> result);
        IEnumerable<TResult> Convert<TSource, TResult>(IEnumerable<TSource> source);
    }
}
