using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TileClick : MonoBehaviour
{
   
    public Transform posicao;
    private Boolean ocupado;
    private Renderer renderer;
    private Color corOriginal;
    


    // Start is called before the first frame update
    void Start()
    {
        renderer = GetComponent<Renderer>();
        posicao = GetComponent<Transform>();
        corOriginal = renderer.material.color;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMouseDown()
    {
        if (!ocupado && UIJogador.MoedasP >= UIJogador.priceTorre)
        {
            ocupado = true;
            Instantiate(UIJogador.Torre, new Vector3(posicao.position.x, posicao.position.y + 0.52f, posicao.position.z), Quaternion.identity);
            UIJogador.MoedasP -= UIJogador.priceTorre;
        }
        
    }
    private void OnMouseEnter()
    {

        if (!ocupado)
        {
            renderer.material.color = Color.green;
        }
    }
    private void OnMouseExit()
    {
        renderer.material.color = corOriginal;
    }

}
