using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UmbrellaStick : MonoBehaviour
{
    [SerializeField] private Surf surf;
    public Umbrot rot;
    public GameObject barrier;
    public ParticleSystem blueParticle;

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("QTE") && Input.GetKey(KeyCode.W))
        {
            rot.lastBarrierActiveTime = Time.time;
            rot.barrierDuration = 3f;
            barrier.gameObject.SetActive(true);
            other.gameObject.SetActive(false);
            rot.StartCoroutine("RndAngle");
            surf.SurfHigher();

            blueParticle.transform.position = other.gameObject.transform.position;
            blueParticle.Play();
        }
    }
}
