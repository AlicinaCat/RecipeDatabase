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

        public frmMain()
        {
            InitializeComponent();

            Recipes = new List<Recipe>();
            Recipe recipe = new Recipe();
            Recipes = recipe.GetRecipes();

            lstRecipes.DisplayMember = "Title";
            lstRecipes.ValueMember = "RecipeID";
            lstRecipes.DataSource = Recipes;
        }

        private void frmMain_Load(object sender, EventArgs e)
        {

        }

        private void lstRecipes_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cmdSearch_Click(object sender, EventArgs e)
        {

          

        }
    }
}
