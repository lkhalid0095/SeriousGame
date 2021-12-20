using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private GameObject pauseButton;
    [SerializeField] private string nextScene;
    // Start is called before the first frame update

    private void Start()
    {
        if (PlayerPrefs.HasKey("volume"))
        {
            AudioListener.volume = PlayerPrefs.GetFloat("volume");
        }
    }

    private void Update()
    {
        if (SceneManager.GetActiveScene().name.Contains("Scene") 
            || SceneManager.GetActiveScene().name.Contains("CrossingOfDelaware")
            || SceneManager.GetActiveScene().name.Contains("Lexington&ConcordStart"))
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

    public void GoToHighScores()
    {
        SceneManager.LoadScene("Highscores");
    }

    public void GoToSettings()
    {
        SceneManager.LoadScene("Settings");
    }
    public void LoadFirstScene()
    {
        Time.timeScale = 1.0f;
        PlayerPrefs.SetInt("CurrentScore", 100000);
        SceneManager.LoadScene("GreatBritain");
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

    public void LoadScene()
    {
        SceneManager.LoadScene(nextScene);
    }

    public void LoadNextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void goToOliveBranch(){
        Debug.Log("jgldasjkl");
        SceneManager.LoadScene("GreatBritain");
    }
    public void goToCrossingText(){
        SceneManager.LoadScene("CrossingofDelawareText");
    }
    public void goToCrossing(){
        SceneManager.LoadScene("CrossingofDelaware");
    }
    public void goToLexingtonText(){
        SceneManager.LoadScene("LexingtonConcord");
    }
    public void goToBoston(){
        SceneManager.LoadScene("BostonMassacre");
    }
    public void goToBunkerHill(){
        SceneManager.LoadScene("BattleofBunkerHill");
    }
    public void goToDecIndependence(){
        SceneManager.LoadScene("Independence");
    }
    
}
