using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeButton : MonoBehaviour
{

    public static GameObject Tower; // Tower prefab

    public Button button;       // button on ui 

    // Start is called before the first frame update
    void Start()
    {
        button.onClick.AddListener(TaskOnClick);    // Function TaskOnClick() doesn't work without this
    }

    void TaskOnClick()
    {
        GameObject tower = Tower;       // gets tower
        Turret turret = tower.GetComponent<Turret>();   // gets the "Turret Script"
        if (UIJogador.CoinsP >= turret.upgradeCost){   // if the player has enough coins lets the player upgrade tower
            turret.UpgradeTower();  // calls the funcion in the script "Turret" to upgrade tower 
        }  
    }
}
