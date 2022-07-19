using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grabbing : MonoBehaviour
{
    // ref
    private Transform player;
    [SerializeField] public Transform hookMask;
    [SerializeField] public Transform hookLine;
    [SerializeField] private Transform hooker;

    private Vector3 newRot;

    public bool isHooked;
    public bool isHooking;
    private WaitForSeconds timeUnit;
    private int hookTime = 25;
    Vector2 hookDirection;

    private void Awake()
    {
        player = transform;
        newRot.x = 0f;
        newRot.y = 0f;
        timeUnit = new WaitForSeconds(0.016f);

        Vector3 newScale = new Vector3(1f, 1f, 1f);
        hookMask.localScale = newScale;
        isHooked = false;
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            Hook();
        }
    }

    private void Hook()
    {
        hookDirection = Input.mousePosition - Camera.main.WorldToScreenPoint(player.position);
        float degree = Mathf.Rad2Deg * Mathf.Atan2(hookDirection.y, hookDirection.x);
        hookLine.rotation = Quaternion.AngleAxis(degree, Vector3.forward);

        if(!isHooking)
            StartCoroutine("StartHook");
    }

    private IEnumerator StartHook()
    {
        Debug.Log("Hook");
        isHooking = true;

        int time = 0;
        Vector3 newScale = new Vector3(1f, 1f, 1f);
        Vector3 newHookScale = new Vector3(0f, 1f, 1f);
        while(time < hookTime)
        {
            newScale.x = newScale.x + (12f / hookTime);
            hookMask.localScale = newScale; // 시각적 요소
            // newHookScale.x = 1 / newScale.x;
            // hooker.localScale = newHookScale; // 판정 블록 움직이기

            if(isHooked)
            {
                isHooked = false;
                isHooking = false;
                break;
            }

            time += 1;
            yield return timeUnit;
        }
        hookMask.localScale = new Vector3(1f, 1f, 1f);

        isHooking = false;
    }

    public void Hooked()
    {
        isHooked = true;
        GetComponent<Rigidbody2D>().AddForce(hookDirection.normalized * 5f, ForceMode2D.Impulse);
    }
}
