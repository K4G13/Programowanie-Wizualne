using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public record CreateProducerDto
    {
        public string Name { get; init; } = string.Empty;
        public string CountryOfOrigin { get; init; } = string.Empty;
    }
}
