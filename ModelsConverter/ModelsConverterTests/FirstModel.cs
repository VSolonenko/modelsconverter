using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelsConverterTests
{
    class FirstModel
    {
        public FirstModel(int id, string name, string description)
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
