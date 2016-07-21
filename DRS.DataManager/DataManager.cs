using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DRS.Entity;
using FluentData;

namespace DRS.DataManager
{
    public class DataManager
    {
        private readonly IDbContext _dbContext;

        public DataManager()
        {
            if (_dbContext == null)
                _dbContext = new DbContext().ConnectionStringName("DrinkRequestSystemConnString", new SqlServerProvider());
        }

        public List<User> GetAllUsers()
        {
            return _dbContext.Sql("SELECT * from dbo.[User]").QueryMany<User>();
        }

        public User GetUserById(int id)
        {
            return _dbContext.Sql("SELECT * from dbo.[User] WHERE Id=@0", id).QuerySingle<User>();
        }

        public List<Drink> GetAllDrinks()
        {
            return _dbContext.Sql("SELECT * from Drink").QueryMany<Drink>();
        }

        public List<Drink> GetDrinksByType(int type)
        {
            return _dbContext.Sql("SELECT * from Drink WHERE Type=@0", type).QueryMany<Drink>();
        }

        public Drink GetDrinkById(int id)
        {
            return _dbContext.Sql("SELECT * from Drink WHERE Id=@0", id).QuerySingle<Drink>();
        }

        public Order GetOrderById(int id)
        {
            return _dbContext.Sql("SELECT * from dbo.[Order] WHERE Id=@0", id).QuerySingle<Order>();
        }

        public List<Order> GetTodaysOrders()
        {
            return _dbContext.Sql("SELECT * from dbo.[Order] WHERE CreateDate >= DATEADD(day, DATEDIFF(day,0,GETDATE()),0) AND CreateDate < DATEADD(day, DATEDIFF(day,0,GETDATE())+1,0)").QueryMany<Order>();
        }

        public bool DeleteOrder(int id)
        {
            var rowsAffected = _dbContext.Delete("dbo.[Order]").Where("Id", id).Execute();

            return rowsAffected > 0;
        }

        public bool CreateOrder(int id)
        {
            var drink = GetDrinkById(id);

            if (drink == null) return false;

            var user = GetAllUsers().FirstOrDefault();

            if (user == null) return false;

            var order = new Order
                {
                    UserId = user.Id,
                    State = (int)Enums.OrderState.InQueue,
                    CreateDate = DateTime.Now,
                    DrinkId = id
                };

            order.Id = _dbContext.Insert("dbo.[Order]", order).AutoMap(x => x.Id).ExecuteReturnLastId<int>();

            return order.Id > 0;
        }
    }
}
