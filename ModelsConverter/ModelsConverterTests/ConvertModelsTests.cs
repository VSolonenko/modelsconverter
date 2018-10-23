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
            var model = new Address(1, "Ukraine", "Odessa", "volzkyu ln", "6");
            if (_modelsConverter.TryConvert<Address, AddressViewModel>(model, out var result))
            {
                Assert.IsTrue(result.Id == model.Id && result.Street == model.Street && result.Number == model.Number);
                Assert.IsTrue(result.Country == model.Country && result.City == model.City);
            }
            else
            {
                Assert.Fail("Model is not converted");
            }
        }
        [TestMethod]
        public void ConvertSecondModelTest()
        {
            var model = new AddressViewModel(2, "Ukraine", "Odessa", "volzkyu ln", "8");
            if (_modelsConverter.TryConvert<AddressViewModel, Address>(model, out var result))
            {
                Assert.IsTrue(result.Id == model.Id && result.Street == model.Street && result.Number == model.Number);
                Assert.IsTrue(result.Country == model.Country && result.City == model.City);
            }
            else
            {
                Assert.Fail("Model is not converted");
            }
        }
        [TestMethod]
        public void ConvertCollectionTest()
        {
            var collection = new List<Address>
            {
                new Address(1, "Ukraine", "Odessa", "Deribasovskaya", "6"),
                new Address(1, "Ukraine", "Odessa", "Deribasovskaya", "2"),
                new Address(1, "Ukraine", "Odessa", "Deribasovskaya", "8"),
                new Address(1, "Ukraine", "Odessa", "Deribasovskaya", "14"),
                new Address(1, "Ukraine", "Odessa", "Deribasovskaya", "16"),
                new Address(1, "Ukraine", "Odessa", "Deribasovskaya", "20"),
                new Address(1, "Ukraine", "Odessa", "Deribasovskaya", "25")
            };
            if (_modelsConverter.TryConvert<Address, AddressViewModel>(collection, out var result))
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
                        Assert.IsTrue(collection[i].Id == resultList[i].Id && collection[i].Street == resultList[i].Street && collection[i].Number == resultList[i].Number);
                        Assert.IsTrue(collection[i].Country == resultList[i].Country && collection[i].City == resultList[i].City);
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
