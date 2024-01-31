using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public record CreatePhoneDto
    {
        public string Name { get; set; }
        public double DiagonalScreenSize { get; set; }
        public DisplayType DisplayType { get; set; }
        public int ProducerId { get; set; }
    }
}
