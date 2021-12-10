using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SamusAnimationStateController : MonoBehaviour
{
    [SerializeField]
    GameObject character;

    Animator animator;

    int isWalkingHash;

    int isAttackingHash;

    int isDashingHash;

    int isDefeatedHash;

    Vector3 characterVelocity;

    void Awake()
    {
        animator = character.GetComponent<Animator>();
        isWalkingHash = Animator.StringToHash("isWalking");
        isAttackingHash = Animator.StringToHash("isAttacking");
        isDashingHash = Animator.StringToHash("isDashing");
        isDefeatedHash = Animator.StringToHash("isDefeated");
    }

    void Update()
    {
        bool isWalking = animator.GetBool(isWalkingHash);
        bool isAttacking = animator.GetBool(isAttackingHash);
        bool isDashing = animator.GetBool(isDashingHash);
        bool isDefeated = animator.GetBool(isDefeatedHash);

        bool isWalkingCond = character.GetComponent<Rigidbody>().velocity.sqrMagnitude >= 0.02f;
        bool isAttackingCond = false;
        bool isDashingCond = false;
        bool isDefeatedCond = false;

        if (!isWalking && isWalkingCond)
        {
            animator.SetBool(isWalkingHash, true);
        }
        else if (isWalking && !isWalkingCond)
        {
            animator.SetBool(isWalkingHash, false);
        }

        if (!isAttacking && isAttackingCond && isWalkingCond)
        {
            animator.SetBool(isAttackingHash, true);
        }
        else if (isAttacking && !isAttackingCond)
        {
            animator.SetBool(isAttackingHash, false);
        }

        if (!isDashing && isDashingCond)
        {
            animator.SetBool(isDashingHash, true);
        }
        else if (isDashing && !isDashingCond)
        {
            animator.SetBool(isDashingHash, false);
        }

        if (!isDefeated && isDefeatedCond)
        {
            animator.SetBool(isDefeatedHash, true);
        }
    }
}