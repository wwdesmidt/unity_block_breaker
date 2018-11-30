using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{

    [SerializeField] Paddle paddle1;
    [SerializeField] float xVelocity = 2f;
    [SerializeField] float yVelocity = 15f;

    Vector2 paddleToBallVector;
    Boolean launched = false;

	// Use this for initialization
	void Start ()
    {
        paddleToBallVector = transform.position - paddle1.transform.position;
	}
	
	// Update is called once per frame
	void Update ()
    {
        if(!launched)
        {
            lockBallToPaddle();
            launchOnMouseClick();
        }
        
        

    }

    private void launchOnMouseClick()
    {
        if(Input.GetMouseButton(0))
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(xVelocity, yVelocity);
            launched = true;
        }
    }

    private void lockBallToPaddle()
    {
        Vector2 paddlePos = new Vector2(paddle1.transform.position.x, paddle1.transform.position.y);
        paddlePos += paddleToBallVector;
        this.transform.position = paddlePos;
    }
}
