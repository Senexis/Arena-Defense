using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rifle : BallisticWeapon
{
    public Projectile rifleBullet;
    private bool allowFire = true;

    public Rifle()
    {
        
            this.MaxClipSize = 30f;
            this.FireRate = 0.10f;
    }

    public override void Fire()
    {
        StartCoroutine(FireWeapon());
    }

    void Start()
    { 

    }

    IEnumerator FireWeapon()
    {
        if (CurrentClipSize > 0 && allowFire)
        {
            GetComponent<AudioSource>().Play();
            allowFire = false;
            GameObject newBullet = Instantiate(rifleBullet.gameObject, new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y, this.gameObject.transform.position.z), this.gameObject.transform.rotation);
            CurrentClipSize--;
            yield return new WaitForSeconds(FireRate);
            allowFire = true;
        }
    }

    public override void ModifyDamage(float modifier)
    {
        rifleBullet.Damage *= modifier;
    }

    public override void Reload()
    {
        var clip = Resources.Load("Audio/rifleReload") as AudioClip;
        GetComponent<AudioSource>().PlayOneShot(clip);
        Invoke("ReloadWeapon", 0.7f);
    }

    public override float getCurrentAmmo()
    {
        return this.CurrentClipSize;
    }

    public override float getMaxAmmo()
    {
        return this.MaxClipSize;
    }

    private void ReloadWeapon()
    {
        CurrentClipSize = 30;
    }
}