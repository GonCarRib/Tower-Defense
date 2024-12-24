using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TileClick : MonoBehaviour
{
   
    public Transform posicao;
    private Boolean ocupado;

    // Start is called before the first frame update
    void Start()
    {
        posicao = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMouseDown()
    {
        if (!ocupado)
        {
            ocupado = true;
            Instantiate(UIJogador.Torre, new Vector3(posicao.position.x, posicao.position.y + 0.52f, posicao.position.z), Quaternion.identity);
        }
        
    }
}
