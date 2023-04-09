using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{
    public Rigidbody2D myRigidbody;
    public LogicManager logic;

    public float flapStrength;
    public bool birdIsAlive = true;

    float screenVerticalTopLimit = 18;
    float screenVerticalBottomLimit = -18;

    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("LogicTag").GetComponent<LogicManager>();
    }

    void Update()
    {
        moveBird();
        checkForOutOfBounds();
    }

    private void triggerGameOver()
    {
        logic.gameOver();
        birdIsAlive = false;
    }

    private void moveBird()
    {
        if (Input.GetKeyDown(KeyCode.Space) && birdIsAlive)
        {
            myRigidbody.velocity = Vector2.up * flapStrength;
        }
    }

    private void checkForOutOfBounds()
    {
        if (myRigidbody.position.y > screenVerticalTopLimit || myRigidbody.position.y < screenVerticalBottomLimit)
        {
            triggerGameOver();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        triggerGameOver();
    }
}
