using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private GameObject pauseButton;
    [SerializeField] private string nextScene;
    // Start is called before the first frame update

    private void Update()
    {
        if (SceneManager.GetActiveScene().name.Contains("Scene"))
        {
            if (GameObject.FindGameObjectsWithTag("Enemy").Length == 0)
            {
                SceneManager.LoadScene(nextScene);
            }
        }
    }

    public void GoToInstructions()
    {
        SceneManager.LoadScene("Instructions");
    }

    public void GoToMainMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }

    public void LoadFirstScene()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene("Scene1");
    }

    public void PauseButton()
    {
        Time.timeScale = 0f;
        pauseMenu.SetActive(true);
        pauseButton.SetActive(false);
    }

    public void ResumeButton()
    {
        Time.timeScale = 1.0f;
        pauseMenu.SetActive(false);
        pauseButton.SetActive(true);
    }

    public void goToOliveBranch(){
        SceneManager.LoadScene("GreatBritain");
    }
}
