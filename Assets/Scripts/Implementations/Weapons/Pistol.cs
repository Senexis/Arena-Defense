using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistol : BallisticWeapon
{
    public Projectile pistolBullet;
    public GameObject player;
    private bool allowFire = true;

    public override void Fire()
    {
        StartCoroutine(FireWeapon());
    }

    public Pistol()
    {
        this.MaxClipSize = 10;
        this.FireRate = 1;
    }

    void Update()
    {
        gameObject.SetActive(true);
        //Debug.Log(gameObject.activeInHierarchy);
    }

    IEnumerator FireWeapon()
    {

        if (CurrentClipSize > 0 && allowFire)
        {
            GetComponent<AudioSource>().Play();
            allowFire = false;
            GameObject newBullet = Instantiate(pistolBullet.gameObject, new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z), player.transform.rotation);
            CurrentClipSize--;
            yield return new WaitForSeconds(FireRate);
            allowFire = true;

        }
    }

    public override void ModifyDamage(float modifier)
    {
        pistolBullet.Damage *= modifier;
    }

    public override float getCurrentAmmo()
    {
        return CurrentClipSize;
    }

    public override float getMaxAmmo()
    {
        return MaxClipSize;
    }

    public override void Reload()
    {
        var clip = Resources.Load("Audio/pistolReload") as AudioClip;
        GetComponent<AudioSource>().PlayOneShot(clip);
        Invoke("ReloadWeapon", 0.5f);
    }

    private void ReloadWeapon()
    {
        CurrentClipSize = MaxClipSize;
    }
}