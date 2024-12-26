using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Transform target;

    public float speed = 70f;

    public void Seek(Transform _target) { 

        target = _target;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (target == null) { 
            Destroy(gameObject);
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
        Debug.Log("quiicanga");
        Destroy(gameObject);
    }
}
