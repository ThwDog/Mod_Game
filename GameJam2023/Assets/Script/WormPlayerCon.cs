using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WormPlayerCon : MonoBehaviour
{
    Rigidbody2D rb;
    float horizontal;
    float vertical;

    [Header("MoveMent")]
    public int speed;

    [Header("Point")]
    public int score;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        dig();
    }

    public void dig()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

        rb.velocity = new Vector2(horizontal * speed , vertical * speed);
    }

   
}
