using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyBall : Projectile
{
    private float lifeTime = 3f;

    public EnergyBall()
    {
        DamageType = DamageType.Bleeding;
        //To be changed later.
        Damage = 5;
        Speed = 100f;
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

            temp.gameObject.AddComponent<StunTimedEffect>();
            temp.gameObject.GetComponent<StunTimedEffect>().SetTiming(0, 1, 0);
            

            Destroy(gameObject);
        }
    }
}