using ModelsConverter.Attributes;
using ModelsConverter.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace ModelsConverter
{
    public class Converter: IModelsConverter
    {
        private ICollection<BaseModelConverter> _modelConverters;
        private ICollection<BaseCollectionConverter> _collectionConverters;

        public Converter()
        {
            var assemblies = AppDomain.CurrentDomain.GetAssemblies();
            _modelConverters = new List<BaseModelConverter>();
            _collectionConverters = new List<BaseCollectionConverter>();
            foreach (var assembly in assemblies)
            {
                if (assembly.GetCustomAttribute(typeof(AssemblyWithConvertersAttribute)) != null)
                {
                    var types = assembly.GetTypes();
                    foreach (var type in types)
                    {
                        if (type.GetCustomAttribute(typeof(ConverterAttribute)) != null)
                        {
                            if (type.BaseType == typeof(BaseModelConverter))
                            {
                                var constructor = type.GetConstructor(Type.EmptyTypes);
                                var secondConstructor = type.GetConstructor(new Type[] { typeof(IModelsConverter) });
                                if (secondConstructor != null)
                                {
                                    var result = (BaseModelConverter)secondConstructor.Invoke(new object[] { this });
                                    _modelConverters.Add(result);
                                }
                                else
                                {
                                    var result = (BaseModelConverter)constructor.Invoke(Type.EmptyTypes);
                                    _modelConverters.Add(result);
                                }


                            }
                            else if (type.BaseType == typeof(BaseCollectionConverter))
                            {
                                var constructor = type.GetConstructor(Type.EmptyTypes);
                                var secondConstructor = type.GetConstructor(new Type[] { typeof(IModelsConverter) });
                                if (secondConstructor != null)
                                {
                                    var result = (BaseCollectionConverter)secondConstructor.Invoke(new object[] { this });
                                    _collectionConverters.Add(result);
                                }
                                else
                                {
                                    var result = (BaseCollectionConverter)constructor.Invoke(Type.EmptyTypes);
                                    _collectionConverters.Add(result);
                                }
                            }
                        }
                    }
                }
            }
        }
        private void TryCheckOnSameTypes(Type sourceType, Type resultType)
        {
            if (sourceType == resultType)
            {
                throw new SameTypesException(sourceType);
            }
        }
        public bool TryConvert<TSource, TResult>(TSource source, out TResult result)
        {
            try
            {
                result = Convert<TSource, TResult>(source);
                return true;
            }
            catch (Exception e)
            {
                result = default(TResult);
                return false;
            }

        }

        public TResult Convert<TSource, TResult>(TSource source)
        {
            TryCheckOnSameTypes(typeof(TSource), typeof(TResult));

            foreach (var converter in _modelConverters.Union(_collectionConverters))
            {
                if (converter.TryConvert(source, out var result, typeof(TResult)))
                {
                    return (TResult)result;
                }
            }
            throw new CantConvertException(typeof(TSource), typeof(TResult), _modelConverters, _collectionConverters);
        }

        public bool TryConvert<TSource, TResult>(IEnumerable<TSource> sourse, out IEnumerable<TResult> result)
        {
            result = Convert<TSource, TResult>(sourse);
            return result != null;
        }

        public IEnumerable<TResult> Convert<TSource, TResult>(IEnumerable<TSource> source)
        {
            TryCheckOnSameTypes(typeof(TSource), typeof(TResult));
            foreach (var converter in _collectionConverters)
            {
                if ((typeof(TResult) == converter.FirstType || typeof(TResult) == converter.SecondType) && (typeof(TSource) == converter.FirstType || typeof(TSource) == converter.SecondType))
                {
                    var foo = converter.Convert<TSource, TResult>(source, typeof(TResult));
                    return foo;
                }
            }
            throw new CantConvertException(typeof(TSource), typeof(TResult), _modelConverters, _collectionConverters);
        }
    }
}

