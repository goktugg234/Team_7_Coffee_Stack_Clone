using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public Transform target; 
    public bool moveCamera;
    public float speed = 0.1f; 

    private Vector3 offset; 

    void Update() {
        if(moveCamera)
            gameObject.SetActive(true);

        offset = transform.position - target.position; 
    }

    void LateUpdate() {
        Vector3 targetPosition = target.position + offset; 
        transform.position = Vector3.Lerp(transform.position, targetPosition, speed); 
    }

}
