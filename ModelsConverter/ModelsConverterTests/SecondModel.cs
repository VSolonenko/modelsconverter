using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelsConverterTests
{
    class SecondModel
    {
        public SecondModel(int id, string name, string description)
        {
            Id = id;
            Name = name;
            Description = description;
        }
        public int Id { get; }
        public string Name { get; }
        public string Description { get; }
    }
}
