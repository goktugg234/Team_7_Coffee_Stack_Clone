using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class Money : MonoBehaviour
{
    public List<GameObject> MoneyList = new List<GameObject>();
    [SerializeField] CameraMove cameraMove;
    public GameObject tempCamera;
    public bool isReached;
    float increaseRate = 1f;

    void Update()
    {
        if(isReached){
            cameraMove.moveCamera = true;
            StartCoroutine(MoneyTalks());
        }
    }
    
    public IEnumerator MoneyTalks(){
        for(int i = 0; i < MoneyList.Count; i++){
            yield return new WaitForSeconds(0.2f);
            MoneyList[i].gameObject.SetActive(true);
            gameObject.transform.position = new Vector3(MoneyList[i].transform.position.x, MoneyList[i].transform.position.y + 1f, MoneyList[i].transform.position.z);
        }
        isReached = false;
    }
}
