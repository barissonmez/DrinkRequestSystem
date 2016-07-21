using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DRS.DTO;

namespace DRS.ServiceManager
{
    public class ServiceManager
    {
        private readonly DataManager.DataManager _dataManager;

        public ServiceManager()
        {
            _dataManager = new DataManager.DataManager();
        }

        public UserDTO GetUserById(int id)
        {
            var userDTO = new UserDTO();

            var userEntity = _dataManager.GetUserById(id);

            if (userEntity != null)
            {
                userDTO.Id = userEntity.Id;
                userDTO.Fullname = userEntity.Fullname;
                userDTO.Username = userEntity.Username;
                userDTO.Password = userEntity.Password;
            }

            return userDTO;
        }

        public List<DrinkDTO> GetAllDrinks()
        {
            var drinksModel = new List<DrinkDTO>();

            var drinks = _dataManager.GetAllDrinks();

            if (drinks.Any())
            {
                drinks.ForEach(d=> drinksModel.Add(new DrinkDTO
                    {
                        Id = d.Id,
                        Name = d.Name,
                        Type = (Enums.DrinkType)d.Type
                    }));
            }

            return drinksModel;
        }

        public List<DrinkDTO> GetDrinksByType(Enums.DrinkType type)
        {
            var drinksModel = new List<DrinkDTO>();

            var drinks = _dataManager.GetDrinksByType((int)type);

            if (drinks.Any())
            {
                drinks.ForEach(d => drinksModel.Add(new DrinkDTO
                {
                    Id = d.Id,
                    Name = d.Name,
                    Type = (Enums.DrinkType)d.Type
                }));
            }

            return drinksModel;
        }

        public bool CreateOrder(int id)
        {
            return _dataManager.CreateOrder(id);
        }

        public bool DeleteOrder(int id)
        {
            return _dataManager.DeleteOrder(id);
        }

        public List<OrderDTO> GetTodaysOrders()
        {
            var orders = new List<OrderDTO>();

            var todaysOrders = _dataManager.GetTodaysOrders().OrderByDescending(a=> a.CreateDate).ToList();

            if (todaysOrders.Any())
            {
                todaysOrders.ForEach(a=> orders.Add(new OrderDTO
                    {
                        Id = a.Id,
                        CreateDate = a.CreateDate.ToShortTimeString(),
                        State = GetState(a.State),
                        UserId = a.UserId,
                        UserFullname = _dataManager.GetUserById(a.UserId).Fullname,
                        TimePassed = (DateTime.Now - a.CreateDate).Minutes.ToString(),
                        DrinkName = _dataManager.GetDrinkById(a.DrinkId).Name
                    }));
            }

            return orders;
        }

        private string GetState(int state)
        {
            switch (state)
            {
                case (int) Enums.OrderState.InQueue:
                    return "Sıraya Alındı";
                case (int) Enums.OrderState.Ready:
                    return "Hazır";
            }

            return null;
        }
    }
}
