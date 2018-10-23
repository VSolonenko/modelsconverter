using System;
using System.Collections.Generic;
using System.Text;

namespace ModelsConverter.Exceptions
{
    public class CantConvertException: Exception
    {
        private readonly Type _source;
        private readonly Type _result;
        private readonly IEnumerable<BaseModelConverter> _converters;
        private readonly IEnumerable<BaseCollectionConverter> _collectionConverters;
        private string _foo;
        private string _bar;
        private string CreateSupportedConversionsString(IEnumerable<BaseModelConverter> converters)
        {
            var strBuilder = new StringBuilder();
            foreach (var converter in converters)
            {
                strBuilder.Append($"{converter.FirstType.Name} : {converter.SecondType.Name}\n");
            }
            return strBuilder.ToString();
        }
        public CantConvertException(Type source, Type result, IEnumerable<BaseModelConverter> converters, IEnumerable<BaseCollectionConverter> collectionConverters)
        {
            _source = source;
            _result = result;
            _converters = converters;
            _collectionConverters = collectionConverters;
        }

        public override string Message => $"Can not convert type {_source} to type {_result}\nSupported conversions:\n{SupportedConversions}\nSupported collections conversions:\n{SupportedCollectionsConversions}";
        public string SupportedConversions => _foo ?? (_foo = CreateSupportedConversionsString(_converters));
        public string SupportedCollectionsConversions => _bar ?? (_bar = CreateSupportedConversionsString(_collectionConverters));
    }
}
