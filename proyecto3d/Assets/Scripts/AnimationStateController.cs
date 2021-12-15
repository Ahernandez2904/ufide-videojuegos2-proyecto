using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationStateController : MonoBehaviour
{
    [SerializeField]
    GameObject player;


    Animator animator;

    int isWalkingHash;

    int isRunningHash;

    int isCrouchingHash;

    int isCrouching2Hash;

    int isAttackingHash;

    void Awake()
    {
        animator = player.GetComponent<Animator>();
        isWalkingHash = Animator.StringToHash("isWalking");
        isRunningHash = Animator.StringToHash("isRunning");
        isCrouchingHash = Animator.StringToHash("isCrouching");
        isCrouching2Hash = Animator.StringToHash("isCrouching2");
        isAttackingHash = Animator.StringToHash("isAttacking");
    }

    void Update()
    {
        bool isWalking = animator.GetBool(isWalkingHash);
        bool isRunning = animator.GetBool(isRunningHash);
        bool forwardPressed = Input.GetAxis("Horizontal") != 0F || Input.GetAxis("Vertical") != 0F;
        bool runPressed = Input.GetKey(KeyCode.LeftShift);
        bool ctrlPressed = Input.GetKey(KeyCode.LeftControl);
        bool atckPressed = Input.GetKey(KeyCode.F);
        if (!isWalking && ! isRunning && !forwardPressed && !runPressed && !ctrlPressed && atckPressed)
        {
            animator.SetBool(isAttackingHash, true);
        }
        else if (!isWalking && !isRunning && !forwardPressed && !runPressed && !ctrlPressed && !atckPressed)
        {
            animator.SetBool(isAttackingHash, false);
        }
        if (!isWalking && !isRunning && forwardPressed && !runPressed && ctrlPressed && atckPressed)
        {
            animator.SetBool(isCrouching2Hash, true);
        }
        else if (!isWalking && !isRunning && !forwardPressed && !runPressed && !ctrlPressed)
        {
            animator.SetBool(isCrouching2Hash, false);
        }
        if (!isWalking && !forwardPressed && !runPressed && ctrlPressed)
        {
            animator.SetBool(isCrouchingHash, true);
        }
        else if (!isRunning && forwardPressed && !runPressed && !ctrlPressed)
        {
            animator.SetBool(isCrouchingHash, false);
        }
        if (!isRunning && forwardPressed && runPressed)
        {
            animator.SetBool(isRunningHash, true);
        }
        else if (isRunning && (!forwardPressed || !runPressed))
        {
            animator.SetBool(isRunningHash, false);
        }
        if (!isWalking && !runPressed && forwardPressed)
        {
            animator.SetBool(isWalkingHash, true);
        }
        else if (isWalking && !forwardPressed)
        {
            animator.SetBool(isWalkingHash, false);
        }

    }
}