using Sample.Model;
using System;
using System.Diagnostics;
using System.Threading;

namespace Sample
{
    public class Program
    {
        static void Main(string[] args)
        {
            GameLogic gameLogic = new(200,1000);
            Thread thread1 = new (gameLogic.FillLists);
            Thread thread2 = new (gameLogic.FillVehicles);
            thread1.Start();
            thread2.Start();
            thread1.Join();
            thread2.Join();

            //информация о 5 случайных автомобилях
            for(int i = 0; i < 5; i++)
            {
                var car =gameLogic.GetRandomVehicle();
                string[] passengers = new string[car.Passengers.Count];
                for(int j=0;j< car.Passengers.Count; j++) passengers[j] = car.Passengers[j].Nickname;
                Console.WriteLine
                    (
                    "Car Name= " + car.Name +
                    "Car driver " + car.Driver.Nickname +
                    "Car passengers " +
                    string.Join(" ", passengers) +
                    "Coord.X=" + car.Coordinate.X +
                    " Coord Y= " + car.Coordinate.Y
                    ) ;
                
            }
            //случайный игрок
            var player = gameLogic.GetRandomPlayer();
            Console.WriteLine("Player "+player.Nickname + " at Coord.X= " +
                      player.Coordinate.X +
                      " Coord.Y " +
                      player.Coordinate.Y);
            //игроки в радиусе 15 от игрока
            var playersAround = gameLogic.GetPlayersAround(player);
            foreach (var p in playersAround)
            {
                Console.WriteLine(p.Nickname + " : " + Coordinate.Compare(player.Coordinate, p.Coordinate));
               
            }
        }
    }
}