using System;
using System.Collections.Generic;

namespace RPG
{
  class Weapon
  {
    public readonly static List<string> Weapons = new List<string>
    {
      "Crystalys",
      "Shadow Blade",
      "Nullifier",
      "Radiance",
      "Desolator",
      "Silver Edge",
      "Abyssal Blade",
      "Butterfly",
      "Daedalus",
      "Bloodthorn"
    };
    public string Name { get; set; }
    public int Power { get; set; }
    public Weapon(string name)
    {
      Name = name;
      Power = new Random().Next(5, 9);
    }
  }
}