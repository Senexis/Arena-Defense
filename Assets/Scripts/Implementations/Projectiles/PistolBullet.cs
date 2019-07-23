using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PistolBullet : Projectile
{
    public Component bleed;
    private float lifeTime = 3f;

    public PistolBullet()
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

            temp.gameObject.AddComponent<BleedTimedEffect>();
            temp.gameObject.GetComponent<BleedTimedEffect>().SetTiming(1,10,1);
            
            Destroy(gameObject);
        }
    }
}