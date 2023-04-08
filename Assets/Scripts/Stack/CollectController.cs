using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectController : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Collectable"))
        {
            other.gameObject.transform.position = transform.position + transform.right;
            other.gameObject.AddComponent<CollectController>();
            other.gameObject.GetComponent<Collider>().isTrigger = false;

            other.gameObject.AddComponent<NodeMovement>();

            

            //other.gameObject.GetComponent<NodeMovement>().connectedNode = transform; 
            other.gameObject.GetComponent<NodeMovement>().connectedNode = CupManager.Instance.cups[CupManager.Instance.cups.Count - 1].transform;

            CupManager.Instance.cups.Add(other.gameObject);





            other.gameObject.tag = "Collected";
            //other.transform.SetParent(transform.root);
            //Destroy(gameObject.GetComponent<CollectController>());

        }
    }
}
