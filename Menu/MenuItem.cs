using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Menu
{
    public abstract class MenuItem
    {
        // Variable Declaration
        protected string itemName;
        protected string description;
        protected double price;
        protected double costPrice;

        // Parent class constructor
        public MenuItem(string itemName, string description, double price, double costPrice)
        {
            this.ItemName = itemName;
            this.Description = description;
            this.Price = price;
            this.CostPrice = costPrice;
        }
        // Getters and Setters
        public string ItemName { get => itemName; set => itemName = value; }
        public string Description { get => description; set => description = value; }
        public double Price { get => price; set => price = value; }
        public double CostPrice { get => costPrice; set => costPrice = value; }

    }
}
