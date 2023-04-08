using DG.Tweening;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
public class CamFollow : MonoBehaviour
{

    public Transform target = null;

    Vector3 offset;
    public float shakeStrength = 2f;

    public bool isShake;

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
        }
    }

    public void Shake()
    {
        if (isShake)
        {
            transform.GetChild(0).DOShakePosition(1f, shakeStrength, fadeOut: true);
            return;
        }
    }

}
