using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]

public class Hook : MonoBehaviour
{
    [SerializeField] Grabbing grabbing;
    private void OnTriggerEnter2D(Collider2D other)
    {
        GrabbableObject go = other.GetComponent<GrabbableObject>();
        if(go != null)
        {
            grabbing.Hooked();
            
        }    
    }
}
