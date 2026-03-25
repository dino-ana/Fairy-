using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public GameObject retryUI;

    void Awake()
    {
        instance = this;
        Time.timeScale = 1f;

        if (retryUI != null)
            retryUI.SetActive(false);
    }

    public void ShowGameOver()
    {
        if (retryUI != null)
            retryUI.SetActive(true);
    }

    public void Retry()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}