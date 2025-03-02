using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject loseScreen;
    public GameObject characterUI;
    public float delayBeforeShowLoseScreen = 1.0f;

    private void OnEnable()
    {
        PlayerHealth.OnPlayerDeath += HandlePlayerDeath;
    }

    private void OnDisable()
    {
        PlayerHealth.OnPlayerDeath -= HandlePlayerDeath;
    }

    private void HandlePlayerDeath()
    {
        StartCoroutine(DelayShowLoseScreen(delayBeforeShowLoseScreen));
    }
    private IEnumerator DelayShowLoseScreen(float delay)
    {
        yield return new WaitForSeconds(delay);
        if (loseScreen != null)
        {
            loseScreen.SetActive(true);
            characterUI.SetActive(true);
        }
    }
}
