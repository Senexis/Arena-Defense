using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Werktuigbouwkunde : PlayerClass
{
    private Weapon _nailgun = new Nailgun();
    private Power _landmine = new Landmine();
    private Power _turret = new Turret();

    public Werktuigbouwkunde()
    {
        this.Name = "Bullseye";
        this.Health = 50f;
        this.MaxHealth = 50f;
        this.Shield = 0f;
        this.Speed = 5f;
        this.Weapon = _nailgun;
        //this.Ability = _landmine;
        this.Ultimate = _turret;
    }

    void Start()
    {
        _turret = gameObject.AddComponent<Turret>();
    }
}