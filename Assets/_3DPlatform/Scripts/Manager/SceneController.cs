
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public static SceneController Instance { get; private set; }
    [SerializeField] private Animator animTransition;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    
    }
    public void NextLevel()
    {
        StartCoroutine(LoadLevel());
    }
    //Transition between levels
    IEnumerator LoadLevel()
    {
        animTransition.SetTrigger("end");
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        animTransition.SetTrigger("start");
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void LoadHome()
    {
        SceneManager.LoadScene(0);
    }
}
