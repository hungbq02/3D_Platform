using System.Collections;
using UnityEngine;

public class AnimCharacterLose : MonoBehaviour
{
    public float effectDuration = 1.0f;     
    public float rotationAngle = 180f;      
    public Vector3 targetScale = Vector3.one; 

    private Vector3 originalScale;
    private Quaternion originalRotation;

    private void Awake()
    {
        originalScale = transform.localScale;
        originalRotation = transform.rotation;

        if (targetScale == Vector3.one)
        {
            targetScale = originalScale;
        }
    }

    private void OnEnable()
    {
        transform.localScale = Vector3.zero;
        transform.localScale = originalScale;
        transform.rotation = originalRotation;

        StartCoroutine(PlayEffect());
    }
/*    private void OnDisable()
    {

    }*/
    private IEnumerator PlayEffect()
    {
        float elapsedTime = 0f;

        Quaternion startRotation = transform.rotation;

        Quaternion endRotation = Quaternion.Euler(transform.eulerAngles + new Vector3(0f, rotationAngle, 0f));


        while (elapsedTime < effectDuration)
        {
            float t = elapsedTime / effectDuration;
            transform.localScale = Vector3.Lerp(Vector3.zero, targetScale, t);
            transform.rotation = Quaternion.Lerp(startRotation, endRotation, t);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.localScale = targetScale;
        transform.rotation = endRotation;
    }
}
