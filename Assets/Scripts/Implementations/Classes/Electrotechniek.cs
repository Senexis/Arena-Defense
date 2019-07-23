using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Electrotechniek : PlayerClass
{
    private Weapon _teslaGun = new Teslagun();
    private Power _teslaCoil = new TeslaCoil();
    //private Power _emp = new EMP();

    public Electrotechniek()
    {
        this.Name = "Nikola";
        this.Health = 50f;
        this.MaxHealth = 50f;
        this.Shield = 0f;
        this.Speed = 5f;
        this.Weapon = _teslaGun;
        //this.Ability = _teslaCoil;
        this.Ultimate = _teslaCoil;
    }

    void Start()
    {
        _teslaCoil = gameObject.AddComponent<TeslaCoil>();
    }
}