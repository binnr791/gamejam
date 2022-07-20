using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Umbrot : MonoBehaviour
{
    public float turnSpeed = 1000;
    public float angle;

    public GameObject qteBoxParent;
    public GameObject other;
    public GameObject barrier;

    private bool isRotate = true;
    public bool isSpace = true;

    public float lastBarrierActiveTime;
    public float barrierDuration;

    private void Awake()
    {
        barrier.SetActive(false);
    }

    void Update()
    {
        if (isRotate)
            transform.Rotate(Vector3.forward, turnSpeed * Time.deltaTime);
            

        if (Input.GetKeyDown(KeyCode.Space) && isSpace)
        {
            StartCoroutine("RndAngle");
            StartCoroutine("UmbStopRotate");
            StartCoroutine("SpaceClicked");
        }

        if(lastBarrierActiveTime + barrierDuration < Time.time)
        {
            barrier.SetActive(false);
        }
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
        yield return new WaitForSeconds(1.5f);
        SetQTEBoxPosRandom();
    }

    public void SetQTEBoxPosRandom()
    {
        angle = Random.Range(0, 360);
        Vector3 newRot = new Vector3(0f, 0f, angle);
        qteBoxParent.transform.rotation = Quaternion.Euler(newRot);
        other.gameObject.SetActive(true);
    }

}


