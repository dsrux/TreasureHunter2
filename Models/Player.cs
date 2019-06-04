using System;
using System.Collections.Generic;

namespace TreasureHunter2.Models
{
  public class Player
  {
    public List<Item> Items { get; set; } = new List<Item>();
    public string Name { get; set; }
    public int PlayerHealth { get; set; } = 100;
    //Add int prospect for adding player health
    public Player(string name)
    {
      Name = name;

    }

  }


}