using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    [SerializeField] float screenWidthInUnits = 16f;
    [SerializeField] float minPos = 0f;
    [SerializeField] float maxPos = 16f;

    private Ball myBall;
    private GameStatus myGameStatus;

    private void Start()
    {
        myBall = FindObjectOfType<Ball>();
        myGameStatus = FindObjectOfType<GameStatus>();
    }

    void Update ()
    {

        Vector2 paddlePos = new Vector2(Mathf.Clamp(getXPos(),minPos,maxPos), transform.position.y);

        transform.position = paddlePos;

	}

    private float getXPos()
    {
        if(myGameStatus.isAutoPlayEnabled())
        {
            return myBall.transform.position.x;
        }
        else
        {
            return (Input.mousePosition.x / Screen.width) * screenWidthInUnits;
        }
    }
}
