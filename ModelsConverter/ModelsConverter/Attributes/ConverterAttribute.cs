using System;
using System.Collections.Generic;
using System.Text;

namespace ModelsConverter.Attributes
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class ConverterAttribute: Attribute
    {
    }
}
