using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockStatus : MonoBehaviour
{
    public ItemDropData data;
    public WormPlayerCon player;

    private void Start()
    {
        player = FindAnyObjectByType<WormPlayerCon>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.tag == "Player")
        {
            player.score = player.score + data.point; 
            Destroy(gameObject);
        }

        if (collision.gameObject.tag == "Floor" && data.names == "Root")
        {
            player.score = player.score - 10;
        }
        if (collision.gameObject.tag == "Floor" && data.names == "Mat")
        {
            player.score = player.score - 20;
        }

        if (collision.gameObject.tag == "Floor")
        {
            Debug.Log("destroy");

            Destroy(this.gameObject);
        }

        
    }

    
}
