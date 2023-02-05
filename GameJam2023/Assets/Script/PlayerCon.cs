using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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

    [Header("Heath")]
    public int maxHp = 6;
    public int currentHp;   

    public UIControll ui;

    public Animator anim;
    public bool playerDead = false;

    void Start()
    {
        PauseMenu.thisgameisPause = false;
        rb = GetComponent<Rigidbody2D>();
        currentHp = maxHp;
    }

    // Update is called once per frame
    void Update()
    {
        movement();
        jump();
        dead();
    }

    public void movement()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

        rb.velocity = new Vector2(horizontal * speed ,rb.velocity.y);
        if (Input.GetAxis("Horizontal") > 0)
        {
            anim.SetBool("walk", true);
            //Debug.Log("r");
            transform.localScale = new Vector3(0.3f, 0.3f, 0.3f);
        }
        //walk left
        if (Input.GetAxis("Horizontal") < 0)
        {
            anim.SetBool("walk", true);
            //Debug.Log("l");
            transform.localScale = new Vector3(-0.3f, 0.3f, 0.3f);
        }
        if (horizontal == 0)
        {
            anim.SetBool("walk", false);
        }

    }

    void jump()
    {
        
        if (Input.GetKey(KeyCode.Space) && canJump == true || Input.GetKey(KeyCode.Joystick1Button1) && canJump == true)
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
        if (collision.gameObject.name == "Wood")
        {            
            Destroy(collision.gameObject);
            item.c1++;
        }
        if (collision.gameObject.name == "Leaf")
        {
            Destroy(collision.gameObject);
            item.c2++;
        }
        if (collision.gameObject.name == "Clover")
        {
            Destroy(collision.gameObject); 
            item.c3++;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Floor")
        {
            floorCheck = true;
        }

        if(collision.gameObject.tag == "Enemy" && floorCheck == true)
        {
            currentHp--;
            ui.gethit++;
        }

        if (collision.gameObject.tag == "Trap")
        {
            for (int i = 0; i < 6; i++)
            {
                ui.hp(i);
                currentHp = 0;
            }
              //ui.gethit++;
            
            //currentHp = 0;
   
        }
    }

    void dead()
    {
        if (this.gameObject.transform.position.y < -6f)
        {
            for (int i = 0; i < 6; i++)
            {
                ui.hp(i);
                currentHp = 0;
            }
        }

        if (currentHp == 0)
        {
            playerDead = true;
            StartCoroutine(slowDead());
            this.gameObject.GetComponent<Renderer>().enabled = false;
            this.gameObject.GetComponent<Collider2D>().enabled = false;
            this.gameObject.GetComponent<Rigidbody2D>().gravityScale = 0;
        }

        
    }
    
    IEnumerator slowDead()
    {
        //anim.Play("");
        yield return new WaitForSeconds(2);
        playerDead = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    }

    
}
