using System;

using TreasureHunter2.Models;

namespace TreasureHunter2.Models
{
  class Program
  {
    static void Main(string[] args)

    {
      System.Console.WriteLine("Welcome to Treasurehunter ----A RuxCo Production");
      System.Console.WriteLine("press 'l' to Look");
      System.Console.WriteLine("press 'd' for room description");
      System.Console.WriteLine("press 'q' to quit");
      System.Console.WriteLine("press 'i' for inventory");
      System.Console.WriteLine("enter 'go + direction' = left, right, forward or back to go that direction");
      System.Console.WriteLine("press 't' to take items");
      Game TreasureHunter2 = new Game();
      TreasureHunter2.StartGame();
      while (TreasureHunter2.GameOver == false)
      {
        TreasureHunter2.Navigation();
        TreasureHunter2.WinningGame();

      }
      System.Console.WriteLine("Thanks for Playing");

    }
  }
}
