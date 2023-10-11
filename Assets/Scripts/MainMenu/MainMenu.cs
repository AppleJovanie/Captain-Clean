using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    private GameMaster gm;
    private GameObject playerPosObject; // Reference to the PlayerPos GameObject

    private Vector2 defaultStartPosition = new Vector2(-7.16f, 0.24f);

    private void Start()
    {
        playerPosObject = GameObject.Find("PlayerPos"); // Set this in the Inspector or through code
        gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();
    }
    //For Debugging 
    public void NewGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }


    public void LoadGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
}
