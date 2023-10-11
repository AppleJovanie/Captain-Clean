using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
   public static bool GameisPaused = false;
    public GameObject pauseMenuUI;
    public static bool isGameOver;
    public GameObject gameOverScreen;
    public GameObject pauseMenuScreen;


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            if (GameisPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }
   
    public  void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameisPaused = false;
    } 
   public void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;

        GameisPaused = true;
    }
    public void Loadmenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }
    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
}
