using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObj : MonoBehaviour
{
    private void OnEnable()
    {
        Invoke("Destroy", 1f);
    }
    void Destroy()
    {
        Destroy(gameObject);
    }
}
