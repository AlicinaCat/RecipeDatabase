using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeDatabase_OOP
{
    public class Ingredient
    {
        public int IngredientID { get; set; }
        public string Name { get; set; }

        public Ingredient()
        {

        }

        public Ingredient(int ingredientID, string name)
        {
            IngredientID = ingredientID;
            Name = name;
        }


    }
}
