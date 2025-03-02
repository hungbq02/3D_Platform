using UnityEngine;

public class FinishPoint : MonoBehaviour
{
    public bool goToNextLevel = true;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            LevelManager.Instance.CheckHighestLevelUnlock(LevelManager.Instance.currentLevel + 1);
            if (goToNextLevel)
            {
                SceneController.Instance.NextLevel();

            }
            else
            {
                SceneController.Instance.RestartLevel();
            }

        }
        
    }

}
