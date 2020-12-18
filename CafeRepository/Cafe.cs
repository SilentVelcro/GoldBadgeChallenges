using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeRepository
{
    public class Cafe
    {
        //POCO
        public int MealNumber { get; set; }
        public string MealName { get; set; }
        public string Description { get; set; }
        public string Ingredinets { get; set; } 
        public double Price { get; set; }

        public Cafe() { }

        public Cafe(int mealNumber, string mealName,  string description, string ingredients, double price)
        {
            MealNumber = mealNumber;
            MealName = mealName;
            Description = description;
            Ingredinets = ingredients;
            Price = price;
        }
    }
}
