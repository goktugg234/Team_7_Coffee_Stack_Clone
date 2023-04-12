using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using DG.Tweening;

public class TriggerController : MonoBehaviour
{
    [SerializeField] private GameObject coffee;
    public GameObject lid;
    public GameObject sleeve;
    public bool handCollected = false, isFinished = false;
    

    private void OnTriggerEnter(Collider other)
    {
        switch (other.tag)
        {
            case "Coffee":
                coffee.SetActive(true);
                break;

            case "Lid":
                coffee.SetActive(false);
                lid.SetActive(true);
                break;

            case "Obstacle":
                CupManager.Instance.DestroyMe(gameObject);
                gameObject.GetComponent<CapsuleCollider>().isTrigger=true;
                Destroy(gameObject);

                break;

            case "Hand":
                other.gameObject.GetComponent<Collider>().enabled = false;
                CupManager.Instance.DestroyMe(gameObject);
                gameObject.transform.SetParent(other.gameObject.transform.GetChild(0).GetChild(0).GetChild(2).transform);
                gameObject.transform.position = other.gameObject.transform.GetChild(0).GetChild(0).GetChild(2).transform.position;
                Destroy(gameObject.GetComponent<CapsuleCollider>());
                Destroy(gameObject.GetComponent<Rigidbody>());
                Destroy(gameObject.GetComponent<TriggerController>());
                Destroy(gameObject.GetComponent<CollectController>());
                Destroy(gameObject.GetComponent<NodeMovement>());

                Animator anim = other.gameObject.GetComponent<Animator>();
                
                anim.SetBool("TakeHand", true);
                anim.SetBool("isFinished", true);
                break;

            case "Sleeve":
                sleeve.SetActive(true);
                break;
            
            case "Collectable":
                
                other.gameObject.tag = "Collected";
                other.gameObject.AddComponent<CollectController>();
                other.GetComponent<CapsuleCollider>().isTrigger = false;
                other.gameObject.GetComponent<Rigidbody>().isKinematic = true;
                other.gameObject.AddComponent<NodeMovement>();
                var number = CollectController.instance.CupList.Count;
                other.gameObject.GetComponent<NodeMovement>().connectedNode = CollectController.instance.CupList[number - 1].transform;
                CollectController.instance.StackCups(other.gameObject, CollectController.instance.CupList.Count - 1);
            
                break;
        }
    }
}
