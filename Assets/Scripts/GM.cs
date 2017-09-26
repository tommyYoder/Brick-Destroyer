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
        
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);
        bricksPrefab.SetActive(true);
        bricksPrefab1.SetActive(false);
        bricksPrefab2.SetActive(false);
        bricksPrefab3.SetActive(false);
        bricksPrefab4.SetActive(false);
        MainSound.Play();

        Setup();
    }
  
    

    public void Setup()
    {
        clonePaddle = Instantiate(paddle, transform.position, Quaternion.identity) as GameObject;
        bricksPrefab.SetActive(true);
        Instantiate(bricksPrefab, transform.position, Quaternion.identity);
      

    }

    void CheckGameOver()
    {
        if (bricks < 1)
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
        if (bricks1 < 1)
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
        if(bricks2 < 1)
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
        if(bricks3 < 1)
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
        if(bricks4 < 1)
        {
            youWon.SetActive(true);
            YouWinSound.Play();
            MainSound.Stop();
            Time.timeScale = .25f;
            Invoke("Reset", resetDelay);
        }
        if (lives < 1)
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
        if (gameOver)
        {
            Invoke("Reset", resetDelay);
            Time.timeScale = 1f;
            Application.LoadLevel(Application.loadedLevel);
            GameOverSound.Stop();
            MainSound.Play();
            bricksPrefab.SetActive(true);
        }
        if(bricks < 1)
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
       
        if (bricks1 < 1)
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
        if(bricks2 < 1)
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
        if(bricks3 < 1)
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
        if(bricks4 < 1)
        {
            Invoke("Reset", resetDelay);
            Time.timeScale = 1f;
            Application.LoadLevel(Application.loadedLevel);
            bricksPrefab.SetActive(true);
            YouWinSound.Stop();
            MainSound.Play();
        }
       

    }

    public void LoseLife()
    {
        lives--;
        livesText.text = "Lives: " + lives;
        Instantiate(deathParticles, clonePaddle.transform.position, Quaternion.identity);
        Destroy(clonePaddle);
        BrickSound.Play();
        Invoke("SetupPaddle", resetDelay);
        CheckGameOver();
    }

    void SetupPaddle()
    {
        clonePaddle = Instantiate(paddle, transform.position, Quaternion.identity) as GameObject;
     
    }

    public void DestroyBrick()
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
