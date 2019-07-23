using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimedEffect : MonoBehaviour
{
    public float duration;
    public float startTime;

    public float repeatTime;

    // Start is called before the first frame update
    void Start()
    {
        if (repeatTime > 0)
        {
            InvokeRepeating("ApplyEffect", startTime, repeatTime);
        }
        else
        {
            Invoke("ApplyEffect", startTime);
        }

        Invoke("EndEffect", duration);
    }

    public void SetTiming(float startTime, float duration, float repeated)
    {
        this.duration = duration;
        this.startTime = startTime;
        this.repeatTime = repeated;
    }

    protected virtual void ApplyEffect()
    {

    }

    protected virtual void EndEffect()
    {
        CancelInvoke();
        Destroy(this);
    }
}
