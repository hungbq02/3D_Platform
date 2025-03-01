using System;
using System.Collections;
using UnityEngine;

public class PlayerEffect : MonoBehaviour
{
    public Pooler smokePool;          
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
        GameObject smoke = smokePool.GetObject();
        if (smoke != null)
        {
            smoke.transform.SetPositionAndRotation(new Vector3(transform.position.x, 1.1f, transform.position.z), Quaternion.identity);
            smoke.SetActive(true);
            StartCoroutine(ReturnSmoke(smoke));
        }
    }
    private IEnumerator ReturnSmoke(GameObject smoke)
    {
        yield return new WaitForSeconds(0.5f);
        smokePool.ReturnObject(smoke);
    }
}
