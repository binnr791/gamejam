using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Typoon : MonoBehaviour
{
    public bool isTypoonWarned;
    public bool isTypoonCome;

    [Header("Time")]
    [SerializeField]  public float typoonStartTime; // 태풍 시작 시간
    [HideInInspector] public float lastInputTime;   // 마지막으로 스페이스바 누른 시점
    [HideInInspector] public float timeInterval;    // 스페이스바 입력 간격
    [HideInInspector] public float needInputTime;   // 이 때까지 스페이스바 입력해야 함

    private void Awake()
    {
        timeInterval = 0.34f;
        isTypoonCome = false;
        isTypoonWarned = false;
    }

    void Update()
    {
        if(typoonStartTime - 2f < Time.time && !isTypoonWarned) // 경고
        {
            isTypoonWarned = true;
            Debug.Log("2초 뒤 태풍이 옵니다!");
        }
        if(typoonStartTime < Time.time && !isTypoonCome) // 태풍 시작
        {
            isTypoonCome = true;
            Debug.Log("태풍이 옵니다!");
        }
        if(isTypoonCome) // 태풍 - 스페이스 바 입력 체크
        {
            CheckTypoonInput();
        }
    }

    private void CheckTypoonInput()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            lastInputTime = Time.time;
            needInputTime = lastInputTime + timeInterval;
        }

        if(needInputTime < Time.time) // 입력 실패
        {
            Debug.Log("(폭풍) 스페이스 바 입력 실패");
            needInputTime = Time.time + timeInterval;
        }
    }
}