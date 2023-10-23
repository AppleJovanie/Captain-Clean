using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject continueButton;
    private bool checkpointReached = false;

    private void Start()
    {
        // Check if a checkpoint has been reached in the game
        checkpointReached = PlayerPrefs.GetInt("CheckpointReached", 0) == 1;

        // Set the "Continue" button's visibility based on whether a checkpoint has been reached
        continueButton.SetActive(checkpointReached);
    }

    public void NewGame()
    {
        PlayerPrefs.SetInt("CheckpointReached", 0);
        PlayerPrefs.Save();
        continueButton.SetActive(false); // Set the "Continue" button to not visible
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }

    public void Continue()
    {
        // Get the scene name where the player reached the last checkpoint
        string sceneNameToLoad = PlayerPrefs.GetString("LastCheckpointScene", SceneManager.GetActiveScene().name);

        // Load the scene
        SceneManager.LoadScene(sceneNameToLoad);

        // Get the checkpoint position from PlayerPrefs
        float checkpointPositionX = PlayerPrefs.GetFloat("CheckpointPositionX");
        float checkpointPositionY = PlayerPrefs.GetFloat("CheckpointPositionY");

        // Find the player GameObject (make sure it's tagged as "Player")
        GameObject player = GameObject.FindGameObjectWithTag("Player");

        // Set the player's position to the checkpoint position
        if (player != null)
        {
            player.transform.position = new Vector3(checkpointPositionX, checkpointPositionY, player.transform.position.z);
        }
    }
}
   

