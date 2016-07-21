using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DRS.DTO;

namespace DRS.UI.Web.Models
{
    public class DrinkListResponseModel
    {
        public DrinkListResponseModel()
        {
            ColdDrinks = new List<DrinkDTO>();
            HotDrinks = new List<DrinkDTO>();
        }

        public List<DrinkDTO> ColdDrinks { get; set; }
        public List<DrinkDTO> HotDrinks { get; set; }
    }
}