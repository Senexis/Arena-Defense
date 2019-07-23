using System.Collections;
using System.Collections.Generic;

public abstract class BallisticWeapon : Weapon
{
    public float MaxClipSize { get; set; }
    public float CurrentClipSize { get; set; }
    public float FireRate { get; set; }
}