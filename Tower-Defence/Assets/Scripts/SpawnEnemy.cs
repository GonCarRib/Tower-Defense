using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{

    public GameObject enemy;
    static public List<GameObject> enemies = new List<GameObject>();
    
    public int numMonstros = 1;
    private bool delaySpawn = false;





    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (enemies.Count == 0 && !delaySpawn)
        {

            StartCoroutine(SpawnComDelay(numMonstros, 1f)); // Preicsa disso para spawnar um monstro de cada vez
            numMonstros += 5;
            UIJogador.Round ++;
        }
    }

    IEnumerator SpawnComDelay(int count, float tempo)
    {
        delaySpawn = true;
        yield return new WaitForSeconds(5f);

        for (int i = 0; i < count; i++)
        {
            GameObject newEnemy = Instantiate(enemy);
            enemies.Add(newEnemy);

            yield return new WaitForSeconds(tempo);
        }

        delaySpawn = false; 

    }
}