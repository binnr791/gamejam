using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using DG.Tweening;

public class Typoon : MonoBehaviour
{
    [SerializeField] Surf surf;

    [Header("State")]
    public bool isTypoonWarned;
    public bool isTypoonCome;

    [Header("Time")]
    [SerializeField]  public float typoonStartTime; // 태풍 시작 시간
    [HideInInspector] public float lastInputTime;   // 마지막으로 스페이스바 누른 시점
    [HideInInspector] public float timeInterval;    // 스페이스바 입력 간격
    [HideInInspector] public float needInputTime;   // 이 때까지 스페이스바 입력해야 함
    public float typoonInterval;

    public int num = 1;

    [Header("Warning Tween")]
    public RectTransform typoonWarningObject;
    public RectTransform typoonMessage;
    private Sequence typoonWarningSequence;

    private void Awake()
    {
        timeInterval = 0.4f;
        isTypoonCome = false;
        isTypoonWarned = false;

        typoonStartTime = 20f;
        typoonInterval = 16f;

        // 태풍 경고문 초기화
        Tween moveDown = typoonWarningObject.DOAnchorPos(new Vector2(0f, 0f), 0.2f);

        typoonWarningSequence = DOTween.Sequence();
        typoonWarningSequence.Append(moveDown)
        .AppendInterval(0.25f)
        .AppendInterval(3f).AppendCallback(() => DecreaseWarnTime())
        .Append(typoonWarningObject.DOAnchorPos(new Vector2(0f, 75f), 0.2f))
        
        .Append(typoonMessage.DOAnchorPos(new Vector2(0f, -105f), 0.3f))
        .AppendCallback(() => ReadyTypoon())
        .AppendInterval(0.5f).AppendCallback(() => DecreaseWarnTime())
        .AppendCallback(() => StartTypoon())
        .AppendInterval(3.5f).AppendCallback(() => DecreaseWarnTime())
        .Append(typoonMessage.DOAnchorPos(new Vector2(0f, 165f), 0.3f))
        .AppendCallback(() => StopTypoon()).SetAutoKill(false);
    }

    void Update()
    {
        if(typoonStartTime + typoonInterval * num < Time.time && !isTypoonWarned) // 태풍 경고
        {
            num += 1;
            isTypoonWarned = true;
            typoonWarningSequence.Restart();
            Debug.Log("곧 태풍이 옵니다!");
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
            surf.SurfLittleLower();
        }
    }

    private void DecreaseWarnTime()
    {

    }

    private void ReadyTypoon()
    {
        MultitaskCamera.instance.DisableBalanceCamera();
        MultitaskCamera.instance.DisableQTECamera();
    }

    private void StartTypoon()
    {
        isTypoonWarned = true;
        isTypoonCome = true;
    }

    private void StopTypoon()
    {
        isTypoonWarned = false;
        isTypoonCome = false;

        MultitaskCamera.instance.AppearBalanceCamera();
        MultitaskCamera.instance.AppearQTECamera();
    }

}