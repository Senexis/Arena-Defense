using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PowerType { Ability, Ultimate }

public abstract class Power : MonoBehaviour
{
    public bool IsReady { get; set; }

    public float currentTimeForCooldown { get; set; }
    public float Cooldown { get; set; }

    public PowerType Type { get; set; }

    public Power()
    {
        IsReady = true;
    }
    
    public abstract void Activate();

    void Start()
    {
        currentTimeForCooldown = Cooldown;
    }

    void Update()
    {
        currentTimeForCooldown += Time.deltaTime;
    }
}