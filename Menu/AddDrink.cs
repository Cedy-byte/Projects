using System;
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
    public partial class AddDrink : Form
    {
        int SelectedIndex;
        public AddDrink(DrinkItem pass, int selectedIndex)
        {
            InitializeComponent();
            txtName.Text = pass.ItemName.ToString();
            txtDescrip.Text = pass.Description;
            txtCost.Text = pass.CostPrice.ToString();
            txtSell.Text = pass.Price.ToString();
            txtContType.Text = pass.Container.ToString();
            txtDrinkType.Text = pass.DrinkType.ToString();
            SelectedIndex = selectedIndex;
        }


        public AddDrink()
        {
            InitializeComponent();
            SelectedIndex = -1;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtName.Text = String.Empty;
            txtDescrip.Text = String.Empty;
            txtCost.Text = "";
            txtSell.Clear();
            txtContType.Clear();
            txtDrinkType.Clear();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                string name = txtName.Text;
                string desc = txtDescrip.Text;
                double sell = Convert.ToDouble(txtSell.Text);
                double cost = Convert.ToDouble(txtCost.Text);
                string cont = txtContType.Text;
                string type = txtDrinkType.Text;


                DrinkItem menu = new DrinkItem(name, desc, sell, cost, cont, type);
                MessageBox.Show("You have successfully added an Item to the menu");
                Menu form = new Menu();
                if (SelectedIndex == -1)
                {
                    //Adding
                    global::Menu.Menu.drinkList.Add(menu);
                    try
                    {
                        // Writing to the text file
                        StreamWriter sw = new StreamWriter("Drink.txt", true);
                        sw.WriteLine(menu.ItemName + "," + menu.Description + "," + menu.CostPrice + "," + menu.Price + "," + menu.Container + "," + menu.DrinkType);
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
                    global::Menu.Menu.drinkList.Remove(menu);
                    global::Menu.Menu.drinkList[SelectedIndex] = menu;
                    try
                    {
                        // Writing to the text file
                        StreamWriter sw = new StreamWriter("Drink.txt");
                        foreach (DrinkItem d in global::Menu.Menu.drinkList)
                        {
                            sw.WriteLine(d.ItemName + "," + d.Description + "," + d.CostPrice + "," + d.Price + "," + d.Container + "," + d.DrinkType);
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
