using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.TextCore.Text;
using UnityEngine.UI;

public class UIJogador : MonoBehaviour
{
    static public int VidasP = 150;
    static public int MoedasP = 20000;

    public TMP_Text TextoVidas;
    public TMP_Text TextoMoedas;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        TextoVidas.text = VidasP.ToString();
        TextoMoedas.text = MoedasP.ToString();

        
    }
}
