using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public record UpdatePhoneDto
    {
        public string Name { get; set; }
        public double DiagonalScreenSize { get; set; }
        public DisplayType DisplayType { get; set; }
    }
}
