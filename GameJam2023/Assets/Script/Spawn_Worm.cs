using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn_Worm : MonoBehaviour
{
    [Header("Spawn")]
    public GameObject[] instobj;
    public float countDown;
    public float nextSpawn;

    [Header("X Spawn Range")]
    public float xMin;
    public float xMax;


    [Header("Y Spawn Range")]
    public float yMin;
    public float yMax;

    Rigidbody2D rb;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        countDown -= Time.deltaTime;
        if (countDown <= 0)
        {
            spawner();
            countDown = nextSpawn;
        }
    }

    void spawner()
    {
        Vector2 pos = new Vector2(Random.Range(xMin, xMax), Random.Range(yMin, yMax));

        GameObject itemPrefab = instobj[Random.Range(0, instobj.Length)];

        Instantiate(itemPrefab, pos, Quaternion.identity, transform);
    }
}
