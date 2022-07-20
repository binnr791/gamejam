using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Umbrot : MonoBehaviour
{
    public float turnSpeed = 1000;
    public float angle;
    public float UmbAngle;

    public GameObject Umb;

    private bool isRotate = true;

    void Update()
    {
        if (isRotate)
            transform.Rotate(Vector3.forward, turnSpeed * Time.deltaTime);
            

        if (Input.GetKeyDown(KeyCode.Space) && isRotate)
        {
            StartCoroutine("RndAngle");
            StartCoroutine("UmbStopRotate");

            UmbAngle = transform.rotation.z;
        }

        if (UmbAngle > angle - 10 && UmbAngle < angle + 10)
        {
            Umb.SetActive(true);
        }
 
    }

    private IEnumerator UmbStopRotate()
    {
        isRotate = false;
        yield return new WaitForSeconds(1f);
        isRotate = true;
    }

    private IEnumerator RndAngle()
    {
        yield return new WaitForSeconds(3f);
        angle = Random.Range(0, 360);
    }
}


