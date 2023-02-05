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

        transition.SetBool("ON", false );

        yield return new WaitForSeconds(tranTime); 

        SceneManager.LoadScene(lvlIdex);
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Worm"))
        {
            GameObject.FindWithTag("Player").GetComponent<WormPlayerCon>().enabled = true;
        }
        else if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Mod"))
        {
            GameObject.FindWithTag("Player").GetComponent<PlayerCon>().enabled = true;
        }
        canvas.gameObject.SetActive(true);
        yield return new WaitForSeconds(tranTime);
        transition.SetBool("ON", true );
        PauseMenu.thisgameisPause = false;
        
    }


}
