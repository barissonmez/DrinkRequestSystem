using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DRS.DTO
{
    public class OrderDTO
    {
        public int Id { get; set; }

        public string CreateDate { get; set; }

        public string State { get; set; }

        public int UserId { get; set; }

        public string UserFullname { get; set; }

        public string TimePassed { get; set; }

        public string DrinkName { get; set; }

    }
}
