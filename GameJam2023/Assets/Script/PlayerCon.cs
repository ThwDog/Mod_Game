using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCon : MonoBehaviour
{
    Rigidbody2D rb;
    float horizontal;
    float vertical;

    [Header("Movement")]
    public int speed;
    public int jPower;
    [SerializeField]
    bool canJump = true;
    [SerializeField]
    public bool floorCheck = false;

    public ItemCollect item;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        movement();
        jump();
    }

    void movement()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

        rb.velocity = new Vector2(horizontal * speed , rb.velocity.y);

        
    }

    void jump()
    {
        if (Input.GetKey(KeyCode.Space) && canJump == true)
        {
            rb.velocity = new Vector2(rb.velocity.x, vertical + jPower);         
            canJump = false;
            floorCheck = false;
            StartCoroutine(jCount());
        }
    }

    IEnumerator jCount()
    {
        yield return new WaitForSeconds(3);
        canJump = true;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Item")
        {
            Debug.Log("destroy");
            //Destroy(collision.gameObject);
            item.c1++;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Floor")
        {
            floorCheck = true;
        }
    }
}
