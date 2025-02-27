using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public Vector3 offset; //7.5,2.5,0

    void LateUpdate()
    {
        if (target != null)
        {
            transform.position = target.position + offset;
            transform.LookAt(target); 
        }
    }
}
