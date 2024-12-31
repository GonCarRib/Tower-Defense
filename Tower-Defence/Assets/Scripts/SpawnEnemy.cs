
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{

    static public List<GameObject> totalMonsters = new List<GameObject>(); // list of enemys
    public List<GameObject> spawnMonsters = new List<GameObject>();

    public int tier = 0;

    public int numMonsters = 1; // number of monster per wave

    private bool delaySpawn = false; //if the spawn has delay



    // Update is called once per frame
    void Update()
    {
        if (totalMonsters.Count == 0 && !delaySpawn) // if the aray of enemis is equal to 0 and(&&) the delay is equal to true spawn the "numMonsters" 
        {
            Debug.Log(numMonsters);
            StartCoroutine(SpawnWithDelay(numMonsters, 0.4f)); // Spawns one monster at a time
            numMonsters += 5; // increment the variable with 5 more
            UIJogador.Round++; // round is incremented +1
            if (UIJogador.Round >= 2)
            {
                tier = 2;
            }
            if (UIJogador.Round >= 6)
            {
                tier = 3;
            }
        }

    }




    IEnumerator SpawnWithDelay(int numMonsters, float time)
        {
            delaySpawn = true;
            yield return new WaitForSeconds(2f);

            for (int i = 0; i < numMonsters; i++)
            {
                GameObject newEnemy = Instantiate(spawnMonsters[UnityEngine.Random.Range(0, tier)]); // puts the enemy in scene
                totalMonsters.Add(newEnemy); // adds to the array 


                yield return new WaitForSeconds(time);
            }

            delaySpawn = false;

    }
}

