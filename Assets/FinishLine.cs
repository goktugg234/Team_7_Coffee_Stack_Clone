using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishLine : MonoBehaviour
{
    [SerializeField] PlayerController playerController;
    [SerializeField] TriggerController triggerController;
    [SerializeField] CamFollow camFollow;

    void Awake()
    {
        playerController = FindObjectOfType<PlayerController>();
        triggerController = FindObjectOfType<TriggerController>();
        camFollow = FindObjectOfType<CamFollow>();
    }
    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Collected")){
            playerController.moveSpeed = 6f;
            playerController.isFinished = true;
            triggerController.isFinished = true;
            camFollow.isFinished=true;
        }
    }
}