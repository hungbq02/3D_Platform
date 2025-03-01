using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DominoFallingObstacle : MonoBehaviour
{
    private List<GameObject> listObstacle = new List<GameObject>();
    public float delayFall = 0.5f;

    // Cache WaitForSeconds để giảm việc tạo đối tượng liên tục
    private WaitForSeconds delayFallWait;
    private void Awake()
    {
        if (listObstacle.Count == 0)
        {
            foreach (Transform child in transform)
            {
                listObstacle.Add(child.gameObject);
            }
        }
        // Tạo đối tượng WaitForSeconds từ delayFall
        delayFallWait = new WaitForSeconds(delayFall);
    }

        private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(FallObstacle());
        }
    }

    private IEnumerator FallObstacle()
    {
        foreach (GameObject obstacle in listObstacle)
        {
            yield return delayFallWait;
            if (obstacle.TryGetComponent<Rigidbody>(out var rb))
            {
                rb.isKinematic = false;
                rb.useGravity = true;
            }
            Destroy(obstacle, 1.5f);
        }

    }
}
