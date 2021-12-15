using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class CollectibleController : MonoBehaviour
{
    public enum CollectibleTypes
    {
        KEY,
        GEM,
        PORTAL
    }

    [SerializeField]
    CollectibleTypes CollectibleType;

    [SerializeField]
    bool rotate;

    [SerializeField]
    float rotationSpeed;

    [SerializeField]
    AudioClip collectSound;

    [SerializeField]
    GameObject collectEffect;

    PlayerController player;

    int playerMask;

    void Awake()
    {
        player = FindObjectOfType<PlayerController>();
        playerMask = LayerMask.NameToLayer("Player");
    }

    void Update()
    {
        if (rotate)
        {
            transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime, Space.World);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == playerMask)
        {
            Collect();
        }
    }

    public void Collect()
    {
        if (collectSound)
        {
            AudioSource.PlayClipAtPoint(collectSound, transform.position);
        }
        if (collectEffect)
        {
            Instantiate(collectEffect, transform.position, Quaternion.identity);
        }
        switch (CollectibleType)
        {
            case CollectibleTypes.KEY:
                player.KeyFound();
                break;
            case CollectibleTypes.GEM:
                player.IncreaseGems(1);
                break;
            case CollectibleTypes.PORTAL:
                player.Win();
                break;
        }
        Destroy(gameObject);
    }
}