# modelsconverter
.Net project for convert objects.
For example:
You have 2 classes Address and AddressViewModel. 
For convert this 2 classes, you need create class, which which will be inherited from BaseCollectionConverter, 
and it will be flagged with ConverterAttribute. 
After your assembly must be flagged with AssemblyWithConvertersAttribute.
After you can use Converter class for convert your objects.
Example used in ModelsConverterTests.
