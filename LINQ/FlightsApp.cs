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

namespace LINQ
{
    public partial class FlightsApp : Form
    {
        List<Flight> allFlights = new List<Flight>();
        List<Flight> filtered;

        public FlightsApp()
        {
            InitializeComponent();
        }

        private void FlightsApp_Load(object sender, EventArgs e)
        {
            lblAirline.Visible = false;
            lblDestination.Visible = false;

            cmbAirline.Visible = false;
            cmbDestination.Visible = false;

            try
            {
                StreamReader file = new StreamReader("Flights.txt");
                string line;

                while ((line = file.ReadLine()) != null)
                {
                    var lineParts = line.Split(',');
                    string flightNo = lineParts[0];
                    DateTime time = new DateTime(DateTime.Today.Year,DateTime.Today.Month,DateTime.Today.Day,Convert.ToInt32(lineParts[1].Split(':')[0]), Convert.ToInt32(lineParts[1].Split(':')[1]),0);
                    string destination = lineParts[2];
                    string gate = lineParts[3];
                    double price = Convert.ToDouble(lineParts[4]);

                    Flight temp = new Flight(flightNo,time,destination,gate,price);
                    allFlights.Add(temp);


                }
                file.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            lbFlights.Items.Clear();
            foreach (Flight f in allFlights)
            {
                lbFlights.Items.Add(f.ToString());
            }
            #region comboboxes
            foreach (Flight f in allFlights)
            {
                if (!cmbAirline.Items.Contains(f.Airline()))
                {
                    cmbAirline.Items.Add(f.Airline());
                }
                cmbAirline.Sorted = true;
            }

            foreach (Flight f in allFlights.Distinct())
            {
                if (!cmbDestination.Items.Contains(f.Destination))
                {
                    cmbDestination.Items.Add(f.Destination);
                }
                cmbDestination.Sorted = true;
            }
            #endregion
        }

        private void cmbCondition_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbCondition.SelectedItem.ToString() == "Choose own airline and destination")
            {
                lblAirline.Visible = true;
                lblDestination.Visible = true;

                cmbAirline.Visible = true;
                cmbDestination.Visible = true;
            }
            else
            {
                lblAirline.Visible = false;
                lblDestination.Visible = false;

                cmbAirline.Visible = false;
                cmbDestination.Visible = false;
            }
           
        }

        private void btnPass_Click(object sender, EventArgs e)
        {
            lbResults.Items.Clear();
            if (cmbCondition.SelectedItem !=null)
            {
                string option = cmbCondition.SelectedItem.ToString();

                switch (option)
                {
                    case "Flights to Cape Town , ordered in alphabetical order of airlines":
                        // Method syntaxs
                        filtered = allFlights.Where(f => f.Destination.Equals("Cape Town")).OrderBy(fn => fn.FlightNo).ToList();
                        // Query Syntax
                        #region querysyntax
                        //filtered = (from f in allFlights
                        //            where (f.Destination == "Cape Town")
                        //            orderby f.FlightNo
                        //            select f).ToList();
                        #endregion
                        break;
                    case "Flight departing from Gate A11, ordered by departure time":
                        filtered = allFlights.Where(f => f.Gate.Equals("A11")).OrderBy(d => d.Time).ToList();
                        #region querysyntax
                        //filtered = (from f in allFlights
                        //            where (f.Gate == "A11")
                        //            orderby f.Time
                        //            select f).ToList();
                        #endregion
                        break;
                    case "Flights to Johannesburg which cost less than R600 , ordered by price (ascending)":
                        filtered = allFlights.Where(f => f.Price < 600 && f.Destination == "Johannesburg").OrderBy(fn => fn.Price).ToList();
                        #region querysyntax
                        //filtered = (from f in allFlights
                        //            where (f.Price < 600 && f.Destination == "Johannesburg")
                        //            orderby f.Price
                        //            select f).ToList();
                        #endregion
                        break;
                    case "Choose own airline and destination":
                        if (cmbAirline.SelectedItem != null && cmbDestination.SelectedItem != null)
                        {
                            filtered = allFlights.Where(f => f.Airline().Equals(cmbAirline.SelectedItem) 
                                                        && f.Destination.Equals(cmbDestination.SelectedItem)).ToList();
                            #region querysyntax
                            //filtered = (from f in allFlights
                            //            where (f.Airline() == cmbAirline.SelectedItem.ToString() && f.Destination == cmbDestination.SelectedItem.ToString())
                            //            orderby f.Time
                            //            select f).ToList();
                            #endregion

                        }
                        break;
                }
                foreach (Flight f in filtered)
                {
                    lbResults.Items.Add(f.ToString());
                }

            }
            
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            lbResults.Items.Clear();
            lblAirline.Visible = false;
            lblDestination.Visible = false;

            cmbAirline.Visible = false;
            cmbDestination.Visible = false;
        }

       
    }
}
