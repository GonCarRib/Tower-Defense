using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;
using UnityEngine.UI;
using UnityEngine.UIElements;



public class Turret : MonoBehaviour {

    public Transform target; // targer its atacking
    public float range = 15f; // Range of the turret

    public int Damage = 0; // damage of the turret
    public int price = 0; // price of the turret

    public string monstroTag = "Monstro"; // Monster Tag

    public Transform Pivot; // Pivot where the upper part of the tower is going to rotate
    public float turnSpeed = 10f; // Trurn speed of the turret

    public float fireRate = 1f; // Fire Rate of the turret
    private float fireCountdown = 0f; // time to fire

    public GameObject prefabBullet; // prefab of the bullet
    public Transform firePoint;     // Where the bullet is gonna come out
    public int upgradeCost; // Upgrade Cost
    public GameObject prefabUpgrade; // Prefab  of the upgrade
    public int sellCost;  // SellCost
    



    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("NewTarget", 0f, 0.5f); // Invokes the funcion NewTarget
        
    }

    void NewTarget() // Finds a new target
    {
        GameObject[] monstros = GameObject.FindGameObjectsWithTag(monstroTag); // Array with all monsters 
        float shortestDistance = Mathf.Infinity;  // shortestDistance
        GameObject NextMonster = null;      // next Monster
        foreach (GameObject monster in monstros) 
        {
            float distanceMonster = Vector3.Distance(transform.position, monster.transform.position); // Distance to monster
            if (distanceMonster < shortestDistance) 
            {
                shortestDistance = distanceMonster; // Shortest Distace to monster = to distance to Monster
                NextMonster = monster; 
            }
        }

        if (NextMonster != null && shortestDistance <= range) // target = null when theres no new monster and(&&) shortestDistance dosent find nothing in range
        {
            target = NextMonster.transform;
        }
        else
        {
            target = null;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (target == null) { 
            return; 
        }// if target == null exits funcion
          

        Vector3 dir = target.position - transform.position; // direction to look
        Quaternion lookRotation = Quaternion.LookRotation(dir); 
        Vector3 rotation = Quaternion.Lerp(Pivot.rotation, lookRotation, Time.deltaTime * turnSpeed).eulerAngles; 
        Pivot.rotation = Quaternion.Euler(0f, rotation.y, 0f); // looks to direction 

        if (fireCountdown <= 0f) {  // Controls the fire rate +/-
            Shoot();    // Shoots
            fireCountdown = 1f / fireRate; // Controlos the fire rate
        }
       
        fireCountdown -= Time.deltaTime;    
    }

    void Shoot() {
        GameObject bulletGo = Instantiate(prefabBullet, firePoint.position, firePoint.rotation) as GameObject; // creates a bullet and gives it to object bulletGo

        Bullet bullet = bulletGo.GetComponent<Bullet>(); // Get the "Bullet" script from the object bulletGo

        if (bullet != null) {   // if bullet diferent(!=) from null does damage to target and seeks target 
            bullet.Dano(Damage);    // says how much damage the bullet is going to give to the "Bullet" script
            bullet.Seek(target);    // seeks target
        }
    }

    void OnDrawGizmosSelected()// creates a red area on the inpector to show the range of the turret
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }

    void OnMouseDown()
    {
        UpgradeButton.Tower = gameObject;   //upgrade button
        SellButton.Tower = gameObject;      //sell button
        UIJogador.upgradePanel.SetActive(true); // makes the upgrade/sell panel visibel  
        UIJogador.selectedIcon.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + 2.5f, gameObject.transform.position.z- 0.4f); // makes the a green icon appear in the top of the turret
        UIJogador.selectedIcon.SetActive(true); // makes the icon appear
        
    }

    public void UpgradeTower() {
        UIJogador.selectedIcon.SetActive(false);    //makes the icon disappear 
        UIJogador.upgradePanel.SetActive(false);    // makes the upgrade/sell disappear
        Vector3 posicao = gameObject.transform.position;  // gets the position of the turret
        Instantiate(prefabUpgrade, new Vector3(posicao.x, posicao.y, posicao.z), Quaternion.identity); //create the upgrade tower
        UIJogador.CoinsP -= upgradeCost;   // takes the upgrade money from the player 
        Destroy(gameObject);    // Destroyes the old tower(un-upgraded)
    }
    public void SellTower() // Sells the tower
    {
        UIJogador.selectedIcon.SetActive(false);
        UIJogador.upgradePanel.SetActive(false);
        UIJogador.CoinsP += sellCost;  // gives the money to the player
        Destroy(gameObject);    //destroyes the object
    }

}
