using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Menu
{
    public partial class AddFood : Form
    {
        int SelectedIndex;
        // Creating and initialising a method that compares itemlist to the created object
        public AddFood(FoodItem pass, int selectedIndex)
        {
            InitializeComponent();
            txtName.Text = pass.ItemName.ToString();
            txtDescrip.Text = pass.Description;
            txtCost.Text = pass.CostPrice.ToString();
            txtSell.Text = pass.Price.ToString();
            txtFoodType.Text = pass.FoodType.ToString();
            txtCuisine.Text = pass.Cuisine.ToString();
            SelectedIndex = selectedIndex;
        }
        public AddFood()
        {
            InitializeComponent();
            SelectedIndex = -1;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {   // Different ways to clear the textBox
            txtName.Text = String.Empty;
            txtDescrip.Text = String.Empty;
            txtCost.Text = "";
            txtSell.Clear();
            txtCuisine.Clear();
            txtFoodType.Clear();

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                // Storing input values from the List of objects and passing it to the menu form for display
                FoodItem menuClass = new FoodItem(txtName.Text, txtDescrip.Text, Convert.ToDouble(txtSell.Text), Convert.ToDouble(txtCost.Text), txtFoodType.Text, txtCuisine.Text);

                MessageBox.Show("You have successfully added an Item to the menu");
                Menu form = new Menu();
                if (SelectedIndex == -1)
                {
                    //Adding
                    global::Menu.Menu.foodList.Add(menuClass);
                    try
                    {
                        // Writing to the text file
                        StreamWriter sw = new StreamWriter("Food.txt", true);
                        sw.WriteLine(menuClass.ItemName + "," + menuClass.Description + "," + menuClass.CostPrice + "," + menuClass.Price + "," + menuClass.FoodType + "," + menuClass.Cuisine);
                        sw.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                }
                else
                {
                    //Editing  
                    global::Menu.Menu.foodList.Remove(menuClass);
                    global::Menu.Menu.foodList[SelectedIndex] = menuClass;
                    try
                    {
                        StreamWriter sw = new StreamWriter("Food.txt");
                        foreach (FoodItem f in global::Menu.Menu.foodList)
                        {

                            sw.WriteLine(f.ItemName + "," + f.Description + "," + f.CostPrice + "," + f.Price + "," + f.FoodType + "," + f.Cuisine);
                        }
                        sw.Close();

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                }
                form.Show();
                this.Hide();
            }
            catch (Exception)
            {
                MessageBox.Show("Sorry, something Went Wrong !" + "\n" + "\n"
                    + "Enter A number for the Price and cost Price");

            }


        }




    }
}
