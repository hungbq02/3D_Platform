using UnityEngine;

public class FinishPoint : MonoBehaviour
{
    public bool goToNextLevel = true;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            if (goToNextLevel)
            {
                SceneController.Instance.NextLevel();
                Debug.Log("Next Level");

            }
            else
            {
                SceneController.Instance.RestartLevel();
                Debug.Log("Restart");
            }

        }
        
    }

}
