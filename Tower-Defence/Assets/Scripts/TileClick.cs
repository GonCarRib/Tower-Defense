using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TileClick : MonoBehaviour
{

    public Transform TilePosition; // position of the tile
    private Boolean Occupied; // if the tile has a tower or not
    private Renderer rend; //Rendere of the tile
    private Color OriginalColor; // Original color of the tile
    public float Height; //Height of the weapon



    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<Renderer>(); // gets the renderes from the tile 
        TilePosition = GetComponent<Transform>(); //  gets the transform of the tile 
        OriginalColor = rend.material.color; // gets the origina color of the tile
    }

    void OnMouseDown() // When the mouse is cllicked on the tile this function is called
    {
        if (!Occupied && UIJogador.CoinsP >= UIJogador.priceTower) // if the player has enough coins and the tile is not occupied
        {
            Occupied = true;
            Instantiate(UIJogador.Tower, new Vector3(TilePosition.position.x, TilePosition.position.y + Height, TilePosition.position.z), Quaternion.identity); // puts the turret in the tile
            UIJogador.CoinsP -= UIJogador.priceTower; // takes the cost of the tower from the player coins
        }

    }

    private void OnMouseEnter() // When mouse enters on the tile, tile goes green
    {
        if (!Occupied)
        {
            rend.material.color = Color.green;
        }
    }
    private void OnMouseExit()// When mouse exits the tile, tile goes normal original color
    {
        rend.material.color = OriginalColor;
    }

}