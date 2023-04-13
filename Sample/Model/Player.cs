using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.Model
{
    public class Player
    {
        public string Nickname;
        public Coordinate Coordinate;
        public Vehicle? Vehicle;
        public Player(string name, Coordinate coord)
        {
            Nickname =name;
            Coordinate = coord;
        }
    }
}
