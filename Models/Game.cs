using System;
using System.Collections.Generic;
using System.Linq;

namespace TreasureHunter2.Models
{
  public class Game
  {
    public Player MyPlayer { get; set; }
    public Room CurrentRoom { get; set; }
    public Move AllDirections { get; set; }
    public string RoomsName { get; set; }
    public string Description { get; set; }

    public Item ItemName { get; set; }
    private List<Item> Inventory;

    public bool GameOver = false;


    public Game()
    {

      System.Console.WriteLine("-------Welcome to Treasure Hunter------");

      Inventory = new List<Item>();
      Room TaxationStation = new Room("TaxationStation", "You walk into a room, the sound of fingers rhythmically beating typewriters clouding out all sounds of you walking, suddenly.....silence.  You are late on your taxes sir, you have 13 days to pay, you notice there's only one way into the room and the workers are chained to the tables, you notice behind them there's an open door", false);
      Room HeavensGate = new Room("HeavensGate", "A bright white room lights up in front of you.  In the middle of the room is a golden key and a beautifully endowed bowl filled with a purple substance you believe is Kool Aid.  Upon gazing into the room, saliva bites at your teeth, it's been a long day and you are very thirsty");
      Room Bedroom = new Room("Bedroom", "You were so sleepy, this was the first night you've gotten any rest as you've fervently spent every night studying C# as if it was ancient hyroglyphics with the universes answers inside.  You situp petting your dog and only social contact in life Nibbles as he lie passed out as if he actually worked or did anything but beg for your food then musk you in his comforted slumber, you reach to your inn table, drinking from your quarter mountain dew......cigarette butt.  Mother has been smoking next to your bed as she watched you sleep yet again against your fairer wishes.  You look around.....this isn't home?", false);
      Room Haven = new Room("Haven", " a room, you see a window that sheens of moving water, through it you can see blue sky, your dog Nibbles.  It's HOME!!  You've made it HOME!! Mother was right you never should have left her sight, Mother was always right", false);
      Room KeyBank = new Room("KeyBank", "You enter a room, there's keys everywhere, in the middle of the room you see something, a bottle with Nibbles picture on it.  You have a deep sense of trust, IT'S MOUNTAIN DEW!!  Nibbles must know i'm lost and he's helping", false);
      Room Hallway = new Room("Hallway", "You walk into a dark musty hallway, it breaks into 4 directions: Forward, Left, Right and back, 'how did I get here? you wondered, this isn't Kansas'", false);

      Item Dew = new Item("Mountain Dew!", true, "Savagely you tip the can putting away 12 ounces of sugary wonder in no time at all");
      Item KoolAid = new Item("Kool Aid", true, "You taste the delicious Kool Aid, it is refreshing and you feel much stronger");
      Bedroom.Inventory.Add(Dew);
      HeavensGate.Inventory.Add(KoolAid);
      KeyBank.Inventory.Add(Dew);
      TaxationStation.Exits.Add("forward", HeavensGate);
      TaxationStation.Exits.Add("left", Bedroom);
      TaxationStation.Exits.Add("right", KeyBank);
      TaxationStation.Exits.Add("back", Hallway);
      HeavensGate.Exits.Add("left", TaxationStation);
      HeavensGate.Exits.Add("forward", Bedroom);
      HeavensGate.Exits.Add("right", Hallway);
      HeavensGate.Exits.Add("back", Hallway);
      Bedroom.Exits.Add("back", HeavensGate);
      Bedroom.Exits.Add("forward", TaxationStation);
      Bedroom.Exits.Add("right", Hallway);
      Bedroom.Exits.Add("left", Hallway);
      KeyBank.Exits.Add("right", Haven);
      Hallway.Exits.Add("left", HeavensGate);
      Hallway.Exits.Add("forward", TaxationStation);
      Hallway.Exits.Add("back", Bedroom);
      Hallway.Exits.Add("right", KeyBank);
      //If current is ever Haven invoke EndGame

      System.Console.WriteLine("Enter you Name");
      string userInput = Console.ReadLine();
      MyPlayer = new Player(userInput);
      CurrentRoom = Bedroom;





    }
    public void StartGame()
    {
      System.Console.WriteLine($"Your current Room is {CurrentRoom.RoomsName}");
      System.Console.WriteLine($"{CurrentRoom.RoomsDescription}");
      if (CurrentRoom.Inventory.Count > 0)
      {
        System.Console.WriteLine("The Room has ");
        for (int i = 0; i < CurrentRoom.Inventory.Count; i++)
        {
          System.Console.WriteLine($"{CurrentRoom.Inventory[i].Name}");
        }

      }
    }
    public void ShowInventory()
    {
      foreach (Item item in MyPlayer.Items)

      {

        System.Console.WriteLine($"You currently have {item.Name}");
      }
      return;



    }
    public void Navigation()
    {
      //This method needs to all user to put in input, needs to check input for command and option, based on command pass along to another method
      string userInput = Console.ReadLine();
      string[] UserInputArray = userInput.Split(' ');
      string command = UserInputArray[0];
      string option = "";
      if (UserInputArray.Length > 1)
      {
        option = UserInputArray[1];
      }
      switch (command)
      {
        case "help":
        case "h":

          System.Console.WriteLine("-----------------------------------HELP------------------------------------------------------");
          System.Console.WriteLine("press 'l' to Look");
          System.Console.WriteLine("press 'd' for room description");
          System.Console.WriteLine("press 'q' to quit");
          System.Console.WriteLine("press 'i' for inventory");
          System.Console.WriteLine("enter 'go + direction' = left, right, forward or back to go that direction");
          System.Console.WriteLine("press 't' to take items");
          System.Console.WriteLine("=============================================================================================");
          break;
        case "l":
        case "look":
        case "d":
        case "description":
          System.Console.WriteLine($" {CurrentRoom.RoomsDescription}");
          break;
        case "q":
        case "quit":
          GameOver = true;
          break;

        case "g":
        case "go":
          RoomNavigation(option);
          break;

        case "t":
        case "take":
          TakeItem();
          break;
        default:
          System.Console.WriteLine("bad input");
          break;

        case "i":
        case "inventory":
          ShowInventory();
          return;
      }

    }
    public void TakeItem()
    {
      if (CurrentRoom.RoomsName == "Bedroom" || "HeavensGate" == CurrentRoom.RoomsName)
      {
        Item item = CurrentRoom.Inventory[0];
        CurrentRoom.Inventory.Remove(item);
        MyPlayer.Items.Add(item);
        System.Console.WriteLine($"You took {item.Name} ");
        if (item.Name == "Dew")
        {
          GameOver = true;
          System.Console.WriteLine(" Mountain Dew is bad for you, diabetes sets in, start over and try to make better life decisions");
        }
        else if (item.Name == "KoolAid")
        {
          MyPlayer.Items.Add(item);
          CurrentRoom.Inventory.Remove(item);
          GameOver = false;
          System.Console.WriteLine($"You got {item.Name}feel refreshed");

        }
      }
    }
    public void RoomNavigation(string direction)
    {
      if (CurrentRoom.Exits.ContainsKey(direction))
      {
        CurrentRoom = CurrentRoom.Exits[direction];
        System.Console.WriteLine($"You entered {CurrentRoom.RoomsName} you see {CurrentRoom.RoomsDescription}");

      }
      else
      {
        System.Console.WriteLine("This current direction is blocked choose another");
      }
    }



    public void WinningGame()
    {
      if (CurrentRoom.RoomsName == "Haven")
      {
        System.Console.WriteLine($"Congratulations you've made it to Haven! {MyPlayer.Name} has won the game ");
        GameOver = true;
      }

    }
  }
}



