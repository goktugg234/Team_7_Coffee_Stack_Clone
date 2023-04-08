using Extentions;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CupManager : MonoSingleton<CupManager>
{

    public List<GameObject> cups = new List<GameObject>();


    public void DestroyMe(GameObject cup)
    {
        cups.Remove(cup);

        if(cups.Count == 0)
        {
            Time.timeScale = 0;
            Debug.Log("game over");
        }
    }

    public void AddCupToListAnim()
    {
        foreach(GameObject cup in cups)
        {
            //cup.transform.DOJump(new Vector3(0, 1, 0), 2f, 1, 0.5f);
            cup.transform.DOLocalMoveY(1, 1f);
        }
    }


}
