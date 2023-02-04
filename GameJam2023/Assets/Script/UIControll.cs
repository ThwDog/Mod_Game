using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIControll : MonoBehaviour
{
    [Header("HPBar")]
    public PlayerCon player;
    public GameObject[] heartPic;
    public Canvas canvas;
    public int gethit;

    [Header("item")]
    public Text item1;
    public Text item2;
    public Text item3;

    public ItemCollect item;

    void Start()
    {
        
    }

    void Update()
    {
        canvas.gameObject.SetActive(true);
        hp(gethit);
        itemUI();
    }

    public void hp(int gethit)
    {

        heartPic[gethit].SetActive(false);
    }

    void itemUI()
    {
        item1.text = item.c1.ToString() + "/" + "5";
        item2.text = item.c2.ToString() + "/" + "5";
        item3.text = item.c3.ToString() + "/" + "5";
    }
}
