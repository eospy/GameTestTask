using Sample.Model;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Sample
{
    public class GameLogic
    {
        private static Random _random;
        const string chars = "abcdefghilklmnopqrstuvwxyz0123456789";
        public ConcurrentBag<Player> players;
        public ConcurrentBag<Vehicle> vehicles;
        int freevehicles;
        public int carscount;
        public int playerscount;
        public GameLogic(int cars, int playercount)
        {
            _random = new Random();
            carscount = cars;
            freevehicles = cars;
            playerscount = playercount;
            players = new ConcurrentBag<Player>();
            vehicles = new ConcurrentBag<Vehicle>();
        }
        //заполнение списков
        public void FillVehicles()
        {
            while (freevehicles > 0)
            {
                foreach (var car in vehicles)
                {
                    if (car.Passengers.Count > 2)
                    {
                        car.vehicleIsFull = true;
                        freevehicles--;
                    }
                    if (!car.vehicleIsFull)
                    {
                        foreach (var player in players)
                        {
                            if (player.Vehicle == null)
                            {
                                if (car.Driver == null)
                                {
                                    car.Driver = player;
                                    player.Vehicle = car;
                                    player.Coordinate = car.Coordinate;
                                }
                                else if (car.Passengers.Count < 3)
                                {
                                    car.Passengers.Add(player);
                                    player.Vehicle = car;
                                    player.Coordinate = car.Coordinate;
                                }

                            }
                        }
                    }
                }
            }

        }
        //создание списков
        public void FillLists()
        {
            for (int i = 0; i < playerscount; i++)
            {
                if (i < carscount)
                {
                    vehicles.Add(GenerateNewVehicle());
                }
                players.Add(GenerateNewPlayer());
            }

        }
        //игроки в окрестности
        public List<Player> GetPlayersAround(Player player)
        {
            List<Player> list = new();
            int x = player.Coordinate.X;
            int y = player.Coordinate.Y;
            return players.Where(p => Coordinate.Compare(player.Coordinate, p.Coordinate) < 15
                && p != player).ToList();
            Console.WriteLine();
        }
        public Vehicle GetRandomVehicle()
        {
            int index = _random.Next(vehicles.Count);
            return vehicles.ElementAt(index);
        }
        public Player GetRandomPlayer()
        {
            int index = _random.Next(players.Count);
            return players.ElementAt(index);
        }
        public static Coordinate GetRandomCoordinate()
        {
            return new Coordinate(_random.Next(100), _random.Next(100));
        }
        private static string GetRandomString(int length)
        {
            return new string(Enumerable.Repeat(chars, length).Select(s => s[_random.Next(s.Length)]).ToArray());
        }

        public static Player GenerateNewPlayer()
        {
            return new Player(GetRandomString(7), GetRandomCoordinate());
        }
        public static Vehicle GenerateNewVehicle()
        {
            return new Vehicle(GetRandomString(5), GetRandomCoordinate());
        }

    }
}
