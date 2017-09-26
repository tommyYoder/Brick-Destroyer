using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {

    public bool isPaused;

    public string mainMenu;

    
    

    public GameObject pauseMenuCanvas;
    public AudioSource ClickSound;

    void Update()
    {
        if (isPaused)
        {
            pauseMenuCanvas.SetActive(true);
            Time.timeScale = 0;
        }
        else
        {
            pauseMenuCanvas.SetActive(false);
            Time.timeScale = 1;
        }
        if (Input.GetKeyDown("p"))
        {
            isPaused = !isPaused;
        }
    }
    public void Resume()
    {
            ClickSound.Play();

            isPaused = false;
           
    }
    
        public void Quit()
    {
        ClickSound.Play();
        Application.Quit();
    }
}


   
   

