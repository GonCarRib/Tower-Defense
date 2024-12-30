using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{

    public GameObject enemy; // Prefab of the enemy we going to spawn
    static public List<GameObject> enemies = new List<GameObject>(); // list of enemys
    
    public int numMonsters = 1; // number of monster per wave

    private bool delaySpawn = false; //if the spawn has delay






    // Update is called once per frame
    void Update()
    {
        if (enemies.Count == 0 && !delaySpawn) // if the aray of enemis is equal to 0 and(&&) the delay is equal to true spawn the "numMonsters" 
        {
            StartCoroutine(SpawnComDelay(numMonsters, 1f)); // Spawns one monster at a time
            numMonsters += 5; // increment the variable with 5 more
            UIJogador.Round ++; // round is incremented +1
        }
    }

    IEnumerator SpawnComDelay(int count, float tempo) 
    {
        delaySpawn = true;
        yield return new WaitForSeconds(5f);

        for (int i = 0; i < count; i++)
        {
            GameObject newEnemy = Instantiate(enemy); // puts the enemy in scene
            enemies.Add(newEnemy);                    // adds to the array 

            yield return new WaitForSeconds(tempo);   
        }

        delaySpawn = false; 

    }
}