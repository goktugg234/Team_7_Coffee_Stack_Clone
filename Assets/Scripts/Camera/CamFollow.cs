using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System.Collections;

public class CamFollow : MonoBehaviour
{

    public Transform target = null;

    Vector3 offset;
    public float shakeStrength = 2f;

    public bool isFinished = false;

    public Vector2 xLimit;
    public bool limitation = true;

    void Start()
    {
        offset = gameObject.transform.position - target.transform.position;
    }

    void LateUpdate()
    {
        if (target != null)
        {
            if (limitation)
            {
                transform.position = new Vector3(
                        Mathf.Clamp((target.position.x + offset.x), xLimit.x, xLimit.y),
                        target.position.y + offset.y,
                        target.position.z + offset.z
                        );
            }
            else
            {
                transform.position = new Vector3(
                        target.position.x + offset.x,
                        target.position.y + offset.y,
                        target.position.z + offset.z
                        );
            }
            if(isFinished){
                transform.position = new Vector3(
                        Mathf.Clamp((target.position.x + offset.x), xLimit.x, xLimit.y),
                        target.position.y + offset.y - 1f,
                        target.position.z + offset.z - 1f
                        );
            }
        }
    }
}