using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerClass : MonoBehaviour
{
    public string Name { get; set; }
    public float Health { get; set; }
    public float MaxHealth { get; set; }
    public float Shield { get; set; }
    public float Speed { get; set; }
    public Weapon Weapon { get; set; }
    //public Power Ability { get; set; }
    public Power Ultimate { get; set; }

    private float _currentHealth;

    public PlayerClass()
    {
        _currentHealth = Health;
    }

    public virtual void TakeDamage(float damage)
    {
        _currentHealth -= damage;
    }

    public virtual void Heal(float healpoints)
    {
        _currentHealth += healpoints; 
    }

    public void FullHeal()
    {
        _currentHealth = Health;
    }

    public virtual void ChargeShield(float shieldpoints)
    {
        Shield += shieldpoints;
    }

    public virtual void DischargeShield(float shieldpoints)
    {
        Shield -= shieldpoints;
    }

    public void ModifySpeed(float modifier)
    {
        Speed *= modifier;
    }

    //public void ActivateAbility()
    //{
    //    Ability.Activate();
    //}

    public void ActivateUltimate()
    {
        //Debug.Log(Ultimate.Cooldown);
        Ultimate.Activate();
    }
}