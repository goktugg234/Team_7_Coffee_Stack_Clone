using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CollectController : MonoBehaviour
{
    public List<GameObject> CupList = new List<GameObject>();
    public float waveDelay = 0.25f;
    public static CollectController instance;
    void Awake()
    {
        DOTween.SetTweensCapacity(10000,2000);
        if(instance == null){
            instance = this;
        }
    }
    public void StackCups(GameObject other, int index){
        CupList.Add(other.gameObject);
        StartCoroutine(MakeWave());
    }
    private IEnumerator MakeWave(){
        for(int i = CupList.Count - 1; i > 0; i--){
            int index = i;
            Vector3 scaleSize = new Vector3(1,1,1);
            scaleSize *= 1.5f;
            CupList[index].transform.DOScale(scaleSize, 0.1f).OnComplete(() => 
            CupList[index].transform.DOScale(new Vector3(1,1,1), 0.1f));
            yield return new WaitForSeconds(0.05f);
        }
    }
}
