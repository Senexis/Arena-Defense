using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class FrenzyTimedEffect : TimedEffect
{
    protected override void ApplyEffect()
    {
        this.gameObject.tag = "FrenziedEnemy";
        List<GameObject> enemies = GameObject.FindGameObjectsWithTag("enemy").ToList();
        List<Transform> targets = new List<Transform>();

        for (int i = 0; i < enemies.Count; i++)
        {
            targets.Add(enemies[i].GetComponent<Transform>());
        }

        gameObject.GetComponent<EnemyController>().targets = targets;
    }

    protected override void EndEffect()
    {
        this.gameObject.tag = "enemy";
        List<GameObject> players = GameObject.FindGameObjectsWithTag("Player").ToList();
        List<Transform> targets = new List<Transform>();

        for (int i = 0; i < players.Count; i++)
        {
            targets.Add(players[i].GetComponent<Transform>());
        }

        gameObject.GetComponent<EnemyController>().targets = targets;
        //gameObject.GetComponent<EnemyController>().closestTarget = targets[0];
        CancelInvoke();
        Destroy(this);
    }
}
