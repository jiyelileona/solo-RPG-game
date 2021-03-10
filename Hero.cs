using System;
using System.Collections.Generic;

namespace RPG
{
  class Hero
  {
    public string Name { get; set; }
    public int BaseStrength { get; set; }
    public int BaseDefense { get; set; }
    public int OriginalHealth { get; set; }
    public int CurrentHealth { get; set; }
    public Weapon EquippedWeapon { get; set; }
    public Armor EquippedArmor { get; set; }
    public List<Weapon> WeaponsBag { get; set; }
    public List<Armor> ArmorsBag { get; set; }
    public Hero(string name)
    {
      Random random = new Random();

      Name = name;

      BaseStrength = random.Next(8, 11);
      BaseDefense = random.Next(10, 12);

      OriginalHealth = 40;
      CurrentHealth = 40;

      WeaponsBag = new List<Weapon>();
      ArmorsBag = new List<Armor>();

      this.InitWeaponArmorBag();

      EquippedWeapon = WeaponsBag[0];
      EquippedArmor = ArmorsBag[0];
    }
    private void InitWeaponArmorBag()
    {
      Random random = new Random();

      HashSet<int> numbers = new HashSet<int>();

      while (numbers.Count < 5)
        numbers.Add(random.Next(0, 9));

      foreach (var num in numbers)
      {
        Weapon randomWeapon = new Weapon(Weapon.Weapons[num]);
        Armor randomArmor = new Armor(Armor.Armors[num]);

        this.WeaponsBag.Add(randomWeapon);
        this.ArmorsBag.Add(randomArmor);
      }
    }
    public Weapon FindWeaponByName(string name)
    {
      int index = 0;

      for (int i = 0; i < this.WeaponsBag.Count; i++)
        if (this.WeaponsBag[i].Name == name) index = i;

      return this.WeaponsBag[index];
    }
    public Armor FindArmorByName(string name)
    {
      int index = 0;

      for (int i = 0; i < this.ArmorsBag.Count; i++)
        if (this.ArmorsBag[i].Name == name) index = i;

      return this.ArmorsBag[index];
    }
    public int AttackDamage()
    {
      return this.EquippedWeapon.Power + this.BaseStrength;
    }
    public int Defense()
    {
      return this.EquippedArmor.Power + this.BaseDefense;
    }
  }
}