using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mechatronica : PlayerClass
{
    private Weapon _rifle = new Rifle();
    //private Power _dash = new Dash();
    private Power _droneShield = new DroneShield();

    public Mechatronica()
    {
        this.Name = "Parody";
        this.Health = 50f;
        this.MaxHealth = 50f;
        this.Shield = 0f;
        this.Speed = 5f;
        this.Weapon = _rifle;
        //this.Ability = _dash;
        this.Ultimate = _droneShield;
    }

    void Start()
    {
        _droneShield = gameObject.AddComponent<DroneShield>();
    }
}   