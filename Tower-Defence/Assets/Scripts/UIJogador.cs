using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIJogador : MonoBehaviour
{
    static public int VidasP = 1;
    static public int MoedasP = 20000;
    static public int Round = 0;
    static public GameObject Torre;
    public GameObject TorreDefault;

    public TMP_Text TextoVidas;
    public TMP_Text TextoMoedas;
    public TMP_Text TextoRound;



    // Start is called before the first frame update
    void Start()
    {
        Torre = TorreDefault;
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
