using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.Model
{
    public class Coordinate
    {
        public int X;
        public int Y;
        public Coordinate(int xcoord, int ycoord) 
        {
            X = xcoord;
            Y = ycoord;
        }
        public static int Compare(Coordinate a,Coordinate b) => (int)Math.Ceiling(Math.Sqrt(Math.Pow(a.X-b.X,2)+ Math.Pow(a.Y - b.Y, 2)));
       
    }
}
