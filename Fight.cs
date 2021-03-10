using System;
using System.Collections.Generic;

namespace RPG
{
  class Fight
  {
    public bool IsFighting { get; set; }
    public bool UserIsWinner { get; set; }
    public Hero Hero { get; set; }
    public Monster Monster { get; set; }
    private bool IsUserTurn = new Random().Next(2) == 1;
    public Fight()
    {
      this.IsFighting = true;
    }
    public void TrackFight()
    {
      if (IsUserTurn)
      {
        this.Monster.CurrentHealth += this.Monster.Defense;
        this.Monster.CurrentHealth -= this.Hero.AttackDamage();

        if (CheckWinner() == 1)
        {
          this.UserIsWinner = true;
          IsFighting = false;

          Hero.CurrentHealth = Hero.OriginalHealth;
          Monster.CurrentHealth = Monster.OriginalHealth;

          System.Console.WriteLine("\u001b[38;5;76mYou win!!!\n\u001b[0m");
          System.Console.Write("    Press any key to go back to the main menu");

          Console.ReadKey();
          return;
        }

        System.Console.WriteLine($"{this.Monster.Name}'s current health {this.Monster.Defense - this.Hero.AttackDamage()} points.\n");
        System.Console.WriteLine("\u001b[7m{0, -10}{1, 15}\u001b[0m", "Hero: ", this.Hero.Name);
        System.Console.WriteLine("\u001b[7m{0, -10}{1, 5}\u001b[0m", "    Current Health: ", this.Hero.CurrentHealth);

        System.Console.WriteLine();

        System.Console.WriteLine($"Monster: {this.Monster.Name}");
        System.Console.WriteLine($"    Current Health: {this.Monster.CurrentHealth}");
        Console.ReadKey();

        IsUserTurn = !IsUserTurn;
      }
      else
      {
        this.Hero.CurrentHealth += this.Hero.Defense();
        this.Hero.CurrentHealth -= this.Monster.Strength;

        if (CheckWinner() == 0)
        {
          this.UserIsWinner = false;
          IsFighting = false;

          Hero.CurrentHealth = Hero.OriginalHealth;
          Monster.CurrentHealth = Monster.OriginalHealth;

          System.Console.WriteLine("\u001b[38;5;124mYou lose....\n\u001b[0m");
          System.Console.Write("    Press any key to go back to the main menu");

          Console.ReadKey();

          return;
        }

        System.Console.WriteLine($"Your current health {this.Hero.Defense() - this.Monster.Strength} points.\n");
        System.Console.WriteLine($"Hero: {this.Hero.Name}");
        System.Console.WriteLine($"    Current Health: {this.Hero.CurrentHealth}");

        System.Console.WriteLine();

        System.Console.WriteLine("\u001b[7m{0, -10}{1, 15}\u001b[0m", "Monster: ", this.Monster.Name);
        System.Console.WriteLine("\u001b[7m{0, -10}{1, 5}\u001b[0m", "    Current Health: ", this.Monster.CurrentHealth);

        Console.ReadKey();

        IsUserTurn = !IsUserTurn;
      }
    }
    public int CheckWinner()
    {
      if (Hero.CurrentHealth <= 0) return 0;
      else if (Monster.CurrentHealth <= 0) return 1;
      else return 2;
    }
  }
}