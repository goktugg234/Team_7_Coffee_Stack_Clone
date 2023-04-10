using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvoidAnim : MonoBehaviour
{

    public float minPos;
    public float maxPos;

    public int animSpeed = 1;



    void Update()
    {
        //KOD ÇALIÞMIYOR. GEREKLÝ ANÝMASYON ÇALIÞMIYOR
        if (transform.localPosition.x < minPos)
        {
            //transform.Translate(transform.position.x + 1 * Time.deltaTime * animSpeed, 0, 0);
            //transform.Translate(1 * Time.deltaTime * animSpeed, 0, 0);
            transform.position += new Vector3(1 * Time.deltaTime * animSpeed, 0, 0);
        }
        if (transform.localPosition.x > maxPos)
        {
            //transform.Translate(transform.position.x + -1 * Time.deltaTime * animSpeed, 0, 0);
            //transform.Translate(-1 * Time.deltaTime * animSpeed, 0, 0);
            transform.position += new Vector3(-1 * Time.deltaTime * animSpeed, 0, 0);
        }

    }
}
