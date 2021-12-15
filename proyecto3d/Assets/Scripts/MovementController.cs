using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    [SerializeField]
    float moveSpeed = 5.0F;

    [SerializeField]
    float rotationSpeed = 2.0F;

    void Update()
    {
        MoveCharacter();
        RotationCharacter();
    }

    private void MoveCharacter()
    {
        float rotation = rotationSpeed * Input.GetAxis("Mouse X");
        transform.Rotate(0, rotation, 0);
    }

    private void RotationCharacter()
    {
        Vector3 posicion =
            new Vector3
            (
                Input.GetAxis("Horizontal"),
                0F,
                Input.GetAxis("Vertical")
                );
        transform.Translate(posicion * moveSpeed * Time.deltaTime);
    }
}
