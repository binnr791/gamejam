using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UmbrellaStick : MonoBehaviour
{
    public Umbrot rot;
    public GameObject barrier;

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("QTE") && Input.GetKey(KeyCode.Space))
        {
            rot.lastBarrierActiveTime = Time.time;
            rot.barrierDuration = 3f;
            barrier.gameObject.SetActive(true);
            other.gameObject.SetActive(false);
            rot.StartCoroutine("RndAngle");
        }
    }
}
