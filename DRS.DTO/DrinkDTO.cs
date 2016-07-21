using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DRS.DTO
{
    public class DrinkDTO
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public Enums.DrinkType Type { get; set; }
    }
}
