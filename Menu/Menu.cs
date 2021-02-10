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
    public partial class Menu : Form
    {
        // Declaring of Lists of objects
        public static List<DrinkItem> drinkList = new List<DrinkItem>();
        public static List<FoodItem> foodList = new List<FoodItem>();


        public Menu()
        {
            InitializeComponent();
        }

        // Validating which item needs to be added to the Menu
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (radFood.Checked)
            {
                this.Hide();
                AddFood add1 = new AddFood();
                add1.ShowDialog();
            }
            else if (radDrink.Checked)
            {
                this.Hide();
                AddDrink add2 = new AddDrink();
                add2.ShowDialog();
            }
            else if (radDrink.Checked == false && radFood.Checked == false)
            {
                MessageBox.Show("Please Select the item you would like to Add !");
            }


        }

        private void MenuForm1_Load(object sender, EventArgs e)
        {
            fileReaderFood();
            fileReaderDrink();
        }



        private void btnDelete_Click(object sender, EventArgs e)
        {
            // working on

            try
            {
                // Deleting selected index from the Food Text file
                int count = -1;
                List<string> linesList = File.ReadAllLines("Food.txt").ToList();
                for (int i = 0; i < linesList.Count; i++)
                {
                    count++;
                    if (count == lbMeals.SelectedIndex)
                    {
                        linesList.RemoveAt(i);
                        lbMeals.Items.RemoveAt(lbMeals.SelectedIndex);
                    }

                }
                File.WriteAllLines("Food.txt", linesList.ToArray());

                // Deleting selected index from the Drink Text file
                int remove = -1;
                List<string> linesDrinkList = File.ReadAllLines("Drink.txt").ToList();
                for (int i = 0; i < linesDrinkList.Count; i++)
                {
                    remove++;
                    if (remove == lbDrinks.SelectedIndex)
                    {
                        linesDrinkList.RemoveAt(i);
                        lbDrinks.Items.RemoveAt(lbDrinks.SelectedIndex);
                    }

                }
                File.WriteAllLines("Drink.txt", linesDrinkList.ToArray());

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Please Select a food item you Wish to Delete from the List");
            }

        }

        // Passing the line to be updated to the respective form
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < foodList.Count; i++)
                {
                    if (lbMeals.SelectedIndex == i)
                    {
                        FoodItem foodItem = new FoodItem(foodList[i].ItemName, foodList[i].Description, foodList[i].Price, foodList[i].CostPrice, foodList[i].FoodType, foodList[i].Cuisine);

                        AddFood add = new AddFood(foodItem, lbMeals.SelectedIndex);
                        add.Show();
                        this.Hide();

                    }
                }
                for (int i = 0; i < drinkList.Count; i++)
                {
                    if (lbDrinks.SelectedIndex == i)
                    {
                        DrinkItem drinkItem = new DrinkItem(drinkList[i].ItemName, drinkList[i].Description, drinkList[i].Price, drinkList[i].CostPrice, drinkList[i].Container, drinkList[i].DrinkType);

                        AddDrink add = new AddDrink(drinkItem, lbDrinks.SelectedIndex);
                        add.Show();
                        this.Hide();

                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Please Select a food item you Wish to Update from the List");

            }


        }

        // Reading from the food text file and displaying each line in the listbox
        public void fileReaderFood()
        {
            foodList.Clear();
            string line;
            try
            {
                StreamReader file = new StreamReader("Food.txt");
                while ((line = file.ReadLine()) != null)
                {
                    string[] lineParts = line.Split(',');
                    FoodItem temp = new FoodItem(lineParts[0], lineParts[1], Convert.ToDouble(lineParts[2]), Convert.ToDouble(lineParts[3]), lineParts[4], lineParts[5]);
                    foodList.Add(temp);
                }
                file.Close();
            }
            catch (FileNotFoundException)
            {
                StreamReader sw = new StreamReader("Food.txt");
                sw.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            lbMeals.Items.Clear();
            for (int i = 0; i < foodList.Count; i++)
            {
                lbMeals.Items.Add(foodList[i].ItemName + " | " + foodList[i].Description + " |" + " ............................................. R" + foodList[i].Price);

            }

        }

        // Reading from the Drink text file and displaying each line in the listbox
        public void fileReaderDrink()
        {
            drinkList.Clear();
            string line;
            try
            {
                StreamReader dFile = new StreamReader("Drink.txt");
                while ((line = dFile.ReadLine()) != null)
                {
                    string[] lineParts = line.Split(',');
                    DrinkItem tp = new DrinkItem(lineParts[0], lineParts[1], Convert.ToDouble(lineParts[2]), Convert.ToDouble(lineParts[3]), lineParts[4], lineParts[5]);
                    drinkList.Add(tp);
                }
                dFile.Close();
            }
            catch (FileNotFoundException)
            {
                StreamReader dsw = new StreamReader("Drink.txt");
                dsw.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            lbDrinks.Items.Clear();
            for (int i = 0; i < drinkList.Count; i++)
            {
                lbDrinks.Items.Add(drinkList[i].ItemName + " | " + drinkList[i].Description + " |" + " ............................................. R" + drinkList[i].Price);
            }
        }


    }
}
