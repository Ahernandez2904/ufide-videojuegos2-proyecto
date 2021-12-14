using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationStateController : MonoBehaviour
{
    [SerializeField]
    GameObject player;

    public bool isRunning;

    Animator animator;

    int isWalkingHash;

    int isRunningHash;

    void Awake()
    {
        animator = player.GetComponent<Animator>();
        isWalkingHash = Animator.StringToHash("isWalking");
        isRunningHash = Animator.StringToHash("isRunning");
    }

    void Update()
    {
        bool isWalking = animator.GetBool(isWalkingHash);
        bool isRunning = animator.GetBool(isRunningHash);
        bool forwardPressed = Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0;
        bool runPressed = Input.GetKey(KeyCode.LeftShift);
        bool ctrlPressed = Input.GetKey(KeyCode.LeftControl);

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