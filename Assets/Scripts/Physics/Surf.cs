using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]

public class Surf : MonoBehaviour
{
    new Rigidbody2D rigidbody;

    public bool isGameOver = false;

    public float horizontalSurfStartForce;
    public float verticalSurfStartForce;

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }
    
    private void FixedUpdate()
    {
        if(IsStopped())
        {
            GameOver();
        }
    }

    public void StartGame()
    {
        Vector2 forceDirection = new Vector2(horizontalSurfStartForce, verticalSurfStartForce);
        rigidbody.AddForce(forceDirection, ForceMode2D.Impulse);
    }

    private bool IsStopped()
    {
        if(rigidbody.velocity.x <= 0)
            return true;
        else
            return false;
    }

    public void GameOver()
    {
        if(!isGameOver)
        {
            isGameOver = true;
            Debug.Log("Game Over");
        }
    }
}