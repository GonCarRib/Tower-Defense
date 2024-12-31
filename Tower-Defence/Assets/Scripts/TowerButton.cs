using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TowerButton : MonoBehaviour
{
    public GameObject TowerPrefab; //Tower prefab 

    public Button button;   // Button with tower


    // Start is called before the first frame update
    void Start()
    {
        button.onClick.AddListener(TaskOnClick);  // Function TaskOnClick() doesn't work without this
    }

 
    void TaskOnClick()
    {
        UIJogador.Tower = TowerPrefab; // UIPlayer tower will be equal to current Tower 
        Turret turret = TowerPrefab.GetComponent<Turret>(); // Get the "Turret" Script
        UIJogador.priceTower = turret.price; //UIPlayer.priceTower is global variable so now all scripts know the price of the tower
    }
}
