using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCoffee : MonoBehaviour
{

    void Start()
    {
        
    }


    void Update()
    {
        transform.Rotate(0, 0, 300 * Time.deltaTime);
    }
}
