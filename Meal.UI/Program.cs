using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Meal.UI
{
    //this page is necessary and needs to be separated from other program
    //this is where all console apps start
    class Program
    {
        static void Main(string[] args)
        {
            MealProgram mealProgram = new MealProgram();
            mealProgram.Run();
        }
    }
}
