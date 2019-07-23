using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrenzyBomb : Power
{
    public FrenzyBomb()
    {
        this.Type = PowerType.Ability;
        this.Cooldown = 150f; //TBD
    }

    public override void Activate()
    {
        if (currentTimeForCooldown >= Cooldown)
        {
            GameObject newPlaceable = Instantiate((GameObject)Resources.Load("EnemyHacking"), new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z), this.transform.rotation);
            currentTimeForCooldown = 0;
        }
    }
}