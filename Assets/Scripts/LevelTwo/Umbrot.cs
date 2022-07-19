using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Umbrot : MonoBehaviour
{
    public float turnSpeed = 10;

    private bool stop_rotate = false;

    void Update()
    {
        if (stop_rotate)
            return;
        Umb_Rotate();

    }

    void Umb_Rotate()
    {
        transform.Rotate(Vector3.forward, turnSpeed * Time.deltaTime);
    }

    void Stop_Umb_Rotate()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            stop_rotate = true;
        }
            
    }
}


