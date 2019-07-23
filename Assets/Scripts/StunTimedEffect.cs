using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StunTimedEffect : TimedEffect
{
    protected override void ApplyEffect()
    {
        gameObject.AddComponent<StunParticleEffect>();
        gameObject.GetComponent<EnemyController>().stunned = true;
    }

    protected override void EndEffect()
    {
        Destroy(gameObject.GetComponent<StunParticleEffect>());
        gameObject.GetComponent<EnemyController>().stunned = false;
        CancelInvoke();
        Destroy(this);
    }
}
