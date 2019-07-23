using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldPlaceable : Placeable
{
    public GameObject target;
    public GameObject parent;


    public GameObject bullet;
    private bool allowFire;
    private float turretRange;
    private SpriteRenderer spr;
    private Sprite[] sprites;
    private GameObject[] enemies;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("DestroyDrone", lifeTime);
        parent = this.transform.parent.gameObject;
        enemies = new GameObject[0];
        allowFire = true;
        turretRange = 25f;
        spr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.RotateAround(parent.transform.position, Vector3.forward, Time.deltaTime * 200);
        enemies = GameObject.FindGameObjectsWithTag("enemy");

        if (enemies.Length > 0)
        {
            target = GetClosestEnemy(enemies);
        }


        if (target != null)
        {

            if (target != null)
            {
                Vector3 dir = target.transform.position - transform.position;
                float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
                transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

                StartCoroutine(FireWeapon());

            }
        }
    }

    void DestroyDrone()
    {
        Destroy(this.gameObject);
    }

    IEnumerator FireWeapon()
    {
        if (allowFire)
        {
            allowFire = false;
            GameObject newBullet = Instantiate(bullet, new Vector3(transform.position.x, transform.position.y, transform.position.z), transform.rotation *= Quaternion.Euler(0, 0, -90));
            yield return new WaitForSeconds(0.5f);
            allowFire = true;
        }
    }

    GameObject GetClosestEnemy(GameObject[] enemies)
    {
        GameObject bestTarget = null;
        float closestDistanceSqr = Mathf.Infinity;
        Vector3 currentPosition = transform.position;
        foreach (GameObject potentialTarget in enemies)
        {
            Vector3 directionToTarget = potentialTarget.transform.position - currentPosition;
            float dSqrToTarget = directionToTarget.sqrMagnitude;
            if (dSqrToTarget < closestDistanceSqr)
            {
                closestDistanceSqr = dSqrToTarget;
                bestTarget = potentialTarget;
            }
        }

        if (Vector3.Distance(currentPosition, bestTarget.transform.position) < turretRange)
        {
            return bestTarget;
        }

        return null;
    }
}
