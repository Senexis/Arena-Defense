using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PistolController : MonoBehaviour
{

    public GameObject bullet;
    public GameObject player;
    
    public int refireTime;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
           
    }

    public void Fire()
    {
        GameObject newBullet = Instantiate(bullet, new Vector3( player.transform.position.x, player.transform.position.y, player.transform.position.z), player.transform.rotation);
        //newBullet.GetComponent<PistolBulletController>().bulletDirection = new Vector2((float) Mathf.Cos(player));
    }
}
