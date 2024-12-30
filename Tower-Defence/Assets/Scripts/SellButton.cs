using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SellButton : MonoBehaviour

{
    public static GameObject Tower; // Current Tower selected

    public Button button; // Sell button

    // Start is called before the first frame update
    void Start()
    {
        button.onClick.AddListener(TaskOnClick); // Function TaskOnClick() doesn't work without this
    }



    void TaskOnClick() 
    {
        GameObject tower = Tower; // tower will be equal to current Tower 
        Turret turret = tower.GetComponent<Turret>(); // Get the "Turret" Script
        turret.SellTower(); // Use the Funcion SellTower() in the previus script to sell the tower

    }
}
