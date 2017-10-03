using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GM : MonoBehaviour {

    public int lives = 3;
    
    public int bricks = 9;
    public int bricks1 = 12;
    public int bricks2 = 16;
    public int bricks3 = 24;
    public int bricks4 = 30;

    public float resetDelay = 1f;
   
    public Text livesText;
    public Text scoreText;
    public GameObject gameOver;
    public GameObject youWon;
    public GameObject bricksPrefab;
  
    public GameObject paddle;
    public GameObject bricksPrefab1;
    public GameObject bricksPrefab2;
    public GameObject bricksPrefab3;
    public GameObject bricksPrefab4;

    public GameObject deathParticles;
    public static GM instance = null;

    public AudioSource BrickSound;
    public AudioSource BallSound;
    public AudioSource GameOverSound;
    public AudioSource MainSound;
    public AudioSource YouWinSound;
    
    private GameObject clonePaddle;
  



    // Use this for initialization
    void Awake()
    {
        
        if (instance == null)                           // Looks to see if only one GM is in the level. If more than one they will be destroyed from the game level. 
            instance = this;
        else if (instance != this)
            Destroy(gameObject);

        bricksPrefab.SetActive(true);                  //BrickPrefab is set to true.
        bricksPrefab1.SetActive(false);                //BrickPrefab is set to false.
        bricksPrefab2.SetActive(false);                //BrickPrefab is set to false.
        bricksPrefab3.SetActive(false);                //BrickPrefab is set to false.
        bricksPrefab4.SetActive(false);                //BrickPrefab is set to false.
        MainSound.Play();

        Setup();                                      // SetUp will begin.
    }
  
    

    public void Setup()                              // This wil instantiate the paddle, allow the brickbrefab to be true, and instantiate the bricks on the stage. 
    {
        clonePaddle = Instantiate(paddle, transform.position, Quaternion.identity) as GameObject;
        bricksPrefab.SetActive(true);
        Instantiate(bricksPrefab, transform.position, Quaternion.identity);
      

    }

    void CheckGameOver()                          // Checks for Game Over
    {
        if (bricks < 1)                          // If bricks is less than one, then first set of bricks are false and new bricks ar true. Brick variables are adjusted to allow that sequence to play out. Lives are added in by one and updated to the live text UI.
        {
            bricksPrefab.SetActive(false);
            bricksPrefab1.SetActive(true);
            Instantiate(bricksPrefab1, transform.position, Quaternion.identity);
            bricks = 15;
            bricks1 = 12;
            bricks2 = 16;
            bricks3 = 22;
            bricks4 = 30;
            lives++;
            livesText.text = "Lives: " + lives;
        }
        if (bricks1 < 1)                     // If bricks is less than one, then first set of bricks are false and new bricks ar true. Brick variables are adjusted to allow that sequence to play out. Lives are added in by one and updated to the live text UI.
        {
            bricksPrefab1.SetActive(false);
            bricksPrefab2.SetActive(true);
            Instantiate(bricksPrefab2, transform.position, Quaternion.identity);
            bricks = 18;
            bricks1 = 18;
            bricks2 = 16;
            bricks3 = 22;
            bricks4 = 30;
            lives++;
            livesText.text = "Lives: " + lives;
        }
        if(bricks2 < 1)                   // If bricks is less than one, then first set of bricks are false and new bricks ar true. Brick variables are adjusted to allow that sequence to play out. Lives are added in by one and updated to the live text UI.
        {
            bricksPrefab2.SetActive(false);
            bricksPrefab3.SetActive(true);
            Instantiate(bricksPrefab3, transform.position, Quaternion.identity);
            bricks = 26;
            bricks1 = 26;
            bricks2 = 26;
            bricks3 = 24;
            bricks4 = 30;
            lives++;
            livesText.text = "Lives: " + lives;
        }
        if(bricks3 < 1)                  // If bricks is less than one, then first set of bricks are false and new bricks ar true. Brick variables are adjusted to allow that sequence to play out. Lives are added in by one and updated to the live text UI.
        {

            bricksPrefab3.SetActive(false);
            bricksPrefab4.SetActive(true);
            Instantiate(bricksPrefab4, transform.position, Quaternion.identity);
            bricks = 32;
            bricks1 = 32;
            bricks2 = 32;
            bricks3 = 32;
            bricks4 = 30;
            lives++;
            livesText.text = "Lives: " + lives;
        }
        if(bricks4 < 1)                    // if bricks is less than one, then you win is set to true, main sound stops, new sound plays, time scale is set to .25 before reset delay is set to true.
        {
            youWon.SetActive(true);
            YouWinSound.Play();
            MainSound.Stop();
            Time.timeScale = .25f;
            Invoke("Reset", resetDelay);
        }
        if (lives < 1)                     // If lives is less than one, then game over is set to true, main sound stops, new sound plays, time scale goes to .25 before reset delay is true. 
        {
            gameOver.SetActive(true);
            GameOverSound.Play();
            MainSound.Stop();
            Time.timeScale = .25f;
            Invoke("Reset", resetDelay);
           
        }
     

    }

    void Reset()
    {
        if (gameOver)                       // If reset delay ocurs, then time scale returns to 1, level is reloaded, game over sound stops, main sound plays, and brick prefab is set to true again.
        {
            Invoke("Reset", resetDelay);
            Time.timeScale = 1f;
            Application.LoadLevel(Application.loadedLevel);
            GameOverSound.Stop();
            MainSound.Play();
            bricksPrefab.SetActive(true);
        }
        if(bricks < 1)                        // If bricks is less than one, then first set of bricks are false and new bricks ar true. Brick variables are adjusted to allow that sequence to play out. Lives are added in by one and updated to the live text UI.
        {
            bricksPrefab.SetActive(false);
            bricksPrefab1.SetActive(true);
            Instantiate(bricksPrefab1, transform.position, Quaternion.identity);
            bricks = 15;
            bricks1 = 12;
            bricks2 = 16;
            bricks3 = 23;
            bricks4 = 30;
            lives++;
            livesText.text = "Lives: " + lives;

        }
       
        if (bricks1 < 1)                     // If bricks is less than one, then first set of bricks are false and new bricks ar true. Brick variables are adjusted to allow that sequence to play out. Lives are added in by one and updated to the live text UI.
        {
            bricksPrefab1.SetActive(false);
            bricksPrefab2.SetActive(true);
            Instantiate(bricksPrefab2, transform.position, Quaternion.identity);
            bricks = 18;
            bricks1 = 18;
            bricks2 = 16;
            bricks3 = 22;
            bricks4 = 30;
            lives++;
            livesText.text = "Lives: " + lives;
        }
        if(bricks2 < 1)                  // If bricks is less than one, then first set of bricks are false and new bricks ar true. Brick variables are adjusted to allow that sequence to play out. Lives are added in by one and updated to the live text UI.
        {
            bricksPrefab2.SetActive(false);
            bricksPrefab3.SetActive(true);
            Instantiate(bricksPrefab3, transform.position, Quaternion.identity);
            bricks = 26;
            bricks1 = 26;
            bricks2 = 26;
            bricks3 = 24;
            bricks4 = 30;
            lives++;
            livesText.text = "Lives: " + lives;
        }
        if(bricks3 < 1)               // If bricks is less than one, then first set of bricks are false and new bricks ar true. Brick variables are adjusted to allow that sequence to play out. Lives are added in by one and updated to the live text UI.
        {
            bricksPrefab3.SetActive(false);
            bricksPrefab4.SetActive(true);
            Instantiate(bricksPrefab4, transform.position, Quaternion.identity);
            bricks = 32;
            bricks1 = 32;
            bricks2 = 32;
            bricks3 = 32;
            bricks4 = 30;
            lives++;
            livesText.text = "Lives: " + lives;
        }
        if(bricks4 < 1)              // if bricks is less than one, then you win is set to true, main sound stops, new sound plays, time scale is set to .25 before reset delay is set to true.
        {
            Invoke("Reset", resetDelay);
            Time.timeScale = 1f;
            Application.LoadLevel(Application.loadedLevel);
            bricksPrefab.SetActive(true);
            YouWinSound.Stop();
            MainSound.Play();
        }
       

    }

    public void LoseLife()          // If you collide with DeadZone, then you lose a life, particle effect is instantiated, paddle is destroyed, reset delay is invoked, and game ove is checked.
    {
        lives--;
        livesText.text = "Lives: " + lives;
        Instantiate(deathParticles, clonePaddle.transform.position, Quaternion.identity);
        Destroy(clonePaddle);
        BrickSound.Play();
        Invoke("SetupPaddle", resetDelay);
        CheckGameOver();
    }

    void SetupPaddle()           // Will instantiate a clone paddle after reset delay is true.
    {
        clonePaddle = Instantiate(paddle, transform.position, Quaternion.identity) as GameObject;
     
    }

    public void DestroyBrick()   // Bricks are destroyed by one along with an audio source playing each time. Will check to see if game over is true.
    {
        bricks--;
        bricks1--;
        bricks2--;
        bricks3--;
        bricks4--;
        BrickSound.Play();
        BallSound.Play();
        CheckGameOver();
    }
     
}
