using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using DG.Tweening;

public class MultitaskCamera : MonoBehaviour
{
    public static MultitaskCamera instance;

    [Header("Ref")]
    [SerializeField] private Camera balanceCamera;
    [SerializeField] private Camera qteCamera;

    [SerializeField] private GameObject balanceObject;
    [SerializeField] private GameObject qteObject;

    [Header("DoTween")]
    private Sequence appearBalanceCamera;
    private Sequence appearQTECamera;

    private Sequence disableBalanceCamera;
    private Sequence disableQTECamera;

    private void Awake()
    {
        instance = this;

        appearBalanceCamera  = DOTween.Sequence();
        appearQTECamera      = DOTween.Sequence();

        disableBalanceCamera = DOTween.Sequence();
        disableQTECamera     = DOTween.Sequence();

        appearBalanceCamera.Append(balanceCamera.DORect(new Rect(-0.75f, 0.5f, 1f, 1f), 0.3f)).SetAutoKill(false);
        appearQTECamera.Append(qteCamera.DORect(new Rect(-0.75f, -0.5f, 1f, 1f), 0.3f)).SetAutoKill(false);

        disableBalanceCamera.Append(balanceCamera.DORect(new Rect(-0.75f, 0.5f, 0.75f, 1f), 0.3f)).SetAutoKill(false);
        disableQTECamera.Append(qteCamera.DORect(new Rect(-0.75f, -0.5f, 0.75f, 1f), 0.3f)).SetAutoKill(false);
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

    public void DisableBalanceCamera()
    {
        disableBalanceCamera.Restart();

        if(balanceObject != null)
        {
            balanceObject.SetActive(false);
        }
    }
    public void DisableQTECamera()
    {
        disableQTECamera.Restart();

        if(qteObject != null)
        {
            qteObject.SetActive(false);
        }
    }
}
