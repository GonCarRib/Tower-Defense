using TMPro;
using Unity.Properties;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIJogador : MonoBehaviour
{
    static public int VidasP = 100;
    static public int MoedasP = 700;
    static public int Round = 0;
    static public GameObject Torre;
    public GameObject TorreDefault;

    public TMP_Text TextoVidas;
    public TMP_Text TextoMoedas;
    public TMP_Text TextoRound;

    public static int priceTorre ;
    static public GameObject upgradePanel;



    // Start is called before the first frame update
    void Start()
    {
        Torre = TorreDefault;
        Turret turret = TorreDefault.GetComponent<Turret>();
        priceTorre = turret.price;
        upgradePanel = GameObject.FindWithTag("upgradePanel");
        upgradePanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (VidasP <= 0)
        {
            SceneManager.LoadScene("Game_Over");
        }
        else {
            TextoVidas.text = VidasP.ToString();
            TextoMoedas.text = MoedasP.ToString();
            TextoRound.text = Round.ToString();
        }
    }
}
