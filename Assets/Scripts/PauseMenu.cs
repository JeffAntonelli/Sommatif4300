using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    private static bool gameIsPaused_ = false;

    [SerializeField] private GameObject pauseMenuUI_;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (gameIsPaused_)
            {
                Resume();
            }
            else
            {
                Paused();
            }
        }
    }

    void Paused()
    {
        pauseMenuUI_.SetActive(true);
        Time.timeScale = 0;
        gameIsPaused_ = true;
    }
    public void Resume()
    {
        pauseMenuUI_.SetActive(false);
        Time.timeScale = 1;
        gameIsPaused_ = false;
    }

    public void LoadMainMenu()
    {
        //DontDestroyOnLoadScene.instance.RemoveFromDontDestroyOnLoad();
        Resume();
        SceneManager.LoadScene("MainMenu");
    }

    public void RestartScene()
    {
        //DontDestroyOnLoadScene.instance.RemoveFromDontDestroyOnLoad();
        Resume();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
