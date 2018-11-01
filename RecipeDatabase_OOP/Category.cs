using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace RecipeDatabase_OOP
{
    public class Category
    {
        public int CategoryID { get; set; }
        public string Name { get; set; }
        public List<Recipe> Recipes { get; set; }

        public Category()
        {
            Recipes = new List<Recipe>();
        }

        public Category(int categoryID, string name)
        {
            CategoryID = categoryID;
            Name = name;
            Recipes = new List<Recipe>();
        }

        public List<Category> GetCategories()
        {
            List<Category> categories = new List<Category>();

            DBManager db = new DBManager("SELECT Name, CategoryID FROM Category");
            DataTable table = db.ExecuteSQL();

            foreach (DataRow row in table.Rows)
            {
                Category category = new Category();
                category.Name = row.ItemArray[0].ToString();
                category.CategoryID = (int)row.ItemArray[1];

                categories.Add(category);
            }

            return categories;  
        }

        public Category FindCategory(int id)
        {
            List <Category> categories = GetCategories();

            Category query = (from c in categories
                        where c.CategoryID == id
                        select c).FirstOrDefault();

            return query;

        }
    }
}


//public List<Recipe> GetRecipes()
//{
//    List<Recipe> recipes = new List<Recipe>();

//    DBManager db = new DBManager("SELECT RecipeID, Title, Description, CategoryID FROM Recipe");
//    DataTable table = db.ExecuteSQL();

//    foreach (DataRow row in table.Rows)
//    {
//        Recipe recipe = new Recipe();
//        recipe.RecipeID = (int)row.ItemArray[0];
//        recipe.Title = row.ItemArray[1].ToString();
//        recipe.Description = row.ItemArray[2].ToString();
//        recipe.CategoryID = (int)row.ItemArray[3];

//        recipes.Add(recipe);
//    }

//    return recipes;
//}
//    }