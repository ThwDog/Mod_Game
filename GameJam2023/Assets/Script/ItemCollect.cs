using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCollect : MonoBehaviour
{
    public PlayerCon player;

    [Header("ItemC")]
    public int c1;
    public int c2;
    public int c3;

    public bool pass = false;

    private void Update()
    {
        playerpass();
    }

    void playerpass()
    {
        if (c1 == 5 && c2 == 5 && c3  == 5)
        {
            pass = true;
            //Debug.Log("Passs");
        }
        nextLvl();
    }

    void nextLvl()
    {
        if(pass == true)
        {
            SceneChange.instance.levelLoad();
            pass = false;
        }
    }
    
}
