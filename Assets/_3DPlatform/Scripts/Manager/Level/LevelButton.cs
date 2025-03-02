
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class LevelButton : MonoBehaviour
{
    private int level;
    private Button btn;

    public Image imgLevelUnlock;
    public Image imgLevelLock;


    public void Awake()
    {
        if(btn == null)
        {
            btn = GetComponent<Button>();
        }
        if(btn != null)
        {
            btn.onClick.AddListener(LoadLevel);
        }
        level = gameObject.transform.GetSiblingIndex() + 1;
    }
    private void OnEnable()
    {
        UpdateState();
    }

    private void UpdateState()
    {
        if (LevelManager.Instance.IsLevelUnlock(level))
        {
            imgLevelUnlock.gameObject.SetActive(true);
            imgLevelLock.gameObject.SetActive(false);
            btn.interactable = true;
        }
        else
        {
            imgLevelUnlock.gameObject.SetActive(false);
            imgLevelLock.gameObject.SetActive(true);
            btn.interactable = false;
        }
    }

    private void LoadLevel()
    {
        SceneManager.LoadScene("Level_"+level);
        LevelManager.Instance.currentLevel = level;
    }

}
