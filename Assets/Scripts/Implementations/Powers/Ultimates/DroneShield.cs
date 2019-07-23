using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneShield : Power
{
    private GameObject drone;


    public DroneShield()
    {
        this.Type = PowerType.Ultimate;
        this.Cooldown = 90f; // 60s + 30s activation
    }

    public override void Activate()
    {
        if (currentTimeForCooldown >= Cooldown)
        {
            drone = Instantiate((GameObject)Resources.Load("DroneShield"), new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z) + Vector3.right, this.transform.rotation);
            drone.gameObject.transform.SetParent(this.gameObject.transform.parent);
            currentTimeForCooldown = 0;
        }
    }
}