using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // To tinker with scenes in Unity it is mandatory to use this import

public class MainMenu : MonoBehaviour{
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); // This line of code loads the next queued scene
        UIJogador.CoinsP = UIJogador.beginning_Coins;
    }

    public void QuitGame() // Quits the game
    {
        Debug.Log("Exited Game!");
        Application.Quit();
    }
}
