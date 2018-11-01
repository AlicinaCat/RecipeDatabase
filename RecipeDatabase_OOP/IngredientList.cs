using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeDatabase_OOP
{
    class IngredientList
    {
        public int IngredientID { get; set; }
        public int RecipeID { get; set; }

        public IngredientList(int ingredientID, int recipeID)
        {
            IngredientID = ingredientID;
            RecipeID = recipeID;
        }
    }
}
