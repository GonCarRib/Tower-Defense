using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;


public class Enemy : MonoBehaviour
{

    public Transform[] wayPoints; // Waypoints that will follow throughout the scene

    public float speed; // Speed that it moves

    public int Reward = 1; //Money the player receives for killing this time of enemy

    public int Life = 1; //  How much life does the monster have
    public int damage = 1; // How much damage does the monster give

    int currentWaypoint = 0; // The current waypoint of the monster

    float currentDisplacement = 0;

    public bool spawnsOthers = false;

    public int numberOfOthers;
    
    public GameObject spawnMonster;
   


    // Start is called before the first frame update
    void Start()
    {
        wayPoints = Waypoints.points; // Associates the waypoints variable with the right points
    }

    // Update is called once per frame
    void Update()
    {
        if (Life <= 0) { 
            UIJogador.CoinsP += Reward;
            if (spawnsOthers)

            {
                for (int i = 0; i < numberOfOthers; i++) {
                    GameObject extraMonster = Instantiate(spawnMonster, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z), Quaternion.identity);
                    Enemy spawnExtraMonster = extraMonster.GetComponent<Enemy>();
                    spawnExtraMonster.pegaWaypoint(currentWaypoint);
                }
            }
            SpawnEnemy.totalMonsters.Remove(gameObject);
            Destroy(gameObject);
        } // if the monster life is equal or less than zero it dies an gives the reward to the player

        Move(currentDisplacement += speed * Time.deltaTime); // if life diferent from 0 it moves
    }

    void Move(float displacement)
    {
        if (currentWaypoint < wayPoints.Length - 1) // while the current waypoint is smaler than its length the monster moves
        {
            transform.position = wayPoints[currentWaypoint].position + currentDisplacement * (wayPoints[currentWaypoint + 1].position - wayPoints[currentWaypoint].position);
            if (currentDisplacement >= 1 && currentWaypoint <= wayPoints.Length)
            {
                currentDisplacement = 0;
                currentWaypoint++;
            }
        }
        if (currentWaypoint == wayPoints.Length -1) // if currentWaypoint is equal to its lenght it means its int the end of the track
        {
            UIJogador.LivesP -= damage; // Subtracts Monster damage from the player's health
            SpawnEnemy.totalMonsters.Remove(gameObject); // the monster is remove from the Monster[] Array in the Spwner script
            Destroy(gameObject); //the monster is destroyed
        }
    }



    public void pegaWaypoint(int _currentWaypoint)
    {
        currentWaypoint = _currentWaypoint;
    }
}
