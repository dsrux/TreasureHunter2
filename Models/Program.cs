using System;

using TreasureHunter2.Models;

namespace TreasureHunter2.Models
{
  class Program
  {
    static void Main(string[] args)

    {
      System.Console.WriteLine("Welcome to Treasurehunter");
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
