using System;
using System.Collections.Generic;

namespace TreasureHunter2.Models
{
  public class Player
  {
    public List<Item> Items { get; set; } = new List<Item>();
    public string Name { get; set; }
    public Player(string name)
    {
      Name = name;







    }

  }


}