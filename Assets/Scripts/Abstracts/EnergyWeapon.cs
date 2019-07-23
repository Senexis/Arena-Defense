using System.Collections;
using System.Collections.Generic;

public abstract class EnergyWeapon : Weapon
{
    public float MaxCharge { get; set; }
    public float CurrentCharge { get; set; }
    public int FireRate { get; set; }
}