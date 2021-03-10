using System;
using System.Collections.Generic;

namespace RPG
{
  class Game
  {
    private bool start { get; set; }
    public Game()
    {
      this.start = true;
    }
    public void Start()
    {
      Tui.SetHero();
      Tui.Mainmenu();

      while (this.start)
      {
        if (Tui.Option == 0) Tui.ShowStatictics();
        else if (Tui.Option == 1) Tui.ShowInventory();
        else if (Tui.Option == 2) Tui.StartFight();
        else if (Tui.Option == 3) this.start = false;
      }

      Console.WriteLine("ending .... ");
    }
  }
}