using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Umbrot : MonoBehaviour
{
    public float turnSpeed = 100;

    private bool isRotate = true;

    void Update()
    {
        if (isRotate)
        {
            StartCoroutine(Umb_Rotate());
        }

        if (Input.GetKey(KeyCode.Space))
        {
            isRotate = false;
            RotCheck();
        }
 
    }

    void RotCheck()
    {
        if (!isRotate)
        {
            StopCoroutine(Umb_Rotate());
        }
    }

    private IEnumerator Umb_Rotate()
    {
        transform.Rotate(Vector3.forward, turnSpeed * Time.deltaTime);
        yield return new WaitForSecondsRealtime(1);
        
        isRotate = true;
        yield return null;
    }

}


