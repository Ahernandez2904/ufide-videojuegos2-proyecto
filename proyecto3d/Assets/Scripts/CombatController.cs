using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public enum CombatTypes
{
    FIST,
    MELEE,
    WEAPON
}

public class CombatController : MonoBehaviour
{
    [SerializeField]
    Animator animatorController;

    [SerializeField]
    CombatTypes combatType;

    [SerializeField]
    Transform weapon;

    [SerializeField]
    Transform melee;

    [SerializeField]
    int attackRate = 2;

    [SerializeField]
    float attackRange = 1.0F;

    int jabHash;

    int swordHash;

    int shootHash;

    int kickHash;

    float nextSwordAttack;

    void Start()
    {
        jabHash = Animator.StringToHash("Jab");
        swordHash = Animator.StringToHash("Sword");
        shootHash = Animator.StringToHash("Shoot");
        kickHash = Animator.StringToHash("Kick");
    }

    void Update()
    {
        if (animatorController == null) { return; }

        if (Time.time > nextSwordAttack)
        {
            bool attack = false;
            if (Input.GetButton("Fire1"))
            {
                attack = true;
                switch (combatType)
                {
                    case CombatTypes.MELEE: animatorController.SetTrigger(swordHash); break;
                    case CombatTypes.WEAPON: animatorController.SetTrigger(shootHash); break;
                    default: animatorController.SetTrigger(jabHash); break;
                }
            }
            else if (Input.GetButton("Fire2"))
            {
                attack = true;
                animatorController.SetTrigger(kickHash);
            }
            if (Input.GetKey(KeyCode.Alpha1))
            {
                combatType = CombatTypes.FIST;
                melee.gameObject.SetActive(false);
                weapon.gameObject.SetActive(false);
            }
            else if (Input.GetKey(KeyCode.Alpha2))
            {
                combatType = CombatTypes.MELEE;
                melee.gameObject.SetActive(true);
                weapon.gameObject.SetActive(false);
            }
            else if (Input.GetKey(KeyCode.Alpha3))
            {
                combatType = CombatTypes.WEAPON;
                melee.gameObject.SetActive(false);
                weapon.gameObject.SetActive(true);
            }

            if (attack) { nextSwordAttack = Time.time + (attackRange / attackRate); }
        }
    }
}
