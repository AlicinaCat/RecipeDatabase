using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace RecipeDatabase_OOP
{
    public partial class frmMain : Form
    {
        public List<Recipe> Recipes { get; set; }
        public List<Ingredient> Ingredients { get; set; }
        public List<Category> Categories { get; set; } 

        public frmMain()
        {
            InitializeComponent();

            LoadRecipes();
            LoadCategories();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {

        }

        private void lstRecipes_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id = (int)lstRecipes.SelectedValue;

            var query = (from r in Recipes
                         where r.RecipeID == id
                         select r).SingleOrDefault();

            txtDescription.Text = query.Description;
            txtCategory.Text = query.Category.Name;

            lstIngredients.DisplayMember = "Name";
            lstIngredients.DataSource = query.Ingredients;

        }

        private void cmdSearch_Click(object sender, EventArgs e)
        {
            string search = txtSearch.Text.ToLower();

            var query = from r in Recipes
                        where r.Title.ToLower().Contains(search) ||
                        r.Category.Name.ToLower().Contains(search)
                        select r;

            lstRecipes.DisplayMember = "Title";
            lstRecipes.ValueMember = "RecipeID";
            lstRecipes.DataSource = query.ToList();
        }

        private void LoadRecipes()
        {
            Recipes = new List<Recipe>();
            Recipe recipe = new Recipe();
            Recipes = recipe.GetRecipes();

            lstRecipes.DisplayMember = "Title";
            lstRecipes.ValueMember = "RecipeID";
            lstRecipes.DataSource = Recipes;
        }

        private void LoadCategories()
        {
            Categories = new List<Category>();
            Category category = new Category();
            Categories = category.GetCategories();

            //lstRecipes.DisplayMember = "Title";
            //lstRecipes.ValueMember = "RecipeID";
            //lstRecipes.DataSource = Recipes;
        }
    }
}
