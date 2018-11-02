using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RecipeDatabase_OOP
{
    public partial class frmNew : Form
    {
        public List<Ingredient> IngredientList { get; set; }
        public Recipe Recipe { get; set; }

        public frmNew()
        {
            InitializeComponent();

            LoadCategories();
            LoadIngredients();
            //IngredientList = new List<Ingredient>();
            Recipe = new Recipe();
            
        }

        private void cmdSave_Click(object sender, EventArgs e)
        {
            Recipe.CreateNewRecipe(txtTitle.Text, txtDescription.Text, (int)lstCategories.SelectedValue);
            MessageBox.Show("Recipe saved!");
            Close();
            Application.Restart();
        }

        private void lstCategory_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void LoadCategories()
        {
            List<Category> categories = new List<Category>();
            Category category = new Category();
            categories = category.GetCategories();

            lstCategories.DisplayMember = "Name";
            lstCategories.ValueMember = "CategoryID";
            lstCategories.DataSource = categories;
        }

        private void LoadIngredients()
        {
            List<Ingredient> ingredients = new List<Ingredient>();
            Ingredient ingredient = new Ingredient();
            ingredients = ingredient.GetIngredients();

            lstIngredients.DisplayMember = "Name";
            lstIngredients.ValueMember = "IngredientID";
            lstIngredients.DataSource = ingredients;
        }

        private void cmdAdd_Click(object sender, EventArgs e)
        {
            List<Ingredient> ingredients = new List<Ingredient>();
            Ingredient ingredient = new Ingredient();
            ingredients = ingredient.GetIngredients();

            var query = (from i in ingredients
                         where i.IngredientID == (int)lstIngredients.SelectedValue
                         select i).SingleOrDefault();

            Recipe.Ingredients.Add(query);

            lstIngredientList.Items.Add(query.Name);

        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmNew_Load(object sender, EventArgs e)
        {

        }

        private void lstIngredients_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
