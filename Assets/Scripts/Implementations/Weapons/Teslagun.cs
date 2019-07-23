using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teslagun : EnergyWeapon
{
    public Projectile energyBall;
    public GameObject player;
    private bool allowFire = true;
    private bool isActive = false;

    public override void Fire()
    {
        StartCoroutine(FireWeapon());
    }

    public Teslagun()
    {
        this.MaxCharge = 30;
        this.FireRate = 1;
        this.CurrentCharge = MaxCharge;
    }

    IEnumerator FireWeapon()
    {
        if (CurrentCharge > 0 && allowFire && !isActive)
        {
            GetComponent<AudioSource>().Play();
            allowFire = false;
            GameObject newBullet = Instantiate(energyBall.gameObject, new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z), player.transform.rotation);
            isActive = true;
            CurrentCharge--;
            yield return new WaitForSeconds(FireRate);
            allowFire = true;
            isActive = false;
        }
    }

    void Update()
    {
        if (!isActive)
        {
            if (player.GetComponent<PlayerController>().trigger == 0)
            {
                //Debug.Log(CurrentCharge + "CurrentCharge");
                if (CurrentCharge < MaxCharge)
                {
                    CurrentCharge += Time.deltaTime;
                }
            }
        }
    }

    public override void ModifyDamage(float modifier)
    {
        energyBall.Damage *= modifier;
    }

    public override void StopFire()
    {
        isActive = false;
    }

    public override float getCurrentAmmo()
    {
        return CurrentCharge;
    }

    public override float getMaxAmmo()
    {
        return MaxCharge;
    }

    public override void Reload()
    {
        //Invoke("ReloadWeapon", 2f);
    }

    private void ReloadWeapon()
    {
        CurrentCharge = MaxCharge;
    }
}