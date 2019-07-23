using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeslacoilController : MonoBehaviour
{
    public List<GameObject> enemies; 
    public float lifeTime = 10f;
    public float health = 10f;
    float timer = 0f;
    byte spriteCount = 0;

    private SpriteRenderer spr;
    private Sprite[] sprites;

    void Start()
    {
        spr = GetComponent<SpriteRenderer>();
        sprites = Resources.LoadAll<Sprite>("Teslacoil");
        Destroy(this.gameObject, lifeTime);
    }

    void Update()
    {
        timer++;
        if (timer > 3) {
            timer = 0;
            spriteCount++;
            spr.sprite = sprites[spriteCount];
            if (spriteCount == sprites.Length - 1) {
                spriteCount = 0;
            }
        }

        foreach (GameObject g in GameObject.FindGameObjectsWithTag("enemy"))
        {
            if (Vector3.Distance(this.transform.position, g.transform.position) < 4f)
            {
                GetComponent<AudioSource>().Play();
                g.GetComponent<CombatManager>().TakeDamage(2f);
            }
        }
    }
}
