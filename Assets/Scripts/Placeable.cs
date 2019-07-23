using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Placeable : MonoBehaviour
{
    public float lifeTime;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("Destroy", lifeTime);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void Destroy()
    {
        Destroy(transform.parent.gameObject);
        Destroy(gameObject);
    }
}