using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MovementChar : MonoBehaviour
{
    public float speed;
    private float horizontalMove;
    private bool moveRight;
    private bool moveLeft;
    private Rigidbody2D rb;
    public float jumpSpeed = 5;
    private Animator anim;
    private SpriteRenderer spriteRenderer;

    
    private Vector3 respawnPoint;
    public GameObject fallDetector;
    public GameObject youWon;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        moveLeft = false;
        moveRight = false;
        anim = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        respawnPoint = transform.position;
    }
    private void ShowGameOverUI()
    {
        youWon.SetActive(true); // Set the reference to your "Game Over" UI element here
        Time.timeScale = 0f; // Pause the game by setting time scale to 0
    }
 
    void Update()
    {
        Movement();

       
       
        fallDetector.transform.position = new Vector2(transform.position.x,fallDetector.transform.position.y);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "FallDetector")
        {
            // Reset the object's position to the respawn point
            transform.position = respawnPoint;
        }
        if (collision.gameObject.CompareTag("FinishLine"))
        {
            ShowGameOverUI();
        }     
    }
    public void Proceed()
    {
        SceneManager.LoadScene("Lvl2");
    }
    public void pointerDownLeft()
    {
        transform.rotation = Quaternion.Euler(0, 180, 0);
        moveLeft = true;
        anim.SetBool("running", true); // Start running animation when moving left
       
    }

    public void pointerUpLeft()
    {
        moveLeft = false;
        anim.SetBool("running", false); // Stop running animation when not moving left
    }

    public void pointerDownRight()
    {
        
        transform.rotation = Quaternion.Euler(0, 0, 0);
        moveRight = true;
        anim.SetBool("running", true); // Start running animation when moving right
       
    }

    public void pointerUpRight()
    {
        moveRight = false;
        anim.SetBool("running", false); // Stop running animation when not moving right
    }

    void Movement()
    {
        if (moveLeft)
        {
            horizontalMove = -speed;
        }
        else if (moveRight)
        {
            horizontalMove = speed;
        }
        else
        {
            horizontalMove = 0;
        }
    }

    public void jumpButton()
    {
        Debug.Log("Jump button clicked");
        if (rb.velocity.y == 0)
        {
            rb.velocity = Vector2.up * jumpSpeed;
        }
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontalMove, rb.velocity.y);
    }
}
