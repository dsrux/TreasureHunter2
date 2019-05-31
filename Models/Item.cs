using System;

namespace TreasureHunter2.Models
{
  public class Item
  {
    public string Name { get; set; }
    public string Description { get; set; }

    public Item(string name, bool PickupItem, string description)
    {

      Name = name;
      Description = description;
      PickupItem = true;





    }


  }


}


