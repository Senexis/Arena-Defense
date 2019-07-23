using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum DamageType { Normal, Bleeding, Piercing, Stun }

public abstract class Projectile : MonoBehaviour
{
    public DamageType DamageType { get; set; }
    public float Damage { get; set; }
    public float Speed { get; set; }

    public abstract void OnTriggerEnter2D(Collider2D collision);
}