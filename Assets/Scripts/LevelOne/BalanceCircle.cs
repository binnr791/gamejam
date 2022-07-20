using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalanceCircle : MonoBehaviour
{
    public Vector3 originPos;
    public new Rigidbody2D rigidbody;

    private void Awake()
    {
        originPos = transform.position;

        rigidbody = GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Border")
        {
            transform.position = originPos;
            rigidbody.velocity = Vector2.zero;
        }
    }
}
