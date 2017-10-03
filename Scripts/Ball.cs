using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ball : MonoBehaviour {

    public float ballInitialVelocity = 600f;
    
   
    private Rigidbody rb;
    private bool ballInPlay;
    private GM gm;
    

    void Awake()
    {

        rb = GetComponent<Rigidbody>();                // Looks for rigidbody attacked on the game object. 
       
       

    }

   public void Update()
    {
        if (Input.GetButtonDown("Fire1") && ballInPlay == false)             // If the player clicks on the left mouse button and ballInPlay is false, then ballInPlay is true. 
        {                                                                   // The paddle and balls transforms are set to false allowing the ridigbody to add force in the X and Y directions. Sound will play.
            transform.parent = null;
            ballInPlay = true;
            rb.isKinematic = false;
            rb.AddForce(new Vector3(ballInitialVelocity, ballInitialVelocity, 0));
            GetComponent<AudioSource>().Play();
        }
       
}
    
        void OnTriggerEnter(Collider other)
        {
        if (other.gameObject.tag == "Wall")                             // If ball collides with Wall tag, then sound will play.
        {
            GetComponent<AudioSource>().Play();
        }
        if (other.gameObject.tag == "Paddle")                          // If ball collides with Paddle tag, then sound will play. 
        { 
            GetComponent<AudioSource>().Play();
        }
     }
}
