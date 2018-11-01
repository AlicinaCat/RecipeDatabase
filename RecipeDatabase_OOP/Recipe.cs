using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace RecipeDatabase_OOP
{
    public class Recipe
    {
        public int RecipeID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public List<Ingredient> Ingredients { get; set; }
        public Category Category { get; set; }

        public Recipe()
        {
            Ingredients = new List<Ingredient>();
        }

        public List<Recipe> GetRecipes()
        {
            List<Recipe> recipes = new List<Recipe>();

            DBManager db = new DBManager("SELECT RecipeID, Title, Description, CategoryID FROM Recipe");
            DataTable table = db.ExecuteSQL();

            foreach (DataRow row in table.Rows)
            {
                Recipe recipe = new Recipe();
                recipe.RecipeID = (int)row.ItemArray[0];
                recipe.Title = row.ItemArray[1].ToString();
                recipe.Description = row.ItemArray[2].ToString();

                int categoryID = (int)row.ItemArray[3];

                Category category = new Category();
                recipe.Category = category.FindCategory(categoryID);
                recipe.Category.Recipes.Add(recipe);
                recipe.Ingredients = recipe.GetListOfIngredients();

                recipes.Add(recipe);
            }

            return recipes;
        }

        public List<Ingredient> GetListOfIngredients()
        {
            List<Ingredient> ingredientList = new List<Ingredient>();

            DBManager db = new DBManager("SELECT IngredientID FROM IngredientList WHERE RecipeID = " + RecipeID);
            DataTable table = db.ExecuteSQL();

            foreach (DataRow row in table.Rows)
            {
                int id = (int)row.ItemArray[0];

                Ingredient ingredient = new Ingredient();
                ingredient = ingredient.FindIngredient(id);

                ingredientList.Add(ingredient);
            }

            return ingredientList;
        }

        public void CreateNewRecipe(string title, string description, int categoryID)
        {
            DBManager db = new DBManager($"DECLARE @INSERTED TABLE(RecipeID int); INSERT INTO Recipe(Title, Description, CategoryID) " +
                                        $"OUTPUT INSERTED.RecipeId INTO @INSERTED VALUES('{title}', " +
                                        $"'{description}', {categoryID}); SELECT * FROM @INSERTED");
            int newRecipeID = db.ExecuteSQLScalar();
            CreateNewIngredientList(newRecipeID);

        }

        private void CreateNewIngredientList(int recipeID)
        {

            foreach (var item in Ingredients)
            {
                DBManager db = new DBManager($"INSERT INTO IngredientList(RecipeID, IngredientID) VALUES ({recipeID}, " +
                                             $"{item.IngredientID})");

                db.ExecuteSQLNoReturn();
            }
        }
    }
}