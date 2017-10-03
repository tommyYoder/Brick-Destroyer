using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour {

    public float paddleSpeed = 1f;


    private Vector3 playerPos = new Vector3(0, -9.5f, 0);

    void Update()
    {
        float xPos = transform.position.x + (Input.GetAxis("Horizontal") * paddleSpeed);       // If player holds down the left or right arrow, the game will move the paddle in the horizontal directions. The paddle will be clamped at 8 or -8 X axis as well -8.5 on the Y axis.
        playerPos = new Vector3(Mathf.Clamp(xPos, -8f, 8f), -8.5f, 0f);                       // This gets updated ny the transform position when the player moves in the game.
        transform.position = playerPos;

    }
}