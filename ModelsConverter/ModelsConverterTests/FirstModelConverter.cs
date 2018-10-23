

using ModelsConverter;
using ModelsConverter.Attributes;

namespace ModelsConverterTests
{
    [Converter]
    public class FirstModelConverter: BaseCollectionConverter
    {
        private Address Convert(AddressViewModel secondModel) => new Address(secondModel.Id, secondModel.Country, secondModel.City, secondModel.Street, secondModel.Number);
        private AddressViewModel Convert(Address firstModel) => new AddressViewModel(firstModel.Id, firstModel.Country, firstModel.City, firstModel.Street, firstModel.Number);
        public FirstModelConverter(): base(typeof(Address), typeof(AddressViewModel))
        {
            ConvertMethod = i => Convert((Address)i);
            ReverseConvertMethod = i => Convert((AddressViewModel)i);
        }
    }
}
