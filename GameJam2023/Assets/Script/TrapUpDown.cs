using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapUpDown : MonoBehaviour
{
    public Transform down;
    public Transform up;

    public int speed;
    Vector3 localscale;

    bool downCheck = true;
    bool upCheck = false;

    
    Rigidbody2D rb;

    void Start()
    {
        localscale = transform.localScale;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

        if (downCheck == false)
        {
            GetComponent<Rigidbody2D>().gravityScale = 2;
        }
        else if (upCheck == false)
        {
            localscale.y = 0.6f;
            transform.localScale = localscale;
            rb.velocity = new Vector2(rb.velocity.x, localscale.y * speed);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Down")
        {
            downCheck = true;
            upCheck = false;
        }
        else if (collision.gameObject.name == "Up")
        {
            upCheck = true;
            downCheck = false;
        }
    }
}
