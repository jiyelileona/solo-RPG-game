using System;
using System.Collections.Generic;

namespace RPG
{
  class Monster
  {
    public static List<string> Monsters = new List<string>
    {
      "Gondar",
      "Traxex",
      "Razor",
      "Meepo",
      "Medusa",
      "Lanaya",
      "Ulfsaar",
      "Clinkz",
      "Nevermore",
      "Viper",
      "Mercurial",
      "Mortred"
    };
    public string Name { get; set; }
    public int Strength { get; set; }
    public int Defense { get; set; }
    public int OriginalHealth { get; set; }
    public int CurrentHealth { get; set; }
    public Monster(string name)
    {
      Random random = new Random();

      Name = name;
      Strength = random.Next(18, 22);
      Defense = random.Next(7, 11);
      OriginalHealth = 30;
      CurrentHealth = 30;
    }
  }
}