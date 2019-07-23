using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeslaCoil : Power
{
    public TeslaCoil()
    {
        this.Type = PowerType.Ability;
        this.Cooldown = 100f; //TBD
    }

    public override void Activate()
    {
        if (currentTimeForCooldown >= Cooldown)
        {
            GameObject newPlaceable = Instantiate((GameObject)Resources.Load("Teslacoil"), new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z) + Vector3.right * 2, this.transform.rotation);
            currentTimeForCooldown = 0;
        }
    }
}