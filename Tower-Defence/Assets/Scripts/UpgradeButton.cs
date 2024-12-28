using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeButton : MonoBehaviour
{

    public static GameObject Tower;

    public Button button;

    // Start is called before the first frame update
    void Start()
    {
        button.onClick.AddListener(TaskOnClick);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void TaskOnClick()
    {
        GameObject tower = Tower;
        Turret turret = tower.GetComponent<Turret>();
        if (UIJogador.MoedasP >= turret.upgradeCost) {
            turret.UpgradeTower(); 
        }  
    }
}
