using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Mainmenu : MonoBehaviour
{
    public GameObject Starts;
    public SceneChange scene;
    public Animator transition;

    public void start()
    {
        Time.timeScale = 1f;
        PauseMenu.thisgameisPause = false;
        transition.SetBool("ON",false);

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Worm"))
        {
            GameObject.FindWithTag("Player").GetComponent<WormPlayerCon>().enabled = true;
        }
        else if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Mod"))
        {
            GameObject.FindWithTag("Player").GetComponent<PlayerCon>().enabled = true;
            
        }

        scene.levelLoad();

    }
}
