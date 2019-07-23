using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Artifacting : Power
{
    public Artifacting()
    {
        this.Type = PowerType.Ability;
        this.Cooldown = 200f; //TBD
    }

    public override void Activate()
    {
        throw new System.NotImplementedException();
    }
}