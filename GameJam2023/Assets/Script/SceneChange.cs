using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    public static SceneChange instance;
    public Animator transition;
    public float tranTime;

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
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(tranTime); 

        SceneManager.LoadScene(lvlIdex);
        //transition.SetTrigger("End");
    }
}
