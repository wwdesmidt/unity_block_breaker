using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    [SerializeField] float screenWidthInUnits = 16f;
    [SerializeField] float minPos = 0f;
    [SerializeField] float maxPos = 16f;

	void Update ()
    {
        float mouseX = (Input.mousePosition.x / Screen.width) * screenWidthInUnits;
        Vector2 paddlePos = new Vector2(Mathf.Clamp(mouseX,minPos,maxPos), transform.position.y);

        transform.position = paddlePos;

	}
}
