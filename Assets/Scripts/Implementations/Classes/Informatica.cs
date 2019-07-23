using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Informatica : PlayerClass
{
    private Weapon _lasergun = new Lasergun();
    //private Power _artifacting = new Artifacting();
    private Power _hacking = new Hacking();

    public Informatica()
    {
        this.Name = "Sloth";
        this.Health = 50f;
        this.MaxHealth = 50f;
        this.Shield = 0f;
        this.Speed = 5f;
        this.Weapon = _lasergun;
        //this.Ability = _artifacting;
        this.Ultimate = _hacking;
    }

    void Start()
    {
        _hacking = gameObject.AddComponent<Hacking>();
    }
}