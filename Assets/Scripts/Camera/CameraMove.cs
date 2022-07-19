using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    [SerializeField] public GameObject player;
    private new Rigidbody2D rigidbody;
    public float lastPlayerXPos;
    public float lastPlayerYPos;

    public Vector3 newPos;

    private void Awake()
    {
        player.GetComponent<Rigidbody2D>();
        newPos.y = transform.position.y;
        newPos.z = transform.position.z;
    }

    void Update()
    {
        newPos.x = transform.position.x + (player.transform.position.x - lastPlayerXPos);
        newPos.y = transform.position.y + (player.transform.position.y - lastPlayerYPos);
        transform.position = newPos;
        lastPlayerXPos = player.transform.position.x;
        lastPlayerYPos = player.transform.position.y;
    }
}
