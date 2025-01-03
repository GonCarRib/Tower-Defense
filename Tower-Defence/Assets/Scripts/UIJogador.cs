using System;
using TMPro;
using Unity.Properties;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIJogador : MonoBehaviour
{
    static public int LivesP = 100; // lives of the player
    static public int CoinsP = 0;  // Coins of the player 
    static public int beginning_Coins = 1000;   // begginning_Coins
    static public int Round = 0;    //Round number
    static public GameObject Tower; //Select tower 
    public GameObject DefaultTower; // Default tower
    static public Boolean RecebeuDinheiro = false;  
    public AudioSource Moneysound;
   

    public TMP_Text Text_Lives; // lives text
    public TMP_Text Text_Coins; // Coins Text
    public TMP_Text TextRound; // Round Text

    public static int priceTower;   //Tower price
    static public GameObject upgradePanel;  //upgrade panel
    static public GameObject selectedIcon;  // selected icon





    // Start is called before the first frame update
    void Start()
    {
        
        CoinsP = beginning_Coins;   //Player coins get initialized
        Tower = DefaultTower;       
        Turret turret = DefaultTower.GetComponent<Turret>(); // Gets "Turret" Script
        priceTower = turret.price;  // receives price of the tower from the "Turret" Script 
        upgradePanel = GameObject.FindWithTag("upgradePanel");  // find upgrade panel
        upgradePanel.SetActive(false);  
        selectedIcon = GameObject.FindWithTag("Selected");  //finds the icon to put int he top of  the towers
        selectedIcon.SetActive(false);  
    }

    // Update is called once per frame
    void Update()
    {
        if (LivesP <= 0)
        {
            SceneManager.LoadScene("Game_Over"); // if player loses goes to scene "Game_Over"
        }
        else {
            Text_Lives.text = LivesP.ToString();    // updates all player information
            Text_Coins.text = CoinsP.ToString();    // updates all player information
            TextRound.text = Round.ToString();      // updates all player information
        }

        if (RecebeuDinheiro) { 
            Moneysound.Play();
            RecebeuDinheiro = false; 
        }

    }
}
