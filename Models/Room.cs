using System;
using System.Collections.Generic;

namespace TreasureHunter2.Models
{
  public class Room
  {
    public string RoomsName { get; set; }
    public string RoomsDescription { get; set; }
    // public string CurrentRoom { get; set; }
    public List<Item> Inventory { get; set; }
    public Dictionary<string, Room> Exits { get; set; } = new Dictionary<string, Room>();
    public Move AllDirections { get; set; }






    public Room(string roomsname, string roomsdescription, bool isloseable = true)
    {
      RoomsDescription = roomsdescription;


      RoomsName = roomsname;
      Inventory = new List<Item>();
      //TODO make an exits Dictionary here
      Exits = Exits;

    }
  }
}