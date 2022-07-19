using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabbableObjectManager : MonoBehaviour
{
    // ref
    [SerializeField] private Transform player;

    [SerializeField] private float startCreatingObjectTime;
    [SerializeField] private float creatingObjectTimeInterval;
    private int timesCreated;

    public GameObject gullPrefab;
    public GameObject fishPrefab;

    System.Random random;

    private void Awake()
    {
        timesCreated = 2;
        random = new System.Random();
        gullPrefab = Resources.Load<GameObject>("Prefabs/Grabbable/Gull");
    }

    void Update()
    {
        if(startCreatingObjectTime + (creatingObjectTimeInterval * timesCreated) < Time.time)
        {
            CreateGull();
            timesCreated += 1;
        }
    }

    void CreateGull()
    {
        GameObject gull = Instantiate(gullPrefab, new Vector3(player.position.x + Random.Range(0f, 2.5f) + 9f,
                                      player.position.y + 8f + Random.Range(0f, 0.5f), 0f), Quaternion.identity);
        gull.GetComponent<Rigidbody2D>().AddForce(new Vector2(-1f, -1f), ForceMode2D.Impulse);
    }
}
