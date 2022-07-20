using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabbableObject : MonoBehaviour
{
    private new Rigidbody2D rigidbody;

    private void Awake()
    {
        rigidbody.GetComponent<Rigidbody2D>();
        rigidbody.AddForce(new Vector2(-1f, 0f), ForceMode2D.Impulse);
    }
}
