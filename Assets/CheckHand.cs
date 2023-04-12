using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckHand : MonoBehaviour
{
    [SerializeField] PlayerController playerController;

    void Awake()
    {
        playerController = FindObjectOfType<PlayerController>();
    }
    void OnTriggerEnter(Collider other)
    {
        playerController.isGoing = false;
    }
}
