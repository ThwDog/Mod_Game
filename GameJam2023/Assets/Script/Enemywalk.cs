using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemywalk : MonoBehaviour
{
    public Transform left;
    public Transform right;

    public int speed;
    Vector3 localscale;

    bool leftCheck = true;
    bool rightCheck = false;

    bool dead = false;
    //public Animation anim;

    public PlayerCon player;

    Rigidbody2D rb;

    private void Start()
    {
        localscale = transform.localScale;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (leftCheck == false)
        {
            localscale.x = -1.66f;
            transform.localScale = localscale;
            rb.velocity = new Vector2(localscale.x *speed , rb.velocity.y);
        }
        else if(rightCheck == false)
        {
            localscale.x = 1.66f;
            transform.localScale = localscale;
            rb.velocity = new Vector2(localscale.x * speed, rb.velocity.y);
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Left")
        {
            leftCheck = true;
            rightCheck = false;
        }
        else if (collision.gameObject.name == "Right")
        {
            rightCheck = true;
            leftCheck = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player" && player.floorCheck == false)
        {
            dead = true;
            if(dead == true)
            {
                speed = 0;
                this.gameObject.GetComponent<Animator>().enabled = false;
                //this.gameObject.GetComponent<Rigidbody2D>().position = Vector3.zero;
            }
            //เล่นท่าตาย

            StartCoroutine(playEnemyDead());

        }
    }

    IEnumerator playEnemyDead()
    {
        yield return new WaitForSeconds(2);
        Destroy(gameObject);
        Debug.Log("Kudead");
        dead = false;
    }
}
