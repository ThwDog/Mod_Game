using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camfoll : MonoBehaviour
{
    public Transform player;
    //public Vector3 offset;
    public PlayerCon charecter;
    public float camfollspeed;

    void Start()
    {
        //this.transform.position  = player.position + offset;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(transform.position.x, Mathf.Clamp(transform.position.y, 0, 1.3f), transform.position.z);
        Vector3 follposition = new Vector3(player.position.x, player.position.y + 2f,-1f);
        this.transform.position = Vector3.Lerp(this.transform.position,follposition,Time.deltaTime * camfollspeed);
        //this.transform.position  = player.position - offset;
        //jump();
    }

    /*void jump()
    {
        if(charecter.floorCheck == false)
        {
            camfollspeed = 5;
        }
        else
        {
            camfollspeed = 1;
        }
    }*/
}
