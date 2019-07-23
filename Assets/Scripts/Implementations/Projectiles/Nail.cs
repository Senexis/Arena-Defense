using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nail : Projectile
{

    private float lifeTime = 3f;
    public int piercingNumber = 4;
    private int currentHits = 0;
    public Nail()
    {
        DamageType = DamageType.Piercing;
        //To be changed later.
        Damage = 100;
        Speed = 30f;
    }

    void Update()
    {
        gameObject.transform.position += transform.up * Time.deltaTime * Speed;

        Destroy(gameObject, lifeTime);
    }

    public override void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "enemy")
        {
            CombatManager temp = collision.gameObject.GetComponent<CombatManager>();
            temp.TakeDamage(Damage);

            if (currentHits >= piercingNumber)
            {
                Destroy(gameObject);
            }
            else
            {
                currentHits++;
            }
        }
    }
}