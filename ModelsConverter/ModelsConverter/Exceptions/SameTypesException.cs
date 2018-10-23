using System;
using System.Collections.Generic;
using System.Text;

namespace ModelsConverter.Exceptions
{
    public class SameTypesException: Exception
    {
        private readonly Type _type;

        public SameTypesException(Type type)
        {
            _type = type;
        }

        public override string Message => $"Soure and Result has same type: {_type}";
    }

}
