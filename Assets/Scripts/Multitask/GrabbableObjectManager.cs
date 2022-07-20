using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabbableObjectManager : MonoBehaviour
{
    // ref
    [SerializeField] private Transform player;

    [SerializeField] private float lastCreatedObjectTime;
    [SerializeField] private float creatingObjectTimeInterval;
    private int timesCreated;

    public GameObject gullPrefab;
    public GameObject fishPrefab;

    System.Random random;

    private void Awake()
    {
        creatingObjectTimeInterval = Random.Range(4f, 6f);
        gullPrefab = Resources.Load<GameObject>("Prefabs/Grabbable/Gull");
    }

    void Update()
    {
        if(lastCreatedObjectTime + creatingObjectTimeInterval < Time.time)
        {
            CreateGull();
            creatingObjectTimeInterval = Random.Range(4f, 6f);
            lastCreatedObjectTime = Time.time;
        }
    }

    void CreateGull()
    {
        GameObject gull = Instantiate(gullPrefab, new Vector3(player.position.x + 20f,
                                      player.position.y + 3f + Random.Range(0f, 2f), 0f), Quaternion.identity);
        // gull.GetComponent<Rigidbody2D>().AddForce(new Vector2(-1f, -1f), ForceMode2D.Impulse);
    }
}
