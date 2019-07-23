using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour
{
    public GameObject enemy;

    public void Spawn(int amount)
    {
        StartCoroutine(Instantiate(amount));
    }

    IEnumerator Instantiate(int amount)
    {
        for (int i = 0; i < amount; i++)
        {
            Instantiate(enemy, transform.position, Quaternion.identity);
            yield return new WaitForSeconds(0.1f);
        }
    }
}
