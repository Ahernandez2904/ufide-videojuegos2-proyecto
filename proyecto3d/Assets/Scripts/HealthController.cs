using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Events;

public class HealthController : MonoBehaviour
{
    [SerializeField]
    float maximumHealth = 100.0F;

    [SerializeField]
    UnityEvent onDeath;
    GameObject player;
    Animator animator;
    public float health;
    float heal;
    int isDefeatedHash;

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

    public GameObject PickUp1;

    void OnTriggerEnter(Collider col)
    {
        PickUp1 = GameObject.FindGameObjectWithTag("NPC");
        health = health + 50;
        }
    }
