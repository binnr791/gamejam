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
            transform.Rotate(Vector3.forward, turnSpeed * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.Space) && isRotate)
        {
            StartCoroutine("UmbStopRotate");
        }
 
    }

    private IEnumerator UmbStopRotate()
    {
        isRotate = false;
        yield return new WaitForSeconds(1f);
        isRotate = true;
    }
}


