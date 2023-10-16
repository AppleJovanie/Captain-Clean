using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLine : MonoBehaviour
{

    private void Start()
    {

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
          
            Invoke("Proceed", 2f);
           
           
        }
    }
    public void Proceed()
    {
        Debug.Log("Proceed method called");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
