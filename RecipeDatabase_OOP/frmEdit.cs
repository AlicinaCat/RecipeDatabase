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
    public partial class frmEdit : Form
    {
        public Recipe Recipe { get; set; }

        public frmEdit(Recipe recipe)
        {
            InitializeComponent();

            Recipe = recipe;

            txtTitle.Text = Recipe.Title;
            txtDescription.Text = Recipe.Description;

            LoadCategories();
            LoadIngredients();

            string catName = Recipe.Category.Name;
            int index = lstCategories.FindString(catName);
            lstCategories.SelectedIndex = index;

            //lstIngredientList.DisplayMember = "Name";
            //lstIngredientList.ValueMember = "IngredientID";
            //lstIngredientList.DataSource = Recipe.Ingredients;

            foreach (var item in Recipe.Ingredients)
            {
                lstIngredientList.Items.Add(item.Name);
            }

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

        private void frmEdit_Load(object sender, EventArgs e)
        {

        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void lstCategories_SelectedIndexChanged(object sender, EventArgs e)
        {

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
            Recipe.UpdateIngredientList(Recipe.RecipeID, query.IngredientID);

            lstIngredientList.Items.Add(query.Name);
        }

        private void cmdSave_Click(object sender, EventArgs e)
        {
            Recipe.UpdateRecipe(txtTitle.Text, txtDescription.Text, (int)lstCategories.SelectedValue);
            MessageBox.Show("Recipe updated!");
            Close();
        }

        private void lstIngredientList_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
