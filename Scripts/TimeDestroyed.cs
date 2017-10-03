using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeDestroyed : MonoBehaviour
{

    public float destroyTime = 1f;
    // Use this for initialization
    void Start()
    {
        Destroy(gameObject, destroyTime);            // Will destroy game object after destroyTime is true.
    }
}



