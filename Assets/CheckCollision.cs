using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CheckCollision : MonoBehaviour
{
    public bool isEntered = false;
    [SerializeField] GameObject mainHand;
    [SerializeField] BoxCollider boxCollider;
    [SerializeField] PlayerController playerController;

    private void Awake()
    {
        playerController = FindObjectOfType<PlayerController>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Collected"))
        {
            isEntered = true;

            if (isEntered)
            {
                boxCollider.GetComponent<BoxCollider>();
                boxCollider.enabled = false;
            }
        }

        var num = CollectController.instance.CupList.IndexOf(other.gameObject);

        if (num >= 0)
        {
            for (int i = num + 1; i < CollectController.instance.CupList.Count; i++)
            {
                var obj = CollectController.instance.CupList[i];
                CollectController.instance.CupList.RemoveAt(i);
                Destroy(obj.GetComponent<NodeMovement>());
                Destroy(obj.gameObject.GetComponent<CollectController>());
                i--;

                // Zıplat
                var randomPos = new Vector3(Random.Range(mainHand.transform.position.x - 2f, mainHand.transform.position.x), 0.67f, Random.Range(mainHand.transform.position.z -2f, mainHand.transform.position.z + 2f));
                obj.transform.DOJump(randomPos, 1f, 2, 0.5f).SetEase(Ease.OutCirc).OnComplete(() => OnJumpComplete(obj, i));
                obj.gameObject.tag = "Collectable";
            }
            
        }
    }

    private void OnJumpComplete(GameObject obj, int index)
    {
        Debug.Log("Jump complete");
        if (index > 0)
        {
            var prevObj = CollectController.instance.CupList[index - 1];
            var newPos = prevObj.transform.position + new Vector3(Random.Range(-4f,4f), 0, Random.Range(7f,14f));
            obj.transform.DOJump(newPos, 3f, 1, 1f).SetEase(Ease.OutCirc);
        }
    }
}
