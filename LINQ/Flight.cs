using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ
{
    public class Flight
    {
        string flightNo;
        DateTime time;
        string destination;
        string gate;
        double price;

        public Flight()
        {

        }

        public Flight(string flightNo, DateTime time, string destination, string gate, double price)
        {
            this.flightNo = flightNo;
            this.time = time;
            this.destination = destination;
            this.gate = gate;
            this.price = price;
        }

        public string FlightNo { get => flightNo; set => flightNo = value; }
        public DateTime Time { get => time; set => time = value; }
        public string Destination { get => destination; set => destination = value; }
        public string Gate { get => gate; set => gate = value; }
        public double Price { get => price; set => price = value; }

        public string Airline()
        {
            string flightCode = this.flightNo.Substring(0, 2);
            string airline = "";
            switch (flightCode)
            {
                case "SA":
                    airline = "South African Airways";
                    break;
                case "JE":
                    airline = "Mango";
                    break;
                case "MN":
                    airline = "Kulula";
                    break;
                case "FA":
                    airline = "FlySafair";
                    break;
                case "BA":
                    airline = "British Airways";
                    break;
            }
            return airline;
        }

        public override string ToString()
        {
            string output;
            if (this.Destination.Length < 9)
                output = this.Time.ToShortDateString() + "\t" + this.FlightNo + "\t" + this.Destination + "\t\t R" + this.Price;
            else
                output = this.Time.ToShortDateString() + "\t" + this.FlightNo + "\t" + this.Destination + "\t R" + this.Price;

            return output;
        }
    }

}
