using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DRS.Entity
{
    public class Order
    {
        public int Id { get; set; }

        public DateTime CreateDate { get; set; }

        public int State { get; set; }

        public int UserId { get; set; }
        
        public int DrinkId { get; set; }

    }
}
