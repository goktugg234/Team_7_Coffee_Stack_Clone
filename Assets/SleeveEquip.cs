using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SleeveEquip : MonoBehaviour
{
    public Animator animator;
    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Collected")){
            animator.SetBool("Hit", true);
        }
    }
}
