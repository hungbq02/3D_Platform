using System;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public static event Action OnPlayerDeath;

    public float deathYLimit = -1.5f;
    private bool isDead = false;

    private PlayerMovement playerMovement;
    private Animator animator;
    private Rigidbody rb;

    private void Awake()
    {
        playerMovement = GetComponent<PlayerMovement>();
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        if (!isDead)
        {
            if (transform.position.y < deathYLimit)
            {
                Die();
            }
        }
    }

    private void Die()
    {
        isDead = true;
        animator.SetTrigger("die");
        playerMovement.enabled = false;

        // notice to the event registration class OnPlayerDeath
        OnPlayerDeath?.Invoke();
    }

}
