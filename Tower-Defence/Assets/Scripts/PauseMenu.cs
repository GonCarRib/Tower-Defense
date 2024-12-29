using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{

    public static bool IsGamePaused = false;

    public GameObject pauseMenuUI;

    // Update is called once per frame

    void Update(){
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(IsGamePaused)
            {
                Resume();
            }else{
                Pause();
            }
        }
    }


    void Resume()
    {
         pauseMenuUI.SetActive(false);
         Time.timeScale = 1f;
         IsGamePaused = false;
    }

    void Pause()
    {
         pauseMenuUI.SetActive(true);
         Time.timeScale = 0f;
         IsGamePaused = true;
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void Quit()
    {
        Application.Quit();
    }
}
