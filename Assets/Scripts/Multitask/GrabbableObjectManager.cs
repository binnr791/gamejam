using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabbableObjectManager : MonoBehaviour
{
    [SerializeField] private float startCreatingObjectTime;
    [SerializeField] private float creatingObjectTimeInterval;
    private int timesCreated;

    public GameObject gullPrefab;
    public GameObject fishPrefab;

    private void Awake()
    {
        timesCreated = 2;

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
        GameObject gull = Instantiate(gullPrefab, new Vector3(2f, 4f, 0f), Quaternion.identity);
        gull.GetComponent<Rigidbody2D>().AddForce(new Vector2(-1f, -1f), ForceMode2D.Impulse);
    }
}
