

using ModelsConverter;
using ModelsConverter.Attributes;

namespace ModelsConverterTests
{
    [Converter]
    public class FirstModelConverter: BaseCollectionConverter
    {
        private FirstModel Convert(SecondModel secondModel) => new FirstModel(secondModel.Id, secondModel.Name, secondModel.Description);
        private SecondModel Convert(FirstModel firstModel) => new SecondModel(firstModel.Id, firstModel.Name, firstModel.Description);
        public FirstModelConverter(): base(typeof(FirstModel), typeof(SecondModel))
        {
            ConvertMethod = i => Convert((FirstModel)i);
            ReverseConvertMethod = i => Convert((SecondModel)i);
        }
    }
}
