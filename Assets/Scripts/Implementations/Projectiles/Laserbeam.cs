using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laserbeam : Projectile
{
    public Laserbeam()
    {
        DamageType = DamageType.Piercing;
        //To be changed later.
        Damage = 1;
        Speed = 75f;
    }

    void Start()
    {
        transform.localScale += new Vector3(0f, 10f, 0f);
    }

    void Update()
    {
    }

    public override void OnTriggerEnter2D(Collider2D collision)
    {

    }

    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "enemy")
        {
            CombatManager temp = collision.gameObject.GetComponent<CombatManager>();
            temp.TakeDamage(Damage);
        }
    }
}