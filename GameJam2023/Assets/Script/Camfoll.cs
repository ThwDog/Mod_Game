using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camfoll : MonoBehaviour
{
    public Transform player;
    public Vector3 offset;
    public PlayerCon charecter;

    void Start()
    {
        this.transform.position  = player.position + offset;
    }

    // Update is called once per frame
    void Update()
    {
        //this.transform.position  = player.position - offset;
        jump();
    }

    void jump()
    {
        if(charecter.floorCheck == false)
        {
            this.transform.position = player.position - new Vector3(0,-2,1);
        }
        else
        {
            this.transform.position = player.position - offset;
        }
    }
}
