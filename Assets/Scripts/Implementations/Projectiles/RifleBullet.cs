using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RifleBullet : Projectile
{
    private float lifeTime = 3f;
    public RifleBullet()
    {
        DamageType = DamageType.Normal;
        //To be changed later.
        Damage = 15;
        Speed = 75f;
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

            Destroy(gameObject);
        }
    }
}