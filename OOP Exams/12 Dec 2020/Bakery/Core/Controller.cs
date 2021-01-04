using Bakery.Core.Contracts;
using Bakery.Models.BakedFoods;
using Bakery.Models.BakedFoods.Contracts;
using Bakery.Models.Drinks;
using Bakery.Models.Drinks.Contracts;
using Bakery.Models.Tables;
using Bakery.Models.Tables.Contracts;
using Bakery.Utilities.Enums;
using Bakery.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bakery.Core
{
    public class Controller : IController
    {
        private readonly ICollection<IBakedFood> bakedFoods;
        private readonly ICollection<IDrink> drinks;
        private readonly ICollection<ITable> tables;
        private decimal totalIncome;
        //private readonly ICollection<IBakedFood> totalOrderedFoods;
        //private readonly ICollection<IDrink> totalOrderedDrinks;
        public Controller()
        {
            this.bakedFoods = new List<IBakedFood>();
            this.drinks = new List<IDrink>();
            this.tables = new List<ITable>();
            this.totalIncome = 0m;
            //this.totalOrderedFoods = new List<IBakedFood>();
            //this.totalOrderedDrinks = new List<IDrink>();
        }

        public IReadOnlyCollection<IBakedFood> BakedFoods => this.bakedFoods.ToList().AsReadOnly();
        public IReadOnlyCollection<IDrink> Drinks => this.drinks.ToList().AsReadOnly();
        public IReadOnlyCollection<ITable> Tables => this.tables.ToList().AsReadOnly();
        //public IReadOnlyCollection<IBakedFood> TotalOrderedFoods => this.totalOrderedFoods.ToList().AsReadOnly();
        //public IReadOnlyCollection<IDrink> TotalOrderedDrinks => this.totalOrderedDrinks.ToList().AsReadOnly();

        public string AddFood(string type, string name, decimal price)
        {
            IBakedFood newFood = CheckIFFoodExistsAndCreateIt(type, name, price);

            this.bakedFoods.Add(newFood);
            return string.Format(OutputMessages.FoodAdded, name, type);

        }
        public string AddDrink(string type, string name, int portion, string brand)
        {
            IDrink newDrink = CheckIFDrinkExistsAndCreateIt(type, name, portion, brand);
            this.drinks.Add(newDrink);
            return string.Format(OutputMessages.DrinkAdded, name, brand);
        }


        public string AddTable(string type, int tableNumber, int capacity)
        {
            ITable newTable = CheckIFTableExistsAndCreateIt(type, tableNumber, capacity);
            this.tables.Add(newTable);
            return string.Format(OutputMessages.TableAdded, tableNumber);
        }

        public string ReserveTable(int numberOfPeople)
        {
            ITable currentTable = this.Tables.FirstOrDefault(t => !t.IsReserved && t.Capacity >= numberOfPeople);
            if (currentTable == null)
            {
                return string.Format(OutputMessages.ReservationNotPossible, numberOfPeople);
            }
            else
            {
                currentTable.Reserve(numberOfPeople);
                return string.Format(OutputMessages.TableReserved, currentTable.TableNumber, numberOfPeople);
            }
        }

        public string OrderFood(int tableNumber, string foodName)
        {
            ITable currentTable = this.Tables.FirstOrDefault(t => t.TableNumber == tableNumber);
            IBakedFood currentFood = this.BakedFoods.FirstOrDefault(f => f.Name == foodName);
            if (currentTable == null)
            {
                return string.Format(OutputMessages.WrongTableNumber, tableNumber);
            }
            if (currentFood == null)
            {
                return string.Format(OutputMessages.NonExistentFood, foodName);
            }

            currentTable.OrderFood(currentFood);
            //this.totalOrderedFoods.Add(currentFood);
            return string.Format(OutputMessages.FoodOrderSuccessful, currentTable.TableNumber, foodName);

        }

        public string OrderDrink(int tableNumber, string drinkName, string drinkBrand)
        {
            ITable currentTable = this.Tables.FirstOrDefault(t => t.TableNumber == tableNumber);
            IDrink currentDrink = this.Drinks.FirstOrDefault(d => d.Name == drinkName && d.Brand == drinkBrand);
            if (currentTable == null)
            {
                return string.Format(OutputMessages.WrongTableNumber, tableNumber);
            }
            if (currentDrink == null)
            {
                return string.Format(OutputMessages.NonExistentDrink, drinkName, drinkBrand);
            }

            currentTable.OrderDrink(currentDrink);
            //this.totalOrderedDrinks.Add(currentDrink);
            return string.Format(OutputMessages.DrinkOrderSuccessful, currentTable.TableNumber, drinkName, drinkBrand);
             
        }

        public string LeaveTable(int tableNumber)
        {
            ITable table = this.Tables.FirstOrDefault(t => t.TableNumber == tableNumber);
            StringBuilder sb = new StringBuilder();
            if (table != null)
            {
                decimal tableBill = table.GetBill();
                this.totalIncome += tableBill;

                table.Clear();
                sb.AppendLine($"Table: {tableNumber}")
                    .AppendLine($"Bill: {tableBill:f2}");
            }
            return sb.ToString().TrimEnd();

        }

        public string GetFreeTablesInfo()
        {
            var freeTables = this.Tables.Where(t => t.IsReserved == false).ToList();
            StringBuilder sb = new StringBuilder();
            foreach (var freeTable in freeTables)
            {
                sb.AppendLine(freeTable.GetFreeTableInfo());
            }
            return sb.ToString().TrimEnd();
        }

        public string GetTotalIncome()
        {
            //var totalIncome = this.TotalOrderedFoods.Select(f => f.Price).Sum() + this.TotalOrderedFoods.Select(d=>d.Price).Sum();
            return string.Format(OutputMessages.TotalIncome, this.totalIncome);
        }








        private static IBakedFood CheckIFFoodExistsAndCreateIt(string type, string name, decimal price)
        {
            Enum.TryParse(type, out BakedFoodType foodType);
            IBakedFood currentFood = null;
            switch (foodType)
            {
                case BakedFoodType.Bread:
                    currentFood = new Bread(name, price);
                    break;
                case BakedFoodType.Cake:
                    currentFood = new Cake(name, price);
                    break;

            }
            return currentFood;
        }

        private static IDrink CheckIFDrinkExistsAndCreateIt(string type, string name, int portion, string brand)
        {
            Enum.TryParse(type, out DrinkType drinkType);
            IDrink currentDrink = null;
            switch (drinkType)
            {
                case DrinkType.Tea:
                    currentDrink = new Tea(name, portion, brand);
                    break;
                case DrinkType.Water:
                    currentDrink = new Water(name, portion, brand);
                    break;
            }
            return currentDrink;
        }

        private static ITable CheckIFTableExistsAndCreateIt(string type, int tableNumber, int capacity)
        {
            Enum.TryParse(type, out TableType tableType);
            ITable currentTable = null;
            switch (tableType)
            {
                case TableType.InsideTable:
                    currentTable = new InsideTable(tableNumber, capacity);
                    break;
                case TableType.OutsideTable:
                    currentTable = new OutsideTable(tableNumber, capacity);
                    break;
            }
            return currentTable;
        }
    }
}
