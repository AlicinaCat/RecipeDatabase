using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

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

        public List<Ingredient> GetIngredients()
        {
            List<Ingredient> ingredients = new List<Ingredient>();

            DBManager db = new DBManager("SELECT IngredientID, Name FROM Ingredient");
            DataTable table = db.ExecuteSQL();

            foreach (DataRow row in table.Rows)
            {
                Ingredient ingredient = new Ingredient();
                ingredient.Name = row.ItemArray[1].ToString();
                ingredient.IngredientID = (int)row.ItemArray[0];

                ingredients.Add(ingredient);
            }

            return ingredients;
        }

        public Ingredient FindIngredient(int id)
        {
            List<Ingredient> ingredients = GetIngredients();

            Ingredient query = (from i in ingredients
                              where i.IngredientID == id
                              select i).FirstOrDefault();

            return query;
        }
    }
}



//public List<Category> GetCategories()
//{
//    List<Category> categories = new List<Category>();

//    DBManager db = new DBManager("SELECT Name, CategoryID FROM Category");
//    DataTable table = db.ExecuteSQL();

//    foreach (DataRow row in table.Rows)
//    {
//        Category category = new Category();
//        category.Name = row.ItemArray[0].ToString();
//        category.CategoryID = (int)row.ItemArray[1];

//        categories.Add(category);
//    }

//    return categories;
//}

//public Category FindCategory(int id)
//{
//    List<Category> categories = GetCategories();

//    Category query = (from c in categories
//                      where c.CategoryID == id
//                      select c).FirstOrDefault();

//    return query;

//}