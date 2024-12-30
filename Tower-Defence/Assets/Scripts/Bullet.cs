using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Rendering;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Transform target;  // the monsters that the bullet is targeting 

    public float speed = 70f; // speed of the bulle

    private int damage = 0; // damage of the bullet

    public float explosionRad = 0f; // explosion radius of bullet if 0 just kils 1 enemy 

    public GameObject impactEffect; // prefab of the explosion when hiting enemey



    public void Seek(Transform _target) { 
        target = _target; 
    }// gets the target from the turret script

    public void Dano(int _damage) {
        damage = _damage;
    }// gets the damage from the turret script
  
    void Start()
    {
        
    }

    void Update()
    {
        if (target == null) { 
            Destroy(gameObject); // if the theres no more target the bullet is destroyed
            return;
        }

        Vector3 direction = target.position - transform.position;

        float distance = speed * Time.deltaTime;

        if (direction.magnitude <= distance) {
            HitTarget();
            return;
        }
        transform.Translate(direction.normalized*distance, Space.World);
    }

    void HitTarget() {
        Instantiate(impactEffect, transform.position, transform.rotation);
        if (explosionRad > 0f)
        {
            Explode();

        }
        else {
            target.GetComponent<Enemy>().Life -= damage;
        }
        Destroy(gameObject);
    }

    void Explode() {
        Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRad);
        foreach (Collider collider in colliders)
        {
            if (collider.tag == "Monstro") {
                collider.GetComponent<Enemy>().Life -= damage;
              
            }
        } 
    }
}
