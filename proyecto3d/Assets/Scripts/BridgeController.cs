using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class BridgeController : MonoBehaviour
{
    [SerializeField]
    UnityEvent onAttack;

    CombatController combatController;

    void Awake() { combatController = GetComponentInChildren<CombatController>(); }

    public void OnAttack() { if (onAttack != null) { onAttack.Invoke(); } }
}
