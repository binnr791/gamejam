using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class RestartButton : MonoBehaviour
{
    [SerializeField] Surf surf;

    private void Awake()
    {
        GetComponent<Button>().onClick.AddListener(() => surf.RestartGame());
        GetComponent<Button>().onClick.AddListener(() => transform.parent.gameObject.SetActive(false));
    }
}
