using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public float speed = 50;

    private GameObject[] players;
    public List<Transform> targets = new List<Transform>();

    private NavMeshAgent agent;

    public float rotationspeed = 15f;
    private int failplayer = 0;

    //public Transform closestTarget;
    //private float closestDistance;
    private Vector3 velocity;
    public bool stunned;

    // Start is called before the first frame update
    void Start()
    {
        stunned = false;
        players = GameObject.FindGameObjectsWithTag("Player");

         for (int i = 0; i < players.Length; i++)
         {
            targets.Add(players[i].GetComponent<Transform>());
         }

        //closestTarget = targets[0];
        //closestDistance = Vector2.Distance(transform.position, targets[0].position);


        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
        agent.Warp(transform.position);
        agent.stoppingDistance = 2f;
    }

    // Update is called once per frame
    void Update()
    {
        Transform closestTarget = null;
        float closestDistance = 0;

        try
        {
            closestTarget = targets[failplayer];

            Vector2 t1 = transform.position;
            Vector2 t2 = targets[failplayer].position;

            closestDistance = Vector2.Distance(t1, t2);
        }
        catch (Exception e)
        {
            failplayer++;
            return;
        }


        velocity = agent.velocity;

        for (int j = failplayer; j < targets.Count; j++)
        {
            try
            {
                targets[j].GetInstanceID();
                float distance = Vector2.Distance(transform.position, targets[j].position);

                if (distance < closestDistance)
                {
                    closestDistance = distance;
                    closestTarget = targets[j];
                }
            }
            catch (Exception e)
            {
                targets.RemoveAt(j);
                return;
                
            }
            

        }


        if (object.ReferenceEquals(closestTarget, null))
        {
            return;
        }
        //Rotate towards closest target
        Vector2 direction = closestTarget.transform.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, rotationspeed);

        if (stunned == false)
        {
            agent.isStopped = false;
            agent.SetDestination(closestTarget.transform.position);
        }
        else
        {
            agent.isStopped = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (this.gameObject.tag == "FrenziedEnemy")
        {
            if (collision.gameObject.tag == "enemy")
            {
                gameObject.GetComponent<CombatManager>().TakeDamage(10);
            }
        }

        if (this.gameObject.tag == "enemy")
        {
            if (collision.gameObject.tag == "FrenziedEnemy")
            {
                //Debug.Log("Enemy hit Frenziedenemy");
                gameObject.GetComponent<CombatManager>().TakeDamage(10);
            }
        }
    }
}
