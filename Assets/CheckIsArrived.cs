using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckIsArrived : MonoBehaviour
{
    Money money;
    void Awake()
    {
        money = FindObjectOfType<Money>();
    }
    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Temp")){
            other.gameObject.SetActive(false);
            money.isReached = true;
        }
    }
}
