using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CheckHasCoffee : MonoBehaviour
{
    public List<GameObject> SPList = new List<GameObject>();
    void OnTriggerEnter(Collider other)

    {
        var num = CollectController.instance.CupList.Count;
        if(num > 0){
            for(int i = 1; i < num ; i++){
                GameObject tempObj = CollectController.instance.CupList[num - i].gameObject;
                CollectController.instance.CupList.Remove(tempObj);
                CollectController.instance.CupList[0].gameObject.SetActive(false);
                Destroy(tempObj.GetComponent<CapsuleCollider>());
                Destroy(tempObj.GetComponent<Rigidbody>());
                Destroy(tempObj.GetComponent<TriggerController>());
                Destroy(tempObj.GetComponent<CollectController>());
                Destroy(tempObj.GetComponent<NodeMovement>());
                tempObj.transform.DOJump(SPList[i].transform.position, 1f, 1 ,1f).SetEase(Ease.OutCirc);
            }
        }
    }
}
