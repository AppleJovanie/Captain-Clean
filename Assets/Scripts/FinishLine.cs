using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLine : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // Get the current scene's build index
            int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

            // Check if there is a scene to proceed to
            if (currentSceneIndex < SceneManager.sceneCountInBuildSettings - 1)
            {
                // Proceed to the next scene (increment the build index)
                SceneManager.LoadScene(currentSceneIndex + 1);
            }
            else
            {
                // Handle what to do when there are no more scenes to proceed to
                Debug.Log("No more scenes to proceed to.");
            }
        }
    }
}
