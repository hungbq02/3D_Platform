using System;
using UnityEngine;

public class PlayerEffect : MonoBehaviour
{
    public GameObject smokeEffect;
    public float smokeCooldown = 0.5f;

    private float lastSmokeTime = 0f;
    private PlayerMovement playerMovement;

    private void Awake()
    {
        playerMovement = GetComponent<PlayerMovement>();
    }

    private void Update()
    {
        if (playerMovement.IsGrounded && Time.time - lastSmokeTime >= smokeCooldown && playerMovement.MoveDirection.magnitude != 0)
        {
            SpawnSmoke();
            lastSmokeTime = Time.time;
        }
    }
    void SpawnSmoke()
    {
        Instantiate(smokeEffect, new Vector3(transform.position.x, 1.1f, transform.position.z), Quaternion.identity);
    }
}
