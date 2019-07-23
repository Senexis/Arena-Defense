using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BleedTimedEffect : TimedEffect
{
    private int damage = 10;

    protected override void ApplyEffect()
    {
        gameObject.GetComponent<CombatManager>().TakeDamage(damage);
        //Debug.Log("I am bleeding now");
    }
}
