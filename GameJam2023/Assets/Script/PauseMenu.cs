using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool thisgameisPause = false;
    public GameObject pausemeNUUI;
    public SceneChange scene;
    public Animator transition;

    //public PlayerCon player;

    private void Start()
    {

    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.Joystick1Button7))
        {
            if (thisgameisPause)
            {
                resume();
            }
            else
            {
                pause();
            }
        }
        
    }

    public void resume()
    {
        pausemeNUUI.SetActive(false);
        Time.timeScale = 1f;
        if(SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Worm"))
        {
            GameObject.FindWithTag("Player").GetComponent<WormPlayerCon>().enabled = true;
        }
        else if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Mod"))
        {
            GameObject.FindWithTag("Player").GetComponent<PlayerCon>().enabled = true;
        }
        thisgameisPause = false;
    }
    void pause()
    {
        pausemeNUUI.SetActive(true);
        Time.timeScale = 0f;
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Worm"))
        {
        GameObject.FindWithTag("Player").GetComponent<WormPlayerCon>().enabled = false;
        }
        else if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Mod"))
        {
        GameObject.FindWithTag("Player").GetComponent<PlayerCon>().enabled = false;
        }
        thisgameisPause = true;
    }

    public void quit()
    {
        Debug.Log("Quit");
        Application.Quit();
    }

    public void loadMenu()
    {
        SceneManager.LoadScene("MainMenu");
        transition.SetBool("ON", true);

    }
}
