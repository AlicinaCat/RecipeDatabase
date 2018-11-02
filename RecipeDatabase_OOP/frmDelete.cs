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
    public partial class frmDelete : Form
    {
        public Recipe Recipe { get; set; }

        public frmDelete(Recipe recipe)
        {
            InitializeComponent();

            Recipe = recipe;

            label1.Text = $"Are you sure you want to delete {Recipe.Title}? ";
        }

        private void label1_Click(object sender, EventArgs e)
        {
        }

        private void cmdNo_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void cmdYes_Click(object sender, EventArgs e)
        {
            MessageBox.Show($"{Recipe.Title} has been removed.");

            Recipe.DeleteRecipe();
            Close();
        }
    }
}
