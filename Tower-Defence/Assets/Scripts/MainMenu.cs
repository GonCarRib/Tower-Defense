using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //para mexer em scenes no unity é obrigatorio usar este import

public class MainMenu : MonoBehaviour{
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); // esta linha de codigo da load a proxima cena em queue 
    }

    public void QuitGame()
    {
        Debug.Log("Exited Game!");
        Application.Quit();
    }
}
