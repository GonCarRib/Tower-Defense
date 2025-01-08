using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{

    public static bool IsGamePaused = false; // sees if game paused

    public GameObject pauseMenuUI; // The gameObject of the Menu Ui

    // Update is called once per frame

    void Update(){
        if (Input.GetKeyDown(KeyCode.Escape)) // key where you pause the game
        {
            if(IsGamePaused) // checks if game is paused
            {
                Resume(); 
            }else{
                Pause();
            }
        }
    }


    public void Resume() // Resumes the game
    {
         pauseMenuUI.SetActive(false);
         Time.timeScale = 1f;
         IsGamePaused = false;
    }

    void Pause() // Pause the game
    {
         pauseMenuUI.SetActive(true);
         Time.timeScale = 0f;
         IsGamePaused = true;
    }

    public void LoadMenu()
    {
        Time.timeScale = 1f; // Reset time scale
        SceneManager.LoadScene("Menu");
    }

    public void Quit() // Quits Game
    {
        Application.Quit();
    }
}
