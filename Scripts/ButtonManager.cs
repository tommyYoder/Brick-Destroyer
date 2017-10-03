using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    public AudioSource ClickSound;

    public AudioSource MainSound;

    public void NewGameBtn(string newGameLevel)         // If player clicks on the new game button, then the game level will load to allow thr player to begin playing the game. Click sound will play and main sound will stop.
    {
        SceneManager.LoadScene(newGameLevel);           
        ClickSound.Play();
        MainSound.Stop();
    }
    public void ExitGameBtn()                        // If player clicks on the quit game button, then the game application will close. Click sound will play and main sound will stop.
    {
        ClickSound.Play();
        MainSound.Stop();
        Application.Quit();
    }
}
