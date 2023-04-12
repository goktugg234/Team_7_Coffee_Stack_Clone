using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckExit : MonoBehaviour
{
    [SerializeField] CheckCollision checkCollision;
    [SerializeField] PlayerController playerController;
    void Awake()
    {
        playerController = FindObjectOfType<PlayerController>();
        checkCollision = FindObjectOfType<CheckCollision>();
    }
    void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Collected")){
            if(checkCollision.isEntered){
                playerController.moveSpeed = 10f;
                checkCollision.isEntered = false;
            }
        }
        if(!checkCollision.isEntered)
            gameObject.SetActive(false);
    }
}
