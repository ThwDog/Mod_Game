using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIWorm : MonoBehaviour
{
    public Text time;
    public Text score;

    public WormPlayerCon player;
    public WormBgInst bgInst;
    public Canvas canvas;

    public Canvas end;
    public bool win = false;
    public Animator anim;

    [Header("TimeCount")]
    public float cTime;

    void Start()
    {
        canvas.gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        scoreTxt();
        timecount();
    }

    void scoreTxt()
    {
        score.text = "Score : " + player.score.ToString();
    }
    
    void timecount()
    {
        cTime = cTime - Time.deltaTime;


        time.text = ((int)cTime).ToString();
        if (cTime < 0 && player.score < 2500)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        else if(cTime < 0 && player.score > 2500)
        {
            win = true;
            end.gameObject.SetActive(true);
            anim.SetBool("win", true);

            canvas.gameObject.SetActive(false);
            bgInst.speed = 0;
        }
    }
}
