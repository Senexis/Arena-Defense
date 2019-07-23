using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Landmine : Power
{
    public Landmine()
    {
        this.Type = PowerType.Ability;
        this.Cooldown = 200f; //TBD
    }

    public override void Activate()
    {
        throw new System.NotImplementedException();
    }
}