using Bakery.Models.BakedFoods.Contracts;
using Bakery.Models.Drinks.Contracts;
using Bakery.Models.Tables.Contracts;
using Bakery.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bakery.Models.Tables
{
    public abstract class Table : ITable
    {
        private ICollection<IBakedFood> foodOrders;
        private ICollection<IDrink> drinkOrders;

        private int capacity;
        private int numberOfPeople;

        public Table(int tableNumber, int capacity, decimal pricePerPerson)
        {
            this.foodOrders = new List<IBakedFood>();
            this.drinkOrders = new List<IDrink>();
 
            this.TableNumber = tableNumber;
            this.Capacity = capacity;
            this.PricePerPerson = pricePerPerson;
            }

        public IReadOnlyCollection<IBakedFood> FoodOrders => this.foodOrders.ToList().AsReadOnly();
        public IReadOnlyCollection<IDrink> DrinkOrders => this.drinkOrders.ToList().AsReadOnly();
        public int TableNumber { get; }

        public int Capacity
        {
            get => this.capacity;
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidTableCapacity);
                }
                this.capacity = value;
            }
        }

        public int NumberOfPeople
        {
            get => this.numberOfPeople;
            protected set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidNumberOfPeople);
                }
                this.numberOfPeople = value;
            }
        }

        public decimal PricePerPerson { get; }

        public bool IsReserved { get; protected set; }

        public decimal Price => this.NumberOfPeople * this.PricePerPerson;

     
        public void Clear()
        {
            this.drinkOrders.Clear();
            this.foodOrders.Clear();
            this.IsReserved = false;
            this.numberOfPeople = 0;
        }


        public decimal GetBill()
        {
            decimal total = this.Price + this.FoodOrders.Sum(f => f.Price) + this.DrinkOrders.Sum(d => d.Price);
            return total;
        }


        public string GetFreeTableInfo()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Table: {this.TableNumber}")
                .AppendLine($"Type: {this.GetType().Name}")
                .AppendLine($"Capacity: {this.Capacity}")
                .AppendLine($"Price per Person: {this.PricePerPerson}");

            return sb.ToString().TrimEnd();
        }

        public void OrderDrink(IDrink drink)
        {
            if (DrinkExists(drink))
            {
                this.drinkOrders.Add(drink);
            }
        }

        public void OrderFood(IBakedFood food)
        {
            if (FoodExists(food))
            {
                this.foodOrders.Add(food);
            }
        }

        public void Reserve(int numberOfPeople)
        {
            this.NumberOfPeople = numberOfPeople;
            this.IsReserved = true;
        }

        private bool FoodExists(IBakedFood food)
        {
            if (food.GetType().Name == "Bread" || food.GetType().Name == "Cake")
            {
                return true;
            }
            return false;
        }
        private bool DrinkExists(IDrink drink)
        {
            if (drink.GetType().Name == "Tea" || drink.GetType().Name == "Water")
            {
                return true;
            }
            return false;
        }
    }
}
