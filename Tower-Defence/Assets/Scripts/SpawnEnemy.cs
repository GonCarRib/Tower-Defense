using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{

    public GameObject enemy;

    float timer = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        float seconds = timer % 60;

        if (seconds >= 5){ 
            Instantiate(enemy);
            timer = 0.0f;
        }
        
    }
}
