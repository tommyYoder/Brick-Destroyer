using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Bricks : MonoBehaviour {


    public GameObject brickParticle;


    void OnCollisionEnter(Collision other)
    {
        Instantiate(brickParticle, transform.position, Quaternion.identity);         // If Ball collides with Bricks, then GM instantiate a particle effect before destroying that game object. 
        GM.instance.DestroyBrick();
        Destroy(gameObject);
    }
}
