using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerScript : MonoBehaviour
{
    void OnParticleCollision(GameObject other)
    {
        if (other.gameObject.tag == "enemy")
        {
            other.gameObject.AddComponent<FrenzyTimedEffect>();
            other.gameObject.GetComponent<FrenzyTimedEffect>().SetTiming(0, 10, 0);
        }
    }
}
