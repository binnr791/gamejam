using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// using TMPro;

public class BalanceCircle : MonoBehaviour
{
    [SerializeField] private Surf surf;
    public Vector3 originPos;
    public new Rigidbody2D rigidbody;

    public ParticleSystem redParticle;

    public float originUptime = 7f;
    public float uptime;
    [SerializeField] GameObject typoonObject;
    // TextMeshProUGUI tmpro;

    private void Awake()
    {
        originPos = transform.position;

        rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        uptime -= Time.deltaTime;
        // tmpro.text = Mathf.RoundToInt(uptime).ToString();
        if(uptime <= 0f)
        {
            uptime = originUptime;
            Instantiate(typoonObject, new Vector3(surf.transform.position.x + 20f, -2.58f, 0f), Quaternion.identity);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Border")
        {
            redParticle.transform.position = transform.position;
            redParticle.Play();

            Reposition();
            surf.SurfLower();
            uptime = originUptime;
        }
    }

    public void Reposition()
    {
        transform.position = originPos;
        rigidbody.velocity = Vector2.zero;
    }
}

