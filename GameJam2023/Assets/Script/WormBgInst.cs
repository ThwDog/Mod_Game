using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WormBgInst : MonoBehaviour
{
    Rigidbody2D rb;
    public float speed;

    public GameObject cam;

    public GameObject bgPrefab;
    public Transform camPo;

    public float ycount;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();   
    }

    // Update is called once per frame
    void Update()
    {
        move();
        instBG();
        cam.transform.position = new Vector3(rb.transform.position.x, rb.transform.position.y, rb.transform.position.z - 1);
        Debug.Log(camPo.position.y);
    }

    void move()
    {
        rb.velocity = new Vector2(rb.velocity.x,  speed * Time.deltaTime); 
    }

    void instBG()
    {
        ycount = camPo.position.y;
        if (ycount > 20.43f)
        {
            //StartCoroutine(setzero());
        }
    }

    IEnumerator setzero()
    {
        yield return new WaitForSeconds(20);
        Instantiate(bgPrefab, new Vector3(camPo.transform.position.x, camPo.transform.position.y, 0), Quaternion.identity);
    }
}
