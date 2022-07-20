using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Umbrot : MonoBehaviour
{
    public float turnSpeed = 1000;
    public float angle;
    public float UmbAngle;

    public GameObject Umb;
    public GameObject other;
    public GameObject barrier;

    private bool isRotate = true;
    private bool isSpace = true;

    void Update()
    {
        if (isRotate)
            transform.Rotate(Vector3.forward, turnSpeed * Time.deltaTime);
            

        if (Input.GetKeyDown(KeyCode.Space) && isRotate)
        {
            StartCoroutine("RndAngle");
            StartCoroutine("UmbStopRotate");
            StartCoroutine("SpaceClicked");

            UmbAngle = transform.rotation.z;
        }

        barrier.SetActive(false);
 
    }

    private IEnumerator UmbStopRotate()
    {
        isRotate = false;
        yield return new WaitForSeconds(1f);
        isRotate = true;
    }

    private IEnumerator SpaceClicked()
    {
        isSpace = false;
        yield return new WaitForSeconds(1f);
        isSpace = true;
    }

    private IEnumerator RndAngle()
    {
        yield return new WaitForSeconds(3f);
        angle = Random.Range(0, 360);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        if (other.gameObject.CompareTag("QTE"))
        {
            if (isSpace)
            {
                other.gameObject.SetActive(false);
                barrier.gameObject.SetActive(true);
            }
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        
    }
}


