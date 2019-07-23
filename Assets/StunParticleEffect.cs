using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StunParticleEffect : MonoBehaviour
{
    Sprite oldSprite;
    SpriteRenderer spr;
    Sprite[] sprites;

    int timer = 0;
    int spriteCount = 0;

    private void Start()
    {
        oldSprite = gameObject.GetComponent<SpriteRenderer>().sprite;
        spr = gameObject.GetComponent<SpriteRenderer>();
        sprites = Resources.LoadAll<Sprite>("RobotStun");
    }

    // Update is called once per frame
    void Update()
    {
        timer++;
        if (timer > 3)
        {
            timer = 0;
            spriteCount++;
            spr.sprite = sprites[spriteCount];
            if (spriteCount == sprites.Length - 1)
            {
                spriteCount = 0;
            }
        }
    }

    private void OnDestroy()
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = oldSprite;
    }
}
