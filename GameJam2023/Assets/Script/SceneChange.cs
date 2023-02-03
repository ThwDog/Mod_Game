using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneChange : MonoBehaviour
{
    public static SceneChange instance;
    public Animator transition;
    public float tranTime;
    public Canvas canvas;

    void Awake()
    {
        instance = this;
    }

    public void levelLoad()
    {
        StartCoroutine(playAnimLvl(SceneManager.GetActiveScene().buildIndex + 1));
    }

    IEnumerator playAnimLvl(int lvlIdex)
    {
        canvas.gameObject.SetActive(false);

        transition.SetTrigger("Start");

        yield return new WaitForSeconds(tranTime); 

        SceneManager.LoadScene(lvlIdex);
        canvas.gameObject.SetActive(true);


        //transition.SetTrigger("End");
    }
}
