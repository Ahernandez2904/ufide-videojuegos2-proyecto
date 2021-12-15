using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Events;

public class HealthController : MonoBehaviour
{
    [SerializeField]
    float maximumHealth = 100.0F;

    [SerializeField]
    UnityEvent onDeath;

    [SerializeField]
    Text HealthText;

    GameObject player;

    Animator animator;

    public float health;

    float heal;

    int isDefeatedHash;

    GameObject PickUp1;

    void Awake() { 
        health = maximumHealth;
        isDefeatedHash = Animator.StringToHash("isDefeated");
    }

    public void TakeDamage(float damage)
    {
        bool isDefeated = animator.GetBool(isDefeatedHash);
        health -= damage;
        if (health <= 0.0F && onDeath != null) {
            onDeath.Invoke();
            animator.SetBool(isDefeatedHash, true); }
    }

    void OnTriggerEnter(Collider col)
    {
        PickUp1 = GameObject.FindGameObjectWithTag("NPC");
        health = health + 50;
        if(health > maximumHealth) { health = maximumHealth; }
        HealthText.text = health.ToString();
    }
}
