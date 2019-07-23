using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatManager : MonoBehaviour
{
    private float health;

    // Start is called before the first frame update
    void Start()
    {
        this.health = 20;
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(health + "Health of enemy");
    }

    public void TakeDamage(float damage)
    {
        Instantiate((GameObject)Resources.Load("OnHitParticle"), gameObject.transform);
        if (health - damage <= 0)
        {
            Destroy(gameObject);
            if(gameObject.tag == "enemy")
            {
                GameObject.FindGameObjectWithTag("Score").GetComponent<ScoreController>().AddScore(25);
            }
        }
        else
        {
            health -= damage;
        }
    }
}
