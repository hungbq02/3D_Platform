using UnityEngine;

public class FallingObstacle : MonoBehaviour
{
    private Rigidbody rb;
    private BoxCollider boxCollider;
    private PlayerMovement player;
    public float fallLimitY = -5f;
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        boxCollider = GetComponent<BoxCollider>();
        player = FindObjectOfType<PlayerMovement>();
    }
    private void Update()
    {
        if (transform.position.y <= fallLimitY)
        {
            rb.useGravity = false;
            rb.isKinematic = true;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            rb.useGravity = true;
            boxCollider.isTrigger = false;
        }
    }
}
