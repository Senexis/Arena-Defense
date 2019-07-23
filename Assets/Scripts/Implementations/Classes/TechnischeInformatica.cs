using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TechnischeInformatica : PlayerClass
{
    private Weapon _pistol = new Pistol();
    private Power _frenzy = new FrenzyBomb();


    public TechnischeInformatica()
    {
        this.Name = "Cipher";
        this.Health = 50f;
        this.MaxHealth = 50f;
        this.Shield = 0f;
        this.Speed = 5f;
        this.Weapon = _pistol;
        this.Ultimate = _frenzy;

    }

    void Start()
    {
        _frenzy = gameObject.AddComponent<FrenzyBomb>();
    }
}