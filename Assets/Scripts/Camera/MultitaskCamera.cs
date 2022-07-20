using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using DG.Tweening;

public class MultitaskCamera : MonoBehaviour
{
    [Header("Ref")]
    [SerializeField] private Camera balanceCamera;
    [SerializeField] private Camera qteCamera;

    [SerializeField] private GameObject balanceObject;
    [SerializeField] private GameObject qteObject;

    [Header("DoTween")]
    private Sequence appearBalanceCamera;
    private Sequence appearQTECamera;

    private void Awake()
    {
        appearBalanceCamera = DOTween.Sequence();
        appearQTECamera     = DOTween.Sequence();

        appearBalanceCamera.Append(balanceCamera.DORect(new Rect(-0.75f, 0.5f, 1f, 1f), 0.3f));
        appearQTECamera.Append(qteCamera.DORect(new Rect(-0.75f, -0.5f, 1f, 1f), 0.3f));
    }

    public void AppearBalanceCamera()
    {
        appearBalanceCamera.Restart();

        if(balanceObject != null)
        {
            balanceObject.SetActive(true);
        }
    }

    public void AppearQTECamera()
    {
        appearQTECamera.Restart();

        if(qteObject != null)
        {
            qteObject.SetActive(true);
        }
    }
}