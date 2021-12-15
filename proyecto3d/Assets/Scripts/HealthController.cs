using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.EventSystems;

public class HealthController : MonoBehaviour
{
    [SerializeField]
    float maximumHealth = 100.0F;

    [SerializeField]
    UnityEvent onDeath;

    float health;

    void Awake() { health = maximumHealth; }

    public void TakeDamage(float damage)
    {
        health -= damage;
        if (health <= 0.0F && onDeath != null) { onDeath.Invoke(); }
    }
}