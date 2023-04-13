using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.Model
{
    public class Vehicle
    {
        public string Name;
        public Coordinate Coordinate;
        public Player? Driver;
        public List<Player> Passengers;
        public bool vehicleIsFull = false;
        public Vehicle(string name, Coordinate coord)
        {
            Name = name;
            Passengers = new List<Player>(capacity: 3);
            Coordinate = coord;
        }
    }
}
