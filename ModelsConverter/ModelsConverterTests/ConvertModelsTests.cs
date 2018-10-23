using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ModelsConverter;
using ModelsConverter.Attributes;

[assembly: AssemblyWithConverters]
namespace ModelsConverterTests
{
    [TestClass]
    public class ConvertModelsTests
    {
        private IModelsConverter _modelsConverter;
        public ConvertModelsTests()
        {
            _modelsConverter = new Converter();
        }
        [TestMethod]
        public void ConvertFirstModelTest()
        {
            var model = new FirstModel(1, "first", "first description");
            if (_modelsConverter.TryConvert<FirstModel, SecondModel>(model, out var result))
            {
                Assert.IsTrue(result.Id == model.Id && result.Name == model.Name && result.Description == model.Description);
            }
            else
            {
                Assert.Fail("Model is not converted");
            }
        }
        [TestMethod]
        public void ConvertSecondModelTest()
        {
            var model = new SecondModel(2, "second", "second description");
            if (_modelsConverter.TryConvert<SecondModel, FirstModel>(model, out var result))
            {
                Assert.IsTrue(result.Id == model.Id && result.Name == model.Name && result.Description == model.Description);
            }
            else
            {
                Assert.Fail("Model is not converted");
            }
        }
        [TestMethod]
        public void ConvertCollectionTest()
        {
            var collection = new List<FirstModel>
            {
                new FirstModel(1, "1", "1"),
                new FirstModel(2, "2", "2"),
                new FirstModel(3, "3", "3"),
                new FirstModel(4, "4", "4"),
                new FirstModel(5, "5", "5"),
                new FirstModel(6, "6", "6"),
                new FirstModel(7, "7", "7")
            };
            if (_modelsConverter.TryConvert<FirstModel, SecondModel>(collection, out var result))
            {
              
                if (collection.Count != result.Count())
                {
                    Assert.Fail("different items count between collection and result");
                }
                else
                {
                    var resultList = result.ToList();
                    for (int i = 0; i < result.Count(); i++)
                    {
                        Assert.IsTrue(collection[i].Id == resultList[i].Id && collection[i].Name == resultList[i].Name && collection[i].Description == resultList[i].Description);
                    }
                }

            }
            else
            {
                Assert.Fail("Models is not converted");
            }
        }
    }
}
