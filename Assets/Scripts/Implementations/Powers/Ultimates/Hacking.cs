using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hacking : Power
{
    private GameObject mainCamera;
    private GameObject[] players;
    private float damageMultiplier = 2f;
    private float glitchDuration = 1.5f;
    private float buffDuration = 10f;

    public Hacking()
    {
        this.Type = PowerType.Ultimate;
        this.Cooldown = 60f; //TBD
    }

    private void Start()
    {
        currentTimeForCooldown = Cooldown;
        mainCamera = GameObject.FindGameObjectWithTag("MainCamera");
        players = GameObject.FindGameObjectsWithTag("Player");
    }

    public override void Activate()
    {
        StartCoroutine(ActivateUltimate());
    }

    private IEnumerator ActivateUltimate()
    {
        if (currentTimeForCooldown >= Cooldown)
        {
            currentTimeForCooldown = 0;
            //Apply screen glitch
            var script = mainCamera.GetComponent<Kino.AnalogGlitch>();
            script.enabled = true;
            script.scanLineJitter = 0.35f;
            script.verticalJump = 0.135f;
            script.horizontalShake = 0.035f;
            script.colorDrift = 0.4f;

            //Disable screen glitch
            yield return new WaitForSeconds(glitchDuration);
            script.enabled = false;

            //Give team damage boost for given duration
            foreach (var player in players)
            {
                var weapon = (player.GetComponentInChildren<Weapon>().GetComponent<MonoBehaviour>() as Weapon);
                weapon.ModifyDamage(damageMultiplier);
            }

            yield return new WaitForSeconds(buffDuration);
            //Remove team damage boost
            foreach (var player in players)
            {
                var weapon = (player.GetComponentInChildren<Weapon>().GetComponent<MonoBehaviour>() as Weapon);
                weapon.ModifyDamage(1 / damageMultiplier);
            }
        }
    }
}