using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerController : MonoBehaviour
{
    public GameObject coffee;
    public GameObject lid;

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
                Destroy(gameObject);
                break;
            case "Hand":
                other.gameObject.GetComponent<Collider>().enabled = false;
                CupManager.Instance.DestroyMe(gameObject);
                gameObject.GetComponent<NodeMovement>().enabled = false;

                gameObject.transform.position = other.transform.GetChild(3).position;
                gameObject.transform.SetParent(other.transform);

                Animator anim = other.gameObject.GetComponent<Animator>();
                //other.gameObject.GetComponent<Animator>().SetBool("isTake", true);
                anim.Play("HandTakeAnim");

                //BU KISIM ANÝMATOR ÝÇERSÝNDEN YAPILDI
                //if (!anim.GetCurrentAnimatorStateInfo(0).IsName("HandTakeAnim") && !anim.IsInTransition(0))
                //{
                //    Debug.Log("animasyon durdu");
                //    Destroy(other.gameObject);
                //}

                break;
        }
    }
}
