using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dash : Power
{
    public Dash()
    {
        this.Type = PowerType.Ability;
        this.Cooldown = 100f; //TBD
    }

    public override void Activate()
    {
        throw new System.NotImplementedException();
    }

}