using System;
using System.Collections.Generic;

namespace RPG
{
  class Tui
  {
    public static int Option { get; set; }
    public static Hero Hero { get; set; }
    public static List<Monster> Monsters { get; set; }
    public static int FightCount = 0;
    public static int CountOfWon = 0;
    public static void SetHero()
    {
      Title();

      System.Console.WriteLine("Enter your name to start the game: ");

      string name = Console.ReadLine();

      if (!string.IsNullOrEmpty(name) && name.Trim() != "")
      {
        Hero = new Hero(name);
        InitMonsters();
        return;
      }
      else
      {
        System.Console.Write("\u001b[31mPlease enter an valid input!\u001b[0m");
        System.Console.ReadKey();
        SetHero();
      }
    }
    public static void InitMonsters()
    {
      Monsters = new List<Monster>();

      foreach (var monsterName in Monster.Monsters)
        Monsters.Add(new Monster(monsterName));
    }
    private static void Title()
    {
      Console.Clear();
      System.Console.WriteLine("   _____       __    ");
      System.Console.WriteLine("  / ___/____  / /___ ");
      System.Console.WriteLine("  \\__ \\/ __ \\/ / __ \\");
      System.Console.WriteLine(" ___/ / /_/ / / /_/ /");
      System.Console.WriteLine("/____/\\____/_/\\____/ ");
      System.Console.WriteLine();
    }
    public static void Mainmenu()
    {
      int curItem = 0, c;

      ConsoleKeyInfo key;

      string[] menuItems = { "Show Statistics", "Show Inventory", "Fight!", "Quit Game" };

      while (true)
      {
        Title();
        System.Console.WriteLine($"Hello, {Hero.Name}\n");

        for (c = 0; c < menuItems.Length; c++)
        {
          if (curItem == c)
          {
            Console.Write("\u001b[38;5;111m>  ");
            Console.WriteLine(menuItems[c] + " \u001b[0m");
            
            Option = curItem;
          }
          else
          {
            Console.Write("   ");
            Console.WriteLine(menuItems[c]);
          }
        }

        key = Console.ReadKey(true);

        if (key.Key.ToString() == "DownArrow")
        {
          curItem++;
          if (curItem > menuItems.Length - 1) curItem = 0;
        }
        else if (key.Key.ToString() == "UpArrow")
        {
          curItem--;
          if (curItem < 0) curItem = Convert.ToInt16(menuItems.Length - 1);
        }
        else if (key.Key.ToString() == "Enter")
        {
          break;
        }
      };
    }
    public static void ShowStatictics()
    {
      Title();

      System.Console.WriteLine($"Total:\n  {FightCount}\n\n");
      System.Console.WriteLine($"Won:\n  {CountOfWon}");

      System.Console.WriteLine();
      System.Console.Write("    [ b ] - back to main menu");
      var code = Console.ReadKey(true).KeyChar;

      if (code == 'b') Mainmenu();
      else ShowStatictics();
    }
    public static void ShowInventory()
    {
      Title();

      int curItem = 0, c;
      int curMenu = 0, m;

      ConsoleKeyInfo key;

      List<string> menuItems = new List<string>();
      List<string> weapons = new List<string>();
      List<string> armors = new List<string>();
      List<string> switchMenu = new List<string> { "Weapons", " Armors" };

      foreach (var weapon in Hero.WeaponsBag)
        weapons.Add(weapon.Name);

      foreach (var armor in Hero.ArmorsBag)
        armors.Add(armor.Name);

      menuItems = weapons;

      while (true)
      {
        Title();

        for (m = 0; m < switchMenu.Count; m++)
        {
          if (curMenu == m)
          {
            Console.Write("\u001b[38;5;79m" + switchMenu[m]);
            Console.Write(" [ o ] \u001b[0m");
          }
          else
          {
            Console.Write(switchMenu[m]);
            Console.Write(" [   ] ");
          }
        }

        System.Console.WriteLine("\n");

        for (c = 0; c < menuItems.Count; c++)
        {
          if (curItem == c)
          {
            if (Hero.EquippedWeapon.Name == menuItems[c])
            {
              Console.Write("\u001b[38;5;204m> ");
              Console.Write("* ");
              Console.WriteLine(menuItems[c] + "   pow -> " + Hero.FindWeaponByName(menuItems[c]).Power + "\u001b[0m");
            }
            else if (Hero.EquippedArmor.Name == menuItems[c])
            {
              Console.Write("\u001b[38;5;204m> ");
              Console.Write("* ");
              Console.WriteLine(menuItems[c] + "   pow -> " + Hero.FindArmorByName(menuItems[c]).Power + "\u001b[0m");
            }
            else
            {
              Console.Write("\u001b[38;5;111m>  ");
              Console.Write(menuItems[c]);
              if (curMenu == 0) System.Console.WriteLine("   pow -> " + Hero.FindWeaponByName(menuItems[c]).Power + "\u001b[0m");
              else if (curMenu == 1) System.Console.WriteLine("   pow -> " + Hero.FindArmorByName(menuItems[c]).Power + "\u001b[0m");
            }
          }
          else
          {
            if (Hero.EquippedWeapon.Name == menuItems[c])
            {
              Console.Write("\u001b[38;5;204m    ");
              Console.WriteLine(menuItems[c] + "   pow -> " + Hero.FindWeaponByName(menuItems[c]).Power + "\u001b[0m");
            }
            else if (Hero.EquippedArmor.Name == menuItems[c])
            {
              Console.Write("\u001b[38;5;204m    ");
              Console.WriteLine(menuItems[c] + "   pow -> " + Hero.FindArmorByName(menuItems[c]).Power + "\u001b[0m");
            }
            else
            {
              Console.Write("    ");
              Console.Write(menuItems[c]);
              if (curMenu == 0) System.Console.WriteLine("   pow -> " + Hero.FindWeaponByName(menuItems[c]).Power);
              else if (curMenu == 1) System.Console.WriteLine("   pow -> " + Hero.FindArmorByName(menuItems[c]).Power);
            }
          }
        }

        System.Console.WriteLine();
        System.Console.WriteLine("    [ enter ] - select item");
        System.Console.WriteLine("    [ b ] - back to main menu");
        System.Console.WriteLine("    [ ↑↓ ] - move selection");
        if (curMenu == 0) System.Console.WriteLine("    [ → ] - go to armors menu");
        else if (curMenu == 1) System.Console.WriteLine("    [ ← ] - go to weapons menu");
        
        key = Console.ReadKey(true);

        if (key.Key.ToString() == "DownArrow")
        {
          curItem++;
          if (curItem > menuItems.Count - 1) curItem = 0;
        }
        else if (key.Key.ToString() == "UpArrow")
        {
          curItem--;
          if (curItem < 0) curItem = Convert.ToInt16(menuItems.Count - 1);
        }
        else if (key.Key.ToString() == "RightArrow")
        {
          curMenu++;
          if (curMenu > switchMenu.Count - 1) curMenu = 1;
          menuItems = armors;
        }
        else if (key.Key.ToString() == "LeftArrow")
        {
          curMenu--;
          if (curMenu < 0) curMenu = 0;
          menuItems = weapons;
        }
        else if (key.Key.ToString() == "Enter")
        {
          if (curMenu == 0)
          {
            Hero.EquippedWeapon = Hero.FindWeaponByName(menuItems[curItem]);
          }
          else if (curMenu == 1)
          {
            Hero.EquippedArmor = Hero.FindArmorByName(menuItems[curItem]);
          }
        }   
        else if (key.Key.ToString() == "B")
        {
          Mainmenu();
          break;
        }
        else ShowInventory();
      };
    }
    public static void StartFight()
    {
      Fight newFight = new Fight();
      Monster monster = Monsters[new Random().Next(12)];

      newFight.Hero = Hero;
      newFight.Monster = monster;

      FightCount++;

      while (newFight.IsFighting)
      {
        Title();
        System.Console.WriteLine($"{newFight.Hero.Name} VS {newFight.Monster.Name}\n");

        newFight.TrackFight();
        if (newFight.UserIsWinner) CountOfWon++;

        if (newFight.IsFighting == false) Mainmenu();
      }
    }
  }
}