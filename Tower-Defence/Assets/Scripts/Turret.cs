using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;



public class Turret : MonoBehaviour {

    public Transform target;
    public float range = 15f;

    public int dano = 0;

    public string monstroTag = "Monstro";

    public Transform Pivot;
    public float turnSpeed = 10f;

    public float fireRate = 1f;
    private float fireCountdown = 0f;

    public GameObject prefabBullet;
    public Transform firePoint; 


    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("NovoAlvo", 0f, 0.5f);
    }

    void NovoAlvo()
    {
        GameObject[] monstros = GameObject.FindGameObjectsWithTag(monstroTag);
        float menorDistancia = Mathf.Infinity;
        GameObject monstroProximo = null;
        foreach (GameObject monstro in monstros)
        {
            float distanciaMonstro = Vector3.Distance(transform.position, monstro.transform.position);
            if (distanciaMonstro < menorDistancia)
            {
                menorDistancia = distanciaMonstro;
                monstroProximo = monstro;
            }
        }

        if (monstroProximo != null && menorDistancia <= range)
        {
            target = monstroProximo.transform;
        }
        else
        {
            target = null;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (target == null)
            return;

        Vector3 dir = target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        Vector3 rotation = Quaternion.Lerp(Pivot.rotation, lookRotation, Time.deltaTime * turnSpeed).eulerAngles;
        Pivot.rotation = Quaternion.Euler(0f, rotation.y, 0f);

        if (fireCountdown <= 0f) {
            Shoot();
            fireCountdown = 1f / fireRate;
        }
       
        fireCountdown -= Time.deltaTime;
    }

    void Shoot() {
        GameObject bulletGo = Instantiate(prefabBullet, firePoint.position, firePoint.rotation) as GameObject;
        Bullet bullet = bulletGo.GetComponent<Bullet>();

        if (bullet != null) {
            bullet.Dano(dano);
            bullet.Seek(target);
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
