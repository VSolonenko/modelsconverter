using System;
using System.Collections.Generic;
using System.Text;

namespace ModelsConverter
{
    public abstract class BaseCollectionConverter : BaseModelConverter, ICollectionConverter
    {
        public IEnumerable<TResult> Convert<TSource, TResult>(IEnumerable<TSource> items, Type resultType)
        {
            var result = new List<TResult>();

            if (items != null)
            {
                foreach (var item in items)
                {
                    if (TryConvert(item, out var foo, resultType))
                    {
                        result.Add((TResult)foo);
                    }
                }
            }
            return result;
        }

        protected BaseCollectionConverter(Type firstType, Type secondType, Func<object, object> convertMethod, Func<object, object> reverseConvertMethod) : base(firstType, secondType, convertMethod, reverseConvertMethod)
        {
        }
        protected BaseCollectionConverter(Type firstType, Type secondType) : base(firstType, secondType)
        {
        }
    }
}
