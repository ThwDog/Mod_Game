using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BgFoll : MonoBehaviour
{
    public Transform player;

    // Update is called once per frame
    void Update()
    {
        this.gameObject.transform.position = new Vector3(player.position.x, Mathf.Clamp(transform.position.y, 0, 1.3f), -5f);
    }
}
