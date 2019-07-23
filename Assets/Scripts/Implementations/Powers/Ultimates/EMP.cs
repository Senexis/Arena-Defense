using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EMP : Power
{
    public EMP()
    {
        this.Type = PowerType.Ultimate;
        this.Cooldown = 500f; //TBD
    }

    public override void Activate()
    {
        throw new System.NotImplementedException();
    }
}