using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadZone : MonoBehaviour {

    public AudioSource WaterSound;

    void OnTriggerEnter(Collider col)
    {
        GM.instance.LoseLife();       // If Ball collides with DeadZone, then GM will take one life from the player and audio source will play. 
        WaterSound.Play();
    }
}