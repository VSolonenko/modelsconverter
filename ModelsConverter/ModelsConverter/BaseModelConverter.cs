using System;
using System.Collections.Generic;
using System.Text;

namespace ModelsConverter
{
    public abstract class BaseModelConverter : IModelConverter
    {
        object Convert(object item)
        {
            Type type = item.GetType();
            if (type == FirstType)
            {
                return ConvertMethod(item);
            }
            else if (type == SecondType)
            {
                return ReverseConvertMethod(item);
            }
            return null;
        }
        public bool TryConvert(object source, out object result, Type resultType)
        {
            var isConverted = false;
            result = null;
            if (source != null)
            {
                if ((source.GetType() == FirstType || source.GetType() == SecondType) && (resultType == FirstType || resultType == SecondType))
                {
                    result = Convert(source);
                    if (result != null)
                    {
                        isConverted = true;
                    }
                }
            }
            return isConverted;
        }
        public Type FirstType { get; }
        public Type SecondType { get; }
        public Func<object, object> ConvertMethod { get; protected set; }

        public Func<object, object> ReverseConvertMethod { get; protected set; }
    }
}
