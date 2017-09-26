using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadZone : MonoBehaviour {

    public AudioSource WaterSound;

    void OnTriggerEnter(Collider col)
    {
        GM.instance.LoseLife();
        WaterSound.Play();
    }
}