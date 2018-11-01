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
        public int CategoryID { get; set; }

        public Recipe()
        {

        }

        public Recipe(int recipeID, string title, string description, Category category)
        {
            RecipeID = recipeID;
            Title = title;
            Description = description;
            Ingredients = new List<Ingredient>();
            //Category = category;
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
                recipe.CategoryID = (int)row.ItemArray[3];

                recipes.Add(recipe);
            }

            return recipes;
        }
    }
}

//public List<Kund> GetAllCustomers()
//{
//    List<Kund> kunder = new List<Kund>();

//    DBManager db = new DBManager("SELECT KundID, Namn, adress,email FROM Kund");
//    DataTable tbl = db.ExecuteSQL();

//    //Loopar igenom alla rader i svaret
//    foreach (DataRow row in tbl.Rows)
//    {
//        Kund kund = new Kund();
//        kund.KundID = (int)row.ItemArray[0];
//        kund.Namn = row.ItemArray[1].ToString();
//        kund.Adress = row.ItemArray[2].ToString();
//        kund.Email = row.ItemArray[3].ToString();

//        kunder.Add(kund);
//    }
//    return kunder;
//}
