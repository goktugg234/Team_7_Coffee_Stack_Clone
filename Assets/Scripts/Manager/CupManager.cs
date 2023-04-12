using Extentions;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CupManager : MonoSingleton<CupManager>
{
    public void DestroyMe(GameObject cup)
    {
        CollectController.instance.CupList.Remove(cup);

        if( CollectController.instance.CupList.Count == 0)
        {
            Time.timeScale = 0;
            Debug.Log("game over");
        }
    }

    /*public void AddCupToListAnim()
    {
        foreach(GameObject cup in cups)
        {
            //cup.transform.DOJump(new Vector3(0, 1, 0), 2f, 1, 0.5f);
            cup.transform.DOScale(1.5f, 1f);
        }
    }*/

}
