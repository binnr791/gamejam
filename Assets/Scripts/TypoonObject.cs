using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TypoonObject : MonoBehaviour
{
    Vector2 force;
    SpriteRenderer renderer;
    float lastSpriteTime;
    float spriteTime;

    private void Awake()
    {
        force = new Vector2(1.2f, 3f);
        spriteTime = 0.35f;
        renderer = GetComponent<SpriteRenderer>();
        
    }

    private void Update()
    {
        if(spriteTime + lastSpriteTime < Time.time)
        {
            renderer.flipX = !renderer.flipX;
            lastSpriteTime = Time.time;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Destroy")
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        Debug.Log(other.gameObject);
        Surf surf = other.gameObject.GetComponent<Surf>();
        if(surf != null)
        {
            surf.GetComponent<Rigidbody2D>().AddForce(force, ForceMode2D.Force);
        }
    }
}