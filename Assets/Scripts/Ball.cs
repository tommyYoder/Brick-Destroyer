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

        rb = GetComponent<Rigidbody>();
       
       

    }

   public void Update()
    {
        if (Input.GetButtonDown("Fire1") && ballInPlay == false)
        {
            transform.parent = null;
            ballInPlay = true;
            rb.isKinematic = false;
            rb.AddForce(new Vector3(ballInitialVelocity, ballInitialVelocity, 0));
            GetComponent<AudioSource>().Play();
        }
       
}
    
        void OnTriggerEnter(Collider other)
        {
        if (other.gameObject.tag == "Wall")
        {
            GetComponent<AudioSource>().Play();
        }
        if (other.gameObject.tag == "Paddle") 
        {
            GetComponent<AudioSource>().Play();
        }
     }
}
