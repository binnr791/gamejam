using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SurfBoardRot : MonoBehaviour
{
    [Header("회전속도 조절")]
    [SerializeField][Range(1f, 100f)] float rotateSpeed = 50f;




    void Update()
    {
        Rotate();
    }
    
    void Rotate()
    {
        if (Input.GetKey(KeyCode.A))
            transform.Rotate(0, 0, Time.deltaTime * rotateSpeed, Space.Self);

        if (Input.GetKey(KeyCode.D))
            transform.Rotate(0, 0, -Time.deltaTime * rotateSpeed, Space.Self);
    }


}


