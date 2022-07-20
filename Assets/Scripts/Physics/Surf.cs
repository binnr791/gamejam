using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]

public class Surf : MonoBehaviour
{
    new Rigidbody2D rigidbody;
    [Header("Ref")]
    [SerializeField] public Transform backgroundParent;
    [SerializeField] public Transform groundParent;

    [Header("Prefab Ref")]
    private GameObject backgroundPrefab;
    private GameObject groundPrefab;

    [Header("State")]
    public bool isStarted  = false;
    public bool isGameOver = false;

    [Header("Other Values")]
    private float nextXPosBG;
    [SerializeField] public float backgroundUnit;
    // private float paddingX;

    [Header("Physics")]
    [SerializeField] public float horizontalSurfStartForce;
    [SerializeField] public float verticalSurfStartForce;

    [SerializeField] public float horizontalSurfHigherForce;
    [SerializeField] public float verticalSurfHigherForce;

    [SerializeField] public float horizontalSurfLowerForce;
    [SerializeField] public float verticalSurfLowerForce;

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        backgroundPrefab = Resources.Load<GameObject>("Prefabs/Environment/Background");
        groundPrefab = Resources.Load<GameObject>("Prefabs/Environment/Ground");
        nextXPosBG = backgroundUnit;
    }
    
    private void FixedUpdate()
    {
        if(isStarted && IsStopped())
        {
            GameOver();
        }

        // 이동할 때마다 배경 동적 생성
        while(transform.position.x > nextXPosBG)
        {
            GameObject bg = Instantiate(backgroundPrefab, new Vector3(nextXPosBG + 4 * backgroundUnit, 16f, 1f), Quaternion.identity);
            GameObject ground = Instantiate(groundPrefab, new Vector3(nextXPosBG + 4 * backgroundUnit, -10f, 0f), Quaternion.identity);
            bg.transform.parent = backgroundParent;
            ground.transform.parent = groundParent;
            nextXPosBG += backgroundUnit;
        }
    }

    public void SurfHigher()
    {
        Vector2 forceDirection = new Vector2(horizontalSurfHigherForce, verticalSurfHigherForce);
        rigidbody.AddForce(forceDirection, ForceMode2D.Impulse);
    }

    public void SurfLower()
    {
        Vector2 forceDirection = new Vector2(horizontalSurfLowerForce, verticalSurfLowerForce);
        rigidbody.AddForce(forceDirection, ForceMode2D.Impulse);
    }

    public void StartGame()
    {
        isStarted = true;
        Vector2 forceDirection = new Vector2(horizontalSurfStartForce, verticalSurfStartForce);
        rigidbody.AddForce(forceDirection, ForceMode2D.Impulse);
    }

    private bool IsStopped()
    {
        if(rigidbody.velocity.x <= 0)
            return true;
        else
            return false;
    }

    public void GameOver()
    {
        if(!isGameOver)
        {
            isGameOver = true;
            Debug.Log("Game Over");
        }
    }
}