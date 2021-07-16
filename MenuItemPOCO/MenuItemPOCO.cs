using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MealClass.POCO
{
    public class MenuItemPOCO
    {
        public decimal MealNumber { get; set; }
        public string MealName { get; set; }
        public string MealDescription { get; set; }
        public decimal MealPrice { get; set; }
        //public List<Ingredients> MealList { get; set; } = new List<Ingredients>();
        public string MealIngredientList { get; set; }

        public MenuItemPOCO() { }

        public MenuItemPOCO(int mealNumber, string mealName, string mealDescription, decimal mealPrice, string mealIngredientList) 
                      //List<Ingredients> mealList)
        {
            MealNumber = mealNumber;
            MealName = mealName;
            MealDescription = mealDescription;
            MealPrice = mealPrice;
            MealIngredientList = mealIngredientList;
        //    MealList = mealList;
        }
    }
}
